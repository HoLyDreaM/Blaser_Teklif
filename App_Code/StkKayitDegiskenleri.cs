using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class StkKayitDegiskenleri
{

    #region String Değişkenler

    static string _MalKodu;
    static string _HesapKodu;
    static string _EvrakNumarasi;
    static string _GirenKaynak;
    static string _GirenSaat;
    static string _GirenKodu;
    static string _DovizCinsi;
    static string _Aciklama1;
    static string _Aciklama2;
    static string _MalSeriNo;
    static string _TeslimKodu;
    static string _ParaBirimi;

    #endregion

    #region Decimal Değişkenler

    static decimal _Miktar;
    static decimal _BirimFiyati;
    static decimal _Tutari;
    static decimal _KdvTutari;
    static decimal _Miktar2;
    static decimal _BayiIskontoOrani;
    static decimal _MusteriIskontoOrani;
    static decimal _TeklifIskontoOrani;
    static decimal _BayiIskontoTutari;
    static decimal _MusteriIskontoTutari;
    static decimal _TeklifIskontoTutari;
    static decimal _DovizTutari;
    static decimal _DovizKuru;
    static decimal _KdvOrani;

    static decimal _GenelMalBedeli;
    static decimal _GenelToplam;
    static decimal _GenelNetTutar;
    static decimal _Genelisk1;
    static decimal _Genelisk2;
    static decimal _Genelisk3;
    static decimal _GenelKdvTutar;
    static decimal _GenelKdvOran;
    static decimal _GenelDovizKuru;

    #endregion

    #region Int Değişkenler

    static int _IslemTarihi;
    static int _TeslimTarihi;
    static int _SEQNo;
    static int _GirenTarih;
    static int _KdvOranFlag;

    #endregion

    #region String Tanımlar

    public static string MalKodu
    {
        get { return _MalKodu; }
        set { _MalKodu = value; }
    }
    public static string HesapKodu
    {
        get { return _HesapKodu; }
        set { _HesapKodu = value; }
    }
    public static string EvrakNumarasi
    {
        get { return _EvrakNumarasi; }
        set { _EvrakNumarasi = value; }
    }
    public static string GirenKaynak
    {
        get { return _GirenKaynak; }
        set { _GirenKaynak = value; }
    }
    public static string GirenSaat
    {
        get { return _GirenSaat; }
        set { _GirenSaat = value; }
    }
    public static string GirenKodu
    {
        get { return _GirenKodu; }
        set { _GirenKodu = value; }
    }
    public static string DovizCinsi
    {
        get { return _DovizCinsi; }
        set { _DovizCinsi = value; }
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
    public static string MalSeriNo
    {
        get { return _MalSeriNo; }
        set { _MalSeriNo = value; }
    }
    public static string TeslimKodu
    {
        get { return _TeslimKodu; }
        set { _TeslimKodu = value; }
    }
    public static string ParaBirimi
    {
        get { return _ParaBirimi; }
        set { _ParaBirimi = value; }
    }

    #endregion

    #region Decimal Tanımlar

    public static decimal GenelMalBedeli
    {
        get { return _GenelMalBedeli; }
        set { _GenelMalBedeli = value; }
    }
    public static decimal GenelToplam
    {
        get { return _GenelToplam; }
        set { _GenelToplam = value; }
    }
    public static decimal GenelNetTutar
    {
        get { return _GenelNetTutar; }
        set { _GenelNetTutar = value; }
    }
    public static decimal Genelisk1
    {
        get { return _Genelisk1; }
        set { _Genelisk1 = value; }
    }
    public static decimal Genelisk2
    {
        get { return _Genelisk2; }
        set { _Genelisk2 = value; }
    }
    public static decimal Genelisk3
    {
        get { return _Genelisk3; }
        set { _Genelisk3 = value; }
    }
    public static decimal GenelKdvTutar
    {
        get { return _GenelKdvTutar; }
        set { _GenelKdvTutar = value; }
    }
    public static decimal GenelKdvOran
    {
        get { return _GenelKdvOran; }
        set { _GenelKdvOran = value; }
    }
    public static decimal GenelDovizKuru
    {
        get { return _GenelDovizKuru; }
        set { _GenelDovizKuru = value; }
    }

    public static decimal Miktar
    {
        get { return _Miktar; }
        set { _Miktar = value; }
    }
    public static decimal BirimFiyati
    {
        get { return _BirimFiyati; }
        set { _BirimFiyati = value; }
    }
    public static decimal Tutari
    {
        get { return _Tutari; }
        set { _Tutari = value; }
    }
    public static decimal KdvTutari
    {
        get { return _KdvTutari; }
        set { _KdvTutari = value; }
    }
    public static decimal Miktar2
    {
        get { return _Miktar2; }
        set { _Miktar2 = value; }
    }
    public static decimal BayiIskontoOrani
    {
        get { return _BayiIskontoOrani; }
        set { _BayiIskontoOrani = value; }
    }
    public static decimal MusteriIskontoOrani
    {
        get { return _MusteriIskontoOrani; }
        set { _MusteriIskontoOrani = value; }
    }
    public static decimal TeklifIskontoOrani
    {
        get { return _TeklifIskontoOrani; }
        set { _TeklifIskontoOrani = value; }
    }
    public static decimal BayiIskontoTutari
    {
        get { return _BayiIskontoTutari; }
        set { _BayiIskontoTutari = value; }
    }
    public static decimal MusteriIskontoTutari
    {
        get { return _MusteriIskontoTutari; }
        set { _MusteriIskontoTutari = value; }
    }
    public static decimal TeklifIskontoTutari
    {
        get { return _TeklifIskontoTutari; }
        set { _TeklifIskontoTutari = value; }
    }
    public static decimal DovizTutari
    {
        get { return _DovizTutari; }
        set { _DovizTutari = value; }
    }
    public static decimal DovizKuru
    {
        get { return _DovizKuru; }
        set { _DovizKuru = value; }
    }
    public static decimal KdvOrani
    {
        get { return _KdvOrani; }
        set { _KdvOrani = value; }
    }

    #endregion

    #region Int Tanımlar

    public static int IslemTarihi
    {
        get { return _IslemTarihi; }
        set { _IslemTarihi = value; }
    }
    public static int TeslimTarihi
    {
        get { return _TeslimTarihi; }
        set { _TeslimTarihi = value; }
    }
    public static int SEQNo
    {
        get { return _SEQNo; }
        set { _SEQNo = value; }
    }
    public static int GirenTarih
    {
        get { return _GirenTarih; }
        set { _GirenTarih = value; }
    }
    public static int KdvOranFlag
    {
        get { return _KdvOranFlag; }
        set { _KdvOranFlag = value; }
    }

    #endregion
}