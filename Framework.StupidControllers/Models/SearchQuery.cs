using System.ComponentModel.DataAnnotations;

namespace Framework.StupidControllers.Models
{
    public class SearchQuery
    {
        [Required]
        public int? Offset { get; set; }

        [Required]
        public int? Limit { get; set; }

    }
}
