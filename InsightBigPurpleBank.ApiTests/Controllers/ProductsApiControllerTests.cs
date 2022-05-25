using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsightBigPurpleBank.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InsightBigPurpleBank.Domain.Interfaces;
using Moq;
using System.Net.Http;
using InsightBigPurpleBank.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InsightBigPurpleBank.Domain.Models;

namespace InsightBigPurpleBank.Api.Controllers.Tests
{
    [TestClass()]
    public class ProductsApiControllerTests
    {
        private readonly ILogger<ProductsApiController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ActionContext _actionContext;
        private readonly HttpContext _httpContext;

        public ProductsApiControllerTests()
        {
            _logger = Mock.Of<ILogger<ProductsApiController>>();
            _productRepository = Mock.Of<IProductRepository>();
            _actionContext = new ActionContext();
            _httpContext = new DefaultHttpContext();
        }

        [TestMethod()]
        public async Task GetProducts_IsRequestedVersionPresentAndPositive_Fail_406_TestAsync()
        {
            //Arrange
            var controller = GetController("1");

            // Act
            var response = await controller.GetProducts(string.Empty, string.Empty, string.Empty, string.Empty, null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 406);
            Assert.AreEqual(code, Constants.ErrorCodes._406_UnsupportedVersion);
        }

        [TestMethod()]
        public async Task GetProducts_PageGreaterThanAvailable_Fail_422_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts(string.Empty, string.Empty, string.Empty, string.Empty, 10, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 422);
            Assert.AreEqual(code, Constants.ErrorCodes._422_InvalidPage);
        }

        [TestMethod()]
        public async Task GetProducts_RequestedVersionNotPositiveInteger_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController("0");

            // Act
            var response = await controller.GetProducts(string.Empty, string.Empty, string.Empty, string.Empty, null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidVersion);
        }

        [TestMethod()]
        public async Task GetProducts_EffectiveIncorrect_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts("INVALID", string.Empty, string.Empty, string.Empty, null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidField);
        }

        [TestMethod()]
        public async Task GetProducts_ProductCategoryIncorrect_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts(string.Empty, string.Empty, string.Empty, "INVALID", null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidField);
        }

        [TestMethod()]
        public async Task GetProducts_UpdatedSinceIncorrect_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts(string.Empty, "INVALID", string.Empty, string.Empty, null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidField);
        }

        [TestMethod()]
        public async Task GetProducts_UpdatedSinceInFutureIncorrect_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts(string.Empty, DateTime.Now.AddDays(1).ToString(), string.Empty, string.Empty, null, null);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidDate);
        }

        [TestMethod()]
        public async Task GetProducts_MaxPageSizeOutOfCDSRange_Fail_400_TestAsync()
        {
            //Arrange
            var controller = GetController();

            // Act
            var response = await controller.GetProducts(string.Empty, string.Empty, string.Empty, string.Empty, null, 1001);
            response.ExecuteResult(_actionContext);
            var result = response as ObjectResult;
            var code = ((ResponseErrorList)result.Value).Errors[0].Code;

            // Assert
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(code, Constants.ErrorCodes._400_InvalidPageSize);
        }

        #region Private Methods
        private ProductsApiController GetController()
        {
            var controller = new ProductsApiController(_logger, _productRepository);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _httpContext
            };
            controller.ControllerContext.HttpContext.Request.Headers[Constants.Headers.Version] = "3";

            return controller;
        }

        private ProductsApiController GetController(string requestedVersion)
        {
            var controller = new ProductsApiController(_logger, _productRepository);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _httpContext
            };
            controller.ControllerContext.HttpContext.Request.Headers[Constants.Headers.Version] = requestedVersion;

            return controller;
        }
        #endregion
    }
}