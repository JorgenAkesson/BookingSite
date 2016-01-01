<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BookingSiteTest.Models.Company>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Företag
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="MainContentCenter">
        <div class="entries">
            <div class="entry nohover">
                <div>
                    <h2>Företag</h2>
                </div>
                <div>
                    <%: Html.ActionLink("Skapa nytt Företag", "Create") %>
                </div>
            </div>
            <% foreach (var item in Model)
               { %>
            <div class="entry">
                <a class="noUnderline" href="/Calender/Index?companyId= <%:item.Id %>">
                    <div>
                        <h4><%: item.Name %></h4>
                        <%:Html.DisplayFor(modelItem => item.Address.Street) %> , <%:Html.DisplayFor(modelItem => item.Address.City) %>
                    </div>
                </a>
                <%: Html.ActionLink("Ändra", "Edit", new { id=item.Id }) %>
                <%: Html.ActionLink("Ta bort", "Delete", new { id=item.Id }) %>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
