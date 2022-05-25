using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsightBigPurpleBank.Domain.Models{ 

    public class ProductsData
    {
        [Required]
        [DataMember(Name = "products")]
        public List<BankingProduct> Products { get; set; }
    }

}