<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ActivityModel>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="wactivityIdth=device-wactivityIdth" />
    <title>Print</title>
</head>
<body>
    <script>
        window.print();
        function printpage() {
            //debugger;
            window.print();
        }
    </script>

    <%: Html.DisplayNameFor(model => model.Activity.Name) %>:
    <%: Html.DisplayFor(model => model.Activity.Name) %>
    <br />
    <%: Html.DisplayNameFor(model => model.Activity.Description) %>:
    <%: Html.DisplayFor(model => model.Activity.Description) %>
    <table>
        <tr>
            <th>First name
            </th>
            <th>Last name
            </th>
            <th>Signature
            </th>
        </tr>

        <%  foreach (var item in Model.Activity.Booking)
            { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Person.FirstName) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Person.LastName) %>
            </td>
            <td>
                <input id="Text1" type="text" />
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Back to List", "Booking") %>
        <input type="button" value="Print this page" onclick="printpage()" />
    </p>
</body>
</html>
