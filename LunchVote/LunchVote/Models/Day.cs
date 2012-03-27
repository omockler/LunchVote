using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    public class Day
    {
        public Day()
        {
            Options = new Collection<DiningOption>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<DiningOption> Options { get; set; }
    }
}