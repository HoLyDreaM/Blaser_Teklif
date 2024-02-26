using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection DbUser = new SqlConnection(ConfigurationManager.ConnectionStrings["BlaserTeklifCS"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        string GirisKontrol = Session["Giris"] as string;

        if (GirisKontrol == "Evet")
        {
            Response.Redirect("Teklif.aspx");
        }
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (HackEngelle(username.Text) == "" || HackEngelle(password.Text) == "")
        {
            Alert.Show("Kullanıcı Adını veya Şifreyi Boş Bıraktınız.Lütfen Kontrol Edip Tekrar Deneyin");
        }
        else
        {
            if (DbUser.State == ConnectionState.Closed)
                DbUser.Open();

            string KullAdi = HackEngelle(username.Text);
            string Pass = HackEngelle(password.Text);
            string IP = Request.ServerVariables["REMOTE_ADDR"].ToString();

            SqlCommand cmd = new SqlCommand("spKullaniciGirisi", DbUser);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("KullaniciAdi", SqlDbType.NVarChar).Value = KullAdi;
            cmd.Parameters.Add("Sifre", SqlDbType.NVarChar).Value = Pass;
            cmd.Parameters.Add("IP", SqlDbType.NVarChar).Value = IP;

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.Read())
            {
                Session["Giris"] = "Evet";
                Session["ID"] = dr[0].ToString();
                Session["KullaniciKodu"] = dr[1].ToString();
                Session["AdiSoyadi"] = dr[2].ToString();
                Session["KullaniciAdi"] = dr[3].ToString();
                Session["Email"] = dr[5].ToString();
                Session["CepNo"] = dr[6].ToString();
                Session["TelNo"] = dr[7].ToString();

                Response.Redirect("Teklif.aspx");
            }
            else
            {
                Alert.Show("Kullanıcı Adı veya Şifre Yanlış");
            }

            dr.Dispose();
            dr.Close();
            
        }
    }

    public static string HackEngelle(string Deger)
    {
        if (Deger != null)
        {
            Deger = Deger.Replace("'", "");
            Deger = Deger.Replace("++", "");
            Deger = Deger.Replace("--", "");
            Deger = Deger.Replace("=", "");
            Deger = Deger.Replace(";--", "");
            Deger = Deger.Replace(";", "");
            Deger = Deger.Replace("/*", "");
            Deger = Deger.Replace("*/", "");
            Deger = Deger.Replace("@@", "");
            Deger = Deger.Replace("@", "");
        }
        return Deger;
    }
}