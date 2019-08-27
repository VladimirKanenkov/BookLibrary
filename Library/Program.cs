using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Library
{
    class Program
    {
        private static List<Book> books;

        static void Main(string[] args)
        {
            books = !File.Exists("lib.xml") ? new List<Book>() : DeserializeFromXML();
            bool flag = true;
            while (flag)
            {
                switch (Console.ReadLine())
                {
                    case "add":
                        Console.WriteLine("Что бы добавить книгу введите через запятую\n" +
                                          "Имя автора, название книги, название издательства");
                        string readLine = Console.ReadLine();
                        if (readLine != null)
                        {
                            string[] temp = readLine.Split(',');
                            Add(temp[0], temp[1], temp[2]);
                        }
                        break;
                    case "exit":
                        flag = false;
                        break;

                    case "print":
                        Print();
                        break;

                    case "delete":
                        Console.WriteLine("Введите название книги которую вы хотите удалить");
                        Delete(Console.ReadLine());
                        break;

                    case "save":
                        SerializeToXML(books);
                        break;

                    case "load":
                        books = DeserializeFromXML();
                        break;

                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }
            }
        }

        private static void Delete(string name)
        {
            foreach (Book book in books.Where(b => b.Name == name))
            {
                Console.WriteLine("Удаление...");
                Console.WriteLine("Название: {0}, Автор: {1}, Издательство: {2}", book.Name, book.Authors, book.Title);
                books.Remove(book);
                break;
            }
        }
        private static void Print()
        {
            foreach (Book book in books)
            {
                Console.WriteLine("Название: {0}, Автор: {1}, Издательство: {2}", book.Name, book.Authors, book.Title);
            }
        }


        private static void Add(
            string author,
            string name,
            string publisher)
        {
            books.Add(new Book(author, name, publisher));
        }

        static public void SerializeToXML(List<Book> lib)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            TextWriter textWriter = new StreamWriter(@"lib.xml");
            serializer.Serialize(textWriter, lib);
            textWriter.Close();
        }

        static List<Book> DeserializeFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Book>));
            TextReader textReader = new StreamReader(@"lib.xml");
            List<Book> lib = (List<Book>)deserializer.Deserialize(textReader);
            textReader.Close();

            return lib;
        }
    }
}
