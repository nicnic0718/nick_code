using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Collections;
using System.Text;
using AllPayWebServiceTest.Service;

namespace AllPayWebServiceTest.Controllers
{
    public class MockCreditController : BaseController
    {

        string prodHashKey = "SM6zZHQvodchMaTk";         //for prod 888891
        string prodHashIv = "zf3MhCfhzwUZoGfi";

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


        /// <summary>
        /// 模擬綠界將快速付款頁重新導頁到歐付寶信用卡接收頁
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateFastCreditCardTradeToCreditGW()
        {
            //string AuthURL = "http://devpaymentcenter.allpay.com.tw:12003/CreditPayment/FromCredit";
            string AuthURL = "http://pay-stage.allpay.com.tw/CreditPayment/FromCredit";
            

            string c = "888891";
            //string c = "2000132";          
            //string c = "1020203";
        

            //string PostData = string.Format("act={0}&client={1}&amount={2}&od_sob={3}&roturl={4}", act, client, amount, od_sob, roturl);

            ////Post至MP反查訂單狀態
            //string resultXML = new AllPay.ShareLib.Network().FormPostReferrURL(AuthURL, "", PostData, 950);

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("c", c);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = AuthURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        /// <summary>
        /// 綠界信用卡授權
        /// </summary>
        /// <returns></returns>
        public ActionResult TestGreenWorldCreditCardAuth()
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

            //PostData = "act=auth&client=1031032&amount=220&stage=3&od_sob=%u53f0%u7063%u6e90%u5473%u672c%u8216GTS0007805+AAE2EA11DA61E5924B3A0389B83108A0&roturl=http%3a%2f%2fgotwshop.kwdodo.idv.tw%2fAPI%2fordersGetGreenWorldECPay&bk_posturl=http%3a%2f%2fgotwshop.kwdodo.idv.tw%2fAPI%2fordersGetGreenWorldECPayBK";

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


        /// <summary>
        /// 模擬綠界重新導頁到歐付寶信用卡接收頁
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCreditCardTradeToCreditGW()
        {
            
           

            string act = "auth";

            string client = "1000070";
            string AuthURL = "http://devpaymentcenter.allpay.com.tw:12003/CreditPayment/FromCredit";

            //string client = "2000132";
            //string AuthURL = "http://pay-stage.allpay.com.tw/CreditPayment/FromCredit";

            //string client = "2000190";  //stage測銀聯
            //string AuthURL = "http://pay-stage.allpay.com.tw/CreditPayment/FromCredit";
            
           
            string amount = "1"; //交易金額
            string od_sob = DateTime.Now.ToString("yyyyMMddHHmmss");  //訂單編號  
            //string roturl = "http://devpaymentcenter.allpay.com.tw:12003/bank/gw/srv/credit/authdata";
            //string roturl = "https://pay.allpay.com.tw/bank/gw/cnt/credit/result";
            string roturl = "http://www-stage.allpay.com.tw";
            string stage = "0";
            string CUPus = "0";  //是否使用銀聯卡
            string mallurl = "http://www.allpay.com.tw";

         
            ////Post至MP反查訂單狀態
            //string resultXML = new AllPay.ShareLib.Network().FormPostReferrURL(AuthURL, "", PostData, 950);

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("act", act);
            postCollection.Add("client", client);
            postCollection.Add("amount", amount);
            postCollection.Add("od_sob", od_sob);
            postCollection.Add("stage", stage);
            postCollection.Add("CUPus", CUPus);     //是否使用銀聯卡
            postCollection.Add("mallurl", mallurl);

            //postCollection.Add("roturl", roturl);
            //postCollection.Add("bk_posturl", bk_posturl);                

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = AuthURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        /// <summary>
        /// 模擬使用歐付寶信用卡規格的訂單
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCreditCardTradeToPaymentCenter()
        {

            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            long AllPayMerchantID = 2000132;
            //設定MP的Post網址    
            string postURL = "http://pay-stage.allpay.com.tw/payment/gateway";
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/Payment/Gateway";
            //string postURL = "https://pay.allpay.com.tw/Payment/Gateway";
            

            string ReturnURL = "http://www.allpay.com.tw/atm/ReturnURL.php";
            string ServerReplyURL = "http://www.allpay.com.tw/atm/ServerReplyURL.php";
            string ClientBackURL = "http://www.allpay.com.tw/";
            string TradeDesc = "allapy123";

            string ReturnURLEncode= HttpUtility.UrlEncode(ReturnURL);
            string ServerReplyURLEncode= HttpUtility.UrlEncode(ServerReplyURL);
            string ClientBackURLEncode= HttpUtility.UrlEncode(ClientBackURL);
            string TradeDescEncode = HttpUtility.UrlEncode(TradeDesc);
            //string totalAmount = "3";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            
                                   
            string tradeXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<Root><Data>"
                    +"<MerchantID>2000132</MerchantID>"
                    +"<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                    +"<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                    +"<TotalAmount>22000</TotalAmount>"
                    +"<TradeDesc>"+TradeDescEncode+"</TradeDesc>"
                    +"<CardNo>0</CardNo>"
                    +"<CardValidMM>0</CardValidMM>"
                    +"<CardValidYY>0</CardValidYY>"
                    +"<CardCVV2>0</CardCVV2>"
                    +"<UnionPay>0</UnionPay>"
                    +"<Installment>0</Installment>"
                    +"<ThreeD>0</ThreeD>"
                    +"<CharSet>utf-8</CharSet>"
                    +"<Enn></Enn>"
                    +"<BankOnly></BankOnly>"
                    +"<Redeem></Redeem>"
                    +"<ReturnURL>"+ReturnURLEncode+"</ReturnURL>"
                    +"<ServerReplyURL>" + ServerReplyURLEncode + "</ServerReplyURL>"
                    +"<ClientBackURL>"+ClientBackURLEncode+"</ClientBackURL>"
                    +"<Remark></Remark>"
                + "</Data></Root>";

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



        /// <summary>
        /// 建立訂單到PaymentCenter信用卡的Web Service版程式
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPaymentCenterWebServiceTrade()
        {


            //string hashKey = "koyqVBURmmkQxROZ";        //開發
            //string hashIv = "BcRITiCQaUHBZC1f";
            //long MerchantID = 1000070;
            //DevPaymentCenterCredit.creditcardSoapClient devCreditWS = new DevPaymentCenterCredit.creditcardSoapClient();      //開發機

            //string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            //string hashIv = "Ps8hPWGtUW0PE3Gk";
            //long MerchantID = 1000139;

            string hashKey = "ejCk326UnaZWKisg";        //stage
            string hashIv = "q9jcZX8Ib9LM8wYk";
            long MerchantID = 2000132;  //1000139;
            //long MerchantID = 2000214;  //不使用OTP
            StagePaymentCenterCredit.creditcardSoapClient devCreditWS = new StagePaymentCenterCredit.creditcardSoapClient();    //stage

           

            string XMLData = "";
            string EnXMLData = "";

            string EnData = "";
            string DeData = "";


            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string CardNo = "4311952222222222";
            string Amount = "3";
            string CardValidMM = "06";
            string CardValidYY = "15";
            string CardCVV2 = "222";
            string UnionPay = "0";
            string Installment = "0";
            string ThreeD = "0";
            string PhoneNumber = "0958389636";

            //string CardNo = "";
            //string Amount = "1";
            //string CardValidMM = "";
            //string CardValidYY = "15";
            //string CardCVV2 = "";
            //string UnionPay = "0";
            //string Installment = "0";
            //string ThreeD = "0";
            //string PhoneNumber = "0958389636";

            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();


            //BasePaymentService basePaymentService = new BasePaymentService();
            //MerchantFunction merchantFunctionData = basePaymentService.GetMerchantHashKey(Convert.ToInt64(MerchantID));

            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
         


            ViewBag.XMLData = XMLData;
            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);


            //DevVirtualWs.VirtualSoapClient devvs = new DevVirtualWs.VirtualSoapClient();
            //EnData = devvs.Exchange(MerchantID, EnXMLData);

            string returnEncryptXml = devCreditWS.CreateTrade(MerchantID, EnXMLData);

            string decryptXml = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, returnEncryptXml); ;
            ViewBag.returnEncryptXml = HttpUtility.UrlDecode(decryptXml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(decryptXml);

            ViewBag.MerchantID = xmlDoc.SelectSingleNode("Root/Data/MerchantID").InnerText;
            ViewBag.MerchantTradeNo = xmlDoc.SelectSingleNode("Root/Data/MerchantTradeNo").InnerText;
            ViewBag.TradeNo = xmlDoc.SelectSingleNode("Root/Data/TradeNo").InnerText;

            return View();



        }

        /// <summary>
        /// 測試信用卡驗證OTP，若正確，則直接做授權
        /// </summary>        
        /// <returns></returns>
        public ActionResult TestPaymentCenterWebServiceVerifyOtp(string TradeNo, long MerchantID, string MerchantTradeNo, string OtpCode)
        {
            //string hashKey = "koyqVBURmmkQxROZ";        //開發
            //string hashIv = "BcRITiCQaUHBZC1f";
            ////long MerchantID = 888996;
            //DevPaymentCenterCredit.creditcardSoapClient devCreditWS = new DevPaymentCenterCredit.creditcardSoapClient();      //開發機

            string hashKey = "ejCk326UnaZWKisg";        //stage
            string hashIv = "q9jcZX8Ib9LM8wYk";
            //long MerchantID = 2000132; 

            //string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            //string hashIv = "Ps8hPWGtUW0PE3Gk";
            ////long MerchantID = 1000139;
            StagePaymentCenterCredit.creditcardSoapClient devCreditWS = new StagePaymentCenterCredit.creditcardSoapClient();    //stage


            string XMLData = "";
            string EnXMLData = "";


            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + TradeNo + "</TradeNo>";
            XMLData += "<OtpCode>" + OtpCode + "</OtpCode>";
            XMLData += "</Data>";
            XMLData += "</Root>";


            ViewBag.XMLData = XMLData;
            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);

            string returnEncryptXml = devCreditWS.VerifyOrderByOtp(MerchantID, EnXMLData);

            string decryptXml = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, returnEncryptXml); ;
            ViewBag.returnEncryptXml = HttpUtility.UrlDecode(decryptXml);

            return View();
        }


