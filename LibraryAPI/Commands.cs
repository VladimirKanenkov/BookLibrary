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

        public void Add()
        {
            Console.WriteLine("Что бы добавить книгу введите через запятую:\n" +
                  "ISBN, имя автора, название, год издания, язык программирования," +
                  "сложность, язык написания, рейтинг");
            string readLine = Console.ReadLine();
            if (readLine != null)
            {
                string[] temp = readLine.Split(',');
                Books.Add(new Book(temp[0], temp[1], temp[2],  DateTime.Parse(temp[3]), temp[4],
                    (Level)Enum.Parse(typeof(Level), temp[5]), temp[6], (Grade)Enum.Parse(typeof(Grade), temp[7])));
            }
        }

        public void Delete()
        {
            Console.WriteLine("Введите название книги которую вы хотите удалить");
            string name = Console.ReadLine();
            foreach (Book book in Books.Where(b => b.Name == name))
            {
                Console.WriteLine("Удаление...");
                Console.WriteLine("Название: {0}, Автор: {1}, Издательство: {2}", book.Name, book.Authors, book.Title);
                Books.Remove(book);
                break;
            }
        }

        public void Edit()
        {

        }





    }
}
