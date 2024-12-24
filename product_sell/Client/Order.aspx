<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="product_sell.Client.Order" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script>
    document.addEventListener("DOMContentLoaded", function () {
        const placeOrderButton = document.getElementById('<%= btnPlaceOrder.ClientID %>');

        placeOrderButton.addEventListener("click", function (event) {
            const confirmation = confirm("Bạn có chắc muốn đặt hàng không?");
            if (!confirmation) {
                event.preventDefault(); // Cancel the form submission
            }
        });
    });
    </script>

    <title>Đặt Hàng</title>
    <link rel="stylesheet" type="text/css" href="StyleOrder.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="section-title">Thông tin sản phẩm đã chọn</h2>
            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" />
            <asp:Repeater ID="OrderRepeater" runat="server">
                <HeaderTemplate>
                    <table class="product-table">
                        <thead>
                            <tr>
                                <th>Hình ảnh</th>
                                <th>Mô tả</th>
                                <th>Số lượng</th>
                                <th>Giá</th>
                                <th>Tổng cộng</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src='<%# ResolveUrl("~/images/") + Eval("image") %>' alt="Product Image" width="100" /></td>
                        <td><%# Eval("description") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td><%# Eval("price", "{0:C}") %></td>
                        <td><%# Eval("TotalPrice", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <div class="container">
            <h2 class="section-title">Thông tin khách hàng</h2>
            <br />
            <label for="txtFullName">Họ và tên:</label>
            <asp:TextBox ID="txtFullName" runat="server" Placeholder="Nhập họ và tên" CssClass="input-box"></asp:TextBox>

            <label for="txtPhoneNumber">Số điện thoại:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" Placeholder="Nhập số điện thoại" CssClass="input-box"></asp:TextBox>

            <label for="txtAddress">Địa chỉ:</label>
            <asp:TextBox ID="txtAddress" runat="server" Placeholder="Nhập địa chỉ" CssClass="input-box"></asp:TextBox>

            <label for="ddlPaymentMethod">Phương thức thanh toán:</label>
            <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                <asp:ListItem Value="PayPal">PayPal</asp:ListItem>
                <asp:ListItem Value="Bank Transfer">Bank Transfer</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnPlaceOrder" runat="server" Text="Đặt hàng" OnClick="btnPlaceOrder_Click" CssClass="order-button" />
            <asp:Button ID="btnBackToHome" runat="server" Text="Quay lại trang chủ" OnClick="btnBackToHome_Click" CssClass="home-button" />

            <div class="total-amount">
                <asp:Literal ID="lblTotalAmount" runat="server" />
            </div>
            <div class="order-success">
                <asp:Literal ID="lblOrderSuccess" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
