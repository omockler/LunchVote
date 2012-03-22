using System;
using System.ComponentModel.DataAnnotations;

namespace LunchVote.Models
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}