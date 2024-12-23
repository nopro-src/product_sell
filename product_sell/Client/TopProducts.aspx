<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client.Master" AutoEventWireup="true" CodeBehind="TopProducts.aspx.cs" Inherits="product_sell.Client.TopProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleProduct.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblWelcome" runat="server" CssClass="welcome-message"></asp:Label>
    <% if (!string.IsNullOrEmpty(Request.QueryString["search"])) { %>
        <p>Kết quả tìm kiếm cho: <strong><%= Server.HtmlEncode(Request.QueryString["search"]) %></strong></p>
    <% } %>

    <div class="product-list">
        <asp:Repeater ID="ProductRepeater" runat="server">
            <ItemTemplate>
                <div class="product-item">
                    <asp:Image ID="Image1" runat="server"
                        ImageUrl='<%# "~/images/" + Eval("image") %>'
                        Width="150px" Height="150px"
                        AlternateText="No Image"
                        CssClass="product-image" />
                    <h3 class="product-title"><%# Eval("description") %></h3>
                    <p class="product-sku">SKU: <%# Eval("SKU") %></p>
                    <p class="product-price" style="color: red;">Price: $<%# Eval("price", "{0:0.00}") %></p>
                    <p class="product-stock">Stock: <%# Eval("stock") %></p>

                    <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="quantity-input" 
                        Text="1" Width="60px" MaxLength="3"></asp:TextBox>
                    <asp:Button ID="btnAddToCart" runat="server"
                        CssClass="btn-add-to-cart"
                        Text="Thêm vào giỏ hàng"
                        OnClick="AddToCart_Click"
                        CommandArgument='<%# Eval("product_id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Thông báo khi không có sản phẩm -->
        <asp:Literal ID="NoProductMessage" runat="server" EnableViewState="false"></asp:Literal>

        <!-- Thông báo thêm giỏ hàng -->
        <asp:Literal ID="CartMessage" runat="server"></asp:Literal>
    </div>
</asp:Content>
