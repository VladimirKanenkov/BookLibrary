using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using LibraryAPI;

namespace Library
{
    class Program
    {
        private static List<Book> books;

        static void Main(string[] args)
        {
            books = !File.Exists("lib.xml") ? new List<Book>() : DeserializeFromXML();
            Commands command = new Commands(books);
            bool flag = true;

            while (flag)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. сохранить \t 2. Добавить  \t 3. Удалить");
                Console.WriteLine("4. Редактировать \t 5. Поиск  \t 6. Список по критерию");
                Console.WriteLine("7. Экспорт в файл \t 8. Импорт из файла \t 9. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
                try
                {
                    int val = Convert.ToInt32(Console.ReadLine());
                    switch (val)
                    {
                        case 1:
                            break;
                        case 2:
                            command.Add();
                            break;
                        case 3:
                            command.Delete();
                            break;
                        case 4:
                            command.Edit();
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            flag = false;
                            continue;
                        default:
                            Console.WriteLine("Нет такой команды\n");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        static List<Book> DeserializeFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Book>));
            TextReader textReader = new StreamReader(@"lib.xml");
            List<Book> lib = (List<Book>)deserializer.Deserialize(textReader);
            textReader.Close();

            return lib;
        }


        static public void SerializeToXML(List<Book> lib)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            TextWriter textWriter = new StreamWriter(@"lib.xml");
            serializer.Serialize(textWriter, lib);
            textWriter.Close();
        }
    }
}
