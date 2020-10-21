using System.Collections.Generic;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string JWTtoken { get; set; }

        public virtual ICollection<Assigned_Book> Assigned_Books { get; set; }  
        public virtual ICollection<History> History { get; set; } 
    }
}