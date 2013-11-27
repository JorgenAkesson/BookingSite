<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication4.Models.Company>>" %>

<%@ Import Namespace="MvcApplication4.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewCompaniesAndSelect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewCompaniesAndSelect</h2>

    <% using (Html.BeginForm("CompanySelected", "Company", FormMethod.Get))
       {%>
    <div>
        <% foreach (var viewCompaniesData in ViewData["ViewCompaniesData"] as List<CompanyController.ViewCompaniesDataModel>)
           { %>
        <div style="float: left; width: 110px;">
            <a href="<%= Url.Action("CompanySelected", new {CompanyId = viewCompaniesData.CompanyId })  %>">
                <div>
                    <img src="<%= Url.Content(viewCompaniesData.ImageUrl) %>" alt=<%: viewCompaniesData.Name %> style="width: 100px" />
                    <label><%: viewCompaniesData.Name %></label>
                </div>
            </a>
        </div>
        <% } %>
    </div>
    <div style="clear: both" />
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
