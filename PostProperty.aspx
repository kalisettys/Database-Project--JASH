<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PostProperty.aspx.cs" Inherits="HousingApp.PostProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $('form').validate();
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" class="main col-6" tabindex="0" role="main" style="margin-top: 51px;">
        <header class="header-main">
            <div class="hgroup-main">
                <h1 class="title">Post your places here!</h1>
            </div>
        </header>
        <form class="dborder-bottom" runat="server">
            <div class="col-3 col-fleft">
                <b>Image</b>
                <input type="file" id="openFileUpload" runat="server" />
                <div class="field-wrapper">
                    <label for="Address2">Occupancy</label>
                    <asp:TextBox type="tel" name="occupancy" ID="occupancy" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="Address2">Parking</label>
                    <asp:CheckBox ID="parking" runat="server" />
                </div>
                <div class="field-wrapper">
                    <label for="Address2">Monthly Rent</label>
                    <asp:TextBox type="tel" name="rent" ID="rent" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="Address2">Apartment</label>
                    <asp:CheckBox ID="apartment" runat="server" />
                </div>
            </div>
            <div class="field-wrapper col-3 col-fright">
                <div class="field-wrapper">
                    <label for="Address1">Address line1</label>
                    <asp:TextBox type="tel" name="Address1" ID="Address1" runat="server"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="Address2">City</label>
                    <asp:TextBox type="tel" name="Address2" ID="City" runat="server"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="Address2">State</label>
                    <asp:TextBox type="tel" name="Address2" ID="State" runat="server"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="Address2">Zip</label>
                    <asp:TextBox type="tel" name="zip" ID="zip" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="bath">Number of Baths</label>
                    <asp:TextBox type="tel" name="bath" ID="bath" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div class="field-wrapper">
                    <label for="bed">Number of beds</label>
                    <asp:TextBox type="tel" name="bed" ID="bed" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="field-wrapper page-actions">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-chevronright" />
            </div>
        </form>
    </div>
</asp:Content>
