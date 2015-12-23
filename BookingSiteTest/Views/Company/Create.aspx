<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Company>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Skapa nytt Företag
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <h2>Skapa nytt Företag</h2>
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Company</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.WebPage) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.WebPage) %>
                <%: Html.ValidationMessageFor(model => model.WebPage) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.AddressId, "Address") %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.Name) %>
                <%: Html.ValidationMessageFor(model => model.Address.Name) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.Street) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.Street) %>
                <%: Html.ValidationMessageFor(model => model.Address.Street) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.PostalNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.PostalNumber) %>
                <%: Html.ValidationMessageFor(model => model.Address.PostalNumber) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.City) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.City) %>
                <%: Html.ValidationMessageFor(model => model.Address.City) %>
            </div>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
        <% } %>
        <div>
            <%: Html.ActionLink("Tillbaks till Företag", "Index") %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
