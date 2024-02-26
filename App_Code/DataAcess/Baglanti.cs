using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// DataAcess > Baglanti
/// </summary>
public class Baglanti : IDisposable
{
    private const string _sunucu = "MEHMET\\SQLSERVER";
    private const string _veritabani = "BlaserTeklif";

    private SqlConnection _baglanti;
    private SqlCommand _komut;
    private SqlDataReader _veriOku;
    private DataTable _tablo;
    private NIslemSonuc _islemSonuc;

    public Baglanti()
    {
        string baglantiCumlesi = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", _sunucu, _veritabani);
        _baglanti = new SqlConnection(baglantiCumlesi);
    }

    public string StorendProcesdureAdi
    {
        set
        {
            _komut = new SqlCommand(value, _baglanti);
            _komut.CommandType = CommandType.StoredProcedure;
        }
    }
    public string Komut
    {
        set
        {
            _komut = new SqlCommand(value, _baglanti);
        }
    }

    public void ParametreEkle(string parametre, SqlDbType tur, object deger)
    {
        _komut.Parameters.Add(parametre, tur).Value = deger;
    }

    private void BaglantiyiAc()
    {
        if (_baglanti.State == ConnectionState.Closed)
            _baglanti.Open();
    }

    public DataTable SorguCalistirTablo()
    {
        BaglantiyiAc();
        _veriOku = null;
        _veriOku = _komut.ExecuteReader();
        _tablo = new DataTable();
        _tablo.Load(_veriOku);
        _baglanti.Close();
        return _tablo;
    }
    public object SorguCalistirTekKayit()
    {
        BaglantiyiAc();
        return _komut.ExecuteScalar();
    }
    public int SorguCalistir()
    {
        BaglantiyiAc();
        return _komut.ExecuteNonQuery();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
