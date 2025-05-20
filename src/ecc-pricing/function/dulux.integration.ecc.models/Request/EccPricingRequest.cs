using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dulux.integration.ecc.models.Request
{
    public class EsSalesOrderDataSet
    {
        [JsonProperty("results")]
        public List<ResultsEsSalesOrderDataSet> resultsEsSalesOrderDataSet;
    }

    public class ItOrderItemsSet
    {
        [JsonProperty("results")]
        public List<ResultsItOrderItemsSet> resultsItOrderItemsSet;
    }

    public class ItOrderPartnersSet
    {
        [JsonProperty("results")]
        public List<ResultsItOrderPartnersSet> resultsItOrderPartnersSet;
    }

    public class ItOrderSchedLinesSet
    {
        [JsonProperty("results")]
        public List<ResultsItOrderSchedLinesSet> resultsItOrderSchedLinesSet;
    }

    public class Metadata
    {
        [JsonProperty("id")]
        public string id;

        [JsonProperty("uri")]
        public string uri;

        [JsonProperty("type")]
        public string type;
    }

    public class ResultsEsSalesOrderDataSet
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata;

        [JsonProperty("Refobjkey")]
        public string Refobjkey;

        [JsonProperty("CreditExposureAmt")]
        public string CreditExposureAmt;
    }

    public class ResultsItOrderItemsSet
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata;

        [JsonProperty("DocNumber")]
        public string DocNumber;

        [JsonProperty("ItmNumber")]
        public string ItmNumber;

        [JsonProperty("ReqQty")]
        public object ReqQty;

        [JsonProperty("Material")]
        public string Material;

        [JsonProperty("SalesUnit")]
        public string SalesUnit;

        [JsonProperty("NetPrice")]
        public object NetPrice;

        [JsonProperty("Plant")]
        public string Plant;

        [JsonProperty("NetValue")]
        public object NetValue;

        [JsonProperty("Currency")]
        public string Currency;

        [JsonProperty("CondUnit")]
        public string CondUnit;

        [JsonProperty("GST")]
        public object GST;

        [JsonProperty("TotalPriceIncGST")]
        public object TotalPriceIncGST;

        [JsonProperty("Discount")]
        public object Discount;
    }

    public class ResultsItOrderPartnersSet
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata;

        [JsonProperty("RefObjKey")]
        public string RefObjKey;

        [JsonProperty("PartnRole")]
        public string PartnRole;

        [JsonProperty("PartnNumb")]
        public string PartnNumb;

        [JsonProperty("ItmNumber")]
        public string ItmNumber;

        [JsonProperty("PartnName")]
        public string PartnName;

        [JsonProperty("PartnCountry")]
        public string PartnCountry;
    }

    public class ResultsItOrderSchedLinesSet
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata;

        [JsonProperty("RefObjKey")]
        public string RefObjKey;

        [JsonProperty("ItmNumber")]
        public string ItmNumber;

        [JsonProperty("SchedLine")]
        public string SchedLine;

        [JsonProperty("ReqDate")]
        public string ReqDate;

        [JsonProperty("ReqQty")]
        public string ReqQty;
    }

    public class EccPricingRequest1
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata;

        [JsonProperty("RefObjKey")]
        public string RefObjKey;

        [JsonProperty("DocType")]
        public string DocType;

        [JsonProperty("SalesOrg")]
        public string SalesOrg;

        [JsonProperty("DistrChan")]
        public string DistrChan;

        [JsonProperty("Division")]
        public string Division;

        [JsonProperty("SalesOff")]
        public string SalesOff;

        [JsonProperty("ReqDateH")]
        public string ReqDateH;

        [JsonProperty("PriceDate")]
        public string PriceDate;

        [JsonProperty("PurchNoC")]
        public string PurchNoC;

        [JsonProperty("CurrIso")]
        public string CurrIso;

        [JsonProperty("ItOrderItemsSet")]
        public ItOrderItemsSet ItOrderItemsSet;

        [JsonProperty("ItOrderPartnersSet")]
        public ItOrderPartnersSet ItOrderPartnersSet;

        [JsonProperty("ItOrderSchedLinesSet")]
        public ItOrderSchedLinesSet ItOrderSchedLinesSet;

        [JsonProperty("EsSalesOrderDataSet")]
        public EsSalesOrderDataSet EsSalesOrderDataSet;
    }











    public class EccPricingRequest
    {
        [JsonProperty("DocType")]
        public string DocType { get; set; }
        [JsonProperty("DistrChan")]
        public string DistrChan { get; set; }
        [JsonProperty("Division")]
        public string Division { get; set; }
        [JsonProperty("SalesOrg")]
        public string SalesOrg { get; set; }
        [JsonProperty("ReqDateH")]
        public string ReqDateH { get; set; }
        [JsonProperty("PriceDate")]
        public string PriceDate { get; set; }
        [JsonProperty("CurrIso")]
        public string CurrIso { get; set; }
        [JsonProperty("SalesOff")]
        public string SalesOff { get; set; }
        [JsonProperty("ItOrderItemsSet")]
        public List<ItOrderItem> ItOrderItemsSet { get; set; }
        [JsonProperty("ItOrderPartnersSet")]
        public List<ItOrderPartner> ItOrderPartnersSet { get; set; }
        [JsonProperty("ItOrderSchedLinesSet")]
        public List<ItOrderSchedLine> ItOrderSchedLinesSet { get; set; }
    }
    public class ItOrderItem
    {
        [JsonProperty("ItmNumber")]
        public string ItmNumber { get; set; }
        [JsonProperty("Material")]
        public string Material { get; set; }
        [JsonProperty("SalesUnit")]
        public string SalesUnit { get; set; }
    }
    public class ItOrderPartner
    {
        [JsonProperty("PartnRole")]
        public string PartnRole { get; set; }
        [JsonProperty("PartnNumb")]
        public string PartnNumb { get; set; }
        [JsonProperty("ItmNumber")]
        public string ItmNumber { get; set; }
    }
    public class ItOrderSchedLine
    {
        [JsonProperty("ItmNumber")]
        public string ItmNumber { get; set; }
        [JsonProperty("SchedLine")]
        public string SchedLine { get; set; }
        [JsonProperty("ReqQty")]
        public string ReqQty { get; set; }
    }


}
