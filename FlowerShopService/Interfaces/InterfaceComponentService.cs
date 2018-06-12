using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceComponentService
    {
        List<ModelElementView> getList();

        ModelElementView getElement(int id);

        void addElement(BoundElementModel model);

        void updateElement(BoundElementModel model);

        void deleteElement(int id);
    }
}
