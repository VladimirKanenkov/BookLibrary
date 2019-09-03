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
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        /// <summary>
        /// Язык на котором написана книга
        /// </summary>
        public string BookLanguage { get; set; }
        /// <summary>
        /// Сложность книги
        /// </summary>
        public Level UserLevel { get; set; }
        /// <summary>
        /// Язык программирования
        /// </summary>
        public string ProgrammingLanguage { get; set; }
        /// <summary>
        /// Рейтинг книги
        /// </summary>
        public Grade? Rating { get; set; }

        public Book(string iSBN, string name, string title, string releaseDate, 
            string language, string userLevel, string programmingLanguage, string rating)
        {
            ISBN = iSBN;  //new Guid().ToString();
            Authors = new Author(name);
            Title = title;
            ReleaseDate = int.Parse(releaseDate);
            BookLanguage = language;
            UserLevel = (Level)Enum.Parse(typeof(Level), userLevel);
            ProgrammingLanguage = programmingLanguage;
            Rating = (Grade)Enum.Parse(typeof(Grade), rating);
        }

        public Book()
        {
        }

        public override string ToString()
        {
            return string.Format(ISBN + ", " + Authors.Name + ", " + Title + ", " + ReleaseDate
                + ", " + BookLanguage + ", " + UserLevel + ", " + ProgrammingLanguage + ", " + Rating);
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
