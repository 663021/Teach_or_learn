<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Teacher_page.Master" AutoEventWireup="true" CodeBehind="Teacher_kurse_creat.aspx.cs" Inherits="TEACH_OR_LEARN.Teacher_kurse_creat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
  <div class="container body-content">
    <div class="form-horizontal">
        <div class="lines">
                <h4>Регистрация курса</h4>                          
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Наименование</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                        <asp:Label runat="server" ID="NameDanger" AssociatedControlID="Name" CssClass="text-danger" Visible="False">Наименование обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Naprav" CssClass="col-md-2 control-label">Направление </asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Naprav" CssClass="form-control"  />
                        <asp:Label runat="server" ID="NapravDenger" AssociatedControlID="Naprav" CssClass="text-danger" Visible="False">Направление обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Info" CssClass="col-md-2 control-label">Информация</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Info" CssClass="form-control" TextMode="MultiLine" Width="280px"/>
                        <asp:Label runat="server" ID="InfoDanger" AssociatedControlID="Info" CssClass="text-danger" Visible="False">Информация обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Sloj" CssClass="col-md-2 control-label">Сложность</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Sloj" CssClass="form-control" />
                        <asp:Label runat="server" ID="SlojDanger" AssociatedControlID="Sloj" CssClass="text-danger" Visible="False">Информация обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Count" CssClass="col-md-2 control-label">Продолжительность</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Count" CssClass="form-control"/>
                        <asp:Label runat="server" ID="CountDanger" AssociatedControlID="Count" CssClass="text-danger" Visible="False">Продолжительность обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Teacher" CssClass="col-md-2 control-label">Руководитель</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Teacher" CssClass="form-control" Enabled="false"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Регистрация" CssClass="btn btn-default" OnClick="CreatClick"/>
                    </div>
                </div>
          </div>
    </div>
      <hr />
  </div>
</asp:Content>

