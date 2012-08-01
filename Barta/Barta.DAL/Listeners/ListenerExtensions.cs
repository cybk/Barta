// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListenerExtensions.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Some listener extensions used to
//   set some common information on the entities
//   to be saved on the DB
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Listeners
{
    using System;

    using NHibernate.Event;

    /// <summary>
    /// Some listener extensions used to 
    /// set some common information on the entities
    /// to be saved on the DB
    /// </summary>
    public static class ListenerExtensions
    {
        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="moment">The moment.</param>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        public static void SetDate(this AbstractPreDatabaseOperationEvent instance, DateTime moment, string name, object[] state)
        {
            var added = instance.Entity.GetType();
            if (added.GetProperty(name) == null)
            {
                return;
            }

            added.GetProperty(name).SetValue(instance.Entity, moment, null);
            var index = Array.IndexOf(instance.Persister.PropertyNames, name);
            if (index == -1)
            {
                return;
            }

            state[index] = moment;
        }
    }
}
