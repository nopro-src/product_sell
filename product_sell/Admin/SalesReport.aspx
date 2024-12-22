<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="product_sell.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Sales Report</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Sales Report</h1>
    <br />
    <h2>Tổng thu nhập</h2>
    <asp:Label ID="lblTotalRevenue" runat="server" CssClass="total-revenue" Text="Tổng doanh thu:"></asp:Label>
    <br />
    <h2>Số lượng bán từng đơn hàng</h2>
    <asp:GridView ID="gvSalesReport" runat="server" AutoGenerateColumns="True"></asp:GridView>
    <br />
    <h2>Lịch Sử Mua Hàng</h2>
    <asp:GridView ID="gvPurchaseHistory" runat="server" AutoGenerateColumns="True"></asp:GridView>
    <h2>Top bán chạy</h2>
    <asp:GridView ID="gvTopSellingProducts" runat="server" AutoGenerateColumns="False" 
    CssClass="table" HeaderStyle-CssClass="thead-dark" 
    EmptyDataText="Không có sản phẩm nào bán chạy" 
    OnRowDataBound="gvTopSellingProducts_RowDataBound">
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="product_id" />
        <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU" />
        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
        <asp:BoundField DataField="total_quantity_sold" HeaderText="Total Quantity Sold" SortExpression="total_quantity_sold" />
    </Columns>
    </asp:GridView>
</asp:Content>
