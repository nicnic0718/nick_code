using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPayWebServiceTest.Models;
using Newtonsoft.Json;

namespace AllPayWebServiceTest.Controllers
{
    public class AllPayMemberController : BaseController
    {

        string prodHashKey = "";         //for prod 888891
        string prodHashIv = "";

        string devHashKey = "fugvqTnG3ROx81MO";        //開發 999999999
        string devHashIv = "WkSfnqIaHLbUMV5X";

        //string devHashKey = "koyqVBURmmkQxROZ";        //開發 1000070 
        //string devHashIv = "BcRITiCQaUHBZC1f";

        string betaHashKey = "Zf1AjVRlwE4XjlF9";        //for beta 1000039
        string betaHashIv = "Ps8hPWGtUW0PE3Gk";

        //string stageHashKey = "Zf1AjVRlwE4XjlF9";        //for stage 888891 
        //string stageHashIv = "Ps8hPWGtUW0PE3Gk";

        string stageHashKey = "5294y06JbISpM5x9";        //for stage 2000132  
        string stageHashIv = "v77hoKGq4kWxNNIS";

        string hashKey = "";
        string hashIv = "";

        public ActionResult PartnerMemberRegister()
        {
            //DEV環境
            string allpayHashKey = devHashKey;
            string allpayHashIv = devHashIv;
            string merchantId = "1000070";
            string tradePostUrl = "http://devmember.allpay.com.tw:12004/MerchantMemberApi/Register";

            ////beta環境
            //string allpayHashKey = betaHashKey;
            //string allpayHashIv = betaHashIv;
            //string merchantId = "1000039";
            //string tradePostUrl = "http://member-beta.allpay.com.tw/MerchantMemberApi/Register";

            PartnerMemberRegister partnerMemberModel = new PartnerMemberRegister();

            partnerMemberModel.MerchantID = merchantId;
            partnerMemberModel.MerchantMemberID = DateTime.Now.ToString("yyyyMMddHHmmss");
            partnerMemberModel.ServerReplyURL = "http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult";
            partnerMemberModel.ClientBackURL = "http://devmockmerchant.allpay.com.tw:12020/AllPayPayment/ReceiveOrderResult";
            partnerMemberModel.TimeStamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            string json = JsonConvert.SerializeObject(partnerMemberModel);
            string encodeJson = HttpUtility.UrlEncode(json, System.Text.Encoding.UTF8);
                     

            
            //string tradePostUrl = "http://member-stage.allpay.com.tw/MerchantMemberApi/Register";

            string PostUrl = tradePostUrl;
            string Contents = new AllPay.ShareLib.Crypt().AES_EnCrypt(allpayHashKey, allpayHashIv, encodeJson);
            
            string jsonData = new AllPay.ShareLib.Crypt().AES_DeCrypt(allpayHashKey, allpayHashIv, Contents.Replace(" ", "+"));
            jsonData = HttpUtility.UrlDecode(jsonData, System.Text.Encoding.UTF8);
                        
            //設定要Post的資料
            Dictionary<string, string> PostDictionary = new Dictionary<string, string>();
            PostDictionary.Add("MerchantID", merchantId.ToString());
            PostDictionary.Add("Contents", Contents);

            //設定要送到MP的資料
            TempData["PostCollection"] = PostDictionary;
            TempData["PostURL"] = PostUrl;

            //將要送給MP的資料，透過autoSubmitForm.cshtml傳給MP
            return RedirectToAction("AutoSubmitForm", "Common");
        }

    }
}
