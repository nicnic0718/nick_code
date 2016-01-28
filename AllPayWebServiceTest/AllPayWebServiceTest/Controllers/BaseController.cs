using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Security;
using AllPayWebServiceTest.Service;

namespace AllPayWebServiceTest.Controllers
{
    public class BaseController : Controller
    {

        public class AllPayMockMethod : AuthorizeAttribute
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);

                string realIP = new AllPay.ShareLib.Network().GetRemoteRealIP();

                if (ConfigService.BlockIp == true)
                {
                    if (!(realIP.StartsWith("172.16.30") || realIP.StartsWith("127.0.0.1")))
                    {
                        filterContext.Result = new HttpUnauthorizedResult();
                    }
                    else
                    {
                        filterContext.Result = null;
                    }

                }
                else {
                    filterContext.Result = null;
                }



            }
        }

        public void DoRequest(string requestUrl, string postData)
        {

            //Creating the Web Request.
            HttpWebRequest httpWebRequest = HttpWebRequest.Create(requestUrl) as HttpWebRequest;

            //指定送出去的方式為POST
            httpWebRequest.Method = "POST";

            //設定要送出的參數; separated by "&"
            string data = string.Format("XMLData={0}", postData);

            //設定content type, it is required, otherwise it will not work.
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                //取得request stream 並且寫入post data
                using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    sw.Write(data);
                    sw.Close();
                }

                string receiveData;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    receiveData = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {

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
            try
            {
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
            }
            catch (Exception exception)
            {
                receiveData = "連線錯誤";

                //log.Error("連線錯誤(BaseBoundaryPayment): :" + exception);
            }

            return receiveData;
        }


       

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
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
