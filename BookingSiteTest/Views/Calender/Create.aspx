<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Skapa ny Kalender
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <h2>Skapa ny Kalender</h2>
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Kalender</legend>

            <input type="hidden" name="companyId" value="<%: ViewBag.CompanyID %>" />

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>

            <%--        <div class="editor-label">
            <%: Html.LabelFor(model => model.CompanyID, "Company") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("CompanyID", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.CompanyID) %>
        </div>--%>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
        <% } %>

        <div>
            <%: Html.ActionLink("Tillbaks till Kalendrar", "Index", new {companyId = ViewBag.CompanyID}) %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
