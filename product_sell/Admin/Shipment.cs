using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product_sell.Admin
{
    public class Shipment
    {
        public int shipment_id { get; set; }
        public DateTime shipment_date { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip_code { get; set; }
        public int Customer_custom { get; set; }

        public Shipment(int shipment_id, DateTime shipment_date, string address, string city, string state, string country, string zip_code, int customer_custom)
        {
            this.shipment_id = shipment_id;
            this.shipment_date = shipment_date;
            this.address = address;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zip_code = zip_code;
            Customer_custom = customer_custom;
        }

        public Shipment()
        {
        }
    }
}