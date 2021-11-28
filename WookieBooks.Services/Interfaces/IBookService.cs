using System.Collections.Generic;
using WookieBooks.Models;

namespace WookieBooks.Services.Interfaces
{
    public interface IBookService
    {
        public IList<Book> List();
        public Book Get(int id);
        public int Add(Book book);
        public void Update(int id, Book book);
        public void UploadCoverImage(int id, byte[] coverImage);
        public void Delete(int id);
    }
}