        public ActionResult TestCreditResendOtp()
        {

            //string hashKey = "fugvqTnG3ROx81MO";        //開發
            //string hashIv = "WkSfnqIaHLbUMV5X";
            //long MerchantID = 888996;
            //string MerchantTradeNo = "20130329113609";
            //string TradeNo = "20130329113610445865";
            //DevPaymentCenterCredit.creditcardSoapClient devCreditWS = new DevPaymentCenterCredit.creditcardSoapClient();      //開發機


            string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            string hashIv = "Ps8hPWGtUW0PE3Gk";
            long MerchantID = 1000139;
            string MerchantTradeNo = "20130329115839";
            string TradeNo = "20130329115839568164";
            StagePaymentCenterCredit.creditcardSoapClient devCreditWS = new StagePaymentCenterCredit.creditcardSoapClient();    //stage

            string XMLData = "";
            string EnXMLData = "";

            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + TradeNo + "</TradeNo>";
            XMLData += "</Data>";
            XMLData += "</Root>";


            ViewBag.XMLData = XMLData;
            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);

            string returnEncryptXml = devCreditWS.ResendOtp(MerchantID, EnXMLData);

            string decryptXml = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, returnEncryptXml); ;
            ViewBag.returnEncryptXml = HttpUtility.UrlDecode(decryptXml);

