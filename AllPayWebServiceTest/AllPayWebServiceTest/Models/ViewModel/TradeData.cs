using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class TradeData
    {
        public string MID { get; set; }

        public string LoginTokenID { get; set; }

        public string TimeStamp { get; set; }

        public string TradeType { get; set; }

        public string CardID { get; set; }
    }
}