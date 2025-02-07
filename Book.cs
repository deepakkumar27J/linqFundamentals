using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqfundamentals
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public static class customFilters
    {
        public static IEnumerable<Book> FilterByPrice(this IEnumerable<Book> books, decimal maxPrice)
        {
            foreach (var book in books)
            {
                if (book.Price < maxPrice)
                {
                    yield return book;
                }
            }
        }

        public static IEnumerable<Book> GetBooksByGenre(this IEnumerable<Book>books, string genre)
        {
            foreach (var book in books)
            {
                if (book.Genre == genre)
                {
                    yield return book;
                }
            }
        }

        public static IEnumerable<Book> ProcessingBookByFile(this IEnumerable<Book> books, string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Skip(1)
                .Select(line => line.Split(','))
                .Select(parts => new Book
                {
                    BookId = int.Parse(parts[0]),
                    Title = parts[1],
                    AuthorId = int.Parse(parts[2]),
                    PublicationYear = int.Parse(parts[3]),
                    Genre = parts[4],
                    Price = decimal.Parse(parts[5])
                }).ToList();
        }
        public static decimal CalculateTotalPrice(this IEnumerable<Book> books)
        {
            return books.Sum(b => b.Price);
        }
    }
}
