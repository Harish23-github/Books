using Books.Contracts.Books.Dtos;
using Books.Contracts.Books.Interfaces;
using Books.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Domain.Repositories
{
    public class BookRepository:  IBookRepository
    {
        private readonly BookDbContext _dbContext;
        public BookRepository(BookDbContext context)
        {
            _dbContext = context;
        }

        public Book Get(Guid id)
        {
            return _dbContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.AsEnumerable();
        }

        public IEnumerable<BookData> GetAllBooksUsingSproc()
        {
            return _dbContext.Set<BookData>().FromSqlRaw("EXEC GetBooksByFirstSortOrder");
        }

        public IEnumerable<CommonBookData> GetAllSecondSortedBooksUsingSproc()
        {
            return _dbContext.Set<CommonBookData>().FromSqlRaw("EXEC GetBooksBySecondSortOrder");
        }

        public void Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public async Task<Book> InsertAndGetAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public void Update(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
