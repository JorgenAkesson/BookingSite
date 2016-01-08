<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Calender>>" %>

<%@ Import Namespace="BookingSiteTest.Helpers" %>

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
                <%: Html.ActionLinkAuthorized("Skapa ny Kalender", "Create", new {companyId = ViewBag.CompanyId}, (int)(ViewBag.CompanyId)) %>
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
            <%: Html.ActionLinkAuthorized("Ändra", "Edit", new { id=item.Id }, (int)(ViewBag.CompanyId)) %>
            <%: Html.ActionLinkAuthorized("Ta bort", "Delete", new { id=item.Id }, (int)(ViewBag.CompanyId)) %>
            <%: Html.ActionLinkAuthorized("Activiteter", "Index", "Activity", new { calenderId = item.Id }, (int)(ViewBag.CompanyId)) %>
            <%: Html.ActionLinkAuthorized("Bokningar", "Bookings", new { calenderId = item.Id, fromDate = DateTime.Now, toDate = DateTime.Now }, (int)(ViewBag.CompanyId)) %>
            <%--<%: Html.ActionLink("Lägg till Aktivitet", "Create", "Activity",new RouteValueDictionary(new { calenderId = item.Id, companyId = item.CompanyID }), null) %>--%>
        </div>
        <% } %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
