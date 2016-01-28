using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AllPayWebServiceTest.DevVirtualWs;
using AllPayWebServiceTest.Models;
using AllPayWebServiceTest.Service;

namespace AllPayWebServiceTest.Controllers
{
    [AllPayMockMethod]
    public class VirtualController : BaseController
    {
        private string currentEnv = "dev";    //dev、stage、prod

        string prodHashKey = "SM6zZHQvodchMaTk";         //for prod 888891
        string prodHashIv = "zf3MhCfhzwUZoGfi";

        //string prodHashKey = "HD5pZKkuG9DxrHfR";         //for prod 888996 
        //string prodHashIv = "XVqza2PuFnCHwWwM";

        string devHashKey = "fugvqTnG3ROx81MO";        //開發
        string devHashIv = "WkSfnqIaHLbUMV5X";

        string stageHashKey = "Zf1AjVRlwE4XjlF9";        //stage
        string stageHashIv = "Ps8hPWGtUW0PE3Gk";

        string hashKey = "";
        string hashIv = "";

        public VirtualController()
        {
            if (currentEnv == "prod")
            {
                hashKey = prodHashKey;
                hashIv = prodHashIv;
            }
            else if (currentEnv == "stage")
            {
                hashKey = stageHashKey;
                hashIv = stageHashIv;
            }
            else if (currentEnv == "dev")
            {
                hashKey = devHashKey;
                hashIv = devHashIv;
            }
            
        }

        public ActionResult Index()
        {

            string amount = "1500.00";
            int intAmount = Convert.ToInt32(string.Format("{0}",amount));
            BasePaymentService baseBouandaryPayment = new BasePaymentService();

            string omgXml = "4ynaiU+eFpsqSzr2/DfFbJo/uitfotYn197jNrb+xN8hk43n7xBLLmY+e1/9BHCEaAkhmlDlm60YBGiN2AkIxDGaRaC1TtcQt2Vh++B2gx55x37xJOnZ5lphjXhRN9ut+LylG+cXnxwzMCanQ1/bfeCzJUyQ2YOSTDdhTvTVOjLQXiRkIOxW9psAW5zc5cbVtakGNjvD8SXR7AygOVHuzeWH7wUWv5lPfAikRORUcIOISKsFAv8Z34ASxeJNRFU7BMGA7Ih/81ZkShUtThEplB51tqbizsYKkoQnUBu1D36uTJ5FemB7yGq/lZA5YKzUZpELSseGWBcS/OrPa/NSPSTlVh/vAV/oyPQOSGnO2YHz4vfd7VJ9OLHFTPdRM25e";
            string desXml = new AllPay.ShareLib.Crypt().AES_DeCrypt("HD5pZKkuG9DxrHfR", "XVqza2PuFnCHwWwM", omgXml);


            string xmlData =
                "4ynaiU+eFpsqSzr2/DfFbJo/uitfotYn197jNrb+xN8hk43n7xBLLmY+e1/9BHCEaAkhmlDlm60YBGiN2AkIxDGaRaC1TtcQt2Vh++B2gx55x37xJOnZ5lphjXhRN9utFZqQpk3x9yrBX1M+IepqVW4nfWQ1whxmElKe21Le+HLoVMQO+s63YocF6e56yn++PEwbQilaMopEeSpmTpZg/B2t+/78wmxqEnmqflisa4KQ6tpzdM7U03whkMXYXB7yO56EVgwDp+GEz+3/zDYRCfFbh9jCILyiCiNE7UCiO1oEuEdq0QnUEIVM4QGKuU2Hw4mcFs0W/3kSjoZzzEtbjA==";
            Hashtable postData = new Hashtable();
            postData.Add("XMLData", xmlData);

            //string postURL = "https://pay.omg.com.tw/Code/Purchase/Allpay/returnGoods.ashx";
            //string response = new AllPay.ShareLib.Network().FormPost(postURL, "?XMLData=" + xmlData);
            //string postStatus = baseBouandaryPayment.DoRequest(postURL, postData);     //避免ShareLib有https錯誤，暫時使用DoRequest

            //string response = new AllPay.ShareLib.Network().FormPost(postURL, "?XMLData=" + xmlData);

            string exchangeUrl = "https://pay.omg.com.tw/Code/Purchase/Allpay/noticeExchangeSNO.ashx";

            return null;
        }

