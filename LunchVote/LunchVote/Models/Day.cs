using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    /// <summary>
    /// This is an object to keep track of options for any given day
    /// </summary>
    public class Day
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Day"/> class.
        /// </summary>
        public Day()
        {
            Options = new Collection<DiningOption>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the dining options nominated for that day.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public virtual ICollection<DiningOption> Options { get; set; }
    }
}