using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WaSinav
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClLoginInfo.InKullaniciId == 0)
            {
                Response.Redirect("FrmGiris.aspx");
            }

            if (!IsPostBack)
            {
                tblOgrenci.Visible = false;

                FnKullaniciListele();
                if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();

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
        private void FnKullaniciListele()
        {
            SqlCommand comm;
            SqlDataReader reader;
            comm = new SqlCommand("SELECT * FROM VwKullanici ORDER BY InKullaniciId DESC", ClLoginInfo.baglanti);
            try
            {
                if(ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();

                reader = comm.ExecuteReader();
                gvListe.DataSource = reader;
                gvListe.DataBind();
                reader.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Bir hata oluştu" + ex.Message);
            }
            finally
            {
                ClLoginInfo.baglanti.Close();
            }
        }

        protected void btnYeni_Click(object sender, EventArgs e)
        {
            txtAdSoyad.Text = txtKullaniciAd.Text = txtEposta.Text = txtSifre.Text = string.Empty;
            hideId.Value = "0";
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
            {
                ClLoginInfo.baglanti.Open();
            }

            int InKullaniciId = 0;
            string kayit = string.Empty;

            if (hideId.Value.Length > 0)
            {
                InKullaniciId = Convert.ToInt32(hideId.Value);
            }

            if (InKullaniciId == 0)
            {
                kayit = "INSERT INTO TbKullanici(InKullaniciTipi,StKullaniciAd,StAdSoyad,StEposta,StSifre) VALUES (@InKullaniciTipi,@StKullaniciAd,@StAdSoyad,@StEposta,@StSifre)";
                SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);

                komut.Parameters.AddWithValue("@InKullaniciTipi", cmbKullaniciTipi.SelectedValue);
                komut.Parameters.AddWithValue("@StKullaniciAd", txtKullaniciAd.Text.Trim());
                komut.Parameters.AddWithValue("@StAdSoyad", txtAdSoyad.Text.Trim());
                komut.Parameters.AddWithValue("@StEposta", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@StSifre", txtSifre.Text.Trim());
                komut.Parameters.Add("@prmInKullaniciId", SqlDbType.Int).Direction = ParameterDirection.Output;

                komut.ExecuteScalar();
                hideId.Value = komut.Parameters["@prmInKullaniciId"].Value.ToString();
            }
            else
            {
                hideId.Value = InKullaniciId.ToString();
                kayit = "UPDATE TbKullanici SET InKullaniciTipi=@InKullaniciTipi,StKullaniciAd= @StKullaniciAd,StAdSoyad = @StAdSoyad,StEposta = @StEposta,StSifre = @StSifre WHERE InKullaniciId = @InKullaniciId";
                SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);

                komut.Parameters.AddWithValue("@InKullaniciId", InKullaniciId.ToString());
                komut.Parameters.AddWithValue("@InKullaniciTipi", cmbKullaniciTipi.SelectedValue);
                komut.Parameters.AddWithValue("@StKullaniciAd", txtKullaniciAd.Text.Trim());
                komut.Parameters.AddWithValue("@StAdSoyad", txtAdSoyad.Text.Trim());
                komut.Parameters.AddWithValue("@StEposta", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@StSifre", txtSifre.Text.Trim());

                komut.ExecuteNonQuery();
            }

            if (cmbKullaniciTipi.SelectedValue == "3") //Öğrenci
            {
                kayit = "INSERT INTO TbOgrenci(InKullaniciId,StSinifi,StOgrenciNo) VALUES (@InKullaniciId,@StSinifi,@StOgrenciNo)";
                SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);

                komut.Parameters.AddWithValue("@InKullaniciId", hideId.Value);
                komut.Parameters.AddWithValue("@StSinifi", txtOgrenciSinifi.Text.Trim());
                komut.Parameters.AddWithValue("@StOgrenciNo", txtOgrenciNo.Text.Trim());

                komut.ExecuteNonQuery();
            }

            ClLoginInfo.baglanti.Close();

            lblMsj.Text = "Kayıt işlemi başarıyla gerçekleşti.";

            FnKullaniciListele();

        }

        protected void gvListe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int InKullaniciId = Convert.ToInt32(gvListe.DataKeys[e.RowIndex].Value.ToString());

            try
            {
                if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete from TbKullanici where InKullaniciId=" + InKullaniciId.ToString(), ClLoginInfo.baglanti);

                komut.ExecuteNonQuery();
                komut.Dispose();
                ClLoginInfo.baglanti.Close();
                lblMsj.Text = "Kayıt başarıyla silindi.";
                FnKullaniciListele();
            }
            catch (Exception ex)
            {
                lblMsj.Text = "Hata oluştu: + " + ex.Message;
            }
            
        }

        protected void gvListe_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
        }

        protected void gvListe_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvListe.EditIndex = e.NewEditIndex;
            FnKullaniciListele();

            try
            {
                int InKullaniciId = Convert.ToInt32(gvListe.DataKeys[e.NewEditIndex].Value.ToString());
                hideId.Value = InKullaniciId.ToString();

                if (ClLoginInfo.baglanti.State == ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();

                string cmdText = "SELECT * FROM TbKullanici WHERE InKullaniciId = " + InKullaniciId.ToString();
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, ClLoginInfo.baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmbKullaniciTipi.SelectedValue = dt.Rows[0]["InKullaniciTipi"].ToString();
                    txtAdSoyad.Text = dt.Rows[0]["StAdSoyad"].ToString();
                    txtEposta.Text = dt.Rows[0]["StEposta"].ToString();
                    txtKullaniciAd.Text = dt.Rows[0]["StKullaniciAd"].ToString();
                    txtSifre.Text = dt.Rows[0]["StSifre"].ToString();
                }
                ClLoginInfo.baglanti.Close();

                FnKullaniciListele();
            }
            catch (Exception ex)
            {
                lblMsj.Text = "Hata oluştu: " + ex.Message;
            }

          
        }

        protected void cmbKullaniciTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKullaniciTipi.SelectedValue == "3") //Öğrenci
            {
                tblOgrenci.Visible = true;
            }
            else
            {
                tblOgrenci.Visible = false;
            }
        }
    }
}