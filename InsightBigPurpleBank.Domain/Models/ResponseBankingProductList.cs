using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace InsightBigPurpleBank.Domain.Models{ 

    public class ResponseBankingProductList
    {
        [Required]
        [DataMember(Name = "data")]
        public ProductsData Data { get; set; }

        [Required]
        [DataMember(Name = "links")]
        public Links Links { get; set; }

        [Required]
        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }
    }

}