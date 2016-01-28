using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class AlipayController : Controller
    {
        //
        // GET: /Alipay/

        public ActionResult Index()
        {
            //string AllPayHashKey = "ejCk326UnaZWKisg";
            //string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            //long MerchantID = 2000132;
            string PaymentType = "ALIPAY";
            //設定MP的Post網址    
            //string postURL = "http://pay-stage.allpay.com.tw/payment/gateway";

            string MerchantID = "1032561";
            string AllPayHashKey = "CE6QNgYj6wBwWZPl";         //for cloud
            string AllPayHashIV = "7WfJoPLXJI79cWMS";
            string postURL = "https://pay.allpay.com.tw/payment/gateway";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string TradeAmount = "181";
            string ItemName = HttpUtility.UrlEncode("微笑寶貝#運費");
            string ItemCounts = "1#1";
            string ItemPrice = "1#180";
            string ServerReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/atm/success.aspx");
            string ClientReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/atm/success.aspx");
            string Remark = HttpUtility.UrlEncode("xxx");
            string Email = "cloud.chen@allpay.com.tw";
            string PhoneNo = "0912345678";
            string UserName = "Cloud";


            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            + "<MerchantID>" + MerchantID + "</MerchantID>"
                            + "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>"
                            + "<MerchantTradeDate>" + MerchantTradeDate + "</MerchantTradeDate>"
                            + "<TradeAmount>" + TradeAmount + "</TradeAmount>"
                            + "<ItemName>" + ItemName + "</ItemName>"
                            + "<ItemCounts>"+ItemCounts+"</ItemCounts>"
                            + "<ItemPrice>"+ItemPrice+"</ItemPrice>"
                            + "<ServerReplyURL>" + ServerReplyURL + "</ServerReplyURL>"
                            + "<ClientReplyURL>" + ClientReplyURL + "</ClientReplyURL>"
                            + "<Remark>" + Remark + "</Remark>"
                            + "<Email>"+Email+"</Email>"
                            + "<PhoneNo>"+PhoneNo+"</PhoneNo>"
                            + "<UserName>"+UserName+"</UserName>"
                + "</Data></Root>";

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);




            postCollection.Add("MerchantID", MerchantID.ToString());
            postCollection.Add("PaymentType", PaymentType);
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
