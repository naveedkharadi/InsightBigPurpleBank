using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace InsightBigPurpleBank.Domain.Models{ 

    public class CardArt
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [Required]
        [DataMember(Name = "imageUri")]
        public string ImageUri { get; set; }
    }

}