using System;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    /// <summary>
    /// This is an entry to track a location and it's votes for a given day
    /// </summary>
    public class DiningOption
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>
        /// The votes.
        /// </value>
        public int Votes { get; set; }

        /// <summary>
        /// Gets or sets the location id.
        /// </summary>
        /// <value>
        /// The location id.
        /// </value>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets the day id.
        /// </summary>
        /// <value>
        /// The day id.
        /// </value>
        public Guid DayId { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        public virtual Day Day { get; set; }
    }
}