        /// <summary>
        /// 模擬送退貨通知給OMG
        /// </summary>
        /// <returns></returns>
        public ActionResult SendChargBackNotify() 
        {
            string XMLData = "";
            string EnXMLData = "";

            //string MerchantID = "888996";
            //string MerchantTradeNo = "520120912000000373";
            //string TradeNo = "1209121232343651";
            //string Reason = HttpUtility.UrlEncode("不想玩了");
            //string ItemNo = "1";
            //string Amount = "6000";
    
            //string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

            ////string postURL = "https://pay.omg.com.tw/Code/Purchase/Allpay/returnGoods.ashx";


            ////BasePaymentService basePaymentService = new BasePaymentService();
            ////MerchantFunction merchantFunctionData = basePaymentService.GetMerchantHashKey(Convert.ToInt64(MerchantID));

            //XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            //XMLData += "<Root>";
            //XMLData += "<Data>";
            //XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            //XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            //XMLData += "<TradeNo>" + TradeNo + "</TradeNo>";
            //XMLData += "<ItemNo>" + ItemNo + "</ItemNo>";
            //XMLData += "<Reason>" + Reason + "</Reason>";
            //XMLData += "<TimeStamp>" + TimeStamp + "</TimeStamp>";
            //XMLData += "</Data>";
            //XMLData += "</Root>";

            ////string prodHashKey = "HD5pZKkuG9DxrHfR";         //for prod 888996 
            ////string prodHashIv = "XVqza2PuFnCHwWwM";

            //EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(prodHashKey, prodHashIv, XMLData);

            //string response = new AllPay.ShareLib.Network().FormPost(postURL, "XMLData=" + EnXMLData, "", 0, 65001);
            

            return View();
        }


        public ActionResult ChargeBack()
        {
            string esXml =
                "Q/nBl88fRVaQM9CRnkyAxCdL9S97b8yW4ACX6jf1lvP23nWGPH35hp04D2jEG8yZ+deWnLKgHSqfUHIoqdJEkCBOBrKjolUgo7aQhjtrW/1PAiRtmTyaMYktTCP88Lw9DT/jQiYgvFkGMBnGKBmsFw/vVkujZtGwtgXl4dUgNCj2kq1ZkkjJaLAAiTll9n0wCkYkizbKAAqeqGFHRJNmlxUxpBSmUHWm6sAeV1A8PhK7dx0V6c9Mk73VuRG9+7lwntJI6R3k26YWB5YNa4JVuXyRPck1ulz5e0M6jANkHNGAh04EU9q7YWK2y0djmUxEm2w4CKcv/dio+H+Ys7X+oDurOSup6rxmlJTPCRWOIJKpbhtr+VYrsbqfilDGyj5/YvAUszGePnKR7GHfSt3MbSC1AqUGHOzP3oNlaM3MGlBKOcfzq0jEQaA7zm+GU7vuGLDqIpd6bvwtdP/Eg4BdApmfAq3nHsLP1QNvO+YMI97aoeRvhVmuVIBY350vB5cxVovCyNz0HvCgYCr4xXjWmkeqh3u38fs4nxpe5G3z5rWE2c/oI7bBGEGDHrgT6Lyp";
            string desXml = new AllPay.ShareLib.Crypt().AES_DeCrypt("4j6pBXN4YxAn9A88", "F4YZt4wAr0NgsZA2", esXml);
            VirtualModel virtualModel = new VirtualModel();

            return View();
        }

