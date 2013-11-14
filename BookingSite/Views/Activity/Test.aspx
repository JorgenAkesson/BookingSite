<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication4.Models.Person>" %>

<%@ Import Namespace="MvcApplication4.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Message"] %></h2>

    <script>
        $(document).ready(function () {
            $("#btn1").click(function () {
                alert("Text: " + $("#test").text());
            });
        });
        function myFunction() {
            alert("Welcome ");
        }
        function getResponse() {
            //debugger;
            $.ajax({
                type: 'Get',
                dataType: 'json',
                url: 'http://localhost:51012/RESTApi/APIActivity',
                success: function (data) {
                    checkData(data);
                    //alert(data);
                }
            });
        }

        function checkData(data) {
            //debugger;
            $.each(data, function (bb) {
                console.log(bb);
                console.log(data[bb]);
                console.log(data[bb].Name);
            });
            var tbl_body = "";
            $.each(data, function () {
                var tbl_row = "";
                $.each(this, function(k, v) {
                    tbl_row += "<td>" + v + "</td>";
                });
                tbl_body += "<tr>" + tbl_row + "</tr>";
            })
            $("#target_table_activityId").html(tbl_body);
        }
    </script>
    <button id="btn1">Show Text</button>
    <button id="Button1" onclick="getResponse()">Ajax call to REST service</button>
    <table id="target_table_id"></table>    

    <% if (Roles.IsUserInRole("Admin"))
       { %>
    I am admin!
    <% } %>
    <br />
    <br />
    <%
        {
            string a = "Kalle";
            a = a + " Anka";
            Response.Write(a);
        }
    %>
    <br />
    Number: <%= DateTime.Now%>
    <br />
    <br />

    <%= LabelHelper.Label("Hej label helpern!")  %>

    <button id="opener">open the dialog</button>
    <div id="dialog" title="Dialog Title">I'm a dialog</div>
    <script>
        $("#dialog").dialog({ autoOpen: false });
        $("#opener").click(function () {
            $("#dialog").dialog("open");
        });
    </script>

    <fieldset>
        <legend>Person</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => Model.Name) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Name) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Age) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Age) %>
        </div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* activityId=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
