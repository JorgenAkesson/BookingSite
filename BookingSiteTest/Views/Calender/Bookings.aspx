<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<List<BookingSiteTest.Models.Activity>>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Visa alla bokningar
</asp:Content>

<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <script>
        function changDate() {
            window.location.href = "../../Calender/Bookings?calenderId=" + '<%: ViewBag.CalenderId%>' +
                "&fromDate=" + $("#datepicker").val() +
                "&toDate=" + $("#datepicker").val();
        };

        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    <div class="entries">
        <%: Html.ActionLink("Tillbaks till Kalendrar","Index", "Calender", new {companyId = ViewBag.CompanyId}, null) %>

        <h2>Visa alla bokningar</h2>
        <p>
            Datum:
        <input type="text" readonly id="datepicker" value="<%: ViewBag.FromDate %>">
            <input type="submit" value="Byt datum" onclick="changDate()">
        </p>
        <%--<%: Html.ActionLink("Tillbaks till Företag","Index", "Company") %>--%>
        <%--<%: Html.ActionLink("Skapa ny Kalender", "Create", new {companyId = ViewBag.CompanyId}) %>--%>
        <table>
            <% foreach (var item in Model)
               { %>
            <tr>
                <td style="vertical-align: top">
                    <%: Html.DisplayFor(modelItem => item.Name) %><br />
                    Datum: <%: Html.DisplayFor(modelItem => item.Date) %><br />
                    Längd: <%: Html.DisplayFor(modelItem => item.Duration) %> Minuter
                </td>
                <td style="vertical-align: top">
                    <div>
                        <% foreach (var booking in item.Bookings)
                           { %>
                        <%: booking.UserId != null ? Html.DisplayFor(modelItem => booking.User.FirstName) : Html.DisplayFor(modelItem => booking.Customer.FirstName) %>
                        <%: booking.UserId != null ? Html.DisplayFor(modelItem => booking.User.LastName) : Html.DisplayFor(modelItem => booking.Customer.LastName)%>
                        <%: booking.UserId != null ? Html.DisplayFor(modelItem => booking.User.Phone) : Html.DisplayFor(modelItem => booking.Customer.Phone)%>
                        <%: booking.UserId != null ? Html.DisplayFor(modelItem => booking.User.Email) : Html.DisplayFor(modelItem => booking.Customer.Email)%>
                        <%: Html.ActionLink("Ta bort bokning","UnBook", "Activity", new {actionId = item.Id, bookingId = booking.Id}, null) %>
                        <br />
                        <% } %>
                    </div>
                    <%--<table>
                    <% foreach (var booking in item.Bookings)
                       { %>
                    <tr>
                        <td>
                            <%: Html.DisplayFor(modelItem => booking.User.FirstName) %>
                            <%: Html.DisplayFor(modelItem => booking.User.LastName) %>
                            <%: Html.DisplayFor(modelItem => booking.User.Phone) %>
                            <%: Html.DisplayFor(modelItem => booking.User.Email) %>
                        </td>
                    </tr>
                    <% } %>
                </table>--%>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
<asp:Content runat="server" ID="ScriptsSection" ContentPlaceHolderID="ScriptsSection"></asp:Content>


