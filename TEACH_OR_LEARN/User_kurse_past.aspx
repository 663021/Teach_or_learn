<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" Async="true" AutoEventWireup="true" CodeBehind="User_kurse_past.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="jumbotron">
        <h2 id="for_h2" runat="server">МОИ КУРСЫ</h2>
        <div class="row">
            <div class="col-md-4">
                <h3 id="for_h3_1" runat="server">Наименование</h3>
            </div>
            <div class="col-md-4">
                <h3 id="for_h3_2" runat="server">Выполнено заданий</h3>
            </div>
        </div>
        <div class="row">
            <asp:Panel class="col-md-4" ID="Panel2" runat="server">
            </asp:Panel>
            <asp:Panel class="col-sm-4" ID="Panel3" runat="server">
            </asp:Panel>
            <asp:Panel class="col-md-4" ID="Panel4" runat="server">
            </asp:Panel>   
        </div> 
    </div>
</asp:Content>
