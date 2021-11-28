using System;
using System.Collections.Generic;
using System.Linq;
using WookieBooks.Models;
using WookieBooks.Services.Interfaces;

namespace WookieBooks.Services.Concretes
{
    public class BookService : IBookService
    {
        private static List<Book> _Books = new List<Book>
        {
            new Book
            {
                Id = 0,
                Title = "First C#",
                Description = "A book about C#",
                AuthorId = 0,
                Author = new Author
                {
                    Id = 0,
                    Name = "Author1"
                },
                CoverImage = Properties.Resources.b1,
                Price = 20
            },
            new Book
            {
                Id = 1,
                Title = "Second C#",
                Description = "Second book about C#",
                AuthorId = 1,
                Author = new Author
                {
                    Id = 1,
                    Name = "Author2"
                },
                CoverImage = Properties.Resources.b2,
                Price = 5
            },
        };

        public IList<Book> List()
        {
            return _Books;
        }

        public Book Get(int id)
        {
            return _Books.FirstOrDefault(b => b.Id == id);
        }

        public int Add(Book book)
        {
            _Books.Add(book);
            return book.Id;
        }

        // This was the shortest solution I came with to update the reference of an element in a list
        public void Update(int id, Book book)
        {
            var index = _Books.FindIndex(b => b.Id == id);
            if (index == -1)
                throw new ArgumentException($"Book with id {id} could not be found");

            // Avoiding the cover image changes in general update
            book.CoverImage = _Books[index].CoverImage;

            _Books[index] = book;
        }

        public void UploadCoverImage(int id, byte[] coverImage)
        {
            var entity = _Books.FirstOrDefault(b => b.Id == id);
            if (entity == null)
                throw new ArgumentException($"Book with id {id} could not be found");

            entity.CoverImage = coverImage;
        }

        public void Delete(int id)
        {
            var entity = _Books.FirstOrDefault(b => b.Id == id);
            if (entity == null)
                throw new ArgumentException($"Book with id {id} could not be found");

            _Books.Remove(entity);
        }
    }
}
