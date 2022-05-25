using System.Runtime.Serialization;
using System.Text.Json.Serialization; 
namespace InsightBigPurpleBank.Domain.Models{ 

    public class MetaError
    {
        [DataMember(Name = "urn")]
        public string Urn { get; set; }
    }

}