<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication4.Models.Company>>" %>

<%@ Import Namespace="MvcApplication4.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewCompaniesAndSelect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewCompaniesAndSelect</h2>

    <% using (Html.BeginForm("CompanySelected", "Company", FormMethod.Get))
       {%>
    <label class="editor-label">Filtrera på stad</label>
    <%: Html.DropDownList("ViewBagCities") %>

    <div>
        <% foreach (var viewCompaniesData in ViewData["ViewCompaniesData"] as List<CompanyController.ViewCompaniesDataModel>)
           { %>
        <div style="float: left;">
            <a href="<%= Url.Action("CompanySelected", new {CompanyId = viewCompaniesData.CompanyId })  %>">
                <ul style="list-style-type: none; -webkit-padding-start: 5px">
                    <li style="font-weight: bold">
                        <%: viewCompaniesData.Name %>
                    </li>
                    <li>
                        <img src="<%= Url.Content(viewCompaniesData.ImageUrl) %>" alt="<%: viewCompaniesData.Name %>" style="width: 100px" />
                    </li>
                </ul>
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
