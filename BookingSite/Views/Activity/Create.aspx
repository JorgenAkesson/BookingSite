<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication4.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <script type="text/javascript">
        $(function () {
            $("#datepicker").datepicker();
        });

    </script>
    <h1>Time Validation</h1>
    <br />
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
            <%--            <%: Html.EditorFor(model => model.Date) %>
            <%: Html.ValidationMessageFor(model => model.Date) %>--%>
            <input type="text" id="datepicker" name="datepicker" />
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Time) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Time) %>
            <%: Html.ValidationMessageFor(model => model.Time) %>
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
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
