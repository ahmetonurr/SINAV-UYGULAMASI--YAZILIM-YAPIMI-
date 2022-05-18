using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WaSinav
{
    public partial class FrmSorular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClLoginInfo.InKullaniciId == 0)
            {
                Response.Redirect("FrmGiris.aspx");
            }

            if (!IsPostBack)
            {
                FnListele();
            }
        }
        private void FnListele()
        {
            SqlCommand comm;
            SqlDataReader reader;
            comm = new SqlCommand("SELECT * FROM TbSoru ORDER BY InSoruId DESC", ClLoginInfo.baglanti);
            try
            {
                if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();

                reader = comm.ExecuteReader();
                gvListe.DataSource = reader;
                gvListe.DataBind();
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Bir hata oluştu" + ex.Message);
            }
            finally
            {
                ClLoginInfo.baglanti.Close();
            }
        }

        protected void gvListe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int InSoruId = Convert.ToInt32(gvListe.DataKeys[e.RowIndex].Value.ToString());

            try
            {
                if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete from TbSoru where InSoruId=" + InSoruId.ToString(), ClLoginInfo.baglanti);

                komut.ExecuteNonQuery();
                komut.Dispose();
                ClLoginInfo.baglanti.Close();
                lblMsj.Text = "Kayıt başarıyla silindi.";
                FnListele();
            }
            catch (Exception ex)
            {
                lblMsj.Text = "Hata oluştu: + " + ex.Message;
            }
        }

        protected void btnYeni_Click(object sender, EventArgs e)
        {
            txtA.Text = txtB.Text = txtC.Text = txtD.Text = txtSoru.Text = txtDogruCevap.Text = string.Empty;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
            {
                ClLoginInfo.baglanti.Open();
            }

            int InId = 0;
            string kayit = string.Empty;

            if (hideId.Value.Length > 0)
            {
                InId = Convert.ToInt32(hideId.Value);
            }

            if (InId == 0)
            {
                kayit = "INSERT INTO TbSoru(StSoru,StASikki,StBSikki,StCSikki,StDSikki, StDogruCevap, StResimYolu) VALUES (@StSoru,@StASikki,@StBSikki,@StCSikki,@StDSikki, @StDogruCevap, @StResimYolu)";

                SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);

                komut.Parameters.AddWithValue("@StSoru", txtSoru.Text.Trim());
                komut.Parameters.AddWithValue("@StASikki", txtA.Text.Trim());
                komut.Parameters.AddWithValue("@StBSikki", txtB.Text.Trim());
                komut.Parameters.AddWithValue("@StCSikki", txtC.Text.Trim());
                komut.Parameters.AddWithValue("@StDSikki", txtD.Text.Trim());
                komut.Parameters.AddWithValue("@StDogruCevap", txtDogruCevap.Text.Trim());
                komut.Parameters.AddWithValue("@StResimYolu", fileSoru.FileName.Trim());
                
                komut.Parameters.Add("@prmId", SqlDbType.Int).Direction = ParameterDirection.Output;

                komut.ExecuteScalar();
                hideId.Value = komut.Parameters["@prmId"].Value.ToString();

                if (fileSoru.HasFile)
                {

                    string uzanti = System.IO.Path.GetExtension(fileSoru.FileName).ToLower();
                    if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".bmp" || uzanti == ".gif")
                    {
                        fileSoru.PostedFile.SaveAs(Server.MapPath("SoruResimleri/") + fileSoru.FileName);

                        Session["resimadi"] = fileSoru.FileName + uzanti;
                    }
                    else
                    {
                        lblMsj.Text = "Resim formatı yanlış .jpg veya .png olmalıdır.";
                    }
                }
            }
            //else
            //{
            //    kayit = "UPDATE TbKullanici SET InKullaniciTipi=@InKullaniciTipi,StKullaniciAd= @StKullaniciAd,StAdSoyad = @StAdSoyad,StEposta = @StEposta,StSifre = @StSifre WHERE InKullaniciId = @InKullaniciId";
            //    SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);

            //    komut.Parameters.AddWithValue("@InKullaniciId", InKullaniciId.ToString());
            //    komut.Parameters.AddWithValue("@InKullaniciTipi", cmbKullaniciTipi.SelectedValue);
            //    komut.Parameters.AddWithValue("@StKullaniciAd", txtKullaniciAd.Text.Trim());
            //    komut.Parameters.AddWithValue("@StAdSoyad", txtAdSoyad.Text.Trim());
            //    komut.Parameters.AddWithValue("@StEposta", txtEposta.Text.Trim());
            //    komut.Parameters.AddWithValue("@StSifre", txtSifre.Text.Trim());


            //    komut.ExecuteNonQuery();
            //}

            ClLoginInfo.baglanti.Close();

            lblMsj.Text = "Kayıt işlemi başarıyla gerçekleşti.";

            FnListele();

        }
    }
}