using System.Collections.Generic;

namespace WookieBooks.Models.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
