using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace AllPayWebServiceTest.Controllers
{
    public class CommonController : BaseController
    {
        /// <summary>
        /// 自動Client Post
        /// </summary>
        /// <param name="waitForSecond">等待N秒之後再post form</param>
        /// <returns></returns>
        public ActionResult AutoSubmitForm(int waitForSecond = 0)
        {
            if (TempData["PostCollection"] == null || TempData["PostURL"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            string PostURL = Convert.ToString(TempData["PostURL"]);
            string outputChartSet = Convert.ToString(TempData["CharSet"]);
            string viewName = "AutoSubmitForm";

            string htmlString = GenHtmlFormString(PostURL, TempData["PostCollection"] as Dictionary<string, string>, waitForSecond);

            TempData["PostForm"] = htmlString;

            if (outputChartSet.ToLower() == "big5")
            {
                viewName = viewName + "BIG5";
                HttpContext.Response.AddHeader("Content-Type", "text/html; charset=big5");
                HttpContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("Big5");
            }

            return View(viewName);
        }

        private string GenHtmlFormString(string postUrl, Dictionary<string, string> postCollection, int waitForSecond = 0)
        {
            string FormID = "PostForm";

            StringBuilder strForm = new StringBuilder();
            StringBuilder strScript = new StringBuilder();

            //建立Form HTML Tag
            strForm.Append("<form id=\"" + FormID + "\" name=\"" + FormID + "\" action=\"" + postUrl + "\" method=\"POST\">");
            foreach (var Item in postCollection as Dictionary<string, string>)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + Item.Key + "\" value=\"" + Item.Value + "\">");
            }
            strForm.Append("</form>");

            //建立JavaScript
            if (0 != waitForSecond)
            {
                //等待N秒後才執行post
                int timedRedirect = waitForSecond * 1000;
                strScript.Append("<script type=\"text/javascript\">");
                strScript.Append("setTimeout(function() {");
                strScript.Append("var v" + FormID + " = document." + FormID + ";");
                strScript.Append("v" + FormID + ".submit();");
                strScript.Append("}," + timedRedirect + ");");

                strScript.Append("</script>");
            }
            else
            {
                strScript.Append("<script type=\"text/javascript\">");
                strScript.Append("var v" + FormID + " = document." + FormID + ";");
                strScript.Append("v" + FormID + ".submit();");
                strScript.Append("</script>");
            }

            return Convert.ToString(strForm) + Convert.ToString(strScript.ToString());
        }
    }
}
