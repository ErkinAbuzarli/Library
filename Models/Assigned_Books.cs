namespace Library.Models
{
    public class Assigned_Book
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CopyId { get; set; }
        public virtual User Users { get; set; }
        public virtual Copy Copies { get; set; }
    }
}