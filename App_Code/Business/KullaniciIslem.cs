using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class KullaniciIslem : KullaniciDB
{

    public NKullanici KullaniciGiris(string kullaniciAdi, string sifre)
    {
        fonksiyonlar fnk = new fonksiyonlar();
       
        var sonuc = base.KullaniciGiris(kullaniciAdi, sifre, fnk.GetIP());
        if (!sonuc.BasariliMi)
        {
            //Hata Kaydet
        }      

        var sonucRow = (DataTable)sonuc.Veri;
        if (sonucRow.Rows[0][0].ToString() == "Yanlis")
            return new NKullanici { BasariliMi = false };
        else
            return new NKullanici()
            {
                BasariliMi = true,
                ID = (int)sonucRow.Rows[0]["ID"],
                KullaniciKodu = sonucRow.Rows[0]["KullaniciKodu"].ToString(),
                AdiSoyadi = sonucRow.Rows[0]["AdiSoyadi"].ToString(),
                KullaniciAdi = sonucRow.Rows[0]["KullaniciAdi"].ToString(),
                Email = sonucRow.Rows[0]["Email"].ToString()
            };
    }
}
 