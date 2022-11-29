﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public Category? Category { get; set; }
        public int InStock { get; set; }
        public override string ToString() => $@"
	Product ID={ID}: 
        Product Name {Name}, 
    	Price: {Price},
        Category - {Category},
    	Amount in stock: {InStock}
	";
    }
}