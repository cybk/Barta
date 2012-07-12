namespace Barta.DAL.Entities
{
    using System;

    /// <summary>
    /// DEfines the common properties to 
    /// be mapped on the databse
    /// </summary>
    public abstract class ModelBase
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public virtual int ID { get; set; }

        /// <summary>
        /// Gets or sets the added date.
        /// </summary>
        /// <value>
        /// The moment when the row was added.
        /// </value>
        public virtual DateTime Added { get; set; }

        /// <summary>
        /// Gets or sets the date for the last modification.
        /// </summary>
        /// <value>
        /// the moment when the row was modified
        /// </value>
        public virtual DateTime Modified { get; set; }
    }
}
