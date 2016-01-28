using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Threading;

namespace AllPayWebServiceTest.Controllers
{
    public class MockLogisticsController : BaseController
    {
        //
        // GET: /MockLogistics/

        public ActionResult Index()
        {
            return View();

        }
        ManualResetEvent _AllMonitorEvent = new ManualResetEvent(false);
        public ActionResult MultiLoogisticsCreateTrade()
        {
            //LogisticsCreateTrade();

            //for (int i = 0; i < 100; i++)
            //{
            //    Thread th = new Thread(new ThreadStart(LogisticsCreateTrade));
            //    th.IsBackground = true;
            //    th.Start();
            //}

            _AllMonitorEvent.Set();

            return Content("1|OK");
        }

        #region 物流產生訂單
        public ActionResult LogisticsCreateTrade()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1115550";
            //HashKey = "utmbJ4qrjFQkcOej";
            //HashIV = "IHWqBtkXMCIBzQXf";
            //string tradePostUrl = "http://logistics.allpay.com.tw/express/create";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/create";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            string MerchantID = "1003860";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/create";
            HashKey = "och1T1AWZPCGVlco";
            HashIV = "LsZ4KXo9ipCsltV0";

            //string MerchantID = "1060752";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/create";
            //HashKey = "JgszospxO4kYi6sF";
            //HashIV = "gyLMsCdaqQt9szOO";

            //string MerchantID = "1000139";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/create";
            ////HashKey = "koyqVBURmmkQxROZ";//"fugvqTnG3ROx81MO";
            ////HashIV = "BcRITiCQaUHBZC1f";//"WkSfnqIaHLbUMV5X";
            //HashKey = "Zf1AjVRlwE4XjlF9";
            //HashIV = "Ps8hPWGtUW0PE3Gk";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";
            //string MerchantID = "2000933";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "XBERn1YOvpM9nfZc";
            //HashIV = "h1ONHk4P4yqbl5LK";

            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "http://logistics.allpay.com.tw/express/create";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //string LogisticsType = "Home";      //CVS:超商取貨/Home:宅配/ALL:
            //string LogisticsSubType = "TCAT";   //

            string LogisticsType = "CVS";      //CVS:超商取貨/Home:宅配/ALL:
            string LogisticsSubType = "UNIMARTC2C";   //

            string GoodsAmount = "108";
            //string IsCollection = "N";      //是否代收貨款
            string CollectionAmount = "4000";
            string GoodsName = "測試商品";

            string SenderName = "陳尼克";
            string SenderPhone = "0975653378";
            string SenderCellPhone = "0975653378";

            string ReceiverName = "陳羽毛";
            string ReceiverPhone = "0975653378";
            string ReceiverCellPhone = "";// "0988123123";
            string ReceiverEmail = "nick.chen@allpay.com.tw";

            string TradeDesc = "";
            string ServerReplyURL = "http://logistics.allpay.com.tw/MockMerchant/NoticsTestRtn";
            string ClientReplyURL = "";

            string Remark = "";

            /************************/
            //宅配使用
            string SenderZipCode = "220";
            string SenderAddress = "台北市板橋區雙十路三段27號4樓之4";
            string ReceiverZipCode = "241";
            string ReceiverAddress = "新北市三重區三和路４段71巷36號4樓";
            string Temperature = "";
            string Distance = "";
            string Specification = "";
            string ScheduledPickupTime = "";
            string ScheduledDeliveryTime = "";

            /************************/
            //超商取貨使用
            string ReceiverStoreID = "991182";// "991182";//"001779";
            string ReturnStoreID = "";

            string LogisticsC2CReplyURL = "http://logistic.allpay.com.tw/MockMerchant/NoticsTestRtn";
            //string IsC2C = "Y";
            string PlatformID = "";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;

            //字串排序
            string[] strList = { 
                                   "MerchantID"
                                    ,"MerchantTradeNo"
                                    ,"MerchantTradeDate"
                                    ,"LogisticsType"
                                    ,"LogisticsSubType"
                                    ,"GoodsAmount"
                                    //,"IsCollection"
                                    ,"GoodsName"
                                    ,"SenderName"
                                    ,"SenderPhone"
                                    ,"SenderCellPhone"
                                    ,"ReceiverName"
                                    ,"ReceiverPhone"
                                    ,"ReceiverCellPhone"
                                    ,"ReceiverEmail"
                                    ,"TradeDesc"
                                    ,"ServerReplyURL"
                                    ,"ClientReplyURL"
                                    ,"Remark"
                                    ,"SenderZipCode"
                                    ,"SenderAddress"
                                    ,"ReceiverZipCode"
                                    ,"ReceiverAddress"
                                    ,"Temperature"
                                    ,"Distance"
                                    ,"Specification"
                                    ,"ScheduledPickupTime"
                                    ,"ScheduledDeliveryTime"
                                    ,"ReceiverStoreID"
                                    ,"ReturnStoreID"
                                    ,"LogisticsC2CReplyURL"
                                    ,"CollectionAmount"
                                    ,"PlatformID"
                                    //,"IsC2C"
                                };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "MerchantTradeNo":
                        strPost += "MerchantTradeNo=" + MerchantTradeNo + "&";//必填
                        break;
                    case "MerchantTradeDate":
                        strPost += "MerchantTradeDate=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "&";//必填
                        break;
                    case "LogisticsType":
                        strPost += "LogisticsType=" + LogisticsType + "&";
                        break;
                    case "LogisticsSubType":
                        strPost += "LogisticsSubType=" + LogisticsSubType + "&";
                        break;
                    case "GoodsAmount":
                        strPost += "GoodsAmount=" + GoodsAmount + "&";
                        break;
                    case "CollectionAmount":
                        strPost += "CollectionAmount=" + CollectionAmount + "&";
                        break;
                    case "IsCollection":
                        //strPost += "IsCollection=" + IsCollection + "&";
                        break;

                    case "GoodsName":
                        strPost += "GoodsName=" + GoodsName + "&";
                        break;

                    case "SenderName":
                        strPost += "SenderName=" + SenderName + "&";
                        break;

                    case "SenderPhone":
                        strPost += "SenderPhone=" + SenderPhone + "&";
                        break;

                    case "SenderCellPhone":
                        if (!string.IsNullOrWhiteSpace(SenderCellPhone))
                        {
                            strPost += "SenderCellPhone=" + SenderCellPhone + "&";
                        }
                        break;

                    case "ReceiverName":
                        strPost += "ReceiverName=" + ReceiverName + "&";
                        break;

                    case "ReceiverPhone":
                        if (!string.IsNullOrWhiteSpace(ReceiverPhone))
                        {
                            strPost += "ReceiverPhone=" + ReceiverPhone + "&";
                        }
                        break;

                    case "ReceiverCellPhone":
                        if (!string.IsNullOrWhiteSpace(ReceiverCellPhone))
                        {
                            strPost += "ReceiverCellPhone=" + ReceiverCellPhone + "&";
                        }
                        break;

                    case "ReceiverEmail":
                        if (!string.IsNullOrWhiteSpace(ReceiverEmail))
                        {
                            strPost += "ReceiverEmail=" + ReceiverEmail + "&";
                        }
                        break;

                    case "TradeDesc":
                        strPost += "TradeDesc=" + TradeDesc + "&";
                        break;
                    case "ServerReplyURL":
                        strPost += "ServerReplyURL=" + ServerReplyURL + "&";
                        break;
                    case "ClientReplyURL":
                        strPost += "ClientReplyURL=" + ClientReplyURL + "&";
                        break;
                    case "Remark":
                        strPost += "Remark=" + Remark + "&";
                        break;
                    case "SenderZipCode":
                        if (!string.IsNullOrWhiteSpace(SenderZipCode))
                        {
                            strPost += "SenderZipCode=" + SenderZipCode + "&";
                        }
                        break;

                    case "SenderAddress":
                        if (!string.IsNullOrWhiteSpace(SenderAddress))
                        {
                            strPost += "SenderAddress=" + SenderAddress + "&";
                        }
                        break;

                    case "ReceiverZipCode":
                        if (!string.IsNullOrWhiteSpace(ReceiverZipCode))
                        {
                            strPost += "ReceiverZipCode=" + ReceiverZipCode + "&";
                        }
                        break;

                    case "ReceiverAddress":
                        if (!string.IsNullOrWhiteSpace(ReceiverAddress))
                        {
                            strPost += "ReceiverAddress=" + ReceiverAddress + "&";
                        }
                        break;

                    case "Temperature":
                        if (!string.IsNullOrWhiteSpace(Temperature))
                        {
                            strPost += "Temperature=" + Temperature + "&";
                        }
                        break;

                    case "Distance":
                        if (!string.IsNullOrWhiteSpace(Distance))
                        {
                            strPost += "Distance=" + Distance + "&";
                        }
                        break;

