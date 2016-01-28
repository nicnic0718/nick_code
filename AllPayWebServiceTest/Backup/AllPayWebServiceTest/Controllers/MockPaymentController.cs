using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Xml;
using AllPayWebServiceTest.Models.ViewModel;
using Newtonsoft.Json;

namespace AllPayWebServiceTest.Controllers
{
    [AllPayMockMethod]
    public class MockPaymentController : BaseController
    {

        private string currentEnv = "prod";    //dev、stage、prod

        string prodHashKey = "";         //for prod 888891
        string prodHashIv = "";

        //string devHashKey = "fugvqTnG3ROx81MO";        //開發 999999999
        //string devHashIv = "WkSfnqIaHLbUMV5X";

        string devHashKey = "koyqVBURmmkQxROZ";        //開發 1000070 
        string devHashIv = "BcRITiCQaUHBZC1f";

        string betaHashKey = "Zf1AjVRlwE4XjlF9";        //for beta 1000039
        string betaHashIv = "Ps8hPWGtUW0PE3Gk";

        //string stageHashKey = "Zf1AjVRlwE4XjlF9";        //for stage 888891 
        //string stageHashIv = "Ps8hPWGtUW0PE3Gk";

        string stageHashKey = "ejCk326UnaZWKisg";        //for stage 2000132  
        string stageHashIv = "q9jcZX8Ib9LM8wYk";

        string hashKey = "";
        string hashIv = "";

        //
        // GET: /MockPayment/

        public ActionResult Index()
        {
            
            //### 建立KeyCrypt物件
            AllPay.ShareLib.KeyCrypt _keyCrypt = new AllPay.ShareLib.KeyCrypt();

            string deHashKey = _keyCrypt.DeCrypt("U61Dp2UxllJxYTyvq00xe0rhSIc/i2qVvTtLYwiny3f=");
            string deHashIV = _keyCrypt.DeCrypt("YP/phIyry/qEcPg2uqKkiHkk1Z747MVHJmE5/V3Uy64=");

            string enHashKey = _keyCrypt.EnCrypt("wWqsaMYYWgVZkWYn");
            string enHashIV = _keyCrypt.EnCrypt("vEwoJCs04n6ta9DZ");

            string merchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string cvsXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>2000132</MerchantID><MerchantTradeNo>138310514400643</MerchantTradeNo><MerchantTradeDate>2013/10/30 11:52:25</MerchantTradeDate><TradeAmount>100</TradeAmount><ExpireTime>2013/10/31 11:52:25</ExpireTime><ServerReplyURL>https%3A%2F%2Fgate.pepay.com.tw%2Fpepay%2Fpaysys%2Fallpay%2Frcv.php</ServerReplyURL><ClientReplyURL>https%3A%2F%2Fgate.pepay.com.tw%2Fpepay%2Fpaysys%2Fallpay%2Frtn.php</ClientReplyURL><Remark></Remark></Data></Root>";
            string encryptString = new AllPay.ShareLib.Crypt().AES_EnCrypt("ejCk326UnaZWKisg", "q9jcZX8Ib9LM8wYk", cvsXml);

            string encryptXml = "XeMYbI2/9Z1p4Xj3XHf96OeHkKBIj5iKGUCZ8OTBo57/DxPzItfiCApy6cywurnWOkvh/8f0varOy/5hlZ3gVD7aAgklGeFhONCAqcdRwORAS1ZCmv14tN141PZc2UkdsOrMiLeYxeLG2jD8NQcPz4Sj+xJRMzASSvtiatPnjqXgP8OpgRlsp/LmdRcKwzMCFCi0JQbbnqaaaKHgbsKffLrVQXU9hhAyzQHSJ1nEzKMxG470fkzE44DJC6/pPvhs0OJCxWxz5tSARYhgGkn8iubpWktloaQXdgWUC2ntEdGcrxiW4ww6GUM+tiZtWnOId5gfSFAu+b35Owewy9TwZmgM9lvPLJRFhacNXpy0qODdt5XOYUHwn69R/avYKevyDfjhbbB/6XlzhjsReAJrmZWB/l3NDWRRjdQWMBoDtvAX74ugqHEpWspQpp8clCjdSJjNjeI2QJiuvyfo9HxZZtsJ4tL4JZzdRlLzc8fYND3EJm5PUNxUHwuAxfDoGiy3tNPE0ytn4FuqHthjNBlb2N89d9W/Iqr7d97TkHdYfWNtCecXFQUkWjLD56gpWBThyirvcn1P/5peDDWo5/vpHsQWvemSyYZ5X4lr7GETeaU4kSDqaUjw+k3va8PJVrirAMGQw5ajGECtqyd3pA2Vfd1JmPFZNFdSiZjspJYJK4Rq3Af8C3IdqHmuv57k9GQZ";
            encryptXml = encryptXml.Replace(' ', '+');
            string xml = new AllPay.ShareLib.Crypt().AES_DeCrypt("ejCk326UnaZWKisg", "q9jcZX8Ib9LM8wYk", encryptXml);

            string testString = "AllPayTest";
            //string encryptString = new AllPay.ShareLib.Crypt().AES_EnCrypt("A123456789012345", "B123456789012345", testString);

            string decryptString = new AllPay.ShareLib.Crypt().AES_DeCrypt("A123456789012345", "B123456789012345", encryptString);

            string urlEncodeString = HttpUtility.UrlEncode("_");

            return View();
        }

        public ActionResult FrameIndex() {

            return View();
        }

        public ActionResult FrameButtom() 
        {
            return View();
        }

        #region 送出資料到PaymentCenter

