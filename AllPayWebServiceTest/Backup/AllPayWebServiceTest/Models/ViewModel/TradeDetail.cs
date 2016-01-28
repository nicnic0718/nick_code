using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class TradeDetail
    {
        //交易記錄流水號
        public long AllPayTradeID { get; set; }

        //商家編號(AllPay會提供)  (特店編號)
        public long MerchantID { get; set; }

        //商家交易編號(不可重複)  (特店交易序號)
        public String MerchantTradeNo { get; set; }

        //交易類型
        public String TradeType { get; set; }

        //回傳網址(傳遞前要先做UrlEncode)。計算檢查碼請用原始URL，不可使用中文網址。
        public String ReplyURL { get; set; }

        //幣別(目前僅接受TWD)
        public String Currency { get; set; }

        //交易描述(傳遞前要先做Encode)
        public String TradeDesc { get; set; }

        //廠商交易日期時間 (yyyyMMddHHmmss)
        public string MerchantTradeDate { get; set; }

        //中文編碼格式(Big5/utf-8) ，預設為 utf-8
        public String CharSet { get; set; }

        //是否採用Allpay平台提供的住址，0-不使用，1 – 使用
        public String UseAllpayAddress { get; set; }

        //分期期數，若不分期請帶0，若要使用紅利折抵請用 -1 (僅信用卡有用)
        public String TradeInstmt { get; set; }

        //AllPay 預設交易安控機制，0：不使用；1：使用；2：使用特店自訂規則
        public String TradeLimit { get; set; }

        //真實IP
        public String RealIP { get; set; }

        //代理IP
        public String ProxyIP { get; set; }

        public string Remark { get; set; }
    }
}