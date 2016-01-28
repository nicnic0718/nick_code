using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPayWebServiceTest.Models.ViewModel;
using System.Configuration;
using System.Collections;
using AllPayWebServiceTest.Service;
using System.Text;
using AllPayWebServiceTest.DevAllpayWs;
using AllPayWebServiceTest.AllPaysharedws;

namespace AllPayWebServiceTest.Controllers
{
    [AllPayMockMethod]
    public class AllPayPaymentController : BaseController
    {
        //
        // GET: /AllPayPayment/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetMerchantHashKey()
        {
            try
            {
                long mid = 1000179;
                //### 透過WebService取得Key與IV
                ApiWS.ApiWSSoapClient WS = new ApiWS.ApiWSSoapClient();
                ApiWS.AllPayMerchantFunction merchantFunction = WS.GetAllPayMerchantFunctionByMerchant(mid);

                Dictionary<string, string> postCollection = new Dictionary<string, string>();
                postCollection.Add("MerchantID", mid.ToString());
                postCollection.Add("XMLData", "tXrjXcgaYAHCE4QIKuDAcuuDKprFV0kXfIrsUWk45RvnYGwXPOkoG8/PHVkUnZvhmzcnceccITG43H1PwnWctlVL43s7Aow8HU8HJmYiuI/Q/MaWX+5yd1zGhuhKMzR/wpJzjEzYyn9ZBErGru+4W69aEHQg/LheV2Yl5Ln0DiP8SKpSiZZPCge2vULAMJYvMlf9qfa5Dhd7x3uuf8BirnCSg6MxIMBnaftx7B2HjCQi+gQeo9n4cJ9JUucWHf3BWgRyTGgPeLF/kxfWEjXmkcpsSEfDqxeFUEQzt7PjHmmqqCUd8Kg5VDJmdBo3Rrz9iMtd3MpV4vAj5I4aIttfGdW4PYCJSmzC4jpopQOD7mRyCwX5iFFfN6hGgSYKvBzxhAvoPQ6/8SYaInS/nvvjzawEYjEC7OWjJFZx0InLAKPA6Wr1q8nG0SZXocvt+HtTi8prBepMiZTYwyaJYCXKZQ==");

                Hashtable RequestTable = new Hashtable();

                foreach (var item in postCollection)
                {
                    RequestTable.Add(item.Key, item.Value);

                }


                //### 發送到Mp, 取得Response
                string ServerResponse = DoRequest("http://payment-stage.allpay.com.tw/cashier/OrderChangeConfirm", RequestTable);

                ViewBag.SendResult = ServerResponse;

                return null;
            }
            catch (Exception e)
            {              
                throw e;
            }
        }

        /// <summary>
        /// 模擬廠商通知AllPay出貨狀態
        /// </summary>
        /// <returns></returns>
        public ActionResult SendDeliveryNotify() {
            
            long merchantId = 1000070;   //測試機目前給企劃測試的特店id是1000070

            int tradeQuantity = 2;
            string ShippingState = "5";  // 5:出貨 / 6:無貨可出 / 7:延遲出貨

            Trade trade = new Trade();
            
            //測試用資料
            //TradeNo
            trade.TradeNo.AllPayTradeNo = "";

            //TradeDetail
            trade.TradeDetail.MerchantID = merchantId;
            trade.TradeDetail.MerchantTradeNo = "";
            trade.TradeDetail.CharSet = "utf-8";
            trade.TradeDetail.Remark = "出貨通知測試-" + merchantId;

            for (int i = 1; i <= tradeQuantity; i++)
            {
                //TradeItemsDetail
                TradeItemsDetail tradeItemsDetailA = new TradeItemsDetail();
                tradeItemsDetailA.ItemNo = "A00" + i;
                tradeItemsDetailA.ShippingState = ShippingState;
                tradeItemsDetailA.ShippingDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                trade.TradeItemsDetailList.Add(tradeItemsDetailA);
            }

            return View(trade);

        }

