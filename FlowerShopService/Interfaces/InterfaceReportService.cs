using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopService.Attributies;
using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;

namespace FlowerShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface InterfaceReportService
    {
        [CustomMethod("Метод сохранения списка изделий в doc-файл")]
        void SaveOutputPrice(BoundReportModel model);

        [CustomMethod("Метод получения списка складов с количество компонент на них")]
        List<ModelReservesLoadView> GetReservesLoad();

        [CustomMethod("Метод сохранения списка списка складов с количество компонент на них в xls-файл")]
        void SaveReservesLoad(BoundReportModel model);

        [CustomMethod("Метод получения списка заказов клиентов")]
        List<ModelCustomerBookingsView> GetCustomerBookings(BoundReportModel model);

        [CustomMethod("Метод сохранения списка заказов клиентов в pdf-файл")]
        void SaveCustomerBookings(BoundReportModel model);
    }
}
