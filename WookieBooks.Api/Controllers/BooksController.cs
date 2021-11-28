using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using WookieBooks.Models;
using WookieBooks.Services.Interfaces;

namespace WookieBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> List()
        {
            return Ok(_bookService.List());
        }

        [HttpGet, Route("{id}")]
        public ActionResult<Book> Get([FromRoute] int id)
        {
            return Ok(_bookService.Get(id));
        }

        [HttpPost]
        public ActionResult<int> Add([FromBody] Book book)
        {
            return Ok(_bookService.Add(book));
        }

        [HttpPut, Route("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Book book)
        {
            _bookService.Update(id, book);
            return Ok();
        }

        [HttpPut, Route("UploadCoverImage/{id}")]
        public HttpResponseMessage UploadCoverImage([FromRoute] int id, [FromForm] IFormFile coverImage)
        {
            if (coverImage == null)
            {
                var badResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                badResponse.Content = new StringContent("Uploaded file is empty");
                return badResponse;
            }

            using (var memoryStream = new MemoryStream())
            {
                coverImage.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                _bookService.UploadCoverImage(id, fileBytes);
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

        [HttpDelete, Route("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bookService.Delete(id);
            return Ok();
        }
    }
}
