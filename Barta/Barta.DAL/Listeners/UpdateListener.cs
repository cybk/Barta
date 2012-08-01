// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateListener.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the UpdateListener type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Listeners
{
    using System;

    using NHibernate.Event;

    /// <summary>
    /// Defines some operations to made on the instance
    /// before update the information on the database
    /// </summary>
    public class UpdateListener : IPreUpdateEventListener
    {
        /// <summary>
        /// Set the value related to the moment on
        /// where the data is updated
        /// </summary>
        /// <param name="instance">the instance data to be updated</param>
        /// <returns>
        /// a false value
        /// </returns>
        public bool OnPreUpdate(PreUpdateEvent instance)
        {
            instance.SetDate(DateTime.Now, "Modified", instance.State);
            return false;
        }
    }
}