        [HttpPost]
        public ActionResult SendDeliveryNotify(Trade trade)
        {
            string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            string testHashIv = "WkSfnqIaHLbUMV5X";
            string XMLData = "";

            if (1000070 == trade.TradeDetail.MerchantID)
            {

            }
            else if (1000139 == trade.TradeDetail.MerchantID)
            {
                testHashKey = "Zf1AjVRlwE4XjlF9";         
                testHashIv = "Ps8hPWGtUW0PE3Gk";
            }
           

            string createTradePostDomain = ConfigurationManager.AppSettings["AllPayPaymentDomain"].ToString();
            string postUrl = createTradePostDomain + "/cashier/DeliveryState";  //接收通知出貨的網址


            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + trade.TradeDetail.MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + trade.TradeDetail.MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + trade.TradeNo.AllPayTradeNo + "</TradeNo>";
            XMLData += "<EncodeChartset>" + trade.TradeDetail.CharSet + "</EncodeChartset>";
            XMLData += "<Remark>" + trade.TradeDetail.Remark + "</Remark>";

            foreach (TradeItemsDetail tradeItemsDetail in trade.TradeItemsDetailList)
            {
                XMLData += "<ItemData>";
                XMLData += "<ItemNo>" + tradeItemsDetail.ItemNo + "</ItemNo>";
                XMLData += "<ShippingState>" + tradeItemsDetail.ShippingState + "</ShippingState>";
                XMLData += "<ShippingDate>" + tradeItemsDetail.ShippingDate + "</ShippingDate>";
                XMLData += "</ItemData>";
            }
                        
            XMLData += "</Data>";
            XMLData += "</Root>";

            //### 將XML透過AES加密
            string encryXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(testHashKey, testHashIv, XMLData);

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", trade.TradeDetail.MerchantID.ToString());
            postCollection.Add("XMLData", encryXMLData);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }

                            
            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.SendResult = ServerResponse;

            return View("SendDeliveryNotify_Receive");
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
                decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt("ejCk326UnaZWKisg", "q9jcZX8Ib9LM8wYk", XMLData);
            }

