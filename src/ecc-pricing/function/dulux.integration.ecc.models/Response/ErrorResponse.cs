using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dulux.integration.ecc.models.response
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; } = String.Empty;
    }
}
