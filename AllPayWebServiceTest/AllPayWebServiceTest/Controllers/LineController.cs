using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace AllPayWebServiceTest.Controllers
{
    public class LineController : Controller
    {
        //
        // GET: /Line/

        public ActionResult Index()
        {
            Socket SckSPort; // 先行宣告Socket

            string RmIp = "127.0.0.1";

            int RmPort = 17879;
            string[] aGroup = {};
            string Sender = "test1234";
            string Msg = "test1234";

            string receiveData = "ok";

            try
            {

                string sGroup = "*LINE*Tzong-Yo, *LINE*AllPayTestLINE, ";

                string sMsg = "";

                foreach (var Group in aGroup)
                {

                    sGroup += string.Format("{0},", Group);

                }

                sMsg = "[MSN=" + sGroup + "]" + Sender + " : " + Msg + "\r\n";

                SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                SckSPort.Connect(new IPEndPoint(IPAddress.Parse(RmIp), RmPort));

                Byte[] sendBytes = Encoding.Default.GetBytes(sMsg);

                SckSPort.Send(sendBytes);

                SckSPort.Close();

            }

            catch (Exception exception)
            {
                receiveData = exception.ToString();
            }


            return Content(receiveData);
        }

        public ActionResult TestLine()
        {

            PostGate.PostGateSoapClient PostGateWS = new PostGate.PostGateSoapClient();

            //string d = "[{\"Group\":[\"AllPayTestLINE\",\"AllPayTestLINE2\"], \"Sender\":\"ALLPAY\", \"Msg\":\"Test\"},{\"Group\":[\"AllPayTestLINE\",\"AllPayTestLINE2\"], \"Sender\":\"ALLPAY\", \"Msg\":\"Test2\"}]";
            //string d ="[{\"Group\":[\"AllPayTestLINE\"], \"Sender\":\"ALLPAY\", \"Msg\":\"Test\"}]";
            //var anonArray = new[] { new { Group = new[] { "AllPayTest" }, Sender = "錯誤提示Error", Msg = "測試訊息TestMsg~!@#$%^&*()_+|}{" }};
            var anonArray = new[] { new { Group = new[] { "AllPayTest", "AllPayTest" }, Sender = "[可自訂的訊息標頭]", Msg = "[訊息內容]" } };
            //var anonArray = new[] { new { Group = new[] { "AllPayTestLINE", "AllPayTestLINE2" }, Sender = "ALLPAY", Msg = "Test" }, new { Group = new[] { "AllPayTestLINE", "AllPayTestLINE2" }, Sender = "ALLPAY", Msg = "Test2" } };
            //var anonArray = new[] { new { Group = new[] { "AllPayTest" }, Sender = "錯誤提示Error", Msg = "測試訊息TestMsg~!@#$%^&*()_+|}{" }, new { Group = new[] { "AllPayTestLINE2" }, Sender = "ALLPAY", Msg = "Test2" } };
            //var anonArray = new[] { new { Group = new[] { "AllPayTestLINE","AllPayTestLINE2" }, Sender = "ALLPAY", Msg = "Test3" }, new { Group = new[] { "AllPayTestLINE2" }, Sender = "ALLPAY", Msg = "Test4" } };

            string d = JsonConvert.SerializeObject(anonArray);

            string RtnMsg = string.Empty;//PostGateWS.LineWarning(d);



            return Content(RtnMsg);
        }

    }
}
