<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Ta bort Aktivitet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">

        <h2>Ta bort Aktivitet</h2>
        <fieldset>
            <legend>Activity</legend>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Name) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Name) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Description) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Description) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Date) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Date) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.MaxPerson) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.MaxPerson) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Duration) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Duration) %>
            </div>

            <div class="display-label">
                <%: Html.DisplayNameFor(model => model.Time) %>
            </div>
            <div class="display-field">
                <%: Html.DisplayFor(model => model.Time) %>
            </div>
        </fieldset>
        <% using (Html.BeginForm())
           { %>
        <p>
            <input type="submit" value="Delete" />
            |
        <%: Html.ActionLink("Tillbaks till Aktiviteter", "Index", new { calenderId = Model.CalenderId }) %>
        </p>
        <% } %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
