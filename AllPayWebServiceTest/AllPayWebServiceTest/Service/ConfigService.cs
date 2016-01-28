using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AllPayWebServiceTest.Service
{
    public class ConfigService
    {
        /// <summary>
        /// 模擬特店的HashKey
        /// </summary>
        public static string MerchantHashKey
        {
            get
            {
                string retVal = ConfigurationManager.AppSettings["MerchantHashKey"];

                if (retVal == null)
                {
                    return "";
                }

                return retVal;
            }
        }

        /// <summary>
        /// 模擬特店的HashIV
        /// </summary>
        public static string MerchantHashIV
        {
            get
            {
                string retVal = ConfigurationManager.AppSettings["MerchantHashIV"];

                if (retVal == null)
                {
                    return "";
                }

                return retVal;
            }
        }

        /// <summary>
        /// 特定API是否要開放特定IP才能使用
        /// </summary>
        public static bool BlockIp
        {
            get
            {
                string retVal = ConfigurationManager.AppSettings["BlockIp"];

                //沒設定就預設為要擋ip
                if (retVal == null)
                {
                    return true;
                }

                bool needBlockIp = Convert.ToBoolean(retVal);

                return needBlockIp;
            }
        }


        /// <summary>
        /// 取得AppLogin加密的 Key 值
        /// </summary>
        public string AppLoginKey
        {
            get
            {
                string retVal = ConfigurationManager.AppSettings["AppLoginKey"].ToString();

                if (retVal == null)
                {
                    return "";
                }

                return retVal;
            }
        }

        /// <summary>
        /// 取得AppLogin加密的 IV 值
        /// </summary>
        public string AppLoginIV
        {
            get
            {
                string retVal = ConfigurationManager.AppSettings["AppLoginIV"].ToString();

                if (retVal == null)
                {
                    return "";
                }

                return retVal;
            }
        }


    }
}