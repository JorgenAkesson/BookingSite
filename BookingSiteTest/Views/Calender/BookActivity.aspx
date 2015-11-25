<%@ Page Title="BookActivity" Language="C#" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>

<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Book Activity</h2>
    <p>Name: <%: Model.Name %></p>
    
    <p>You're logged in as: <%: User.Identity.Name %>.</p>

    <a href='<%: Url.Action("Book", new RouteValueDictionary(new { id = Model.Id, personId = ViewData["UserId"]})) %>'>
        <p>Book!</p>
    </a>

</asp:Content>
<asp:Content runat="server" ID="ScriptsSection" ContentPlaceHolderID="ScriptsSection"></asp:Content>
