namespace Library.DTOs
{
    public class PostBookDTO
    {
        //[Required]
        public string Name { get; set; }

        //[Required]
        public string Author { get; set; }

        //[Required]
        public int Page { get; set; }

        //[Required]
        public int CategoryId { get; set; }

    }
}