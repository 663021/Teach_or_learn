<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" AutoEventWireup="true" Async="true" CodeBehind="Kurse_work_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="jumbotron">
                <div style="padding-top: 10px" class="form-group">
                    <asp:Button style="margin-right: 20px" runat="server" Text="Назад" ID="Unnamed4" CssClass="btn btn-default" OnClick="Unnamed4_Click" />
                    <asp:Button runat="server" Text="Отписатся от курса" ID="Button1" CssClass="btn btn-default" />
                </div>       
            </div>    
            <div class="jumbotron">
                    <h3 style="padding-left: 170px" id="for_h3_1" runat="server">О КУРСЕ</h3>
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" CssClass="control-label">Наименование: Программирование</asp:Label>     
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
                        <asp:Label runat="server" ID="Label4" CssClass="control-label">Сложность: 7 из 7</asp:Label>                   
                 </div>
            </div>     
        </div>
        <div class="col-md-6">
                <h3 style="padding-left: 210px; padding-top: 70px" id="H1" runat="server">ЗАДАНИЯ КУРСА</h3>
                <asp:Panel style="padding-top: 30px" class="col-md-3" ID="Panel2" runat="server">
                </asp:Panel>
        </div>
    </div>
</asp:Content>
