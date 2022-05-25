using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _400_InvalidPageSize : Error
    {
        public _400_InvalidPageSize(int requestedPageSize)
        {
            Code = Constants.ErrorCodes._400_InvalidPageSize;
            Detail = $"The value provided in the page-size pagination field is greater than the maximum allowed by the Consumer Data Standards (page_size > {Constants.MaxPageSizeByCDS}). Requested page size {requestedPageSize}";
            Title = "Invalid Page Size";
        }
    }
}
