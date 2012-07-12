// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conference.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Defines the structure for the Conference table
//   used to save a register for all the conference
//   and their participants
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the structure for the Conference table
    /// used to save a register for all the conference
    /// and their participants
    /// </summary>
    public class Conference : ModelBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Conference" /> class.
        /// </summary>
        public Conference()
        {
            Participants = new List<Contact>();
            HistoryConferences = new List<HistoryConference>();
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public virtual Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>
        /// The participants.
        /// </value>
        public virtual IList<Contact> Participants { get; set; }

        /// <summary>
        /// Gets or sets the history conferences.
        /// </summary>
        /// <value>
        /// The history conferences.
        /// </value>
        public virtual IList<HistoryConference> HistoryConferences { get; set; }

        /// <summary>
        /// Histories the conference.
        /// </summary>
        /// <param name="history">The history.</param>
        public virtual void HistoryConference (HistoryConference history)
        {
            history.Conference = this;
            this.HistoryConferences.Add(history);
        }
    }
}
