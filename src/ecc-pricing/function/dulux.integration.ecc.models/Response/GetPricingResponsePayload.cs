using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace dulux.integration.ecc.models.response
{
    public class GetPricingResponsePayload
    {
        [JsonPropertyName("RefObjKey")]
        public string RefObjKey { get; set; } = "";
        [JsonPropertyName("ReqDateH")]
        public string ReqDateH { get; set; } = "";
        [JsonPropertyName("PriceDate")] 
        public string PriceDate { get; set; } = "";
        [JsonPropertyName("DistrChan")] 
        public string DistrChan { get; set; } = "";
        [JsonPropertyName("CurrIso")] 
        public string CurrIso { get; set; } = "";
        [JsonPropertyName("PurchNoC")] 
        public string PurchNoC { get; set; } = "";
        [JsonPropertyName("SalesOrg")] 
        public string SalesOrg { get; set; } = "";
        [JsonPropertyName("SalesOff")] 
        public string SalesOff { get; set; } = "";
        [JsonPropertyName("Division")] 
        public string Division { get; set; } = "";
        [JsonPropertyName("DocType")] 
        public string DocType { get; set; } = "";
        [JsonPropertyName("ItOrderItemsSet")] 
        public List<ItOrderItem> ItOrderItemsSet { get; set; }
        [JsonPropertyName("EsSalesOrderDataSet")] 
        public List<EsSalesOrderData> EsSalesOrderDataSet { get; set; }
        [JsonPropertyName("Error Message")]
        public String  ErrorMessage { get; set; }
        [JsonPropertyName("Error Details")]
        public ErrorObject Error { get; set; }
    }


    public class ItOrderItem
    {
        [JsonPropertyName("DocNumber")]
        public string DocNumber { get; set; } = "";
        [JsonPropertyName("ItmNumber")] 
        public string ItmNumber { get; set; } = "";
        [JsonPropertyName("ReqQty")] 
        public string ReqQty { get; set; } 
        [JsonPropertyName("Material")] 
        public string Material { get; set; } = "";
        [JsonPropertyName("SalesUnit")] 
        public string SalesUnit { get; set; } = "";
        [JsonPropertyName("NetPrice")] 
        public string NetPrice { get; set; } 
        [JsonPropertyName("Plant")] 
        public string Plant { get; set; } = "";
        [JsonPropertyName("NetValue")] 
        public string NetValue { get; set; } = "";
        [JsonPropertyName("Currency")] 
        public string Currency { get; set; } = "";
        [JsonPropertyName("CondUnit")] 
        public string CondUnit { get; set; }
        [JsonPropertyName("GST")] 
        public string GST { get; set; }
        [JsonPropertyName("TotalPriceIncGST")] 
        public string TotalPriceIncGST { get; set; }
        [JsonPropertyName("Discount")] 
        public string Discount { get; set; } 
    }

    public class EsSalesOrderData
    {
        [JsonPropertyName("Refobjkey")]
        public string Refobjkey { get; set; }
        [JsonPropertyName("GrossValHd")] 
        public string GrossValHd { get; set; }
        [JsonPropertyName("TaxAmountHd")] 
        public string TaxAmountHd { get; set; }
        [JsonPropertyName("NetValHd")] 
        public string NetValHd { get; set; }
        [JsonPropertyName("CreditExposureAmt")] 
        public string CreditExposureAmt { get; set; }
    }



    public class ErrorMessage
{
   public string Lang { get; set; }
   public string Value { get; set; }
}
public class ErrorResolution
{
   public string SAP_Transaction { get; set; }
   public string SAP_Note { get; set; }
}
public class Application
{
   public string Component_Id { get; set; }
   public string Service_Namespace { get; set; }
   public string Service_Id { get; set; }
   public string Service_Version { get; set; }
}
public class InnerError
{
   public Application Application { get; set; }
   public string TransactionId { get; set; }
   public string Timestamp { get; set; }
   public ErrorResolution Error_Resolution { get; set; }
   public List<object> ErrorDetails { get; set; }
}
public class ErrorObject
{
   public string Code { get; set; }
   public ErrorMessage Message { get; set; }
   public InnerError InnerError { get; set; }
}

}
