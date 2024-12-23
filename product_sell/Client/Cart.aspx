<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="product_sell.Client.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giỏ hàng</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background-color: #f9f9f9;
        }
        form {
            width: 90%;
            max-width: 800px;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }
        .cart-item {
            display: flex;
            align-items: center;
            border-bottom: 1px solid #ddd;
            padding: 10px 0;
        }
        .cart-item img {
            width: 100px;
            height: 100px;
            object-fit: cover;
            margin-right: 15px;
        }
        .cart-item-details {
            flex: 1;
            font-size: 14px;
        }
        .cart-item-details h3 {
            margin: 0 0 5px 0;
        }
        .cart-item-details p {
            margin: 5px 0;
        }
        .cart-item-details .price {
            color: red;
            font-weight: bold;
        }
        .cart-item-actions {
            display: flex;
            align-items: center;
        }
        .cart-item-actions input[type="number"] {
            width: 50px;
            text-align: center;
            border: 1px solid #ccc;
            margin: 0 5px;
            font-size: 14px;
        }
        .cart-item-actions button {
            width: 30px;
            height: 30px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 50%;
            cursor: pointer;
            font-size: 16px;
        }
        .cart-item-actions button:hover {
            background-color: #45a049;
        }
        .cart-footer {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }
        .cart-footer button {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .cart-footer button:hover {
            background-color: #45a049;
        }
        .cart-footer .btn-cancel {
            background-color: #f44336;
        }
        .cart-footer .btn-cancel:hover {
            background-color: #e53935;
        }
    </style>
    <script>
        function updateQuantity(button, isIncrement) {
            const quantityInput = button.parentElement.querySelector('input[type="number"]');
            let currentQuantity = parseInt(quantityInput.value) || 1;
            currentQuantity = isIncrement ? currentQuantity + 1 : Math.max(1, currentQuantity - 1);
            quantityInput.value = currentQuantity;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Giỏ hàng của tôi</h1>
        <div>
            <asp:Repeater ID="CartRepeater" runat="server">
                <ItemTemplate>
                    <div class="cart-item">
                        <!-- CheckBox -->
                        <input type="checkbox" name="selectProduct" value='<%# Eval("product_id") %>' />

                        <!-- Product Image -->
                        <asp:Image ID="Image1" runat="server"
                            ImageUrl='<%# "~/images/" + Eval("image") %>'
                            Width="100px" Height="100px"
                            AlternateText="No Image"
                            class="product-image" />

                        <!-- Product Details -->
                        <div class="cart-item-details">
                            <h3><%# Eval("description") %></h3>
                            <p>SKU: <%# Eval("SKU") %></p>
                            <p class="price">Price: $<%# Eval("price", "{0:0.00}") %></p>
                        </div>

                        <!-- Quantity Adjustment -->
                        <div class="cart-item-actions">
                            <button type="button" onclick="updateQuantity(this, false)">-</button>
                            <input type="number" min="1" value='<%# Eval("quantity") %>' />
                            <button type="button" onclick="updateQuantity(this, true)">+</button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="CartMessage" runat="server"></asp:Literal>

            <!-- Footer with Order and Cancel Button -->
            <div class="cart-footer">
                <button type="button" id="btnCancel" onclick="location.href='Home.aspx'" class="btn-cancel">Bỏ qua</button>
                <button type="button" id="btnOrder" onclick="placeOrder()">Đặt hàng</button>
            </div>
        </div>
    </form>
</body>
</html>
