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
    public partial class Sinav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClLoginInfo.InKullaniciId == 0)
            {
                Response.Redirect("FrmGiris.aspx");
            }

            if (!IsPostBack)
            {
                Timer1.Interval = 1000; 
                lblTimer.Text = "Kalan Süre: 10:00";
                Session["timeout"] = DateTime.Now.AddSeconds(600).ToString();
                FnListele();
            }
        }

        protected void btnIleri_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                {
                    ClLoginInfo.baglanti.Open();
                }

                //İlk Soru ise sınav tablosuna kayıt yap.
                int InSoruNo = 0;
                string kayit = string.Empty;

                if (lblSoruNo.Text.Length > 0)
                {
                    InSoruNo = Convert.ToInt32(lblSoruNo.Text);
                }

                if (InSoruNo == 1)
                {
                    kayit = "INSERT INTO TbSinav(InOgrenciId,DtTarih,InDogruSayisi,InYanlisSayisi,InBosSayisi,DePuan) VALUES (@InOgrenciId,@DtTarih,@InDogruSayisi,@InYanlisSayisi,@InBosSayisi,@DePuan); SELECT SCOPE_IDENTITY()";
                    SqlCommand komut = new SqlCommand(kayit, ClLoginInfo.baglanti);
                    komut.Parameters.AddWithValue("@InOgrenciId", ClLoginInfo.InOgrenciId);
                    komut.Parameters.AddWithValue("@DtTarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@InDogruSayisi", 0);
                    komut.Parameters.AddWithValue("@InYanlisSayisi", 0);
                    komut.Parameters.AddWithValue("@InBosSayisi", 0);
                    komut.Parameters.AddWithValue("@DePuan", 0);
                    //komut.Parameters.Add("@InSinavId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    hideInSinavId.Value = komut.ExecuteScalar().ToString();
                    //hideInSinavId.Value = komut.Parameters["@InSinavId"].Value.ToString();
                    komut.Dispose();
                }

                kayit = "INSERT INTO TbOgrenciCevap(InSinavId,InSoruId, StCevap,InDurumId) VALUES (@InSinavId,@InSoruId, @StCevap,@InDurumId)";

                SqlCommand komut2 = new SqlCommand(kayit, ClLoginInfo.baglanti);
                komut2.Parameters.AddWithValue("@InSinavId", Convert.ToInt32(hideInSinavId.Value));
                komut2.Parameters.AddWithValue("@InSoruId", Convert.ToInt32(hideInSoruId.Value));
                string StCevap = string.Empty;

                if (rbA.Checked)
                    StCevap = "A";
                else if (rbB.Checked)
                    StCevap = "B";
                else if (rbC.Checked)
                    StCevap = "C";
                else if (rbD.Checked)
                    StCevap = "D";
                else
                    StCevap = string.Empty;

                komut2.Parameters.AddWithValue("@StCevap", StCevap);

                //1.Doğru 2.Yanlış 3.Boş
                int InDurumId = 0;
                if (StCevap == hideDogruCevap.Value)
                    InDurumId = 1;
                else if (StCevap == string.Empty)
                    InDurumId = 3;
                else
                    InDurumId = 2;

                komut2.Parameters.AddWithValue("@InDurumId", InDurumId);
                komut2.ExecuteNonQuery();
                komut2.Dispose();

                if (InDurumId == 1) //6. kez doğru ise soru, soru havuzuna atılacak. TbOgrenciCevap tablosunda BoBilinen = 1 olarak güncellenmesi eyterli.
                {
                    try
                    {
                        //SpSoruHavuzu procedure'ü çalıştırılacak bunun için.
                        string StKomut = "SpSoruHavuzu";
                        SqlCommand komut3 = new SqlCommand(StKomut, ClLoginInfo.baglanti);
                        komut3.CommandType = CommandType.StoredProcedure;
                        komut3.Parameters.AddWithValue("@InOgrenciId", ClLoginInfo.InOgrenciId);
                        komut3.Parameters.AddWithValue("@InSoruId", Convert.ToInt32(hideInSoruId.Value));
                        komut3.ExecuteNonQuery();
                        komut3.Dispose();
                    }
                    catch (Exception ex)
                    {
                        lblMsj.Text = "Hata oluştu: SpSoruHavuzu" + ex.Message;
                    }
                }//if

                //Sınav bitecek
                if (InSoruNo == 10)
                {
                    tblSoru.Visible = false;
                    lblMsj.Text = "Sınavınız bitmiştir.";

                    kayit = "UPDATE TbSinav SET InDogruSayisi = (SELECT COUNT(*) FROM TbOgrenciCevap WHERE InDurumId = 1 AND InSinavId = " +  hideInSinavId.Value +
                        ") ,InYanlisSayisi = (SELECT COUNT(*) FROM TbOgrenciCevap WHERE InDurumId = 2 AND InSinavId = " + hideInSinavId.Value + 
                        " ) ,InBosSayisi = (SELECT COUNT(*) FROM TbOgrenciCevap WHERE InDurumId = 3 AND InSinavId = " + hideInSinavId.Value + 
                        ") WHERE InSinavId = " + hideInSinavId.Value;

                    SqlCommand komut3 = new SqlCommand(kayit, ClLoginInfo.baglanti);
                    komut3.ExecuteNonQuery();
                    komut3.Dispose();
                }
                //Session'dan sonraki sorunun bilgilerini doldur.
                DataTable dtSoru = (DataTable)Session["dtSoru"];
                if (dtSoru != null)
                {
                    int InKacinciSoru = Convert.ToInt32(lblSoruNo.Text);
                    if (dtSoru.Rows.Count > 0 && InKacinciSoru < 10)
                    {
                        //0. satır 1. soru 1. satır 2. soru
                        lblSoruNo.Text = (InKacinciSoru + 1).ToString();
                        lblSoru.Text = dtSoru.Rows[InKacinciSoru]["StSoru"].ToString();
                        lblA.Text = dtSoru.Rows[InKacinciSoru]["StASikki"].ToString();
                        lblB.Text = dtSoru.Rows[InKacinciSoru]["StBSikki"].ToString();
                        lblC.Text = dtSoru.Rows[InKacinciSoru]["StCSikki"].ToString();
                        lblD.Text = dtSoru.Rows[InKacinciSoru]["StDSikki"].ToString();
                        hideDogruCevap.Value = dtSoru.Rows[InKacinciSoru]["StDogruCevap"].ToString();
                        hideInSoruId.Value = dtSoru.Rows[0]["InSoruId"].ToString();

                        if (dtSoru.Rows[InKacinciSoru]["StResimYolu"].ToString().Length > 0)
                        {
                            imgSoru.Visible = true;
                            imgSoru.ImageUrl = "~/SoruResimleri/" + dtSoru.Rows[InKacinciSoru]["StResimYolu"].ToString();
                        }
                        else
                        {
                            imgSoru.Visible = false;
                        }
                    }
                }
                rbA.Checked = false;
                rbB.Checked = false;
                rbC.Checked = false;
                rbD.Checked = false;
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

        private void FnListele()
        {
            try
            {
                if (ClLoginInfo.baglanti.State == System.Data.ConnectionState.Closed)
                    ClLoginInfo.baglanti.Open();

                //Bilinen soru havuzundan olmayan rastgele 10 soru
                SqlCommand cmdSorular = new SqlCommand("SpSinavSorulari", ClLoginInfo.baglanti);
                cmdSorular.Parameters.AddWithValue("@InOgrenciId", ClLoginInfo.InOgrenciId);
                cmdSorular.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmdSorular);

                DataTable dtSoru = new DataTable();
                da.Fill(dtSoru);

                if (dtSoru != null)
                {
                    Session["dtSoru"] = dtSoru;

                    if (dtSoru.Rows.Count > 0)
                    {
                        lblSoruNo.Text = "1";
                        hideInSoruId.Value = dtSoru.Rows[0]["InSoruId"].ToString();
                        lblSoru.Text = dtSoru.Rows[0]["StSoru"].ToString();
                        lblA.Text = dtSoru.Rows[0]["StASikki"].ToString();
                        lblB.Text = dtSoru.Rows[0]["StBSikki"].ToString();
                        lblC.Text = dtSoru.Rows[0]["StCSikki"].ToString();
                        lblD.Text = dtSoru.Rows[0]["StDSikki"].ToString();
                        hideDogruCevap.Value = dtSoru.Rows[0]["StDogruCevap"].ToString();

                        if (dtSoru.Rows[0]["StResimYolu"].ToString().Length > 0)
                        {
                            imgSoru.Visible = true;
                            imgSoru.ImageUrl = "~/SoruResimleri/" + dtSoru.Rows[0]["StResimYolu"].ToString();
                        }
                        else
                        {
                            imgSoru.Visible = false;
                        }
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
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Session["timeout"].ToString())))
            {
                //Eğer
                //değer 0 dan büyük ise kalan süreyi Label de gösteriyoruz.
                int InKalanToplamSaniye = (Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds;
                int InKalanDakika = (int)(InKalanToplamSaniye / 60);
                int InKalanSaniye = (int)(InKalanToplamSaniye - (InKalanDakika * 60));
                lblTimer.Text = "Kalan Süre: " + InKalanDakika.ToString() + ":" + InKalanSaniye.ToString();
            }
            else
            {
                //süre 0
                //ve küçük ise sürenin bittiğini Label e yazdırıyoruz.
                lblTimer.Text = "Süre Bitti…";
                tblSoru.Visible = false;
            }
        }
    }
}