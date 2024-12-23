using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product_sell.Admin
{
    public class Order
    {
        public int order_id { get; set; }
        public DateTime order_date { get; set; }
        public decimal total_price { get; set; }
        public string status { get; set; }
        public int Customer_custo { get; set; }
        public int Payment_payme { get; set; }
        public int Shipment_shipm { get; set; }

        public Order(int order_id, DateTime order_date, decimal total_price, string status, int customer_custo, int payment_payme, int shipment_shipm)
        {
            this.order_id = order_id;
            this.order_date = order_date;
            this.total_price = total_price;
            this.status = status;
            Customer_custo = customer_custo;
            Payment_payme = payment_payme;
            Shipment_shipm = shipment_shipm;
        }

        public Order()
        {
        }
    }
}