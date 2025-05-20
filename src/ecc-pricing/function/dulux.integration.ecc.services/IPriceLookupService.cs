using dulux.integration.ecc.models.request;
using dulux.integration.ecc.models.Request;
using dulux.integration.ecc.models.response;
using dulux.integration.ecc.models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dulux.integration.ecc.services
{
    public interface IPriceLookupService
    {
        Task<EccPricingResponse> GetPrice(EccPricingRequest pricingRequest);
    }
}
