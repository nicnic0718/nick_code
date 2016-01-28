using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models
{
    public class ExchangeModel
    {
        public string MerchantID { get; set; }
        public string MerchantTradeNo { get; set; }
        public string TradeNo { get; set; }
        public string ItemNo { get; set; }
        public string Amount { get; set; }
        public string SNO { get; set; }
        public string PWD { get; set; }
        public string TimeStamp { get; set; }
    }
}