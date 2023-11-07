using Books.Contracts.Books;
using Books.Contracts.Books.Dtos;
using Books.Contracts.Books.Interfaces;
using Books.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetBook(Guid id)
        {
            return _bookRepository.Get(id);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            return await _bookRepository.InsertAndGetAsync(book);
        }

        public string GenerateChicagoCitation(Book book)
        {
            return $"{book.AuthorLastName}, {book.AuthorFirstName}, \"{book.Title}\" <i>{book.JournalTitle}</i>, {book.Publisher}, {book.PublicationDate.Year.ToString()}, pp. {book.PageRange}.";
        }

        public string GenerateMlaCitation(Book book)
        {
            string citation = string.Empty;
            if (book.VolumeNumber != null)
                citation = $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.PublicationDate.Year.ToString()}. \"{book.Title}.\" <i>{book.JournalTitle}</i>, no.{book.VolumeNumber} ({book.PublicationDate.ToString("MMMM")} {book.PublicationDate.Year.ToString()}): {book.PageRange}.";
            else
                citation = $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.PublicationDate.Year.ToString()}. \"{book.Title}.\" <i>{book.JournalTitle}</i>, ({book.PublicationDate.ToString("MMMM")} {book.PublicationDate.Year.ToString()}): {book.PageRange}.";
            if (!string.IsNullOrEmpty(book.Url))
                citation = citation + $" {book.Url}.";
            return citation;
        }

        public IEnumerable<BookData> GetBooksUsingSproc()
        {
            return _bookRepository.GetAllBooksUsingSproc();
        }

        public IEnumerable<BookData> GetSortedBooks()
        {
            return _bookRepository.GetAll().Select(x => new BookData
            {
                Id = x.Id,
                Title = x.Title,
                AuthorName = x.AuthorLastName + ", " + x.AuthorFirstName,
                Publisher = x.Publisher
            }).OrderBy(x => x.Publisher).ThenBy(x => x.AuthorName).ThenBy(x => x.Title);
        }

        public IEnumerable<CommonBookData> GetSecondSortedBooks()
        {
            return _bookRepository.GetAll().Select(x => new CommonBookData
            {
                Id = x.Id,
                Title = x.Title,
                AuthorName = x.AuthorLastName + ", " + x.AuthorFirstName,
            }).OrderBy(x => x.AuthorName).ThenBy(x => x.Title);
        }

        public decimal GetTotalBooksPrice()
        {
            return _bookRepository.GetAll().Select(x => x.Price).Sum();
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
