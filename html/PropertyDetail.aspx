<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PropertyDetail.aspx.cs" Inherits="HousingApp.PropertyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container {
            padding-top: 30px;
            width: 50%;
            margin: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="slideshow">
            <div id="slider" class="swipe col-4 col-fleft" style="visibility: visible;">
                <asp:Literal ID="ltrImage" runat="server" />
            </div>

            <div class="info-box col-2 col-fright">
                <span class="price serif">
                    Monthly Rent:- <asp:Literal ID="ltrPrice" runat="server" />
                </span>
                <p class="bedbath">
                    Number of Beds:- <asp:Literal ID="ltrBeds" runat="server" />
                </p>
                <p class="bedbath">
                    Number of Bath:- <asp:Literal ID="lrBath" runat="server" />
                </p>
                <p class="bedbath">
                    Occupancy:- <asp:Literal ID="ltroccu" runat="server" />
                </p>
                <p class="bedbath">
                    Parking:- <asp:Literal ID="ltrparking" runat="server" />
                </p>
                <p class="bedbath">
                    Address:- <asp:Literal ID="ltraddress" runat="server" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
