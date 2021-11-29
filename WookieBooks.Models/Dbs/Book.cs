namespace WookieBooks.Models.Dbs
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public byte[] CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}
