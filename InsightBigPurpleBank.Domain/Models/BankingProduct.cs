using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InsightBigPurpleBank.Domain.Enums;

namespace InsightBigPurpleBank.Domain.Models{ 

    public class BankingProduct
    {
        [Required]
        [DataMember(Name = "productId")]
        public string ProductId { get; set; }

        [DataMember(Name = "effectiveFrom")]
        public string EffectiveFrom { get; set; }

        [DataMember(Name = "effectiveTo")]
        public string EffectiveTo { get; set; }

        [Required]
        [DataMember(Name = "lastUpdated")]
        public string LastUpdated { get; set; }

        [Required]
        [DataMember(Name = "productCategory")]
        public BankingProductCategory ProductCategory { get; set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [Required]
        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        [DataMember(Name = "brandName")]
        public string BrandName { get; set; }

        [DataMember(Name = "applicationUri")]
        public string ApplicationUri { get; set; }

        [Required]
        [DataMember(Name = "isTailored")]
        public bool IsTailored { get; set; }

        [DataMember(Name = "additionalInformation")]
        public AdditionalInformation AdditionalInformation { get; set; }

        [DataMember(Name = "cardArt")]
        public List<CardArt> CardArt { get; set; }
    }

}