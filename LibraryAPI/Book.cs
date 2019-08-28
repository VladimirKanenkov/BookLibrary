using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public class Book
    {
        public string ISBN { get; set; }
        public Author Authors { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        /// <summary>
        /// Язык программирования
        /// </summary>
        public string Language { get; set; }
        public Level UserLevel { get; set; }
        /// <summary>
        /// Язык на котором написана книга
        /// </summary>
        public string BookLanguage { get; set; }
        public Grade? Rating { get; set; }

        public Book(string iSBN, string name, string title, string releaseDate, 
            string language, string userLevel, string bookLanguage, string rating)
        {
            ISBN = iSBN;  //new Guid().ToString();
            Authors = new Author(name);
            Name = name;
            Title = title;
            ReleaseDate = int.Parse(releaseDate);
            Language = language;
            UserLevel = (Level)Enum.Parse(typeof(Level), userLevel);
            BookLanguage = bookLanguage;
            Rating = (Grade)Enum.Parse(typeof(Grade), rating);
        }

        public Book()
        {
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public Author(string name)
        {
            Name = name;
        }
        public Author()
        {
        }
    }

    public enum Level {beginner, intermediate, advanced }
    public enum Grade { disgusting, bad, good, great }
}
