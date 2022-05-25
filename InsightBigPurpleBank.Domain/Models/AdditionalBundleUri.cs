using System.Runtime.Serialization;
namespace InsightBigPurpleBank.Domain.Models{ 

    public class AdditionalBundleUri
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "additionalInfoUri")]
        public string AdditionalInfoUri { get; set; }
    }

}