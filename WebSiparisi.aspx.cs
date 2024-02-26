using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        HtmlGenericControl control = (HtmlGenericControl)Master.FindControl("menuWeb");
        control.Attributes.Add("class", "active");

        String csname1 = "PopupScript";
        String csname2 = "ButtonClickScript";

        if (!IsClientScriptBlockRegistered(csname1))
        {
            String cstext1 = "<script type=\"text/javascript\">" +
                "alert('Hello World');</" + "script>";
            RegisterStartupScript(csname1, cstext1);
        }

        if (!IsClientScriptBlockRegistered(csname2))
        {
            StringBuilder cstext2 = new StringBuilder();
            cstext2.Append("<script type=\"text/javascript\"> function DoClick() {");
            cstext2.Append("Form1.Message.value='Text from client script.'} </");
            cstext2.Append("script>");
            RegisterClientScriptBlock(csname2, cstext2.ToString());
        }

    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {

    }
    protected void ASPxButton2_Click(object sender, EventArgs e)
    {
        
    }
}