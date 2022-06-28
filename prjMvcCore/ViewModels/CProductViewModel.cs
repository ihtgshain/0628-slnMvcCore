﻿using Microsoft.AspNetCore.Http;
using prjMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCore.ViewModels
{
    public class CProductViewModel
    {
        public CProductViewModel()
        {
            _prod = new TProduct();
        }

        private TProduct _prod;
        public TProduct product
        {
            get { return _prod; }
            set { _prod = value; }
        }
        public int FId {
            get { return _prod.FId; }
            set { _prod.FId = value; }
        }
        //[DisplayName("品名")]
        public string FName {
            get { return _prod.FName; }
            set { _prod.FName = value; }
        }
        //[DisplayName("成本")]
        public decimal? FCost {
            get { return _prod.FCost; }
            set { _prod.FCost = value; }
        }
        //[DisplayName("在庫")]
        public string FQty {
            get { return _prod.FQty; }
            set { _prod.FQty = value; }
        }
        //[DisplayName("單價")]
        public decimal? FPrice {
            get { return _prod.FPrice; }
            set { _prod.FPrice = value; }
        }
        //[DisplayName("圖片")]
        public string FImagePath {
            get { return _prod.FImagePath; }
            set { _prod.FImagePath = value; }
        }
        public IFormFile photo { get; set; }
    }
}
