using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WookieBooks.Controllers;
using WookieBooks.Models.Dtos;
using WookieBooks.Services.Interfaces;
using Xunit;

namespace WookieBooks.Services.Test
{
    public class BooksControllerTest
    {
        private BooksController _booksController;
        private Mock<IBookService> _mockBookService = new Mock<IBookService>();

        public BooksControllerTest()
        {
            _booksController = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public async Task Get_Test()
        {
            var cSharpBookStringBytes = "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";

            AuthorDto author = new AuthorDto
            {
                Id = 1,
                Name = "Author1"
            };
            BookDto book = new BookDto
            {
                Author = author,
                AuthorId = author.Id,
                CoverImage = Convert.FromBase64String(cSharpBookStringBytes),
                Description = "A book about C#",
                Price = 20,
                Title = "C# book"
            };

            int bookId = 1;

            _mockBookService.Setup(x => x.AddAsync(book)).ReturnsAsync(bookId);

            var result = await _booksController.AddAsync(book);

            Assert.IsAssignableFrom<ActionResult<int>>(result);
            Assert.Equal(1, bookId);
        }
    }
}
