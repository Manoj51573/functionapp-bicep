using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dulux.integration.ecc.models.Response
{
    public class Detail
    {
        public Metadata __metadata { get; set; }
        public string RefObjKey { get; set; }
        public string DocType { get; set; }
        public string SalesOrg { get; set; }
        public string DistrChan { get; set; }
        public string Division { get; set; }
        public string SalesOff { get; set; }
        public string ReqDateH { get; set; }
        public string PriceDate { get; set; }
        public string PurchNoC { get; set; }
        public string CurrIso { get; set; }
        public ItOrderItemsSet ItOrderItemsSet { get; set; }
        public ItOrderPartnersSet ItOrderPartnersSet { get; set; }
        public ItOrderSchedLinesSet ItOrderSchedLinesSet { get; set; }
        public EsSalesOrderDataSet EsSalesOrderDataSet { get; set; }
    }

    public class Deferred
    {
        public string uri { get; set; }
    }

    public class EsSalesOrderDataSet
    {
        public List<Result> results { get; set; }
    }

    public class IsOrderHeader
    {
        public Deferred __deferred { get; set; }
    }

    public class ItOrderItemsSet
    {
        public List<Result> results { get; set; }
    }

    public class ItOrderPartnersSet
    {
        public List<object> results { get; set; }
    }

    public class ItOrderSchedLinesSet
    {
        public List<object> results { get; set; }
    }

    public class Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Result
    {
        public Metadata __metadata { get; set; }
        public string DocNumber { get; set; }
        public string ItmNumber { get; set; }
        public string ReqQty { get; set; }
        public string Material { get; set; }
        public string SalesUnit { get; set; }
        public string NetPrice { get; set; }
        public string Plant { get; set; }
        public string NetValue { get; set; }
        public string Currency { get; set; }
        public string CondUnit { get; set; }
        public string GST { get; set; }
        public string TotalPriceIncGST { get; set; }
        public string Discount { get; set; }
        public IsOrderHeader IsOrderHeader { get; set; }
        public string Refobjkey { get; set; }
        public string NetValHd { get; set; }
        public string GrossValHd { get; set; }
        public string TaxAmountHd { get; set; }
        public string CreditExposureAmt { get; set; }
    }

    public class EccPricingResponse
    {
        public Detail d { get; set; }
    }
}
