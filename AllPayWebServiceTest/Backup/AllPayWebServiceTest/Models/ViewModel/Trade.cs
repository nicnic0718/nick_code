using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class Trade
    {
        private TradeNo tradeNo = new TradeNo();
        public TradeNo TradeNo { get { return tradeNo; } set { tradeNo = value; } }

        private TradeDetail tradeDetail = new TradeDetail();
        public TradeDetail TradeDetail { get { return tradeDetail; } set { tradeDetail = value; } }

        private List<TradeItemsDetail> tradeItemsDetailList = new List<TradeItemsDetail>();
        public List<TradeItemsDetail> TradeItemsDetailList { get { return tradeItemsDetailList; } set { tradeItemsDetailList = value; } }
    }
}