            string fileName = Server.MapPath("~/App_Data/ReceiveNotify/PaidNotify/付款通知_") + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(HttpUtility.UrlDecode(decryXmlData)).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(fileName, fileContent.ToString(), true);

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
                decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(ConfigService.MerchantHashKey, ConfigService.MerchantHashIV, XMLData);
            }

            string fileName = Server.MapPath("~/App_Data/ReceiveNotify/PaidNotify/付款通知_") + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(HttpUtility.UrlDecode(decryXmlData)).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(fileName, fileContent.ToString(), true);

            ViewBag.ReturnData = "成功回到BackURL";
            ViewBag.XmlData = HttpUtility.UrlDecode(decryXmlData);

            //return View();
            return Content("1|OK");
        }


        /// <summary>
        /// 退貨/換貨/取消訂單的接收頁
        /// </summary>
        public ActionResult OrderStateChangeReceive(string XMLData)
        {
            //這裡的接收到的字串會有"+"變成空白的問題，導致解密解成空白
            string decryXmlData = "";

            string fileName = Server.MapPath("~/App_Data/ReceiveNotify/OrderChangeNotify/退換貨取消通知_") + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(XMLData).AppendLine();
            fileContent.AppendLine();

            if (XMLData != null)
            {
                XMLData = XMLData.Replace(" ", "+");
                decryXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(ConfigService.MerchantHashKey, ConfigService.MerchantHashIV, XMLData);
            }



            fileContent.Append("log create time:").Append(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")).AppendLine();
            fileContent.Append("XML data:").Append(HttpUtility.UrlDecode(decryXmlData)).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(fileName, fileContent.ToString(), true);

            return View();
        }

   
        /// <summary>
        /// 模擬廠商通知AllPay訂單的退換貨狀態
        /// </summary>
        /// <returns></returns>
        public ActionResult SendOrderChangeNotify()
        {
            string realIP = new AllPay.ShareLib.Network().GetRemoteRealIP();

            long merchantId = 1000070;   //測試機目前給企劃測試的特店id是1000070

            int tradeQuantity = 2;
            string ShippingState = "1";  // 1:退貨通知 / 2:換貨通知 / 3:取消訂單

            Trade trade = new Trade();

            //測試用資料
            //TradeNo
            trade.TradeNo.AllPayTradeNo = "";

            //TradeDetail
            trade.TradeDetail.MerchantID = merchantId;
            trade.TradeDetail.MerchantTradeNo = "";
            trade.TradeDetail.CharSet = "utf-8"; 

            for (int i = 1; i <= tradeQuantity; i++)
            {
                //TradeItemsDetail
                TradeItemsDetail tradeItemsDetailA = new TradeItemsDetail();
                tradeItemsDetailA.ItemNo = "A00" + i;
                tradeItemsDetailA.SubTotalAMT = 5;
                tradeItemsDetailA.ShippingState = ShippingState;
                tradeItemsDetailA.VendorReplyStatus = "1";
                
                trade.TradeItemsDetailList.Add(tradeItemsDetailA);
            }

            return View(trade);

        }

        [HttpPost]
        public ActionResult SendOrderChangeNotify(Trade trade)
        {
            string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            string testHashIv = "WkSfnqIaHLbUMV5X";
            string XMLData = "";

            if (1000070 == trade.TradeDetail.MerchantID)
            {

            }
            else if (1000139 == trade.TradeDetail.MerchantID)
            {
                testHashKey = "Zf1AjVRlwE4XjlF9";
                testHashIv = "Ps8hPWGtUW0PE3Gk";
            }


            string createTradePostDomain = ConfigurationManager.AppSettings["AllPayPaymentDomain"].ToString();
            string postUrl = createTradePostDomain + "/cashier/OrderChangeConfirm";  //接收通知退換貨的網址


            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + trade.TradeDetail.MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + trade.TradeDetail.MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + trade.TradeNo.AllPayTradeNo + "</TradeNo>";
            XMLData += "<EncodeChartset>" + trade.TradeDetail.CharSet + "</EncodeChartset>";


            foreach (TradeItemsDetail tradeItemsDetail in trade.TradeItemsDetailList)
            {
                if (!string.IsNullOrEmpty(tradeItemsDetail.ItemNo))
                {
                    XMLData += "<ItemData>";
                    XMLData += "<ItemNo>" + tradeItemsDetail.ItemNo + "</ItemNo>";
                    XMLData += "<Amount>" + tradeItemsDetail.SubTotalAMT + "</Amount>";
                    XMLData += "<InfoType>" + tradeItemsDetail.ShippingState + "</InfoType>";
                    XMLData += "<ConfirmState>" + tradeItemsDetail.VendorReplyStatus + "</ConfirmState>";
                    XMLData += "<Remark>" + HttpUtility.UrlEncode("退換貨通知測試") + "</Remark>";
                    XMLData += "</ItemData>";                    
                }
               
            }

            XMLData += "</Data>";
            XMLData += "</Root>";

            //### 將XML透過AES加密
            string encryXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(testHashKey, testHashIv, XMLData);

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", trade.TradeDetail.MerchantID.ToString());
            postCollection.Add("XMLData", encryXMLData);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.SendResult = ServerResponse;

            return View("SendOrderChangeNotify_Receive");
        }

        /// <summary>
        /// 玉山實名認證-餘額查詢交易
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdEsunAllPayQueryBalance() {

            //正式環境的查詢
            AllPayEsunPaymentService.PayServiceClient esunPaymentService = new AllPayEsunPaymentService.PayServiceClient();

            //string VaccNo = "98608220709816"; //OMG的虛擬帳戶;
            string VaccNo = "98608513536609";
            string QueryDateTime = DateTime.Now.ToString("yyyyMMddHHss");
            string HashKey = "pkwefio28o23jklw4924jlzf92023kf9";

            //產生驗證碼
            StringBuilder shaPara = new StringBuilder();
            shaPara.Append(VaccNo);
            shaPara.Append(QueryDateTime);
            shaPara.Append(HashKey);
            string identifyNo = new AllPay.ShareLib.Crypt().SHA(shaPara.ToString());

            var reponseResult = esunPaymentService.Balance(VaccNo,QueryDateTime,identifyNo);

            return null;
        }

        /// <summary>
        /// 玉山實名認證-圈存交易
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdEsunAllPayTrans() {

            string memberVirtualAccount = "98608220709816";
            int tradeAmount = 5;
            string HashKey = "pkwefio28o23jklw4924jlzf92023kf9";

            //產生驗證碼
            StringBuilder shaPara = new StringBuilder();
            shaPara.Append(memberVirtualAccount);
            shaPara.Append(tradeAmount);
            shaPara.Append(HashKey);
            string identifyNo = new AllPay.ShareLib.Crypt().SHA(shaPara.ToString());

            AllPayEsunPaymentService.PayServiceClient esunPaymentService = new AllPayEsunPaymentService.PayServiceClient();
            var esunTransResponse = esunPaymentService.Trans(memberVirtualAccount, tradeAmount, identifyNo);

            return null;
        }

        /// <summary>
        /// 玉山實名認證-解圈退貨
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdEsunAllPayReject()
        {

            //正式環境的查詢
            AllPayEsunPaymentService.PayServiceClient esunPaymentService = new AllPayEsunPaymentService.PayServiceClient();

            string VaccNo = "98608218458640";
            int unLockAmount = 5;
            string HashKey = "pkwefio28o23jklw4924jlzf92023kf9";

            //產生驗證碼
            StringBuilder shaPara = new StringBuilder();
            shaPara.Append(VaccNo);
            shaPara.Append(unLockAmount);
            shaPara.Append(HashKey);
            string identifyNo = new AllPay.ShareLib.Crypt().SHA(shaPara.ToString());

            var reponseResult = esunPaymentService.Reject(VaccNo, unLockAmount, identifyNo);

            return null;
        }

        /// <summary>
        /// 玉山實名認證-解圈轉帳
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdEsunAllPayTransFree()
        {

            //正式環境的查詢
            AllPayEsunPaymentService.PayServiceClient esunPaymentService = new AllPayEsunPaymentService.PayServiceClient();

            string VaccNo = "98608513536609"; //"98608218458640";
            int unLockAmount = 7;
            string inVaccNo = "98608220709816";  // "98608220711017";
            int inAmount = 7;
            int Fee = 0;
            string HashKey = "pkwefio28o23jklw4924jlzf92023kf9";

            //產生驗證碼
            StringBuilder shaPara = new StringBuilder();
            shaPara.Append(VaccNo);
            shaPara.Append(unLockAmount);
            shaPara.Append(HashKey);
            string identifyNo = new AllPay.ShareLib.Crypt().SHA(shaPara.ToString());

            var reponseResult = esunPaymentService.TransFree(VaccNo, unLockAmount,inVaccNo, inAmount, Fee, identifyNo);

            return null;
        }

        /// <summary>
        /// 開發環境訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult DevQueryTrade() {
            string MerchantID = "1000070";
            string MerchantTradeNo = "";

            ViewBag.MerchantID = MerchantID;
            ViewBag.MerchantTradeNo = MerchantTradeNo;

            return View();
        }

        [HttpPost]
        public ActionResult DevQueryTrade(string MerchantID, string MerchantTradeNo) {

            DevAllpayWs.AllPaySoapClient ws = new DevAllpayWs.AllPaySoapClient();

            string HashKey = "fugvqTnG3ROx81MO";        //開發
            string HashIV = "WkSfnqIaHLbUMV5X";

            //string stageHashKey = "Zf1AjVRlwE4XjlF9";        //stage
            //string stageHashIv = "Ps8hPWGtUW0PE3Gk";

            
            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();


            string XML = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>{0}</MerchantID><MerchantTradeNo>{1}</MerchantTradeNo><TimeStamp>{2}</TimeStamp></Data></Root>", MerchantID, MerchantTradeNo, TimeStamp);
            string EnXML = new AllPay.ShareLib.Crypt().AES_EnCrypt(HashKey, HashIV, XML);
            string Result = ws.QueryTrade(MerchantID, EnXML);
            string DeXML = new AllPay.ShareLib.Crypt().AES_DeCrypt(HashKey, HashIV, Result);

            ViewBag.Result = HttpUtility.UrlDecode(DeXML);
            return View("DevQueryTrade_Receive");
        
        
        }

        /// <summary>
        /// stage訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult StageQueryTrade()
        {
            string MerchantID = "1000139";
            string MerchantTradeNo = "";

            ViewBag.MerchantID = MerchantID;
            ViewBag.MerchantTradeNo = MerchantTradeNo;

            return View();
        }


        [HttpPost]
        public ActionResult StageQueryTrade(string MerchantID, string MerchantTradeNo)
        {

            StageAllpayWs.AllPaySoapClient ws = new StageAllpayWs.AllPaySoapClient();

            string HashKey = "Zf1AjVRlwE4XjlF9";        //stage
            string HashIV = "Ps8hPWGtUW0PE3Gk";


            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();


            string XML = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>{0}</MerchantID><MerchantTradeNo>{1}</MerchantTradeNo><TimeStamp>{2}</TimeStamp></Data></Root>", MerchantID, MerchantTradeNo, TimeStamp);
            string EnXML = new AllPay.ShareLib.Crypt().AES_EnCrypt(HashKey, HashIV, XML);
            string Result = ws.QueryTrade(MerchantID, EnXML);
            string DeXML = new AllPay.ShareLib.Crypt().AES_DeCrypt(HashKey, HashIV, Result);

            ViewBag.Result = HttpUtility.HtmlDecode(DeXML);
            return View("StageQueryTrade_Receive");


        }

        /// <summary>
        /// 測試stage的post版訂單查詢
        /// </summary>        
        public ActionResult StageQueryPostTrade()
        {

            StageAllpayWs.AllPaySoapClient ws = new StageAllpayWs.AllPaySoapClient();

            //string testHashKey = "yWsdQjr33vV7IFw1";         //for beta:888888889
            //string testHashIv = "6vvUZQaZXm11GATD";
            //string MerchantID = "888888889";

            //string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            //string testHashIv = "WkSfnqIaHLbUMV5X";
            //string MerchantID = "1000070";

            string testHashKey = "A123456789012345";         //for stage:999990001
            string testHashIv = "B123456789012345";
            string MerchantID = "999990001";

            //string testHashKey = "B12prXew9mbTySf5";         //for prod:999990001
            //string testHashIv = "VCUrz5Tyda0gpqPN";
            //string MerchantID = "999990001";

            string MerchantTradeNo = "13081209216343";

            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

             string postData = "&MerchantID=" + MerchantID                            
                            + "&MerchantTradeNo=" + MerchantTradeNo                          
                            + "&TimeStamp=" + TimeStamp;

                        
            string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=" + testHashKey + postData + "&HashIV=" + testHashIv);            
            string md5DataToLower = lowerDataToUrlEncode.ToLower();
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(md5DataToLower);

            string Result = ws.QueryTradeInfo(MerchantID, MerchantTradeNo, Convert.ToInt32(TimeStamp), CheckMacValue);


            ViewBag.Result = Result;
            return View("StageQueryTrade_Receive");


        }


        /// <summary>
        /// 測試stage的post版訂單查詢
        /// </summary>        
        public ActionResult StageQueryPostTrade_2()
        {
                      

            //string testHashKey = "yWsdQjr33vV7IFw1";         //for beta:888888889
            //string testHashIv = "6vvUZQaZXm11GATD";
            //string MerchantID = "888888889";

            //string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            //string testHashIv = "WkSfnqIaHLbUMV5X";
            //string MerchantID = "1000070";

            string testHashKey = "A123456789012345";         //for stage:999990001
            string testHashIv = "B123456789012345";
            string MerchantID = "999990001";
            string postUrl = "http://payment-stage.allpay.com.tw/Cashier/QueryTradeInfo";
            //string postUrl = "http://devpayment.allpay.com.tw:12005/Cashier/QueryTradeInfo";

            //string testHashKey = "B12prXew9mbTySf5";         //for prod:999990001
            //string testHashIv = "VCUrz5Tyda0gpqPN";
            //string MerchantID = "999990001";

            string MerchantTradeNo = "13081209216343"; 

            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

            string postData = "&MerchantID=" + MerchantID
                           + "&MerchantTradeNo=" + MerchantTradeNo
                           + "&TimeStamp=" + TimeStamp;


            string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=" + testHashKey + postData + "&HashIV=" + testHashIv);
            string md5DataToLower = lowerDataToUrlEncode.ToLower();
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(md5DataToLower);

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", MerchantID);
            postCollection.Add("MerchantTradeNo", MerchantTradeNo);
            postCollection.Add("TimeStamp", TimeStamp);
            postCollection.Add("CheckMacValue", CheckMacValue);
           
            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }


            
            
            //TempData["PostCollection"] = postCollection;
            //TempData["PostURL"] = postUrl;

            //return RedirectToAction("AutoSubmitForm", "Common");

            ////### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.Result = ServerResponse;
            return View("StageQueryTrade_Receive");


        }

        //public ActionResult testProdSms() {
        //    AllPaySharedWSSoapClient WS = new AllPaySharedWSSoapClient();
        //    string RtnCode = WS.SendSMS("0958389636", "matt test", 0);

        //    return View();
        //}


        /// <summary>
        /// 測試簡易API的商品異常處理通知
        /// </summary>
        /// <returns></returns>
        public ActionResult TestOrderChangeNotify()
        {

            //string testHashKey = "yWsdQjr33vV7IFw1";         //for beta:888888889
            //string testHashIv = "6vvUZQaZXm11GATD";
            //string MerchantID = "888888889";

            string testHashKey = "0xurqKTafMeETeB9";         //for stage:2000031
            string testHashIv = "DXn12MB9Qa9pBpsj";
            string MerchantID = "2000031";

            string MerchantTradeNo = "130626204228130";
            string TradeNo = "1306262042286797";
            string InfoType = "1";      //1:退部份金額/2:退全部金額/3:換貨後已重新出貨/4:商品無異常
            string RefundAmount = "10";
            string Remark = "matt";

            string postData = "&InfoType=" + InfoType + "&MerchantID=" + MerchantID + "&MerchantTradeNo=" + MerchantTradeNo + "&RefundAmount=" + RefundAmount + "&Remark=" + Remark + "&TradeNo=" + TradeNo;
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5("HashKey=" + testHashKey + postData + "&HashIV=" + testHashIv);

            
            string createTradePostDomain = ConfigurationManager.AppSettings["AllPayPaymentDomain"].ToString();
            //string postUrl = createTradePostDomain + "/cashier/OrderChangeNotify";  //接收商品異常訂單結果通知網址
            string postUrl =  "http://payment-stage.allpay.com.tw/cashier/OrderChangeNotify";
                        
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", MerchantID);
            postCollection.Add("MerchantTradeNo", MerchantTradeNo);
            postCollection.Add("TradeNo", TradeNo);
            postCollection.Add("InfoType", InfoType);
            postCollection.Add("RefundAmount", RefundAmount);
            postCollection.Add("Remark", Remark);
            postCollection.Add("CheckMacValue", CheckMacValue);    
            
            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.SendResult = ServerResponse;

            return View("SendDeliveryNotify_Receive");

        }


        /// <summary>
        /// 測試使用PaymentType = pay的方式建立訂單
        /// (無履約，但要登入會員)
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPayCreateOrder()
        {

            //string testHashKey = "yWsdQjr33vV7IFw1";         //for beta:888888889
            //string testHashIv = "6vvUZQaZXm11GATD";
            //string MerchantID = "888888889";

            //string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            //string testHashIv = "WkSfnqIaHLbUMV5X";
            //string MerchantID = "1000070";

            //string testHashKey = "A123456789012345";         //for stage:999990001
            //string testHashIv = "B123456789012345";
            //string MerchantID = "999990004";

            //string testHashKey = "B12prXew9mbTySf5";         //for prod:999990001
            //string testHashIv = "VCUrz5Tyda0gpqPN";
            //string MerchantID = "999990001";


            //string testHashKey = "B12prXew9mbTySf5";         //for prod:1031342
            //string testHashIv = "VCUrz5Tyda0gpqPN";
            //string MerchantID = "1031342";

            string testHashKey = "SM6zZHQvodchMaTk";         //for prod:888891 
            string testHashIv = "zf3MhCfhzwUZoGfi";
            string MerchantID = "888891";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string PaymentType = "pay";
            string TotalAmount = "35";
            //string TradeDesc = "支付寶卡面額人民幣(CNY)100元X2張+支付寶卡面額人民幣(CNY)500元X1張";
            //string ItemName = "支付寶卡面額人民幣(CNY)100元X2張+支付寶卡面額人民幣(CNY)500元X1張";
            string TradeDesc = "BOX1_Online_Shop";
            string ItemName = "M-02";
            string ReturnURL = "http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/TestReceivePayResult";
            string Remark = "matt";
            string ClientBackURL = "http://www.allpay.com.tw";                                
            string Currency = "CNY";
            string ExchangeRate = "2.0";
            string BuyerChargeFee = "0";
            //string ChoosePayment = "TopUpUsed_AllPay";
            //string ChoosePayment = "TopUpUsed_ESUN";
            string ChoosePayment = "CVS";
            string ChooseSubPayment = "";
            string OrderCreateNotifyURL = "http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult";

            string postData = "&BuyerChargeFee=" + BuyerChargeFee
                            + "&ChoosePayment=" + ChoosePayment
                            + "&ChooseSubPayment=" + ChooseSubPayment
                            + "&ClientBackURL=" + ClientBackURL                            
                            + "&Currency=" + Currency
                            + "&ExchangeRate=" + ExchangeRate
                            + "&ItemName=" + ItemName
                            + "&MerchantID=" + MerchantID
                            + "&MerchantTradeDate=" + MerchantTradeDate
                            + "&MerchantTradeNo=" + MerchantTradeNo
                            //+ "&OrderCreateNotifyURL=" + OrderCreateNotifyURL
                            + "&PaymentType=" + PaymentType
                            //+ "&Remark=" + Remark
                            + "&ReturnURL=" + ReturnURL
                            + "&TotalAmount=" + TotalAmount
                            + "&TradeDesc=" + TradeDesc;

                        
            string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=" + testHashKey + postData + "&HashIV=" + testHashIv);
            //string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=NkeqESxlDNONHVIp&AlipayItemCounts=2#1&AlipayItemName=電子鍋#皮衣&AlipayItemPrice=100#250&CheckMacValue=&ChoosePayment=ATM&ClientBackURL=http://vmall2.sunup.net/&CreditInstallment=3&Desc_4=付款完請保留繳費收据&Email=over.chang@allpay.com.tw&ExpireDate=3&ExpireTime=2013/11/07+17:45:35&InstallmentAmount=150&ItemName=A001商品001+100元x2#A002商品002+100元x2#&MerchantID=1012077&MerchantTradeDate=2013/11/04+17:44:47&MerchantTradeNo=1383557665&PaymentType=aio&PhoneNo=0919253377&ReturnURL=http://vmall2.sunup.net/ecart/allpay_bk_roturl.php&TotalAmount=100&TradeDesc=anow購物商城&UserName=張虔銘&HashIV=pMXD78k3iwaTpO2v");
            string md5DataToLower = lowerDataToUrlEncode.ToLower();
            //md5DataToLower = "hashkey%3dnkeqesxldnonhvip%26alipayitemcounts%3d2%231%26alipayitemname%3d%e9%9b%bb%e5%ad%90%e9%8d%8b%23%e7%9a%ae%e8%a1%a3%26alipayitemprice%3d100%23250%26choosepayment%3datm%26clientbackurl%3dhttp%3a%2f%2fvmall2.sunup.net%2f%26creditinstallment%3d3%26desc_4%3d%e4%bb%98%e6%ac%be%e5%ae%8c%e8%ab%8b%e4%bf%9d%e7%95%99%e7%b9%b3%e8%b2%bb%e6%94%b6%e6%8d%ae%26email%3dover.chang%40allpay.com.tw%26expiredate%3d3%26expiretime%3d2013%2f11%2f07%2b17%3a45%3a35%26installmentamount%3d150%26itemname%3da001%e5%95%86%e5%93%81001%2b100%e5%85%83x2%23a002%e5%95%86%e5%93%81002%2b100%e5%85%83x2%23%26merchantid%3d1012077%26merchanttradedate%3d2013%2f11%2f04%2b17%3a44%3a47%26merchanttradeno%3d1383557665%26paymenttype%3daio%26phoneno%3d0919253377%26returnurl%3dhttp%3a%2f%2fvmall2.sunup.net%2fecart%2fallpay_bk_roturl.php%26totalamount%3d100%26tradedesc%3danow%e8%b3%bc%e7%89%a9%e5%95%86%e5%9f%8e%26username%3d%e5%bc%b5%e8%99%94%e9%8a%98%26hashiv%3dpmxd78k3iwatpo2v";
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(md5DataToLower);            

            string createTradePostDomain = ConfigurationManager.AppSettings["AllPayPaymentDomain"].ToString();

            //string postUrl = "http://devpayment.allpay.com.tw:12005/cashier/checkout";
            //string postUrl = "http://payment-stage.allpay.com.tw/cashier/checkout";
            string postUrl = "https://payment.allpay.com.tw/cashier/checkout";
            //string postUrl = "http://test-alicard.allpay.com.tw/main/payment_gateway/trade_notify_page";

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("BuyerChargeFee", BuyerChargeFee);
            postCollection.Add("Currency", Currency);
            postCollection.Add("ChoosePayment", ChoosePayment);
            postCollection.Add("ChooseSubPayment", ChooseSubPayment);
            postCollection.Add("ExchangeRate", ExchangeRate);
            postCollection.Add("MerchantID", MerchantID);
            postCollection.Add("MerchantTradeNo", MerchantTradeNo);
            postCollection.Add("MerchantTradeDate", MerchantTradeDate);            
            postCollection.Add("PaymentType", PaymentType);
            postCollection.Add("TotalAmount", TotalAmount);
            postCollection.Add("TradeDesc", TradeDesc);
            postCollection.Add("ItemName", ItemName);
            postCollection.Add("ReturnURL", ReturnURL);
            //postCollection.Add("Remark", Remark);
            //postCollection.Add("OrderCreateNotifyURL", OrderCreateNotifyURL);
            postCollection.Add("ClientBackURL", ClientBackURL);
            postCollection.Add("CheckMacValue", CheckMacValue);
            

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postUrl;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        /// <summary>
        /// 測試使用PaymentType = pay的方式退款        
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPayChargeBack()
        {

            //string testHashKey = "yWsdQjr33vV7IFw1";         //for beta:888888889
            //string testHashIv = "6vvUZQaZXm11GATD";
            //string MerchantID = "888888889";

            //string testHashKey = "fugvqTnG3ROx81MO";         //for 1000070
            //string testHashIv = "WkSfnqIaHLbUMV5X";
            //string MerchantID = "1000070";

            //string testHashKey = "A123456789012345";         //for stage:999990001
            //string testHashIv = "B123456789012345";
            //string MerchantID = "999990004";

            //string testHashKey = "B12prXew9mbTySf5";         //for prod:999990001
            //string testHashIv = "VCUrz5Tyda0gpqPN";
            //string MerchantID = "999990001";


            string testHashKey = "LYTAue8Hm0CotSnO";         //for prod:1031095
            string testHashIv = "wyyA9QEilAqGE9di";
            string MerchantID = "1031095";

            //string testHashKey = "SM6zZHQvodchMaTk";         //for prod:888891 
            //string testHashIv = "zf3MhCfhzwUZoGfi";
            //string MerchantID = "888891";


            string MerchantTradeNo = "2106";
            string allpayTradeNo = "1311120453580056";
            string ChargeBackTotalAmount = "990";
                       
            string Remark = "allpay fix";
          
       
            string postData = "&ChargeBackTotalAmount=" + ChargeBackTotalAmount                    
                            + "&MerchantID=" + MerchantID                        
                            + "&MerchantTradeNo=" + MerchantTradeNo
                            + "&Remark=" + Remark
                            + "&TradeNo=" + allpayTradeNo;


            string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=" + testHashKey + postData + "&HashIV=" + testHashIv);
            
            string md5DataToLower = lowerDataToUrlEncode.ToLower();
            
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(md5DataToLower);

            string createTradePostDomain = ConfigurationManager.AppSettings["AllPayPaymentDomain"].ToString();

            //string postUrl = "http://devpayment.allpay.com.tw:12005/cashier/Chargeback";
            //string postUrl = "http://payment-stage.allpay.com.tw/cashier/Chargeback";
            string postUrl = "https://payment.allpay.com.tw/cashier/Chargeback";
            

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("ChargeBackTotalAmount", ChargeBackTotalAmount);         
            postCollection.Add("MerchantID", MerchantID);
            postCollection.Add("MerchantTradeNo", MerchantTradeNo);
            postCollection.Add("TradeNo", allpayTradeNo);
            postCollection.Add("CheckMacValue", CheckMacValue);
            postCollection.Add("Remark", Remark);


            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postUrl;

            return RedirectToAction("AutoSubmitForm", "Common");

        }


        public ActionResult TestReceivePayResult()
        {

            string testHashKey = "A123456789012345";         //for stage:999990001
            string testHashIv = "B123456789012345";
            string MerchantID = "999990001";

            //這裡的接收到的字串會有"+"變成空白的問題，導致解密解成空白
            string decryXmlData = "";
                       

            return View();
        }


    }
}
