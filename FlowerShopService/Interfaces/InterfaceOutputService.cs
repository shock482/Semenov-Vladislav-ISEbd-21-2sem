using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceOutputService
    {
        List<ModelOutputView> getList();

        ModelOutputView getElement(int id);

        void addElement(BoundOutputModel model);

        void updateElement(BoundOutputModel model);

        void deleteElement(int id);
    }
}
