using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class KullaniciDB : BaglantiDB
{
    public KullaniciDB()
    {
        if (_baglanti == null)
        {
            this._baglanti = new Baglanti();
        }
    }

    NIslemSonuc _islemSonuc;

    protected NIslemSonuc KullaniciGiris(String KullaniciAdi, string Sifre, string IP)
    {
        try
        {
            _baglanti.StorendProcesdureAdi = "spKullaniciGirisi";
            _baglanti.ParametreEkle("KullaniciAdi", System.Data.SqlDbType.NVarChar, KullaniciAdi);
            _baglanti.ParametreEkle("Sifre", System.Data.SqlDbType.NVarChar, Sifre);
            _baglanti.ParametreEkle("IP", System.Data.SqlDbType.NVarChar, IP);

            object sonuc = _baglanti.SorguCalistirTablo();
            _islemSonuc = new NIslemSonuc(true, veri: sonuc);
        }
        catch (Exception ex)
        {
            _islemSonuc = new NIslemSonuc(false, new NHata
            {
                Sinif  = "Kullanici Veri Tabanı",
                Method = "Kullanici Girişi",
                KullaniciId = 0,
                HataMesaj = ex.Message,
                Tarih = DateTime.Now
            });
        }

        return _islemSonuc;
    }

}
