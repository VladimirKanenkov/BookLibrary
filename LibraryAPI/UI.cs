using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI
{
    interface UI
    {
        string GetMessage();

    }
    class RussianUI : UI
    {
        string UI.GetMessage()
        {
            return "1. Изменить язык интерфейса \t 2. Добавить  \t 3. Удалить\n" +
                "4. Редактировать \t 5. Поиск  \t 6. Список по критерию\n" +
                "7. Экспорт в файл \t 8. Импорт из файла \t 9. Выйти из программы\n" +
                "Введите номер пункта:";
        }

    }

    class EnglishUI : UI
    {

    }

}
