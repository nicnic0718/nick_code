using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Allpay.AES;

namespace AllPayWebServiceTest.Controllers
{
    public class WebATMController : Controller
    {
        //
        // GET: /WebATM/
       
        public ActionResult Index()
        {
            long AllPayMerchantID = 1000070;   //測試機目前給企劃測試的特店id是1000070
            string AllPayHashKey = "koyqVBURmmkQxROZ";        //開發 1000070 
            string AllPayHashIV = "BcRITiCQaUHBZC1f";
            string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";
            
            //string AllPayHashKey = "ejCk326UnaZWKisg";
            //string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            //long AllPayMerchantID = 2000132;
            string PaymentType = "WEB_ATM";
            //設定MP的Post網址    
            //string postURL = "http://pay-stage.allpay.com.tw/payment/gateway";

            //string xxx = new Allpay.AES.AES().AES_EnCrypt(AllPayHashKey, AllPayHashIV, "123");


            string ReplyURL = "http://localhost/";
            string BackURL = "";
            string Remark = "";
            string ServerReplyURL = "";
            string TradeDesc = "allapy123";

            string TradeDescEncode = HttpUtility.UrlEncode(TradeDesc);
            string ReplyURLEncode = HttpUtility.UrlEncode(ReplyURL);
            string BackURLEncode = HttpUtility.UrlEncode(BackURL);
            string RemarkEncode = HttpUtility.UrlEncode(Remark);
            string ServerReplyURLEncode = HttpUtility.UrlEncode(ServerReplyURL);
            //string totalAmount = "3";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");


            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                    + "<MerchantID>1000070</MerchantID>"
                    + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                    + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                    + "<TotalAmount>22000</TotalAmount>"
                    + "<TradeDesc>" + TradeDescEncode + "</TradeDesc>"
                    + "<TradeCategory>1</TradeCategory>"
                    + "<BankName>ALL</BankName>"
                    + "<CharSet>utf-8</CharSet>"
                    + "<ReplyURL>"+ReplyURLEncode+"</ReplyURL>"
                    + "<BackURL>"+ BackURLEncode +"</BackURL>"
                    + "<Remark>" + RemarkEncode + "</Remark>"
                    + "<ServerReplyURL>" + ServerReplyURLEncode + "</ServerReplyURL>"
                + "</Data></Root>";

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            


            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", PaymentType);
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }


    }
}
