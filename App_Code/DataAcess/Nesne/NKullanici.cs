using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class NKullanici
{
    //[ID] [int] IDENTITY(1,1) NOT NULL,
    //[KullaniciKodu] [nvarchar](10) NOT NULL,
    //[AdiSoyadi] [nvarchar](30) NOT NULL,
    //[KullaniciAdi] [nvarchar](20) NOT NULL,
    //[Sifre] [nvarchar](20) NOT NULL,
    //[Email] [nvarchar](50) NOT NULL,
    //[Aktif] [bit] NOT NULL

    public int ID { get; set; }
    public string KullaniciKodu { get; set; }
    public string AdiSoyadi { get; set; }
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public string Email { get; set; }
    public Boolean Aktif { get; set; }

    public Boolean BasariliMi { get; set; }
}
