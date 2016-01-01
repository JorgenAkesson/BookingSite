<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.LoginModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Logga in
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <hgroup class="title">
            <h1>Logga in</h1>
        </hgroup>

        <section id="loginForm">
            <h2>Använd ett befintligt konto för att logga in.</h2>
            <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
               { %>
            <%: Html.AntiForgeryToken() %>
            <%: Html.ValidationSummary(true) %>

            <fieldset>
                <legend>Logga in uppgifter</legend>
                <ol>
                    <li>
                        <%: Html.LabelFor(m => m.UserName) %>
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </li>
                    <li>
                        <%: Html.LabelFor(m => m.Password) %>
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                    </li>
                    <li>
                        <%: Html.CheckBoxFor(m => m.RememberMe) %>
                        <%: Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" }) %>
                    </li>
                </ol>
                <input type="submit" value="Logga in" />
            </fieldset>
            <p>
                <%: Html.ActionLink("Registrera", "Register") %> om du inte har något konto.
            </p>
            <% } %>
        </section>

        <section class="social" id="socialLoginForm">
            <h2>Använd en annan service att logga in.</h2>
            <%: Html.Action("ExternalLoginsList", new { ReturnUrl = ViewBag.ReturnUrl }) %>
        </section>
    </div>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
