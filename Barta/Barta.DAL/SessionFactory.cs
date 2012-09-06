// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionFactory.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the SessionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL
{
    using System;

    using Barta.DAL.Conventions;
    using Barta.DAL.Entities;
    using Barta.DAL.Listeners;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Event;

    using Ninject;
    using Ninject.Extensions.Logging;

    /// <summary>
    ///  Defines the start configuration and 
    /// the mapping used for the nhibernate logic
    /// </summary>
    public class SessionFactory
    {
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        [Inject]
        public static ILogger Log { get; set; }

        /// <summary>
        /// Creates the session.
        /// </summary>
        /// <returns>the new session just created</returns>
        public static ISessionFactory CreateSession()
        {
            try
            {
                var cfg = new AutoMapConfig();
                var configure =
                    Fluently.Configure().Database(
                        MsSqlConfiguration.MsSql2008.ConnectionString(
                            connect => connect.FromConnectionStringWithKey("ApplicationServices")));
                configure.Mappings(
                    m =>
                    m.AutoMappings.Add(
                        AutoMap.AssemblyOf<Settings>(cfg).Conventions.Add<ForeignKeyConventions>().Override<Settings>(
                            map => map.HasMany(x => x.Contacts).Cascade.All()).Override<Settings>(
                                map => map.HasMany(x => x.Histories).Cascade.All()).Override<Settings>(
                                    map => map.HasMany(x => x.Conferences).Cascade.All()).Override<Conference>(
                                        map => map.HasMany(x => x.HistoryConferences)).Override<Conference>(
                                            map => map.HasManyToMany(x => x.Participants).Cascade.All()).Override<Contact>(
                                                map => map.HasManyToMany(x => x.Conferences).Inverse())));

                configure.ExposeConfiguration(
                    x => x.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new InsertListener() });

                configure.ExposeConfiguration(
                    x => x.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new UpdateListener() });
                return configure.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Log.Error("There was an error at create the session: {0}", ex);
                throw;
            }
        }
    }
}
