using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AllPayWebServiceTest.Controllers
{
    public class CheckXmlDataController : Controller
    {
        //
        // GET: /CheckXmlData/

        public ActionResult Payment()
        {
           
            return View();
        }

        /// <summary>
        /// 測試訂單的XML資料是否正確
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentCeneter()
        {
            //### 建立KeyCrypt物件
            AllPay.ShareLib.KeyCrypt _keyCrypt = new AllPay.ShareLib.KeyCrypt();

            string deHashKey = _keyCrypt.DeCrypt("AGkQgnTfBOClgtRSVI5RPc6abMihC2+8/z70hlN9Ezt=");
            string deHashIV = _keyCrypt.DeCrypt("ssCLnmJYxU7grRxnEF9Y+XEI7B8Ye4/lx2sEpJe2NRu=");

            string tradeXML = "VjiKskbhRlwoR7RfzGjihxB1aFStOd2mhSWqoimj4R3ztRaV0E5CNmyBtTFnhE5emW4H0E9VpNbRoCK1g4cp5rIEe3NYjI7 DIUDyBqvO4tY hRiY3q/ZmblU2E8f7CeCkr/UaJoWF3Qk 2p9CHZm7ywqx3OPZk7fJGpDNe5GTmMXFDb4z5PLAooN5K JLEvlUS3CBzfPOcxDxnUv3ho7GcHJ5RRf5/OFV9ynNt1zV g8JcFo/m/8GG3d8I m94yvLe6KhaRN4IoBzGRyn32LHBjiI4E6bsXwNs6NygznHk528tDEs8rb3eDu9oxvFfrzVLqMmieb6uqO9FeNWsPBPhTnQA/lGNp LZiUAnc3MoYMAP YmouBWPYHgG7WnP614R614AER9hzRDK64qJ6W466uBGcRV0OeKUuL511eEGWw5X MGrOcUHW9jOh2Uiu8nqr7SOy5DYYBwSyrcbA5AcWgjDQHkuI8KDZxlhDLL9Mrou71aRJYlkMA6so4IXm22gD4BnNQgc5PiU0eXCwko0MVP7oV1eQWtNzkyIpp3JDLEYRFASjzt1Rvx5Rm67RxWLJ6svSEpvudA4P5L6oCR2b5uOsDPrvu89yu XOiZMXyK/1vCo8MOFk1uTKyK3l";
            tradeXML = tradeXML.Replace(' ', '+');
            string xmlData = new AllPay.ShareLib.Crypt().AES_DeCrypt(deHashKey, deHashIV, tradeXML);
            //xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Data><MerchantID>1020258</MerchantID><MerchantTradeN>1234567</MerchantTradeN><MerchantTradeDate>2013/08/03 05:00:00</MerchantTradeDate><TradeAmount>200</TradeAmount><TradeType>CVS_IBON</TradeType><TradeDesc>credit</TradeDesc><Desc_1></Desc_1><Desc_2></Desc_2><Desc_3></Desc_3><Desc_4></Desc_4><ReplyURL>http://173.255.242.213/buy/allpayPaidData.php</ReplyURL><Remark></Remark></Data></Root>\n\n\n\n\n\n\n\n\n\n";

            try
            {
                XDocument xDoc = XDocument.Parse(xmlData);
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add(string.Empty, HttpContext.Server.MapPath("~/App_Data/XSD/PaymentCenterCVSTrade.xsd"));
                xDoc.Validate(schemas, null);
            }
            catch (Exception exception)
            {
                string exceptionMsg = exception.Message.Replace("'", " ");
            }

            return View();
        }
    }
}
