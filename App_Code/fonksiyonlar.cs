using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class fonksiyonlar
{
    public string GetIP()
    {
        var request = HttpContext.Current.Request;
        return request.ServerVariables["REMOTE_ADDR"].ToString();
    }

    public string MesajBox(string kelime)
    {
        kelime = "<script language='JavaScript'>alert('" + kelime + "');</script>";
        return kelime;
    }

    /// <summary>
    /// Js Alert methodunun yanında virgülden sonra link verebilir ya da geri yazabiliriz
    /// </summary>
    public string MesajBox(string kelime, string link)
    {
        if (link == "geri")
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');history.back(-1);</script>";
        }
        else
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');window.location = '" + link + "';</script>";
        }
        return kelime;
    }
}