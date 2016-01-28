using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class CreditPeriodController : Controller
    {
        //
        // GET: /CreditPeriod/

        public ActionResult Index()
        {

            string AllPayHashKey = "ejCk326UnaZWKisg";
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;
            string PaymentType = "CREDIT_PERIOD";
            //設定MP的Post網址    
            string postURL = "http://pay-stage.allpay.com.tw/payment/gateway";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string PeriodAmount = "10";
            string PeriodType ="M";
            int Frequency =1;
            int ExecTimes=12;
            string TradeDesc = HttpUtility.UrlEncode("allapy123");
            string CardNo = "0";
            string CardValidMM = "0";
            string CardValidYY = "0";
            int CardCVV2 = 0;
            string CharSet = "utf-8";
            string Enn = "e";
            string BankOnly = "";
            string ReturnURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string ServerReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string ClientBackURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string PeriodReturnURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string Remark = HttpUtility.UrlEncode("xxx");







            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            + "<MerchantID>" + MerchantID + "</MerchantID>"
                            + "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>"
                            + "<MerchantTradeDate>" + MerchantTradeDate + "</MerchantTradeDate>"
                            + "<PeriodAmount>"+PeriodAmount+"</PeriodAmount>"
                            + "<PeriodType>"+PeriodType+"</PeriodType>"
                            + "<Frequency>"+ Frequency +"</Frequency>"
                            + "<ExecTimes>"+ExecTimes+"</ExecTimes>"
                            + "<TradeDesc>" + TradeDesc + "</TradeDesc>"
                            + "<CardNo>" + CardNo + "</CardNo>"
                            + "<CardValidMM>" + CardValidMM + "</CardValidMM>"
                            + "<CardValidYY>" + CardValidYY + "</CardValidYY>"
                            + "<CardCVV2>" + CardCVV2 + "</CardCVV2>"
                            + "<CharSet>" + CharSet + "</CharSet>"
                            + "<Enn>" + Enn + "</Enn>"
                            + "<BankOnly>" + BankOnly + "</BankOnly>"
                            + "<ReturnURL>" + ReturnURL + "</ReturnURL>"
                            + "<ServerReplyURL>" + ServerReplyURL + "</ServerReplyURL>"
                            + "<ClientBackURL>" + ClientBackURL + "</ClientBackURL>"
                            + "<PeriodReturnURL>"+PeriodReturnURL+"</PeriodReturnURL>"
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
