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

        /// <summary>
        /// Добавление книги в библиотеку
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str = "")
        {
            Console.WriteLine("Чтобы добавить книгу введите через запятую:\n" +
                  "ISBN, имя автора, название, год издания, язык программирования," +
                  "сложность, язык написания, рейтинг");
            string readLine = (str == "" ? Console.ReadLine() : str);
            if (readLine != null)
            {
                string[] temp = readLine.Split(',');
                if (Books.Where(n=>n.ISBN == temp[0].Trim()).Count() == 1)
                {
                    Console.WriteLine("Невозможно добавить! Такой ISBN уже присутствует.");
                    return;
                }
                Books.Add(new Book(temp[0].Trim(), temp[1].Trim(), temp[2].Trim(),  temp[3].Trim(), temp[4].Trim(),
                    temp[5].Trim(), temp[6].Trim(), temp[7].Trim()));
            }
        }

        /// <summary>
        /// Удаление книги из библиотеки
        /// </summary>
        /// <param name="str"></param>
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
            //Console.WriteLine("1. ISBN\t 2. Имя автора \t 3. Название (или фрагмент названия)");
            //Console.WriteLine(Books[0].GetString());
            
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
