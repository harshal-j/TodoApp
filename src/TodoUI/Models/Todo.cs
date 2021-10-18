using System;
using System.ComponentModel.DataAnnotations;

namespace TodoUI.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
