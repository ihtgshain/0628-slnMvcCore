using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMvcCore.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        [DisplayName("品名")]
        public string FName { get; set; }
        [DisplayName("成本")]
        public decimal? FCost { get; set; }
        [DisplayName("在庫")]
        public string FQty { get; set; }
        [DisplayName("單價")]
        public decimal? FPrice { get; set; }
        [DisplayName("圖片")]
        public string FImagePath { get; set; }
    }
}
