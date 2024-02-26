using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //fonksiyonlar fnk = new fonksiyonlar();
        string GirisKontrol = Session["Giris"] as string;

        if (GirisKontrol != "Evet")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HtmlGenericControl li = (HtmlGenericControl)Master.FindControl("menuAnasayfa");
            li.Attributes.Add("class", "active");
        }
    }
}