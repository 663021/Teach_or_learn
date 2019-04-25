<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" Async="true" AutoEventWireup="true" CodeBehind="Default_page_past.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="jumbotron">
        <h2 id="for_h2" runat="server">ЗАПЕШИТЕСЬ НА КУРС!</h2>
        <p class="lead">Наш сервис готов предоставить вам множество различных курсов, для изучения нового..</p>
        <p class="lead">Выберите интересный вам курс и проходите его получая новые знания! </p>
        <p><a href="/Kurses_page_past.aspx" class="btn btn-primary btn-lg">Курсы &raquo;</a></p>
    </div>

    <div class="jumbotron">
        <h2>Get more libraries</h2>
            <iframe id="video_id" width="854" height="480" src="https://www.youtube.com/embed/JAhJJmr_3PI"></iframe>
    </div>

    <div class="jumbotron">
         <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
    </div>    
</asp:Content>
