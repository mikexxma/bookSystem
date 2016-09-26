using System;
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
            Console.WriteLine("2.Serach your book");
            Console.WriteLine("3.Beturn book");
            Console.WriteLine("4.Book manager system");
            Console.WriteLine("5.Exit");
            BookManagerImp.createBookLibrary(@"c:\Mike\bookLib","booklibrary.txt",null);
            String inputNumber = Console.ReadLine();
            int num = CheckInput.checkInputIsNum(inputNumber);
            switch (num)
            {
                case 1:
                    claerScreen();
                    Console.WriteLine("List all of the book of library");
                    Array booklist = BookManagerImp.findAllBookInFile();
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

        public void controlSys()
        {

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

        public static Array findAllBookInFile()
        {
            return null;
        }
        public static void createBookLibrary(String path,String fileName,Array books)
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
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    //Write file
                }
            }
            else
            {
                Console.WriteLine("File "+fileName+" is already exists");
            }
        }
    }
}
