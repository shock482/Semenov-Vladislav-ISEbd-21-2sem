using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceExecutorService
    {
        List<ModelExecutorView> getList();

        ModelExecutorView getElement(int id);

        void addElement(BoundExecutorModel model);

        void updateElement(BoundExecutorModel model);

        void deleteElement(int id);
    }
}
