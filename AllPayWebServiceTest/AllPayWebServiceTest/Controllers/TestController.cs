using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            //string testHashKey = "5294y06JbISpM5x9";         //for 2000132
            //string testHashIv = "v77hoKGq4kWxNNIS";
            //string MerchantID = "2000132";
            //string TradePostUrl = "http://payment-stage.allpay.com.tw/Cashier/AIOCheckOut";

            string MerchantID = "1000070";
            string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            string testHashIv = "WkSfnqIaHLbUMV5X";
            string TradePostUrl = "http://devPayment.allpay.com.tw:12005/Cashier/AIOCheckOut";


            //add common para 

            string MerchantTradeNo = "2013111111111113";
            string MerchantTradeDate = "2013/11/11 11:11:11";
            string PaymentType = "aio";
            int TotalAmount = 1000;
            string TradeDesc = "Allpay商城購物";
            string ItemName = "手機20元X2#隨身碟60元X1";
            string ReturnURL = "http://localhost:53131/PayReturn.aspx";
            string ChoosePayment = "WebATM";      //Credit:信用卡 /WebATM:網路ATM /ATM:自動櫃員機 /CVS:超商代碼 /BARCODE:超商條碼 /Alipay: 支付寶 /Tenpay: 財付通 /TopUpUsed:儲值消費            

            
            //
            //可為空

            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("ChoosePayment", ChoosePayment);
            PostDictionary.Add("ItemName", ItemName);
            PostDictionary.Add("MerchantID", MerchantID);
            PostDictionary.Add("MerchantTradeDate", MerchantTradeDate);
            PostDictionary.Add("MerchantTradeNo", MerchantTradeNo);
            PostDictionary.Add("PaymentType", PaymentType);
            PostDictionary.Add("ReturnURL", ReturnURL);
            PostDictionary.Add("TotalAmount", TotalAmount.ToString());
            PostDictionary.Add("TradeDesc", TradeDesc);

            string strConn =  "ChoosePayment=" + ChoosePayment + "&" +
                              "ItemName=" + ItemName + "&" +
                              "MerchantID=" + MerchantID + "&" +
                              "MerchantTradeDate=" + MerchantTradeDate + "&" +
                              "MerchantTradeNo=" + MerchantTradeNo + "&" +
                              "PaymentType=" + PaymentType + "&" +
                              "ReturnURL=" + ReturnURL + "&" +
                              "TotalAmount=" + TotalAmount + "&" +
                              "TradeDesc=" + TradeDesc + "&";

           // string Tstr = "HashKey=5294y06JbISpM5x9&ChoosePayment=WebATM&ChooseSubPayment=2001&ClientBackURL=http://www.allpay.com.tw/Shopping/Detail&ItemName=手機20元X2#隨身碟60元X1&ItemURL=http://www.allpay.com.tw/&MerchantID=2000132&MerchantTradeDate=&MerchantTradeNo=&OrderResultURL=http://www.allpay.com.tw/&PaymentType=aio&Remark=http://www.allpay.com.tw/&ReturnURL=http://www.allpay.com.tw/receive.php&TotalAmount=1000&TradeDesc=Allpay商城購物&HashIV=v77hoKGq4kWxNNIS";

            string strPost = "HashKey=" + testHashKey + "&" + strConn + "HashIV=" + testHashIv;
            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();
           // 檢查碼要使用MD5加密
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);

            PostDictionary.Add("CheckMacValue", CheckMacValue);




            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = TradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
