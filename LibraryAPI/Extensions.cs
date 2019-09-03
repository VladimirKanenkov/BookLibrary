using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public static class Extensions
    {
        public static  string GetString(this Book book)
        {
            return book.ISBN + ", " + book.Authors.Name + ", " + book.Title + ", " + book.ReleaseDate
                + ", " + book.BookLanguage + ", " + book.UserLevel + ", " + book.ProgrammingLanguage + ", " + book.Rating;
        }
    }
}
