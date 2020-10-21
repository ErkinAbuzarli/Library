using System.Collections.Generic;

namespace Library.Models
{
    public class Copy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public bool Status { get; set; }

        public virtual Book Books { get; set; }
        public virtual ICollection<Assigned_Book> Assigned_Books { get; set; }  
        public virtual ICollection<History> History { get; set; }  
    }
}