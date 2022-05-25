using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace InsightBigPurpleBank.Domain.Models{ 

    public class Meta
    {
        [Required]
        [DataMember(Name = "totalRecords")]
        public int TotalRecords { get; set; }

        [Required]
        [DataMember(Name = "totalPages")]
        public int TotalPages { get; set; }
    }

}