using FlowerShopService.Attributies;
using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с работниками")]
    public interface InterfaceExecutorService
    {
        [CustomMethod("Метод получения списка работников")]
        List<ModelExecutorView> getList();

        [CustomMethod("Метод получения работника по id")]
        ModelExecutorView getElement(int id);

        [CustomMethod("Метод добавления работника")]
        void addElement(BoundExecutorModel model);

        [CustomMethod("Метод изменения данных по работнику")]
        void updateElement(BoundExecutorModel model);

        [CustomMethod("Метод удаления работника")]
        void deleteElement(int id);
    }
}
