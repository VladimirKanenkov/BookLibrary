using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAPI;
using Library;
using System.Linq;
using System.Reflection;

namespace LibraryTest
{
    [TestClass]
    public class CommandsTest 
    {
        static List<Book> books = Program.DeserializeFromXML("lib.xml");
        Commands comm = new Commands(books);

        [TestMethod]
        public void DeleteTest()
        {            
            string str = "Объектно-ориентированное программирование в С++";
            comm.Delete(str);
            Assert.AreEqual(books.Where(n => n.Title == str).Count(), 0);
        }

        [TestMethod]
        public void AddTest()
        {           
            string str1 = ", Шарп Дж, " + "Microsoft Visual C#. 8-е изд., " + "2017, " + "ru, " + "intermediate, " + "C#, " + "great";
            string readLine = Guid.NewGuid().ToString() + str1;

            comm.Add(readLine);
            Assert.AreEqual(books.Where(n => n.Title == readLine.Split(',')[2].Trim()).Count(), 1);
            string str2 = "f57b28be-9835-4a13-9a42-396d797f77bc";
            readLine = str2 + str1;
            comm.Add(readLine);
            Assert.AreEqual(books.Where(n => n.ISBN == str2).Count(), 1);          
        }

        //https://qa-help.ru/questions/s-unit-test-dlya-metoda-kotoryj-vyzyvaet-consolereadline

    }
}
