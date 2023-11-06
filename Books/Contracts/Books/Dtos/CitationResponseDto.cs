using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Contracts.Books.Dtos
{
    public class CitationResponseDto
    {
        public CitationType CitationType { get; set; }
        public string Citation { get; set; }
    }

    public enum CitationType
    {
        Chicago = 1,
        Mla = 2
    }
}