        /// <summary>
        /// 測試virtual的退貨web service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChargeBack(VirtualModel model)
        {
            VirtualWS.VirtualSoapClient vs = new VirtualWS.VirtualSoapClient();
            StageVirtualWs.VirtualSoapClient stageVs = new StageVirtualWs.VirtualSoapClient();

            string XMLData = "";
            string EnXMLData = "";

            string EnData = "";
            string DeData = "";
            

            //string MerchantID = "1000139";
            //string MerchantTradeNo = "20120820222153";
            //string TradeNo = "20120820222201995707";
            //string ItemNo = "A001";
            //string Amount = "5";
            //string SNO = "NTMG-YCDT-ZJUB-SRUF";
            //string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

            string MerchantID = model.MerchantID;
            string MerchantTradeNo = model.MerchantTradeNo;
            string TradeNo = model.TradeNo;
            string ItemNo = model.ItemNo;
            string Amount = model.Amount;
            string SNO = model.SNO;
            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();



            //BasePaymentService basePaymentService = new BasePaymentService();
            //MerchantFunction merchantFunctionData = basePaymentService.GetMerchantHashKey(Convert.ToInt64(MerchantID));

            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + TradeNo + "</TradeNo>";
            XMLData += "<ItemNo>" + ItemNo + "</ItemNo>";
            XMLData += "<Amount>" + Amount + "</Amount>";
            XMLData += "<SNO>" + SNO + "</SNO>";
            XMLData += "<TimeStamp>" + TimeStamp + "</TimeStamp>";
            XMLData += "</Data>";
            XMLData += "</Root>";


            ViewBag.XMLData = XMLData;
            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);
            ViewBag.EnXMLData = EnXMLData;

            if (currentEnv == "prod")
            {
                 EnData = vs.ChargeBack(MerchantID, EnXMLData);
                 ViewBag.EnData = EnData;
            }
            else if(currentEnv == "stage")
            {
                EnData = stageVs.ChargeBack(MerchantID, EnXMLData);
                ViewBag.EnData = EnData;
            }
           

            DeData = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, EnData);
            ViewBag.DeData = DeData;

