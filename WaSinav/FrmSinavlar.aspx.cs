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
    public partial class FrmSinavlar : System.Web.UI.Page
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
            comm = new SqlCommand("SELECT k.StAdSoyad, o.StSinifi, o.StOgrenciNo, s.InSinavId, s.DtTarih, s.InDogruSayisi, s.InYanlisSayisi, s.InBossayisi, s.DePuan FROM TbSinav s LEFT JOIN TbOgrenci o ON o.InOgrenciId = s.InOgrenciId LEFT JOIN Tbkullanici k ON k.InKullaniciId = o.InKullaniciId ORDER BY InSinavId DESC", ClLoginInfo.baglanti);
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
    }
}