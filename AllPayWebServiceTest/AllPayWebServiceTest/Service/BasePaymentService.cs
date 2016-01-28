using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AllPay.ShareLib;
using AllPayWebServiceTest.ApiWS;
using AllPayWebServiceTest.Models;

namespace AllPayWebServiceTest.Service
{
    public class BasePaymentService
    {

        public BasePaymentService()
        {
            //記錄log

            //判斷系統是否維謢中
        }

        /// <summary>
        /// 取得特店的加密key
        /// </summary>
        /// <param name="mid">特店編號</param>
        /// <returns></returns>
        public virtual MerchantFunction GetMerchantHashKey(long mid)
        {
            try
            {
                //### 透過WebService取得Key與IV
                ApiWSSoapClient WS = new ApiWSSoapClient();
                ApiWS.AllPayMerchantFunction merchantFunction = WS.GetAllPayMerchantFunctionByMerchant(mid);

                MerchantFunction paymentMerchantFunction = new MerchantFunction();
                paymentMerchantFunction.MID = merchantFunction.MID;
                paymentMerchantFunction.PaymentTypeID = merchantFunction.PaymentTypeID;
                paymentMerchantFunction.PaymentSubTypeID = merchantFunction.PaymentSubTypeID;
                paymentMerchantFunction.HashIV = merchantFunction.HashIV;
                paymentMerchantFunction.HashKey = merchantFunction.HashKey;
                paymentMerchantFunction.States = merchantFunction.States;
                paymentMerchantFunction.Notes = merchantFunction.Notes;
                //paymentMerchantFunction.AllowedIP = merchantFunction.AllowedIP;

                return paymentMerchantFunction;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DoRequest(string requestUrl, Hashtable postData, string contentType = "application/x-www-form-urlencoded")
        {

            //Creating the Web Request.
            HttpWebRequest httpWebRequest = null;
            //HttpWebRequest httpWebRequest = HttpWebRequest.Create(requestUrl) as HttpWebRequest;

            //如果是https請求
            if (requestUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
                httpWebRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                httpWebRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            }

            //指定送出去的方式為POST
            httpWebRequest.Method = "POST";

            //設定要送出的參數; separated by "&"
            string data = SetPostFieldByHashtable(postData);

            //設定content type, it is required, otherwise it will not work.
            httpWebRequest.ContentType = contentType;

            string receiveData;
           
                //取得request stream 並且寫入post data
                using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    sw.Write(data);
                    sw.Close();
                }

                //取得server的reponse結果
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    receiveData = sr.ReadToEnd();
                }
           

            return receiveData;
        }


        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private string SetPostFieldByHashtable(Hashtable postData)
        {
            if (postData == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            foreach (DictionaryEntry variable in postData)
            {
                if (string.IsNullOrWhiteSpace(variable.Key.ToString()))
                {
                    builder.Append(variable.Value).Append('&');
                }
                else
                {
                    builder.Append(variable.Key + "=" + variable.Value).Append('&');
                }
            }

            return builder.ToString().TrimEnd(new char[] { '&' });
        }
    }
}