<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication4.Models.Company>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Image</h2>
    <form method="post" enctype="multipart/form-data">
        <%: Html.HiddenFor(model => model.Id) %>
        <label for="file">Filename:</label>
        <input type="file" name="file" id="file" />

        <input type="submit" />
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
