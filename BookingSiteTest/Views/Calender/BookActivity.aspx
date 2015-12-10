<%@ Page Title="BookActivity" Language="C#" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>

<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Bekräfta din bokning</h2>

    <h2><%: Model.Date.DayOfWeek %> <%: Model.Date.ToLongDateString() %></h2>
    <h3>Name: <%: Model.Name %></h3>

    <p><%: Model.Description %></p>

    <p> Lämna ett meddelande!</p>
    <textarea id="note" rows="2"></textarea>
    <br>

    <input type="button" value="Boka" onclick="book()" />
    <form action="<%: Url.Action("ViewWeek", new RouteValueDictionary(new { id = Model.Calender.Id, activityDate = Model.Date })) %>" style="float: left">
        <input type="submit" value="Avbryt">
    </form>

    <script>
        function book() {
            $.ajax({
                url: '../../Calender/Book?id=' + '<%: Model.Id %>' +
                                                  '&note=' + $('#note').val(),
                datatype: "text",
                type: 'POST',
                success: function () {
                    window.location.href = "../../Calender/ViewWeek?id=" + '<%: Model.Calender.Id%>' + "&activityDate=" + '<%: Model.Date %>';
                }
            });
        }
    </script>
</asp:Content>
<asp:Content runat="server" ID="ScriptsSection" ContentPlaceHolderID="ScriptsSection"></asp:Content>
