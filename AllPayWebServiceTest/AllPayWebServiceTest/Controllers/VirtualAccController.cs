using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class VirtualAccController : Controller
    {
        //
        // GET: /VirtualAcc/

        public ActionResult Index()
        {

            //string MerchantID = "1032561";
            //string AllPayHashKey = "CE6QNgYj6wBwWZPl";         //for cloud
            //string AllPayHashIV = "7WfJoPLXJI79cWMS";
            //string postURL = "https://pay.allpay.com.tw/payment/Srv/gateway";


            string AllPayHashKey = "ejCk326UnaZWKisg";
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;
            string postURL = "http://pay-stage.allpay.com.tw/payment/Srv/gateway";
            string PaymentType = "vAccount";
            //超商代碼(FAMIPORT、OK、萊爾富)：CVS_CVS、超商代碼(7-11 ibon)：CVS_IBON、超商條碼：BARCODE_BARCODE、
            //設定MP的Post網址    


            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int TradeAmount = 100;
            string ExpireDate = "3";
            string TradeDesc = HttpUtility.UrlEncode("0");
            string BankName = "ALL";
            string ReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string Remark = "xxx";







            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            + "<MerchantID>" + MerchantID + "</MerchantID>"
                            + "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>"
                            + "<MerchantTradeDate>" + MerchantTradeDate + "</MerchantTradeDate>"
                            + "<TradeAmount>" + TradeAmount + "</TradeAmount>"
                            + "<ExpireDate>" + ExpireDate + "</ExpireDate>"
                            + "<BankName>" + BankName + "</BankName>"
                            + "<ReplyURL>" + ReplyURL + "</ReplyURL>"
                            + "<Remark>" + Remark + "</Remark>"
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
