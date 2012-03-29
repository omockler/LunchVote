using System;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    /// <summary>
    /// A location to eat at
    /// </summary>
    public class Location
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}