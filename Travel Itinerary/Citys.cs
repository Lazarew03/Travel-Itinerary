using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Itinerary
{
    internal class Citys
    {
        public Citys(int id, string name, double price, double transit, double tax)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.transit = transit;
            this.tax = tax;
        }
        public Citys(int id, string name, double price, double transit)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.transit = transit;
            tax = 1;
        }

        public override string ToString()
        {
            return $"{id} {name} {price} {transit} {tax}";
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double transit { get; set; }
        public double tax { get; set; }

    }
}
