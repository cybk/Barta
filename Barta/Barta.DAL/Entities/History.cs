// --------------------------------------------------------------------------------------------------------------------
// <copyright file="History.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the History structure
//   This table is used to save the conversations'
//   history.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Entities
{
    /// <summary>
    /// Defines the History structure
    /// This table is used to save the conversations'
    /// history.
    /// </summary>
    public class History : ModelBase
    {
        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender; there is not a foreign key
        /// due to could be a contact or the logged user.
        /// </value>
        public virtual int Sender { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public virtual string Message { get; set; }

        /// <summary>
        /// Gets or sets the settings associated
        /// with the conversation history.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public virtual Settings Settings { get; set; }
    }
}
