<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_page.Master" AutoEventWireup="true" CodeBehind="Teacher_kurse_creat.aspx.cs" Inherits="TEACH_OR_LEARN.Teacher_kurse_creat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="form-horizontal">
        <div class="lines">
                <h4>Регистрация курса</h4>                          
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Имя</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Names" CssClass="form-control" />
                        <asp:Label runat="server" ID="for_name" AssociatedControlID="Email" CssClass="text-danger" Visible="False">Имя обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Адрес электронной почты</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:Label runat="server" ID="for_email" AssociatedControlID="Email" CssClass="text-danger" Visible="False">Адрес электронной почты обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Login" CssClass="col-md-2 control-label">Логин</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Login" CssClass="form-control"/>
                        <asp:Label runat="server" ID="for_login" AssociatedControlID="Email" CssClass="text-danger" Visible="False">Логин обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Пароль</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" CssClass="form-control"/>
                        <asp:Label runat="server" ID="for_pass" AssociatedControlID="Email" CssClass="text-danger" Visible="False">Пароль обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Подтверждение пароля</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control"/>
                        <asp:Label runat="server" ID="for_confirm_pass" AssociatedControlID="Email" CssClass="text-danger" Visible="False">Подтверждение пароля обязательное поле</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Регистрация" CssClass="btn btn-default"/>
                    </div>
                </div>
          </div>
    </div>
</asp:Content>

