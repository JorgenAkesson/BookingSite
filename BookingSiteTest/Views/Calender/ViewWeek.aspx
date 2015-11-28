﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewWeek
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewWeek</h2>

    <script>
        $(document).ready(function () {

            $('#calendar').fullCalendar({
                header: {
                    left: "prev, next,today",
                    center: "title",
                    right: " agendaWeek, month,"
                },
                editable: false,
                defaultView: "agendaWeek",
                //theme: true,
                events: {
                    url: '/Calender/GetEvents',
                    data: {
                        calenderId: <%: Model.Id %>
                        }
                },
                eventClick: function(event) {
                    if(event.description == false)
                        window.location = "/Calender/BookActivity?activityId=" + event.id;
                    var a = event.description;
                }

            });

        });

    </script>

    <div id="calendar"></div>

    <%--<% var firstDayNumber = ((DateTime)ViewData["FirstDateOfWeek"]).Day; %>--%>

    <%--Set--%>
    <%--    <div style="position: relative; width: 600px; height: 500px">
        <% for (int x = 0; x <= 500; x = x + 50)
           { %>
        <hr style="margin: 0px; position: absolute; top: <%: x %>px; width: 600px" />
        <% } %>

        <% var persId = ViewData["UserId"] as int?;
           foreach (var aD in ViewData["ActivitiesData"] as List<BookingSiteTest.Models.Activity>)
           {
               int topMin = 8 * 60; // Set starttime to 8 am
               int y = (aD.Date.Hour * 60 + aD.Date.Minute - topMin) / 2;
               int x = 100;
               var fullyBooked = aD.Bookings.Count() >= aD.MaxPerson;
               string color = "#00FF00";
               if (fullyBooked)
                   color = "#FF0000";
        %>
        <div style="position: absolute; top: <%: y.ToString() %>px; left: <%: x.ToString() %>px;">
            <a href='<%: Url.Action("BookActivity", new RouteValueDictionary(new { id = Model.Id, activityId = aD.Id })) %>'>
                <p>
                    <input type="button" value="<%: aD.Name %>" style="background-color: <%: color%>" />
                </p>
            </a>
        </div>
        <% } %>
    </div>--%>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
