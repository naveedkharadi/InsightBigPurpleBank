using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace InsightBigPurpleBank.Api.Filters
{
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
        /// <summary>
        /// Operation filter to support setting header parameters from Swagger UI. 
        /// This method can be further customized to control the visibility different headers for different operations.
        /// Currently, all API operations from Swagger UI will reqruie a value for "x-v" header.
        /// </summary>
        /// <param name="operation"><see cref="OpenApiOperation"/></param>
        /// <param name="context"><see cref="OperationFilterContext"/></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-v",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
