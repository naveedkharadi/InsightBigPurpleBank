using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _406_UnsupportedVersion : Error
    {
        public _406_UnsupportedVersion(int supportedVersion, int requestedVersion)
        {
            Code = Constants.ErrorCodes._406_UnsupportedVersion;
            Detail = $"A request is made for a version that is not supported. Requested version = {requestedVersion}. Supported version = {supportedVersion}.";
            Title = "Unsupported Version";
        }
    }
}
