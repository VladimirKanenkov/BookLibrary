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
        public DateTime? ReleaseDate { get; set; }
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

        public Book(string iSBN, string name, string title, DateTime? releaseDate, 
            string language, Level userLevel, string bookLanguage, Grade? rating)
        {
            ISBN = iSBN;  //new Guid().ToString();
            Authors = new Author(name);
            Name = name;
            Title = title;
            ReleaseDate = releaseDate;
            Language = language;
            UserLevel = userLevel;
            BookLanguage = bookLanguage;
            Rating = rating;
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
    }

    public enum Level {beginner, intermediate, advanced }
    public enum Grade { disgusting, bad, good, great }
}
