﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}