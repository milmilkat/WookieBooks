namespace WookieBooks.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
        public byte[] CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}
