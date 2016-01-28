using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AllPayWebServiceTest
{
    public class Line
    {
        public string Index()
        {
            Socket SckSPort; // 先行宣告Socket

            string RmIp = "172.16.30.31";

            int RmPort = 17879;
            string[] aGroup = {"aaa","bbb"};
            string Sender = "test";
            string Msg = "test";

            string receiveData = "ok";

            try
            {

                string sGroup = "";

                string sMsg = "";

                foreach (var Group in aGroup)
                {

                    sGroup = string.Format("{0},", aGroup);

                }

                sMsg = "[MSN=*LINE*" + sGroup + "]" + Sender + " : " + Msg + "\r\n";

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


            return receiveData;
        }
    }
}