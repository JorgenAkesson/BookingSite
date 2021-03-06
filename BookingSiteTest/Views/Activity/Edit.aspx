﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Ändra Aktivitet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $(function () {
                $(".datepicker").datepicker();
            });
        })
    </script>
    <div class="entries">

        <h2>Ändra Aktivitet</h2>

        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Activity</legend>

            <%: Html.HiddenFor(model => model.CalenderId) %>
            <input name="page" value="<%:ViewBag.Page %>" type="hidden"/>
            <input name="pageSize" value="<%:ViewBag.PageSize %>" type="hidden"/>
            <input name="sortOrder" value="<%:ViewBag.SortOrder %>" type="hidden"/>
            <input name="searchString" value="<%:ViewBag.SearchString %>" type="hidden"/>
                
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
                <%: Html.ValidationMessageFor(model => model.MaxPerson ) %>
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
                <input type="submit" value="Save" />
            </p>
        </fieldset>
        <% } %>
        <div>
            <%: Html.ActionLink("Tillbaks till Aktiviteter", "Index", new {calenderId = Model.CalenderId}) %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
