using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class GuaranteeCreateGuaranteePostItem
    {
        [Required]
        public string ItemNo { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int ItemType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int SubTotalAmount { get; set; }

        [Required]
        public int GuaranteeQuantity { get; set; }

        [Required]
        public int GuaranteeAmount { get; set; }
    }
}