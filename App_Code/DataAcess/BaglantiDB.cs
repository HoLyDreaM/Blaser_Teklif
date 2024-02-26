using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DataAcess > BaglantiDB : Baglanti
/// </summary>
public class BaglantiDB
{
    protected Baglanti _baglanti = new Baglanti();
    public BaglantiDB() //Bu veritabanına bağlantı yoksa yeni bağlantı oluştur.
    {
        if (_baglanti == null)
            _baglanti = new Baglanti();
    }
}