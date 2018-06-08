using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceReportService
    {
        void SaveOutputPrice(BoundReportModel model);

        List<ModelReservesLoadView> GetReservesLoad();

        void SaveReservesLoad(BoundReportModel model);

        List<ModelCustomerBookingsView> GetCustomerBookings(BoundReportModel model);

        void SaveCustomerBookings(BoundReportModel model);
    }
}
