<%@ Page Title="Add Account" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddAccounts.aspx.cs" Inherits="product_sell.Admin.AddAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Thêm tài khoản</h2>
    <asp:Table runat="server" ID="tb">
        <asp:TableRow>
            <asp:TableCell>First name</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="first_name" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Last name</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="last_name" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Email</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="email" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Password</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="password" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Address</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="address" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Phone number</asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="phonenumber" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Role</asp:TableCell><asp:TableCell>
                <asp:DropDownList ID="sl_role" runat="server" size="2" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="btn_add_accounts" runat="server" Text="Thêm" OnClick="btn_add_accounts_Click" /><asp:Button ID="btn_cancel_accounts" runat="server" Text="Bỏ qua" />
    <p>
        <asp:Label ID="msg_add_accounts" Font-Italic="true" runat="server" />
    </p>
    <p>
        <asp:Button ID="btn2" runat="server" Text="Danh sách tài khoản" PostBackUrl="~/Admin/ManageAccounts.aspx" />
    </p>
</asp:Content>
