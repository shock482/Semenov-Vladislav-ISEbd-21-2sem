using FlowerShopService.Attributies;
using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с компонентами")]
    public interface InterfaceComponentService
    {
        [CustomMethod("Метод получения списка компонент")]
        List<ModelElementView> getList();

        [CustomMethod("Метод получения компонента по id")]
        ModelElementView getElement(int id);

        [CustomMethod("Метод добавления компонента")]
        void addElement(BoundElementModel model);

        [CustomMethod("Метод изменения данных по компоненту")]
        void updateElement(BoundElementModel model);

        [CustomMethod("Метод удаления компонента")]
        void deleteElement(int id);
    }
}
