<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>WebCam</h2>

<%--<iframe src="http://akessonit.babordsvagen.se/" width="950" height="600"></iframe>
<iframe src="http://babordsvagen.se:188/snapshot.cgi?user=admin4&pwd=admin4&count=0" width="640" height="480"></iframe>--%>

<iframe src="http://babordsvagen.se:188/videostream.asf?user=admin4&pwd=admin4&resolution=32&rate=0" width="640" height="480"></iframe>

</asp:Content>
