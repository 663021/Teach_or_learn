<%@ Page Title="" Language="C#" MasterPageFile="~/Main_page_past.Master" AutoEventWireup="true" Async="true" CodeBehind="Que_user_page.aspx.cs" Inherits="TEACH_OR_LEARN.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
    <div class="form-horizontal">
            <div class="row">
                <div class="col-md-3">
                    <div class="jumbotron">
                         <asp:Button style="margin-left: 40px" runat="server" Text="Назад" ID="Button1" CssClass="btn btn-default" OnClick="Unnamed4_Click" />
                     </div>
                </div>
                <div class="col-md-9">
                    <div class="jumbotron">
                        <div class="col-md-offset-3">
                            <h3 style="padding-left: 160px" id="H2" runat="server">Hello world!</h3>
                            <div style="margin-right: 140px; text-align: justify" class="form-group">
                                <asp:Label runat="server" ID="Label5" CssClass="control-label">Задание: Написать прорамму для вывод сообщения "hello world!</asp:Label>     
                            </div>  
                        </div>  
                    </div>
                    <div style="color: antiquewhite; background-color: #cef3c0;" class="jumbotron">
                        <div class="col-md-offset-3">
                            <div class="form-group">
                                <asp:Button style="margin-left: 140px; margin-top: 10px" runat="server" Text="Скачать задание" ID="Unnamed4" CssClass="btn btn-default" />
                            </div>  
                        </div>  
                    </div>
                </div>
            </div> 
    </div>
</asp:Content>
