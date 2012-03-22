using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    public class Day
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<DiningOption> Options { get; set; }
    }
}