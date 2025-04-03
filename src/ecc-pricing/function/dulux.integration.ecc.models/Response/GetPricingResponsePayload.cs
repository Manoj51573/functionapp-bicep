using System;
using System.Collections.Generic;

namespace dulux.integration.ecc.models.response
{
    public class GetPricingResponsePayload
    {
        public string RefObjKey { get; set; }
        public string ReqDateH { get; set; }
        public string PriceDate { get; set; }
        public string DistrChan { get; set; }
        public string CurrIso { get; set; }
        public string PurchNoC { get; set; }
        public string SalesOrg { get; set; }
        public string SalesOff { get; set; }
        public string Division { get; set; }
        public string DocType { get; set; }
        public List<ItOrderItem> ItOrderItemsSet { get; set; }
        public EsSalesOrderData EsSalesOrderDataSet { get; set; }
    }

    public class ItOrderItem
    {
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
    }

    public class EsSalesOrderData
    {
        public string Refobjkey { get; set; }
        public string GrossValHd { get; set; }
        public string TaxAmountHd { get; set; }
        public string NetValHd { get; set; }
        public string CreditExposureAmt { get; set; }
    }
}
