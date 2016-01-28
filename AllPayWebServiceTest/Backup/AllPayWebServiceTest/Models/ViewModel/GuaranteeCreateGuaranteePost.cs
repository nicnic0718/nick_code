using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class GuaranteeCreateGuaranteePost
    {
        //廠商編號(AllPay會提供)
        [Required]
        public long MerchantID { get; set; }

        [Required]
        public string MerchantTradeNo { get; set; }

        [Required]
        public string TradeNo { get; set; }

        [Required]
        public string PaymentType { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int GuaranteeTotalAmount { get; set; }

        [Required]
        public List<GuaranteeCreateGuaranteePostItem> ItemData { get; set; }
    }
}