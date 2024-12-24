<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="product_sell.Client.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giỏ hàng</title>
    <link rel="stylesheet" type="text/css" href="StyleCart.css" />
    <script>
        function updateQuantity(button, isIncrement) {
            const quantityInput = button.parentElement.querySelector('input[type="number"], input[type="text"]');
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
                        <asp:CheckBox ID="SelectProduct" runat="server" />
                        <asp:Image ID="Image1" runat="server"
                            ImageUrl='<%# "~/images/" + Eval("image") %>'
                            Width="100px" Height="100px"
                            AlternateText="No Image" class="product-image" />
                        <div class="cart-item-details">
                            <h3><%# Eval("description") %></h3>
                            <p>SKU: <%# Eval("SKU") %></p>
                            <p class="price">Giá: $<%# Eval("price", "{0:0.00}") %></p>
                        </div>
                        <div class="cart-item-actions">
                            <button type="button" onclick="updateQuantity(this, false)">-</button>
                            <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Eval("quantity") %>' CssClass="quantity-box" />
                            <button type="button" onclick="updateQuantity(this, true)">+</button>
                        </div>
                        <asp:HiddenField ID="ProductIdHiddenField" runat="server" Value='<%# Eval("product_id") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Literal ID="CartMessage" runat="server"></asp:Literal>

            <!-- Footer with Order and Cancel Button -->
            <div class="cart-footer">
                <button type="button" id="btnCancel" onclick="location.href='Home.aspx'" class="btn-cancel">Bỏ qua</button>
                <asp:Button ID="btnOrder" runat="server" Text="Đặt hàng" CssClass="btn-order" OnClick="PlaceOrder_Click" />
            </div>
        </div>
    </form>
</body>
</html>
