﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryAPI
{
    
    public class Commands { 
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
                  "ISBN, имя автора, название, год издания, язык написания," +
                  "сложность, язык программирования, рейтинг");
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
            Console.WriteLine("Введите название книги, которую вы хотите удалить") ;
            string name = (str == "" ? Console.ReadLine() : str);
            foreach (Book book in Books.Where(b => b.Title == name))
            {
                Console.WriteLine("Удаление...");
                Console.WriteLine("ISBN: {0}, Автор: {1}, Название: {2}", book.ISBN, book.Authors, book.Title);
                Books.Remove(book);
                break;
            }
        }

        /// <summary>
        /// Сменить язык интерфейса
        /// </summary>
        /// <param name="localisation"></param>
        /// <param name="fileName"></param>
        public void ChangeUI(string localisation, string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Open)))
            {
                switch (localisation)
                {
                    case "ru":
                        writer.Write("en");
                        break;
                    case "en":
                        writer.Write("ru");
                        break;
                }
            }
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поиск книги по автору или названию
        /// </summary>
        public void Find()
        {
            bool flag = true;
            string str;
            while (flag)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n1. По ISBN\t2. По автору\t 3. По названию\t 4. Выйти");
                Console.ForegroundColor = color;
                int val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    
                    case 2:
                        Console.WriteLine("Введите имя или часть имени автора:");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.Authors.Name.ToLower().Contains(str));
                        break;
                    case 3:
                        Console.WriteLine("Введите название или часть названия:");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.Title.ToLower().Contains(str));
                        break;
                    case 4:
                        flag = false;
                        continue;
                    default:
                        Console.WriteLine("Нет такой команды\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Вывод списка книг по заданному критерию
        /// </summary>
        public void List()
        {
            bool flag = true;

            while (flag)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n1. Все \t 2. По автору  \t 3. По языку программирования\n" +
                "4. По рейтингу \t 5. По сложности  \t 6. Выйти\n" +
                "Введите номер пункта:");
                Console.ForegroundColor = color;
                int val = Convert.ToInt32(Console.ReadLine());
                string str;

                switch (val)
                {
                    case 1:
                        Books.ForEach((n) => Console.WriteLine(n.ToString() + "\n"));
                        break;
                    case 2:
                        Console.WriteLine("Введите имя или часть имени автора:");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.Authors.Name.ToLower().Contains(str));
                        break;
                    case 3:
                        Console.WriteLine("Введите название языка программирования" +
                            " (возможные варианты: " + Books.GetUnique(i => i.ProgrammingLanguage) + "):");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.ProgrammingLanguage.ToLower() == str);
                        break;
                    case 4:
                        Console.WriteLine("Введите рейтинг книги" +
                            " (возможные варианты: " + Books.GetUnique(i => i.Rating.ToString()) + "):");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.Rating.ToString().ToLower() == str);
                        break;
                    case 5:
                        Console.WriteLine("Введите сложность книги" +
                        " (возможные варианты: " + Books.GetUnique(i => i.UserLevel.ToString()) + "):");
                        str = Console.ReadLine().ToLower();
                        Books.GetWriteLines(t => t.UserLevel.ToString().Contains(str));
                        break;
                    case 6:
                        flag = false;
                        continue;

                    default:
                        Console.WriteLine("Нет такой команды\n");
                        break;
                }
            }
        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            throw new NotImplementedException();
        }
    }

}
