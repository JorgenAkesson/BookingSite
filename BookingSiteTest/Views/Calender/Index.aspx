<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Calender>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kalendrar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%: Html.ActionLink("Tillbaks till Företag","Index", "Company") %>
    <h2>Kalendrar</h2>
    <%: Html.ActionLink("Skapa ny Kalender", "Create", new {companyId = ViewBag.CompanyId}) %>
    <table>
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
                    <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Visa Activiteter", "Index", "Activity", new { calenderId = item.Id }, null) %> |
                    <%: Html.ActionLink("Visa Bokningar", "Bookings", new { calenderId = item.Id, fromDate = DateTime.Now, toDate = DateTime.Now }, null) %>
                    <%--<%: Html.ActionLink("Lägg till Aktivitet", "Create", "Activity",new RouteValueDictionary(new { calenderId = item.Id, companyId = item.CompanyID }), null) %>--%>
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
