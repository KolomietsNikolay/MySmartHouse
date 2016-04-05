<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Smart_House.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart House</title>
    <link href="~/Content/style.css" rel="stylesheet">
    
</head>
<body style="background-color:indigo">
    <form id="form1" runat="server" >
     
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
        <div  style="background-image:url(/Content/reshenia.png)">
            <ul class="menu">
                
                <li>
                    <p4>Добавить простое устройство</p4>
                    <ul class="submenu">
                        <li>
                            <asp:Button ID="Button1" runat="server" Text="Добавить Дверь" /></li>
                        <li>
                            <asp:Button ID="Button2" runat="server" Text="Добавить Лампочку" /></li>
                    </ul>
                </li>

                <li>
                    <p4>Добавить электроприпор в доме</p4>
                    <ul class="submenu">
                        <li>
                            <asp:Button ID="Button4" runat="server" Text="Добавить Телевизор" /></li>
                        <li>
                            <asp:Button ID="Button5" runat="server" Text="Добавить Холодильник" /></li>
                        
                    </ul>
                </li>
            </ul>
            <asp:PlaceHolder ID="Rezult" runat="server"></asp:PlaceHolder>
            <br />
            <div class="centr">
                <asp:Panel ID="deviceHolder" runat="server"></asp:Panel>
                            </div>
                        <br />
                
                        
                   
          </div>
        </div>
                </ContentTemplate>
                </asp:UpdatePanel> 
    </form>
</body>
</html>
