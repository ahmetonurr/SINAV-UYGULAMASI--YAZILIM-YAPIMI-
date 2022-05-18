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
    public partial class FrmOgrenciAyarlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClLoginInfo.InKullaniciId == 0)
            {
                Response.Redirect("FrmGiris.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                        ClLoginInfo.baglanti.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TbOgrenciAyar WHERE InOgrenciId = " + ClLoginInfo.InOgrenciId.ToString(), ClLoginInfo.baglanti);
                    DataTable dtAyar = new DataTable();
                    da.Fill(dtAyar);

                    if (dtAyar != null)
                    {
                        if (dtAyar.Rows.Count > 0)
                        {
                            hideAyarId.Value = dtAyar.Rows[0]["InOgrenciAyarId"].ToString();
                            txtTarih1.Text = dtAyar.Rows[0]["InTarih1Gun"].ToString();
                            txtTarih2.Text = dtAyar.Rows[0]["InTarih2Gun"].ToString();
                            txtTarih3.Text = dtAyar.Rows[0]["InTarih3Gun"].ToString();
                            txtTarih4.Text = dtAyar.Rows[0]["InTarih4Gun"].ToString();
                            txtTarih5.Text = dtAyar.Rows[0]["InTarih5Gun"].ToString();
                            txtTarih6.Text = dtAyar.Rows[0]["InTarih6Gun"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Bir hata oluştu" + ex.Message);
                }
                finally
                {
                    ClLoginInfo.baglanti.Close();
                }
            }//if

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                {
                    ClLoginInfo.baglanti.Open();
                }

                int InAyarId = 0;
                string kayit = string.Empty;

                if (hideAyarId.Value.Length > 0)
                {
                    InAyarId = Convert.ToInt32(hideAyarId.Value);
                }

                if (InAyarId == 0)
                {
                    kayit = "INSERT INTO TbOgrenciAyar(InOgrenciId,InTarih1Gun,InTarih2Gun,InTarih3Gun,InTarih4Gun, InTarih5Gun, InTarih6Gun) VALUES (@InOgrenciId,@InTarih1Gun,@InTarih2Gun,@InTarih3Gun,@InTarih4Gun,@InTarih5Gun, @InTarih6Gun)";
                    SqlCommand komut1 = new SqlCommand(kayit, ClLoginInfo.baglanti);

                    komut1.Parameters.AddWithValue("@InOgrenciId", ClLoginInfo.InOgrenciId);
                    komut1.Parameters.AddWithValue("@InTarih1Gun", Convert.ToInt32(txtTarih1.Text.Trim()));
                    komut1.Parameters.AddWithValue("@InTarih2Gun", Convert.ToInt32(txtTarih2.Text.Trim()));
                    komut1.Parameters.AddWithValue("@InTarih3Gun", Convert.ToInt32(txtTarih3.Text.Trim()));
                    komut1.Parameters.AddWithValue("@InTarih4Gun", Convert.ToInt32(txtTarih4.Text.Trim()));
                    komut1.Parameters.AddWithValue("@InTarih5Gun", Convert.ToInt32(txtTarih5.Text.Trim()));
                    komut1.Parameters.AddWithValue("@InTarih6Gun", Convert.ToInt32(txtTarih6.Text.Trim()));

                    komut1.ExecuteNonQuery();
                    komut1.Dispose();
                }
                else
                {
                    kayit = "UPDATE TbOgrenciAyar SET InTarih1Gun=@InTarih1Gun,InTarih2Gun= @InTarih2Gun,InTarih3Gun = @InTarih3Gun,InTarih4Gun = @InTarih4Gun,InTarih5Gun = @InTarih5Gun, InTarih6Gun = @InTarih6Gun  WHERE InOgrenciAyarId = @InOgrenciAyarId";
                    SqlCommand komut2 = new SqlCommand(kayit, ClLoginInfo.baglanti);

                    komut2.Parameters.AddWithValue("@InKullaniciId", InAyarId);
                    komut2.Parameters.AddWithValue("@InTarih1Gun", Convert.ToInt32(txtTarih1.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InTarih2Gun", Convert.ToInt32(txtTarih2.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InTarih3Gun", Convert.ToInt32(txtTarih3.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InTarih4Gun", Convert.ToInt32(txtTarih4.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InTarih5Gun", Convert.ToInt32(txtTarih5.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InTarih6Gun", Convert.ToInt32(txtTarih6.Text.Trim()));
                    komut2.Parameters.AddWithValue("@InOgrenciAyarId", InAyarId);

                    komut2.ExecuteNonQuery();
                    komut2.Dispose();
                }

                lblMsj.Text = "Kayıt işlemi başarıyla gerçekleşti.";
            }
            catch (Exception ex)
            {
                lblMsj.Text = "Hata oluştu: " + ex.Message;
            }
            finally
            {
                ClLoginInfo.baglanti.Close();
            }
        }
    }
}