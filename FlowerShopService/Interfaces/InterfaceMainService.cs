using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System.Collections.Generic;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceMainService
    {
        List<ModelBookingView> getList();

        void createOrder(BoundBookingModel model);

        void takeOrderInWork(BoundBookingModel model);

        void finishOrder(int id);

        void payOrder(int id);

        void putComponentOnReserve(BoundResElementModel model);
    }
}
