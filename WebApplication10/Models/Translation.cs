using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Translation
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
