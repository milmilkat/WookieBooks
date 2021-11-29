using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.Models.Dtos;
using WookieBooks.Repositories.Interfaces;
using WookieBooks.Services.Interfaces;

namespace WookieBooks.Services.Concretes
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IList<BookDto>> ListAsync()
        {
            return await _bookRepository.ListAsync();
        }

        public async Task<BookDto> GetAsync(int id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<int> AddAsync(BookDto book)
        {
            return await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(int id, BookDto book)
        {
            await _bookRepository.UpdateAsync(id, book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
