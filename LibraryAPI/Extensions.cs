using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public static class Extensions
    {

        /// <summary>
        /// Возвратить уникальные значения из списка
        /// </summary>
        /// <param name="books"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string GetUnique(this List<Book> books, Func<Book, string> func)
        {
            return books.GroupBy(func)
                        .Select(i => i.Key)
                        .Aggregate((i, j) => i + " ," + j);
        }

        /// <summary>
        /// Вывод списка книг по критерию
        /// </summary>
        /// <param name="books"></param>
        /// <param name="func"></param>
        public static void GetWriteLines (this List<Book> books, Func<Book, bool> func)
        {
            books.Where(func).ToList()
                .ForEach((n) => Console.WriteLine(n.ToString() + "\n"));
        }
    }
}
