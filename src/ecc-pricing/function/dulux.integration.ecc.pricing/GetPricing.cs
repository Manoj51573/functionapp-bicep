using Azure.Core;
using dulux.integration.ecc.models.request;
using dulux.integration.ecc.models.response;
using dulux.integration.ecc.pricing.Helper;
using dulux.integration.ecc.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GetPricing
{
    public class GetPricing
    {
        private readonly ILogger<GetPricing> _logger;
        private readonly IPriceLookupService _priceLookupService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GetPricing(ILogger<GetPricing> logger, IPriceLookupService priceLookupService)
        {
            _logger = logger;
            _priceLookupService = priceLookupService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        internal bool RequestMessageExists(string message)
        {
            // Validate that the request body is not empty
            if (string.IsNullOrWhiteSpace(message))
            {
                // Log the error
                _logger.LogError("Request body is null or whitespace");

                return false;
            }

            return true;
        }


        internal bool RequestMessageValid(string message, out string[] errors)
        {
            // Parse the request body
            var request = System.Text.Json.JsonSerializer.Deserialize<GetPricingRequestPayload>(message, _jsonSerializerOptions);

            // Validate the request schema
            if (Validation.TrySchemaValidate(request, out List<ValidationResult> results) == false)
            {
                errors = results.Select(x => x.ErrorMessage).ToArray();

                // If the request was not valid, log the validation errors
                _logger.LogError(string.Join('\n', errors));

                return false;
            }

            errors = System.Array.Empty<string>();

            return true;
        }

        [Function("GetPricing")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest request)
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

                    var lookupRequest = JsonConvert.DeserializeObject<GetPricingRequestPayload>(requestBody);

                    if (lookupRequest == null)
                    {
                        _logger.LogError($"Error: {nameof(GetPricing)} function: Failed to Deserialize submitted payload to GetPricingRequestPayload.");
                        return new BadRequestObjectResult("Invalid Request");
                    }
                    else 
                    {
                        // Call the price lookup service
                        var result = await _priceLookupService.GetPrice(lookupRequest);

                        return new OkObjectResult(result);
                    }
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
