using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Contracts.Books.Interfaces
{
    public interface IBook
    {
        Guid Id { get; set; }
        string Publisher { get; set; }
        string Title { get; set; }
        string AuthorLastName { get; set; }
        string AuthorFirstName { get; set; }
        decimal Price { get; set; }
        string MlaCitation { get; set; }
        string ChicagoCitation { get; set; }
        string JournalTitle { get; set; }
        DateTime PublicationDate { get; set; }
        string PageRange { get; set; }
        int? VolumeNumber { get; set; }
        string? Url { get; set; }
    }
}
