using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace linqfundamentals
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public static class AuthorExtensions
    {
        public static bool IsFromUnitedKingdom(this Author author)
        {
            return author.Country == "United Kingdom";
        }
    }
}
