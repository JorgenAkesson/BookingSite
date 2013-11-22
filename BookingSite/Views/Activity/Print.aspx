<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication4.Models.Activity>" %>

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

    <%: Html.DisplayNameFor(model => model.Name) %>:
    <%: Html.DisplayFor(model => model.Name) %>
    <br />
    <%: Html.DisplayNameFor(model => model.Description) %>:
    <%: Html.DisplayFor(model => model.Description) %>
    <table>
        <tr>
            <th>First name
            </th>
            <th>Last name
            </th>
            <th>Signature
            </th>
        </tr>

        <%  foreach (var item in Model.Booking)
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
        <input type="button" value="Print this page" onclick="printpage()" />
    </p>
</body>
</html>
