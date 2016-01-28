using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPayWebServiceTest.Controllers
{
    public class CreditController : Controller
    {
        //
        // GET: /Credit/

        public ActionResult Index()
        {

            //string MerchantID = "1037844";
            //string AllPayHashKey = "Fu9auJ7hVwdWBGYc";
            //string AllPayHashIV = "EZK0I3tTdy5j3M5g";
            //string postURL = "https://pay.allpay.com.tw/payment/gateway";
            ////string TradePostUrl = "https://payment.allpay.com.tw/Cashier/AioCheckOut";

            string AllPayHashKey = "ejCk326UnaZWKisg";
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;
            string PaymentType = "CREDIT";
            //設定MP的Post網址    
            string postURL = "http://pay-stage.allpay.com.tw/payment/gateway";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string TotalAmount="1";
            string TradeDesc = "allapyTest";
            string CardNo = "0";
            string CardValidMM = "0";
            string CardValidYY = "0";
            int CardCVV2 = 0;
            int UnionPay = 0;
            int installment = 0;
            int ThreeD =0;
            string CharSet= "utf-8";
            string Enn ="";
            string BankOnly ="";
            string Redeem ="";
            string ReturnURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string ServerReplyURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string ClientBackURL = HttpUtility.UrlEncode("http://www.allpay.com.tw/");
            string Remark = "";

            
       




            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                            +"<MerchantID>"+MerchantID+"</MerchantID>"
                            +"<MerchantTradeNo>"+MerchantTradeNo+"</MerchantTradeNo>"
                            +"<MerchantTradeDate>"+MerchantTradeDate+"</MerchantTradeDate>"
                            +"<TotalAmount>"+TotalAmount+"</TotalAmount>"
                            +"<TradeDesc>"+TradeDesc+"</TradeDesc>"
                            +"<CardNo>"+CardNo+"</CardNo>"
                            +"<CardValidMM>"+CardValidMM+"</CardValidMM>"
                            +"<CardValidYY>"+CardValidYY+"</CardValidYY>"
                            +"<CardCVV2>"+CardCVV2+"</CardCVV2>"
                            +"<UnionPay>"+UnionPay+"</UnionPay>"
                            +"<Installment>"+installment+"</Installment>"
                            +"<ThreeD>"+ThreeD+"</ThreeD>"
                            +"<CharSet>"+CharSet+"</CharSet>"
                            +"<Enn>"+Enn+"</Enn>"
                            +"<BankOnly>"+BankOnly+"</BankOnly>"
                            +"<Redeem>"+Redeem+"</Redeem>"
                            +"<ReturnURL>"+ReturnURL+"</ReturnURL>"
                            +"<ServerReplyURL>"+ServerReplyURL+"</ServerReplyURL>"
                            +"<ClientBackURL>"+ClientBackURL+"</ClientBackURL>"
                            +"<Remark>"+Remark+"</Remark>"
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

        public ActionResult CreateCreditCardTradeToPaymentCenter(string totalAmount = "10", string env = "", string enn = "")
        {
            string AllPayHashKey = "";
            string AllPayHashIV = "";
            long AllPayMerchantID = 0;
            string postURL = "";


            //dev
            /*
             AllPayHashKey = "koyqVBURmmkQxROZ";
             AllPayHashIV = "BcRITiCQaUHBZC1f";
                          
             AllPayMerchantID = 1000070;
            */

            AllPayHashKey = "8kKi3AqacfeJmh1l";
            AllPayHashIV = "kjzsd3cj5jLGoBJt";

            AllPayMerchantID = 1000475; //dev有風管

            //設定MP的Post網址    
            postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";


            if ("beta".Equals(env))
            {
                //### beta有風管

                AllPayHashKey = "Q6Dp6zkC3eJ7Mj52";
                AllPayHashIV = "jpLuRMHTyv5FSYss";
                AllPayMerchantID = 1000404;
                //設定MP的Post網址    
                postURL = "http://pay-beta.allpay.com.tw/Payment/Gateway";

                /*
                AllPayHashKey = "Zf1AjVRlwE4XjlF9";
                AllPayHashIV = "Ps8hPWGtUW0PE3Gk";
                AllPayMerchantID = 1000139;
                //設定MP的Post網址    
                postURL = "http://pay-beta.allpay.com.tw/Payment/Gateway";
                */
            }



            else if ("stage".Equals(env))
            {

                AllPayHashKey = "5294y06JbISpM5x9";
                AllPayHashIV = "v77hoKGq4kWxNNIS";
                AllPayMerchantID = 1000006;


                //設定MP的Post網址                        
                postURL = "http://pay-stage.allpay.com.tw/Payment/Gateway";
            }


            //totalAmount = (string.IsNullOrEmpty(totalAmount)) ? "50" : totalAmount;
            //string totalAmount = "11000";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");



            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TotalAmount>" + totalAmount + "</TotalAmount>"
                + "<TradeDesc>%e8%a8%82%e5%96%ae%e6%8f%8f%e8%bf%b0-MacBook+Air</TradeDesc>"

                //有帶卡號
                /*
                + "<CardNo>4311952222222222</CardNo>"
                + "<CardValidMM>11</CardValidMM>"
                + "<CardValidYY>11</CardValidYY>"
                + "<CardCVV2>123</CardCVV2>"
                */
                //沒帶卡號

                + "<CardNo>0</CardNo>"
                + "<CardValidMM>0</CardValidMM>"
                + "<CardValidYY>0</CardValidYY>"
                + "<CardCVV2>0</CardCVV2>"

                + "<UnionPay>0</UnionPay>"
                + "<Installment>0</Installment>"
                + "<ThreeD>0</ThreeD>"
                + "<CharSet>utf-8</CharSet>"
                + "<Enn>" + enn + "</Enn>"
                + "<BankOnly></BankOnly>"
                + "<Redeem></Redeem>"
                + "<ReturnURL>" + HttpUtility.UrlEncode("http://mockMerchant-beta.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ReturnURL>"
                //+ "<ReturnURL></ReturnURL>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-beta.allpay.com.tw/AllPayPayment/ReceiveBackUrlResult") + "</ServerReplyURL>"

                + "<ClientBackURL>" + HttpUtility.UrlEncode("http://www.allpay.com.tw") + "</ClientBackURL>"
                //+ "<ClientBackURL></ClientBackURL>"
                + "<Remark>;Test" + orderTradeNo + "</Remark>"  // dev
                //+ "<Remark>" + merchantID + ";Test" + orderTradeNo + "</Remark>" // beta

                + "</Data></Root>";


            /*
              + "<ReturnURL>" + HttpUtility.UrlEncode("http://mockMerchant-beta.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ReturnURL>"
                //+ "<ReturnURL></ReturnURL>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-beta.allpay.com.tw/AllPayPayment/ReceiveBackUrlResult") + "</ServerReplyURL>"

                + "<ClientBackURL>" + HttpUtility.UrlEncode("http://www.allpay.com.tw") + "</ClientBackURL>"             
             */



            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "CREDIT");
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }



    }
}
