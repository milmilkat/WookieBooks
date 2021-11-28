using System;
using WookieBooks.Services.Concretes;
using WookieBooks.Services.Interfaces;
using Xunit;

namespace WookieBooks.Services.Test
{
    public class BookServiceTest
    {
        private IBookService _bookService;

        public BookServiceTest()
        {
            _bookService = new BookService();
        }

        [Fact]
        public void Initial_Values_Test()
        {
            Assert.Equal(2, _bookService.List().Count);
        }

        [Fact]
        public void Delete_Not_Existing_Test()
        {
            Assert.Throws<ArgumentException>(() => _bookService.Delete(-1));
        }

        [Fact]
        public void Update_Not_Existing_Test()
        {
            Assert.Throws<ArgumentException>(() => _bookService.Update(-1, null));
        }
    }
}
