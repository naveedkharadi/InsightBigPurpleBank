using System.Runtime.Serialization;
using System.Collections.Generic; 
namespace InsightBigPurpleBank.Domain.Models{ 

    public class AdditionalInformation
    {
        [DataMember(Name = "overviewUri")]
        public string OverviewUri { get; set; }

        [DataMember(Name = "termsUri")]
        public string TermsUri { get; set; }

        [DataMember(Name = "eligibilityUri")]
        public string EligibilityUri { get; set; }

        [DataMember(Name = "feesAndPricingUri")]
        public string FeesAndPricingUri { get; set; }

        [DataMember(Name = "bundleUri")]
        public string BundleUri { get; set; }

        [DataMember(Name = "additionalOverviewUris")]
        public List<AdditionalOverviewUri> AdditionalOverviewUris { get; set; }

        [DataMember(Name = "additionalTermsUris")]
        public List<AdditionalTermsUri> AdditionalTermsUris { get; set; }

        [DataMember(Name = "additionalEligibilityUris")]
        public List<AdditionalEligibilityUri> AdditionalEligibilityUris { get; set; }

        [DataMember(Name = "additionalFeesAndPricingUris")]
        public List<AdditionalFeesAndPricingUri> AdditionalFeesAndPricingUris { get; set; }

        [DataMember(Name = "additionalBundleUris")]
        public List<AdditionalBundleUri> AdditionalBundleUris { get; set; }
    }

}