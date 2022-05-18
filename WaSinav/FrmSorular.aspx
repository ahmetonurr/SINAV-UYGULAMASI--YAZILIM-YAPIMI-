<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="FrmSorular.aspx.cs" Inherits="WaSinav.FrmSorular" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       
    </div>

        <div>
            Soru Listesi</div>

         <div>
            </div>
         <div>
             <asp:GridView ID="gvListe" runat="server" DataKeyNames="InSoruId" OnRowDeleting="gvListe_RowDeleting">
                 <Columns>
                        <asp:CommandField ShowDeleteButton="true" />

                </Columns>
             </asp:GridView>
        </div>
         <div>
             Soru Ekle</div>

        <div><table>
            <tr><td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Soru"></asp:Label>
                </td><td class="auto-style1">
                    <asp:TextBox ID="txtSoru" runat="server" Height="54px" Width="467px"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">Soru Resmi</td><td class="auto-style1">
                <asp:FileUpload ID="fileSoru" runat="server" Width="478px" />
                </td></tr>
            <tr><td class="auto-style2">A Şıkkı</td><td class="auto-style1">
                <asp:TextBox ID="txtA" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">B Şıkkı</td><td class="auto-style1">
                <asp:TextBox ID="txtB" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">C Şıkkı</td><td class="auto-style1">
                <asp:TextBox ID="txtC" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">D Şıkkı</td><td class="auto-style1">
                <asp:TextBox ID="txtD" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">Doğru Cevap</td><td class="auto-style1">
                <asp:TextBox ID="txtDogruCevap" runat="server"></asp:TextBox>
                </td></tr>
              <tr><td class="auto-style2">&nbsp;</td><td class="auto-style1">
                  <asp:Button ID="btnYeni" runat="server" Text="Yeni" OnClick="btnYeni_Click" />
                  <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                  </td></tr>
              <tr><td class="auto-style2">&nbsp;</td><td class="auto-style1">
                  <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                  <asp:HiddenField ID="hideId" runat="server" />
                  </td></tr>
             </table>
            </div>

    <</asp:Content>