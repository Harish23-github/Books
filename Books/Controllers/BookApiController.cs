using Books.Contracts.Books.Dtos;
using Books.Contracts.Books.Interfaces;
using Books.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/book")]
    public class BookApiController : ControllerBase
    {
        private readonly ILogger<BookApiController> _logger;
        private readonly IBookService _bookService;

        public BookApiController(ILogger<BookApiController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("first-sorted-books")]
        public IActionResult GetSortedBooks()
        {
            var books = _bookService.GetSortedBooks().ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("first-sorted-books-sproc")]
        public IActionResult GetSortedBooksUsingSproc()
        {
            var books = _bookService.GetBooksUsingSproc().ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("second-sorted-books")]
        public IActionResult GetSecondSortedBooks()
        {
            var books = _bookService.GetSecondSortedBooks().ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("second-sorted-books-sproc")]
        public IActionResult GetSecondSortedBooksUsingSproc()
        {
            var books = _bookService.GetSecondSortedBooks().ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("chicago-citation")]
        public IActionResult GetChicagoCitation(Guid id)
        {
            try
            {
                Book book = _bookService.GetBook(id);
                string chicagoCitation = book.ChicagoCitation;
                if (string.IsNullOrEmpty(chicagoCitation))
                {
                    chicagoCitation = _bookService.GenerateChicagoCitation(book);
                    if (!string.IsNullOrEmpty(chicagoCitation))
                    {
                        book.ChicagoCitation = chicagoCitation;
                        _bookService.UpdateBook(book);
                    }
                }
                var response = new CitationResponseDto
                {
                    Citation = chicagoCitation,
                    CitationType = CitationType.Chicago
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception occurred, unable to get citation {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [Route("mla-citation")]
        public IActionResult GetMlaCitation(Guid id)
        {
            try
            {
                Book book = _bookService.GetBook(id);
                string mlaCitation = book.MlaCitation;
                if (string.IsNullOrEmpty(mlaCitation))
                {
                    mlaCitation = _bookService.GenerateMlaCitation(book);
                    if (!string.IsNullOrEmpty(mlaCitation))
                    {
                        book.MlaCitation = mlaCitation;
                        _bookService.UpdateBook(book);
                    }
                }
                var response = new CitationResponseDto
                {
                    Citation = mlaCitation,
                    CitationType = CitationType.Mla
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception occurred, unable to get citation {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [Route("total-book-price")]
        public IActionResult GetTotalBookPrice()
        {
            var bookPrice = _bookService.GetTotalBooksPrice();
            return Ok(bookPrice);
        }
    }
}
