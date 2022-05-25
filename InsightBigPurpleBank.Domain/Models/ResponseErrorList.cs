using System.Text.Json.Serialization; 
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace InsightBigPurpleBank.Domain.Models{ 

    public class ResponseErrorList
    {
        [Required]
        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }
    }

}