using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace AllPayWebServiceTest.Controllers
{
    public class TestAIOController : Controller
    {
        //
        // GET: /TestAIO/
        public ActionResult index()
        {

            return new AllPay.ShareLib.js().ContentRunJavaScript("if(confirm(\"視窗內文字\")){alert(\"你按下確定\");}else{alert(\"你按下取消\");document.location.href=\"http://tw.yahoo.com\"}");
        }

        public ActionResult TestCheckOut()
        {
            //前後加上屬於自己的HashKey及HashIV

            string MerchantID = "2000132";        //STAGE    
            string testHashKey = "5294y06JbISpM5x9";         //for 2000132
            string testHashIv = "v77hoKGq4kWxNNIS";
            string TradePostUrl = "http://payment-stage.allpay.com.tw/Cashier/AioCheckOut";

            //string MerchantID = "1000070";
            //string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            //string testHashIv = "WkSfnqIaHLbUMV5X";
            //string TradePostUrl = "http://devPayment.allpay.com.tw:12005/Cashier/AIOCheckOut";

            //string MerchantID = "1024874";
            //string testHashKey = "v5vsY0wly3AT9kcB";         //for cloud
            //string testHashIv = "Zg2b9pDj8i9AlZPj";
            ////string postURL = "https://pay.allpay.com.tw/payment/gateway";
            //string TradePostUrl = "https://payment.allpay.com.tw/Cashier/AioCheckOut";

            //string MerchantID = "1037474";
            //string testHashKey = "Fiza8IAh0ra9iVLk";         //for cloud
            //string testHashIv = "IzYipJ8q0IVRpAE2";
            ////string postURL = "https://pay.allpay.com.tw/payment/gateway";
            //string TradePostUrl = "https://payment.allpay.com.tw/Cashier/AioCheckOut";


            //add common para 
            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string PaymentType = "aio";
            int TotalAmount = 3;
            string TradeDesc = "[test]";
            string ItemName = "AllpayTest";
            string ReturnURL = "http://tw.yahoo.com";
            string ChoosePayment = "ALL";      //Credit:信用卡 /WebATM:網路ATM /ATM:自動櫃員機 /CVS:超商代碼 /BARCODE:超商條碼 /Alipay: 支付寶 /Tenpay: 財付通 /TopUpUsed:儲值消費            
            string CheckMacValue = "";
            string NeedExtraPaidInfo = "N";
            string DeviceSource = "P";
            string PaymentInfoURL = "http://tw.yahoo.com";

            //
               int ExpireDate = 7;
            string Desc_1 = "交易描述1";
            string Desc_2 = "交易描述2";
            string Desc_3 = "交易描述3";
            string Desc_4 = "交易描述4";
            string AlipayItemName = "手機";
            string AlipayItemCounts = "1";
            string AlipayItemPrice = "3";
            string Email = "cloud.chen@allpay.com.tw";
            string PhoneNo = "0900000000";
            string UserName = "Cloud";
            string ExpireTime = "";
            //
            //可為空
            string ClientBackURL = "";
            string ItemURL = "";
            string Remark = "";
            string ChooseSubPayment = "";
            string OrderResultURL = "";
            //信用卡
            int CreditInstallment = 3;
            int InstallmentAmount = 3;
            string Redeem = "";

            //信用卡定期定額
            int PeriodAmount = 0;//非0執行定期定額$3
            string PeriodType = "D";
            int Frequency = 1;
            int ExecTimes = 3;
            string PeriodReturnURL = "";


            SortedDictionary<string, string> PostDictionary = new SortedDictionary<string, string>();
            PostDictionary.Add("ChoosePayment", ChoosePayment);
            PostDictionary.Add("ChooseSubPayment", ChooseSubPayment);
            PostDictionary.Add("ItemName", ItemName);
            PostDictionary.Add("MerchantID", MerchantID);
            PostDictionary.Add("MerchantTradeDate", MerchantTradeDate);
            PostDictionary.Add("MerchantTradeNo", MerchantTradeNo);
            PostDictionary.Add("PaymentType", PaymentType);
            PostDictionary.Add("ReturnURL", ReturnURL);
            PostDictionary.Add("TotalAmount", TotalAmount.ToString());
            PostDictionary.Add("TradeDesc", TradeDesc);
            PostDictionary.Add("ClientBackURL", ClientBackURL);
            PostDictionary.Add("ItemURL", ItemURL);
            PostDictionary.Add("Remark", Remark);
            PostDictionary.Add("OrderResultURL", OrderResultURL);
            PostDictionary.Add("NeedExtraPaidInfo", NeedExtraPaidInfo);
            PostDictionary.Add("DeviceSource", DeviceSource);


            string strConn = "";
            switch (ChoosePayment)
            {
                case "WebATM":
                    break;

                case "ATM":

                    PostDictionary.Add("ExpireDate", ExpireDate.ToString());
                    PostDictionary.Add("PaymentInfoURL", PaymentInfoURL);

                    break;

                case "CVS":

                    PostDictionary.Add("Desc_1", Desc_1);
                    PostDictionary.Add("Desc_2", Desc_2);
                    PostDictionary.Add("Desc_3", Desc_3);
                    PostDictionary.Add("Desc_4", Desc_4);
                    PostDictionary.Add("PaymentInfoURL", PaymentInfoURL);
                    break;

                case "BARCODE":

                    PostDictionary.Add("Desc_1", Desc_1);
                    PostDictionary.Add("Desc_2", Desc_2);
                    PostDictionary.Add("Desc_3", Desc_3);
                    PostDictionary.Add("Desc_4", Desc_4);
                    PostDictionary.Add("PaymentInfoURL", PaymentInfoURL);

                    break;
                case "Alipay":

                    PostDictionary.Add("AlipayItemCounts", AlipayItemCounts);
                    PostDictionary.Add("AlipayItemName", AlipayItemName);
                    PostDictionary.Add("AlipayItemPrice", AlipayItemPrice);
                    PostDictionary.Add("Email", Email);
                    PostDictionary.Add("PhoneNo", PhoneNo);
                    PostDictionary.Add("UserName", UserName);
                    //PostDictionary.Remove("ItemName");

                    break;
                case "Tenpay":

                    PostDictionary.Add("ExpireTime", ExpireTime);

                    break;
                case "Credit":


                        PostDictionary.Add("CreditInstallment", CreditInstallment.ToString());
                        PostDictionary.Add("InstallmentAmount", InstallmentAmount.ToString());
                        PostDictionary.Add("Redeem", Redeem);

                        if (PeriodAmount != 0)
                        {
                            PostDictionary.Add("PeriodAmount", PeriodAmount.ToString());
                            PostDictionary.Add("PeriodType", PeriodType);
                            PostDictionary.Add("Frequency", Frequency.ToString());
                            PostDictionary.Add("ExecTimes", ExecTimes.ToString());
                            PostDictionary.Add("PeriodReturnURL", PeriodReturnURL);
                            PostDictionary.Remove("CreditInstallment");
                            PostDictionary.Remove("InstallmentAmount");
                            PostDictionary.Remove("Redeem");
                        }
                    break;
                case "ALL":
                                        PostDictionary.Add("AlipayItemCounts", AlipayItemCounts);
                    PostDictionary.Add("AlipayItemName", AlipayItemName);
                    PostDictionary.Add("AlipayItemPrice", AlipayItemPrice);
                    PostDictionary.Add("Email", Email);
                    PostDictionary.Add("PhoneNo", PhoneNo);
                    PostDictionary.Add("UserName", UserName);
                    //PostDictionary.Remove("ItemName");
                    break;

            }

            strConn = string.Join("&", PostDictionary.Select(p => p.Key + "=" + p.Value));


            string strPost = "HashKey=" + testHashKey + "&" + strConn + "&" + "HashIV=" + testHashIv;
            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();
            
            //檢查碼要使用MD5加密
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(lowerUrlEncodeStrPost));
            StringBuilder sBuilder = new StringBuilder();
            for(int i =0 ; i<data.Length;i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            
            CheckMacValue = sBuilder.ToString();



            PostDictionary.Add("CheckMacValue", CheckMacValue);


            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<html><body>").AppendLine();
            sb.Append("<form name='allpaywebatm'  id='allpaywebatm' action='" + TradePostUrl + "' method='POST'>").AppendLine();
            foreach (var test in PostDictionary)
            {
                sb.Append("<input type='hidden' name='" + test.Key + "' value='" + test.Value + "'>").AppendLine();
            }
            sb.Append("</form>").AppendLine();
            sb.Append("<script> var theForm = document.forms['allpaywebatm'];  if (!theForm) { theForm = document.allpaywebatm; } theForm.submit(); </script>").AppendLine();
            sb.Append("<html><body>").AppendLine();

            Response.Write(sb.ToString());
            Response.End();



            //設定要送到MP的資料
            //TempData["PostCollection"] = PostDictionary;
            //TempData["PostURL"] = TradePostUrl;

            ////將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            //return RedirectToAction("AutoSubmitForm", "Common");
            return View();
        }

    }

    
}
