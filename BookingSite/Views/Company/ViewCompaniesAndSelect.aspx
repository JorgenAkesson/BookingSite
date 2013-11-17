<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication4.Models.Company>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewCompaniesAndSelect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewCompaniesAndSelect</h2>

    <% using (Html.BeginForm("CompanySelected", "Company", FormMethod.Get))
       {%>

    <table>
        <%: Html.DropDownList("CompanyList") %>
    </table>
    <input type="submit" value="Submit" />

    <% foreach (var url in ViewData["Strings"] as List<String>)
       { %>
    <a href="<%= Url.Action("CompanySelected2", new {CompanyId = 1})  %>"><img src="<%: Url.Content(url) %>" alt="IMAGES" /></a>
    <% } %>

    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
