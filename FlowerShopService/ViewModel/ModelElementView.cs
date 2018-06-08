using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelElementView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string ElementName { get; set; }
    }
}
