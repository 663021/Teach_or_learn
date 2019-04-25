<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page.Master" AutoEventWireup="true" CodeBehind="Default_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="jumbotron">
        <h2>TEACH OR LEARN</h2>
        <p class="lead">В нашу эпоху цифровых технологий и интернета можно получить высшее образование, не выходя из дома. В этом Вам поможет дистанционная система обучения!</p>
        <p class="lead">Студент и преподаватель, которого называют тьютором, могут находиться на разных континентах, но это не будет мешать учебному процессу!</p>
        <p><a href="/Information_page.aspx" class="btn btn-primary btn-lg">Подробнее &raquo;</a></p>
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
