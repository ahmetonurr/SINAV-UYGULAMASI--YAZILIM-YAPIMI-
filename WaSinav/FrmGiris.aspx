<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGiris.aspx.cs" Inherits="WaSinav.FrmGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>

                    <td><asp:Label ID="Label1" runat="server" Text="Kullanıcı Tipi"></asp:Label></td><td>
                    <asp:DropDownList ID="cmbKullaniciTipi" runat="server" Width="200px">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>

                    <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Kullanıcı Adı"></asp:Label></td><td class="auto-style2">
                    <asp:TextBox ID="txtKullanici" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td><asp:Label ID="Label3" runat="server" Text="Şifre"></asp:Label></td><td>
                    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                 <tr>

                    <td class="auto-style1"></td><td class="auto-style1">
                     <asp:Button ID="btnGiris" runat="server" Text="Giriş" OnClick="btnGiris_Click" />
                     <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td><td>
                    <asp:LinkButton ID="lnkSifremiUnuttum" runat="server" OnClick="lnkSifremiUnuttum_Click">Şifremi Unuttum</asp:LinkButton>
                    </td>
                </tr>
                <tr><td></td><td></td></tr>
                <tr>
                    <td></td><td><div runat="server" id="divSifre" visible="false"><table><tr>

                        <td>
                        <asp:Label ID="lblEposta" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    </td><td>
                        <asp:TextBox ID="txtKullaniciAdiSifremiUnuttum" runat="server" Width="186px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblEposta0" runat="server" Text="E-posta Adresi"></asp:Label>
                     </td><td>
                        <asp:TextBox ID="txtEposta" runat="server" Width="186px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEposta1" runat="server" Text="Ad Soyad"></asp:Label>
                    </td><td>
                        <asp:TextBox ID="txtAdSoyad" runat="server" Width="186px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEposta2" runat="server" Text="Yeni Şifre"></asp:Label>
                    </td><td>
                        <asp:TextBox ID="txtYeniSifre" runat="server" Width="186px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEposta3" runat="server" Text="Yeni Şifre Tekrar"></asp:Label>
                    </td><td>
                        <asp:TextBox ID="txtYeniSifre0" runat="server" Width="186px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td><td>
                         <asp:Button ID="btnSifreGuncelle" runat="server" OnClick="btnGonder_Click" Text="Şifreyi Güncelle" />
                    </td>
                </tr>
               </tr></table></div></td></tr>
                    
            </table>
        </div>
        
    </form>
</body>
</html>
