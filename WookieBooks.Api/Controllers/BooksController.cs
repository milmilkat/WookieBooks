using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.Models.Dtos;
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
        public async Task<ActionResult<IList<BookDto>>> ListAsync()
        {
            return Ok(await _bookService.ListAsync());
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<BookDto>> GetAsync([FromRoute] int id)
        {
            return Ok(await _bookService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] BookDto book)
        {
            return Ok(await _bookService.AddAsync(book));
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] BookDto book)
        {
            await _bookService.UpdateAsync(id, book);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
    }
}
