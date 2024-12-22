<%@ Page Title="Update Account" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Update_Account.aspx.cs" Inherits="product_sell.Admin.Update_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update tài khoản</h2>
    <asp:Table runat="server" ID="update_ac">
        <asp:TableRow>
            <asp:TableCell>Customer ID</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="customer_id" Enabled="false" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>First name</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="first_name" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Last name</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="last_name" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Email</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="email" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Password</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="password" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Address</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="address"/>
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Phone number</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="phone_number" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Role</asp:TableCell><asp:TableCell>
                <asp:DropDownList runat="server" ID="sl_role" size="2"/>
            </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="btn_update" runat="server" Text="Sửa" OnClick="btn_update_Click" /><asp:Button ID="btn_boqua" runat="server" Text="Bỏ qua" />
    <p>
        <asp:Label ID="msg" runat="server" ForeColor="Red" Font-Bold="True" />
    </p>
    <p>
        <asp:Button ID="btn1" runat="server" Text="Danh sách tài khoản" PostBackUrl="~/Admin/ManageAccounts.aspx" />
    </p>
</asp:Content>