            return View();

        }

        /// <summary>
        /// 模擬call信用卡關帳退款的API
        /// </summary>
        /// <returns></returns>
        public ActionResult CreditCardDoActionToPaymentCenter()
        {
            //long MerchantID = 999999999;
            //string hashKey = "fugvqTnG3ROx81MO";        //開發for 999999999
            //string hashIv = "WkSfnqIaHLbUMV5X";
            //string relpyUrl = "http://devpaymentcenter.allpay.com.tw:12003/CreditDetail/DoAction";

            long MerchantID = 1000139;
            string hashKey = "Zf1AjVRlwE4XjlF9";        //stage
            string hashIv = "Ps8hPWGtUW0PE3Gk";
            string relpyUrl = "http://pay-stage.allpay.com.tw/CreditDetail/DoAction";
                                   
                     
            string XMLData = "";
            string EnXMLData = "";

            string MerchantTradeNo = "20131106153427";
            string tradeNo = "20131106153429315907";
            string Action = "N";
            string Amount = "1";

            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();


            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + tradeNo + "</TradeNo>";
            XMLData += "<Action>" + Action + "</Action>";
            XMLData += "<TotalAmount>" + Amount + "</TotalAmount>";
            XMLData += "</Data>";
            XMLData += "</Root>";

            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);

            Hashtable hashtable = new Hashtable();

            hashtable.Add("MerchantID", MerchantID);
            hashtable.Add("xmlData", EnXMLData);

            string rtnStatus = DoRequest(relpyUrl, hashtable);

            string DescryptXMLData = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, rtnStatus.Replace(" ", "+"));

            return null;
        }


        /// <summary>
        /// 信用卡訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryCreditCardTrade()
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

            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            long AllPayMerchantID = 2000132;
            ////設定MP的Post網址                        
            string postURL = "http://pay-stage.allpay.com.tw/payment/creditcardquery";


          

            //string totalAmount = "3";
            string MerchantTardeNo = "201310020010";
            

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            //將要丟給payment center的xml做AES加密
            string encryMerchantTradeNO = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, MerchantTardeNo);

            postCollection.Add("MerchantID", AllPayMerchantID.ToString());
            postCollection.Add("MerchantTradeNo", encryMerchantTradeNO);            

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        /// <summary>
        /// 信用卡訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryCreditCardTradeByWebService()
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

            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            long AllPayMerchantID = 2000132;
            ////設定MP的Post網址                        
            string postURL = "http://pay-stage.allpay.com.tw/payment/creditcardquery";


            //string totalAmount = "3";
            string MerchantTardeNo = "201310020010";

            
            //將要丟給payment center的xml做AES加密
            string encryMerchantTradeNO = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey, AllPayHashIV, MerchantTardeNo);

          

            ProdPaymentCenterCredit.creditcardSoapClient devCreditWS = new ProdPaymentCenterCredit.creditcardSoapClient();      //正式機

            string returnXml = devCreditWS.QueryTrade(AllPayMerchantID, "7CfqbJgNGm1RwUv0AZtbGw==");

            return View();

        }


        /// <summary>
        /// 模擬使用MPOS規格的刷卡
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateMPOSTradeToPaymentCenter(string totalAmount = "3")
        {

            //string AllPayHashKey = devHashKey;
            //string AllPayHashIV = devHashIv;
            //long AllPayMerchantID = 1000070;
            ////設定MP的Post網址    
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/mpos/CreateTrade";
            ////string postURL = "https://pay.allpay.com.tw/mpos/CreateTrade";

            //string AllPayHashKey = betaHashKey;
            //string AllPayHashIV = betaHashIv;
            ////long AllPayMerchantID = 1000139;                     
            //long AllPayMerchantID = 1000273;    //walter特店
            ////設定MP的Post網址    
            //string postURL = "http://pay-beta.allpay.com.tw/mpos/CreateTrade";

            string AllPayHashKey = stageHashKey;
            string AllPayHashIV = stageHashIv;
            long AllPayMerchantID = 2000132;
            ////設定MP的Post網址                        
            string postURL = "http://pay-stage.allpay.com.tw/mpos/CreateTrade";
    
            //string totalAmount = "3";
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"
                + "<TerminalID>12345678</TerminalID>"
                + "<MerchantTradeNo>" + orderTradeNo + "</MerchantTradeNo>"
                + "<MerchantTradeDate>" + orderDate + "</MerchantTradeDate>"
                + "<TotalAmount>" + totalAmount + "</TotalAmount>"

                //有帶卡號
                + "<CardNo>4311952222222222</CardNo>"
                + "<CardValidMM>11</CardValidMM>"
                + "<CardValidYY>13</CardValidYY>"
                + "<CardCVV2>0</CardCVV2>"

                + "<Installment>0</Installment>"
                + "<Redeem></Redeem>"              
                + "</Data></Root>";
                       

            //tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Root><Data><MerchantID>1029515</MerchantID><MerchantTradeNo>G201310081902022</MerchantTradeNo><MerchantTradeDate>2013/10/09 09:02:07</MerchantTradeDate><TotalAmount>440</TotalAmount><TradeDesc>Allpay%e5%95%86%e5%9f%8e%e8%b3%bc%e7%89%a9</TradeDesc><CardNo>0</CardNo><CardValidMM>0</CardValidMM><CardValidYY>0</CardValidYY><CardCVV2>0</CardCVV2><UnionPay>0</UnionPay><Installment>0</Installment><ThreeD>0</ThreeD><CharSet>UTF-8</CharSet><Enn/><BankOnly/><Redeem/><ReturnURL/><ServerReplyURL>http%3a%2f%2fwww.allpay.com.tw%2fatm%2fServerReplyURL.php</ServerReplyURL><ClientBackURL>http%3a%2f%2fwww.allpay.com.tw%2f</ClientBackURL><Remark>%e6%b8%ac%e8%a9%a6%e8%b3%bc%e7%89%a9</Remark></Data></Root>";
            //將要丟給payment center的xml做AES加密
            string xmlData = new AllPay.ShareLib.Crypt().TripleDes_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            Hashtable RequestTable = new Hashtable();
            RequestTable.Add("MerchantID", AllPayMerchantID.ToString());
            RequestTable.Add("PaymentType", "CREDIT");
            RequestTable.Add("XMLData", xmlData);           

            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);

            ViewBag.decryptXML = HttpUtility.HtmlDecode(new AllPay.ShareLib.Crypt().TripleDes_DeCrypt(AllPayHashKey, AllPayHashIV, ServerResponse)); 

            return View();

        }


        /// <summary>
        /// 模擬使用MPOS規格的可使用分期銀行及期數查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryInstallmentInfo()
        {

            //string AllPayHashKey = devHashKey;
            //string AllPayHashIV = devHashIv;
            //long AllPayMerchantID = 1000070;
            ////設定MP的Post網址    
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/mpos/QueryInstallmentInfo";
            ////string postURL = "https://pay.allpay.com.tw/mpos/QueryInstallmentInfo";

            //string AllPayHashKey = betaHashKey;
            //string AllPayHashIV = betaHashIv;
            ////long AllPayMerchantID = 1000139;                     
            //long AllPayMerchantID = 1000273;    //walter特店
            ////設定MP的Post網址    
            //string postURL = "http://pay-beta.allpay.com.tw/mpos/QueryInstallmentInfo";

            //string AllPayHashKey = stageHashKey;
            //string AllPayHashIV = stageHashIv;
            //long AllPayMerchantID = 2000132;
            //////設定MP的Post網址                        
            //string postURL = "http://pay-stage.allpay.com.tw/mpos/QueryInstallmentInfo";


            string AllPayHashKey = prodHashKey;
            string AllPayHashIV = prodHashIv;
            long AllPayMerchantID = 888891;     //正式機
            //設定MP的Post網址                        
            string postURL = "https://pay.allpay.com.tw/mpos/QueryInstallmentInfo";

                     
                      
            string orderTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string tradeXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<Root><Data>"
                + "<MerchantID>" + AllPayMerchantID + "</MerchantID>"             
                + "</Data></Root>";

                      
            
            string xmlData = new AllPay.ShareLib.Crypt().TripleDes_EnCrypt(AllPayHashKey, AllPayHashIV, tradeXML);

            Hashtable RequestTable = new Hashtable();
            RequestTable.Add("MerchantID", AllPayMerchantID.ToString());
            RequestTable.Add("XMLData", xmlData);

            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);

            ViewBag.decryptXML = HttpUtility.UrlDecode(new AllPay.ShareLib.Crypt().TripleDes_DeCrypt(AllPayHashKey, AllPayHashIV, ServerResponse));

            return View();

        }


        /// <summary>
        /// 付款結果接收頁
        /// </summary>
        public ActionResult ReceiveOrderResult(string XMLData)
        {
            //這裡的接收到的字串會有"+"變成空白的問題，導致解密解成空白
            string decryXmlData = "";

            if (XMLData != null)
            {
                XMLData = XMLData.Replace(" ", "+");
                //decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(ConfigService.MerchantHashKey, ConfigService.MerchantHashIV, XMLData);

                //string AllPayHashKey = "dfNqKZbfPOe7aqUN";
                //string AllPayHashIV = "smf8MjZrd1uwT8Op";

                string AllPayHashKey = stageHashKey;
                string AllPayHashIV = stageHashIv;

                decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(AllPayHashKey, AllPayHashIV, XMLData);


            }

            string fileName = Server.MapPath("~/App_Data/ReceiveNotify/PaidNotify/付款通知_") + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(HttpUtility.UrlDecode(decryXmlData)).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(fileName, fileContent.ToString(), true);

            ViewBag.decryptXML = decryXmlData;
            return View();
        }

        /// <summary>
        /// Client端接收頁
        /// </summary>   
        public ActionResult ReceiveBackUrlResult(string XMLData, string RtnData)
        {
            //這裡的接收到的字串會有"+"變成空白的問題，導致解密解成空白
            string decryXmlData = "";

            if (XMLData != null)
            {
                XMLData = XMLData.Replace(" ", "+");
                decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(devHashKey, devHashIv, XMLData);
            }

            string fileName = Server.MapPath("~/App_Data/ReceiveNotify/PaidNotify/付款通知_") + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(HttpUtility.UrlDecode(decryXmlData)).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(fileName, fileContent.ToString(), true);

            ViewBag.ReturnData = "成功回到BackURL";
            ViewBag.XmlData = HttpUtility.UrlDecode(decryXmlData);
            return View();
        }
    }
}
