using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelReserveElementView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int ReserveID { get; set; }

        [DataMember]
        public int ElementID { get; set; }

        [DataMember]
        public string ElementName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
