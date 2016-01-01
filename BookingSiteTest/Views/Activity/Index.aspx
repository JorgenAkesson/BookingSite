<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<PagedList.PagedList<BookingSiteTest.Models.Activity>>" %>

<%@ Import Namespace="PagedList.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Aktiviteter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <%: Html.ActionLink("Tillbaks till Kalendrar","Index", "Calender", new {companyId = ViewBag.CompanyId}, null) %>
        <h2>Aktiviteter</h2>
        <%: Html.ActionLink("Skapa ny Aktivitet", "Create", new {calenderId = ViewBag.CalenderId}) %>

        <% var nameSortOrder = ViewBag.SortOrder == "name_asc" ? "name_desc" : "name_asc";
           var dateSortOrder = ViewBag.SortOrder == "date_asc" ? "date_desc" : "date_asc"; %>

        <% using (Html.BeginForm())
           {%>
        <p>
            Sök: <%: Html.TextBox("searchString")%>
            <input type="submit" value="Sök" />
        </p>
        <% }%>
        <table>
            <tr>
                <td><%: Html.ActionLink("Namn", "Index", new { calenderId = ViewBag.CalenderId, sortOrder = nameSortOrder, page = Model.PageNumber, pageSize = Model.PageSize, searchString = ViewBag.SearchString })%>
                </td>
                <td>Beskrivning
                </td>
                <td><%: Html.ActionLink("Datum", "Index", new { calenderId = ViewBag.CalenderId, sortOrder = dateSortOrder, page = Model.PageNumber, pageSize = Model.PageSize, searchString = ViewBag.SearchString })%>
                </td>
                <td>Max personer</td>
                <td>Längd</td>
                <td>Tid</td>
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
                    <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id, sortOrder = ViewBag.SortOrder, page = Model.PageNumber, pageSize = Model.PageSize, searchString = ViewBag.SearchString }) %> |
                <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id, sortOrder = ViewBag.SortOrder, page = Model.PageNumber, pageSize = Model.PageSize, searchString = ViewBag.SearchString }) %>
                </td>
            </tr>
            <% } %>
        </table>
        <br />
        Sida <%: Model.PageNumber %> av <%: Model.PageCount %>
        <%: Html.PagedListPager(Model, page => Url.Action("Index", new { page, calenderId = ViewBag.CalenderId, sortOrder = ViewBag.SortOrder, pageSize = Model.PageSize, searchString = ViewBag.SearchString })) %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
