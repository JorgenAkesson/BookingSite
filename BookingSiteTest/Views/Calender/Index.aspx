<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Calender>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%: Html.ActionLink("Skapa ny kalender", "Create", new {companyId = ViewBag.CompanyId}) %>
    </p>
    <table>
        <tr>
            <th>
                <h2>Kalendrar</h2>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <div>
                <td>
                    <a href="/Calender/ViewWeek/<%:item.Id %>">
                        <div>
                            <%: Html.DisplayFor(modelItem => item.Name) %>
                        </div>
                    </a>
                </td>
                <td>
                    <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Visa activiteter", "Index", "Activity", new { calenderId = item.Id }, null) %> |
                    <%: Html.ActionLink("Add activities", "Create", "Activity",new RouteValueDictionary(new { calenderId = item.Id, companyId = item.CompanyID }), null) %>
                </td>
            </div>
        </tr>
        <% } %>
    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
