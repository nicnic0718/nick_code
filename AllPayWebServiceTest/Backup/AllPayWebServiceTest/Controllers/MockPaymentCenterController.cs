using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using AllPayWebServiceTest.Models.ViewModel;


namespace AllPayWebServiceTest.Controllers
{
    public class MockPaymentCenterController : BaseController
    {
        //
        // GET: /PaymentCenter/

        public ActionResult Index()
        {

            return View();
        }

        public string ByteToString(byte[] dBytes)
        {
            string str;
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            return enc.GetString(dBytes);
        }

        public static string HexStr(byte[] p)
        {

            char[] c = new char[p.Length * 2 + 2];

            byte b;

            c[0] = '0'; c[1] = 'x';

            for (int y = 0, x = 2; y < p.Length; ++y, ++x)
            {

                b = ((byte)(p[y] >> 4));

                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);

                b = ((byte)(p[y] & 0xF));

                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);

            }

            return new string(c);

        }

        public byte[] Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                
             
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //tdes.KeySize = 192;
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.None;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, 24);

            return resultArray;
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            //复制于MSDN

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC; //默认值
                tdsp.Padding = PaddingMode.None; //默认值

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                tdsp.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// 測試導到第一銀行建立訂單
        /// </summary>
        /// <returns></returns>
        public ActionResult TestFirstBankCreateTrade() {

            XmlDocument XML = new XmlDocument();

            //讀取範本檔，要post到PaymentCenter
            XML.Load(HttpContext.Server.MapPath("~/App_Data/SendFirstBankWebATM.xml"));

            //取得XML的節點
            XmlElement eleSendSeqNo = (XmlElement)XML.SelectSingleNode("CardPayRq/SendSeqNo");
            XmlElement eleMID = (XmlElement)XML.SelectSingleNode("CardPayRq/MID");
            XmlElement eleFunCode = (XmlElement)XML.SelectSingleNode("CardPayRq/FunCode");
            XmlElement eleUserData = (XmlElement)XML.SelectSingleNode("CardPayRq/UserData");
            XmlElement eleONO = (XmlElement)XML.SelectSingleNode("CardPayRq/ONO");
            XmlElement eleInAccountNo = (XmlElement)XML.SelectSingleNode("CardPayRq/InAccountNo");
            XmlElement eleAmount = (XmlElement)XML.SelectSingleNode("CardPayRq/Amount");
            XmlElement eleMAC = (XmlElement)XML.SelectSingleNode("CardPayRq/MAC");
            XmlElement eleRsURL = (XmlElement)XML.SelectSingleNode("CardPayRq/RsURL");

            string postUrl = " https://teatm.firstbank.com.tw/acq/cardpay";
            string testMID = "T00535388511";
            string desKey = "N5IW8VYNG4PB4YPNXR23AEI9";
            string desIv = "00000000";

            string orderID = DateTime.Now.ToString("yyyyMMddHHmmss");
            //### 設定XML內容
            string SendSeqNo = orderID;
            string MID = testMID;
            string FunCode = "";
            string UserData = "歐付寶測試";
            string ONO = orderID;
            string InAccountNo = "1007122222222222";
            string CurAmt = "10";
            string MAC = GenerateTradeMAC(desKey, desIv, SendSeqNo, MID, ONO, InAccountNo, CurAmt);
            string RsURL = "https://pay.allpaya.com.tw/bank/first/cnt/webatm/result";



            eleSendSeqNo.InnerText = SendSeqNo;         //傳送序號，特店自編 (2年內需唯一)
            eleMID.InnerText = testMID;                     //繳費單位代碼
            eleFunCode.InnerText = FunCode;            
            eleUserData.InnerText = UserData;           //自定顯示資料
            eleONO.InnerText = ONO;                     //繳費編號，繳費單位自編 (2年內需唯一)
            eleInAccountNo.InnerText = InAccountNo;           //銷帳編號，虛擬帳號,純數字
            eleAmount.InnerText = CurAmt;               //金額
            eleMAC.InnerText = MAC;                     //押碼
            eleRsURL.InnerText = RsURL;                 //回傳URL(不可超過50個字)

            string CardBillRq = Convert.ToBase64String(Encoding.Default.GetBytes(XML.OuterXml));

            //設定要Post的資料
            Dictionary<string, string> PostCollection = new Dictionary<string, string>();
            PostCollection.Add("CardPayRq", CardBillRq);

            TempData["PostCollection"] = PostCollection;
            TempData["PostURL"] = postUrl;

            return RedirectToAction("AutoSubmitForm", "Common");

        }

        /// <summary>
        /// 測試第一銀行的訂單反查功能
        /// </summary>
        /// <returns></returns>
        public ActionResult TestFirstBankQueryTrade() { 
        
            FirstWebATMClientReturn FirstWebAtmClientReturnModel = new FirstWebATMClientReturn();

            string MID = "T00535388511";
            string orderCheckURL = "https://eatm.firstbank.com.tw/acq/cardpayinq";

            string toMacString = MID + "10444" ;     //TardeID

            string MAC = GenerateTradeMAC(toMacString);

            XmlDocument XML = new XmlDocument();

            //讀取範本檔
            XML.Load(Server.MapPath("~/App_Data/SendFirstWebATMOrderCheck.xml"));

            //取得XML的節點
            XmlElement eleSendSeqNo = (XmlElement)XML.SelectSingleNode("CardPayInqRq/SendSeqNo");
            XmlElement eleMID = (XmlElement)XML.SelectSingleNode("CardPayInqRq/MID");
            XmlElement eleMAC = (XmlElement)XML.SelectSingleNode("CardPayInqRq/MAC");

            eleSendSeqNo.InnerText = FirstWebAtmClientReturnModel.SendSeqNo;        //原傳送序號
            eleMID.InnerText = MID;                                                 //繳費單位代碼(台銀給定)
            eleMAC.InnerText = toMacString;                                                 //押碼

            string cardBillInqRq = Convert.ToBase64String(Encoding.Default.GetBytes(XML.OuterXml));

            string PostData = string.Format("CardPayInqRq={0}", cardBillInqRq);

            //Post至MP反查訂單狀態
            string resultXML = new AllPay.ShareLib.Network().FormPostReferrURL(orderCheckURL, "", PostData, 950);

            //Hashtable hashtable = new Hashtable();

            //hashtable.Add("CardPayInqRq", cardBillInqRq);

            //string resultXML = DoRequest(orderCheckURL, hashtable);

            return null;
        }



        /// <summary>
        /// 產生一銀的MAC欄位
        /// </summary>
        /// <returns></returns>
        private string GenerateTradeMAC(string toEncryptData)
        {
            String encryptedString = "";
            System.Text.Encoding encoding = System.Text.Encoding.Default;
            byte[] byteData;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            try
            {
                byteData = oSHA.ComputeHash(encoding.GetBytes(toEncryptData));
            }
            catch (Exception)
            {
                return "SHA1 Encrypt Error";
            }

            string desKey = "UKVVG8KD4M5GAPYTBYDDZKT6";    //一銀提供的key
            string desIv = "00000000";

            byte[] bteKey = System.Text.ASCIIEncoding.ASCII.GetBytes(desKey);
            byte[] bteIV = System.Text.ASCIIEncoding.ASCII.GetBytes(desIv);

            System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            tdes.Mode = System.Security.Cryptography.CipherMode.CBC;
            tdes.Padding = System.Security.Cryptography.PaddingMode.Zeros;

            try
            {
                encryptedString = Convert.ToBase64String(tdes.CreateEncryptor(bteKey, bteIV).TransformFinalBlock(byteData, 0, byteData.Length));
            }
            catch (Exception)
            {
                encryptedString = "TripleDES Encrypt Error";
            }

            return encryptedString;
        }


        //測試回傳給payment center 玉山ATM付款成功的動作
        public ActionResult TestEsunAtmReturnToPaymentCenter()
        {
            string procDate = "20130703";               //處理日期
            string virtualAccount = "9854207069217096".Substring(0, 15);         //要銷帳的虛擬帳號(玉山atm只會回傳15碼)
            string payAmount = "100";                    //繳款金額
            string payDate = "20130703105054";          //繳款日期

            string postData = string.Format("{0},銀行,1,{1},{2},{3}", procDate, virtualAccount, payAmount, payDate);
            
            //string relpyUrl = "http://devpaymentcenter.allpay.com.tw:12003/bank/esun/srv/atm/writeoffdata";
            string relpyUrl = "http://pay-stage.allpay.com.tw/bank/esun/srv/atm/writeoffdata";

            Hashtable hashtable = new Hashtable();

            hashtable.Add("Data", postData);

            //string response = new AllPay.ShareLib.Network().FormPost(relpyUrl, "Data=" + postData, "", 0, 65001);
            string serverResponse = DoRequest(relpyUrl, hashtable);

            return null;
        }


        //測試payment center的台灣銀行Web ATM收到銷帳檔
        public ActionResult TestPaymentCenterBotWebAtmWriteOff()
        {

            string desKey = "eyu5e5mv";
            string desIv = "00000000";
            string RC = "0";
            string MID = "A00087";
            string ONO = "94279";       //trade id(一定要改)
            string AcctIdTo = "20130731172504551411";   //Virtual Account(一定要改)
            string CurAmt = "30";     //付款金額(一定要改)
            string TrnDt = "20130731";  //付款日期(一定要改)

            string macValue = ReceiveMAC(desKey, desIv, RC, MID, ONO,AcctIdTo, CurAmt);

            string tradeXML = "<?xml version=\"1.0\" encoding=\"Big5\"?>"
                + "<CardBillRs>"
                + "<RC>"+ RC + "</RC>"
                + "<MSG>交易成功</MSG>"
                + "<SendSeqNo>53219</SendSeqNo>"
                + "<MID>" + MID + "</MID>"
                + "<TxnType>01</TxnType>"
                + "<ONO>" + ONO +"</ONO>"
                + "<AcctIdTo>" + AcctIdTo + "</AcctIdTo>"
                + "<CurAmt>" + CurAmt + "</CurAmt>"
                + "<TrnDt>" + TrnDt +"</TrnDt>"
                + "<TrnTime>230101</TrnTime>"
                + "<BankIdFrom>004</BankIdFrom>"
                + "<AcctIdFrom>29743</AcctIdFrom>"
                + "<DueDt>20130207</DueDt>"
                + "<TxnSeqNo>00000007</TxnSeqNo>"
                + "<PayTxnFee>0</PayTxnFee>"
                + "<MAC>" + macValue + "</MAC>"
                + "</CardBillRs>";


            string CardBillRs = Convert.ToBase64String(Encoding.Default.GetBytes(tradeXML));

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
                      

            postCollection.Add("CardBillRs", CardBillRs);           
            
            
            //string postURL = "http://devpaymentcenter.allpay.com.tw:12003/bank/bot/cnt/webatm/result";
            //string postURL = "http://pay-stage.allpay.com.tw/bank/bot/cnt/webatm/result";
            string postURL = "https://pay.allpay.com.tw/bank/bot/cnt/webatm/result";

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = postURL;

            return RedirectToAction("AutoSubmitForm", "Common");
            
        }
            

        /// <summary>
        /// 以收到台銀的資料，來重新產生MAC值
        /// </summary>
        /// <returns></returns>
        private string ReceiveMAC(string desKey, string desIv, string RC, string MID, string ONO, string AcctIdTo, string CurAmt)
        {
            //string sha1String = new AllPay.ShareLib.Crypt().SHA1(RC + MID + ONO + AcctIdTo + CurAmt);
            //string desString = new AllPay.ShareLib.Crypt().Des_EnCrypt(desKey, desIv, sha1String, CipherMode.CBC, PaddingMode.None);

            string base64String = new SECURITYLib.UseSecurity().Bot_Mac(RC + MID + ONO + AcctIdTo + CurAmt, desKey);

            return base64String;
        }

        //測試payment center的台灣銀行ATM收到銷帳檔
        public ActionResult TestPaymentCenterBotAtmWriteOff()
        {

            string txtData = "131656131656_20110224_000517        7   ,1000926,150550,3536052273150913,0000000030,131656,,,,I,1000926,902";
            //txtData = "135368135368_20121116_000002        9   ,1011119,173406,3536532324861771,0000000010,135368,8080000532968111786808289463300000000000,Matt測試,,A,1011116,225";
            Hashtable hashtable = new Hashtable();

            hashtable.Add("", txtData);

            //string ReturnURL = currentDomain + "/AuthWebATMTsib/ServerReturnData";
            string postURL = "http://devpaymentcenter.allpay.com.tw:12003/bank/taiwan/srv/atm/writeoffdata";
            //string postURL = "http://pay-stage.allpay.com.tw/bank/taiwan/srv/atm/writeoffdata";
            //string postURL = "https://pay.allpay.com.tw/bank/taiwan/srv/atm/writeoffdata";

            string rtnStatus = DoRequest(postURL, hashtable, "text/plain");

            return null;
        }

        //測試回傳給payment center 超商付款成功的動作
        public ActionResult TestCvsReturnToPaymentCenter()
        {
            string tradeId = "12341";       //payment center的交易編號
            string paymentType = "cvs";     //有兩種:barcode/cvs
            string tradeAmount = "30";  //金額
            string payNo = "GW121022924321";      //cvs的時候需要設定的繳費代碼

            string success = "1";   //0:付款失敗 / 1:付款成功
            string paidDate = "20121022";
            string procDate = "20121022";
            string procTIme = "183020";
            string tac = "b5b473cf4b5ed622cfcf64b7ba5174eff4ebe459";

            string postURL = "http://devpaymentcenter.allpay.com.tw:12003/bank/cvs/srv/result";

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("mer_id", "4321");
            postCollection.Add("PaymentType", paymentType);

            postCollection.Add("tsr", "12345");     //綠界的交易單號
            postCollection.Add("od_sob", tradeId);
            postCollection.Add("payno", payNo);
            postCollection.Add("amt", tradeAmount);
            postCollection.Add("succ", success);
            postCollection.Add("payfrom", "okmart");
            postCollection.Add("proc_date", procDate);
            postCollection.Add("proc_time", procTIme);
            postCollection.Add("tac", tac);
            postCollection.Add("trigger", "virtual");
            postCollection.Add("original_tsr", tradeId);
            postCollection.Add("paid_date", paidDate);


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


        //測試回傳給payment center 支付寶付款成功的動作
        public ActionResult TestAlipayReturnToPaymentCenter()
        {

            string mer_id = "4321";
            string payment_type = "alipay";
            string tsr = "123321";
            string od_sob = "12339";      //payment center的tradeID
            string amt = "30";         //付款金額
            string succ = "1";
            string alipay_buyer = "10000223";
            string alipay_no = "20120830111";
            string proc_date = "20121022";
            string proc_time = "162530";
            string mac = "1000070";

            string relpyUrl = "http://devpaymentcenter.allpay.com.tw:12003/bank/gw/srv/alipay/result";

            string getUrl = string.Format("mer_id={0}&payment_type={1}&tsr={2}&od_sob={3}&amt={4}&succ={5}&alipay_buyer={6}&alipay_no={7}&proc_date={8}&proc_time={9}&mac={10}"
                , mer_id, payment_type, tsr, od_sob, amt, succ, alipay_buyer, alipay_no, proc_date, proc_time, mac);

            string response = new AllPay.ShareLib.Network().FormPost(relpyUrl, getUrl, "", 0, 65001);
            //DoRequest(relpyUrl, XMLData);

            return null;
        }


        /// <summary>
        /// 中信無法模擬銀行端回來
        /// </summary>
        /// <returns></returns>
        public ActionResult TestChinatrustWebAtmToPaymentCenter()
        {

            //CTCB.Crypto.Encrypt ctcbEncrypt = new CTCB.Crypto.Encrypt();

            //ctcbEncrypt.WebATMAcct = "12345";   //虛擬帳號
            //ctcbEncrypt.OrderNo = "lidm1000001";
            //ctcbEncrypt.AuthAmt = "10000";

            //ctcbEncrypt.MerchantID = "8220000000001";
            //ctcbEncrypt.TerminalID = "99000001";
            //ctcbEncrypt.TxType = "9";          //WebATM 請填入9
            //ctcbEncrypt.AuthResURL = "https://test.com.tw/res.jsp";
            //ctcbEncrypt.BillShortDesc = "";
            //ctcbEncrypt.Note = "";
            //ctcbEncrypt.StoreName = "中文商店名稱";
            //ctcbEncrypt.Key = "12345678abcdabcd1234cdef";

            ////設定要Post的資料
            //Dictionary<string, string> postCollection = new Dictionary<string, string>();
            //postCollection.Add("TransactionNo", strTransactionNo);
            //postCollection.Add("Body", strBody);


            //TempData["PostCollection"] = postCollection;
            //TempData["PostURL"] = ReturnURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }


        #region 模擬中信ATM付款完成的虛擬帳號和金額
        public ActionResult TestChinatrustAtmToPaymentCenter()
        {
            string virtualAccount = "4939023381363440";  //虛擬帳號
            string payAmount = "0000000000030"; //交易金額(一定要13位數)
            string payDate = "1010928";  //入帳日期
            string strTransactionNo = "123456";
            string ReturnURL = "http://pay-stage.allpay.com.tw/bank/chinatrust/srv/atm/writeoffdata";
    
            string strBody = "1071184558062"+payDate+virtualAccount.Substring(5) +"aaa" + payAmount + "00"+ payDate 
                +"2331308222732564C+964100803010540000000000000000aaaaaaaaaaa49390000000000000000000000000000";
          
            strBody = strBody.Replace("a", " ");
           
            //虛擬帳號的範例
            //4939023323874861

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("TransactionNo", strTransactionNo);
            postCollection.Add("Body", strBody);
            

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = ReturnURL;

            return RedirectToAction("AutoSubmitForm", "Common");

        }
        #endregion


        #region 模擬富邦ATM及WebATM付款完成的資料送回payment center
        public ActionResult TestFubonAtmToPaymentCenter(string Data = "")
        {
            //富邦的web atm和atm的付款完成通知是同一個api
            string payDate = "20121128";    //付款日期
            string payAmount = "0000000000005";     //金額(要13碼)
            string virtualAccount = "8156382342089073";     //虛擬帳號
            string ReturnURL = "https://pay.allpay.com.tw/bank/fubon/srv/atm/writeoffdata";

            string testData = "71571511" + payDate + "02310959N" + payAmount + "00001" + virtualAccount + "                                                                                                                                                012 00007151682526400            " + payDate + "164606012000071516825****7154030";

            //設定要Post的資料
            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("Data", testData);

            TempData["PostCollection"] = postCollection;
            TempData["PostURL"] = ReturnURL;

            return RedirectToAction("AutoSubmitForm", "Common");
        }
        #endregion

       
        /// <summary>
        /// 測試payment center的web atm訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterWebATM()
        {

            long merchantId = 999999999;
            string merchantTradeNo = "26255";           //payment的tradeID


            string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";

            string relpyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/cnt/tenpay/result";
            string serverReplyUrl = "http://devpayment.allpay.com.tw:12005/bank/paymentcenter/srv/tenpay/result";

            //string relpyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/cnt/alipay/result";
            //string serverReplyUrl = "https://payment.allpay.com.tw/bank/paymentcenter/srv/alipay/result";

            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            //開發環境
            DevPaymentCenterWebATM.WebATMSoapClient devWebAtmQuery = new DevPaymentCenterWebATM.WebATMSoapClient();
            string rtnXmlData = devWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);

            //正式環境
            //ProdPaymentCenterWebATM.WebATMSoapClient prodWebAtmQuery = new ProdPaymentCenterWebATM.WebATMSoapClient();
            //string rtnXmlData = prodWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);


            return null;
        }


        /// <summary>
        /// 測試payment center的ATM訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterVirtualAccount()
        {

            long merchantId = 999999999;
            string merchantTradeNo = "26255";           //payment的tradeID


            string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";


            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            //開發環境
            DevPaymentCenterVirtualAccount.VirtualAccountSoapClient devVirtualAccountQuery = new DevPaymentCenterVirtualAccount.VirtualAccountSoapClient();
            var returnData = devVirtualAccountQuery.ATMQuery(merchantId, encryptMerchantTradeNo);

            //正式環境
            //ProdPaymentCenterWebATM.WebATMSoapClient prodWebAtmQuery = new ProdPaymentCenterWebATM.WebATMSoapClient();
            //string rtnXmlData = prodWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);


            return null;
        }

        /// <summary>
        /// 測試payment center的CVS訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterCVS()
        {

            //long merchantId = 999999999;
            //string merchantTradeNo = "26255";           //payment的tradeID

            //string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            //string AesHashIv = "WkSfnqIaHLbUMV5X";

            long merchantId = 2000132;               //stage環境
            string merchantTradeNo = "18";
            string AesHashKey = "ejCk326UnaZWKisg";
            string AesHashIv = "q9jcZX8Ib9LM8wYk";

            

            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            ////開發環境
            //DevPaymentCenterCVS.CVSSoapClient devCVSQuery = new DevPaymentCenterCVS.CVSSoapClient();
            //var returnData = devCVSQuery.CVSQuery(merchantId, encryptMerchantTradeNo);

            //正式環境
            //ProdPaymentCenterWebATM.WebATMSoapClient prodWebAtmQuery = new ProdPaymentCenterWebATM.WebATMSoapClient();
            //string rtnXmlData = prodWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);

            //----做post版的訂單查詢
            string postURL = "http://pay-stage.allpay.com.tw/payment/cvsquery";

            Dictionary<string, string> postCollection = new Dictionary<string, string>();
            postCollection.Add("MerchantID", merchantId.ToString());
            postCollection.Add("MerchantTradeNo", merchantTradeNo);
                    

            Hashtable RequestTable = new Hashtable();

            foreach (var item in postCollection)
            {
                RequestTable.Add(item.Key, item.Value);

            }


            //### 發送到Mp, 取得Response
            string ServerResponse = DoRequest(postURL, RequestTable);
                    

            return null;
        }


        /// <summary>
        /// 測試payment center的Alipay訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterAlipay()
        {

            long merchantId = 999999999;
            string merchantTradeNo = "26255";           //payment的tradeID


            string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";


            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            //開發環境
            DevPaymentCenterAlipay.alipaySoapClient devAlipayQuery = new DevPaymentCenterAlipay.alipaySoapClient();
            DevPaymentCenterAlipay.AlipayTradeQueryPost queryPost = new DevPaymentCenterAlipay.AlipayTradeQueryPost();
            queryPost.MerchantId = merchantId;
            queryPost.XMLData = encryptMerchantTradeNo;
            var returnData = devAlipayQuery.AlipayQuery(queryPost);

            //正式環境
            //ProdPaymentCenterWebATM.WebATMSoapClient prodWebAtmQuery = new ProdPaymentCenterWebATM.WebATMSoapClient();
            //string rtnXmlData = prodWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);

            return null;
        }


        /// <summary>
        /// 測試payment center的財富通訂單查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterTenpay()
        {

            long merchantId = 999999999;
            string merchantTradeNo = "26255";           //payment的tradeID


            string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";


            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            //開發環境
            DevPaymentCenterTenpay.TenpaySoapClient devAlipayQuery = new DevPaymentCenterTenpay.TenpaySoapClient();
            DevPaymentCenterTenpay.TenpayTradeQueryPost queryPost = new DevPaymentCenterTenpay.TenpayTradeQueryPost();
            queryPost.MerchantId = merchantId;
            queryPost.XMLData = encryptMerchantTradeNo;
            var returnData = devAlipayQuery.TenpayQuery(queryPost);

            //正式環境
            //ProdPaymentCenterWebATM.WebATMSoapClient prodWebAtmQuery = new ProdPaymentCenterWebATM.WebATMSoapClient();
            //string rtnXmlData = prodWebAtmQuery.WebATMQuery(merchantId, encryptMerchantTradeNo);

            return null;
        }


        /// <summary>
        /// 測試payment center的信用卡訂單查詢api
        /// </summary>
        /// <returns></returns>
        public ActionResult TestQueryPaymentCenterCreditCard()
        {

            long merchantId = 999999999;
            string merchantTradeNo = "15109";           //payment的tradeID


            string AesHashKey = "fugvqTnG3ROx81MO"; //開發機的key
            string AesHashIv = "WkSfnqIaHLbUMV5X";
            string queryUrl = "http://devpaymentcenter.allpay.com.tw:12003/payment/CreditCardQuery";


            //### 將merchantTradeNo透過AES加密
            string encryptMerchantTradeNo = new AllPay.ShareLib.Crypt().AES_EnCrypt(AesHashKey, AesHashIv, merchantTradeNo);

            //開發環境
            DevPaymentCenterCredit.creditcardSoapClient devCreditWS = new DevPaymentCenterCredit.creditcardSoapClient();
            var returnData = devCreditWS.QueryTrade(merchantId, encryptMerchantTradeNo);

            Hashtable postHashTable = new Hashtable();
            postHashTable.Add("MerchantID",merchantId);
            postHashTable.Add("MerchantTradeNo",encryptMerchantTradeNo);

            string postReturnData = DoRequest(queryUrl, postHashTable);
            

            return null;
        }


       

        private string GenerateTradeMAC(string desKey, string desIv, string SendSeqNo, string MID, string ONO, string InAccountNo, string Amount)
        {
            //Hex2Base64(DES(KEY,SHA-1(繳費單位代碼+繳費編號+銷帳編號+金額)))
            string sha1String = new AllPay.ShareLib.Crypt().SHA1(SendSeqNo + MID + ONO + InAccountNo + Amount);
            string desString = new AllPay.ShareLib.Crypt().TripleDes_DeCrypt(desKey, desIv,sha1String);
            string base64String = Convert.ToBase64String(Encoding.Default.GetBytes(desString));

            return base64String;
        }

    }
}
