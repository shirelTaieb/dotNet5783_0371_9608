﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp1
{
    public enum OrderStatus { confirm, sent, deliveried };
    public class OrderForList
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }
    }
}