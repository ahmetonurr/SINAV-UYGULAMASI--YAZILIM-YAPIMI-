using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WaSinav
{
    public static class ClLoginInfo
    {
        public static int InKullaniciId;

        public static int InOgrenciId;

        public static int InKullaniciTipi; //1. Admin 2. Sınav Sorumlusu 3. Öğrenci

        public static string StBaglantiCumlesi = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;

        public static SqlConnection baglanti = new SqlConnection(StBaglantiCumlesi);
    }
}