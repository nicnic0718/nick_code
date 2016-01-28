using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace AllPayWebServiceTest.Controllers
{
    public class MockSMSController : BaseController
    {
        /// <summary>
        /// 測試發送簡訊的API
        /// </summary>
        /// <returns></returns>
        public ActionResult SendSMS()
        {

            //stage環境
            //string AllPayHashKey = "ejCk326UnaZWKisg";
            //string AllPayHashIV = "q9jcZX8Ib9LM8wYk";
            //long AllPayMerchantID = 2000132;
            //string postUrl = "http://sms-stage.allpay.com.tw/SMS/Send";

            //stage環境
            string AllPayHashKey = "SM6zZHQvodchMaTk";
            string AllPayHashIV = "zf3MhCfhzwUZoGfi";
            long AllPayMerchantID = 888891;
            string postUrl = "https://sms.allpay.com.tw/SMS/Send";

            string Phone = "0958389636";
            string SmsType = "0";
            string TimeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string MsgData = "測試簡訊";

            string postData = "&MerchantID=" + AllPayMerchantID
                           + "&Phone=" + Phone
                           + "&SmsType=" + SmsType
                           + "&TimeStamp=" + TimeStamp;

            string lowerDataToUrlEncode = HttpUtility.UrlEncode("HashKey=" + AllPayHashKey + postData + "&HashIV=" + AllPayHashIV);

            lowerDataToUrlEncode = "HashKey%3DA123456789012345%26MerchantID%3D999990001%26Phone%3D0917234601%26SmsType%3D0%26TimeStamp%3D1381302739%26HashIV%3DB123456789012345";
            string md5DataToLower = lowerDataToUrlEncode.ToLower();
                       
            string CheckMacValue = new AllPay.ShareLib.Crypt().MD5(md5DataToLower);


            Hashtable RequestTable = new Hashtable();
            RequestTable.Add("MerchantID", AllPayMerchantID.ToString());
            RequestTable.Add("Phone", Phone);
            RequestTable.Add("SmsType", SmsType);
            RequestTable.Add("TimeStamp", TimeStamp);
            RequestTable.Add("MsgData", MsgData);
            RequestTable.Add("CheckMacValue", CheckMacValue);


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.SendResult = ServerResponse;

            return View();
        }

    }
}
