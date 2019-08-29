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
            string str = Guid.NewGuid().ToString() + ", Шарп Дж, " + "Microsoft Visual C#. 8-е изд., " +  "2017, " + "ru, " + "intermediate, " + "C#, " + "great";
            comm.Add(str);
            Assert.AreEqual(books.Where(n => n.Title == str.Split(',')[2].Trim()).Count(), 1);

        }

    }
}
