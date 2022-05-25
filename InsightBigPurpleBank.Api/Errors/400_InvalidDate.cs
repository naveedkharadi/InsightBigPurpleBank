using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _400_InvalidDate : Error
    {
        public _400_InvalidDate(string parameterName)
        {
            Code = Constants.ErrorCodes._400_InvalidDate;
            Detail = $"An invalid date is provided. Parameter name: {parameterName}";
            Title = "Invalid Date";
        }
    }
}
