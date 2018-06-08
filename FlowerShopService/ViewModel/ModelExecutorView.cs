using System.Runtime.Serialization;

namespace FlowerShopService.ViewModel
{
    [DataContract]
    public class ModelExecutorView
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string ExecutorFullName { get; set; }
    }
}
