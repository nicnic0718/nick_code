using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class MerchantETicketItemData
    {

        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public int ItemType { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int SubTotalAmount { get; set; }
        public int IsGuarantee { get; set; }

    }
}