using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class CreditActionController : Controller
    {
        //
        // GET: /CreditActuon/

        public ActionResult Index()
        {
            string AllPayHashKey = "ejCk326UnaZWKisg";
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;

            //設定MP的Post網址    
            string postURL = "http://pay-stage.allpay.com.tw/CreditDetail/DoAction";

            string MerchantTradeNo = "123456789";
            string TradeNo = "201203151740582564";
            string TotalAmount = "22000";
            string Action = "C";






            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            + "<MerchantID>" + MerchantID + "</MerchantID>"
                            + "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>"
                            + "<TradeNo>" + TradeNo + "</TradeNo>"
                            + "<Action>" + Action + "</Action>"
                            + "<TotalAmount>" +TotalAmount+ "</TotalAmount>" 
                + "</Data></Root>";



            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);




            postCollection.Add("MerchantID", MerchantID.ToString());
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
