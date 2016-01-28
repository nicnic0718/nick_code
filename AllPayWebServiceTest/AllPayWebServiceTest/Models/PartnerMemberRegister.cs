using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models
{
    public class PartnerMemberRegister
    {

        public string MerchantID { get; set; }

        //廠商會員的唯一編號
        public string MerchantMemberID { get; set; }

        //Server端結果回傳網址(註冊結束後歐付寶會以server post方式回傳註冊結果到此網址。)
        public string ServerReplyURL { get; set; }

        //Client端結果回傳網址(交易結束後以client端方式將頁面導回到廠商設定的網址。)
        public string ClientBackURL { get; set; }

        //
        public long TimeStamp { get; set; }
                
    }
}