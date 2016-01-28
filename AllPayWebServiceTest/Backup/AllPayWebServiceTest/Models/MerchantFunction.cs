using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models
{
    public class MerchantFunction
    {
        //會員編號
        public long MID { get; set; }

        //付款方式編號
        public short PaymentTypeID { get; set; }

        //
        public string PaymentSubTypeID { get; set; }

        //狀態
        public string States { get; set; }

        //HashKey(針對post的資料做加密檢查用)
        public string HashKey { get; set; }

        //HashIV(針對post的資料做加密檢查用)
        public string HashIV { get; set; }

        //備註
        public string Notes { get; set; }

        //public string AllowedIP { get; set; }
    }
}