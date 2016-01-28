using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class FirstWebATMClientReturn
    {
        public string RC { get; set; }

        public string MSG { get; set; }

        public string SendSeqNo { get; set; }

        public string MID { get; set; }

        public string ONO { get; set; }

        public string InAccountNo { get; set; }

        public string Amount { get; set; }

        public string TxnDate { get; set; }

        public string TxnTime { get; set; }

        public string OutBankId { get; set; }

        public string AtmSeqNo { get; set; }

        public string Fee { get; set; }

        public string MAC { get; set; }

        public string ResultCode { get; set; }
        public string ResultMsg { get; set; }

    }
}