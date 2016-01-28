using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class MerchantETicketData
    {
        public long MerchantID { get; set; }
        public string MerchantTradeNo { get; set; }
        public string MerchantTradeDate { get; set; }
        public string ReturnURL_Srv { get; set; }
        public string ClientBackURL { get; set; }
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public string TradeDesc { get; set; }
        public string PaymentType { get; set; }
        public int CreditInstallment { get; set; }
        public int InstallmentAmount { get; set; }
        public int Redeem { get; set; }
        public List<MerchantETicketItemData> ItemData { get; set; }
    }
}
