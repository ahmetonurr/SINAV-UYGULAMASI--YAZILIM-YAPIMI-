<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WaSinav._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div><br />
              <table>
                     <tr>
                    <td style="height: 20px; width: 185px;">&nbsp;</td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                </tr>
                     <tr>
                    <td style="height: 20px; width: 185px;">Kullanıcı Listesi</td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                </tr>
              <tr>
                    <td style="height: 20px; width: 185px;">&nbsp;</td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                </tr>

            <tr><td><asp:GridView ID="gvListe" runat="server" OnRowDeleting="gvListe_RowDeleting" DataKeyNames="InKullaniciId" OnRowEditing="gvListe_RowEditing" OnRowUpdating="gvListe_RowUpdating">
                <Columns>
                   <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" />

                </Columns>
            </asp:GridView></td> </tr>
                <tr><td>&nbsp;</td></tr>
            </table>
           
        </div>
        <div class="col-md-4">
            <table style="width:100%;">
                <tr>
                    <td style="height: 20px; width: 185px;"></td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td class="modal-sm" style="width: 185px">Kullanıcı Tipi:</td>
                    <td>
                        <asp:DropDownList ID="cmbKullaniciTipi" runat="server" Width="150px" OnSelectedIndexChanged="cmbKullaniciTipi_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="modal-sm" style="width: 185px">
                        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKullaniciAd" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="modal-sm" style="width: 185px">
                        <asp:Label ID="Label2" runat="server" Text="Adı Soyadı"></asp:Label>
                      </td>
                    <td>
                        <asp:TextBox ID="txtAdSoyad" runat="server"></asp:TextBox>
                      </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="modal-sm" style="width: 185px">
                        <asp:Label ID="Label3" runat="server" Text="E-posta:"></asp:Label>
                      </td>
                    <td>
                        <asp:TextBox ID="txtEposta" runat="server"></asp:TextBox>
                      </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="modal-sm" style="width: 185px">
                        <asp:Label ID="Label4" runat="server" Text="Şifre"></asp:Label>
                      </td>
                    <td>
                        <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
                      </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> &nbsp;</td>
                    <td>&nbsp;</td>
                </tr></table>
            <table id="tblOgrenci" runat="server">
                 <tr>
                    <td class="modal-sm" style="width: 185px">Öğrenci No:</td>
                    <td> 
                        <asp:TextBox ID="txtOgrenciNo" runat="server"></asp:TextBox>
                      </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">Öğrenci Sınıfı:</td>
                    <td> 
                        <asp:TextBox ID="txtOgrenciSinifi" runat="server"></asp:TextBox>
                      </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> &nbsp;</td>
                    <td>&nbsp;</td>
                </tr></table><table>
                 <tr>
                    <td class="modal-sm" style="width: 185px; height: 49px;"></td>
                    <td style="height: 49px">
                        <asp:Button ID="btnYeni" runat="server" OnClick="btnYeni_Click" Text="Yeni" />
                        <asp:Button ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="Kaydet" />
                        <asp:HiddenField ID="hideId" runat="server" />
                       
                     </td>
                    <td style="height: 49px"></td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="modal-sm" style="width: 185px">&nbsp;</td>
                    <td> &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
           
        </div>
        <div class="col-md-4">
           
        </div>
        <div class="col-md-4">
           
        </div>
    </div>

</asp:Content>
