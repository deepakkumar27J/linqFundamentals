using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace linqfundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data for authors
            var authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "George Orwell", Country = "United Kingdom" },
                new Author { AuthorId = 2, Name = "J.K. Rowling", Country = "United Kingdom" },
                new Author { AuthorId = 3, Name = "Stephen King", Country = "United States" }
            };

            // Sample data for books
            var books = new List<Book>
            {
                new Book
                {
                    BookId = 1, Title = "1984", AuthorId = 1, PublicationYear = 1949, Genre = "Dystopian", Price = 9.99m
                },
                new Book
                {
                    BookId = 2, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 2,
                    PublicationYear = 1997, Genre = "Fantasy", Price = 8.99m
                },
                new Book
                {
                    BookId = 3, Title = "The Shining", AuthorId = 3, PublicationYear = 1977, Genre = "Horror",
                    Price = 7.99m
                }
            };
            //Q12

            var csvData = "BookId,Title,AuthorId,PublicationYear,Genre,Price\n" +
                          "1,1984,1,1949,Dystopian,9.99\n" +
                          "2,Harry Potter and the Philosopher's Stone,2,1997,Fantasy,8.99\n" +
                          "3,The Shining,3,1977,Horror,7.99";
            var lines = csvData.Split( new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var header = lines.First();
            var booksFromCSV = lines.Skip(1)
                                                .Select(line => line.Split(','))
                                                .Select(parts => new Book
                                                {
                                                    BookId = int.Parse(parts[0]),
                                                    Title = parts[1],
                                                    AuthorId = int.Parse(parts[2]),
                                                    PublicationYear = int.Parse(parts[3]),
                                                    Genre = parts[4],
                                                    Price = decimal.Parse(parts[5])
                                                });

            
            
            // Q13

            var booksFromFile = books.ProcessingBookByFile("books.csv");


            // Q17
            var authorsWithBooks = new List<AuthorWithBooks>
            {
                new AuthorWithBooks
                {
                    Author = new Author { AuthorId = 1, Name = "George Orwell", Country = "United Kingdom" },
                    Books = new List<Book> { new Book { BookId = 1, Title = "1984", AuthorId = 1, PublicationYear = 1949, Genre = "Dystopian", Price = 9.99m } }
                },
                new AuthorWithBooks
                {
                    Author = new Author { AuthorId = 2, Name = "J.K. Rowling", Country = "United Kingdom" },
                    Books = new List<Book> { new Book { BookId = 2, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 2, PublicationYear = 1997, Genre = "Fantasy", Price = 8.99m } }
                }
            };

            // Q18
            

            //var allBookTitles = authorsWithBooks.SelectMany(a => a.Books.Select(b => b.Title));

            //foreach (var title in allBookTitles)
            //{
            //    Console.WriteLine(title);
            //}
            // Q16
            //var booksByProject = booksFromFile.Select(b => new 
            //{
            //    b.Title,
            //    b.Genre
            //}).ToList();

            //foreach (var book in booksByProject)
            //{
            //    Console.WriteLine($"Title : {book.Title} , Genre : {book.Genre}");
            //}

            //Q15
            //var booksByAny = booksFromFile.Where(b => b.AuthorId == 3).Any();
            //Console.WriteLine(booksByAny);

            //var booksByAll = booksFromFile.All(b => b.Price <= 15.0m);
            //Console.WriteLine(booksByAll);

            //var booksByContain = booksFromFile.Select(b => b.Title).Contains("1984");
            //Console.WriteLine(booksByContain);

            //Q14: 
            //var booksWhereFirst = booksFromFile.Where(b => b.Genre == "Horror").First();
            //Console.WriteLine(booksWhereFirst.Title);
            //foreach (var book in booksWhereFirst)
            //{
            //    Console.WriteLine($"Title : {book}");
            //}

            //Q11

            //var booksStreamedOperator = books.Where(b => b.Price < 10.0m).Select(b => b.Title);

            //foreach (var book in booksStreamedOperator)
            //{
            //    Console.WriteLine($"Title: {book}");
            //}

            //Q10


            //var booksDeffered = Enumerable.Empty<Book>();
            //Console.WriteLine("checking if this is printing first or the query for deffered part");

            //try
            //{
            //     booksDeffered = books.Where(b => b.Price < 0);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Exception : {e.Message}");
            //}

            //try
            //{
            //    var firstBook = booksDeffered.First(); // This will throw an exception if the list is empty
            //    Console.WriteLine(firstBook.Title);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Exception: {e.Message}");
            //}


            // Q9
            //var booksDeffered = books.Where(b => b.Genre == "Fantasy");

            //Console.WriteLine("checking if this is printing first or the query for deffered part");

            //foreach (var book in booksDeffered)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //Q8
            //var booksByGenre = books.GetBooksByGenre("Horror");
            //foreach (var book in booksByGenre)
            //{
            //    Console.WriteLine($"{book.Title}, {book.Genre}");
            //}
            // Q1

            //var booksAndAuthors = from book in books
            //    join author in authors on book.AuthorId equals author.AuthorId
            //    select new { book.Title, book.Genre, book.Price, author.Name };

            //foreach (var book in booksAndAuthors)
            //{
            //    Console.WriteLine($"{book.Title}, {book.Name}");
            //}

            // Q2

            //var booksByUKAuthors = from book in books
            //    join author in authors on book.AuthorId equals author.AuthorId
            //    where author.IsFromUnitedKingdom()
            //    select new { book.Title, author.Name, author.Country };
            //foreach (var book in booksByUKAuthors)
            //{
            //    Console.WriteLine($"{book.Title}, {book.Name}, {book.Country}");
            //}

            //  Q3

            //var booksPublishedAfter = books.Where(b => b.PublicationYear > 1980)
            //    .Select(b => b.Title).ToList();

            //foreach (var book in booksPublishedAfter)
            //{
            //    Console.WriteLine($"{book}");
            //}

            // Q4
            //Func<Book, bool> fantasyBooks = b => b.Genre == "Fantasy";
            //Action<string> bookTitls = title => Console.WriteLine(title);

            //var booksFantasy = books.Where(fantasyBooks);
            //foreach (var book in booksFantasy)
            //{
            //    bookTitls(book.Title);
            //}

            // Q5
            //var booksWithTitle = books.Select(b => new{ b.Title, b.PublicationYear});
            //foreach (var book in booksWithTitle)
            //{
            //    Console.WriteLine($"Title : {
            //        book.Title
            //    }, Publication Year : {book.PublicationYear}");
            //}

            // Q6

            // Query syntax
            //var authorsAlphabOrder = from book in books
            //    join author in authors on book.AuthorId equals author.AuthorId
            //    orderby author.Name ascending
            //    select new { author.Name };
            //foreach (var author in authorsAlphabOrder)
            //{
            //    Console.WriteLine($"{author.Name}");
            //}

            //var authorsAlphabOrderMethod = authors.OrderByDescending(a => a.Name).Select(a => a.Name);

            //foreach (var author in authorsAlphabOrderMethod)
            //{
            //    Console.WriteLine($"{author}");
            //}

            // Q7
            //var booksLessThanMax = books.FilterByPrice(9.1m);

            //foreach (var book in booksLessThanMax)
            //{
            //    Console.WriteLine($"{book.Title}");
            //}
        }


    }

}