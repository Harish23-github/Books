using Books.Contracts.Books.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models.Books
{
    public class Book: IBook
    {
        [Key]
        public Guid Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string MlaCitation { get; set; }
        public string ChicagoCitation { get; set; }
        public string JournalTitle { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PageRange { get; set; }
        public int? VolumeNumber { get; set; }
        public string Url { get; set; }
    }
}