            return View("ChargeBackConfirm");
        }



        public ActionResult Exchange()
        {

            ExchangeModel exchangeModel = new ExchangeModel();

            return View();
        }

        /// <summary>
        /// 測試virtual的兌換web service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Exchange(ExchangeModel model)
        {
            VirtualWS.VirtualSoapClient vs = new VirtualWS.VirtualSoapClient();
            StageVirtualWs.VirtualSoapClient stageVs = new StageVirtualWs.VirtualSoapClient();
            DevVirtualWs.VirtualSoapClient devVs = new DevVirtualWs.VirtualSoapClient();

            string XMLData = "";
            string EnXMLData = "";

            string EnData = "";
            string DeData = "";

           

            //string MerchantID = "1000139";
            //string MerchantTradeNo = "20120820222153";
            //string TradeNo = "20120820222201995707";
            //string ItemNo = "A001";
            //string Amount = "5";
            //string SNO = "NTMG-YCDT-ZJUB-SRUF";
            //string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

            string MerchantID = model.MerchantID;
            string MerchantTradeNo = model.MerchantTradeNo;
            string TradeNo = model.TradeNo;
            string ItemNo = model.ItemNo;
            string Amount = model.Amount;
            string SNO = model.SNO;
            string PWD = model.PWD;
            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();



            //BasePaymentService basePaymentService = new BasePaymentService();
            //MerchantFunction merchantFunctionData = basePaymentService.GetMerchantHashKey(Convert.ToInt64(MerchantID));

            XMLData += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            XMLData += "<Root>";
            XMLData += "<Data>";
            XMLData += "<MerchantID>" + MerchantID + "</MerchantID>";
            XMLData += "<MerchantTradeNo>" + MerchantTradeNo + "</MerchantTradeNo>";
            XMLData += "<TradeNo>" + TradeNo + "</TradeNo>";
            XMLData += "<ItemNo>" + ItemNo + "</ItemNo>";
            XMLData += "<Amount>" + Amount + "</Amount>";
            XMLData += "<SNO>" + SNO + "</SNO>";
            XMLData += "<PWD>" + PWD + "</PWD>";
            XMLData += "<TimeStamp>" + TimeStamp + "</TimeStamp>";
            XMLData += "</Data>";
            XMLData += "</Root>";


            ViewBag.XMLData = XMLData;
            EnXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(hashKey, hashIv, XMLData);
            ViewBag.EnXMLData = EnXMLData;

            //DevVirtualWs.VirtualSoapClient devvs = new DevVirtualWs.VirtualSoapClient();
            //EnData = devvs.Exchange(MerchantID, EnXMLData);

           

            if (currentEnv == "prod")
            {
                EnData = vs.Exchange(MerchantID, EnXMLData);
                ViewBag.EnData = EnData;
            }
            else if (currentEnv == "stage")
            {
                EnData = stageVs.Exchange(MerchantID, EnXMLData);
                ViewBag.EnData = EnData;
            }
            else if (currentEnv == "dev")
            {
                EnData = devVs.Exchange(MerchantID, EnXMLData);
                ViewBag.EnData = EnData;
            }

            DeData = new AllPay.ShareLib.Crypt().AES_DeCrypt(hashKey, hashIv, EnData);
            ViewBag.DeData = DeData;

            return View("ChargeBackConfirm");
        }


        /// <summary>
        /// 測試Payment專案中，Virtual商品的訂單查詢Web Service
        /// </summary>
        /// <returns></returns>
        public ActionResult TestVirtualQueryTrade()
        {
            //string merchantId = "1000070";
            //string merchantTradeNo = "2012080919134";
            //string AesHashKey = "fugvqTnG3ROx81MO";
            //string AesHashIv = "WkSfnqIaHLbUMV5X";

            //XmlDocument XML = new XmlDocument();
            //XML.Load(HttpContext.Server.MapPath("~/App_Data/QueryVirtualTrade.xml"));
            //XmlElement EleItemData = (XmlElement)XML.SelectSingleNode("Root/Data");
            //XmlElement eleMerchantID = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantID");
            //XmlElement eleMerchantTradeNo = (XmlElement)XML.SelectSingleNode("Root/Data/MerchantTradeNo");
            //XmlElement eleTimeStamp = (XmlElement)XML.SelectSingleNode("Root/Data/TimeStamp");

            //eleMerchantID.InnerText = merchantId;
            //eleMerchantTradeNo.InnerText = merchantTradeNo;
            //long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            //eleTimeStamp.InnerText = epoch.ToString();

            //string encXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, XML.OuterXml);

            //VirtualSoapClient virtualService = new VirtualSoapClient();
            //string rtnXmlData = virtualService.QueryTrade(merchantId, encXMLData);
            //string desXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(AesHashKey, AesHashIv, rtnXmlData);

            //ViewBag.XmlData = desXmlData;
            return View();
        }


        /// <summary>
        /// 測試Payment專案中，Virtual商品的訂單查詢Web Service
        /// </summary>
        /// <returns></returns>
        public ActionResult TestVirtualQueryBySerialNo()
        {
            string SNO = "LJDR-LLMW-JWJH-XESC";
            string PWD = "CYFE-KFDI-OHFH-RJK";

            string AesHashKey = "HD5pZKkuG9DxrHfR";
            string AesHashIv = "XVqza2PuFnCHwWwM";

            //DevVirtualWs.VirtualSoapClient devVs = new DevVirtualWs.VirtualSoapClient();
            //string rtnXmlData = devVs.QueryBySerialNo(SNO, PWD);
            //string desXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(AesHashKey, AesHashIv, rtnXmlData);

            VirtualWS.VirtualSoapClient vs = new VirtualWS.VirtualSoapClient();
            string rtnXmlData = vs.QueryBySerialNo(SNO, PWD);

            string desXmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(AesHashKey, AesHashIv, rtnXmlData);

            //ViewBag.XmlData = desXmlData;
            return View();
        }

        
    }
}
