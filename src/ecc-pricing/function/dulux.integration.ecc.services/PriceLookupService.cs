using dulux.integration.ecc.models.Configurations;
using dulux.integration.ecc.models.request;
using dulux.integration.ecc.models.request.xml;
using dulux.integration.ecc.models.Request;
using dulux.integration.ecc.models.response;
using dulux.integration.ecc.models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
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

        public async Task<EccPricingResponse> GetPrice(EccPricingRequest pricingRequest)
        {
            var client = _httpClientFactory.CreateClient("ecc");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-requested-with", "XMLHttpRequest");
            // Serialize the pricingRequest object to JSON
            string jsonContent = JsonConvert.SerializeObject(pricingRequest, Formatting.Indented);
            // Create JSON StringContent
            using StringContent content = new(
               jsonContent,
               Encoding.UTF8,
               "application/json"
            );


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_option.Value.UserName}:{_option.Value.Password}")));
            var result = await client.PostAsync($"{_option.Value.BaseUrl}", content);
            string responseString = string.Empty;

            if (result.IsSuccessStatusCode)
            {
                responseString = await result.Content.ReadAsStringAsync();
            }

            //return ConvertPricingResponseToJson(json);
            var lookupRequest = JsonConvert.DeserializeObject<EccPricingResponse>(responseString);
            return lookupRequest;
        }

        public static string Serializer(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using var writer = new StringWriter();
            serializer.Serialize(writer, obj);
            var xmlString = writer.ToString();

            return xmlString;
        }

        internal IsOrderHeaderSet ConvertToXmlEccPricingRequest(GetPricingRequestPayload lookupRequest)
        {
            var itOrderItems = new List<models.request.xml.ItOrderItems>();
            var itOrderPartners = new List<models.request.xml.ItOrderPartners>();
            var itOrderSchedLines = new List<models.request.xml.ItOrderSchedLines>();

            foreach (var item in lookupRequest.ItOrderItemsSet)
            {
                itOrderItems.Add(new models.request.xml.ItOrderItems
                {
                    Plant = item.Plant,
                    CondUnit = item.CondUnit,
                    DocNumber = item.DocNumber,
                    Material = item.Material,
                    ReqQty = item.ReqQty == 0 ? "" : item.ReqQty.ToString(),
                    Currency = item.Currency,
                    Discount = item.Discount == 0 ? "" : item.Discount.ToString(),
                    ItmNumber = item.ItmNumber.ToString(),
                    GST = item.GST == 0 ? "" : item.GST.ToString(),
                    NetPrice = item.NetPrice == 0 ? "" : item.NetPrice.ToString(),
                    NetValue = item.NetValue == 0 ? "" : item.NetValue.ToString(),
                    SalesUnit = item.SalesUnit,
                    TotalPriceIncGST = item.TotalPriceIncGST == 0 ? "" : item.TotalPriceIncGST.ToString()
                });
            }

            foreach (var item in lookupRequest.ItOrderPartnersSet)
            {
                itOrderPartners.Add(new models.request.xml.ItOrderPartners
                {
                    PartnRole = item.PartnRole,
                    PartnNumb = item.PartnNumb,
                    ItmNumber = item.ItmNumber,
                    RefObjKey = item.RefObjKey
                });
            }

            foreach (var item in lookupRequest.ItOrderSchedLinesSet)
            {
                itOrderSchedLines.Add(new models.request.xml.ItOrderSchedLines
                {
                    ReqQty = item.ReqQty.ToString(),
                    SchedLine = item.SchedLine,
                    ItmNumber = item.ItmNumber.ToString(),
                    ReqDate = item.ReqDate
                });
            }

            return new IsOrderHeaderSet
            {
                IsOrderHeader = new models.request.xml.IsOrderHeader
                {
                    PriceDate = lookupRequest.PriceDate,
                    ReqDateH = lookupRequest.ReqDateH,
                    DistrChan = lookupRequest.DistrChan,
                    CurrIso = lookupRequest.CurrIso,
                    SalesOrg = lookupRequest.SalesOrg,
                    RefObjKey = lookupRequest.RefObjKey,
                    Division = lookupRequest.Division,
                    DocType = lookupRequest.DocType,
                    EsSalesOrderDataSet = lookupRequest.EsSalesOrderDataSet == null ? new models.request.xml.EsSalesOrderDataSet { EsSalesOrderData = new models.request.xml.EsSalesOrderData { Refobjkey = "dummy", CreditExposureAmt = "10" } } : new models.request.xml.EsSalesOrderDataSet { EsSalesOrderData = new models.request.xml.EsSalesOrderData { Refobjkey = lookupRequest.EsSalesOrderDataSet.EsSalesOrderData.Refobjkey, CreditExposureAmt = lookupRequest.EsSalesOrderDataSet.EsSalesOrderData.CreditExposureAmt, GrossValHd = lookupRequest.EsSalesOrderDataSet.EsSalesOrderData.GrossValHd, NetValHd = lookupRequest.EsSalesOrderDataSet.EsSalesOrderData.NetValHd, TaxAmountHd = lookupRequest.EsSalesOrderDataSet.EsSalesOrderData.TaxAmountHd } },
                    ItOrderItemsSet = new models.request.xml.ItOrderItemsSet { ItOrderItems = itOrderItems },
                    ItOrderPartnersSet = new models.request.xml.ItOrderPartnersSet { ItOrderPartners = itOrderPartners },
                    ItOrderSchedLinesSet = new models.request.xml.ItOrderSchedLinesSet { ItOrderSchedLines = itOrderSchedLines }
                }
            };
        }

        internal GetPricingResponsePayload ConvertPricingResponseToJson(string responseString)
        {
            var serializer = new XmlSerializer(typeof(XmlEccPricingResponse));
            using TextReader reader = new StringReader(responseString);
            var rawResponse = (XmlEccPricingResponse?)serializer.Deserialize(reader);

            var response = new GetPricingResponsePayload();
            if (rawResponse != null)
            {
                var index = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData.FindIndex(x => x.Refobjkey.Equals(rawResponse.IsOrderHeader.RefObjKey)) ?? 0;

                response.RefObjKey = rawResponse.IsOrderHeader.RefObjKey;
                response.PriceDate = rawResponse.IsOrderHeader.PriceDate;
                response.ReqDateH = rawResponse.IsOrderHeader.ReqDateH;
                response.ItOrderItemsSet = new List<models.response.ItOrderItem>();
                response.EsSalesOrderDataSet = new models.response.EsSalesOrderData
                {
                    CreditExposureAmt = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData[index].CreditExposureAmt.ToString(),
                    GrossValHd = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData[index].GrossValHd,
                    NetValHd = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData[index].NetValHd,
                    Refobjkey = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData[index].Refobjkey,
                    TaxAmountHd = rawResponse.IsOrderHeader?.EsSalesOrderDataSet?.EsSalesOrderData[index].TaxAmountHd
                };

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