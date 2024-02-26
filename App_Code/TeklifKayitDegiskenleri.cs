using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TeklifKayitDegiskenleri
{

    #region String Değişkenleri

    static string _TeklifEvrakNo;
    static string _KullaniciKodu;
    static string _MusteriHesapKodu;
    static string _BayiHesapKodu;
    static string _MalKodu;
    static string _MalAdi;
    static string _Birim;
    static string _TeslimSuresi;
    static string _TeslimYeri;
    static string _OdemeSekli1;
    static string _OdemeSekli2;
    static string _OdemeSekli3;
    static string _Aciklama1;
    static string _Aciklama2;
    static string _Not1;
    static string _Not2;
    static string _Bilgiler;
    static string _BayiUnvanAdres1;
    static string _BayiUnvanAdres2;
    static string _BayiUnvanAdres3;
    static string _TelFax;
    static string _TeklifSeriNo;
    static string _TeklifiHazirlayan;
    static string _CepNo;
    static string _TelNo;
    static string _DovizCinsi;
    static string _TeklifRedNeden1;
    static string _TeklifRedNeden2;

    #endregion

    #region Decimal Değişkenler

    static decimal _Miktar;
    static decimal _Miktar2;
    static decimal _BirimFiyat;
    static decimal _KafileBuyuklugu;
    static decimal _Tutar;
    static decimal _BayiIskTutari;
    static decimal _MusteriIskTutari;
    static decimal _TeklifIskTutari;
    static decimal _BayiIskOran;
    static decimal _MusteriIskOran;
    static decimal _TeklifIskOran;
    static decimal _DovizKuru;

    #endregion

    #region İnt Değişkenler

    static int _TeklifTuru;
    static int _TeklifTarihi;
    static int _BitisTarihi;
    static int _TeklifDurum;
    static int _TeklifOnayTarihi;

    #endregion

    #region String Tanımlar

    public static string TeklifEvrakNo
    {
        get { return _TeklifEvrakNo; }
        set { _TeklifEvrakNo = value; }
    }
    public static string KullaniciKodu
    {
        get { return _KullaniciKodu; }
        set { _KullaniciKodu = value; }
    }
    public static string MusteriHesapKodu
    {
        get { return _MusteriHesapKodu; }
        set { _MusteriHesapKodu = value; }
    }
    public static string BayiHesapKodu
    {
        get { return _BayiHesapKodu; }
        set { _BayiHesapKodu = value; }
    }
    public static string MalKodu
    {
        get { return _MalKodu; }
        set { _MalKodu = value; }
    }
    public static string MalAdi
    {
        get { return _MalAdi; }
        set { _MalAdi = value; }
    }
    public static string Birim
    {
        get { return _Birim; }
        set { _Birim = value; }
    }
    public static string TeslimSuresi
    {
        get { return _TeslimSuresi; }
        set { _TeslimSuresi = value; }
    }
    public static string TeslimYeri
    {
        get { return _TeslimYeri; }
        set { _TeslimYeri = value; }
    }
    public static string OdemeSekli1
    {
        get { return _OdemeSekli1; }
        set { _OdemeSekli1 = value; }
    }
    public static string OdemeSekli2
    {
        get { return _OdemeSekli2; }
        set { _OdemeSekli2 = value; }
    }
    public static string OdemeSekli3
    {
        get { return _OdemeSekli3; }
        set { _OdemeSekli3 = value; }
    }
    public static string Aciklama1
    {
        get { return _Aciklama1; }
        set { _Aciklama1 = value; }

    }
    public static string Aciklama2
    {
        get { return _Aciklama2; }
        set { _Aciklama2 = value; }

    }
    public static string Not1
    {
        get { return _Not1; }
        set { _Not1 = value; }

    }
    public static string Not2
    {
        get { return _Not2; }
        set { _Not2 = value; }

    }
    public static string Bilgiler
    {
        get { return _Bilgiler; }
        set { _Bilgiler = value; }

    }
    public static string BayiUnvanAdres1
    {
        get { return _BayiUnvanAdres1; }
        set { _BayiUnvanAdres1 = value; }

    }
    public static string BayiUnvanAdres2
    {
        get { return _BayiUnvanAdres2; }
        set { _BayiUnvanAdres2 = value; }

    }
    public static string BayiUnvanAdres3
    {
        get { return _BayiUnvanAdres3; }
        set { _BayiUnvanAdres3 = value; }

    }
    public static string TelFax
    {
        get { return _TelFax; }
        set { _TelFax = value; }

    }
    public static string TeklifSeriNo
    {
        get { return _TeklifSeriNo; }
        set { _TeklifSeriNo = value; }

    }
    public static string TeklifiHazirlayan
    {
        get { return _TeklifiHazirlayan; }
        set { _TeklifiHazirlayan = value; }

    }
    public static string CepNo
    {
        get { return _CepNo; }
        set { _CepNo = value; }

    }
    public static string TelNo
    {
        get { return _TelNo; }
        set { _TelNo = value; }

    }
    public static string DovizCinsi
    {
        get { return _DovizCinsi; }
        set { _DovizCinsi = value; }

    }
    public static string TeklifRedNeden1
    {
        get { return _TeklifRedNeden1; }
        set { _TeklifRedNeden1 = value; }

    }
    public static string TeklifRedNeden2
    {
        get { return _TeklifRedNeden2; }
        set { _TeklifRedNeden2 = value; }

    }

    #endregion

    #region Decimal Tanımlar

    public static decimal Miktar
    {
        get { return _Miktar; }
        set { _Miktar = value; }
    }
    public static decimal Miktar2
    {
        get { return _Miktar2; }
        set { _Miktar2 = value; }
    }
    public static decimal BirimFiyat
    {
        get { return _BirimFiyat; }
        set { _BirimFiyat = value; }
    }
    public static decimal KafileBuyuklugu
    {
        get { return _KafileBuyuklugu; }
        set { _KafileBuyuklugu = value; }
    }
    public static decimal Tutar
    {
        get { return _Tutar; }
        set { _Tutar = value; }
    }
    public static decimal BayiIskTutari
    {
        get { return _BayiIskTutari; }
        set { _BayiIskTutari = value; }
    }
    public static decimal MusteriIskTutari
    {
        get { return _MusteriIskTutari; }
        set { _MusteriIskTutari = value; }
    }
    public static decimal TeklifIskTutari
    {
        get { return _TeklifIskTutari; }
        set { _TeklifIskTutari = value; }
    }
    public static decimal BayiIskOran
    {
        get { return _BayiIskOran; }
        set { _BayiIskOran = value; }
    }
    public static decimal MusteriIskOran
    {
        get { return _MusteriIskOran; }
        set { _MusteriIskOran = value; }
    }
    public static decimal TeklifIskOran
    {
        get { return _TeklifIskOran; }
        set { _TeklifIskOran = value; }
    }
    public static decimal DovizKuru
    {
        get { return _DovizKuru; }
        set { _DovizKuru = value; }
    }

    #endregion

    #region Int Tanımlar

    public static int TeklifTuru
    {
        get { return _TeklifTuru; }
        set { _TeklifTuru = value; }
    }
    public static int TeklifTarihi
    {
        get { return _TeklifTarihi; }
        set { _TeklifTarihi = value; }
    }
    public static int BitisTarihi
    {
        get { return _BitisTarihi; }
        set { _BitisTarihi = value; }
    }
    public static int TeklifDurum
    {
        get { return _TeklifDurum; }
        set { _TeklifDurum = value; }
    }
    public static int TeklifOnayTarihi
    {
        get { return _TeklifOnayTarihi; }
        set { _TeklifOnayTarihi = value; }
    }

    #endregion
}