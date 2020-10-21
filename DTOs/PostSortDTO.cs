using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class PostSortDTO
    {
        [Required]
        public string OrderBy { get; set; }

        [Required]
        public bool Asc { get; set; }

    }
}