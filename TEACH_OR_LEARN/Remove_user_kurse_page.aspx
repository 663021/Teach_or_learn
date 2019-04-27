<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" AutoEventWireup="true" Async="true" CodeBehind="Remove_user_kurse_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="jumbotron">
        <h2 style="text-align:center;" id="H1" runat="server">ВЫ УВЕРЕНЫ ЧТО ХОТИТЕ ОТПИСАТСЯ </h2>
        <h2 style="text-align:center;" id="H2" runat="server"> ОТ КУРСА:</h2>
        <h2 style="text-align:center;" id="for_h2" runat="server">ПРОГРАММИРОВАНИЕ</h2>
        <div class="row">
            <div class="col-md-4">
                <asp:Button runat="server" Text="Назад" ID="Unnamed4" CssClass="btn btn-default" OnClick="Unnamed4_Click"/>
            </div>
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <asp:Button runat="server" Style="display: block; margin-left: auto;" Text="Отписатся" ID="Button1" CssClass="btn btn-default" OnClick="Button1_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
