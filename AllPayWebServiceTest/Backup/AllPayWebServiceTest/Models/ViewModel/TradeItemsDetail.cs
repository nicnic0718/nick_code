using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class TradeItemsDetail
    {
        //交易記錄流水號
        public long AllPayTradeID { get; set; }

        //商品流水號，同一個交易編號內的流水號不可重複
        public string ItemNo { get; set; }

        //商品名稱(請依據 EncodeChartset欄位進行UrlEncode )
        public string ItemName { get; set; }

        //商品數量
        public string Quantity { get; set; }

        //商品單價
        public int Price { get; set; }

        //商品小計
        public int SubTotalAMT { get; set; }

        //商品網址(請依據 EncodeChartset欄位進行UrlEncode )
        public string ItemURL { get; set; }

        //商品狀態
        public string ItemStatus { get; set; }

        //商品猶豫期時間，單位為小時
        public int ConsiderHour { get; set; }

        //出貨狀況(5:出貨 / 6:無貨可出 / 7:延遲出貨)
        public string ShippingState { get; set; }

        //預購型商品必須填寫預計出貨日，其餘可不填
        public string ShippingDate { get; set; }

        //商品送達日期時間
        public string DeliveryDate { get; set; }

        //貨運單號
        public string ItemTrackingNo { get; set; }

        //賣家回報狀態

        public string VendorReplyStatus { get; set; }

        //賣家回報日期
        public string VendorReplyDate { get; set; }

        //賣家回報備註
        public string VendorComment { get; set; }

        //買家回報狀態
        public string BuyerReplyStatus { get; set; }

        //買家回報日期
        public string BuyerReplyDate { get; set; }

        //買家回報備註
        public string BuyerReplyComment { get; set; }

        //截圖狀態 0: 未截圖, 1:截圖成功 2:截圖失敗
        public int SnapshotStatus { get; set; }

        //缺貨通知日期
        public string BackorderNoticeDate { get; set; }

        //------以下為非AllPay_Payment_TradeItemsDetail的欄位
        public string AllPayTradeNo { get; set; }
    }
}