<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page.Master" AutoEventWireup="true" Async="true" CodeBehind="Login_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="form-horizontal">
        <div class="lines">
            <div class="col-md-offset-5">
                <h4 style="padding-left: 30px;">АВТОРИЗАЦИЯ</h4>   
             </div>                       
             <hr />
             <div class="col-md-offset-3">
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Login" CssClass="col-md-2 control-label">Логин</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Login" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Пароль</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" CssClass="form-control" />
                            <div class="lines">
                                <asp:Label runat="server" ID="for_pass" AssociatedControlID="for_pass" Style="padding-left:10px;" CssClass="text-danger" Visible="False" AutoPostBack="true">Логин или пароль введены не верно</asp:Label>
                            </div>
                        </div>
                    </div>
                 <div style="padding-left:120px;" class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Войти" ID="Unnamed4" CssClass="btn btn-default" OnClick="Unnamed4_Click" />
                    </div>
                </div>
                </div>
          </div>
    </div>
</asp:Content>
