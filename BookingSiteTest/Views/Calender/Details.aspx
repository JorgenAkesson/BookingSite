<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master"
    Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kalender
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <h2>Kalender</h2>
        <fieldset>
            <legend>Kalender</legend>
            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Name) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Name) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Company.Name) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Company.Name) %>
            </div>
        </fieldset>
        <p>
            <%: Html.ActionLink("Ändra", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Tillbaks till Kalendrar", "Index") %>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
