using Books.Contracts.Books.Dtos;
using Books.Models.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Contracts.Books.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(Guid id);
        void Create(Book book);
        IEnumerable<BookData> GetAllBooksUsingSproc();
        Task<Book> InsertAndGetAsync(Book book);
        IEnumerable<CommonBookData> GetAllSecondSortedBooksUsingSproc();
    }
}
