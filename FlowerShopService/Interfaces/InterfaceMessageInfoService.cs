using FlowerShopService.DataFromUser;
using FlowerShopService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopService.Interfaces
{
    public interface InterfaceMessageInfoService
    {
        List<ModelMessageInfoView> GetList();

        ModelMessageInfoView GetElement(int id);

        void AddElement(BoundMessageInfoModel model);
    }
}
