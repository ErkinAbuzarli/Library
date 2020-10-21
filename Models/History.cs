using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CopyId { get; set; }

        
        public virtual User Users { get; set; }
        public virtual Copy Copies { get; set; }
       


        [Column(TypeName="Date")]
        public DateTime TakenDate { get; set; }

        [Column(TypeName="Date")]
        public DateTime BackDate { get; set; }

    }
}