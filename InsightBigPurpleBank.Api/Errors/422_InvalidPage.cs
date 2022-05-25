using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _422_InvalidPage : Error
    {
        public _422_InvalidPage(int maxPages)
        {
            Code = Constants.ErrorCodes._422_InvalidPage;
            Detail = $"The page being requested it out of of range. Maximum page = {maxPages}.";
            Title = "Invalid Page";
        }
    }
}
