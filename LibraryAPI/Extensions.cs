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
            return book.BookLanguage;
        }
    }
}
