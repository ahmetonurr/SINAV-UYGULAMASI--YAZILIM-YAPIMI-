<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSinav.aspx.cs" Inherits="WaSinav.Sinav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 91px;
        }
        .auto-style2 {
            width: 91px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 91px;
            height: 89px;
        }
        .auto-style5 {
            height: 89px;
        }
        .auto-style6 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="jumbotron">
        <h4>&nbsp;</h4>
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
            <table class="auto-style6">
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
            Sınav </div>
          <div>
          </div>
          <div>
              <table style="width: 100%;" runat="server" id ="tblSoru">
                    <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                    <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                         
                        </td>
                      <td>&nbsp;</td>
                  </tr>
                    <tr>
                      <td class="auto-style4"></td>
                      <td class="auto-style5">
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Timer ID="Timer1"  runat="server" OnTick="Timer1_Tick" Interval="1000">

        </asp:Timer>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

            <ContentTemplate>

                

                <asp:Label ID="lblTimer" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>

                

            </ContentTemplate>

        <Triggers>

        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick"/>

        </Triggers>

       

        </asp:UpdatePanel>
                        </td>
                      <td class="auto-style5"></td>
                  </tr>
                    <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                  <tr>
                      <td class="auto-style1"><asp:Label ID="lblSoruNo" runat="server"></asp:Label>
                          .</td>
                      <td>
                          <asp:Label ID="lblSoru" runat="server"></asp:Label>
                      </td>
                      <td>&nbsp;</td>
                  </tr>
                  <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          <asp:Image ID="imgSoru" runat="server" ImageUrl="C:\C_4\Serap-Projeler\WaSinav\WaSinav\App_Data\16.png" />
                       </td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr> <tr>
                      <td class="auto-style2"></td>
                      <td class="auto-style3">
                          </td>
                      <td class="auto-style3"></td>
                  </tr>
                  <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          <asp:Label ID="Label2" runat="server" Text="A."></asp:Label>
                      &nbsp;<asp:RadioButton ID="rbA" runat="server" ValidationGroup="vgSoru" GroupName="gnSoru" />
                          <asp:Label ID="lblA" runat="server"></asp:Label>
                      </td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                           B.  &nbsp;<asp:RadioButton ID="rbB" runat="server" ValidationGroup="vgSoru" GroupName="gnSoru" />
                           <asp:Label ID="lblB" runat="server"></asp:Label>
                       </td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style2"></td>
                      <td class="auto-style3">
                          C.  &nbsp;<asp:RadioButton ID="rbC" runat="server" ValidationGroup="vgSoru" GroupName="gnSoru" />
                          <asp:Label ID="lblC" runat="server"></asp:Label>
                       </td>
                      <td class="auto-style3"></td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          D.  &nbsp;<asp:RadioButton ID="rbD" runat="server" ValidationGroup="vgSoru" GroupName="gnSoru" />
                          <asp:Label ID="lblD" runat="server"></asp:Label>
                       </td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          <asp:Button ID="btnIleri" runat="server" OnClick="btnIleri_Click" Text="Sonraki Soru" />
                       </td>
                      <td>&nbsp;</td>
                  </tr>
                   <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          <asp:HiddenField ID="hideInSoruId" runat="server" />
                          <asp:HiddenField ID="hideInSinavId" runat="server" />
                          <asp:HiddenField ID="hideDogruCevap" runat="server" />
                       </td>
                      <td>&nbsp;</td>
                  </tr>
              </table>
              
          </div>
            <div>
          </div>
        <div>
            <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
          </div>
        <div>
          </div>
        <div>
          </div>
    </form>
</body>
</html>
