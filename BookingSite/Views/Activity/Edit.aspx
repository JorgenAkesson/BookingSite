<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication4.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <script>
        $(function () {
            $("#datepicker").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>


    <fieldset>
        <legend>Activity</legend>

        <%: Html.HiddenFor(model => model.Id) %>
        <%: Html.HiddenFor(model => model.CompanyId) %>

        <%: Html.DropDownList("Cities") %>

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
            <%--<%: Html.EditorFor(model => model.Date) %>--%>
            <%--<%: Html.ValidationMessageFor(model => model.Date) %>--%>
            <input type="text" id="datepicker" name="datepicker" value="<%: Model.Date.ToShortDateString() %>" />
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
            <input type="submit" value="Save" />
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
