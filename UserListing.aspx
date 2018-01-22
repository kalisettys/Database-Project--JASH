<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserListing.aspx.cs" Inherits="HousingApp.UserListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/CSS/bootstrap.css" />
    <style>
.card {
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
    transition: 0.3s;
    width: 40%;
}

.card:hover {
    box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.container {
    padding: 2px 16px;
}
</style>
    <script type="text/javascript">
        $(function () {
            $('.favClick').click(function () {
                var id = $(this).attr('home-id');
                var userid = $('#ContentPlaceHolder1_hdnUserId').val();
                if (id != undefined) {
                    $.ajax({
                        url: '/LikeHome.ashx' + '?id=' + id + '&userId=' + userid,
                        cache: false,
                        success: function (pdata) {
                            alert(pdata);
                        },
                        error: function (pdata) {
                        }
                    });
                }
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div id="main" class="main col-6" tabindex="0" role="main" style="margin-top: 51px;">
            <header class="header-main">
                <div class="hgroup-main">
                    <h1 class="title">
                        <asp:Literal ID="ltrName" runat="server" />
                    </h1>
                </div>
            </header>
            <div class="col-3 col-fleft">
                <a href="/userlisting.aspx?type=apt">Apartments</a><br />
                <a href="/userlisting.aspx?type=home">Individual Homes</a><br />
                <a href="/userlisting.aspx?type=fav">Wish list</a>
            </div>
            <div class="col-8 col-fright">

                <div class="container-fluid">

                    <div class="row">
                        <asp:Repeater ID="rptHome" runat="server">
                            <ItemTemplate>

                                <div class="card" style="width: 17rem; margin-right: 20px; margin-bottom: 20px;">
                                    <a href="/PropertyDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Home_ID") %>">
                                        <img class="card-img-top" src="<%# DataBinder.Eval(Container.DataItem, "Home_image") %>" alt="Card image cap" style="width:100%">
                                        <div class="container card-block">
                                            <p class="card-text">
                                                Price:- $<%# DataBinder.Eval(Container.DataItem, "Home_MonthlyRent") %>
                                            </p>
                                            <% if (HousingApp.ClassFiles.Utilities.IsUserLoggedIn() && showFav)
                                        { %>
                                    <b><a home-id='<%# DataBinder.Eval(Container.DataItem, "Home_ID") %>' class="favClick" href="javascript:void();">Add to wishlist</a></b>
                                    <% } %>
                                        </div>
                                    </a>
                                    
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </div>

        </div>
        <asp:HiddenField ID="hdnUserId" runat="server" />
    </form>
</asp:Content>
