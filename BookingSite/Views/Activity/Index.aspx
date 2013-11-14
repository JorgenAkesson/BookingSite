<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication4.Models.Activity>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(function () {
            //debugger;
            $('#my-dialog').dialog({
                autoOpen: false,
                width: 400,
                resizable: false,
                modal: true
            });

            $('#show-modal').click(function() {
                $('#my-dialog').load("@Url.Action('MyActionOnController')", function() {
                    $(this).dialog('open');
                });
                return false;
            });

        });
    </script>

    <div id="my-dialog"></div>
    <a href="#" id="show-modal">Click Me </a>

    <h2>Index</h2>
    <form method="GET" action="/Activity/Details/">
    </form>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Name) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Description) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Date) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.MaxPerson) %>
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
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
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id, number = 12 }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
            </td>
        </tr>
        <% } %>
    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
