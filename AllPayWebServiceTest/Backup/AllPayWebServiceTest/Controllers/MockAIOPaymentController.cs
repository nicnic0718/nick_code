using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class MockAIOPaymentController : BaseController
    {
        //
        // GET: /MockAIOPayment/

        public ActionResult TestCheckOut()
        {
            //前後加上屬於自己的HashKey及HashIV
            //string HashKey = "koyqVBURmmkQxROZ", HashIV = "BcRITiCQaUHBZC1f";
            string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            string testHashIv = "WkSfnqIaHLbUMV5X";

            string MerchantID = "1000070";        //dev    
            string TradePostUrl = "http://devpayment.allpay.com.tw:12005/Cashier/AioCheckOut";

            //add common para 
            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string PaymentType = "aio";
            int TotalAmount = 100;
            string TradeDesc = "Allpay商城購物-";
            string ItemName = "手機20元X2#隨身碟60元X1";
            //
            int ExpireDate = 7;
            string Desc_1 = "交易描述1"; 
            string Desc_2 = "交易描述2";
            string Desc_3 = "交易描述3";
            string Desc_4 = "交易描述4";
            string AlipayItemName = "手機#隨身碟";
            string AlipayItemCounts = "2#1";
            string AlipayItemPrice = "20#60";
            string Email = "xxxx@xxxx.com.tw";
            string PhoneNo ="0912345678";
            string UserName = "XXX";
            string ExpireTime = "";


            //

            string ChoosePayment = "WebATM";      //Credit:信用卡 /WebATM:網路ATM /ATM:自動櫃員機 /CVS:超商代碼 /BARCODE:超商條碼 /Alipay: 支付寶 /Tenpay: 財付通 /TopUpUsed:儲值消費
            

            string ReturnURL = "http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/TestReceivePayResult";
            //string ClientBackURL = "";


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



            string strConn = "";
            switch (ChoosePayment)
            {
                case "WebATM":

                    
                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "ItemName=" + ItemName + "&" + "MerchantID=" + MerchantID + "&" + 
                                  "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +
                                     "PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";
                    break;

                case "ATM":

                    
                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "ExpireDate=" + ExpireDate + "&" + "ItemName=" + ItemName + "&" + "MerchantID=" + MerchantID + "&" + 
                                    "MerchantTradeDate=" + MerchantTradeDate + "&" + 
                                       "MerchantTradeNo=" + MerchantTradeNo + "&" +"PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";

                    PostDictionary.Add("ExpireDate", ExpireDate.ToString());

                    break;

                case "CVS":


                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "Desc_1=" + Desc_1 + "&" + "Desc_2=" + Desc_2 + "&" + "Desc_3=" + Desc_3 + "&" + "Desc_4=" + Desc_4 + "&" + "ItemName=" + ItemName + "&" +
                                    "MerchantID=" + MerchantID + "&" + "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +"PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + 
                                        "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";
                    PostDictionary.Add("Desc_1", Desc_1);
                    PostDictionary.Add("Desc_2", Desc_2);
                    PostDictionary.Add("Desc_3", Desc_3);
                    PostDictionary.Add("Desc_4", Desc_4);

                    break;

                case "BARCODE":


                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "Desc_1=" + Desc_1 + "&" + "Desc_2=" + Desc_2 + "&" + "Desc_3=" + Desc_3 + "&" + "Desc_4=" + Desc_4 + "&" + "ItemName=" + ItemName + "&" +
                                    "MerchantID=" + MerchantID + "&" + "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +"PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + 
                                        "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";
                    PostDictionary.Add("Desc_1", Desc_1);
                    PostDictionary.Add("Desc_2", Desc_2);
                    PostDictionary.Add("Desc_3", Desc_3);
                    PostDictionary.Add("Desc_4", Desc_4);

                    break;
                case "Alipay":

                    strConn = "AlipayItemCounts=" + AlipayItemCounts + "&" + "AlipayItemName=" + AlipayItemName + "&" + "AlipayItemPrice=" + AlipayItemPrice + "&" + "ChoosePayment=" + ChoosePayment + "&" + "Email=" + Email + "&" +  
                                   "ItemName=" + ItemName + "&" + "MerchantID=" + MerchantID + "&" + "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +"PaymentType=" + PaymentType + "&" + 
                                        "PhoneNo=" + PhoneNo + "&" + "ReturnURL=" + ReturnURL + "&" + "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&" + "UserName=" + UserName + "&";

                    PostDictionary.Add("AlipayItemCounts", AlipayItemCounts);
                    PostDictionary.Add("AlipayItemName", AlipayItemName);
                    PostDictionary.Add("AlipayItemPrice", AlipayItemPrice);
                    PostDictionary.Add("Email",Email);
                    PostDictionary.Add("PhoneNo",PhoneNo);
                    PostDictionary.Add("UserName", UserName);
                    PostDictionary.Remove(ItemName);
                   
                    break;
                case "Tenpay":
                   
                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "ItemName=" + ItemName + "&" + "MerchantID=" + MerchantID + "&" + "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +
                                     "PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";
                    break;
                case "Credit":
                   
                    strConn = "ChoosePayment=" + ChoosePayment + "&" + "ItemName=" + ItemName + "&" + "MerchantID=" + MerchantID + "&" + "MerchantTradeDate=" + MerchantTradeDate + "&" + "MerchantTradeNo=" + MerchantTradeNo + "&" +
                                     "PaymentType=" + PaymentType + "&" + "ReturnURL=" + ReturnURL + "&" + "TotalAmount=" + TotalAmount + "&" + "TradeDesc=" + TradeDesc + "&";
                    break;

            }



            string strPost = "HashKey=" + testHashKey + "&" + strConn + "HashIV=" + testHashIv;
            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();
            //檢查碼要使用MD5加密
            string  CheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);
           
            PostDictionary.Add("CheckMacValue", CheckMacValue);      
  



            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = TradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
