using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Contracts.Books.Dtos
{
    public class BookData
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    }

    public class CommonBookData
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
    }
}
