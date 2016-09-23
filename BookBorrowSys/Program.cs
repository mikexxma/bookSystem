using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowSys
{
    class Program
    {
        int i;
        string j = "123";
        String k = "123";
        static void Main(string[] args)
        {
            BookSystemManager.start();
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
        public void checkInput(String input)
        {

        }
        public static void start()
        {
            Console.WriteLine("****************welocom to Mike book borrow system************************");
            Console.WriteLine("press 1 2 3 to chose the function you want");
            Console.WriteLine("1.Browser library books");
            Console.WriteLine("2.Serach your book");
            Console.WriteLine("3.Beturn book");
            Console.WriteLine("4.Book manager system");
            Console.WriteLine("5.Exit");
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

        public static void exitSys()
        {
            Environment.Exit(0);
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
    }
}
