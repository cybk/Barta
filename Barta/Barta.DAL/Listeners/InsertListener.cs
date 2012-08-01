// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InsertListener.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines customized operations applied to a class
//   before insert him on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Listeners
{
    using System;

    using NHibernate.Event;

    /// <summary>
    /// Defines customized operations applied to a class 
    /// before insert him on the database.
    /// </summary>
    public class InsertListener : IPreInsertEventListener
    {

        /// <summary>
        /// Add the information related to The dates on where 
        /// the data was created on the database
        /// </summary>
        /// <param name="instance">the instance for the data to save</param>
        /// <returns>a false value</returns>
        public bool OnPreInsert(PreInsertEvent instance)
        {
            var moment = DateTime.Now;
            instance.SetDate(moment, "Added", instance.State);
            instance.SetDate(moment, "Modified", instance.State);
            return false;
        }
    }
}
