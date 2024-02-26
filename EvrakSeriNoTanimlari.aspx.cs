using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
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
        }
    }
}