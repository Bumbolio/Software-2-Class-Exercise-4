﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Models
{
    public class Product
    {
        public Guid ProductId {get; set;}
        public decimal Price { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}
