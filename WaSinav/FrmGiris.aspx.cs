using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace WaSinav
{
    public partial class FrmGiris : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Çıkış yapan kullanıcı bu forma yönlendiriliyor.
            ClLoginInfo.InOgrenciId = 0;
            ClLoginInfo.InKullaniciId = 0;
            ClLoginInfo.InKullaniciTipi = 0;

            if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                ClLoginInfo.baglanti.Open();

            if (!IsPostBack)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From TbKullaniciTipi", ClLoginInfo.baglanti);
                DataTable dtKullaniciTipi = new DataTable();
                da.Fill(dtKullaniciTipi);

                cmbKullaniciTipi.DataTextField = "StKullaniciTipi";
                cmbKullaniciTipi.DataValueField = "InKullaniciTipiId";
                cmbKullaniciTipi.DataSource = dtKullaniciTipi;
                cmbKullaniciTipi.DataBind();
                cmbKullaniciTipi.SelectedIndex = -1;

                ClLoginInfo.baglanti.Close();
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text.Trim().Length == 0 || txtSifre.Text.Trim().Length == 0 || cmbKullaniciTipi.SelectedIndex == -1)
                lblMsj.Text = "Kullanıcı tipi, Kullanıcı adı ve Şifre giriniz!";
            else
            {
                try
                {
                    if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                        ClLoginInfo.baglanti.Open();
                    string cmdText = "SELECT * FROM TbKullanici WHERE StKullaniciAd = '" + txtKullanici.Text.Trim()
                        + "' And StSifre = '" + txtSifre.Text.Trim() + "' And InKullaniciTipi = " + cmbKullaniciTipi.SelectedValue.ToString();

                    SqlDataAdapter komut = new SqlDataAdapter(cmdText, ClLoginInfo.baglanti);
                    DataTable dt = new DataTable();
                    komut.Fill(dt);

                    if (dt.Rows.Count == 0)
                        lblMsj.Text = "Kullanıcı bilgileri hatalı!";
                    else
                    {
                        ClLoginInfo.InKullaniciId = Convert.ToInt32(dt.Rows[0]["InKullaniciId"]);
                        ClLoginInfo.InKullaniciTipi = Convert.ToInt32(cmbKullaniciTipi.SelectedValue);
                        if (ClLoginInfo.InKullaniciTipi == 1) //Admin
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else if (ClLoginInfo.InKullaniciTipi == 3)
                        {
                            //ÖğrenciId'yi alıyoruz.
                            SqlCommand komut2 = new SqlCommand("SELECT InOgrenciId FROM VwKullaniciOgrenci WHERE InKullaniciId=@InKullaniciId", ClLoginInfo.baglanti);
                            if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                                ClLoginInfo.baglanti.Open();
                            komut2.Parameters.AddWithValue("@InKullaniciId", ClLoginInfo.InKullaniciId);
                            ClLoginInfo.InOgrenciId = Convert.ToInt32(komut2.ExecuteScalar());
                            ClLoginInfo.baglanti.Close();
                            Response.Redirect("DefaultOgrenci.aspx");
                        }
                    }
                    ClLoginInfo.baglanti.Close();
                }
                catch (Exception ex)
                {
                    lblMsj.Text = ex.Message;
                }
            }
        }

        protected void lnkSifremiUnuttum_Click(object sender, EventArgs e)
        {
            divSifre.Visible = true;
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYeniSifre.Text.Trim() != txtYeniSifre0.Text.Trim())
                    lblMsj.Text = "Yeni şifreler birbiriyle uyuşmamaktadır!";
                else
                {

                    if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                        ClLoginInfo.baglanti.Open();
                    string cmdText = "SELECT * FROM TbKullanici WHERE StKullaniciAd = '" + txtKullaniciAdiSifremiUnuttum.Text.Trim()
                        + "' And StAdSoyad = '" + txtAdSoyad.Text.Trim() + "' And StEposta = '" + txtEposta.Text.Trim() + "'";

                    SqlDataAdapter komut = new SqlDataAdapter(cmdText, ClLoginInfo.baglanti);
                    DataTable dt = new DataTable();
                    komut.Fill(dt);
                    ClLoginInfo.baglanti.Close();

                    if (dt.Rows.Count == 0)
                        lblMsj.Text = "Böyle bir kullanıcı bulunamadı!";
                    else
                    {
                        int InKullaniciId =  Convert.ToInt32(dt.Rows[0]["InKullaniciId"]);
                        SqlCommand komut2 = new SqlCommand("UPDATE TbKullanici SET StSifre=@StSifre WHERE InKullaniciId=@InKullaniciId", ClLoginInfo.baglanti);
                        if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                            ClLoginInfo.baglanti.Open();
                        komut2.Parameters.AddWithValue("@InKullaniciId", InKullaniciId);
                        komut2.Parameters.AddWithValue("@StSifre", txtYeniSifre.Text.Trim());
                        komut2.ExecuteNonQuery();
                        lblMsj.Text = "Şifreniz güncellendi. Giriş yapabilirsiniz.";
                        ClLoginInfo.baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
    }
}