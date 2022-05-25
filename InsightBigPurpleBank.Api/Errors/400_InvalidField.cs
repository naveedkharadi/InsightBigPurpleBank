using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _400_InvalidField : Error
    {
        public _400_InvalidField(string parameterName)
        {
            Code = Constants.ErrorCodes._400_InvalidField;
            Detail = $"Parameter is an invalid type or the value violates the field's constraints as defined by the interface contract. Parameter name: {parameterName}";
            Title = "Invalid Field";
        }
    }
}
