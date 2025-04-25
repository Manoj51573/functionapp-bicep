using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace dulux.integration.ecc.models.request
{
    public class GetPricingRequestPayload
    {
        [Required]
        public string DocType { get; set; }
        [Required]
        public string DistrChan { get; set; }
        [Required]
        public string Division { get; set; }
        [Required] 
        public string SalesOrg { get; set; }
        [Required] 
        public string CurrIso { get; set; }
        [Required] 
        public string ReqDateH { get; set; }
        [Required] 
        public string PriceDate { get; set; }
        [Required] 
        public string RefObjKey { get; set; }
        [Required] 
        public List<ItOrderItem> ItOrderItemsSet { get; set; }
        [Required] 
        public List<ItOrderPartner> ItOrderPartnersSet { get; set; }
        [Required] 
        public List<ItOrderSchedLine> ItOrderSchedLinesSet { get; set; }
        public EsSalesOrderDataSet EsSalesOrderDataSet { get; set; }
    }

    public class EsSalesOrderDataSet
    {
        public EsSalesOrderData EsSalesOrderData { get; set; }
    }

    public class EsSalesOrderData
    {

        public string Refobjkey { get; set; }
        public string CreditExposureAmt { get; set; }
        public string NetValHd { get; set; }
        public string GrossValHd { get; set; }
        public string TaxAmountHd { get; set; }
    }

    public class ItOrderItem
    {
        [Required]
        public int ItmNumber { get; set; }
        [Required]
        [MaxLength(18)]
        public string Material { get; set; }
        [Required] 
        public string SalesUnit { get; set; }
        public string Plant { get; set; }
        public string CondUnit { get; set; }
        public string DocNumber { get; set; }
        public int ReqQty { get; set; }
        public string Currency { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal NetPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal TotalPriceIncGST { get; set; }
    }

    public class ItOrderPartner
    {
        [Required]
        public string PartnRole { get; set; }
        [Required] 
        public string PartnNumb { get; set; }
        [Required] 
        public string ItmNumber { get; set; }
        [Required] 
        public string RefObjKey { get; set; }
    }

    public class ItOrderSchedLine
    {
        public int ItmNumber { get; set; }
        public string SchedLine { get; set; }
        public int ReqQty { get; set; }
        public string ReqDate { get; set; }
    }
}
