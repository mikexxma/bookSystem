using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowSys
{
    public delegate void HandleBookSysEvent();
   
    class Program
    {
        static void Main(string[] args)
        {
            BookSystemManager bookSysManger = new BookSystemManager();
            bookSysManger.start();
        }
      
    }

    //create a listener to listen book system situation like start and exit
    class Listerner
    {
        public Listerner(BookSystemManager bsm, HandleBookSysEvent booklibEvent)
        {
            bsm.bookSysEvent += booklibEvent;// attach function to the event delegate
        }
        public static void bookSystemStart()
        {
            Console.WriteLine("Book system started");
        }
        public static void bookSystemExit()
        {
            Console.WriteLine("Book system exit");
        }
    }
    class CheckInput
    {
        public static int checkInputIsNum(String input)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(input);
            }
            catch (Exception e)
            {
                num = 0;
            }
            return num;
        }
    }
    class BookSystemManager
    {
        public string bookLibPath = @"c:\Mike\bookLib";
        public string bookLibName = "booklibrary.txt";
        public event HandleBookSysEvent bookSysEvent;
        private void cleanBooksysEvent()
        {
            bookSysEvent = null;
        }
        private void runBookSysEvent()
        {
            if (bookSysEvent != null)
            {
                bookSysEvent();
            }
        }
        public virtual  void onStart()
        {
            cleanBooksysEvent();
            Listerner listerner = new Listerner(this, Listerner.bookSystemStart);
            runBookSysEvent();
        }

        public virtual void onStop()
        {
            cleanBooksysEvent();
            Listerner listerner = new Listerner(this, Listerner.bookSystemExit);
            runBookSysEvent();
          
        }

        public void checkInput(String input)
        {

        }
        public void start()
        {
            onStart();
            Console.WriteLine("****************welocom to Mike book borrow system************************");
            Console.WriteLine("press 1 2 3 to chose the function you want");
            Console.WriteLine("1.Browser library books");
           // Console.WriteLine("2.Serach your book");
            Console.WriteLine("3.Return book");
            Console.WriteLine("4.Book manager system");
            Console.WriteLine("5.Exit");
            string[] books = { "1.C# Learning", "2.Advanced C#", "3.To Be a Better Man", "4. How to write Testament" };

            string pathString = Path.Combine(bookLibPath, bookLibName);
            BookManagerImp.createBookLibrary(bookLibPath, bookLibName, books);
            string inputNumber = Console.ReadLine();
            int num = CheckInput.checkInputIsNum(inputNumber);
            switch (num)
            {
                case 1:
                    claerScreen();
                    Console.WriteLine("List all of the book of library input the number to chose which book you want to borrow");
                    string[] booklist = BookManagerImp.findAllBookInFile(bookLibPath,bookLibName);
                    foreach (string book in booklist)
                    {
                        Console.WriteLine(book);
                    }

                    //Console.WriteLine("0.Serach your book");
                    Console.WriteLine("input space to return to the main menu");

                    string inputNumberInBrowserBook = Console.ReadLine();
                    foreach (string book in booklist)
                    {

                        Console.WriteLine("searching book"+ book[0]);
                        if (book[0].Equals(inputNumberInBrowserBook.Trim().ToCharArray()[0])&& inputNumberInBrowserBook.Trim().ToCharArray().Length==1)
                        {
                           
                            Console.WriteLine("you borrowed the book " + book );
                            int index = Convert.ToInt32(Char.GetNumericValue(book[0]));
                            booklist[index - 1] = "this book is gone";
                            updateBookLib(pathString, booklist);
                            break;
                        }
                        else if(booklist.Length< Int32.Parse(inputNumberInBrowserBook))
                        {
                            Console.WriteLine("there is no that book you want"+ book[0]);
                        }

                    }
                    Console.WriteLine("press any key to the menu");
                    string input = Console.ReadLine();
                    start();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    exitSys();
                    break;
                default:
                    claerScreen();
                    start();
                    break;
            }
            Console.ReadLine();
        }

        public void borrowBook(int functionNum)
        {
           
        }
        public void controlSys()
        {

        }

        public void updateBookLib(string pathString,string[] books)
        {
            File.WriteAllLines(pathString, books);
        }

        public void exitSys()
        {
            onStop();

            Console.ReadLine();
           // Environment.Exit(0);
        }
        public static void claerScreen()
        {
            Console.Clear();
        }

    }



    abstract class BookManager
    {
        public abstract void checkBookInFile(String bookName);
        public abstract void addBookInFile(String bookName);
        public abstract void delBookInFile(String bookName);
        public abstract void changeBookInFile(String bookName);

    }

    class BookManagerImp : BookManager
    {
        public override void addBookInFile(string bookName)
        {
            throw new NotImplementedException();
        }

        public override void changeBookInFile(string bookName)
        {
            throw new NotImplementedException();
        }

        public override void checkBookInFile(string bookName)
        {
            throw new NotImplementedException();
        }

        public override void delBookInFile(string bookName)
        {
            throw new NotImplementedException();
        }

        public static string[] findAllBookInFile(String path,String fileName)
        {
            String pathString = System.IO.Path.Combine(path, fileName);
            string [] mybooks =  File.ReadAllLines(pathString);
            return mybooks;
        }
        public static void createBookLibrary(String path,String fileName,string[] books)
        {

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            else
            {
                Console.WriteLine("path: " + path + " is already exists");
            }
            String pathString = System.IO.Path.Combine(path, fileName);
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.File.Create(pathString))
                {
                    //Write file
                    File.WriteAllLines(pathString, books);
                }
            }
            else
            {
                //File.WriteAllLines(pathString, books);
                Console.WriteLine("File "+fileName+" is already exists");
            }
        }
    }
}
