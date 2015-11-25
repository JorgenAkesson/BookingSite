<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewWeek
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ViewWeek</h2>
    <div>
        <% foreach (var activityData in ViewData["ActivitiesData"] as List<BookingSiteTest.Models.Activity>)
           { %>
        <div>
            <ul style="list-style-type: none; -webkit-padding-start: 5px">
                <li>
                    <%: activityData.Name %>
                    <%: activityData.Date %>
                    <%: activityData.Time %>
                    <%: activityData.Duration %>
                </li>
            </ul>
        </div>

        <% } %>
    </div>

    <%--Set--%>
    <div>
        <% var persId = ViewData["UserId"] as int?;
           foreach (var aD in ViewData["ActivitiesData"] as List<BookingSiteTest.Models.Activity>)
           {
               int topMin = 8 * 60;
               int y = (aD.Date.Hour * 60 + aD.Date.Minute - topMin) / 10;
               int x = 100;
        %>

        <a style="position: relative; top: <%: y.ToString() %>px; left: <%: x.ToString() %>px;" href='<%: Url.Action("BookActivity", new RouteValueDictionary(new { id = Model.Id, activityId = aD.Id })) %>'>
            <p><%: aD.Name %></p>
        </a>

        <% } %>
    </div>

    <%--    <fieldset>
        <legend>Calender</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Name) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Name) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.CompanyID) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.CompanyID) %>
        </div>
    </fieldset>--%>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
