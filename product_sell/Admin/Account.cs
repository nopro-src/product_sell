using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product_sell.Admin
{
    public class Account
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string role { get; set; }

        public Account(int customer_id, string first_name, string last_name, string email, string password, string address, string phone_number, string role)
        {
            this.customer_id = customer_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.password = password;
            this.address = address;
            this.phone_number = phone_number;
            this.role = role;
        }

        public Account()
        {
        }
    }

}