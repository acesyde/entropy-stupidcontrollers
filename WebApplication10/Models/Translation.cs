using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Translation
    {
        [Required]
        public string Culture { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
