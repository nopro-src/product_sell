--use master
--drop database Shopping
create database Shopping1
go
use Shopping1
go
-- Tạo bảng Customer
CREATE TABLE Customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(100),	
    last_name NVARCHAR(100),
    email NVARCHAR(100),
    password NVARCHAR(100),
    address NVARCHAR(100),
    phone_number NVARCHAR(100),
    role NVARCHAR(50) NOT NULL,
    CONSTRAINT chk_role CHECK (role IN ('Customer', 'Admin'))
);


-- Tạo bảng Category
CREATE TABLE Category (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100)
);

-- Tạo bảng Product
CREATE TABLE Product (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    SKU NVARCHAR(100),
    description NVARCHAR(100),
    price DECIMAL(10, 2),
    stock INT,
    Category_catego INT,
    FOREIGN KEY (Category_catego) REFERENCES Category(category_id),
	image nvarchar(100)
);
--ALTER TABLE Product
--ADD image nvarchar(100);

-- Tạo bảng Cart
CREATE TABLE Cart (
    cart_id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    Customer_customer_id INT,
    Product_product_id INT,
    FOREIGN KEY (Customer_customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (Product_product_id) REFERENCES Product(product_id)
);

-- Tạo bảng Wishlist
CREATE TABLE Wishlist (
    wishlist_id INT IDENTITY(1,1) PRIMARY KEY,
    Customer_customer_id INT,
    Product_product_id INT,
    FOREIGN KEY (Customer_customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (Product_product_id) REFERENCES Product(product_id)
);


-- Tạo bảng Payment
CREATE TABLE Payment (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    payment_date DATETIME,
    payment_method VARCHAR(100),
    amount DECIMAL(10, 2),
    Customer_custome INT,
    FOREIGN KEY (Customer_custome) REFERENCES Customer(customer_id)
);

-- Tạo bảng Shipment
CREATE TABLE Shipment (
    shipment_id INT IDENTITY(1,1) PRIMARY KEY,
    shipment_date DATETIME,
    address NVARCHAR(100),
    city NVARCHAR(100),
    state NVARCHAR(20),
    country NVARCHAR(50),
    zip_code NVARCHAR(10),
    Customer_custom INT,
    FOREIGN KEY (Customer_custom) REFERENCES Customer(customer_id)
);

-- Tạo bảng Order
CREATE TABLE [Order] (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    order_date DATETIME,
    total_price DECIMAL(10, 2),
	status VARCHAR(20) NOT NULL DEFAULT 'processing',
    Customer_custo INT,
    Payment_payme INT,
    Shipment_shipm INT,
    FOREIGN KEY (Customer_custo) REFERENCES Customer(customer_id),
    FOREIGN KEY (Payment_payme) REFERENCES Payment(payment_id),
    FOREIGN KEY (Shipment_shipm) REFERENCES Shipment(shipment_id)
);
--ALTER TABLE [Order]
--ADD status VARCHAR(20) NOT NULL DEFAULT 'processing';


-- Tạo bảng Order_Item
CREATE TABLE Order_Item (
    order_item_id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    price DECIMAL(10, 2),
    Product_produ INT,
    Order_order_i INT,
    FOREIGN KEY (Product_produ) REFERENCES Product(product_id),
    FOREIGN KEY (Order_order_i) REFERENCES [Order](order_id)
);

-- Thêm cột image nvarchar(100) vào bảng Product
--alter table Product add image nvarchar(100)
-- Nhập ít nhất 2 danh mục (category)
insert into Category values (N'Quần')
insert into Category values (N'Áo')
insert into Category values (N'Giày')

-- Nhập mỗi danh mục it nhất 5 sản phẩm 
insert into Product values ('sku1', N'Quần Jeans', 100000, 100, 1, N'anh1.png')
insert into Product values ('sku2', N'Quần bò', 150000, 200, 1, N'anh2.png')
insert into Product values ('sku3', N'Quần vải', 110000, 200, 1, N'anh3.png')
insert into Product values ('sku4', N'Quần shorts', 140000, 50, 1, N'anh4.png')
insert into Product values ('sku5', N'Quần Leggings', 200000, 100, 1, N'anh5.png')
insert into Product values ('sku6', N'Quần què', 300000, 200, 1, N'anh6.png')
	--
insert into Product values ('sku1', N'Áo Polo', 100000, 155, 2, N'anh1.png')
insert into Product values ('sku2', N'Áo phông', 150000, 30, 2, N'anh1.png')
insert into Product values ('sku3', N'Áo sơ mi', 110000, 80, 2, N'anh1.png')
insert into Product values ('sku4', N'Áo khoác', 140000, 90, 2, N'anh1.png')
insert into Product values ('sku5', N'Áo thun', 200000, 100, 2, N'anh1.png')
insert into Product values ('sku6', N'Áo mưa', 300000, 100, 2, N'anh1.png')
	--
insert into Product values ('sku1', N'Áo Polo', 100000, 90, 3, N'anh1.png')
insert into Product values ('sku2', N'Áo phông', 150000, 20, 3, N'anh1.png')
insert into Product values ('sku3', N'Áo sơ mi', 110000, 110, 3, N'anh1.png')
insert into Product values ('sku4', N'Áo khoác', 140000, 220, 3, N'anh1.png')
insert into Product values ('sku5', N'Áo thun', 200000, 100, 3, N'anh1.png')
insert into Product values ('sku6', N'Áo mưa', 300000, 50, 3, N'anh1.png')
--- Tạo 3 customer
insert into Customer values(N'Trung', N'Kiên', 'admin@gmail.com', 'abc123', N'Hà Nam', '0123456789', 'Admin')
insert into Customer values(N'Nguyễn', N'Kiên', 'kien1@gmail.com', 'abc123', N'Hà Nam', '0123456789','Customer')
insert into Customer values(N'Nguyễn', N'Ánh', 'kien2@gmail.com', 'abc123', N'Hà Nam', '0123456789','Customer')
insert into Customer values(N'Phạm', N'Bảo', 'kien3@gmail.com', 'abc123', N'Hà Nam', '0123456789','Customer')

--- Tạo 4 sản phẩm cho khách hàng 1 trong giỏ hàng
insert into Cart values(3, 2, 1)
insert into Cart values(2, 2, 2)
insert into Cart values(1, 2, 3)
insert into Cart values(1, 2, 6)
-- Tao 3 sản phẩm cho khách hàng 2 trong giỏ hàng
insert into Cart values(3, 3, 1)
insert into Cart values(2, 3, 2)
insert into Cart values(1, 3, 3)
-- Tạo 2 sản phẩm cho khách hàng 3 trong giỏ hàng
insert into Cart values(3, 4, 1)
insert into Cart values(2, 4, 2)

-- Tạo dữ liệu cho bảng Shipment
insert into Shipment values('2024-12-13',N'Địa chỉ 1',N'Hà Nam', N'ABC', N'Việt Nam', '084', 2)
insert into Shipment values('2024-12-13',N'Địa chỉ 2',N'Hà Nam', N'ABC', N'Việt Nam', '084', 3)
insert into Shipment values('2024-12-13',N'Địa chỉ 3',N'Hà Nam', N'ABC', N'Việt Nam', '084', 4)
 -- Tạo dữ liệu cho bảng Payment
 -- Chèn dữ liệu vào bảng Payment
insert into Payment (payment_date, payment_method, amount, Customer_custome)
values 
('2024-12-13', 'Credit Card', 500000, 2),  -- Thanh toán bằng thẻ tín dụng của khách hàng 1
('2024-12-14', 'PayPal', 300000, 3),     -- Thanh toán bằng PayPal của khách hàng 2
('2024-12-15', 'Bank Transfer', 450000, 4); -- Thanh toán bằng chuyển khoản ngân hàng của khách hàng 3


-- Cho khách hàng 1 đặt hàng 4 sản phẩm
-- Tạo đơn hàng cho khách hàng 1
insert into [Order] (order_date, total_price, status, Customer_custo, Payment_payme, Shipment_shipm)
values ('2024-12-13', 600000, 'processing', 2, 1, 1);

-- Lấy order_id vừa tạo cho khách hàng 1 (giả sử là 1)
declare @order_id_1 int;
set @order_id_1 = (select top 1 order_id from [Order] where Customer_custo = 2 order by order_id desc);

-- Tạo 4 sản phẩm trong đơn hàng của khách hàng 1
insert into Order_Item (quantity, price, Product_produ, Order_order_i)
values (2, 100000, 1, @order_id_1), 
       (2, 150000, 2, @order_id_1), 
       (2, 110000, 3, @order_id_1),
       (2, 200000, 6, @order_id_1);

-- Cho khách hàng 2 đặt hàng 3 sản phẩm
-- Tạo đơn hàng cho khách hàng 2
insert into [Order] (order_date, total_price, status, Customer_custo, Payment_payme, Shipment_shipm)
values ('2024-12-13', 500000, 'processing', 3, 2, 2);

-- Lấy order_id vừa tạo cho khách hàng 2
declare @order_id_2 int;
set @order_id_2 = (select top 1 order_id from [Order] where Customer_custo = 3 order by order_id desc);

-- Tạo 3 sản phẩm trong đơn hàng của khách hàng 2
insert into Order_Item (quantity, price, Product_produ, Order_order_i)
values (1, 100000, 1, @order_id_2),
       (2, 150000, 2, @order_id_2),
       (1, 110000, 3, @order_id_2);

-- Cho khách hàng 3 đặt hàng 2 sản phẩm
-- Tạo đơn hàng cho khách hàng 3
insert into [Order] (order_date, total_price, status, Customer_custo, Payment_payme, Shipment_shipm)
values ('2024-12-13', 250000, 'processing', 4, 3, 3);

-- Lấy order_id vừa tạo cho khách hàng 3
declare @order_id_3 int;
set @order_id_3 = (select top 1 order_id from [Order] where Customer_custo = 4 order by order_id desc);

-- Tạo 2 sản phẩm trong đơn hàng của khách hàng 3
insert into Order_Item (quantity, price, Product_produ, Order_order_i)
values (1, 100000, 1, @order_id_3),
       (1, 150000, 2, @order_id_3);


select * from Customer
select * from Product
select * from Category
select * from Cart
select * from [Order]
select * from Order_Item
select * from Payment
select * from Shipment

-- THỐNG KÊ BÁN HÀNG
--Tổng tất cả
select sum(quantity * price) as Total_Amount
From Order_Item
	
--Tổng tiền từng đơn hàng
SELECT
    o.order_id,
    SUM(oi.quantity * oi.price) AS total_amount,
	SUM(oi.quantity) AS total_quantity
FROM
    [Order] o
JOIN
    Order_Item oi ON o.order_id = oi.Order_order_i
GROUP BY
    o.order_id;

--Hiển thị top bán chạy
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
    total_quantity_sold DESC;

--Hiển thị lịch sử mua hàng
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
    c.customer_id, o.order_date DESC, o.order_id;