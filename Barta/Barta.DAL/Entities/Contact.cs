// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the structure for the Contacts table
//   Used to save the detailed information from the
//   Contacts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the structure for the Contacts table
    /// Used to save the detailed information from the
    /// Contacts.
    /// </summary>
    public class Contact : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        public Contact()
        {
            this.Conferences = new List<Conference>();
        }

        /// <summary>
        /// Gets or sets the JID.
        /// </summary>
        /// <value>
        /// The JID is the unique identifier used
        /// on jabber for every user.
        /// </value>
        public virtual string Jid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public virtual Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the enc key.
        /// </summary>
        /// <value>
        /// The enc key.
        /// </value>
        public virtual string EncKey { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt.
        /// </value>
        public virtual string Salt { get; set; }

        /// <summary>
        /// Gets or sets the enable enc.
        /// </summary>
        /// <value>
        /// The enable enc.
        /// </value>
        public virtual string EnableEnc { get; set; }

        /// <summary>
        /// Gets or sets the conferences.
        /// </summary>
        /// <value>
        /// The conferences.
        /// </value>
        public virtual IList<Conference> Conferences { get; set; }
    }
}
