using System;
using System.Collections.Generic;

namespace dulux.integration.ecc.models.request
{
    public class GetPricingRequestPayload
    {
        public string DocType { get; set; }
        public string DistrChan { get; set; }
        public string Division { get; set; }
        public string SalesOrg { get; set; }
        public string CurrIso { get; set; }
        public DateTime ReqDateH { get; set; }
        public DateTime PriceDate { get; set; }
        public string RefObjKey { get; set; }
        public List<ItOrderItem> ItOrderItemsSet { get; set; }
        public List<ItOrderPartner> ItOrderPartnersSet { get; set; }
        public List<ItOrderSchedLine> ItOrderSchedLinesSet { get; set; }
    }

    public class ItOrderItem
    {
        public int ItmNumber { get; set; }
        public string Material { get; set; }
        public string SalesUnit { get; set; }
        public string Plant { get; set; }
    }

    public class ItOrderPartner
    {
        public string PartnRole { get; set; }
        public string PartnNumb { get; set; }
        public string ItmNumber { get; set; }
        public string RefObjKey { get; set; }
    }

    public class ItOrderSchedLine
    {
        public int ItmNumber { get; set; }
        public string SchedLine { get; set; }
        public int ReqQty { get; set; }
        public DateTime ReqDate { get; set; }
    }
}
