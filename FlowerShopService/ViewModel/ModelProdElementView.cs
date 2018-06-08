using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelProdElementView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int OutputID { get; set; }

        [DataMember]
        public int ElementID { get; set; }

        [DataMember]
        public string ElementName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
