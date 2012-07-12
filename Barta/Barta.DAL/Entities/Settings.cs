// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the structure for the
//   settings table on Database
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the structure for the 
    /// settings table on Database
    /// </summary>
    public class Settings : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings" /> class.
        /// </summary>
        public Settings()
        {
            Contacts = new List<Contact>();
            Histories = new List<History>();
            Conferences = new List<Conference>();
        }

        /// <summary>
        /// Gets or sets the JID.
        /// </summary>
        /// <value>
        /// The unique identifier for the account
        /// on the jabber system.
        /// </value>
        public virtual string JID { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets the pass.
        /// </summary>
        /// <value>
        /// The pass.
        /// </value>
        public virtual string Pass { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt use at encrypt the password.
        /// </value>
        public virtual string Salt { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public virtual int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use SSL]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool UseSsl { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts references to the logged user.
        /// </value>
        public virtual IList<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the histories.
        /// </summary>
        /// <value>
        /// The histories.
        /// </value>
        public virtual IList<History> Histories { get; set; }

        /// <summary>
        /// Gets or sets the conferences.
        /// </summary>
        /// <value>
        /// The conferences.
        /// </value>
        public virtual IList<Conference> Conferences { get; set; }

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public virtual void AddContact(Contact contact)
        {
            contact.Settings = this;
            this.Contacts.Add(contact);
        }

        /// <summary>
        /// Adds the history.
        /// </summary>
        /// <param name="history">The history.</param>
        public virtual void AddHistory(History history)
        {
            history.Settings = this;
            this.Histories.Add(history);
        }

        /// <summary>
        /// Adds the conference.
        /// </summary>
        /// <param name="conference">The conference.</param>
        public virtual void AddConference(Conference conference)
        {
            conference.Settings = this;
            this.Conferences.Add(conference);
        }
   }
}
