<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication4.Models.Company>>" %>
<%@ Import Namespace="MvcApplication4.Controllers" %>

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

    <% foreach (var viewCompaniesData in ViewData["ViewCompaniesData"] as List<CompanyController.ViewCompaniesDataModel>)
       { %>
    <a href="<%= Url.Action("CompanySelected", new {CompanyId = viewCompaniesData.CompanyId })  %>"><img src="<%= Url.Content(viewCompaniesData.ImageUrl) %>" alt="IMAGES" /></a>
    <% } %>

    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
