<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Teacher_page.Master" Async="true" CodeBehind="Home_work.aspx.cs" Inherits="TEACH_OR_LEARN.home_work" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="alert-warning" style="position:absolute;z-index: 100;width: 270px;height: 200px;margin-top: 15%;margin-left: 40%;" runat="server" id="Window" visible="false">
        <h3 runat="server" id="name" style="margin-left: 7%;">Изменение оценки, введите значение</h3>
        <asp:TextBox runat="server" ID="TextBox" style="position:center;z-index: 99; margin-top: 2%;margin-left: 6%;"></asp:TextBox>
        <asp:TextBox runat="server" ID="id" visible="false" style="position:center;z-index: 99; margin-top: 2%;margin-left: 6%;"></asp:TextBox>
        <input style="font-size: small;margin-top: 2%;margin-left: 6%;" class="control-input" type="file" id="File1" name="File1" accept=".docx, .doc" runat="server" visible="false" />
        <asp:Button runat="server" ID="button1" Text="Отправить" style="position:center;z-index: 99; margin-top: 2%;margin-left: 6%;" OnClick="UpdateQuest"></asp:Button>
        <asp:Button runat="server" ID="button2" Text="Отправить" style="position:center;z-index: 99; margin-top: 2%;margin-left: 6%;" OnClick="LoadQuest"></asp:Button>
    </div>
    <div class="jumbotron" runat="server" id="jumb">
           <asp:Panel runat="server" ID="Panel1"></asp:Panel>
            </div>
            <div class="jumbotron" runat="server" id="Quest" visible="false">
                <div class="row">
                    <h3 class="col-md-3">Ученик</h3> <h3 class="col-md-2">Оценка</h3> <h3 class="col-md-3">Файл</h3>
                </div>
                <div class="row" >
                    <asp:Label runat="server" ID="Label1" class="col-md-3"></asp:Label>
                    <asp:Label runat="server" ID="Label2" class="col-md-2"></asp:Label>
                    <asp:Label runat="server" ID="Label3" class="col-md-3"></asp:Label>
                    <asp:Label runat="server" ID="Label4" class="col-md-1"  style="margin-right: 65px"></asp:Label>
                    <asp:label runat="server" ID="Label5" class="col-md-1"  style="margin-right: 25px"></asp:label> 
                    <asp:Label runat="server" ID="Label6" class="col-md-1"></asp:Label> 
                </div>
            </div>
        <hr /> 
</asp:Content>
