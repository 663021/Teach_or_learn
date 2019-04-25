<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" AutoEventWireup="true" Async="true" CodeBehind="Kurses_page_past.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="jumbotron">
        <h2>ВСЕ КУРСЫ</h2>
        <div class="row">
            <div class="col-md-3">
                <h3>Наименование</h3>
            </div>
            <div class="col-md-3">
                <h3>Продолжительность</h3>
            </div>
            <div class="col-md-3">
                <h3>Количество заданий</h3>
            </div>
        </div>
        <div class="row">
            <asp:Panel class="col-md-3" ID="Panel2" runat="server">
            </asp:Panel>
            <asp:Panel class="col-sm-3" ID="Panel3" runat="server">
            </asp:Panel>
            <asp:Panel class="col-sm-3" ID="Panel1" runat="server">
            </asp:Panel>
            <asp:Panel class="col-md-3" ID="Panel4" runat="server">
            </asp:Panel>   
        </div> 
    </div>
</asp:Content>
