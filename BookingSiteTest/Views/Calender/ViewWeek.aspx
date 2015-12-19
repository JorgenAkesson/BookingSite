﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Calender>" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="BookingSiteTest.Models" %>

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
                maxTime: "20:00",
                height: 582,
                defaultView: "agendaWeek",
                allDaySlot: false,
                theme: true,
                events: {
                    url: "/Calender/GetEvents",
                    data: { 'calenderId': '<%: Model.Id %>' }
                },
                eventClick: function (event) {
                    if (event.bookedByMe == true) {
                        $('#activityName').text(event.title);
                        $("#unBookDialog").dialog(
                        {
                            resizable: false,
                            buttons: {
                                "Ok": function () {
                                    var data = { 'activityId': event.id, 'activityDate': event.start._i };
                                    var jsonData = JSON.stringify(data);
                                    $.ajax({
                                        url: '../../Activity/UnBook',
                                        datatype: "text",
                                        type: "POST",
                                        data: { "jsonData": jsonData },
                                        success: function (data) {
                                            window.location.reload();
                                        }
                                    });
                                    $(this).dialog("close");
                                },
                                "Avbryt": function () {
                                    $(this).dialog("close");
                                },

                            }
                        });
                    }
                    else if (event.fullyBooked == false) {
                        window.location = "/Calender/BookActivity?activityId=" + event.id;
                    }
                },
                dayClick: function (date, jsEvent, view) {
                    $("#startTime").val(date.format("HH:mm"));
                    // Add Dialog for Create Activity
                    $("#dialog").dialog(
                    {
                        resizable: false,
                        width: 350,
                        buttons: {
                            "OK": function () {
                                if ($('#addDialog').valid()) {
                                    var data = { 'name': $("#name").val(), 'nrOfPerson': $("#nrOfPerson").val(), 'date': date.format(), 'startTime': $("#startTime").val(), 'length': $("#length").val(), 'description': $("#description").val(), 'calenderId': '<%: Model.Id%>' };
                                    var jsonData = JSON.stringify(data);
                                    $.ajax({
                                        url: '../../Activity/CreateFromDialog',
                                        datatype: "text",
                                        type: "POST",
                                        data: { "jsonData": jsonData },
                                        success: function (data) {
                                            $('#calendar').fullCalendar('refetchEvents');
                                        }
                                    });
                                    $(this).dialog("close");
                                }
                            },
                            "Avbryt": function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
            });
            <% var date = DateTime.ParseExact((string)ViewData["ActivityDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture); %>
            $('#calendar').fullCalendar('gotoDate', '<%: date %>');
            $.validator.addMethod(
                    "regex",
                    function (value, element, regexp) {
                        var check = false;
                        return this.optional(element) || regexp.test(value);
                    },
                "Please check your input."
            );
            $("#addDialog").validate({
                rules: {
                    nameN: {
                        required: true,
                    },
                    nrOfPersonN: {
                        required: true,
                        digits: true,
                    },
                    startTimeN: {
                        required: true,
                        regex: /^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$/
                    },
                    lengthN: {
                        required: true,
                        digits: true,
                    }
                },
                messages: {
                    nameN: "Namn måste anges.",
                    lengthN: {
                        required: "Längd måste anges.",
                        digits: "Ange endast siffror."
                    },
                    startTimeN: {
                        required:"Starttid måste anges.",
                        regex: 'Ange på formen tt:mm.'
                    },
                    nrOfPersonN: {
                        required: "Antal personer måste anges.",
                        digits: "Ange endast siffror."
                    }
                }
            });
        });

    </script>

    <div style="display: none;">
        <div id="dialog" title="Lägg till Activitet!">
            <form id="addDialog">
                <label>Namn</label>
                <input type="text" name="nameN" id="name" value="Default namn">
                <label>Beskrivning</label>
                <input type="text" name="descN" id="description" value="Default beskrivning.">
                <label>Antal personer</label>
                <input type="text" name="nrOfPersonN" id="nrOfPerson" value="1">
                <label>Start tid</label>
                <input type="text" name="startTimeN" id="startTime" value="10:00">
                <label>Längd</label>
                <input type="text" name="lengthN" id="length" value="60">
            </form>
        </div>
    </div>

    <div style="display: none;">
        <div id="unBookDialog" title="Avboka din aktivitet!">
            <form>
                <fieldset>
                    <label for="name" id="activityName"></label>
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
