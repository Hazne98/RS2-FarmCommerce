﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.SearchObjects
{
    public class ProizvodSearchObject : BaseSearchObject
    {
        public string? ImeProizvoda { get; set; }
        public string? FTS { get; set; }
    }
}
