using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using dulux.integration.ecc.models.request;
using System.Reflection;
using dulux.integration.ecc.models.response;

namespace dulux.integration.ecc.pricing
{
    public class GetPricing : BaseFunction<GetPricing, GetPricingRequestPayload>
    {
        public GetPricing(ILogger<GetPricing> logger) : base(logger)
        {
        }

        [FunctionName("GetPricing")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request,
            ILogger log)
        {
            try
            {
                // Read the request body
                string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

                if (!string.IsNullOrEmpty(requestBody))
                {
                    if (!RequestMessageValid(requestBody, out string[] errors))
                    {
                        // Return a HTTP 400 response
                        return new BadRequestObjectResult(new ErrorResponse { Error = "Invalid Request" });
                    }

                    var data = JsonConvert.DeserializeObject<GetPricingRequestPayload>(requestBody);
                    return new OkObjectResult(new GetPricingResponsePayload
                    {
                        
                    });
                }
                else
                {
                    _logger.LogError($"Error: {nameof(GetPricing)} function: Bad payload - Empty request body.");
                    return new BadRequestObjectResult("Missing request body.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {nameof(GetPricing)} function; exception:{ex.Message}, Stack trace: {ex.StackTrace}");

                return new ObjectResult(new ErrorResponse
                {
                    Error = "Unknown error. Please try again"
                })
                { StatusCode = 500 };
            }
        }
    }
}
