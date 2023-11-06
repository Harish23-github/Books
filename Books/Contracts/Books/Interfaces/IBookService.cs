using Books.Contracts.Books.Dtos;
using Books.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Contracts.Books.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookData> GetBooksUsingSproc();
        IEnumerable<BookData> GetSortedBooks();
        Task<Book> CreateBookAsync(Book book);
        Book GetBook(Guid id);
        string GenerateChicagoCitation(Book book);
        string GenerateMlaCitation(Book book);
        IEnumerable<CommonBookData> GetSecondSortedBooks();

        decimal GetTotalBooksPrice();
    }
}
