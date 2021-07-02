using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class OrderRequest
    {
        public int DrugId { get; set; }
        public double Quantity { get; set; }
    }
}
