using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace AllPayWebServiceTest.Controllers
{
    public class MockTinyURLController : BaseController
    {
        //
        // GET: /MockTinyURL/

        public ActionResult AddUrl()
        {

            string testHashKey = "J1d9jJos0duyn1oP";    //stage環境
            string testHashIv = "xYeufjniLEJH8FJW";
            string postUrl = "http://p-stage.allpay.com.tw/tinyurl/Add";

            string XMLData = "Http://www.allpay.com.tw";
            string encryXMLData = new AllPay.ShareLib.Crypt().AES_EnCrypt(testHashKey, testHashIv, XMLData);

            Dictionary<string, string> postCollection = new Dictionary<string, string>();

            postCollection.Add("url", encryXMLData);

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postUrl, RequestTable);

            ViewBag.SendResult = ServerResponse;

            return View();
        }

    }
}
