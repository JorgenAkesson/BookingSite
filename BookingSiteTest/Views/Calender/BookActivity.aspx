<%@ Page Title="BookActivity" Language="C#" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.Activity>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Bekräfta din bokning
</asp:Content>

<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <div class="entries">
        <h2>Bekräfta din bokning</h2>

        <h2><%: Model.Date.DayOfWeek %> <%: Model.Date.ToLongDateString() %></h2>
        <h3>Name: <%: Model.Name %></h3>

        <p><%: Model.Description %></p>

        <p>Lämna ett meddelande!</p>
        <textarea id="note" rows="2"></textarea>
        <br>

        <input type="button" value="Boka" onclick="book()" />
        <input type="submit" value="Avbryt" onclick="cancel()">
        <script>
            function cancel() {
                window.location.href = "../../Calender/ViewWeek?id=" + '<%: Model.Calender.Id%>' + "&activityDate=" + '<%: Model.Date.ToShortDateString() %>';
        }
        function book() {
            $.ajax({
                url: '../../Calender/Book?id=' + '<%: Model.Id %>' +
                    '&note=' + $('#note').val(),
                datatype: "text",
                type: 'POST',
                success: function () {
                    window.location.href = "../../Calender/ViewWeek?id=" + '<%: Model.Calender.Id%>' + "&activityDate=" + '<%: Model.Date.ToShortDateString() %>';
                }
            });
        }
        </script>
    </div>
</asp:Content>
<asp:Content runat="server" ID="ScriptsSection" ContentPlaceHolderID="ScriptsSection"></asp:Content>
