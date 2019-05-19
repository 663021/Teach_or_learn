<%--  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_page.Master" Async="true" AutoEventWireup="true" CodeBehind="Teacher_kurse_edit.aspx.cs" Inherits="TEACH_OR_LEARN.Teacher_kurse_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_container" runat="server">
<style>
.control-input {
    margin-bottom: 10px;
    margin-left: 25px;
    line-height: normal;
    width: 350px;
}
.control-label {
    margin-bottom: 10px;
}
</style>
    <div class="container body-content">
    <div class="row">
        <div class="col-md-6">  
            <div class="jumbotron">
                    <h3 style="padding-left: 170px" id="for_h3_1" runat="server">О КУРСЕ
                    </h3>
                    <div class="form-group">
                        <asp:Label runat="server" style="padding-left: 12%" ID="Label1" CssClass="control-label">Наименование: <asp:TextBox runat="server" ID="TextBox1" Width="220" ></asp:TextBox></asp:Label>   
                    </div>               
                <div class="form-group">
                        <asp:Label runat="server" style="padding-left: 15%" ID="Label2" CssClass="control-label">Направление: <asp:TextBox runat="server" ID="TextBox2" Width="220"></asp:TextBox></asp:Label>                  
                    </div>
                <div class="form-group">
                        <asp:Label runat="server" ID="Label6" CssClass="control-label">Продолжительность: <asp:TextBox runat="server" ID="TextBox3" Width="220"></asp:TextBox></asp:Label>                  
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" style="padding-left: 15%" ID="Label3" CssClass="control-label">Информация: <asp:TextBox runat="server" ID="TextBox4" Rows="3" Width="220px" TextMode="MultiLine" Style="line-height: normal;"></asp:TextBox></asp:Label>    
                    </div>
                 <div class="form-group">
                        <asp:Label runat="server" ID="Label4" style="padding-left: 20%" CssClass="control-label">Сложность: <asp:TextBox runat="server" ID="TextBox5" Width="220"></asp:TextBox></asp:Label>                   
                 </div>
                 <div style="padding-top: 10px" class="form-group">
                    <asp:Button style="margin: 0px 20px 0px 200px" runat="server" Text="Обновить" ID="Unname4" CssClass="btn btn-default" />
                    <asp:Button runat="server" Text="Удалить" ID="Button1" CssClass="btn btn-default" OnClick="DelClick" />
                </div>    
            </div>  
        </div>
        <div class="col-md-6">
                <h3 style="padding-left: 210px; padding-top: 70px" id="H1" runat="server">ЗАДАНИЯ КУРСА</h3>

            
                <asp:Panel runat="server" ID="Panel2" CssClass="control-label">
                </asp:Panel>

            <div class="jumbotron" runat="server" id="addquest"  visible="false">
                <div class="wrapper" style="display: flex;">
                    <div style="padding-top: 10px; display:flex; flex-direction: column;" class="form-group">
                        <asp:Label runat="server" ID="Label5" CssClass="control-label" Style="padding-top: 10px;">Тема:</asp:Label>      
                        <asp:Label runat="server" ID="Label7" CssClass="control-label">Задание:</asp:Label>
                        <asp:Label runat="server" ID="Label8" CssClass="control-label">Файл: </asp:Label>
                    </div>
                    <div style="padding-top: 10px; display:flex; flex-direction: column;" class="form-group">
                        <asp:TextBox runat="server" ID="TextBox6" CssClass="control-input" TextMode="MultiLine"></asp:TextBox>
                        <asp:TextBox runat="server" ID="TextBox7" CssClass="control-input" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <asp:TextBox runat="server" ID="TextBox8" CssClass="control-input" TextMode="MultiLine"></asp:TextBox>
                        <input style="font-size: medium;" class="control-input" type="file" id="File2" name="File2" accept=".docx, .doc" runat="server" />
                    </div>
                </div>
                <asp:Button style="margin: 0px 20px 0px 180px" runat="server" Text="Добавить" ID="Button2" CssClass="btn btn-default" OnClick="AddQuest"/>
                </div>

            <div class="jumbotron" runat="server" visible="false" id="Div1">
                <div class="wrapper" style="display: flex;">
                    <div style="padding-top: 10px; display:flex; flex-direction: column;" class="form-group">
                        <asp:Label runat="server" ID="Label9" CssClass="control-label" Style="padding-top: 10px;">Тема:</asp:Label>      
                        <asp:Label runat="server" ID="Label10" CssClass="control-label">Задание:</asp:Label>
                        <asp:Label runat="server" ID="Label11" CssClass="control-label">Файл: </asp:Label>
                    </div>
                    <div style="padding-top: 10px; display:flex; flex-direction: column;" class="form-group">
                        <asp:TextBox runat="server" ID="TextBox9" CssClass="control-input" TextMode="MultiLine"></asp:TextBox>
                        <asp:TextBox runat="server" ID="TextBox10" CssClass="control-input" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <asp:TextBox runat="server" ID="TextBox11" CssClass="control-input" TextMode="MultiLine"></asp:TextBox>
                        <input style="font-size: medium;" class="control-input" type="file" id="File1" name="File1" accept=".docx, .doc" runat="server" />
                    </div>
                </div>
                <asp:Button style="margin: 0px 20px 0px 180px;" runat="server" Text="Обновить" ID="Button3" CssClass="btn btn-default" OnClick="UpdateQuest"/>
                <asp:Button style="margin: 0px 20px 0px 0px;" runat="server" Text="Удалить" ID="Button4" CssClass="btn btn-default" Onclick="DelClick_1" />
                </div>
          </div>
        </div>
    </div>
        <hr />
        </div>
</asp:Content>
