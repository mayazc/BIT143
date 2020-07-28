using System;
using System.Collections.Generic;
using System.Text;


/**
 * BIT 143, 2016 Fall 
 * A3.0
 */

/**
 * THe missing something: The method call run test was missing. You usally give us a project test or just to move on... so I just created an empty class and method so the
 * prompt 6 does nothing but completes the sequence. When the program is run, it keeps it's do-while loop working. Basically checking all the boxes to complete the task, even
 * if it doesn't necessarily have a full function.
 */
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
            errors(ec);
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
            errors(ec);
            // STUDENTS: YOUR ERROR-CHECKING CODE SHOULD GO HERE!
        }
        public void errors(ErrorCode checkEC)
        {
            if (checkEC == ErrorCode.OK)
            {
                Console.WriteLine("Your action was a success");
            }
            else if (checkEC == ErrorCode.DuplicateBook)
            {
                Console.WriteLine("This book cannot be added twice into the system");
            }
            else
            {
                Console.WriteLine("Book search, cannot be found");
            }
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
            public string author;
            public string title;
            public double price;
            public Book nextTitle;
            public Book previousTitle;
            public Book nextAuthor;
            public Book previousAuthor;

            public Book(string auth, string title, double pri)
            {
                author = auth;
                this.title = title;
                price = pri;
            }

            // Probably good to have a Print method on this class
            public void print(bool theAuthor)
            {
                Book book = this;
                if (book == null)
                {
                    Console.WriteLine("We currently have no books in stock");
                    return;
                }
                while (book != null)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Book Title: {0} \nBook Author: {1}\nPrice: ${2}", book.title, book.author, book.price);
                    Console.WriteLine("----------------------------------");

                    if (theAuthor == true)
                    {
                        book = book.nextAuthor;
                    }
                    else
                    {
                        book = book.nextTitle;
                    }
                }
            }

            

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
                int counter = otherBook.title.CompareTo(title);
                return counter;
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
                int counter = otherBook.author.CompareTo(author);
                return counter;
            }
        }

        private Book fAuthor;
        private Book fTitle;

        public MultiLinkedListOfBooks()
        {
            fAuthor = null;
            fTitle = null;
        }

        public ErrorCode Add(string author, string title, double price)
        {
            // If the book is already in the list (author, title), then
            // do the following: return ErrorCode.DuplicateBook;

            // having multiple books with the same author, but different titles, or 
            // multiple books with the same title, but different authors, is fine.
            // two books with the same author & title should be identified as duplicates,
            // even if the prices are different.

            Book newBook = new Book(author, title, price);
            if (fAuthor == null)
            {
                fAuthor = newBook;
                fTitle = newBook;
            }
            else
            {
                Book tempAuthor = fAuthor;
                Book tempTitle = fTitle;
                bool authorExit = false;
                bool titleExit = false;
                int checkAuthor = 1;
                int checkTitle = 1;

                //loop until lists are modded to a new book
                while(authorExit != true || titleExit != true){
                    //duplicate book found
                    if ((tempAuthor.title == title && tempAuthor.author == author) || (tempTitle.title == title && tempTitle.author == author))
                    {
                        return ErrorCode.DuplicateBook;
                    }
                    
                    //all checks for author
                    if (authorExit != true)
                    {
                        checkAuthor = author.CompareTo(tempAuthor.author);
                        //same title, lets check their titles
                        if (checkAuthor == 0)
                            checkAuthor = tempAuthor.CompareByAuthor(newBook);
                        //insert new book before the current node
                        if (checkAuthor == -1 && authorExit != true)
                        {
                            //check if first element in list
                            if (tempAuthor == fAuthor)
                                fAuthor = newBook;
                            newBook.previousAuthor = tempAuthor.previousAuthor;
                            newBook.nextAuthor = tempAuthor;
                            if (tempAuthor.previousAuthor != null)
                                tempAuthor.previousAuthor.nextAuthor = newBook;
                            tempAuthor.previousAuthor = newBook;
                            authorExit = true;
                        }   //if the next element is null insert at end   
                        else if (tempAuthor.nextAuthor == null && authorExit != true)
                        {
                            tempAuthor.nextAuthor = newBook;
                            newBook.previousAuthor = tempAuthor;
                            authorExit = true;
                        }

                        tempAuthor = tempAuthor.nextAuthor;
                    }

                    //all checks for the title
                    if (titleExit != true)
                    {
                        checkTitle = title.CompareTo(tempTitle.title);
                        //check their authors
                        if (checkTitle == 0)
                            checkTitle = tempTitle.CompareByTitle(newBook);
                        //insert new book before the current node
                        if (checkTitle == -1)
                        {
                            if (fTitle == tempTitle)
                                fTitle = newBook;
                                    newBook.previousTitle = tempTitle.previousTitle;
                                    newBook.nextTitle = tempTitle;

                            if (tempTitle.previousTitle != null)
                                tempTitle.previousTitle.nextTitle = newBook;
                                    tempTitle.previousTitle = newBook;
                                    titleExit = true;
                        }  
                        //if the next element is null insert at end                                   
                        else if (tempTitle.nextTitle == null && titleExit != true)
                        {
                            tempTitle.nextTitle = newBook;
                            newBook.previousTitle = tempTitle;
                            titleExit = true;
                        }

                        tempTitle = tempTitle.nextTitle;
                    }
                }
            }
            return ErrorCode.OK;
        }

      
        /// <summary>
        /// if there are no books, then print out a message saying that the list is empty
        /// prints by alphabetical order by authors
        /// /// </summary>
        public void PrintByAuthor()
        {
            if (fAuthor == null)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("List is empty");
                Console.WriteLine("-------------");
                return;
            }
            fAuthor.print(true);
        }

        /// <summary>
        /// if there are no books, then print out a message saying that the list is empty
        /// prints by alphabetical order by titles
        /// /// </summary>
        public void PrintByTitle()
        {
            if (fTitle == null)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("List is empty");
                Console.WriteLine("-------------");
                return;
            }

            fTitle.print(false);
        }

        public ErrorCode Remove(string author, string title)
        {
            bool AuthorCheck = false;
            if (fAuthor.author == author && fAuthor.title == title)
            {
                fAuthor = fAuthor.nextAuthor;
                AuthorCheck = true;
            }

            if (author == fTitle.author && title == fTitle.title) 
            {
                fTitle = fTitle.nextTitle;
                if (AuthorCheck == true)
                {
                    return ErrorCode.OK;
                }
            }

            for (Book temp = fAuthor; temp != null; temp = temp.nextAuthor)
            {
                if (temp.author == author && temp.title == title)
                {
                    //remove object, but dont lose the remaining object(s).
                    if (temp.nextAuthor != null) 
                    {
                        temp.previousAuthor = temp.nextAuthor;
                        temp.nextAuthor.previousAuthor = temp.previousAuthor;
                    }
                    else     //we reached the end of the list
                    {
                        temp.previousAuthor.nextAuthor = null;
                    }

                    //remove object, but dont lose the remaining object(s).
                    if (temp.nextTitle != null)  
                    {
                        temp.previousTitle = temp.nextTitle;
                        temp.nextTitle.previousTitle = temp.previousTitle;
                    }
                    else 
                    {
                        temp.previousTitle.nextTitle = null;
                    }
                    return ErrorCode.OK;
                }
            }

            // if there isn't an exact match, then do the following:
            return ErrorCode.BookNotFound;
            // (this includes finding a book by the given author, but with a different title,
            // or a book with the given title, but a different author)
        }
    }


    //added to run the program
    class AllTests
    {
        public void RunTests()
        {

        }
    }
}
