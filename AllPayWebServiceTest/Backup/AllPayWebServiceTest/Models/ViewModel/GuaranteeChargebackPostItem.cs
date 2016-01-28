using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllPayWebServiceTest.Models.ViewModel
{
    public class GuaranteeChargebackPostItem
    {
        [Required]
        public string ItemNo { get; set; }

        [Required]
        public int ChargebackQuantity { get; set; }

        [Required]
        public int ChargebackAmount { get; set; }
    }
}