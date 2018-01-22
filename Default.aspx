<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HousingApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/slick/slick.css" />
    <link rel="stylesheet" type="text/css" href="/slick/slick-theme.css" />
    <script type="text/javascript" src="/slick/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.slideslickshow').slick({
                autoplay: true,
                dots: true,
                autoplaySpeed: 2000
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section section-hero" role="complementary" aria-label="Slideshow" style="margin-top: 51px;">
        <div class="section-inner">


            <div style="clear:both;">
                <div class="slideslickshow">
                    <div class="image"><img src="/Images/2.jpg" width="960" height="480"/></div>
                    <div class="image"><img src="/Images/1.jpg"  width="960" height="480"/></div>
                    <div class="image">
                        <img src="/Images/3.jpg"  width="960" height="480"/></div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
