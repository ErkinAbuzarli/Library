using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.DTOs
{
    public class ReadBookDTO
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Pages { get; set; }

        public int Stock { get; set; }
    }
}