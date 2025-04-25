using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace dulux.integration.ecc.models.request.xml
{
    [XmlRoot(ElementName = "ItOrderSchedLines")]
    public class ItOrderSchedLines
    {
        [XmlElement(ElementName = "SchedLine")]
        public string SchedLine { get; set; }

        [XmlElement(ElementName = "RefObjKey")]
        public string RefObjKey { get; set; }

        [XmlElement(ElementName = "ReqQty")]
        public string ReqQty { get; set; }

        [XmlElement(ElementName = "ItmNumber")]
        public string ItmNumber { get; set; }

        [XmlElement(ElementName = "ReqDate")]
        public string ReqDate { get; set; }
    }

    [XmlRoot(ElementName = "ItOrderSchedLinesSet")]
    public class ItOrderSchedLinesSet
    {
        [XmlElement(ElementName = "ItOrderSchedLines")]
        public List<ItOrderSchedLines> ItOrderSchedLines { get; set; }
    }

    [XmlRoot(ElementName = "ItOrderItems")]
    public class ItOrderItems
    {
        [XmlElement(ElementName = "Plant")]
        public string Plant { get; set; }

        [XmlElement(ElementName = "CondUnit")]
        public string CondUnit { get; set; }

        [XmlElement(ElementName = "DocNumber")]
        public string DocNumber { get; set; }

        [XmlElement(ElementName = "Material")]
        public string Material { get; set; }

        [XmlElement(ElementName = "ItmNumber")]
        public string ItmNumber { get; set; }

        [XmlElement(ElementName = "ReqQty")]
        public string ReqQty { get; set; }

        [XmlElement(ElementName = "SalesUnit")]
        public string SalesUnit { get; set; }

        [XmlElement(ElementName = "NetPrice")]
        public string NetPrice { get; set; }

        [XmlElement(ElementName = "NetValue")]
        public string NetValue { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }

        [XmlElement(ElementName = "GST")]
        public string GST { get; set; }

        [XmlElement(ElementName = "TotalPriceIncGST")]
        public string TotalPriceIncGST { get; set; }

        [XmlElement(ElementName = "Discount")]
        public string Discount { get; set; }
    }

    [XmlRoot(ElementName = "ItOrderItemsSet")]
    public class ItOrderItemsSet
    {
        [XmlElement(ElementName = "ItOrderItems")]
        public List<ItOrderItems> ItOrderItems { get; set; }
    }

    [XmlRoot(ElementName = "ItOrderPartners")]
    public class ItOrderPartners
    {
        [XmlElement(ElementName = "PartnRole")]
        public string PartnRole { get; set; }

        [XmlElement(ElementName = "PartnNumb")]
        public string PartnNumb { get; set; }

        [XmlElement(ElementName = "PartnName")]
        public string PartnName { get; set; }

        [XmlElement(ElementName = "PartnCountry")]
        public string PartnCountry { get; set; }

        [XmlElement(ElementName = "RefObjKey")]
        public string RefObjKey { get; set; }

        [XmlElement(ElementName = "ItmNumber")]
        public string ItmNumber { get; set; }
    }

    [XmlRoot(ElementName = "ItOrderPartnersSet")]
    public class ItOrderPartnersSet
    {
        [XmlElement(ElementName = "ItOrderPartners")]
        public List<ItOrderPartners> ItOrderPartners { get; set; }
    }

    [XmlRoot(ElementName = "EsSalesOrderData")]
    public class EsSalesOrderData
    {
        [XmlElement(ElementName = "Refobjkey")]
        public string Refobjkey { get; set; }

        [XmlElement(ElementName = "CreditExposureAmt")]
        public string CreditExposureAmt { get; set; }
        [XmlElement(ElementName = "NetValHd")]
        public string NetValHd { get; set; }
        [XmlElement(ElementName = "GrossValHd")]
        public string GrossValHd { get; set; }
        [XmlElement(ElementName = "TaxAmountHd")]
        public string TaxAmountHd { get; set; }
    }

    [XmlRoot(ElementName = "EsSalesOrderDataSet")]
    public class EsSalesOrderDataSet
    {
        [XmlElement(ElementName = "EsSalesOrderData")]
        public EsSalesOrderData EsSalesOrderData { get; set; }
    }

    [XmlRoot(ElementName = "IsOrderHeader")]
    public class IsOrderHeader
    {
        [XmlElement(ElementName = "PriceDate")]
        public string PriceDate { get; set; }

        [XmlElement(ElementName = "ReqDateH")]
        public string ReqDateH { get; set; }

        [XmlElement(ElementName = "DistrChan")]
        public string DistrChan { get; set; }

        [XmlElement(ElementName = "CurrIso")]
        public string CurrIso { get; set; }

        [XmlElement(ElementName = "PurchNoC")]
        public string PurchNoC { get; set; }

        [XmlElement(ElementName = "SalesOrg")]
        public string SalesOrg { get; set; }

        [XmlElement(ElementName = "SalesOff")]
        public string SalesOff { get; set; }

        [XmlElement(ElementName = "RefObjKey")]
        public string RefObjKey { get; set; }

        [XmlElement(ElementName = "Division")]
        public string Division { get; set; }

        [XmlElement(ElementName = "DocType")]
        public string DocType { get; set; }

        [XmlElement(ElementName = "ItOrderSchedLinesSet")]
        public ItOrderSchedLinesSet ItOrderSchedLinesSet { get; set; }

        [XmlElement(ElementName = "ItOrderItemsSet")]
        public ItOrderItemsSet ItOrderItemsSet { get; set; }

        [XmlElement(ElementName = "ItOrderPartnersSet")]
        public ItOrderPartnersSet ItOrderPartnersSet { get; set; }

        [XmlElement(ElementName = "EsSalesOrderDataSet")]
        public EsSalesOrderDataSet EsSalesOrderDataSet { get; set; }
    }

    [XmlRoot(ElementName = "IsOrderHeaderSet")]
    public class IsOrderHeaderSet
    {
        [XmlElement(ElementName = "IsOrderHeader")]
        public IsOrderHeader IsOrderHeader { get; set; }
    }
}
