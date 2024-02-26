using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///  DataAcess > Nesne > NISlemSonuc
/// </summary>
public class NIslemSonuc
{
    public NIslemSonuc(bool basariliMi, NHata hataBilgi = null, object veri = null)
    {
        BasariliMi = basariliMi;
        HataBilgi = hataBilgi;
        Veri = veri;
        if (!basariliMi)
        {
            NHata hataIslem = new NHata();
            //Hata Ekleme işlemi yapılacak
        }
    }
    public bool BasariliMi { get; set; }
    public object Veri { get; set; }
    public NHata HataBilgi { get; set; }
}