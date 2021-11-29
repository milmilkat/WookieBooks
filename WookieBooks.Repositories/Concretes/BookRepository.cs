using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WookieBooks.Data;
using WookieBooks.Models.Dbs;
using WookieBooks.Models.Dtos;
using WookieBooks.Repositories.Interfaces;

namespace WookieBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private WookieContext _wookieContext;
        private IMapper _mapper;

        public BookRepository(WookieContext wookieContext, IMapper mapper)
        {
            _wookieContext = wookieContext;
            _mapper = mapper;
        }

        public async Task<IList<BookDto>> ListAsync()
        {
            return await _wookieContext.Books
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDto> GetAsync(int id)
        {
            return await _wookieContext.Books
                .Include(b => b.Author)
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> AddAsync(BookDto book)
        {
            var entity = _mapper.Map<Book>(book);

            _wookieContext.Books.Add(entity);
            await _wookieContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(int id, BookDto book)
        {
            var entity = _wookieContext.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);

            if (entity == null)
                throw new ArgumentException($"Book with id {id} could not be found");

            _mapper.Map(book, entity);
            await _wookieContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _wookieContext.Books.FirstOrDefault(b => b.Id == id);
            if (entity == null)
                throw new ArgumentException($"Book with id {id} could not be found");

            _wookieContext.Books.Remove(entity);
            await _wookieContext.SaveChangesAsync();
        }
    }
}
