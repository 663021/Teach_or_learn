<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_page.Master" Async="true" AutoEventWireup="true" CodeBehind="Teacher_kurse_edit.aspx.cs" Inherits="TEACH_OR_LEARN.Teacher_kurse_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
<div class="container body-content">
    <div class="jumbotron">
        <h2>Редактировать курс</h2>
        <div class ="row">
            <h3 class="col-md-3">Наименованния</h3>
            <h3 class="col-md-3">Направление</h3>
            <h3 class="col-md-3">Продолжительность</h3>
            <h3 class="col-md-3">Информация</h3>
            <h3 class="col-md-3">Сложность</h3>
        </div>
        <div class="row">
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
               <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"/>
                    <asp:Label runat="server" ID="Label1" CssClass="text-danger" Visible="False">Наименование обязательное поле</asp:Label>

                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control"  TextMode="SingleLine"/>
                    <asp:Label runat="server" ID="Label2" CssClass="text-danger" Visible="False">Направление обязательное поле</asp:Label>

                <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control"  TextMode="SingleLine"/>
                    <asp:Label runat="server" ID="Label3" CssClass="text-danger" Visible="False">Продолжительность обязательное поле</asp:Label>


                <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control"  TextMode="MultiLine"/>
                    <asp:Label runat="server" ID="Label4" CssClass="text-danger" Visible="False">Информация обязательное поле</asp:Label>


               <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control"  TextMode="SingleLine"/>
                    <asp:Label runat="server" ID="Label5" CssClass="text-danger" Visible="False">Сложность обязательное поле</asp:Label>
        </div>
               <asp:Panel ID="Panel5" runat="server"></asp:Panel>
               <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    </div>
    <hr />
</div>
</asp:Content>
