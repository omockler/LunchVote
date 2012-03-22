using System;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    public class DiningOption
    {
        [Key]
        public Guid Id { get; set; }
        public int Votes { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}