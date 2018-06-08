using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelCustomerView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string CustomerFullName { get; set; }
    }
}
