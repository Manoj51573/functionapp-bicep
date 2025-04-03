using dulux.integration.ecc.pricing.Helper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dulux.integration.ecc.pricing
{
    public class BaseFunction<TFunction, TRequest>
    {
        internal readonly ILogger<TFunction> _logger;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseFunction(ILogger<TFunction> logger)
        {
            _logger = logger;
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
            var request = JsonSerializer.Deserialize<TRequest>(message, _jsonSerializerOptions);

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

    }
}
