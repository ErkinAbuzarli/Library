using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class PostSearchDTO
    {
        [Required]
        public string SearchBy { get; set; }

        [Required]
        public string SearchString { get; set; }

    }
}