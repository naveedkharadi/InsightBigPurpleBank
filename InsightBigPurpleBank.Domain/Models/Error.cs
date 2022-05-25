using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InsightBigPurpleBank.Domain.Models{ 

    public class Error
    {
        [Required]
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [Required]
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [Required]
        [DataMember(Name = "detail")]
        public string Detail { get; set; }

        [DataMember(Name = "meta")]
        public MetaError Meta { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}