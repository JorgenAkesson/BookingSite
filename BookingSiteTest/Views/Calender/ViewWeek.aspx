<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kalender
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%: Html.ActionLink("Tillbaks till Kalendrar","Index", "Calender", new {companyId = Model.CompanyID}, null) %>
    <h2><%: Model.Company.Name %></h2>
    <h3><%: Model.Name %></h3>
    <br />

    <%: Scripts.Render("~/bundles/fullcalendarjs") %>

    <script>
        $(document).ready(function () {

            $('#calendar').fullCalendar({
                header: {
                    left: "prev, next,today",
                    center: "title",
                    right: " agendaWeek, month,"
                },
                editable: false,
                minTime: "08:00",
                maxTime: "19:00",
                height: 570,
                defaultView: "agendaWeek",
                allDaySlot: false,
                theme: true,
                events: {
                    url: '/Calender/GetEvents',
                    data: {
                        calenderId: <%: Model.Id %>
                        }
                },
                eventClick: function(event) {
                    if (event.description == false) {
                        window.location = "/Calender/BookActivity?activityId=" + event.id;
                        // Dialoge for Book Activity
                        //$("#bookDialog").dialog(
                        //{
                        //    resizable: false,
                        //    buttons: {
                        //        "Save": function() {
                        //        },
                        //        "Book": function() {
                        //            var data = { 'bookNote': $("#bookNote").val(), 'activityId': event.id };
                        //            var jsonData = JSON.stringify(data);
                        //            $.ajax({
                        //                url: '../../Calender/Book',
                        //            datatype: "text",
                        //            type: "POST",
                        //            data: { "jsonData": jsonData },
                        //            success: function(data) {
                        //                //debugger;
                        //                window.location.reload();
                        //            }
                        //        });
                        //        $(this).dialog("close");
                        //        $(this).dialog("close");
                        //    }
                        //}
                        //});
                    }
                },
                dayClick: function(date, jsEvent, view) {
                    $("#startTime").val(date.format("HH:mm"));
                    // Add Dialog for Create Activity
                    $("#dialog").dialog(
                    {
                        resizable: false,
                        width: 350,
                        buttons: {
                            "OK": function() {
                                var data = { 'name': $("#name").val(), 'nrOfPerson': $("#nrOfPerson").val(), 'date': date.format(), 'startTime': $("#startTime").val(), 'length': $("#length").val(), 'description': $("#description").val(), 'calenderId': <%: Model.Id%> };
                                var jsonData = JSON.stringify(data);
                                $.ajax({
                                    url: '../../Activity/CreateFromDialog',
                                    datatype: "text",
                                    type: "POST",
                                    data: { "jsonData": jsonData },
                                    success: function(data) {
                                        $('#calendar').fullCalendar('refetchEvents');
                                    }
                                });
                                $(this).dialog("close");
                            },
                            "Cancel": function() {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
            });
            <% var date = DateTime.ParseExact((string) ViewData["ActivityDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture); %>
            $('#calendar').fullCalendar('gotoDate', '<%: date %>' );
        });

    </script>
    <div style="visibility: collapse; display: none;">
        <div id="dialog" title="Add Activity!">
            <form>
                <fieldset>
                    <label for="name">Name</label>
                    <input type="text" name="name" id="name" value="Defalt Name">
                    <label for="name">Description</label>
                    <input type="text" id="description" value="Default description.">
                    <label for="name">Nr of persons:</label>
                    <input type="text" id="nrOfPerson" value="1">
                    <label for="name">Start time:</label>
                    <input type="text" id="startTime" value="">
                    <label for="name">Length:</label>
                    <input type="text" id="length" value="60">
                </fieldset>
            </form>
        </div>
    </div>

    <div style="visibility: collapse; display: none;">
        <div id="bookDialog" title="Book!">
            <form>
                <fieldset>
                    <label for="name" id="userName">UName</label>
                    <label for="name" id="activityName">ActivityName</label>
                    <label for="name">Booking note:</label>
                    <input type="text" id="bookNote" value="">
                </fieldset>
            </form>
        </div>
    </div>

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

    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
