using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class PostFilterDTO
    {
        [Required]
        public string Option { get; set; }

        [Required]
        public string MinDate { get; set; }

        [Required]
        public string MaxDate { get; set; }

    }
}