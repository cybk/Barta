// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperations.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the structure that we have all the elements that
//   implement the Operations elements
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Contracts
{
    using System;
    using System.Collections.Generic;

    using NHibernate.Criterion;

    /// <summary>
    /// Defines the structure that we have all the elements that 
    /// implement the Operations elements
    /// </summary>
    /// <typeparam name="T">
    /// The instance on where the operation is performed
    /// </typeparam>
    public interface IOperations<T> : IDisposable
    {
        /// <summary>
        /// Saves the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The instance that specify the operation's result</returns>
        Result Save(T element);

        /// <summary>
        /// Updates the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The instance that require be updated
        /// </returns>
        Result Update(T element);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>
        /// retrieve all the elements for a specified instance
        /// </returns>
        IList<T> FindAll();

        /// <summary>
        /// Finds the by id.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The elements that accomplish the indicated criteria
        /// </returns>
        IList<T> FindById(QueryOver<T, T> query);

        /// <summary>
        /// Deletes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The result for try to delete the element.
        /// </returns>
        Result Delete(T element);

    }
}
