using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
