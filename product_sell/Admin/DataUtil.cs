using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;

namespace product_sell.Admin
{
    public class DataUtil
    {
        SqlConnection con;

        public DataUtil()
        {
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";
            con = new SqlConnection(sqlCon);
        }

        public List<Product> Product()
        {
            List<Product> sp = new List<Product>();
            string sql = "select * from Product";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                Product p = new Product();
                p.product_id = (int)rd["product_id"];
                p.SKU = (string)rd["SKU"];
                p.description = (string)rd["description"];
                p.price = (decimal)rd["price"];
                p.stock = (int)rd["stock"];
                p.Category_catego = (int)rd["Category_catego"];
                p.image = (string)rd["image"];
                sp.Add(p);
            }
            con.Close();
            return sp;
        }
        //=======================
        public List<Category> Category()
        {
            List<Category> sp = new List<Category>();
            string sql = "select * from Category";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category dm = new Category();
                dm.category_id = (int)rd["category_id"];
                dm.name = (string)rd["name"];
                sp.Add(dm);
            }
            con.Close();
            return sp;
        }
        //===================
        public void ThemSP(Product p)
        {
            con.Open();
            string sql = "insert into Product values (@SKU, @description, @price, @stock, @Category_catego, @image)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("SKU", p.SKU);
            cmd.Parameters.AddWithValue("description", p.description);
            cmd.Parameters.AddWithValue("price", p.price);
            cmd.Parameters.AddWithValue("stock", p.stock);
            cmd.Parameters.AddWithValue("Category_catego", p.Category_catego);
            cmd.Parameters.AddWithValue("image", p.image);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void XoaSP(int product_id)
        {
            con.Open();
            String strSql = "delete from Product where product_id=@product_id";
            SqlCommand cmd = new SqlCommand(strSql, con);
            cmd.Parameters.AddWithValue("product_id", product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //========================
        public Product Layra1SP(int product_id)
        {
            List<Product> sp = new List<Product>();
            string sql = "select * from Product where product_id=@product_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("product_id", product_id);
            Product p = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                p = new Product();
                p.product_id = (int)rd["product_id"];
                p.SKU = (string)rd["SKU"];
                p.description = (string)rd["description"];
                p.price = (decimal)rd["price"];
                p.stock = (int)rd["stock"];
                p.Category_catego = (int)rd["Category_catego"];
                p.image = (string)rd["image"];
                
            }
            con.Close();
            return p;
        }

        //========================
        public void CapnhatSP(Product p)
        {
            con.Open();
            string sql = "update Product set SKU=@SKU, description=@description, price=@price, stock=@stock, Category_catego=@Category_catego, image=@image where product_id=@product_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("SKU", p.SKU);
            cmd.Parameters.AddWithValue("description", p.description);
            cmd.Parameters.AddWithValue("price", p.price);
            cmd.Parameters.AddWithValue("stock", p.stock);
            cmd.Parameters.AddWithValue("Category_catego", p.Category_catego);
            cmd.Parameters.AddWithValue("image", p.image);
            cmd.Parameters.AddWithValue("product_id", p.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Lấy danh sách tài khoản từ cơ sở dữ liệu
        public List<Account> Account()
        {
            List<Account> ds = new List<Account>();
            string sql = "select * from Customer";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Account cd = new Account();
                cd.customer_id = (int)rd["customer_id"];
                cd.first_name = (string)rd["first_name"];
                cd.last_name = (string)rd["last_name"];
                cd.email = (string)rd["email"];
                cd.password = (string)rd["password"];
                cd.address = (string)rd["address"];
                cd.phone_number = (string)rd["phone_number"];
                cd.role = (string)rd["role"];
                ds.Add(cd);
            }
            con.Close();
            return ds;
        }

        // Thêm tài khoản vào cơ sở dữ liệu
        public void Add(Account ac)
        {
            con.Open();
            string sql = "insert into Customer (first_name, last_name, email, password, address, phone_number, role) values (@first_name, @last_name, @email, @password, @address, @phone_number, @role)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@first_name", ac.first_name);
            cmd.Parameters.AddWithValue("@last_name", ac.last_name);
            cmd.Parameters.AddWithValue("@email", ac.email);
            cmd.Parameters.AddWithValue("@password", ac.password);
            cmd.Parameters.AddWithValue("@address", ac.address);
            cmd.Parameters.AddWithValue("@phone_number", ac.phone_number);
            cmd.Parameters.AddWithValue("@role", ac.role);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu chưa
        public bool IsEmailExists(string email)
        {
            string sql = "select count(1) from Customer where email = @Email";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0; // Nếu có ít nhất một bản ghi thì email đã tồn tại
        }

        // Kiểm tra xem số điện thoại đã tồn tại trong cơ sở dữ liệu chưa
        public bool IsPhoneNumberExists(string phoneNumber)
        {
            string sql = "select count(1) from Customer where phone_number = @PhoneNumber";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0; // Nếu có ít nhất một bản ghi thì số điện thoại đã tồn tại
        }
        public void Xoa(int customer_id)
        {
            con.Open();
            String sql = "delete from customer where customer_id=@customer_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customer_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Account LayAC(int customer_id)
        {
            List<Account> ds = new List<Account>();
            string sql = "select * from Customer where customer_id=@customer_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("customer_id", customer_id);
            SqlDataReader rd = cmd.ExecuteReader();
            Account ac = null;
            if (rd.Read())
            {
                ac = new Account();
                ac.customer_id = (int)rd["customer_id"];
                ac.first_name = (string)rd["first_name"];
                ac.last_name = (string)rd["last_name"];
                ac.email = (string)rd["email"];
                ac.password = (string)rd["password"];
                ac.address = (string)rd["address"];
                ac.phone_number = (string)rd["phone_number"];
                ac.role = (string)rd["role"];
            }
            con.Close();
            return ac;
        }
        public void Update(Account ac)
        {
            con.Open();
            string sql = "update Customer set first_name=@first_name, last_name=@last_name, email=@email, " +
                "password=@password, address=@address,phone_number=@phone_number, role=role  where customer_id=@customer_id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("first_name", ac.first_name);
            cmd.Parameters.AddWithValue("last_name", ac.last_name);
            cmd.Parameters.AddWithValue("email", ac.email);
            cmd.Parameters.AddWithValue("password", ac.password);
            cmd.Parameters.AddWithValue("address", ac.address);
            cmd.Parameters.AddWithValue("phone_number", ac.phone_number);
            cmd.Parameters.AddWithValue("role", ac.role);
            cmd.Parameters.AddWithValue("customer_id", ac.customer_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
