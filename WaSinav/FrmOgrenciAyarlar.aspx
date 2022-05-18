<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmOgrenciAyarlar.aspx.cs" Inherits="WaSinav.FrmOgrenciAyarlar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 114px;
        }
        .auto-style2 {
            width: 344px;
        }
        .auto-style4 {
            width: 776px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 776px;
        }
        .auto-style7 {
            width: 114px;
            height: 30px;
        }
        .auto-style8 {
            width: 344px;
            height: 30px;
        }
        .auto-style9 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
        <h4>SINAV UYGULAMASI ÖĞRENCİ SAYFASI</h4>
    </div>
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
              Ayarlar</div>
          <div>
              <table style="width: 100%;">
                
                   <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>


              </table>
          </div>
            <div>
                Bir Sorunun Çıkma Aralığı</div>
        <div>
             <table style="width: 100%;">
                
                   <tr>
                    <td class="auto-style4">
                        </td>
                    <td class="auto-style5"></td>
                </tr>
                   <tr>
                    <td class="auto-style6">
                        Daha önce hiç ayar yapmadıysanız varsayılan değerleri görmektesiniz.</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

              </table>
          </div>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style7">1. Tarih</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtTarih1" runat="server">1</asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="gün"></asp:Label>
                    </td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style1">2. Tarih</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTarih2" runat="server">7</asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="gün"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">3. Tarih</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTarih3" runat="server">30</asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="gün"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="auto-style1">4. Tarih</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTarih4" runat="server">90</asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="gün"></asp:Label>
                     </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">5. Tarih</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTarih5" runat="server">180</asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Text="gün"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">6. Tarih</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTarih6" runat="server">365</asp:TextBox>
                        <asp:Label ID="Label6" runat="server" Text="gün"></asp:Label>
                    &nbsp;sonra çıksın.</td>
                    <td>&nbsp;</td>
                </tr>

                   <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                   <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="Kaydet" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hideAyarId" runat="server" />
                       </td>
                </tr>
                  <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
                      </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
       
    </form>
</body>
</html>
