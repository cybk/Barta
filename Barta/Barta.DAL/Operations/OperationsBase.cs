// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsBase.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the common operations that can be
//   performed by the Entities
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Barta.DAL.Contracts;
    using NHibernate;
    using NHibernate.Criterion;
    using Ninject;
    using Ninject.Extensions.Logging;

    /// <summary>
    /// Defines the common operations that can be
    /// performed by the Entities
    /// </summary>
    /// <typeparam name="T">
    /// The class that should implement the operations
    /// </typeparam>
    public abstract class OperationsBase<T> : IOperations<T>
    {
        /// <summary>
        /// Has the session build on the factory.
        /// </summary>
        private readonly ISessionFactory session;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase{T}" /> class.
        /// </summary>
        protected OperationsBase()
        {
            session = SessionFactory.CreateSession();
        }

        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        [Inject]
        public static ILogger Log { get; set; }

        /// <summary>
        /// Close the current open session.
        /// </summary>
        public void Dispose()
        {
            session.Close();
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>
        /// The list with all the instances
        /// </returns>
        public IList<T> FindAll()
        {
            var elems = new List<T>();
            this.ExecuteSearch(command => { elems = command.CreateCriteria(typeof(T)).List<T>().ToList(); });
            return elems;
        }

        /// <summary>
        /// Finds the by id.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The list with the elements that accomplish the criteria
        /// </returns>
        public IList<T> FindById(QueryOver<T, T> query)
        {
            using (var sessionOpen = this.session.OpenSession())
            {
                return query.GetExecutableQueryOver(sessionOpen).List();
            }
        }

        /// <summary>
        /// Saves the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The result for try to save the new element
        /// </returns>
        public Result Save(T element)
        {
            return this.Execute(command => command.Save(element));
        }

        /// <summary>
        /// Updates the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The result for try to update the element
        /// </returns>
        public Result Update(T element)
        {
            return this.Execute(command => command.Update(element));
        }

        /// <summary>
        /// Deletes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The result for try to delete the element
        /// </returns>
        public Result Delete(T element)
        {
            return this.Execute(command => command.Delete(element));
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// The result for the operation
        /// </returns>
        protected Result Execute(Action<ISession> command)
        {
            try
            {
                using (var sessionOpen = this.session.OpenSession())
                {
                    using (var trans = sessionOpen.BeginTransaction())
                    {
                        command(sessionOpen);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error at saving the information {0}", ex);
                return new Result(ex.Message);
            }

            return new Result();
        }

        /// <summary>
        /// Executes the search.
        /// </summary>
        /// <param name="command">The command.</param>
        protected void ExecuteSearch(Action<ISession> command)
        {
            using (var sessionOpen = this.session.OpenSession())
            {
                command(sessionOpen);
            }
        }
    }
}
