<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
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
        <%: Html.ActionLink("Tillbaks till kalendern", "Index", new { calenderId = Model.CalenderId }) %>
    </p>
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
