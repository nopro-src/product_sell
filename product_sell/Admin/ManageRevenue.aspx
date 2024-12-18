<%@ Page Title="Quản lý doanh thu" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageRevenue.aspx.cs" Inherits="product_sell.Admin.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="macd" HeaderText="Mã chuyến đi" />
            <asp:BoundField DataField="tencd" HeaderText="Tên chuyến đi" />
            <asp:BoundField DataField="songaydi" HeaderText="Số ngày đi" />
            <asp:BoundField DataField="songuoidi" HeaderText="Số người đi" />
            <asp:BoundField DataField="mapt" HeaderText="Mã phương tiện" />

        </Columns>
    </asp:GridView>
</asp:Content>
