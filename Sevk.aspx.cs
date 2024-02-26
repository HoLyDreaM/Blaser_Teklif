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
        HtmlGenericControl control = (HtmlGenericControl)Master.FindControl("menuSevk");
        control.Attributes.Add("class", "active");
    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        ASPxTextBox1.Text = DateTime.Now.ToString();
    }
}