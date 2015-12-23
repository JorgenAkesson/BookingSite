<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Activity>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Aktiviteter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <%: Html.ActionLink("Tillbaks till Kalendrar","Index", "Calender", new {companyId = ViewBag.CompanyId}, null) %>
        <h2>Aktiviteter</h2>
        <%: Html.ActionLink("Skapa ny Aktivitet", "Create", new {calenderId = ViewBag.CalenderId}) %>

        <table>
            <tr>
                <th>
                    <%: Html.DisplayNameFor(model => model.Name) %>
                </th>
                <th>
                    <%: Html.DisplayNameFor(model => model.Description) %>
                </th>
                <th>
                    <%: Html.DisplayNameFor(model => model.Date) %>
                </th>
                <th>
                    <%: Html.DisplayNameFor(model => model.MaxPerson) %>
                </th>
                <th>
                    <%: Html.DisplayNameFor(model => model.Duration) %>
                </th>
                <th>
                    <%: Html.DisplayNameFor(model => model.Time) %>
                </th>
                <th></th>
            </tr>

            <% foreach (var item in Model)
               { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Name) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Description) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Date) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.MaxPerson) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Duration) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Time) %>
                </td>
                <td>
                    <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id }) %>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
