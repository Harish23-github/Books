using Books.Contracts.Books.Dtos;
using Books.Contracts.Books.Interfaces;
using Books.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class BookController: Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult GetSortedBooks()
        {
            var books = _bookService.GetSortedBooks().ToList();
            return View(books);
        }

        public IActionResult GetSortedBooksUsingSproc()
        {
            var books = _bookService.GetBooksUsingSproc().ToList();
            return View(books);
        }

        public IActionResult GetSecondSortedBooks()
        {
            var books = _bookService.GetSecondSortedBooks().ToList();
            return View(books);
        }

        public IActionResult GetSecondSortedBooksUsingSproc()
        {
            var books = _bookService.GetSecondSortedBooks().ToList();
            return View(books);
        }

        public IActionResult GetChicagoCitation(Guid id)
        {
            try
            {
                Book book = _bookService.GetBook(id);
                string chicagoCitation = book.ChicagoCitation;
                if (string.IsNullOrEmpty(chicagoCitation))
                    chicagoCitation = _bookService.GenerateChicagoCitation(book);
                var response = new CitationResponseDto
                {
                    Citation = chicagoCitation,
                    CitationType = CitationType.Chicago
                };
                return View("Citation", response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception occurred, unable to get citation {ex.Message}");
                throw;
            }
        }

        public IActionResult GetMlaCitation(Guid id)
        {
            try
            {
                Book book = _bookService.GetBook(id);
                string mlaCitation = book.MlaCitation;
                if (string.IsNullOrEmpty(mlaCitation))
                    mlaCitation = _bookService.GenerateChicagoCitation(book);
                var response = new CitationResponseDto
                {
                    Citation = mlaCitation,
                    CitationType = CitationType.Mla
                };
                return View("Citation", response);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Exception occurred, unable to get citation {ex.Message}");
                throw;
            }
        }

        public IActionResult GetTotalBookPrice()
        {
            var bookPrice =  _bookService.GetTotalBooksPrice();
            return View("TotalBookPrice", (object)bookPrice);
        }
    }
}
