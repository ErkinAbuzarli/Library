using System.Collections.Generic;

namespace Library.Models
{
    public class ProfileDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public List<string> AssignedBooks { get; set; }

    }
}