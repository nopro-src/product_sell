using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

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
        public List<Product> TimKiemTheoMa(int productId)
        {
            List<Product> sp = new List<Product>();
            string sql = "SELECT * FROM Product WHERE product_id = @productId";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@productId", productId);

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
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
        public List<Product> TimKiemTheoMoTa(string keyword)
        {
            List<Product> sp = new List<Product>();
            string sql = "SELECT * FROM Product WHERE description LIKE @keyword";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
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
        //Thống kê
        public DataTable GetSalesReport()
        {
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            string sql = @"
        SELECT
    o.order_id,
    SUM(oi.quantity * oi.price) AS total_amount,
	SUM(oi.quantity) AS total_quantity
FROM
    [Order] o
JOIN
    Order_Item oi ON o.order_id = oi.Order_order_i
GROUP BY
    o.order_id;";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy báo cáo doanh thu: " + ex.Message);
            }

            return dt;
        }

        //Lịch sử mua hàng
        public DataTable GetPurchaseHistory()
        {
            //            string sqlCon = "Data Source=LAPTOP-H87TDBVU\\VIETBACH;Initial Catalog=Shopping;Integrated Security=True";  // Kiểm tra chuỗi kết nối

            //            string sql = @"
            //SELECT 
            //    c.customer_id,
            //    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
            //    o.order_id,
            //    o.order_date,
            //    o.total_price,
            //    o.status,
            //    p.SKU,
            //    p.description AS product_name,
            //    oi.quantity,
            //    oi.price AS unit_price,
            //    (oi.quantity * oi.price) AS total_item_price
            //FROM 
            //    Customer c
            //JOIN 
            //    [Order] o ON c.customer_id = o.Customer_custo
            //JOIN 
            //    Order_Item oi ON o.order_id = oi.Order_order_i
            //JOIN 
            //    Product p ON oi.Product_produ = p.product_id
            //ORDER BY 
            //    c.customer_id, o.order_date DESC, o.order_id;";

            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);  // Sử dụng chuỗi kết nối tại đây
            //    DataTable dt = new DataTable();

            //    try
            //    {
            //        adapter.Fill(dt);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Có lỗi xảy ra khi lấy lịch sử mua hàng: " + ex.Message);
            //    }
            //    return dt;
            //}
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            string sql = @"
        SELECT 
    c.customer_id,
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    o.order_id,
    o.order_date,
    o.total_price,
    o.status,
    p.SKU,
    p.description AS product_name,
    oi.quantity,
    oi.price AS unit_price,
    (oi.quantity * oi.price) AS total_item_price
FROM 
    Customer c
JOIN 
    [Order] o ON c.customer_id = o.Customer_custo
JOIN 
    Order_Item oi ON o.order_id = oi.Order_order_i
JOIN 
    Product p ON oi.Product_produ = p.product_id
ORDER BY 
    c.customer_id, o.order_date DESC, o.order_id;";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy báo cáo doanh thu: " + ex.Message);
            }

            return dt;
        }
        //Top bán chạy
        public DataTable GetTopSellingProducts()
        {
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            string sql = @"
        SELECT 
    p.product_id, 
    p.SKU, 
    p.description, 
    SUM(oi.quantity) AS total_quantity_sold
FROM 
    Product p
JOIN 
    Order_Item oi ON p.product_id = oi.Product_produ
GROUP BY 
    p.product_id, p.SKU, p.description
ORDER BY 
    total_quantity_sold DESC;";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy báo cáo doanh thu: " + ex.Message);
            }

            return dt;
        }
        //Tổng thu nhập 
        public decimal GetTotalRevenue()
        {
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            string sql = @"
    select sum(quantity * price) as Total_Amount
    From Order_Item";

            decimal totalAmount = 0;  // Khởi tạo giá trị mặc định là 0

            try
            {
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Thực hiện truy vấn và lấy giá trị
                        var result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalAmount = Convert.ToDecimal(result);  // Chuyển đổi kết quả thành decimal
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy báo cáo doanh thu: " + ex.Message);
            }

            return totalAmount;  // Trả về tổng doanh thu dưới dạng decimal
        }   
    }
}
