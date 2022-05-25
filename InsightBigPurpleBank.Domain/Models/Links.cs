using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace InsightBigPurpleBank.Domain.Models{ 

    public class Links
    {
        [Required]
        [DataMember(Name = "self")]
        public string Self { get; set; }

        [DataMember(Name = "first")]
        public string First { get; set; }

        [DataMember(Name = "prev")]
        public string Prev { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }

        [DataMember(Name = "last")]
        public string Last { get; set; }
    }

}