                    case "Specification":
                        if (!string.IsNullOrWhiteSpace(Specification))
                        {
                            strPost += "Specification=" + Specification + "&";
                        }
                        break;

                    case "ScheduledPickupTime":
                        if (!string.IsNullOrWhiteSpace(ScheduledPickupTime))
                        {
                            strPost += "ScheduledPickupTime=" + ScheduledPickupTime + "&";
                        }
                        break;

                    case "ScheduledDeliveryTime":
                        if (!string.IsNullOrWhiteSpace(ScheduledDeliveryTime))
                        {
                            strPost += "ScheduledDeliveryTime=" + ScheduledDeliveryTime + "&";
                        }
                        break;

                    case "ReceiverStoreID":
                        if (!string.IsNullOrWhiteSpace(ReceiverStoreID))
                        {
                            strPost += "ReceiverStoreID=" + ReceiverStoreID + "&";
                        }
                        break;

                    case "ReturnStoreID":
                        if (!string.IsNullOrWhiteSpace(ReturnStoreID))
                        {
                            strPost += "ReturnStoreID=" + ReturnStoreID + "&";
                        }
                        break;

                    case "LogisticsC2CReplyURL":
                        strPost += "LogisticsC2CReplyURL=" + LogisticsC2CReplyURL + "&";
                        break;
                    case "PlatformID":
                        if (!string.IsNullOrWhiteSpace(PlatformID))
                        {
                            strPost += "PlatformID=" + PlatformID + "&";
                        }
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Hashtable PostDictionary = new Hashtable();
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("MerchantTradeNo", MerchantTradeNo);    //必填
            PostDictionary.Add("MerchantTradeDate", MerchantTradeDate);//必填
            PostDictionary.Add("LogisticsType", LogisticsType);//必填
            PostDictionary.Add("LogisticsSubType", LogisticsSubType);
            PostDictionary.Add("GoodsAmount", GoodsAmount);

            //PostDictionary.Add("IsCollection", IsCollection);
            PostDictionary.Add("GoodsName", GoodsName);
            PostDictionary.Add("SenderName", SenderName);
            PostDictionary.Add("SenderPhone", SenderPhone);
            if (!string.IsNullOrEmpty(SenderCellPhone))
            {
                PostDictionary.Add("SenderCellPhone", SenderCellPhone);
            }

            PostDictionary.Add("ReceiverName", ReceiverName);

            if (!string.IsNullOrEmpty(ReceiverPhone))
            {
                PostDictionary.Add("ReceiverPhone", ReceiverPhone);
            }

            if (!string.IsNullOrEmpty(ReceiverCellPhone))
            {
                PostDictionary.Add("ReceiverCellPhone", ReceiverCellPhone);
            }

            if (!string.IsNullOrEmpty(ReceiverEmail))
            {
                PostDictionary.Add("ReceiverEmail", ReceiverEmail);
            }

            PostDictionary.Add("TradeDesc", TradeDesc);
            PostDictionary.Add("ServerReplyURL", ServerReplyURL);
            PostDictionary.Add("ClientReplyURL", ClientReplyURL);
            PostDictionary.Add("Remark", Remark);

            if (!string.IsNullOrEmpty(SenderZipCode))
            {
                PostDictionary.Add("SenderZipCode", SenderZipCode);
            }
            if (!string.IsNullOrEmpty(SenderAddress))
            {
                PostDictionary.Add("SenderAddress", SenderAddress);
            }
            if (!string.IsNullOrEmpty(ReceiverZipCode))
            {
                PostDictionary.Add("ReceiverZipCode", ReceiverZipCode);
            }
            if (!string.IsNullOrEmpty(ReceiverAddress))
            {
                PostDictionary.Add("ReceiverAddress", ReceiverAddress);
            }
            if (!string.IsNullOrEmpty(Temperature))
            {
                PostDictionary.Add("Temperature", Temperature);
            } if (!string.IsNullOrEmpty(Distance))
            {
                PostDictionary.Add("Distance", Distance);
            }

            if (!string.IsNullOrEmpty(Specification))
            {
                PostDictionary.Add("Specification", Specification);

            } if (!string.IsNullOrEmpty(ScheduledPickupTime))
            {
                PostDictionary.Add("ScheduledPickupTime", ScheduledPickupTime);
            }

            if (!string.IsNullOrEmpty(ScheduledDeliveryTime))
            {
                PostDictionary.Add("ScheduledDeliveryTime", ScheduledDeliveryTime);
            }

            if (!string.IsNullOrEmpty(ReceiverStoreID))
            {
                PostDictionary.Add("ReceiverStoreID", ReceiverStoreID);
            }

            if (!string.IsNullOrEmpty(ReturnStoreID))
            {
                PostDictionary.Add("ReturnStoreID", ReturnStoreID);
            }
            PostDictionary.Add("CollectionAmount", CollectionAmount);

            PostDictionary.Add("LogisticsC2CReplyURL", LogisticsC2CReplyURL);

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            if (!string.IsNullOrEmpty(PlatformID))
            {
                PostDictionary.Add("PlatformID", PlatformID);
            }

            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            //RedirectToAction("AutoSubmitForm", "Common");
            //_AllMonitorEvent.WaitOne();
            string result = DoRequest(tradePostUrl, PostDictionary);
            //test++;
            WriteLogFileTrade(result, "CreateLogisticsTrade");

            return Content(result);
        }
        #endregion
        int test = 0;
        #region 紀錄廠商送來的參數text log
        /// <summary>
        /// 紀錄廠商送來的參數text log
        /// </summary>
        /// <param name="requestForm"></param>
        public void WriteLogFileTrade(string requestForm, string logName)
        {

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("RequestForm:").Append(requestForm).AppendLine();
            fileContent.Append("log建立時間:").Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).AppendLine();
            fileContent.AppendLine();

