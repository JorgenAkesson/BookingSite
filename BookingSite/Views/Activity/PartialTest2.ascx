<%@ Control Language="C#"
    Inherits="System.Web.Mvc.ViewUserControl<MvcApplication1.Models.ActivitiesModel>" %>

<%: ((DateTime)ViewData["DayDate"]).ToShortDateString() %>

<% DateTime date = ((DateTime)ViewData["DayDate"]); %>


<% if (Model.Activities != null)
   {
       foreach (var activity in Model.Activities.Where(a => a.Date == date.Date))
       { %>
<%: Html.DisplayFor(a => activity.Name) %>
<br />
<%: Html.DisplayFor(modelItem => activity.MaxPerson) %>
<br />
<%: Html.DisplayFor(modelItem => activity.Booking.Count) %>
<br />

<%
var book = activity.Booking.Where(a => a.PersonId == Model.PersonId).FirstOrDefault();
var isBooked = book == null ? false : true;
if (activity.Booking.Count < activity.MaxPerson && !isBooked)
{ %>
<%= Html.ActionLink("Book", "Book", "Activity", new { activityId = activity.Id, fromDate = ViewData["fromDate"], toDate = ViewData["toDate"]}, null) %>
<% } %>
<%else
           { %>
<%= Html.ActionLink("UnBook", "UnBook", "Activity", new { activityId=activity.Id, fromDate = ViewData["fromDate"], toDate = ViewData["toDate"]}, null) %>
<% } %>

<input type="button" style="background: none; border: 0; color: #0026ff; text-decoration: underline;" value="Check Booked" onclick="myFunction(<%= activity.Id %>)" />
<%= Html.ActionLink("Print", "Print",  new { activityId=activity.Id}) %>

<%
if (isBooked)
{ %>
<asp:Label ID="Label1" runat="server" Text="Booked"></asp:Label>
<% } %>
<br />
<%}
   }
%>PartialBooking