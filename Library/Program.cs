﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using LibraryAPI;

namespace Library
{
    public class Program
    {
        static List<Book> books;
        static readonly string settings = "settings.dat";
        static readonly string library = "lib.xml";

        static void Main(string[] args)
        {
            books = !File.Exists(library) ? new List<Book>() : DeserializeFromXML(library);
            Commands command = new Commands(books);
            bool flag = true;
            string localisation;
            IUserInterface RussianInterface = new RussianUI();
            IUserInterface EnglishIntarface = new EnglishUI();
            IUserInterface userInerface;

            while (flag)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                switch (localisation = ReadSettings(settings))
                {
                    case "ru":
                        userInerface = RussianInterface;
                        break;
                    case "en":
                        userInerface = EnglishIntarface;
                        break;
                    default:
                        userInerface = RussianInterface;
                        break;
                }
                Console.WriteLine(userInerface.GetMessage());
                Console.ForegroundColor = color;
                try
                {
                    int val = Convert.ToInt32(Console.ReadLine());
                    switch (val)
                    {
                        case 1:
                            command.ChangeUI(localisation, settings);
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
                            command.Find();
                            break;
                        case 6:
                            command.List();
                            break;
                        case 7:
                            command.Export();
                            break;
                        case 8:
                            command.Import();
                            break;
                        case 9:
                            SerializeToXML(books);
                            break;
                        case 10:
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

        static string ReadSettings(string fileName)
        {
            if (!File.Exists(fileName))
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write("ru");
                }

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                return reader.ReadString();
            }
        }

        static public List<Book> DeserializeFromXML(string file)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Book>));
            TextReader textReader = new StreamReader(file);
            List<Book> lib = (List<Book>)deserializer.Deserialize(textReader);
            textReader.Close();

            return lib;
        }

        static public void SerializeToXML(List<Book> lib)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            TextWriter textWriter = new StreamWriter(library);
            serializer.Serialize(textWriter, lib);
            textWriter.Close();
        }


        /// <summary>
        /// Заполнение данными
        /// </summary>
        /// <param name="lib"></param>
        static public void FillWithData(List<Book> lib)
        {
            lib.Add(new Book(Guid.NewGuid().ToString(), "Лафоре Р.", "Объектно-ориентированное программирование в С++", "2016" , "ru", "intermediate", "C++", "bad"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Лафоре Р.", "Структуры данных и алгоритмы в Java. 2-е изд.", "2016", "ru", "intermediate", "Java", "good"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Эккель Б.", "Философия Java. Библиотека программиста. 4-е изд.", "2015", "ru", "intermediate", "Java", "bad"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Гоше Х.", "HTML5. Для профессионалов. 2-е изд.", "2015", "ru", "advanced", "HTML5", "good"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Макфарланд Д.", "Новая большая книга CSS", "2016", "ru", "intermediate", "CSS", "bad"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Любанович Б.", "Простой Python. Современный стиль программирования", "2016", "ru", "beginner", "Python", "good"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Усов В. А.", "Swift. Основы разработки приложений под iOS и OS X. 2-е изд. ", "2016", "ru", "beginner", "Swift", "good"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Рихтер Д.", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд. ", "2016", "en", "advanced", "C#", "great"));
            lib.Add(new Book(Guid.NewGuid().ToString(), "Васильев А. Н.", "C#. Объектно-ориентированное программирование. Учебный курс ", "2012", "ru", "intermediate", "C#", "good"));
        }



    }


}
