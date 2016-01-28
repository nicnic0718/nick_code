using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPayWebServiceTest.Models.ViewModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;

namespace AllPayWebServiceTest.Controllers
{
    public class TestBarcodeController : BaseController
    {
        //
        // GET: /TestBarcode/

        public string Index()
        {
            string TradePostUrl = "http://devpayment.allpay.com.tw:12005/App/Barcode/CreateBarcode";

            string AllPayHashKey = "BICfVOb61OogBe9l";
            string AllPayHashIV = "6XP1ATqYaEmE9wAp";

            string str = "{\"MID\":\"1000277\",\"LoginTokenID\":\"819328C8945248D2BE3BDD79BAB2BD19\",\"TimeStamp\":\"1438847402\",\"TradeType\":\"3\",\"CardID\":\"2\"}";

            //TradeData model = new TradeData();
            //model.CardID = "";
            //model.LoginTokenID = "";
            //model.MID = "";
            //model.TimeStamp = "";
            //model.TradeType = "";

            //string JsonStr = JsonConvert.SerializeObject(model);

            string d = new AllPay.ShareLib.Crypt().AES_EnCrypt(AllPayHashKey,AllPayHashIV,str);

            //post方法
            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("d", d);

            
            Hashtable RequestTable = new Hashtable();
            RequestTable.Add("d", d);


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(TradePostUrl, RequestTable);
            return ServerResponse;
            //TempData["PostCollection"] = PostDictionary;
            //TempData["PostURL"] = TradePostUrl;

            ////將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            //return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
