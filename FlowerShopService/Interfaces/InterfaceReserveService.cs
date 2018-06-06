using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceReserveService
    {
        List<ModelReserveView> getList();

        ModelReserveView getElement(int id);

        void addElement(BoundReserveModel model);

        void updateElement(BoundReserveModel model);

        void deleteElement(int id);
    }
}
