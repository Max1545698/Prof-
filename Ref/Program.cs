using System;
namespace Ref
{
    public class Book
    {
        public string Author;
        public string Title;
    }

    public class BookCollection
    {
        private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                                 new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
                               };
        private Book nobook = null;

        public ref Book GetBookByTitle(string title)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (title == books[i].Title)
                    return ref books[i];
            }
            return ref nobook;
        }

        public void ListBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, by {book.Author}");
            }
            Console.WriteLine();
        }
    }
    class Example
    {
        static void Main()
        {
            BookCollection bc = new BookCollection();
            bc.ListBooks();

            ref Book book = ref bc.GetBookByTitle("Call of the Wild, The");
            if (book != null)
                book = new Book { Title = "Republic, The", Author = "Plato" };
            bc.ListBooks();
        }
    }
}