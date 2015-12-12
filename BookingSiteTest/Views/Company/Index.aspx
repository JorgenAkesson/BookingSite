<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Company>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Företag
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Företag</h2>
    <%: Html.ActionLink("Skapa nytt Företag", "Create") %>
    <table>
        <% foreach (var item in Model)
           { %>
        <tr>
            <div>
                <td>
                    <a href="/Calender/Index?companyId= <%:item.Id %>">
                        <div>
                            <%:Html.DisplayFor(modelItem => item.Name) %>
                            <br />
                            <%--<%:Html.DisplayFor(modelItem => item.Address.Name) %> ,--%>
                            <%:Html.DisplayFor(modelItem => item.Address.Street) %> , 
                            <%:Html.DisplayFor(modelItem => item.Address.City) %>
                        </div>
                    </a>
                </td>
                <td>
                    <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id }) %>
                </td>
            </div>
        </tr>
        <% } %>
    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
