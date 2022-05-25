using InsightBigPurpleBank.Api.Errors;
using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Enums;
using InsightBigPurpleBank.Domain.Interfaces;
using InsightBigPurpleBank.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsApiController : ControllerBase
    {
        private readonly ILogger<ProductsApiController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsApiController(ILogger<ProductsApiController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <remarks>Obtain a list of products that are currently openly offered to the market.</remarks>
        /// <param name="effective">Allows for the filtering of products based on whether the current time is within the period of time defined as effective by the effectiveFrom and effectiveTo fields. Valid values are CURRENT, FUTURE and ALL. If absent defaults to CURRENT.</param>
        /// <param name="updatedSince">Only include products that have been updated after the specified date and time. If absent defaults to include all products.</param>
        /// <param name="brand">Filter results based on a specific brand.</param>
        /// <param name="productCategory">Used to filter results on the productCategory field applicable to accounts. Any one of the valid values for this field can be supplied. If absent then all accounts returned.</param>
        /// <param name="page">Page of results to request (standard pagination).</param>
        /// <param name="pageSize">Page size to request. Default is 25 (standard pagination).</param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="406">NotAcceptable</response>
        /// <response code="422">UnprocessableEntity</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [Route("/banking/products")]
        [ProducesResponseType(typeof(ResponseBankingProductList), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorList), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorList), (int)HttpStatusCode.NotAcceptable)]
        [ProducesResponseType(typeof(ResponseErrorList), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> GetProducts(
            [FromQuery] string effective,
            [FromQuery] string updatedSince,
            [FromQuery] string brand,
            [FromQuery] string productCategory,
            [FromQuery] int? page,
            [FromQuery] int? pageSize)
        {
            var errorList = new ResponseErrorList() { Errors = new System.Collections.Generic.List<Error>() };
            var supportedVersion = 3; // this can be fetched from another source; for demo it's fixed here
            var maximumPages = 5; // this can be fetched from another source; for demo it's fixed here
            var requestedVersion = -1;

            // Is "x-v" header present and is a positive integer?
            if (!int.TryParse(Request.Headers[Constants.Headers.Version], out requestedVersion) || requestedVersion < 1)
            {
                errorList.Errors.Add(new _400_InvalidVersion(Convert.ToString(Request.Headers[Constants.Headers.Version])));
            }
            // If parameter "effective" is present, does it have a valid date time value?
            if (!string.IsNullOrEmpty(effective) && !Enum.TryParse(typeof(EffectiveDates), effective, out var effectiveDate))
            {
                errorList.Errors.Add(new _400_InvalidField("effective"));
            }
            // If parameter "productCategory" is present, does it have a valid product category value?
            if (!string.IsNullOrEmpty(productCategory) && !Enum.TryParse(typeof(BankingProductCategory), productCategory, out var productCategoryEnum))
            {
                errorList.Errors.Add(new _400_InvalidField("productCategory"));
            }
            // If parameter "updatedSince" is present, does it have a valid date time value?
            if (!string.IsNullOrEmpty(updatedSince) && !DateTime.TryParse(updatedSince, out var updatedSinceDateTime))
            {
                errorList.Errors.Add(new _400_InvalidField("updatedSince"));
            }
            // If parameter "updatedSince" is present, does it have a future date?
            if (DateTime.TryParse(updatedSince, out updatedSinceDateTime) && updatedSinceDateTime > DateTime.Now)
            {
                errorList.Errors.Add(new _400_InvalidDate("updatedSince"));
            }
            // If parameter "pageSize" is present, does it have a value less than the maximum specified by CDS?
            if (pageSize.HasValue && pageSize > Constants.MaxPageSizeByCDS)
            {
                errorList.Errors.Add(new _400_InvalidPageSize(pageSize.GetValueOrDefault()));
            }
            if (errorList.Errors.Count > 0)
            {
                return StatusCode(400, errorList);
            }

            // Is parameter "x-v" (requested version) present and does it match the supported version?
            if (!Request.Headers.ContainsKey(Constants.Headers.Version)
                || requestedVersion != supportedVersion) // requestedVersion can be checked to be in a certain range; for demo it's expected to match the supported version
            {
                errorList.Errors.Add(new _406_UnsupportedVersion(supportedVersion, requestedVersion));
                return StatusCode(406, errorList);
            }

            // If parameter "page" is present, is it less than or equal to the number of pages available?
            if (page.HasValue && page > maximumPages)
            {
                errorList.Errors.Add(new _422_InvalidPage(maximumPages));
            }
            if (errorList.Errors.Count > 0)
            {
                return StatusCode(422, errorList);
            }

            var products = await _productRepository.GetProducts();

            Response.Headers.Add("x-v", Convert.ToString(supportedVersion));
            return Ok(products);
        }
    }
}
