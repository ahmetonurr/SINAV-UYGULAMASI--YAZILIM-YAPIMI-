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
    public partial class DefaultOgrenci : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClLoginInfo.InKullaniciId == 0)
            {
                ClLoginInfo.InOgrenciId = 0;
                Response.Redirect("FrmGiris.aspx");
            }

            if (!IsPostBack)
            {
                FnListele();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSinav.aspx");
        }

        private void FnListele()
        {
            SqlCommand comm;
            SqlDataReader reader;
            comm = new SqlCommand("SELECT * FROM TbSinav WHERE InOgrenciId = " + ClLoginInfo.InOgrenciId.ToString() + " ORDER BY InSinavId DESC", ClLoginInfo.baglanti);
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