using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{

    //FormAciklamalariIslem frmAciklamalari;
    protected void Page_Load(object sender, EventArgs e)
    {
        string GirisKontrol = Session["Giris"] as string;

        if (GirisKontrol != "Evet")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HtmlGenericControl control = (HtmlGenericControl)Master.FindControl("menuTanimlar");
            control.Attributes.Add("class", "dropdown active");
           
            if (!IsPostBack)
            {
                FormAciklamalariIslem frmAciklamalari = new FormAciklamalariIslem();
                NFormAciklamasi NFormAciklama = frmAciklamalari.FormAciklamasiGetir();
                if (NFormAciklama.BasariliMi)
                {
                    txtUstBilgi1.Text = NFormAciklama.UstBaslik1;
                    txtUstBilgi2.Text = NFormAciklama.UstBaslik2;
                    txtUstBilgi3.Text = NFormAciklama.UstBaslik3;

                    txtAltBilgi1.Text = NFormAciklama.AltBaslik1;
                    txtAltBilgi2.Text = NFormAciklama.AltBaslik2;
                    txtAltBilgi3.Text = NFormAciklama.AltBaslik3;            
            }

          }
        }
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        FormAciklamalariIslem frmAciklamalari = new FormAciklamalariIslem();
        NFormAciklamasi NFormAciklamasi;

        NFormAciklamasi = new NFormAciklamasi { 
            AltBaslik1 = txtAltBilgi1.Text,
            AltBaslik2 = txtAltBilgi2.Text,
            AltBaslik3 = txtAltBilgi3.Text,

            UstBaslik1 = txtUstBilgi1.Text,
            UstBaslik2 = txtUstBilgi2.Text,
            UstBaslik3 = txtUstBilgi3.Text
        };

        if ((int)frmAciklamalari.frmAciklamalariniKaydet(NFormAciklamasi).Veri > 0) {
            System.Windows.Forms.MessageBox.Show("Başarılı");
        }else
            System.Windows.Forms.MessageBox.Show("Başarısız");
    }
}