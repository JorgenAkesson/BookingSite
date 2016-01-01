<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Company>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Visa Företag
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <h2>Visa Företag</h2>
        <fieldset>
            <legend>Företag</legend>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Name) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Name) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Email) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Email) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Phone) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Phone) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.WebPage) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.WebPage) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Description) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Description) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Address.Name) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Address.Name) %>
            </div>
        </fieldset>
        <p>

            <%: Html.ActionLink("Ändra", "Edit", new { id=Model.Id }) %>
            <%: Html.ActionLink("Tillbaks till företag", "Index") %>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
