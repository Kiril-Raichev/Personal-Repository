using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int PageCount { get; set; }

            public Book(string title, string author, int pageCount)
            {
                Title = title;
                Author = author;
                PageCount = pageCount;
            }
        }
        public class Library : IEnumerable<Book>
        {
            public Library(IEnumerable<Book> books)
            {
                Books = books;
                Filter = books => true;
            }

            public IEnumerable<Book> Books { get; }
            public Predicate<Book> Filter { get; set; }
            public IEnumerator<Book> GetEnumerator()
            {
                return new MyEnumerator(Books, Filter);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return new MyEnumerator(Books, Filter);
            }
        }

        public class MyEnumerator : IEnumerator<Book>
        {
            private readonly IEnumerable<Book> books;
            private readonly Predicate<Book> filter;
            private IEnumerator<Book> enumerator;

            public MyEnumerator(IEnumerable<Book> books, Predicate<Book> filter)
            {
                this.books = books;
                this.filter = filter;
                Reset();
            }
            public Book Current => enumerator.Current;
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                while (enumerator.MoveNext())
                {
                    if (filter(enumerator.Current))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                enumerator = books.GetEnumerator();
            }
            public void Dispose()
            {
                enumerator.Dispose();
            }

        }

        public class MyUtils
        {
            public static List<Book> GetFiltered(IEnumerable<Book> books, Predicate<Book> filter)
            {
                Library library = new Library(books) { Filter = filter };
                return library.ToList();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
