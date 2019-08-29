using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryAPI
{
    
    public class Commands
    {
        public static List<Book> Books { get; set; }
        public Commands(List<Book> _books)
        {
            Books = _books;
        }

        public void Add(string str = "")
        {
            Console.WriteLine("Что бы добавить книгу введите через запятую:\n" +
                  "ISBN, имя автора, название, год издания, язык программирования," +
                  "сложность, язык написания, рейтинг");
            string readLine = (str == "" ? Console.ReadLine() : str);
            if (readLine != null)
            {
                string[] temp = readLine.Split(',');
                Books.Add(new Book(temp[0].Trim(), temp[1].Trim(), temp[2].Trim(),  temp[3].Trim(), temp[4].Trim(),
                    temp[5].Trim(), temp[6].Trim(), temp[7].Trim()));
            }
        }

        public void Delete(string str="")
        {
            Console.WriteLine("Введите название книги которую вы хотите удалить") ;
            string name = (str == "" ? Console.ReadLine() : str);
            foreach (Book book in Books.Where(b => b.Title == name))
            {
                Console.WriteLine("Удаление...");
                Console.WriteLine("ISBN: {0}, Автор: {1}, Название: {2}", book.ISBN, book.Authors, book.Title);
                Books.Remove(book);
                break;
            }
        }

        public void Edit()
        {

        }

        public void Find()
        {
            Console.WriteLine("Введите ISBN, имя автора, название (или фрагмент названия)");

        }

        public void List()
        {

        }

        public void Export()
        {

        }

        public void Import()
        {

        }


    }
}
