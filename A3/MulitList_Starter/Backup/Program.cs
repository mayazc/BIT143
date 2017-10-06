using System;
using System.Collections.Generic;
using System.Text;

namespace MulitList_Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            (new UserInterface()).RunProgram();

            // Or, you could go with the more traditional:
            // UserInterface ui = new UserInterface();
            // ui.RunProgram();
        }
    }

    // Bit of a hack, but still an interesting idea....
    enum MenuOptions
    {
        // DO NOT USE ZERO!
        // (TryParse will set choice to zero if a non-number string is typed,
        // and we don't want to accidentally set nChoice to be a member of this enum!)
        QUIT = 1,
        ADD_BOOK,
        PRINT_BY_AUTHOR,
        PRINT_BY_TITLE,
        REMOVE_BOOK,
        RUN_TESTS
    }

    class UserInterface
    {
        MultiLinkedListOfBooks theList;
        public void RunProgram()
        {
            int nChoice;
            theList = new MultiLinkedListOfBooks();

            do // main loop
            {
                Console.WriteLine("Your options:");
                Console.WriteLine("{0} : End the program", (int)MenuOptions.QUIT);
                Console.WriteLine("{0} : Add a book", (int)MenuOptions.ADD_BOOK);
                Console.WriteLine("{0} : Print all books (by author)", (int)MenuOptions.PRINT_BY_AUTHOR);
                Console.WriteLine("{0} : Print all books (by title)", (int)MenuOptions.PRINT_BY_TITLE);
                Console.WriteLine("{0} : Remove a Book", (int)MenuOptions.REMOVE_BOOK);
                Console.WriteLine("{0} : RUN TESTS", (int)MenuOptions.RUN_TESTS);
                if (!Int32.TryParse(Console.ReadLine(), out nChoice))
                {
                    Console.WriteLine("You need to type in a valid, whole number!");
                    continue;
                }
                switch ((MenuOptions)nChoice)
                {
                    case MenuOptions.QUIT:
                        Console.WriteLine("Thank you for using the multi-list program!");
                        break;
                    case MenuOptions.ADD_BOOK:
                        this.AddBook();
                        break;
                    case MenuOptions.PRINT_BY_AUTHOR:
                        theList.PrintByAuthor();
                        break;
                    case MenuOptions.PRINT_BY_TITLE:
                        theList.PrintByTitle();
                        break;
                    case MenuOptions.REMOVE_BOOK:
                        this.RemoveBook();
                        break;
                    case MenuOptions.RUN_TESTS:
                        AllTests tester = new AllTests();
                        tester.RunTests();
                        break;
                    default:
                        Console.WriteLine("I'm sorry, but that wasn't a valid menu option");
                        break;

                }
            } while (nChoice != (int)MenuOptions.QUIT);
        }

        public void AddBook()
        {
            Console.WriteLine("ADD A BOOK!");

            Console.WriteLine("Author name?");
            string author = Console.ReadLine();

            Console.WriteLine("Title?");
            string title = Console.ReadLine();

            double price = -1;
            while (price < 0)
            {
                Console.WriteLine("Price?");
                if (!Double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("I'm sorry, but that's not a number!");
                    price = -1;
                }
                else if (price < 0)
                {
                    Console.WriteLine("I'm sorry, but the number must be zero, or greater!!");
                }
            }

            ErrorCode ec = theList.Add(author, title, price);

            // STUDENTS: YOUR ERROR-CHECKING CODE SHOULD GO HERE!
        }

        public void RemoveBook()
        {
            Console.WriteLine("REMOVE A BOOK!");

            Console.WriteLine("Author name?");
            string author = Console.ReadLine();

            Console.WriteLine("Title?");
            string title = Console.ReadLine();

            ErrorCode ec = theList.Remove(author, title);

            // STUDENTS: YOUR ERROR-CHECKING CODE SHOULD GO HERE!
        }
    }

    enum ErrorCode
    {
        OK,
        DuplicateBook,
        BookNotFound
    }

    class MultiLinkedListOfBooks
    {
        private class Book
        {

            // Probably good to have a Print method on this class

            /// <summary>
            /// Compares the parameter, and this book, and determines which one should go
            /// first, in the AUTHOR list
            /// </summary>
            /// <param name="otherBook"></param>
            /// <returns> -1 if this book goes before the otherBook
            ///           0 if they're duplicate books
            ///           +1 if this book goes AFTER the otherBook</returns>
            public int CompareByAuthor(Book otherBook)
            {
                return 0;
            }


            /// <summary>
            /// Compares the parameter, and this book, and determines which one should go
            /// first, in the TITLE list
            /// </summary>
            /// <param name="otherBook"></param>
            /// <returns> -1 if this book goes before the otherBook
            ///           0 if they're duplicate books
            ///           +1 if this book goes AFTER the otherBook</returns>
            public int CompareByTitle(Book otherBook)
            {
                return 0;
            }
        }

        public ErrorCode Add(string author, string title, double price)
        {
            // If the book is already in the list (author, title), then
            // do the following:
            return ErrorCode.DuplicateBook;

            // having multiple books with the same author, but different titles, or 
            // multiple books with the same title, but different authors, is fine.

            // two books with the same author & title should be identified as duplicates,
            // even if the prices are different.
        }

        public void PrintByAuthor()
        {
            // if there are no books, then print out a message saying that the list is empty
        }
        public void PrintByTitle()
        {
            // if there are no books, then print out a message saying that the list is empty
        }

        public ErrorCode Remove(string author, string title)
        {
            // if there isn't an exact match, then do the following:
            return ErrorCode.BookNotFound;
            // (this includes finding a book by the given author, but with a different title,
            // or a book with the given title, but a different author)
        }
    }
}
