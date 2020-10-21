using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class PostCategoryDTO
    {
        [Required]
        public string Name { get; set; }

    }
}