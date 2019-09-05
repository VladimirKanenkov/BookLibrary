using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public interface IUserInterface
    {
        string GetMessage();
    }
    public class RussianUI : IUserInterface
    {
        public string  GetMessage()
        {
            return "1. Изменить язык интерфейса \t 2. Добавить  \t 3. Удалить\n" +
                "4. Редактировать \t 5. Поиск  \t 6. Список \n" +
                "7. Экспорт в файл \t 8. Импорт из файла \t 9. Сохранить \t 10. Выйти\n" +
                "Введите номер пункта:";
        }

    }
    public class EnglishUI : IUserInterface
    {
        public string GetMessage()
        {
            return "1. Change the interface language \t 2. Add \t 3. Remove\n" +
                "4. Edit \t 5. Search \t 6. List \n" +
                "7. Export to file \t 8. Import from file \t 9. Save \t 10. Exit\n" +
                "Enter item number:";
        }
    }

}
