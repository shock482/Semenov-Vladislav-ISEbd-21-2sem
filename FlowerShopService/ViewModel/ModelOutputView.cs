using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelOutputView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string OutputName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<ModelProdElementView> OutputElements { get; set; }
    }
}
