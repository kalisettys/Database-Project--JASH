<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HousingApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container {
            padding-top: 30px;
            width: 50%;
            margin: auto;
        }
    </style>
    <script type="text/javascript">
        $('form').validate();
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="announcementHeader">
            <h2>
                <asp:Literal ID="ltrErrors" runat="server" />
            </h2>
        </div>
        <div class="content">
            <form name="registration" runat="server">
                <h1>Login</h1>
                <br />
                <br />
                <div class="column one">
                    <b>Select type of login</b>
                    <asp:RadioButtonList ID="radioList" runat="server">
                        <asp:ListItem Text="Student" Value="dbo.IsValidUser" Selected="True" />
                        <asp:ListItem Text="Faculty" Value="dbo.IsValidFaculty"/>
                        <asp:ListItem Text="Property Manager" Value="dbo.IsValidPM" />
                    </asp:RadioButtonList>
                    <div class="form-element-wrapper">
                        <label for="username">User Name*</label>
                        <asp:TextBox ID="username" CssClass="form-element form-field" runat="server" name="username" required />
                    </div>

                    <div class="form-element-wrapper">
                        <label for="password">Password*</label>
                        <%--<input class="form-element form-field" id="password" name="j_password" type="password" value=""/>--%>
                        <asp:TextBox ID="password" CssClass="form-element form-field" runat="server" name="password" TextMode="Password" required></asp:TextBox>
                    </div>
                    <div class="form-element-wrapper">
                        <asp:Button ID="btnLogin" runat="server" CssClass="form-element form-button" OnClick="btnLogin_Click" Text="Log In" />
                        <%--onclick="this.childNodes[0].nodeValue='Logging in, please wait...'"--%>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

