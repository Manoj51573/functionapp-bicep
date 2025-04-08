using dulux.integration.ecc.models.Configurations;
using dulux.integration.ecc.models.request;
using dulux.integration.ecc.models.response;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dulux.integration.ecc.services
{
    public class PriceLookupService : IPriceLookupService
    {
        private readonly IOptions<SapEccOption> _option;
        private readonly IHttpClientFactory _httpClientFactory;

        public PriceLookupService(IOptions<SapEccOption> option, IHttpClientFactory httpClientFactory) 
        {
            _option = option;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GetPricingResponsePayload> GetPrice(GetPricingRequestPayload pricingRequest)
        {
            var client = _httpClientFactory.CreateClient("ecc");
            client.DefaultRequestHeaders.Add("Accept", "application/xml");

            using StringContent content = new(
                JsonSerializer.Serialize(ConvertToXmlEccPricingRequest(pricingRequest)),
                Encoding.UTF8,
            "application/xml");


            var result = await client.PostAsync($"{_option.Value.BaseUrl}", content);
            string responseString = string.Empty;

            if (result.IsSuccessStatusCode)
            {
                responseString = await result.Content.ReadAsStringAsync();
            }
            return ConvertPricingResponseToJson(responseString);
        }

        internal XmlEccPricingRequest ConvertToXmlEccPricingRequest(GetPricingRequestPayload lookupRequest)
        {
            // Convert the lookupRequest to XmlEccPricingRequest
            // Implement the conversion logic here
            return new XmlEccPricingRequest();
        }

        internal GetPricingResponsePayload ConvertPricingResponseToJson(string responseString)
        {
            var serializer = new XmlSerializer(typeof(XmlEccPricingResponse));
            using TextReader reader = new StringReader(responseString);
            var rawResponse = (XmlEccPricingResponse?)serializer.Deserialize(reader);

            var response = new GetPricingResponsePayload();
            if (rawResponse != null)
            {
                response.RefObjKey = rawResponse.IsOrderHeader.RefObjKey;
                response.PriceDate = rawResponse.IsOrderHeader.PriceDate;
                response.ReqDateH = rawResponse.IsOrderHeader.ReqDateH;
                response.ItOrderItemsSet = new List<models.response.ItOrderItem>();

                foreach (var item in rawResponse.IsOrderHeader.ItOrderItemsSet.ItOrderItems)
                {
                    response.ItOrderItemsSet.Add(new models.response.ItOrderItem
                    {
                        DocNumber = item.DocNumber,
                        ItmNumber = item.ItmNumber,
                        ReqQty = item.ReqQty.ToString(),
                        Material = item.Material,
                        SalesUnit = item.SalesUnit,
                        NetPrice = item.NetPrice.ToString(),
                        Plant = item.Plant,
                        NetValue = item.NetValue.ToString(),
                        Currency = item.Currency,
                        CondUnit = item.CondUnit,
                        GST = item.GST.ToString(),
                        TotalPriceIncGST = item.TotalPriceIncGST.ToString(),
                        Discount = item.Discount
                    });
                }
            }

            return response;
        }
    }
}