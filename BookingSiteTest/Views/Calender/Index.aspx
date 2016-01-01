<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Calender>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kalendrar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="entries">
        <div class="entry nohover">
            <%: Html.ActionLink("Tillbaks till Företag","Index", "Company") %>
            <div>
                <h2><%: ViewBag.CompanyName %></h2>
            </div>
            <div>
                <%: Html.ActionLink("Skapa ny Kalender", "Create", new {companyId = ViewBag.CompanyId}) %>
            </div>
        </div>
    <% foreach (var item in Model)
       { %>
    <div class="entry">
        <a class="noUnderline" href="/Calender/ViewWeek/<%:item.Id %>">
            <div>
                <h4><%: item.Name %></h4>
                <p><%: item.Description %></p>
            </div>
        </a>
        <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Activiteter", "Index", "Activity", new { calenderId = item.Id }, null) %> |
                    <%: Html.ActionLink("Bokningar", "Bookings", new { calenderId = item.Id, fromDate = DateTime.Now, toDate = DateTime.Now }, null) %>
        <%--<%: Html.ActionLink("Lägg till Aktivitet", "Create", "Activity",new RouteValueDictionary(new { calenderId = item.Id, companyId = item.CompanyID }), null) %>--%>
    </div>
    <% } %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
