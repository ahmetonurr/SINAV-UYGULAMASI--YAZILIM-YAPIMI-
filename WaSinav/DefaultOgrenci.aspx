<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultOgrenci.aspx.cs" Inherits="WaSinav.DefaultOgrenci" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
        <h4>SINAV UYGULAMASI ÖĞRENCİ SAYFASI</h4>
    </div>
        <div>
        <asp:Menu ID="Menu1" runat="server">
           <Items>
                <asp:MenuItem NavigateUrl="DefaultOgrenci.aspx" Text="ANASAYFA" Value="ANASAYFA"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="DefaultOgrenci.aspx" Text="Sınav Sonuçları" Value="Sınav Sonuçları"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="FrmOgrenciAyarlar.aspx" Text="Ayarlar" Value="Ayarlar"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="FrmSinav.aspx" Text="Sınava Gir" Value="Sınava Gir"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="FrmGiris.aspx" Text="Çıkış" Value="Çıkış"></asp:MenuItem>
            </Items>
        </asp:Menu></div>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            Sınav Sonuçları</div>
          <div>
              <table> <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr> <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr></table>
          </div>
          <div>
              <asp:GridView ID="gvListe" runat="server">
              </asp:GridView>
          </div>
            <div>
          </div>
        <div>
          </div>
        <div></div>
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Sınava Gir</asp:LinkButton>
          </div>
        <div>
          </div>
    </form>
</body>
</html>
