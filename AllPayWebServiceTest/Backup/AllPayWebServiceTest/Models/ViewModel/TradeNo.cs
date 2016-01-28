using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class TradeNo
    {
        //交易記錄流水號
        public long AllPayTradeID { get; set; }

        //交易編號
        public String AllPayTradeNo { get; set; }

        //付款方式代碼
        public int PaymentTypeID { get; set; }

        //收單行名稱代碼
        public int PaymentSubTypeID { get; set; }

        //交易總金額
        public int TradeTotalAMT { get; set; }

        //特店手續費(付款完畢後結算)
        public int HandlingCharge { get; set; }

        //建立日期
        public string CreateDate { get; set; }

        //交易狀態
        public String TradeStatus { get; set; }

        //會員編號
        public long MID { get; set; }

        //付款狀態 1: 已付款
        public int PaymentStatus { get; set; }

        //付款日期
        public string PaymentDate { get; set; }

        //會計結算日
        public string AccountingDate { get; set; }

        //退款金額
        public int RefundAMT { get; set; }

        //退款時間 (yyyyMMddHHmmss)
        public string RefundDate { get; set; }

        //實際交易總金額
        public int ActualTotalAMT { get; set; }
    }
}