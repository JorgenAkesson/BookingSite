<%@ Page Title="BookActivity" Language="C#" Inherits="System.Web.Mvc.ViewPage<BookingSiteTest.Models.ViewModels.ActivityBooking>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Bekräfta din bokning
</asp:Content>

<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <div class="entries">
        <h2>Bekräfta din bokning</h2>

        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Calender</legend>
            <%: Html.HiddenFor(model => model.Activity.Id) %>
            <%: Html.HiddenFor(model => model.Activity.CalenderId) %>
            <%: Html.HiddenFor(model => model.Activity.Date) %>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Customer.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Customer.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.Customer.FirstName) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Customer.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Customer.LastName) %>
                <%: Html.ValidationMessageFor(model => model.Customer.LastName) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Customer.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Customer.Email) %>
                <%: Html.ValidationMessageFor(model => model.Customer.Email) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Customer.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Customer.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Note) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Note) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Note) %>
                <%: Html.ValidationMessageFor(model => model.Note) %>
            </div>
            <p>
                <input type="submit" value="Spara" />
            </p>
        </fieldset>
        <% } %>

        <h2><%: Model.Activity.Date.DayOfWeek %> <%: Model.Activity.Date.ToLongDateString() %></h2>
        <h3>Name: <%: Model.Activity.Name %></h3>

        <p><%: Model.Activity.Description %></p>

        <p>Lämna ett meddelande!</p>
        <textarea id="note" rows="2"></textarea>
        <br>

        <input type="button" value="Boka" onclick="book()" />
        <input type="submit" value="Avbryt" onclick="cancel()">
        <script>
            function cancel() {
                window.location.href = "../../Calender/ViewWeek?id=" + '<%: Model.Activity.Calender.Id%>' + "&activityDate=" + '<%: Model.Activity.Date.ToShortDateString() %>';
            }
            function book() {
                $.ajax({
                    url: '../../Calender/Book?id=' + '<%: Model.Activity.Id %>' +
                    '&note=' + $('#note').val(),
                datatype: "text",
                type: 'POST',
                success: function () {
                    window.location.href = "../../Calender/ViewWeek?id=" + '<%: Model.Activity.Calender.Id%>' + "&activityDate=" + '<%: Model.Activity.Date.ToShortDateString() %>';
                }
            });
        }
        </script>
    </div>
</asp:Content>
<asp:Content runat="server" ID="ScriptsSection" ContentPlaceHolderID="ScriptsSection"></asp:Content>
