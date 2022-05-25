using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _400_InvalidVersion : Error
    {
        public _400_InvalidVersion(string requestedVersion)
        {
            Code = Constants.ErrorCodes._400_InvalidVersion;
            Detail = $"A request is made for a version that is not a PositiveInteger. RequestedVersion = {requestedVersion}.";
            Title = "Invalid Version";
        }
    }
}
