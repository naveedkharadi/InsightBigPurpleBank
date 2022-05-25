using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Errors
{
    public class _500_InternalServerError : Error
    {
        public _500_InternalServerError(Exception exception)
        {
            Code = Constants.ErrorCodes._500_InternalServerError;
            Detail = exception.Message.ToString();
            Title = "Internal Server Error";
        }
    }
}
