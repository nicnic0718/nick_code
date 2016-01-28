using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace AllPayWebServiceTest.Controllers
{
    public class CVSController : Controller
    {
        //
        // GET: /CVS/

        public ActionResult Index()
        {


            //long MerchantID = 1000070;   //測試機目前給企劃測試的特店id是1000070
            //string AllPayHashKey = "koyqVBURmmkQxROZ";        //開發 1000070 
            //string AllPayHashIV = "BcRITiCQaUHBZC1f";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";

            string AllPayHashKey = "ejCk326UnaZWKisg";
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;
            string PaymentType = "CVS_IBON";
            //超商代碼(FAMIPORT、OK、萊爾富)：CVS_CVS、超商代碼(7-11 ibon)：CVS_IBON、超商條碼：BARCODE_BARCODE、
            //設定MP的Post網址    
            string postURL = " http://pay-stage.allpay.com.tw/payment/Srv/gateway ";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int TradeAmount = 100;
            string TradeType = PaymentType;
            string TradeDesc =  HttpUtility.UrlEncode("0");
            string Desc_1 = HttpUtility.UrlEncode("0");
            string Desc_2 = HttpUtility.UrlEncode("0");
            string Desc_3 = HttpUtility.UrlEncode("0");
            string Desc_4 = HttpUtility.UrlEncode("0");
            string ReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string Remark = "xxx";







            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            + "<MerchantID>" + MerchantID + "</MerchantID>"
                            + "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>"
                            + "<MerchantTradeDate>" + MerchantTradeDate + "</MerchantTradeDate>"
                            + "<TradeAmount>" + TradeAmount + "</TradeAmount>"
                            + "<TradeType>" + TradeType + "</TradeType>"
                            + "<TradeDesc>" + TradeDesc + "</TradeDesc>"
                            + "<Desc_1>" + Desc_1 + "</Desc_1>"
                            + "<Desc_2>" + Desc_2 + "</Desc_2>"
                            + "<Desc_3>" + Desc_3 + "</Desc_3>"
                            + "<Desc_4>" + Desc_4 + "</Desc_4>"
                            + "<ReplyURL>" + ReplyURL + "</ReplyURL>"
                            + "<Remark>" + Remark + "</Remark>"
                + "</Data></Root>";

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

           // string gg = Convert.ToBase64String(Encoding.Default.GetBytes(xmlData));
           // string hh = Encoding.Default.GetString(Convert.FromBase64String("42ed30318e9658e1e87bd3104a89bf63"));

            //string ff = new AllPay.ShareLib.Crypt().AES_EnCrypt("A123456789012345", "B123456789012345", "NDJlZDMwMzE4ZTk2NThlMWU4N2JkMzEwNGE4OWJmNjM=");
             

            postCollection.Add("MerchantID", MerchantID.ToString());
            postCollection.Add("PaymentType", PaymentType);
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
