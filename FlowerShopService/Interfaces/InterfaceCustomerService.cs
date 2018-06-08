using FlowerShopService.Attributies;
using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface InterfaceCustomerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<ModelCustomerView> getList();

        [CustomMethod("Метод получения клиента по id")]
        ModelCustomerView getElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void addElement(BoundCustomerModel model);

        [CustomMethod("Метод изменения данных по клиенту")]
        void updateElement(BoundCustomerModel model);

        [CustomMethod("Метод удаления клиента")]
        void deleteElement(int id);
    }
}
