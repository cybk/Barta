// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryConference.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   DEfines the structure for the HistoryConference table
//   used to save the conferences' conversations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Entities
{
    /// <summary>
    /// DEfines the structure for the HistoryConference table
    /// used to save the conferences' conversations
    /// </summary>
    public class HistoryConference : ModelBase
    {
        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
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
        /// Gets or sets the conference.
        /// </summary>
        /// <value>
        /// The conference.
        /// </value>
        public virtual Conference Conference { get; set; }
    }
}
