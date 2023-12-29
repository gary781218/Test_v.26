using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Modules.Utilities
{
    public class SwaggerHeaderFilter : IOperationFilter
    {
        /// <summary>
        /// 套用 Swagger Operation
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var pp = operation.Parameters;

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            IDictionary<string, OpenApiExample> langs = new Dictionary<string, OpenApiExample>();
            langs.Add("繁中", new OpenApiExample() { Value = new OpenApiString("zh-TW") });
            langs.Add("簡中", new OpenApiExample() { Value = new OpenApiString("zh-CN") });
            langs.Add("英文", new OpenApiExample() { Value = new OpenApiString("en-US") });

            operation.Parameters.Add(
                new OpenApiParameter
                {
                    Name = "Accept-Language",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema { Type = "string" },
                    Examples = langs,
                    Example = new OpenApiString("zh-TW"),
                    Description = "呼叫端喜好語系, 只能為 zh-TW、zh-CN、en-US",
                }
            );

        }
    }
}