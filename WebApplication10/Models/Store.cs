using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Store
    {
        [Required]
        public string Name { get; set; }
        public string Uri { get; set; }
        [Url]
        [Required]
        public string Url { get; set; }
    }
}
