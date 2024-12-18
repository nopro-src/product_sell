<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="product_sell.Admin.ManageAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="customer_id" HeaderText="ID" />
            <asp:BoundField DataField="first_name" HeaderText="First name" />
            <asp:BoundField DataField="last_name" HeaderText="Last name" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="password" HeaderText="Password" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="phone_number" HeaderText="Phone number" />
            <asp:BoundField DataField="role" HeaderText="Role" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("customer_id") %>'
                        Text="Xoá" OnCommand="Xoa_click" runat="server"
                        OnClientClick="return confirm('Bạn có chắc chắn muốn xoá không?')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Update">
                <ItemTemplate>
                    <asp:Button ID="sua" CommandName="sua" CommandArgument='<%# Bind("customer_id") %>'
                        Text="Sửa" OnCommand="Sua_click" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btn_add" runat="server" PostBackUrl="AddAccounts.aspx" Text="Thêm tài khoản" />
</asp:Content>