            new AllPay.ShareLib.File().WriteFile(GenLogFileNameTrade(logName), fileContent.ToString(), true);
        }

        /// <summary>
        /// 產生log檔名稱
        /// </summary>
        /// <returns></returns>
        private string GenLogFileNameTrade(string logName)
        {
            string fileRoot = "~/App_Data/";
            fileRoot = "D:\\Logistics\\Log\\";
            if (!Directory.Exists(fileRoot))
            {
                //新增資料夾
                Directory.CreateDirectory(fileRoot);
            }
            StringBuilder fileName = new StringBuilder();
            fileName.Append(fileRoot).Append(logName + "_").Append(DateTime.Now.ToString("yyyyMMdd")).Append(".txt");


            return fileName.ToString();
        }
        #endregion

        #region 全家逆物流
        public ActionResult LogisticsCreateRtnTrade()
        {
            /*
             * AllPayLogisticsID=10062&
             * CollectionAmount=0&
             * Cost=4#6&
             * GoodsAmount=10&
             * GoodsName=商品一#商品二&
             * MerchantID=2000132&
             * Quantity=1#1&
             * Remark=PAZZO測試退貨&
             * SenderName=Pazzo&
             * SenderPhone=0911222333&
             * ServerReplyURL=http://www.google.com&
             * ServiceType=5&
             * CheckMacValue=DCCD5C2B141C26A42F9DF6D762866773
             */


            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            string MerchantID = "1000070";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/ReturnCVS";
            HashKey = "koyqVBURmmkQxROZ";
            HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/ReturnCVS";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";
            //string MerchantID = "2000933";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/ReturnCVS";
            //HashKey = "XBERn1YOvpM9nfZc";
            //HashIV = "h1ONHk4P4yqbl5LK";

            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/express/ReturnCVS";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;

            string LogisticsID = "11448";
            string GoodsAmount = "1000";
            string GoodsName = "";
            string CollectionAmount = "0";
            string SenderName = "Luke";
            string SenderPhone = "0423109938";
            string Remark = "MB-0910310953";
            string Quantity = "";
            string Cost = "";
            string ServiceType = "4";
            string ServerReplyURL = "http://edshop.dev.donz.tw/wp-admin/admin-ajax.php?action=package_status_update";
            string PlatformID = "1000070";
            //字串排序
            string[] strList = { 
                                    "AllPayLogisticsID"
                                    ,"MerchantID"
                                    ,"GoodsAmount"
                                    ,"GoodsName"
                                    ,"CollectionAmount"
                                    ,"SenderName"
                                    ,"SenderPhone"
                                    ,"Remark"
                                    ,"Quantity"
                                    ,"Cost"
                                    ,"ServerReplyURL"
                                    ,"ServiceType"
                                    ,"PlatformID"
                                    
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + LogisticsID + "&";//必填
                        break;
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "GoodsAmount":
                        strPost += "GoodsAmount=" + GoodsAmount + "&";
                        break;
                    case "GoodsName":
                        if (!string.IsNullOrWhiteSpace(GoodsName))
                        {
                            strPost += "GoodsName=" + GoodsName + "&";
                        }
                        break;

                    case "CollectionAmount":
                        if (!string.IsNullOrWhiteSpace(CollectionAmount))
                        {
                            strPost += "CollectionAmount=" + CollectionAmount + "&";
                        }
                        break;

                    case "SenderName":
                        strPost += "SenderName=" + SenderName + "&";
                        break;

                    case "SenderPhone":
                        if (!string.IsNullOrWhiteSpace(SenderPhone))
                        {
                            strPost += "SenderPhone=" + SenderPhone + "&";
                        }
                        break;

                    case "Remark":
                        if (!string.IsNullOrWhiteSpace(Remark))
                        {
                            strPost += "Remark=" + Remark + "&";
                        }
                        break;


                    case "Quantity":
                        if (!string.IsNullOrWhiteSpace(Quantity))
                        {
                            strPost += "Quantity=" + Quantity + "&";
                        }
                        break;

                    case "Cost":
                        if (!string.IsNullOrWhiteSpace(Cost))
                        {
                            strPost += "Cost=" + Cost + "&";
                        }
                        break;

                    case "ServiceType":
                        if (!string.IsNullOrWhiteSpace(ServiceType))
                        {
                            strPost += "ServiceType=" + ServiceType + "&";
                        }
                        break;
                    case "ServerReplyURL":
                        strPost += "ServerReplyURL=" + ServerReplyURL + "&";
                        break;
                    case "PlatformID":
                        strPost += "PlatformID=" + PlatformID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", LogisticsID);    //必填
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填

            if (!string.IsNullOrEmpty(CollectionAmount))
            {
                PostDictionary.Add("CollectionAmount", CollectionAmount);
            }

            if (!string.IsNullOrEmpty(GoodsAmount))
            {
                PostDictionary.Add("GoodsAmount", GoodsAmount);
            }

            if (!string.IsNullOrEmpty(GoodsName))
            {
                PostDictionary.Add("GoodsName", GoodsName);
            }

            PostDictionary.Add("SenderName", SenderName);

            if (!string.IsNullOrEmpty(SenderPhone))
            {
                PostDictionary.Add("SenderPhone", SenderPhone);
            }

            if (!string.IsNullOrEmpty(Remark))
            {
                PostDictionary.Add("Remark", Remark);
            }

            PostDictionary.Add("ServiceType", ServiceType);

            if (!string.IsNullOrEmpty(Quantity))
            {
                PostDictionary.Add("Quantity", Quantity);
            }

            if (!string.IsNullOrEmpty(Cost))
            {
                PostDictionary.Add("Cost", Cost);
            }

            PostDictionary.Add("ServerReplyURL", ServerReplyURL);
            PostDictionary.Add("PlatformID", PlatformID);
            PostDictionary.Add("CheckMacValue", strCheckMacValue);


            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 全家逆物流退貨核帳
        public ActionResult LogisticsCheckAccounts()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/Helper/LogisticsCheckAccoounts";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            string MerchantID = "888891";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/Helper/LogisticsCheckAccoounts";
            HashKey = "SM6zZHQvodchMaTk";
            HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;

            string RtnMerchantTradeNo = "1407091415536";

            //字串排序
            string[] strList = {                                     
                                    "MerchantID"
                                    ,"RtnMerchantTradeNo"                           
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "RtnMerchantTradeNo":
                        strPost += "RtnMerchantTradeNo=" + RtnMerchantTradeNo + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("RtnMerchantTradeNo", RtnMerchantTradeNo);

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 統一超商B2C更新出貨日、門市資訊
        public ActionResult LogisticsUpdateShipmentInfo()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/Helper/UpdateShipmentInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/Helper/UpdateShipmentInfo";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";

            string MerchantID = "1115181";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/Helper/UpdateShipmentInfo";
            HashKey = "rc8j62KcvPvzHq7o";
            HashIV = "ZQg2u86RIRz7a5KQ";

            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/Helper/UpdateShipmentInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            //string MerchantID = "1143414";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/Helper/UpdateShipmentInfo";
            //HashKey = "p496t7u6FVnhtGb9";
            //HashIV = "gFbqGNG95JrbYmDs";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;

            string LogisticsID = "2086937";
            string ShipmentDate = "";
            string ReceiverStoreID = "896045";

            //字串排序
            string[] strList = {                                     
                                    "MerchantID"
                                    ,"AllPayLogisticsID" 
                                    ,"ShipmentDate"
                                    ,"ReceiverStoreID"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + LogisticsID + "&";
                        break;
                    case "ShipmentDate":
                        strPost += "ShipmentDate=" + ShipmentDate + "&";
                        break;
                    case "ReceiverStoreID":
                        strPost += "ReceiverStoreID=" + ReceiverStoreID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("AllPayLogisticsID", LogisticsID);
            PostDictionary.Add("ShipmentDate", ShipmentDate);
            PostDictionary.Add("ReceiverStoreID", ReceiverStoreID);

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 統一超商門市取貨即時驗收檔
        public ActionResult RequestOLTP()
        {
            //string postData = @"<OLTP><HEADER><VER>01.01</VER><FROM>CS00100001</FROM><TERMINO>20141013165311000006079153</TERMINO><TO>CP00800020</TO><BUSINESS>0010103</BUSINESS><DATE>20141013</DATE><TIME>165311</TIME><STATCODE>0000</STATCODE><STATDESC></STATDESC></HEADER><AP><TotalCount>1</TotalCount><TotalAmount>100</TotalAmount><Detail><SequenceNo>1</SequenceNo><OL_OI_NO>852</OL_OI_NO><OL_Code_1>031016852</OL_Code_1><OL_Code_2>2100032030010039</OL_Code_2><OL_Code_3></OL_Code_3><OL_Amount>100</OL_Amount><Status>S</Status><Description></Description><OL_Print>Y</OL_Print></Detail></AP></OLTP>";
            string postData = @"<OLTP><HEADER><VER>01.01</VER><FROM>CS00100001</FROM><TERMINO>20141028991182030195261556</TERMINO><TO>CP00800090</TO><BUSINESS>0010103</BUSINESS><DATE>20150108</DATE><TIME>155610</TIME><STATCODE>0000</STATCODE><STATDESC></STATDESC></HEADER><AP><TotalCount>1</TotalCount><TotalAmount>4000</TotalAmount><Detail><SequenceNo>1</SequenceNo><OL_OI_NO>853</OL_OI_NO><OL_Code_1>031111853</OL_Code_1><OL_Code_2>2005507630400064</OL_Code_2><OL_Code_3></OL_Code_3><OL_Amount>4000</OL_Amount><Status>S</Status><Description /><OL_Print>Y</OL_Print></Detail></AP></OLTP>";

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://devlogistics.allpay.com.tw:12007/Helper/ProcessOLTPRequest");


            myRequest.Method = "POST";


            myRequest.ContentType = "application/x-www-form-urlencoded";


            ASCIIEncoding encoder = new ASCIIEncoding();


            // Convert the string into a byte array.


            byte[] xmlBytes = encoder.GetBytes(postData);


            myRequest.ContentLength = xmlBytes.Length;


            Stream newStream = myRequest.GetRequestStream();


            newStream.Write(xmlBytes, 0, xmlBytes.Length);


            newStream.Close();


            // Return the response. 


            WebResponse myWebResponse = myRequest.GetResponse();


            // Obtain a 'Stream' object associated with the response object.


            Stream ReceiveStream = myWebResponse.GetResponseStream();


            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");


            // Pipe the stream to a higher level stream reader with the required encoding format. 


            StreamReader readStream = new StreamReader(ReceiveStream, encode);


            var response = readStream.ReadToEnd();


            readStream.Close(); readStream = null;


            myWebResponse.Close();

            return Content(response);
        }
        #endregion

        #region 正物流訂單資訊查詢
        public ActionResult LogisticsQueryTradeInfo()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            string MerchantID = "1000070";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/Helper/QueryLogisticsTradeInfo";
            HashKey = "koyqVBURmmkQxROZ";
            HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/Helper/LogisticsCheckAccoounts";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            string AllPayLogisticsID = "10593";
            string TimeStamp = "1417416830";
            //字串排序
            string[] strList = {                                     
                                    "MerchantID"
                                    ,"AllPayLogisticsID"   
                                    ,"TimeStamp"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                    case "TimeStamp":
                        strPost += "TimeStamp=" + TimeStamp + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("TimeStamp", TimeStamp);
            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 逆物流訂單資訊查詢
        public ActionResult LogisticsQueryRtnTradeInfo()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            string MerchantID = "1000070";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/Helper/QueryLogisticsRtnTradeInfo";
            HashKey = "koyqVBURmmkQxROZ";
            HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/Helper/LogisticsCheckAccoounts";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            string RtnMerchantTradeNo = "1412011408128";
            string TimeStamp = "1417422296";
            //字串排序
            string[] strList = {                                     
                                    "MerchantID"
                                    ,"RtnMerchantTradeNo"   
                                    ,"TimeStamp"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "RtnMerchantTradeNo":
                        strPost += "RtnMerchantTradeNo=" + RtnMerchantTradeNo + "&";
                        break;
                    case "TimeStamp":
                        strPost += "TimeStamp=" + TimeStamp + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("RtnMerchantTradeNo", RtnMerchantTradeNo);
            PostDictionary.Add("TimeStamp", TimeStamp);
            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 統一超商C2C取消訂單
        public ActionResult CancelC2COrder()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/CancelC2COrder";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            string MerchantID = "888891";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/express/CancelC2COrder";
            HashKey = "SM6zZHQvodchMaTk";
            HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            string AllPayLogisticsID = "10109";
            string CVSPaymentNo = "F0002365";
            string CVSValidationNo = "8165";

            //字串排序
            string[] strList = {                                     
                                    "AllPayLogisticsID",
                                    "CVSPaymentNo",
                                    "CVSValidationNo",
                                    "MerchantID"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "CVSPaymentNo":
                        strPost += "CVSPaymentNo=" + CVSPaymentNo + "&";//必填
                        break;
                    case "CVSValidationNo":
                        strPost += "CVSValidationNo=" + CVSValidationNo + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("CVSPaymentNo", CVSPaymentNo);   //必填
            PostDictionary.Add("CVSValidationNo", CVSValidationNo);   //必填     
            PostDictionary.Add("MerchantID", MerchantID);   //必填       

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 統一超商C2C列印繳費單
        public ActionResult PrintUniMartC2COrder()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/PrintUniMartC2COrderInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/PrintUniMartC2COrderInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";
            //string MerchantID = "2000933";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/PrintUniMartC2COrderInfo";
            //HashKey = "XBERn1YOvpM9nfZc";
            //HashIV = "h1ONHk4P4yqbl5LK";

            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/express/PrintUniMartC2COrderInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string MerchantID = "1115550";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/express/PrintUniMartC2COrderInfo";
            HashKey = "utmbJ4qrjFQkcOej";
            HashIV = "IHWqBtkXMCIBzQXf";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            string AllPayLogisticsID = "2016226";
            string CVSPaymentNo = "C6348779";
            string CVSValidationNo = "0913";
            //10114	F0004820	0727
            //字串排序
            string[] strList = {                                     
                                    "AllPayLogisticsID",
                                    "CVSPaymentNo",
                                    "CVSValidationNo",
                                    "MerchantID"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "CVSPaymentNo":
                        strPost += "CVSPaymentNo=" + CVSPaymentNo + "&";//必填
                        break;
                    case "CVSValidationNo":
                        strPost += "CVSValidationNo=" + CVSValidationNo + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("CVSPaymentNo", CVSPaymentNo);   //必填
            PostDictionary.Add("CVSValidationNo", CVSValidationNo);   //必填     
            PostDictionary.Add("MerchantID", MerchantID);   //必填       

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 統一超商C2C-發生門市關店時，利用此API更新門市
        public ActionResult UpdateUniMartC2CStoreInfo()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/UpdateStoreInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/express/UpdateStoreInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string MerchantID = "1114048";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/express/UpdateStoreInfo";
            HashKey = "fSXByIrRTHBSXxWt";
            HashIV = "0OF0LCoo05phi7Pn";
            //Hashkey:fSXByIrRTHBSXxWt HashIV:0OF0LCoo05phi7Pn
            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            string AllPayLogisticsID = "2087293";
            string CVSPaymentNo = "D4421644";
            string CVSValidationNo = "4709";
            string StoreType = "01";
            string ReceiverStoreID = "890324";
            string ReturnStoreID = "";

            //字串排序
            string[] strList = {                                     
                                    "AllPayLogisticsID",
                                    "CVSPaymentNo",
                                    "CVSValidationNo",
                                    "MerchantID",
                                    "ReceiverStoreID",
                                    "ReturnStoreID",
                                    "StoreType"                                    
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "CVSPaymentNo":
                        strPost += "CVSPaymentNo=" + CVSPaymentNo + "&";//必填
                        break;
                    case "CVSValidationNo":
                        strPost += "CVSValidationNo=" + CVSValidationNo + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                    case "StoreType":
                        strPost += "StoreType=" + StoreType + "&";
                        break;
                    case "ReceiverStoreID":
                        strPost += "ReceiverStoreID=" + ReceiverStoreID + "&";
                        break;
                    case "ReturnStoreID":
                        strPost += "ReturnStoreID=" + ReturnStoreID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("CVSPaymentNo", CVSPaymentNo);   //必填
            PostDictionary.Add("CVSValidationNo", CVSValidationNo);   //必填     
            PostDictionary.Add("MerchantID", MerchantID);   //必填  
            PostDictionary.Add("StoreType", StoreType);   //必填  
            PostDictionary.Add("ReceiverStoreID", ReceiverStoreID);   //必填  
            PostDictionary.Add("ReturnStoreID", ReturnStoreID);   //必填  

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        public ActionResult QueryFAMIVendorInfo()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/Helper/QueryVendorInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000139";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Helper/QueryVendorInfo";
            //HashKey = "Zf1AjVRlwE4XjlF9";
            //HashIV = "Ps8hPWGtUW0PE3Gk";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "https://logistics.allpay.com.tw/express/CancelC2COrder";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string MerchantID = "1114444";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/helper/QueryVendorInfo";
            HashKey = "aR13siWZjUmfhKZd";
            HashIV = "ytJoay2bHCetqJjC";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;


            //字串排序
            string[] strList = {                                                                         
                                    "MerchantID"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", MerchantID);   //必填       

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }

        #region 全家超商C2C列印小白單
        public ActionResult PrintFAMIC2COrder()
        {
            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/PrintFAMIC2COrderInfo";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000139";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "Zf1AjVRlwE4XjlF9";
            //HashIV = "Ps8hPWGtUW0PE3Gk";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string MerchantID = "1115550";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/express/PrintFAMIC2COrderInfo";
            HashKey = "utmbJ4qrjFQkcOej";
            HashIV = "IHWqBtkXMCIBzQXf";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            //string AllPayLogisticsID = "10123";
            //string CVSPaymentNo = "04958430666";
            string AllPayLogisticsID = "2016247";
            string CVSPaymentNo = "05999919804";
            //10114	F0004820	0727
            //字串排序
            string[] strList = {                                     
                                    "AllPayLogisticsID",
                                    "CVSPaymentNo",
                                    "MerchantID"
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "CVSPaymentNo":
                        strPost += "CVSPaymentNo=" + CVSPaymentNo + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("CVSPaymentNo", CVSPaymentNo);   //必填    
            PostDictionary.Add("MerchantID", MerchantID);   //必填       

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        public string[] SortedRequestFormData(string requestData)
        {
            string[] RequestDataArray = requestData.TrimStart('?').Split('&');
            Array.Sort(RequestDataArray);

            return RequestDataArray;
        }

        #region 模擬產生托運單格式
        public ActionResult CreatePrintTrade()
        {


            //dev test
            //string MerchantID = "1000070";
            //string HashKey = "koyqVBURmmkQxROZ";
            //string HashIV = "BcRITiCQaUHBZC1f";
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/helper/PrintTradeDocument";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/helper/PrintTradeDocument";
            //string HashKey = "5294y06JbISpM5x9";
            //string HashIV = "v77hoKGq4kWxNNIS";

            string AllPayLogisticsID = "2016352";
            string MerchantID = "1115550";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/helper/PrintTradeDocument";
            string HashKey = "utmbJ4qrjFQkcOej";
            string HashIV = "IHWqBtkXMCIBzQXf";
            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "http://logistics.allpay.com.tw/helper/PrintTradeDocument";
            //string HashKey = "SM6zZHQvodchMaTk";
            //string HashIV = "zf3MhCfhzwUZoGfi";

            string[] strList = {                                     
                                    "AllPayLogisticsID",                                    
                                    "MerchantID"
                               };


            string strPost = string.Empty;

            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + AllPayLogisticsID + "&";
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;

            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            string strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("MerchantID", MerchantID);   //必填       

            PostDictionary.Add("CheckMacValue", strCheckMacValue);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in PostDictionary)
            {
                RequestTable.Add(item.Key, item.Value);

            }

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }
        #endregion

        public ActionResult ServerReplyTest()
        {
            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            string MerchantID = "1000070";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/MockMerchant/ServerReplyTest";
            HashKey = "koyqVBURmmkQxROZ";
            HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000139";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "Zf1AjVRlwE4XjlF9";
            //HashIV = "Ps8hPWGtUW0PE3Gk";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            //string AllPayLogisticsID = "10123";
            //string CVSPaymentNo = "04958430666";
            string AllPayLogisticsID = "10062";
            string Rtncode = "1";
            string RtnMsg = "OK";
            string ServerReplyURL = "http://logistics-beta.allpay.com.tw/MockMerchant/NoticsTestRtn";
            //10114	F0004820	0727
            //字串排序            
            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", AllPayLogisticsID);
            PostDictionary.Add("MerchantID", MerchantID);
            PostDictionary.Add("Rtncode", Rtncode);   //必填    
            PostDictionary.Add("RtnMsg", RtnMsg);   //必填      
            PostDictionary.Add("ServerReplyURL", ServerReplyURL);

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }

        public ActionResult RtnServerReplyTest()
        {
            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            string MerchantID = "1000070";        //dev    
            string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/MockMerchant/RtnServerReplyTest";
            HashKey = "koyqVBURmmkQxROZ";
            HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000139";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "Zf1AjVRlwE4XjlF9";
            //HashIV = "Ps8hPWGtUW0PE3Gk";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            //string MerchantID = "888891";        //正式機    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/Express/PrintFAMIC2COrderInfo";
            //HashKey = "SM6zZHQvodchMaTk";
            //HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;
            //string AllPayLogisticsID = "10123";
            //string CVSPaymentNo = "04958430666";
            string RtnMerchantTradeNo = "1405281126405";
            string Rtncode = "1";
            string RtnMsg = "OK";
            string ServerReplyURL = "http://logistics-beta.allpay.com.tw/MockMerchant/NoticsTestRtn";
            //10114	F0004820	0727
            //字串排序            
            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("RtnMerchantTradeNo", RtnMerchantTradeNo);
            PostDictionary.Add("MerchantID", MerchantID);
            PostDictionary.Add("Rtncode", Rtncode);   //必填    
            PostDictionary.Add("RtnMsg", RtnMsg);   //必填      
            PostDictionary.Add("ServerReplyURL", ServerReplyURL);

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }

        #region 宅配逆物流
        public ActionResult LogisticsCreateRtnTradeHome()
        {

            //前後加上屬於自己的HashKey及HashIV
            string HashKey = "", HashIV = "";

            //string MerchantID = "1000070";        //dev    
            //string tradePostUrl = "http://devlogistics.allpay.com.tw:12007/express/ReturnHome";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "1000070";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "koyqVBURmmkQxROZ";
            //HashIV = "BcRITiCQaUHBZC1f";

            //string MerchantID = "999998888";        //beta    
            //string tradePostUrl = "http://logistics-beta.allpay.com.tw/express/ReturnCVS";
            //HashKey = "fugvqTnG3ROx81MO";
            //HashIV = "WkSfnqIaHLbUMV5X";

            //string MerchantID = "1000139";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/create";

            //string MerchantID = "2000132";        //stage    
            //string tradePostUrl = "http://logistics-stage.allpay.com.tw/express/ReturnHome";
            //HashKey = "5294y06JbISpM5x9";
            //HashIV = "v77hoKGq4kWxNNIS";


            string MerchantID = "888891";        //正式機    
            string tradePostUrl = "https://logistics.allpay.com.tw/express/ReturnHome";
            HashKey = "SM6zZHQvodchMaTk";
            HashIV = "zf3MhCfhzwUZoGfi";

            string strPost = string.Empty;
            string strCheckMacValue = string.Empty;

            string LogisticsID = "10204";

            string ServerReplyURL = "http://logistics.allpay.com.tw/MockMerchant/NoticsTestRtn";
            string SenderName = "陳卜菖";
            string SenderPhone = "0927651918";
            string SenderCellPhone = "";

            string ReceiverName = "陳尼克";
            string ReceiverPhone = "";
            string ReceiverCellPhone = "0975653378";
            string ReceiverEmail = "";
            /************************/
            //宅配使用
            string SenderZipCode = "115";
            string SenderAddress = "台北市南港區三重路19-2號D棟5F";
            string ReceiverZipCode = "115";
            string ReceiverAddress = "台北市南港區三重路19-2號D棟5F";
            string Temperature = "";
            string Distance = "";
            string Specification = "";
            string ScheduledPickupTime = "";
            string ScheduledDeliveryTime = "";

            /************************/

            //字串排序
            string[] strList = { 
                                    "AllPayLogisticsID"
                                    ,"Distance"
                                    ,"MerchantID"                                                                        
                                    ,"ReceiverAddress"
                                    ,"ReceiverCellPhone"
                                    ,"ReceiverName"
                                    ,"ReceiverPhone"
                                    ,"ReceiverZipCode"                                                                                                                                                                                    
                                    ,"Temperature"    
                                    ,"ScheduledDeliveryTime"
                                    ,"ScheduledPickupTime"                                    
                                    ,"SenderAddress"
                                    ,"SenderCellPhone"
                                    ,"SenderName"
                                    ,"SenderPhone"
                                    ,"SenderZipCode"
                                    ,"Specification"
                                    ,"ServerReplyURL"                                    
                               };



            var orderStr = strList.OrderBy(o => o).ToArray();

            //需要加密的參數組字串-訂單資料
            foreach (string str in orderStr)
            {
                switch (str)
                {
                    case "AllPayLogisticsID":
                        strPost += "AllPayLogisticsID=" + LogisticsID + "&";//必填
                        break;
                    case "MerchantID":
                        strPost += "MerchantID=" + MerchantID + "&";//必填
                        break;
                    case "SenderName":
                        strPost += "SenderName=" + SenderName + "&";
                        break;

                    case "SenderPhone":
                        strPost += "SenderPhone=" + SenderPhone + "&";
                        break;

                    case "ServerReplyURL":
                        strPost += "ServerReplyURL=" + ServerReplyURL + "&";
                        break;

                    case "SenderCellPhone":
                        if (!string.IsNullOrWhiteSpace(SenderCellPhone))
                        {
                            strPost += "SenderCellPhone=" + SenderCellPhone + "&";
                        }
                        break;

                    case "ReceiverName":
                        strPost += "ReceiverName=" + ReceiverName + "&";
                        break;

                    case "ReceiverPhone":
                        if (!string.IsNullOrWhiteSpace(ReceiverPhone))
                        {
                            strPost += "ReceiverPhone=" + ReceiverPhone + "&";
                        }
                        break;

                    case "ReceiverCellPhone":
                        if (!string.IsNullOrWhiteSpace(ReceiverCellPhone))
                        {
                            strPost += "ReceiverCellPhone=" + ReceiverCellPhone + "&";
                        }
                        break;

                    case "ReceiverEmail":
                        if (!string.IsNullOrWhiteSpace(ReceiverEmail))
                        {
                            strPost += "ReceiverEmail=" + ReceiverEmail + "&";
                        }
                        break;

                    case "SenderZipCode":
                        if (!string.IsNullOrWhiteSpace(SenderZipCode))
                        {
                            strPost += "SenderZipCode=" + SenderZipCode + "&";
                        }
                        break;

                    case "SenderAddress":
                        if (!string.IsNullOrWhiteSpace(SenderAddress))
                        {
                            strPost += "SenderAddress=" + SenderAddress + "&";
                        }
                        break;

                    case "ReceiverZipCode":
                        if (!string.IsNullOrWhiteSpace(ReceiverZipCode))
                        {
                            strPost += "ReceiverZipCode=" + ReceiverZipCode + "&";
                        }
                        break;

                    case "ReceiverAddress":
                        if (!string.IsNullOrWhiteSpace(ReceiverAddress))
                        {
                            strPost += "ReceiverAddress=" + ReceiverAddress + "&";
                        }
                        break;

                    case "Temperature":
                        if (!string.IsNullOrWhiteSpace(Temperature))
                        {
                            strPost += "Temperature=" + Temperature + "&";
                        }
                        break;

                    case "Distance":
                        if (!string.IsNullOrWhiteSpace(Distance))
                        {
                            strPost += "Distance=" + Distance + "&";
                        }
                        break;

                    case "Specification":
                        if (!string.IsNullOrWhiteSpace(Specification))
                        {
                            strPost += "Specification=" + Specification + "&";
                        }
                        break;

                    case "ScheduledPickupTime":
                        if (!string.IsNullOrWhiteSpace(ScheduledPickupTime))
                        {
                            strPost += "ScheduledPickupTime=" + ScheduledPickupTime + "&";
                        }
                        break;

                    case "ScheduledDeliveryTime":
                        if (!string.IsNullOrWhiteSpace(ScheduledDeliveryTime))
                        {
                            strPost += "ScheduledDeliveryTime=" + ScheduledDeliveryTime + "&";
                        }
                        break;
                }
            }


            strPost = "HashKey=" + HashKey + "&" + strPost + "HashIV=" + HashIV;



            string urlEncodeStrPost = HttpUtility.UrlEncode(strPost);
            string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            //檢查碼要使用MD5加密
            strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);


            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("AllPayLogisticsID", LogisticsID);    //必填
            PostDictionary.Add("MerchantID", MerchantID.ToString());   //必填
            PostDictionary.Add("CheckMacValue", strCheckMacValue);
            PostDictionary.Add("SenderName", SenderName);
            PostDictionary.Add("SenderPhone", SenderPhone);
            if (!string.IsNullOrEmpty(SenderCellPhone))
            {
                PostDictionary.Add("SenderCellPhone", SenderCellPhone);
            }

            PostDictionary.Add("ReceiverName", ReceiverName);

            if (!string.IsNullOrEmpty(ReceiverPhone))
            {
                PostDictionary.Add("ReceiverPhone", ReceiverPhone);
            }

            if (!string.IsNullOrEmpty(ReceiverCellPhone))
            {
                PostDictionary.Add("ReceiverCellPhone", ReceiverCellPhone);
            }

            if (!string.IsNullOrEmpty(ReceiverEmail))
            {
                PostDictionary.Add("ReceiverEmail", ReceiverEmail);
            }
            if (!string.IsNullOrEmpty(SenderZipCode))
            {
                PostDictionary.Add("SenderZipCode", SenderZipCode);
            }
            if (!string.IsNullOrEmpty(SenderAddress))
            {
                PostDictionary.Add("SenderAddress", SenderAddress);
            }
            if (!string.IsNullOrEmpty(ReceiverZipCode))
            {
                PostDictionary.Add("ReceiverZipCode", ReceiverZipCode);
            }
            if (!string.IsNullOrEmpty(ReceiverAddress))
            {
                PostDictionary.Add("ReceiverAddress", ReceiverAddress);
            }
            if (!string.IsNullOrEmpty(Temperature))
            {
                PostDictionary.Add("Temperature", Temperature);
            } if (!string.IsNullOrEmpty(Distance))
            {
                PostDictionary.Add("Distance", Distance);
            }

            if (!string.IsNullOrEmpty(Specification))
            {
                PostDictionary.Add("Specification", Specification);

            } if (!string.IsNullOrEmpty(ScheduledPickupTime))
            {
                PostDictionary.Add("ScheduledPickupTime", ScheduledPickupTime);
            }

            if (!string.IsNullOrEmpty(ScheduledDeliveryTime))
            {
                PostDictionary.Add("ScheduledDeliveryTime", ScheduledDeliveryTime);
            }
            PostDictionary.Add("ServerReplyURL", ServerReplyURL);

            //string ServerResponse = DoRequest(tradePostUrl, RequestTable);

            //return Content(ServerResponse);
            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = tradePostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");


        }
        #endregion

        #region 計算檢核碼
        public ActionResult CelMacCheckValue()
        {

            string MerchantID = "888891";        //正式機   
            string tradePostUrl = "https://payment.allpay.com.tw/AioHelper/GenCheckMacValue";
            //string HashKey = "5294y06JbISpM5x9";
            //string HashIV = "v77hoKGq4kWxNNIS";

            Hashtable dt = new Hashtable();

            dt.Add("MerchantID", MerchantID);
            dt.Add("MerchantTradeNo", "FO20141216031175");
            dt.Add("RtnCode", "3023");
            dt.Add("RtnMsg", "賣家已取買家未取貨");
            dt.Add("AllPayLogisticsID", "10198");
            dt.Add("LogisticsType", "CVS");
            dt.Add("LogisticsSubType", "FAMI");
            dt.Add("GoodsAmount", "2");
            dt.Add("UpdateStatusDate", "2014/12/23 17:27:26");
            dt.Add("CVSPaymentNo", "");
            dt.Add("CVSValidationNo", "");
            dt.Add("ReceiverName", "林和生");
            dt.Add("ReceiverPhone", "");
            dt.Add("ReceiverCellPhone", "0935660662");
            dt.Add("ReceiverEmail", "");
            dt.Add("ReceiverAddress", "");
            dt.Add("BookingNote", "");
            dt.Add("EncryptType", "0");

            //var items = dt.OrderBy(x => x.Key);
            //string paras = string.Empty;

            //foreach (var item in dt)
            //{
            //    paras = paras + "&" + item.Key + "=" + item.Value;
            //}

            //paras = paras.Trim(new char[] { '&' });

            //paras = "HashKey=" + HashKey + "&" + paras + "&HashIV=" + HashIV;

            //paras = "HashKey=WOlv8QtCYlN8zMV2&AllPayLogisticsID=10198&BookingNote=&CVSPaymentNo =&CVSValidationNo=&GoodsAmount=2&LogisticsSubType=FAMI&LogisticsType=CVS&MerchantID=1057435&MerchantTradeNo=FO20141216031175&ReceiverAddress=&ReceiverCellPhone=0935660662&ReceiverEmail=&ReceiverName=林和生&ReceiverPhone=&RtnCode=3023&RtnMsg=賣家已取買家未取貨&UpdateStatusDate=2014/12/26 02:00:11&HashIV=58oYGys4yhEWzier";

            string rtnMsg = DoRequest(tradePostUrl, dt);

            //string urlEncodeStrPost = HttpUtility.UrlEncode(paras);
            //string lowerUrlEncodeStrPost = urlEncodeStrPost.ToLower();

            ////檢查碼要使用MD5加密
            //string strCheckMacValue = new AllPay.ShareLib.Crypt().MD5(lowerUrlEncodeStrPost);

            return Content(rtnMsg);

        }
        #endregion


        public ActionResult HTMLDecode()
        {
            DateTime now1 = DateTime.Now;
            DateTime deadline1 = Convert.ToDateTime(Convert.ToDateTime("2015-12-30").ToString("yyyy-MM-dd") + " 10:00:00").AddDays(2);

            if (now1 > deadline1)
            {

            }

            QueryParkResultAP model2 = new QueryParkResultAP();
            model2.Key_1 = "1234";
            model2.Key_2 = "4567";
            model2.Key_3 = "8901";

            List<string> PropertyList = new List<string>();

            foreach (var PropertyName in model2.GetType().GetProperties())
            {
                PropertyList.Add(PropertyName.Name);
            }

            foreach (var item in PropertyList)
            {
                Type abc = model2.GetType();
                var cc = abc.GetProperty("Key_1").GetValue(model2, null);
                
            }


            string shipmentDate = "2015-12-01";

            DateTime deadline = Convert.ToDateTime(shipmentDate + " 10:00:00").AddDays(2);

            DateTime now = DateTime.Now;
             string nowHour = now.ToString("HH:mm:ss");
            string deadlineHour = "10:00:00";

            if (Convert.ToDateTime(nowHour) > Convert.ToDateTime(deadlineHour))
            {

            }

            DateTime nowdate = DateTime.Now;
            string shipdate = "2015-12-04";
            if (!string.IsNullOrWhiteSpace(shipdate))
            {
                if (Convert.ToDateTime(shipdate) <  Convert.ToDateTime(now.ToString("yyyy-MM-dd")))
                {
                    StringBuilder errorMsg = new StringBuilder("出貨日期不可小於今天日期");
                    
                }
            }


            string decodeMsg = HttpUtility.UrlDecode("MerchantID=1135014&amp%3bAllPayLogisticsID=2031747&amp%3bShipmentDate=2015%2f10%2f14&amp%3bReceiverStoreID=&amp%3bPlatformID=&amp%3bCheckMacValue=70E50A909A8E0C6DEB076E88889E93D4");

            string xml = @"<OLTP>
      <HEADER>
        <BUSINESS>1002</BUSINESS>
        <FROM>TCG</FROM>
        <TERMINO>POS01A20140428000001</TERMINO>
        <DATE>20140428</DATE>
        <TIME>140600</TIME>
        <STATCODE>0000</STATCODE>
        <STATDESC></STATDESC>
      </HEADER>
      <AP>
        <TRAN_NO></TRAN_NO>
        <Key_1>AA-1234</Key_1>
        <Key_2>C</Key_2>
        <Key_3></Key_3>
        <TotalCount>2</TotalCount>
        <TotalAmount>150</TotalAmount>
        <Detail>
          <SequenceNo>01</SequenceNo>
          <OL_P_Check>Y</OL_P_Check>
          <Field_1>E40243843619</Field_1>
          <Field_2>AA-1234</Field_2>
          <Field_3>20140401</Field_3>
          <Field_4>20140430</Field_4>
          <Field_5>50</Field_5>
          <Field_6></Field_6>
          <Field_7>停車單</Field_7>
          <Field_8></Field_8>
          <Field_9></Field_9>
          <Field_10></Field_10>
        </Detail>
        <Detail>
          <SequenceNo>02</SequenceNo>
          <OL_P_Check>Y</OL_P_Check>
          <Field_1>ZZZ20140425123456</Field_1>
          <Field_2>AA-1234</Field_2>
          <Field_3>20140425</Field_3>
          <Field_4>20140525</Field_4>
          <Field_5>100</Field_5>
          <Field_6></Field_6>
          <Field_7>追繳單</Field_7>
          <Field_8></Field_8>
          <Field_9></Field_9>
          <Field_10></Field_10>
        </Detail>
      </AP></OLTP>
";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(doc);


            ParkInfo<QueryParkResultAP> model = JsonConvert.DeserializeObject<ParkInfo<QueryParkResultAP>>(json);

            //model.RtnCode = "0";
            // model.RtnMsg = "Success";

            string resultJson = JsonConvert.SerializeObject(model.OLTP.AP);

            ///OLTP<QueryParkAP> model = JsonConvert.
            //string merchantTradeNo = new AllPay.ShareLib.Crypt().AES_DeCrypt("UpXknzpL6XsYfocm", "C8Csc3DHcZY6wt1j", "jHxQEcBbIqMGqBg0BXZQ8A==");
            //HashKey	HashIV I/kwP+JBad+z/juJ0mX4SR7iXJ2sqp1LPLZjda4AsOj=	cZ6TKS+86tSD0v9rzVbpDwSM4z/hoHGi8YVzPDMr6zs=

            AllPay.ShareLib.KeyCrypt _keyCrypt = new AllPay.ShareLib.KeyCrypt();
            string HashKey = _keyCrypt.DeCrypt("kmoIaYDYJCIhKheuVCCHd68rhE1HEPJHbc64YOL4VCf=");
            string HashIV = _keyCrypt.DeCrypt("UdevOEvG5Pzo30eUwWkz6HVfWw5CIRy0+33KD+QRPss=");

            string msg = @"RequestForm:ClientReplyURL=http%3a%2f%2fwww.loveucfgirl.com%2fpayment%2fallpay_c2c%2fcallback_allpay_c2c&CollectionAmount=2244&GoodsAmount=2244&GoodsName=QDM+%u7db2%u8def%u958b%u5e97%u5e73%u53f0%2327618942&IsCollection=Y&LogisticsC2CReplyURL=http%3a%2f%2fwww.allpay.com.tw%2freceive.php&LogisticsSubType=UNIMARTC2C&LogisticsType=CVS&MerchantID=1062916&MerchantTradeDate=2015%2f12%2f10+08%3a01%3a08&MerchantTradeNo=27618942&ReceiverCellPhone=0921126037&ReceiverEmail=yenhsiliang%40gmail.com&ReceiverName=%u8b1d%u8070%u54f2&ReceiverPhone=0921126037&ReceiverStoreID=912709&SenderCellPhone=0987788018&SenderName=%u937e%u5be7%u9060&SenderPhone=&ServerReplyURL=http%3a%2f%2fwww.loveucfgirl.com%2fpayment%2fallpay_c2c%2fcallback_allpay_paid&TradeDesc=&CheckMacValue=1D6637998C569F31B7F920BB18C12203
RealIP:36.226.227.72
ProxyIP:
log建立時間:2015/12/10 08:01:21";
            //"ClientReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&GoodsAmount=894&GoodsName=%u82f1%u570b%u611b%u82e5%u96c5%u7121%u6bd2%u6307%u7532%u6cb9%u3001%u6c34%u6027%u6307%u7532%u6cb9%u3001%u8336%u6a39%u7cbe%u6cb9&IsCollection=Y&LogisticsC2CReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&LogisticsSubType=UNIMARTC2C&LogisticsType=CVS&MerchantID=1060752&MerchantTradeDate=2015%2f07%2f04+00%3a33%3a37&MerchantTradeNo=10601506081435941217&ReceiverCellPhone=0938246125&ReceiverEmail=test%40gmail.com&ReceiverName=%u738b%u4ead%u60e0&ReceiverPhone=0938246125&ReceiverStoreID=122625&SenderCellPhone=0&SenderName=%u738b%u4ead%u60e0&SenderPhone=0&ServerReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&TradeDesc=test&CheckMacValue=0F3362C32BAE4F1C89D5C445D0423804";
            //"cvsid=201507233300007&cvsspot=F011217&cvstemp=&cvsname=LOGISTICS.ALLPAY.COM.TW&name=%e5%85%a8%e5%ae%b6%e5%9c%9f%e5%9f%8e%e6%96%b0%e5%be%b7%e5%ba%97&tel=02-22644631&addr=%e6%96%b0%e5%8c%97%e5%b8%82%e5%9c%9f%e5%9f%8e%e5%8d%80%e4%b8%ad%e5%a4%ae%e8%b7%af%e4%b8%80%e6%ae%b5248%e4%b9%8b2%e8%99%9f&cvsnum=TK12";
            //"ClientReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&GoodsAmount=1967&GoodsName=%u82f1%u570b%u611b%u82e5%u96c5%u7121%u6bd2%u6307%u7532%u6cb9%u3001%u6c34%u6027%u6307%u7532%u6cb9%u3001%u8336%u6a39%u7cbe%u6cb9&IsCollection=Y&LogisticsC2CReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&LogisticsSubType=UNIMARTC2C&LogisticsType=CVS&MerchantID=1060752&MerchantTradeDate=2015%2f07%2f06+00%3a39%3a45&MerchantTradeNo=10691506081436114385&ReceiverCellPhone=0916642755&ReceiverEmail=test%40gmail.com&ReceiverName=%u6e38%u821c%u4ec1&ReceiverPhone=0916642755&ReceiverStoreID=112053&SenderCellPhone=0&SenderName=%u6e38%u821c%u4ec1&SenderPhone=0&ServerReplyURL=http%3a%2f%2fwww.alloyalife.com%2fmycart%2fallpal%2fcvs_url.php&TradeDesc=test&CheckMacValue=85C99954AC92726F787684F1583E4674";
            //string LogString = new AllPay.ShareLib.Crypt().AES_DeCrypt(HashKey, HashIV, msg);
            
            msg = HttpUtility.UrlDecode(msg);

            return Content(msg + "\r\n" + "Hashkey:" + HashKey + "\r\n" + "HashIV:" + HashIV);
        }

        static CookieContainer myContainer = new CookieContainer();

        public string DoRequest(string sURL)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = myContainer;
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            //keep cookies
            for (int i = 0; i < ((System.Net.HttpWebResponse)(response)).Cookies.Count; i++)
            {
                Cookie cookie = ((System.Net.HttpWebResponse)(response)).Cookies[i];
                Cookie newCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path);
                myContainer.Add(new Uri(Request.Url.ToString()), newCookie);
            }

            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            return responseFromServer;
        }

        string AppLoginKey = "BICfVOb61OogBe9l";
        string AppLoginIV = "6XP1ATqYaEmE9wAp";
        static string appUserKey = "";
        static string appUserIV = "";


        public ActionResult Login()
        {
            AppLogin AppLogin = new AppLogin();
            AppLogin.Account = "0900000104";
            AppLogin.PWD = "0F76AEallpay";
            AppLogin.UserCode = "Jarvis095206";
            AppLogin.DeviceID = "AA0001";
            AppLogin.RegistrationID = "AATESTTEST0000001";
            AppLogin.TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            return View(AppLogin);
        }

        [HttpPost]
        public ActionResult Login(AppLogin AppLogin)
        {
            string requestUrl = "http://devlogin.allpay.com.tw:12001/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "http://login-beta.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "http://login-stage.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "https://login.allpay.com.tw/app/AppLogin/AppUserCodeLogin";

            requestUrl += "?D=" + JsonEnCrypt(AppLogin, AppLoginKey, AppLoginIV);
            string Result = DoRequest(requestUrl);
            LoginResult LoginResult = JsonConvert.DeserializeObject<LoginResult>(Result);
            LoginResult.RtnData = JsonDeCrypt(LoginResult.RtnData, AppLoginKey, AppLoginIV); //解密

            LoginResult RtnData = JsonConvert.DeserializeObject<LoginResult>(LoginResult.RtnData);

            appUserKey = RtnData.AppKey;
            appUserIV = RtnData.AppIV;

            return Content("RtnCode:" + LoginResult.RtnCode + "<br>" +
                           "RtnMsg:" + LoginResult.RtnMsg + "<br>" +
                           "RtnData:" + LoginResult.RtnData);
        }

        [HttpPost]
        public ActionResult CreateBarcode(BarcodeGetData model)
        {
            string requestUrl = "http://devpayment.allpay.com.tw:12005/app/BarcodeSeller/CreateBarcode";
            //string requestUrl = "http://login-beta.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "http://login-stage.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "https://login.allpay.com.tw/app/AppLogin/AppUserCodeLogin";

            requestUrl += "?D=" + JsonEnCrypt(model, appUserKey, appUserIV);
            string Result = DoRequest(requestUrl);
            LoginResult LoginResult = JsonConvert.DeserializeObject<LoginResult>(Result);
            LoginResult.RtnData = JsonDeCrypt(LoginResult.RtnData, appUserKey, appUserIV); //解密

            LoginResult RtnData = JsonConvert.DeserializeObject<LoginResult>(LoginResult.RtnData);

            appUserKey = RtnData.AppKey;
            appUserIV = RtnData.AppIV;

            return Content("RtnCode:" + LoginResult.RtnCode + "<br>" +
                           "RtnMsg:" + LoginResult.RtnMsg + "<br>" +
                           "RtnData:" + LoginResult.RtnData);
        }

        
        [HttpPost]
        public ActionResult CheckBarcodeSellerInfo(BarcodeGetData model)
        {
            string requestUrl = "http://devpayment.allpay.com.tw:12005/app/BarcodeSeller/CheckBarcodeSellerInfo";
            //string requestUrl = "http://login-beta.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "http://login-stage.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "https://login.allpay.com.tw/app/AppLogin/AppUserCodeLogin";

            requestUrl += "?D=" + JsonEnCrypt(model, appUserKey, appUserIV);
            string Result = DoRequest(requestUrl);
            LoginResult LoginResult = JsonConvert.DeserializeObject<LoginResult>(Result);
            LoginResult.RtnData = JsonDeCrypt(LoginResult.RtnData, appUserKey, appUserIV); //解密

            LoginResult RtnData = JsonConvert.DeserializeObject<LoginResult>(LoginResult.RtnData);

            appUserKey = RtnData.AppKey;
            appUserIV = RtnData.AppIV;

            return Content("RtnCode:" + LoginResult.RtnCode + "<br>" +
                           "RtnMsg:" + LoginResult.RtnMsg + "<br>" +
                           "RtnData:" + LoginResult.RtnData);
        }

         [HttpPost]
        public ActionResult AppCreateOrder(BarcodeGetData model)
        {
            string requestUrl = "http://devpayment.allpay.com.tw:12005/app/AppApiSeller/AppCreateOrder";
            //string requestUrl = "http://login-beta.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "http://login-stage.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
            //string requestUrl = "https://login.allpay.com.tw/app/AppLogin/AppUserCodeLogin";

            requestUrl += "?D=" + JsonEnCrypt(model, appUserKey, appUserIV);
            string Result = DoRequest(requestUrl);
            LoginResult LoginResult = JsonConvert.DeserializeObject<LoginResult>(Result);
            LoginResult.RtnData = JsonDeCrypt(LoginResult.RtnData, appUserKey, appUserIV); //解密

            LoginResult RtnData = JsonConvert.DeserializeObject<LoginResult>(LoginResult.RtnData);

            appUserKey = RtnData.AppKey;
            appUserIV = RtnData.AppIV;

            return Content("RtnCode:" + LoginResult.RtnCode + "<br>" +
                           "RtnMsg:" + LoginResult.RtnMsg + "<br>" +
                           "RtnData:" + LoginResult.RtnData);
        }

         [HttpPost]
         public ActionResult AppCancelOrder(BarcodeGetData model)
         {
             string requestUrl = "http://devpayment.allpay.com.tw:12005/app/AppApiSeller/AppCancelOrder";
             //string requestUrl = "http://login-beta.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
             //string requestUrl = "http://login-stage.allpay.com.tw/app/AppLogin/AppUserCodeLogin";
             //string requestUrl = "https://login.allpay.com.tw/app/AppLogin/AppUserCodeLogin";

             requestUrl += "?D=" + JsonEnCrypt(model, appUserKey, appUserIV);
             string Result = DoRequest(requestUrl);
             LoginResult LoginResult = JsonConvert.DeserializeObject<LoginResult>(Result);
             LoginResult.RtnData = JsonDeCrypt(LoginResult.RtnData, appUserKey, appUserIV); //解密

             LoginResult RtnData = JsonConvert.DeserializeObject<LoginResult>(LoginResult.RtnData);

             appUserKey = RtnData.AppKey;
             appUserIV = RtnData.AppIV;

             return Content("RtnCode:" + LoginResult.RtnCode + "<br>" +
                            "RtnMsg:" + LoginResult.RtnMsg + "<br>" +
                            "RtnData:" + LoginResult.RtnData);
         }        

        public string JsonEnCrypt(object model, string AppKey, string AppIV)
        {
            if (model == null || string.IsNullOrEmpty(AppKey) || string.IsNullOrEmpty(AppIV))
            {
                return string.Empty;
            }

            //### 序列化成Json Format.
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(model);
            }
            catch { }
            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }

            //### UTF8 UrlEncode.
            string encodeJson = HttpUtility.UrlEncode(json, Encoding.GetEncoding("utf-8"));
            if (string.IsNullOrEmpty(encodeJson))
            {
                return string.Empty;
            }

            encodeJson = encodeJson.Replace("+", "%20");

            //### AES加密.
            string enCryptJson = new AllPay.ShareLib.Crypt().AES_EnCrypt(AppKey, AppIV, encodeJson);
            return enCryptJson;
        }

        public string JsonDeCrypt(string originalString, string sKey, string sIV)
        {
            //### 先將空白取代成加號
            //### AES解密, 為Json Format
            string NewString = originalString.Replace(" ", "+");
            string EnJson = new AllPay.ShareLib.Crypt().AES_DeCrypt(sKey, sIV, NewString);
            string Json = HttpUtility.UrlDecode(EnJson, Encoding.GetEncoding("utf-8"));

            return Json;
        }
    }

    public class LoginResult
    {
        public string RtnCode { get; set; }

        public string RtnMsg { get; set; }

        public string RtnData { get; set; }

        public string AppKey { get; set; }

        public string AppIV { get; set; }

        public string MID { get; set; }

        public string LoginTokenID { get; set; }
    }

    public class AppLogin
    {
        public string Account { get; set; }

        public string PWD { get; set; }

        public string DeviceID { get; set; }

        public string SaveMode { get; set; }

        public string TimeStamp { get; set; }

        public string RegistrationID { get; set; }

        public string OS { get; set; }

        public int VersionCode { get; set; }

        //登入代碼
        public string UserCode { get; set; }

        //簡訊驗證碼
        public string AuthCode { get; set; }

        //簡訊驗證碼
        public string SMSAuthCode { get; set; }

        //身分證驗證碼
        public string IDAuthCode { get; set; }

        public string AppName { get; set; }
    }

    public class BarcodeGetData
    {
        public string MID { get; set; }

        public string LoginTokenID { get; set; }

        public string TimeStamp { get; set; }

        public string PaymentType { get; set; }

        public string CardID { get; set; }

        //========== 2013-11-26 By Nick =============
        //交易代碼
        public string Barcode { get; set; }
        //有效秒數
        public string Seconds { get; set; }
        //會員身份證字號
        public string IDNO { get; set; }

        public string TradeAmount { get; set; }

        //保留欄位
        public string GroupID { get; set; }

        public string MerchantID { get; set; }

        public int ExtendSecs { get; set; }

        public string TotalAmount { get; set; }
    }

    public class MapInfo
    {
        public string CVSStoreID { get; set; }

        public string CVSStoreName { get; set; }

        public string MerchantID { get; set; }

        public string LogisticsSubType { get; set; }

        public string MerchantTradeNo { get; set; }

        public string CVSAddress { get; set; }

        public string CVSTelephone { get; set; }

        public string ExtraData { get; set; }
    }


    public class OLTP<T>
    {
        public string RtnCode { get; set; }

        public string RtnMsg { get; set; }

        public ParkHeader HEADER { get; set; }

        public T AP { get; set; }
    }

    public class ParkHeader
    {
        public string BUSINESS { get; set; }

        public string FROM { get; set; }

        public string TERMINO { get; set; }

        public string DATE { get; set; }

        public string TIME { get; set; }

        public string STATCODE { get; set; }

        public string STATDESC { get; set; }
    }

    //### 一． 查詢作業
    public class ParkInfo<T>
    {
        public OLTP<T> OLTP { get; set; }
    }

    public class QueryParkAP
    {
        public string TRAN_NO { get; set; }

        //### 車號，需帶-
        public string key_1 { get; set; }

        //### 車種(C:汽車 M:機車)
        public string key_2 { get; set; }

        //### 繳費單號
        public string key_3 { get; set; }

    }

    public class QueryParkInfo<T>
    {
        public OLTP<T> OLTP { get; set; }
    }

    public class QueryParkResultAP
    {
        public string TRAN_NO { get; set; }
        public string Key_1 { get; set; }
        public string Key_2 { get; set; }
        public string Key_3 { get; set; }
        public string TotalCount { get; set; }
        public string TotalAmount { get; set; }

        public List<QueryParkResultDetail> Detail { get; set; }
    }

    public class QueryParkResultDetail
    {
        public string SequenceNo { get; set; }
        public string OL_P_Check { get; set; }
        public string Field_1 { get; set; }
        public string Field_2 { get; set; }
        public string Field_3 { get; set; }
        public string Field_4 { get; set; }
        public string Field_5 { get; set; }
        public string Field_6 { get; set; }
        public string Field_7 { get; set; }
        public string Field_8 { get; set; }
        public string Field_9 { get; set; }
        public string Field_10 { get; set; }

    }
}