        /// <summary>
        /// 建立Web ATM的訂單
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateWebAtmTradeToPaymentCenter() {

            string AllPayHashKey = devHashKey;
            string AllPayHashIV = devHashIv;
            long AllPayMerchantID = 1000070;

            //string AllPayHashKey = "fugvqTnG3ROx81MO";  //開發機:999999999
            //string AllPayHashIV = "WkSfnqIaHLbUMV5X";
            //long AllPayMerchantID = 999999999;

            //string AllPayHashKey = stageHashKey;
            //string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 2000132;    //2000132:stage的測試店家 

            //long AllPayMerchantID = 1018778;   
            string totalAmount = "30";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");


            //設定MP的Post網址                        
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";
            //string postURL = "http://pay-stage.allpay.com.tw/Payment/Gateway";
            string postURL = "https://pay.allpay.com.tw/Payment/Gateway";

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TotalAmount>" + totalAmount + "</TotalAmount>"
                + "<TradeDesc>%e8%a8%82%e5%96%ae%e6%8f%8f%e8%bf%b0-MacBook+Air</TradeDesc>"
                + "<TradeCategory>1</TradeCategory>"
                + "<BankName>CATHAY</BankName>"
                + "<CharSet>utf-8</CharSet>"
                + "<ReplyURL>" + HttpUtility.UrlEncode("http://pay-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"
                //+ "<ReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"

                + "<BackURL>" + HttpUtility.UrlEncode("http://pay-stage.allpay.com.tw/MockMerchant/ReceiveBackUrlResult") + "</BackURL>"                
                //+ "<BackURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</BackURL>"

                + "<Remark>%e4%b8%80%e8%88%ac%e5%95%86%e5%93%81%e6%b8%ac%e8%a9%a6-DEV</Remark>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://pay-stage.allpay.com.tw/MockMerchant/ReceiveBackUrlResult") + "</ServerReplyURL>"
                //+ "<ServerReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ServerReplyURL>"

                + "</Data></Root>";

            
            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            
            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);           

            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "WEB_ATM");
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        
        }

        //模擬payment傳送CVS訂單資料到payment center
        public ActionResult TestCvsToPaymentCenter()
        {
            string AllPayHashKey = devHashKey;
            string AllPayHashIV = devHashIv;
            long AllPayMerchantID = 1000070;
            //long AllPayMerchantID = 999999999;
            string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Srv/Gateway";

            //string AllPayHashKey = stageHashKey;
            //string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 2000132;    //2000132:stage的測試店家       
            ////設定MP的Post網址                        
            //string postURL = "http://pay-stage.allpay.com.tw/Payment/Srv/Gateway";


            string totalAmount = "50";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string paymentType = "BARCODE_BARCODE";  // "CVS_CVS";  // "BARCODE_BARCODE";
                        

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"                
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TradeAmount>" + totalAmount + "</TradeAmount>"
                + "<TradeType>" + paymentType + "</TradeType>"
                + "<TradeDesc>allpay-test</TradeDesc>"
                + "<Desc_1>10</Desc_1>"
                + "<Desc_2>10</Desc_2>"
                + "<Desc_3>10</Desc_3>"
                + "<Desc_4>10</Desc_4>"
                //+ "<ReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"
                + "<ReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"

                + "<Remark>%e4%b8%80%e8%88%ac%e5%95%86%e5%93%81%e6%b8%ac%e8%a9%a6-DEV</Remark>"                
                + "</Data></Root>";
                       
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", paymentType);
       
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);
                       

            postCollection.Add("XMLData", xmlData);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Srv/Gateway";
          
            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);

            ViewBag.ServerResponse = ServerResponse;          

            return View();

        }


        //模擬查詢超商條碼的資料到payment center
        public ActionResult TestCvsQueryBarcodeToPaymentCenter()
        {

            string AllPayHashKey = "ejCk326UnaZWKisg";         //for stage 2000132
            string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            long AllPayMerchantID = 2000132;
            string MerchantTradeNo = "201309141807";


            
            //設定MP的Post網址                        
            string postURL = "http://pay-stage.allpay.com.tw/barcode/getbarcode";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/barcode/getbarcode";
            //string postURL = "https://pay.allpay.com.tw/barcode/getbarcode";

            string AesMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, MerchantTradeNo);

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("MerchantTradeNo", AesMerchantTradeNo);

            



            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);

            ViewBag.ServerResponse = ServerResponse;

            return View();

        }

                
        /// <summary>
        /// 模擬傳送ATM訂單資料到payment center
        /// </summary>
        /// <returns></returns>
        public ActionResult TestAtmToPaymentCenter()
        {

            //string AllPayHashKey = devHashKey;
            //string AllPayHashIV = devHashIv;
            //long AllPayMerchantID = 1000070;
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Srv/Gateway";

            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 999999999; 
            long AllPayMerchantID = 2000132;    //2000132:stage的測試店家                       
            string postURL = "http://pay-stage.allpay.com.tw/Payment/Srv/Gateway";

            
                       
            string totalAmount = "35";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string expireDate = "2";

            

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TradeAmount>" + totalAmount + "</TradeAmount>"
                + "<ExpireDate>" + expireDate + "</ExpireDate>"
                + "<BankName>TAISHIN</BankName>"               
                //+ "<ReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"
                + "<ReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ReplyURL>"
                + "<Remark>%e4%b8%80%e8%88%ac%e5%95%86%e5%93%81%e6%b8%ac%e8%a9%a6-DEV</Remark>"
                + "</Data></Root>";

           
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "vAccount");

            //tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Root><Data><MerchantID>2000132</MerchantID><MerchantTradeNo>test2013110811</MerchantTradeNo><MerchantTradeDate>2013/11/08 15:46:52</MerchantTradeDate> <TradeAmount>30000</TradeAmount><ExpireDate>3</ExpireDate><BankName>TAISHIN</BankName><ReplyURL>http://latebird.tw.59.127.35.26.xip.io/api/allpay_notify.json</ReplyURL><Remark/></Data></Root>";

            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            //xmlData = "H266LJHL3XdawK5JprWAWFe1tkLrGB1WBKaiiYcNP74vWmkudvM4k3iaVpN+IU5EKvgQDht4wWj6iSPUPJoFb6HwjZFXUsWDOFnG71XUiT6sAWRR9f/EAq+/k9U5BsJnFlDN+lBfYzJuNEIihbuZQTZmvmLbR41D6lQEBuw1VGHz77jGWhTQuRK4EuVfq6ltnuSMl+FpP9R51sdmTrQLENkeUvMqTiY5vFVBPDmT/a0m0CqN638oXWYTiaL31punwnxa4A649L8uigqFFmd+tnGKB1K0mtIsO5q6camVKWPE1lNJp2D4P7zQqALe3U2+MsrZpGfeOwI/zkE3CwHYgP9YxvXcwTL1kQ6wi1h+1Y52wCh62MaxD5GBplzDPAq9RGGdqxjrKy0+UYgbpZ57IBrhMUnFCfpK+23HvPjTpUZskyzggT9dIeD/KrQfrlW6FknjiDsWPdob2DeFL1EBMn3vtiAl0yRCAw850fNKt6018NGFYWiRf+Abqho56kKQ";

            postCollection.Add("XMLData", xmlData);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Srv/Gateway";

            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);

            ViewBag.ServerResponse = ServerResponse;

            return View();

        }

        //模擬payment傳送財付通訂單資料到payment center
        public ActionResult TestTenpayToPaymentCenter()
        {
            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 999999999;    //dev
            long AllPayMerchantID = 2000132;    //2000132:stage的測試店家 

            string totalAmount = "35";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //string expireDate = DateTime.Now.AddDays(2).ToString("yyyy/MM/dd HH:mm:ss");

            //設定MP的Post網址                        
            string postURL = "http://pay-stage.allpay.com.tw/Payment/Gateway";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"          
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TradeAmount>" + totalAmount + "</TradeAmount>"
                + "<ExpireTime></ExpireTime>"                
                //+ "<ServerReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ServerReplyURL>"
                //+ "<ClientReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ClientReplyURL>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ServerReplyURL>"
                + "<ClientReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ClientReplyURL>"
                
                + "<Remark>%e4%b8%80%e8%88%ac%e5%95%86%e5%93%81%e6%b8%ac%e8%a9%a6-DEV</Remark>"
                + "</Data></Root>";


            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "TENPAY");

            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);


            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        //模擬payment傳送支付寶訂單資料到payment center
        public ActionResult TestAlipayToPaymentCenter()
        {
            string AllPayHashKey = devHashKey;
            string AllPayHashIV = devHashIv;
            long AllPayMerchantID = 999999999;    //dev
            
     
            string totalAmount = "35";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //string expireDate = DateTime.Now.AddDays(2).ToString("yyyy/MM/dd HH:mm:ss");

            //設定MP的Post網址                        
            //string postURL = "http://pay-stage.allpay.com.tw/Payment/Gateway";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";
            string postURL = "https://pay.allpay.com.tw/Payment/Gateway";

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"                
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TradeAmount>" + totalAmount + "</TradeAmount>"
                + " <ItemName>入門包#超值包</ItemName><ItemCounts>1#2</ItemCounts><ItemPrice>15#20</ItemPrice>"
                //+ "<ServerReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ServerReplyURL>"
                //+ "<ClientReplyURL>" + HttpUtility.UrlEncode("http://mockMerchant-stage.allpay.com.tw/AllPayPayment/ReceiveOrderResult") + "</ClientReplyURL>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ServerReplyURL>"
                + "<ClientReplyURL>" + HttpUtility.UrlEncode("http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult") + "</ClientReplyURL>"

                + "<Remark>%e4%b8%80%e8%88%ac%e5%95%86%e5%93%81%e6%b8%ac%e8%a9%a6-DEV</Remark>"
                + "<Email>matt.yeh@allpay.com.tw</Email>"
                + "<PhoneNo>0958389636</PhoneNo>"
                + "<UserName>葉炳棋</UserName>"
                + "</Data></Root>";

            tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>1031026</MerchantID><MerchantTradeNo>138355833153339</MerchantTradeNo><MerchantTradeDate>2013/11/04 17:45:32</MerchantTradeDate><TradeAmount>100</TradeAmount><ItemName>gfhgfhgf</ItemName><ItemCounts>1</ItemCounts><ItemPrice>100</ItemPrice><ServerReplyURL>https%3A%2F%2Fgate.pepay.com.tw%2Fpepay%2Fpaysys%2Fallpay%2Fal_rcv.php</ServerReplyURL><ClientReplyURL>https%3A%2F%2Fgate.pepay.com.tw%2Fpepay%2Fpaysys%2Fallpay%2Fal_rtn.php</ClientReplyURL><Remark></Remark><Email></Email><PhoneNo></PhoneNo><UserName></UserName></Data></Root>";

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "ALIPAY");

            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);
            
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }

        /// <summary>
        /// 模擬要導到AllPay接收綠界信用卡訂單的
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCreditCardTradeToCreditAllPay()
        {
            string AuthURL = "https://credit.allpay.com.tw/form_ssl.php";
            string act = "auth";
            string client = "3";
            string card_no = "4311952222222222";
            string CARDM = "12";
            string CARDY = "12";
            string amount = "2"; //交易金額
            string od_sob = "1234567";  //訂單編號
            string cvv2 = "123";    //卡片未三碼
            string roturl = "http://test.allpay.com.tw";

            string PostData = string.Format("act={0}&client={1}&card_no={2}&CARDM={3}&CARDY={4}&amount={5}&od_sob={6}&cvv2={7}&roturl={8}", act, client, card_no, CARDM, CARDY, amount, od_sob, cvv2, roturl);

            //Post至MP反查訂單狀態
            string resultXML = new AllPay.ShareLib.Network().FormPostReferrURL(AuthURL, "", PostData, 950);

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("act", act);
            postCollection.Add("client", client);
            postCollection.Add("card_no", card_no);
            postCollection.Add("CARDM", CARDM);
            postCollection.Add("CARDY", CARDY);
            postCollection.Add("amount", amount);
            postCollection.Add("od_sob", od_sob);
            postCollection.Add("cvv2", cvv2);

            postCollection.Add("roturl", roturl);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = AuthURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }
                               

        public ActionResult GwNotifyAuthResult()
        {
            string notifyURL = "http://devpaymentcenter.allpay.com.tw:12003/bank/gw/srv/credit/authdata";

            string tradeID = "12819";
            int tradeAmount = 2;

            string allsn = tradeID;
            string succ = "1";  //1:授權成功，0:授權失敗
	        int gwsr = 123321; //授權單號
	        string response_code = "11111";
	        string response_msg = "測試";
	        string process_date = "20130124";
	        string process_time = "112233";
            string od_sob = "201222222";        //訂單編號
	        string auth_code = "222222";
            int amount = tradeAmount;        //金額
	        string od_hoho = "測試";
	        int stage = 0;
	        int stast = 0;
	        int staed = 0;
	        int eci = 3;
	        string card4no = "2222";
	        string card6no = "123456";
	        int red_dan = 0;
	        int red_de_amt = 0;
	        int red_ok_amt = 0;
	        int red_yet = 0;
	        string rech_key = "sfasxf";
	        string inspect = "xcfasdfa";
	        int spcheck = 3265;


            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("allsn", allsn);
            postCollection.Add("succ", succ);
            postCollection.Add("gwsr", gwsr.ToString());
            postCollection.Add("response_code", response_code);
            postCollection.Add("response_msg", response_msg);
            postCollection.Add("process_date", process_date);
            postCollection.Add("process_time", process_time);
            postCollection.Add("od_sob", od_sob);
            postCollection.Add("auth_code", auth_code);
            postCollection.Add("amount", amount.ToString());
            postCollection.Add("od_hoho", od_hoho);
            postCollection.Add("stage", stage.ToString());
            postCollection.Add("stast", stast.ToString());
            postCollection.Add("staed", staed.ToString());
            postCollection.Add("eci", eci.ToString());
            postCollection.Add("card4no", card4no);
            postCollection.Add("card6no", card6no);
            postCollection.Add("red_dan", red_dan.ToString());
            postCollection.Add("red_de_amt", red_de_amt.ToString());
            postCollection.Add("red_ok_amt", red_ok_amt.ToString());
            postCollection.Add("red_yet", red_yet.ToString());
            postCollection.Add("rech_key", rech_key);
            postCollection.Add("inspect", inspect);
            postCollection.Add("spcheck", spcheck.ToString());


            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(notifyURL, RequestTable);
            
            
            //string PostData = string.Format("succ={0}&gwsr={1}&response_code={2}&response_msg={3}&process_date={4}&process_time={5}"
            //    + "&od_sob={6}&auth_code={7}&amount={8}&od_hoho={9}&stage={10}"
            //    + "&stast={11}&staed={12}&eci={13}&card4no={14}&card6no={15}" 
            //    + "&red_dan={16}&red_de_amt={17}&red_ok_amt={18}&red_yet={19}&rech_key={20}" 
            //    + "&inspect={21}&spcheck={22}"
            //    ,succ, gwsr, response_code, response_msg, process_date, process_time
            //    ,od_sob, auth_code, amount, od_hoho, stage 
            //    ,stast, staed, eci, card4no, card6no 
            //    ,red_dan, red_de_amt, red_ok_amt, red_yet, rech_key
            //    ,inspect, spcheck
            //    );

            

            ////Post至MP反查訂單狀態
            //string resultXML = new AllPay.ShareLib.Network().FormPostReferrURL(notifyURL, "", PostData, 950);

            return null;
        }


       
        #endregion


        #region 從PaymentCenter回傳到Payment

        //測試回傳給payment WebATM付款成功的動作
        public ActionResult TestWebAtmReturn()
        {

            string merchantId = "999999999";
            string merchantTradeNo = "40964";           //payment的tradeID
            string tradeNo = "20121202033318643476";    //payment center的tradeNo(隨便填，可以不用改)
            string tradeAmount = "1000";
            string AesHashKey = "fugvqTnG3ROx81MO";
            string AesHashIv = "WkSfnqIaHLbUMV5X";



            //string serverRelpyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/webatm/result";
            //string clientReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/cnt/webatm/result";
            string serverRelpyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/srv/webatm/result";
            string clientReplyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/cnt/webatm/result";

            //也必需更新payment center的訂單，因為payment會反查
            /*
                update Payment_TradeNo
                set PaymentStatus = '1'
                ,PaymentDate = GETDATE()
                where TradeID = 12153

                update Payment_TradeDetail_WebATM
                set RtnCode = '1'
                ,RtnPaymentDate= GETDATE()
                ,RtnBankCode = '008'
                ,RtnBankAcc = '168371'
                where TradeID = 12153
             * */

            XmlDocument XML = new XmlDocument();
            XML.Load(HttpContext.Server.MapPath("~/App_Data/ReturnMerchantWebATM.xml"));

            //###取得XML的節點
            XmlElement eleMerchantID = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantID");
            XmlElement eleMerchantTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantTradeNo");
            XmlElement eleRtnCode = (XmlElement)XML.SelectSingleNode("Root/Data/RtnCode");
            XmlElement eleRtnMsg = (XmlElement)XML.SelectSingleNode("Root/Data/RtnMsg");
            XmlElement eleTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/TradeNo");
            XmlElement eleTradeDate = (XmlElement)XML.SelectSingleNode("Root/Data/TradeDate");
            XmlElement eleTradeAmount = (XmlElement)XML.SelectSingleNode("Root/Data/TradeAmount");
            XmlElement eleAccBank = (XmlElement)XML.SelectSingleNode("Root/Data/AccBank");
            XmlElement eleAccNo = (XmlElement)XML.SelectSingleNode("Root/Data/AccNo");
            XmlElement eleBankName = (XmlElement)XML.SelectSingleNode("Root/Data/BankName");

            //### 設定XML內容
            eleMerchantID.InnerText = merchantId;
            eleMerchantTradeNo.InnerText = merchantTradeNo;
            eleRtnCode.InnerText = "1";
            eleRtnMsg.InnerText = "success";
            eleTradeNo.InnerText = tradeNo;
            eleTradeDate.InnerText = "2012/12/02 03:33:18"; // DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            eleTradeAmount.InnerText = tradeAmount;
            eleAccBank.InnerText = "808";
            eleAccNo.InnerText = "17962";
            eleBankName.InnerText = "ESUN";

            //### 將XML透過AES加密
            string XMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, XML.OuterXml);

            string serverResponse = new AllPay.ShareLib.Network().FormPost(serverRelpyUrl, "XMLData=" + XMLData, "", 0, 65001);

            //再client端回傳
            string clientResponse = new AllPay.ShareLib.Network().FormPost(clientReplyUrl, "XMLData=" + XMLData, "", 0, 65001);

            ViewBag.ServerResponse = serverResponse;
            ViewBag.ServerResult = false;

            if (serverResponse.IndexOf("1|OK") > -1)
            {
                ViewBag.Result = true;
            }

            ViewBag.ClientResponse = clientResponse;

            return View();
        }


        //測試回傳給payment ATM付款成功的動作
        public ActionResult TestAtmHncbReturn()
        {

            //string merchantId = "999999999";
            //string merchantTradeNo = "100050";           //payment的tradeID
            //string tradeNo = "20121204134122541156";    //payment center的tradeNo
            //string AesHashKey = "fugvqTnG3ROx81MO";
            //string AesHashIv = "WkSfnqIaHLbUMV5X";
            //string serverReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/atm/result";


            string merchantId = "2000132";
            string merchantTradeNo = "100050";           //payment的tradeID
            string tradeNo = "20121204134122541156";    //payment center的tradeNo
            string AesHashKey = "ejCk326UnaZWKisg";
            string AesHashIv = "q9jcZX8Ib9LM8wYk";
            string serverReplyUrl = "http://linda.sunup.net/test/pay_info.php";
            
            //也必需更新payment center的訂單，因為payment會反查
            /*
                update Payment_TradeNo
                set PaymentStatus = '1'
                ,PaymentDate = GETDATE()
                where TradeID = 12153

                update Payment_TradeDetail_ATM
                set RtnCode = '1'
                ,RtnPaymentDate= GETDATE()
                ,RtnBankCode = '008'
                ,RtnBankAcc = '168371'
                where TradeID = 12153
             * */

            XmlDocument XML = new XmlDocument();
            XML.Load(HttpContext.Server.MapPath("~/App_Data/NoticeMerchantATM.xml"));

            //###取得XML的節點
            XmlElement eleMerchantID = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantID");
            XmlElement eleMerchantTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantTradeNo");
            XmlElement eleRtnCode = (XmlElement)XML.SelectSingleNode("Root/Data/RtnCode");
            XmlElement eleRtnMsg = (XmlElement)XML.SelectSingleNode("Root/Data/RtnMsg");
            XmlElement eleTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/TradeNo");
            XmlElement elePayDate = (XmlElement)XML.SelectSingleNode("Root/Data/PayDate");
            XmlElement eleTradeAmount = (XmlElement)XML.SelectSingleNode("Root/Data/TradeAmount");
            XmlElement eleAccBank = (XmlElement)XML.SelectSingleNode("Root/Data/AccBank");
            XmlElement eleAccNo = (XmlElement)XML.SelectSingleNode("Root/Data/AccNo");

            //### 設定XML內容
            eleMerchantID.InnerText = merchantId;
            eleMerchantTradeNo.InnerText = merchantTradeNo;
            eleRtnCode.InnerText = "1";
            eleRtnMsg.InnerText = "success";
            eleTradeNo.InnerText = tradeNo;
            elePayDate.InnerText = "2013/10/18 23:38:18";
            eleTradeAmount.InnerText = "105";
            eleAccBank.InnerText = "812";
            eleAccNo.InnerText = "123123";

            //### 將XML透過AES加密
            string XMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, XML.OuterXml);
            
            //server端回傳
            string serverReponse = new AllPay.ShareLib.Network().FormPost(serverReplyUrl, "XMLData=" + XMLData, "", 0, 65001);

            ViewBag.Response = serverReponse;
            ViewBag.Result = false;

            if (serverReponse.IndexOf("1|OK") > -1)
            {
                ViewBag.Result = true;
            }

            return View();

        }


        //測試回傳給payment 超商付款成功的動作
        public ActionResult TestCVSReturnToPayment()
        {

            string merchantId = "999999999";
            string merchantTradeNo = "13837";           //payment的tradeID(必改)
            string tradeNo = "20121018101322793733";    //payment center的tradeNo(可不改)
            string payDate = "2012-10-18 19:25:27";
            string payAmount = "30";
            string paymentNo = "GW121018919930";        //繳費代碼
            string payForm = "okmart";                  //繳費平台

            string AesHashKey = "fugvqTnG3ROx81MO";     //開發環境的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";
            string serverReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/cvs/result";
            
      

            XmlDocument xml = new XmlDocument();

            xml.Load(HttpContext.Server.MapPath("~/App_Data/ReturnCVSPaidTrade.xml"));

            XmlElement eleMerchantID = (XmlElement)xml.SelectSingleNode("Root/Data/MerchantID");
            XmlElement eleMerchantTradeNo = (XmlElement)xml.SelectSingleNode("Root/Data/MerchantTradeNo");
            XmlElement eleRtnCode = (XmlElement)xml.SelectSingleNode("Root/Data/RtnCode");
            XmlElement eleRtnMsg = (XmlElement)xml.SelectSingleNode("Root/Data/RtnMsg");
            XmlElement eleTradeNo = (XmlElement)xml.SelectSingleNode("Root/Data/TradeNo");
            XmlElement elePayDate = (XmlElement)xml.SelectSingleNode("Root/Data/PayDate");
            XmlElement eleTradeAmount = (XmlElement)xml.SelectSingleNode("Root/Data/TradeAmount");
            XmlElement elePaymentNo = (XmlElement)xml.SelectSingleNode("Root/Data/PaymentNo");
            XmlElement elePayFrom = (XmlElement)xml.SelectSingleNode("Root/Data/PayFrom");

            //### 設定XML內容
            eleMerchantID.InnerText = merchantId;
            eleMerchantTradeNo.InnerText = merchantTradeNo;
            eleRtnCode.InnerText = "1";
            eleRtnMsg.InnerText = "Succeeded";
            eleTradeNo.InnerText = tradeNo;
            elePayDate.InnerText = payDate;
            eleTradeAmount.InnerText = payAmount;
            elePaymentNo.InnerText = paymentNo;
            elePayFrom.InnerText = payForm;

            //long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            //eleTimeStamp.InnerText = epoch.ToString();

            ////### 將XML透過AES加密
            string XMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, xml.OuterXml);

            //server端回傳
            string serverReponse = new AllPay.ShareLib.Network().FormPost(serverReplyUrl, "XMLData=" + XMLData, "", 0, 65001);

            ViewBag.Reponse = serverReponse;
            ViewBag.Result = false;

            if (serverReponse.IndexOf("1|OK") > -1)
            {
                ViewBag.Result = true;
            }

            return View();

        }



        //測試回傳給payment 支付寶付款成功的動作
        public ActionResult TestAlipayReturn()
        {


            string merchantTradeNo = "42244";           //payment的tradeID
            string tradeNo = "20121212170719279614";    //payment center的tradeNo
            string tradeAmount = "350";

            string merchantId = "999999999";
            string AesHashKey = "fugvqTnG3ROx81MO";
            string AesHashIv = "WkSfnqIaHLbUMV5X";
            string relpyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/cnt/alipay/result";
            string serverReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/alipay/result";

      
            XmlDocument XML = new XmlDocument();
            XML.Load(HttpContext.Server.MapPath("~/App_Data/PaymentReceiveAlipay.xml"));

            //###取得XML的節點
            XmlElement eleMerchantID = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantID");
            XmlElement eleMerchantTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantTradeNo");
            XmlElement eleRtnCode = (XmlElement)XML.SelectSingleNode("Root/Data/RtnCode");
            XmlElement eleRtnMsg = (XmlElement)XML.SelectSingleNode("Root/Data/RtnMsg");
            XmlElement eleTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/TradeNo");
            XmlElement eleTradeDate = (XmlElement)XML.SelectSingleNode("Root/Data/TradeDate");
            XmlElement eleTradeAmount = (XmlElement)XML.SelectSingleNode("Root/Data/TradeAmount");
            XmlElement eleAlipayID = (XmlElement)XML.SelectSingleNode("Root/Data/AlipayID");
            XmlElement eleAlipayTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/AlipayTradeNo");
            XmlElement eleTimeStamp = (XmlElement)XML.SelectSingleNode("Root/Data/TimeStamp");

            //### 設定XML內容
            eleMerchantID.InnerText = merchantId;
            eleMerchantTradeNo.InnerText = merchantTradeNo;
            eleRtnCode.InnerText = "1";
            eleRtnMsg.InnerText = "success";
            eleTradeNo.InnerText = tradeNo;
            eleTradeDate.InnerText = "2012/12/12 17:07:18";
            eleTradeAmount.InnerText = tradeAmount;
            eleAlipayID.InnerText = "2088002260834144";
            eleAlipayTradeNo.InnerText = "2012121202863314";

            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            eleTimeStamp.InnerText = epoch.ToString();

            //### 將XML透過AES加密
            string XMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, XML.OuterXml);

            //先server端回傳
            string serverReponse = new AllPay.ShareLib.Network().FormPost(serverReplyUrl, "XMLData=" + XMLData, "", 0, 65001);

            //再client端回傳
            string response = new AllPay.ShareLib.Network().FormPost(relpyUrl, "XMLData=" + XMLData, "", 0, 65001);
            //DoRequest(relpyUrl, XMLData);

            return null;
        }



        //測試回傳給payment 財付通付款成功的動作
        public ActionResult TestTenpayReturn()
        {

            //string merchantId = "999999999";
            //string merchantTradeNo = "41047";           //payment的tradeID
            //string tradeNo = "20121202161509134918";    //payment center的tradeNo


            ////string relpyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/cnt/tenpay/result";
            ////string serverReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/tenpay/result";

            //string relpyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/cnt/tenpay/result";
            //string serverReplyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/srv/tenpay/result";

            string merchantId = "2000132";
            string merchantTradeNo = "100051";           //payment的tradeID
            string tradeNo = "20131018144107463317";    //payment center的tradeNo
            string AesHashKey = "ejCk326UnaZWKisg";
            string AesHashIv = "q9jcZX8Ib9LM8wYk";
            string serverReplyUrl = "http://linda.sunup.net/test/pay_info.php";
            

            XmlDocument XML = new XmlDocument();
            XML.Load(HttpContext.Server.MapPath("~/App_Data/PaymentReceiveTenpay.xml"));

            //###取得XML的節點
            XmlElement eleMerchantID = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantID");
            XmlElement eleMerchantTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantTradeNo");
            XmlElement eleRtnCode = (XmlElement)XML.SelectSingleNode("Root/Data/RtnCode");
            XmlElement eleRtnMsg = (XmlElement)XML.SelectSingleNode("Root/Data/RtnMsg");
            XmlElement eleTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/TradeNo");
            XmlElement eleTradeDate = (XmlElement)XML.SelectSingleNode("Root/Data/TradeDate");
            XmlElement eleTradeAmount = (XmlElement)XML.SelectSingleNode("Root/Data/TradeAmount");
            XmlElement eleTenpayTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/TenpayTradeNo");
            XmlElement eleTimeStamp = (XmlElement)XML.SelectSingleNode("Root/Data/TimeStamp");

            //### 設定XML內容
            eleMerchantID.InnerText = merchantId;
            eleMerchantTradeNo.InnerText = merchantTradeNo;
            eleRtnCode.InnerText = "1";
            eleRtnMsg.InnerText = "success";
            eleTradeNo.InnerText = tradeNo;
            eleTradeDate.InnerText = "2013/10/18 23:24:00";
            eleTradeAmount.InnerText = "200.0";
            eleTenpayTradeNo.InnerText = "12141540012012120201";

            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            eleTimeStamp.InnerText = epoch.ToString();

            //### 將XML透過AES加密
            string XMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, XML.OuterXml);

            //先server端回傳
            string serverReponse = new AllPay.ShareLib.Network().FormPost(serverReplyUrl, "XMLData=" + XMLData, "", 0, 65001);

            //再client端回傳
            //string response = new AllPay.ShareLib.Network().FormPost(relpyUrl, "XMLData=" + XMLData, "", 0, 65001);
            //DoRequest(relpyUrl, XMLData);

            return null;
        }


        #endregion


        #region eticket相關測試

        public ActionResult TestEticketCreateGuarantee()
        {

            long merchantId = 1000139;
            string hashKey = "Zf1AjVRlwE4XjlF9";        //beta
            string hashIv = "Ps8hPWGtUW0PE3Gk";
            string tradePostUrl = "http://payment-beta.allpay.com.tw/api/Guarantee/CreateGuarantee";


            //long merchantId = 1000139;
            //string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            //string hashIv = "Ps8hPWGtUW0PE3Gk";
            //string tradePostUrl = "http://payment-stage.allpay.com.tw/api/Guarantee/CreateGuarantee";


            //long merchantId = 888891;
            //string hashKey = "SM6zZHQvodchMaTk";        //正式
            //string hashIv = "zf3MhCfhzwUZoGfi";
            //string tradePostUrl = "https://payment.allpay.com.tw/api/Guarantee/CreateGuarantee";


            string merchantTradeNo = "20130514112749";  // "Matt" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string tradeNo = "1305141127592819";  // DateTime.Now.ToString("yyyyMMddHHmmss");
            int guaranteeTotalAmount = 90;

            GuaranteeCreateGuaranteePost ETicketModel = new GuaranteeCreateGuaranteePost();
            List<GuaranteeCreateGuaranteePostItem> ListItemData = new List<GuaranteeCreateGuaranteePostItem>();

            ETicketModel.MerchantID = merchantId;
            ETicketModel.MerchantTradeNo = merchantTradeNo;
            ETicketModel.TradeNo = tradeNo;
            ETicketModel.PaymentType = "eticket";
            ETicketModel.UserName = "葉炳棋";
            ETicketModel.Phone = "0958389636";
            ETicketModel.GuaranteeTotalAmount = guaranteeTotalAmount;

            GuaranteeCreateGuaranteePostItem guaranteeCreateGuaranteePostItem = new GuaranteeCreateGuaranteePostItem();
            guaranteeCreateGuaranteePostItem.ItemNo = "A123";
            guaranteeCreateGuaranteePostItem.ItemName = "喜來登住宿券";
            guaranteeCreateGuaranteePostItem.ItemType = 0;
            guaranteeCreateGuaranteePostItem.Quantity = 3;
            guaranteeCreateGuaranteePostItem.Amount = 30;
            guaranteeCreateGuaranteePostItem.SubTotalAmount = 90;
            guaranteeCreateGuaranteePostItem.GuaranteeQuantity = 3;
            guaranteeCreateGuaranteePostItem.GuaranteeAmount = 90;

            ListItemData.Add(guaranteeCreateGuaranteePostItem);
            ETicketModel.ItemData = ListItemData;

            string Json = HttpUtility.UrlEncode(JsonConvert.SerializeObject(ETicketModel), System.Text.Encoding.UTF8);


            string PostUrl = tradePostUrl;
            string Contents = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, Json);

            Hashtable postHashTable = new Hashtable();
            postHashTable.Add("MerchantID", merchantId);
            postHashTable.Add("Contents", Contents);

            string postReturnData = DoRequest(PostUrl, postHashTable);

            string decryptXml = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, postReturnData); ;
            ViewBag.returnEncryptXml = HttpUtility.UrlDecode(decryptXml);

            return View();

        }


        /// <summary>
        /// 測試eticket退款
        /// </summary>
        /// <returns></returns>
        public ActionResult TestEticketChargeBack() {

            long merchantId = 1000070;
            string hashKey = "fugvqTnG3ROx81MO";        //dev
            string hashIv = "WkSfnqIaHLbUMV5X";
            string tradePostUrl = "http://devpayment.allpay.com.tw:12005/api/Guarantee/Chargeback";

            //long merchantId = 1000139;
            //string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            //string hashIv = "Ps8hPWGtUW0PE3Gk";
            //string tradePostUrl = "http://payment-stage.allpay.com.tw/api/Guarantee/Chargeback";


            string merchantTradeNo = "20130412113131";
            string tradeNo = "1304121131338757";
            int chargebackTotalAmount = 10;

            int chargebackQuantity = 1;
            string itemNo = "A123";
            int chargebackAmount = 10;

            GuaranteeChargebackPost ETicketModel = new GuaranteeChargebackPost();
            List<GuaranteeChargebackPostItem> ListItemData = new List<GuaranteeChargebackPostItem>();

            ETicketModel.MerchantID = merchantId;
            ETicketModel.MerchantTradeNo = merchantTradeNo;
            ETicketModel.TradeNo = tradeNo;
            ETicketModel.ChargebackTotalAmount = chargebackTotalAmount;

            GuaranteeChargebackPostItem chargeBackPostItem = new GuaranteeChargebackPostItem();
            chargeBackPostItem.ItemNo = itemNo;
            chargeBackPostItem.ChargebackQuantity = chargebackQuantity;
            chargeBackPostItem.ChargebackAmount = chargebackAmount;
            ListItemData.Add(chargeBackPostItem);
            //ListItemData.Add(chargeBackPostItem);

            ETicketModel.ItemData = ListItemData;

            string Json = HttpUtility.UrlEncode(JsonConvert.SerializeObject(ETicketModel), System.Text.Encoding.UTF8);
                        

            string PostUrl = tradePostUrl;
            string Contents = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, Json);

            Hashtable postHashTable = new Hashtable();
            postHashTable.Add("MerchantID", merchantId);
            postHashTable.Add("Contents", Contents);

            string postReturnData = DoRequest(PostUrl, postHashTable);

            ////設定要Post的資料
            //Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            //PostDictionary.Add("MerchantID", merchantId.ToString());
            //PostDictionary.Add("Contents", Contents);

            ////設定要送到MP的資料
            //TempData["PostCollection"] = PostDictionary;
            //TempData["PostURL"] = PostUrl;

            ////將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            //return RedirectToAction("AutoSubmitForm", "Common");

            string decryptXml = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, postReturnData);
            ViewBag.returnEncryptXml = HttpUtility.UrlDecode(decryptXml);

            return View();
        
        }


        #endregion

        #region 玉山儲值

        public ActionResult TestEsunMemberAuth()
        {
            string postURL = "https://mtest.esunbank.com.tw/epay/esunAuth.aspx";
            string IcpConfirmTransURL = "http://member-stage.allpay.com.tw";
            string HashKey = "2iQEK29jdeMSZV0NIzymRPeuOQ6yCv";

            string AccNo = "8801953188059";
            string AccName = HttpUtility.UrlEncode("葉炳棋");
            string AccCell = "0958389636";
            string AccMail = "matt.yeh@allpay.com.tw";
            string CommAddress = HttpUtility.UrlEncode("台北市南港路三重路");
            string HomeAddress = HttpUtility.UrlEncode("台北市南港路三重路");
            string BirthDate = "19800101";
            string IDN = "N123756874";
            string PicFree = "1";
            string IssueDate = "20030101";  //會員統編領補換日
            string IssueType = "3";     //"1":初發 "2": 補發 "3": 換發 
            string IssueLoc = "10007000";   //領補換地點
            string IDType = "C3";       //"C1" :電子簽章認證/"C2" :金融連結認證/C3" :手機、ＥＭＡＩＬ認證
            string IcpNo = "O2G5M1";
            string HashKeyNo = "1";
            string IdentifyNo = new AllPay.ShareLib.Crypt().SHA1(AccNo + AccName + AccCell + AccMail + CommAddress + HomeAddress + BirthDate + IDN + PicFree + IssueDate + IssueType + IssueLoc + IDType + IcpNo + HashKeyNo + HashKey);  //驗證碼
            
            
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("AccNo", AccNo);
            postCollection.Add("AccName", AccName);
            postCollection.Add("AccCell", AccCell);
            postCollection.Add("AccMail", AccMail);
            postCollection.Add("CommAddress", CommAddress);
            postCollection.Add("HomeAddress", HomeAddress);

            postCollection.Add("BirthDate", BirthDate);
            postCollection.Add("IDN", IDN);
            postCollection.Add("PicFree", PicFree);
            postCollection.Add("IssueDate", IssueDate);
            postCollection.Add("IssueType", IssueType);
            postCollection.Add("IssueLoc", IssueLoc);
            postCollection.Add("IDType", IDType);
            postCollection.Add("IcpNo", IcpNo);
            postCollection.Add("IcpConfirmTransURL", IcpConfirmTransURL);
            postCollection.Add("HashKeyNo", HashKeyNo);
            postCollection.Add("IdentifyNo", IdentifyNo);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }

        /// <summary>
        /// 查詢會員的玉山餘額
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryEsunBalance()
        {
            ProdApiTopUpWs.TopUpWSSoapClient prodApiTopUpWS = new ProdApiTopUpWs.TopUpWSSoapClient();
            var returnInfo = prodApiTopUpWS.TopUpBalance(1028250, 999900808);
           
            return View();

        }

        #endregion


        #region 支付寶

        /// <summary>
        /// 測試到payment center建立訂單
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateAlipayTradeToPaymentCenter()
        {

            //string AllPayHashKey = devHashKey;
            //string AllPayHashIV = devHashIv;
            //long AllPayMerchantID = 1000070;
            ////設定MP的Post網址    
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";
            ////string postURL = "https://pay.allpay.com.tw/Payment/Gateway";

            //string AllPayHashKey = betaHashKey;
            //string AllPayHashIV = betaHashIv;
            ////long AllPayMerchantID = 1000139;                     
            //long AllPayMerchantID = 1000273;    //walter特店
            ////設定MP的Post網址    
            //string postURL = "http://pay-beta.allpay.com.tw/Payment/Gateway";

            //string AllPayHashKey = stageHashKey;
            //string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 2000132;
            //////設定MP的Post網址                        
            //string postURL = "http://pay-stage.allpay.com.tw/Payment/Gateway";


            //string AllPayHashKey = prodHashKey;
            //string AllPayHashIV = prodHashIv;
            //long AllPayMerchantID = 888891;     //正式機
            ////設定MP的Post網址                        
            //string postURL = "https://pay.allpay.com.tw/Payment/Gateway";


            //string AllPayHashKey = "kqdWBOOUvpmYltq6";
            //string AllPayHashIV = "50vySfM1EWPwPa5Z";
            //long AllPayMerchantID = 1016085;     //范董(正式機)
            ////設定MP的Post網址                        
            //string postURL = "http://pay.allpay.com.tw/Payment/Gateway";

            string AllPayHashKey = "90tfJomHg20jz2Ja";
            string AllPayHashIV = "85UQ17Fw9d8l8wXf";
            long AllPayMerchantID = 1027174;     
            //設定MP的Post網址                        
            string postURL = "http://pay.allpay.com.tw/Payment/Gateway";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";

            //string totalAmount = "3";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string totalAmount = "20";

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TradeAmount>" + totalAmount + "</TradeAmount>"
                + "<ItemName>入門包#超值包</ItemName>"
                + "<ItemCounts>1#2</ItemCounts>"
                + "<ItemPrice>10#10</ItemPrice>"
                + "<ServerReplyURL>" + HttpUtility.UrlEncode("http://devmockMerchant.allpay.com.tw:12020/AllPayPayment/ReceiveBackUrlResult") + "</ServerReplyURL>"   
                + "<ClientReplyURL>" + HttpUtility.UrlEncode("http://www.allpay.com.tw") + "</ClientReplyURL>"                
                + "<Remark></Remark>"
                + "<Email>techsupport@allpay.com.tw</Email>"
                + "<PhoneNo>0912345678</PhoneNo>"
                + "<UserName>test</UserName>"
                + "</Data></Root>";

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>1027469</MerchantID><MerchantTradeNo>1</MerchantTradeNo><MerchantTradeDate>2013/09/12 05:25:55</MerchantTradeDate><TradeAmount>10</TradeAmount><ItemName>%E7%89%A9%E5%93%81%E4%B8%80</ItemName><ItemCounts>1</ItemCounts><ItemPrice>1</ItemPrice><ServerReplyURL>http%3A%2F%2Fwww.apollo-chess.com.tw%2Fhzbook%2Fallpay%2Falipay_checkout_reply.rbt</ServerReplyURL><ClientReplyURL>http%3A%2F%2Fwww.apollo-chess.com.tw%2Fhzbook%2Fallpay%2Falipay_checkout_return.rbt</ClientReplyURL><Remark></Remark><Email>teco.li.email@gmail.com</Email><PhoneNo>0953333543</PhoneNo><UserName>Teco</UserName></Data></Root>";

            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            //xmlData = "4K9D+yykBOhBtmAN5URwFVkEGf/TbjyzDOd+jmbeKbURzjkmvNU3kvygveWVm99JJcmRx9DbGTwsr4suPcReUcg5aNUr2nvI+lShmY1Hr+UJOae5c9AX+7Iu5+dvQlO+P9PdP8/s+ChrGJTl5zKz78g7DC5/Xz83C8xb2IsWjnnnVv85bf4iNKZvYaut0ZCLumrjoGzEMFOwaqT9zxzXTvF97uBsOgqm1kfMbCF9uqXLWhcigsiDGm1M5rRs6bx+un18jl6gBW6H4LetsDaLwu7PPanft6C7Emd/Hd8vwL1D4YCm1bjApCvVz9Z7t1GM7LOiC4WwCx/bQvijsfKkhBL8P3wwrvu6e77QQfNS0JM2dVCWEZIcNAvezy38SbQQAbK6Z7AD3TSIrGBH193+PzRz9bhlc+mkP3rVSn/jYoMeQ8wUvN7ISKrBRhd+nzRkhrJQWhIsggkI2/sERbiUFsTO+oJV/9wiSJx+9ZhM+GD3DcOojE1ZvjTHWcjLE9yIOepBjqwn3t1VwY8NPSVhoJB1HZIWPZAtASoDz2LpIDa1INWHfYcrSiqPMllk8igf4Nk1CeFpzsstpNJez3V7fndaL8CqNwuVkhyWgZ5x7Te3TAE/6gkOSMrtbaYJOof7kLBvNpshJG8rOSflHeRSflqHOE4ZXQolkFCFN1EDMlmOp2U/UX9lUDZJSXfC16GSBKG8oDNtxdbSDp2RqKAs76ag9jIfltoH+S3f2jUFrrFup613aWHTNA0aPIJrfNd3GsJmhoxJZs77T55jzUYq1Q4NHogXxykw4eYF99YaJaKs/jj/gf/7hVrKCCBSFp8IAGoxAvat84CpMjsU0JG3F2q/Naavh/Wib+RXvLiglnLQ4szpoxQkm8MMJU5dmcXC";
            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("PaymentType", "ALIPAY");
            postCollection.Add("XMLData", xmlData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }



        #endregion
       
    }
}
