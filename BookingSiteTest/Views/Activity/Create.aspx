<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Skapa ny Aktivitet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $(function () {
                $(".datepicker").datepicker();
            });
        })
    </script>

    <h2>Skapa ny Aktivitet</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Activity</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Date) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Date, "{0:yyyy-MM-dd}", new { @class="datepicker", @readonly="true" })%>
            <%: Html.ValidationMessageFor(model => model.Date) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.MaxPerson) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MaxPerson) %>
            <%: Html.ValidationMessageFor(model => model.MaxPerson) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Duration) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Duration) %>
            <%: Html.ValidationMessageFor(model => model.Duration) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Time) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Time) %>
            <%: Html.ValidationMessageFor(model => model.Time) %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Tillbaks till Aktiviteter", "Index", "Activity", new {calenderId = ViewBag.CalenderId}, null) %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
