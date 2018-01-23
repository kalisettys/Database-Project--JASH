<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HousingApp.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container {
    padding-top: 20px;
    width: 50%;
    margin: auto;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
    <h1> About us </h1>
        <br />
    <p>The purpose of 'JASH' is to provide off-campus housing for students and faculty members of Virginia Commonwealth University. This website application also gives 
        property listers the access to post the properties they own or wish to rent out. The authors for developing this site are: Shilpa Kalisetty & Jasleen Kaur. 
        This project is being developed for our Database Theory Class. We are responsible for creating a user-interface that enables the user to add and manipulate data
        and how the data that is entered on the interface will be saved or accessed from the database we built which is named as "HousingApp".
    </p>
        </div>
</asp:Content>
