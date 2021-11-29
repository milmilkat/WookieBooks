using System.Collections.Generic;
using System.Threading.Tasks;
using WookieBooks.Models.Dtos;

namespace WookieBooks.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<IList<BookDto>> ListAsync();
        public Task<BookDto> GetAsync(int id);
        public Task<int> AddAsync(BookDto book);
        public Task UpdateAsync(int id, BookDto book);
        public Task DeleteAsync(int id);
    }
}
