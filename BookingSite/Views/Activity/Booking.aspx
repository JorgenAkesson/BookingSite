<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ActivitiesModel>" %>

<%@ Import Namespace="MvcApplication4.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Booking
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Booking</h2>
    <% using (Html.BeginForm())
       { %>
    Name:
    <%:  Html.DisplayFor(modelItem => Model.FirstName)%>
    <%:  Html.DisplayFor(modelItem => Model.LastName) %>
    <br />

    <script>
        $(document).ready(function () {
            //debugger;
            $("#btn1").mouseover(function () {
                alert("Text: " + $("#LastName").attr("value"));
            });
            //$("a").click(function () {
            //    var valueF = $("#FirstName").attr("value");
            //    $(this).attr('href', function () {
            //        return this.href += '?FirstName=' + encodeURIComponent(valueF);
            //    });
            //    var valueL = $("#LastName").attr("value");
            //    $(this).attr('href', function () {
            //        return this.href += '&LastName=' + encodeURIComponent(valueL);
            //    });
            //});
        });

        function myFunction(id) {
            //debugger;
            $("#a" + id).dialog({ autoOpen: false });
            $("#a" + id).dialog("open");
        }
    </script>
    <table>
        <tr>
            <th>Name <%--<%: Html.DisplayNameFor(model => model.Activities.Name) %>--%>
            </th>
            <th>Description <%--<%: Html.DisplayNameFor(model => model.Description) %>--%>
            </th>
            <th>Date <%--<%: Html.DisplayNameFor(model => model.Date) %>--%>
            </th>
            <th>MaxPerson <%--<%: Html.DisplayNameFor(model => model.MaxPerson) %>--%>
            </th>
            <th>PersonBooked
            </th>
            <th></th>
        </tr>

        <%  foreach (Activity item in Model.Activities)
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
                <%: Html.DisplayFor(modelItem => item.Booking.Count) %>
            </td>
            <td>
                <%
                var book = item.Booking.Where(a => a.PersonId == Model.PersonId).FirstOrDefault();
                var isBooked = book == null ? false : true;
                if (item.Booking.Count < item.MaxPerson && !isBooked)
                { %>
                <%= Html.ActionLink("Book", "Book", "Activity", new { activityId = item.Id }, null) %>
                <% } %>
                <%else
                { %>
                <%= Html.ActionLink("UnBook", "UnBook", "Activity", new { activityId=item.Id}, null) %>
                <% } %>

                <input type="button" style="background: none; border: 0; color: #0026ff; text-decoration: underline;" value="Check Booked" onclick="myFunction(<%= item.Id %>)" />
                <%= Html.ActionLink("Print", "Print",  new { activityId=item.Id}) %>

                <%
                if (isBooked) { %>
                <asp:Label ID="Label1" runat="server" Text="Booked"></asp:Label>
                <% } %>
            </td>
            <td>
                <div id="a<%= item.Id %>" style="display: none">
                    <% foreach (var booking in item.Booking)
                       { %>
                    <%: Html.DisplayFor(bookingItem => booking.Person.FirstName) %>
                    <%: Html.DisplayFor(bookingItem => booking.Person.LastName) %>
                    <br />
                    <% } %>
                </div>
            </td>
        </tr>
        <% } %>
    </table>
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
