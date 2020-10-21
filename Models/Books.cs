using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
    
        public virtual ICollection<Copy> Copies { get; set; }           
    }
}