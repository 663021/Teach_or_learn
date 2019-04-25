<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" AutoEventWireup="true" Async="true" CodeBehind="About_kurs_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="form-horizontal">
        <div class="lines">
            <div class="jumbotron">
                <div class="col-md-offset-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" CssClass="control-label"><strong>Наименование курса: Программирование</strong></asp:Label>     
                    </div>    
                </div>               
                <div class="form-group">
                        <asp:Label runat="server" ID="Label2" CssClass="control-label">Направление: ИТ</asp:Label>                  
                    </div>
                <div class="form-group">
                        <asp:Label runat="server" ID="Label6" CssClass="control-label">Руководитель: ИТ</asp:Label>                  
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label3" CssClass="control-label">Продолжительность: 3 месяца</asp:Label>    
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label7" CssClass="control-label">Количество заданий: 7 из 7</asp:Label>                   
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label4" CssClass="control-label">Сложность: 7 из 7</asp:Label>                   
                    </div>
                <div class="form-group">
                        <asp:Label runat="server" ID="Label5" CssClass="control-label">Описание: Прогрмаиирование очень перспективнай профессия для тек кто любит работать с компьютерами.</asp:Label>                   
                    </div>
                <div class="form-group">
                    <asp:Button runat="server" style="margin-right: 20px" Text="Назад" ID="Unnamed4" CssClass="btn btn-default" OnClick="Unnamed4_Click" />
                    <asp:Button runat="server" Text="Записатся" ID="Button1" CssClass="btn btn-default" OnClick="Button1_Click" />
                </div>
            </div>
         </div> 
    </div>
</asp:Content>
