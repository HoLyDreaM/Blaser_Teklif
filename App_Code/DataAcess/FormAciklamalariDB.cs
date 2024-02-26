using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class FormAciklamalariDB : BaglantiDB
{
	public FormAciklamalariDB()
	{
		if (_baglanti == null)
		{
			this._baglanti = new Baglanti();
		}
	}

	NIslemSonuc _islemSonuc;

	protected NIslemSonuc frmAciklamalariniGetir()
	{
		try
		{
			_baglanti.Komut = "SELECT top 1 * FROM tblFormAciklamalari";
			object sonuc = _baglanti.SorguCalistirTablo();

			_islemSonuc = new NIslemSonuc(true, veri: sonuc);
		}
		catch (Exception ex)
		{
			_islemSonuc = new NIslemSonuc(false, new NHata
			{
				Sinif = "Form Açıklamaları",
				Method = "Form Açıklamalarını Getir",
				KullaniciId = 0,
				HataMesaj = ex.Message,
				Tarih = DateTime.Now
			});
		}

		return _islemSonuc;
	}

	protected NIslemSonuc frmAciklamalariniKaydet(NFormAciklamasi frmAciklamasi)
	{
		try
		{
			_baglanti.Komut = @"UPDATE tblFormAciklamalari
								SET
									UstBaslik1 = @UstBaslik1,
									UstBaslik2 = @UstBaslik2,
									UstBaslik3 = @UstBaslik3,
									UstBaslik4 = '',
									AltBaslik1 = @AltBaslik1,
									AltBaslik2 = @AltBaslik2,
									AltBaslik3 = @AltBaslik3,
									AltBaslik4 = ''";

			_baglanti.ParametreEkle("UstBaslik1", System.Data.SqlDbType.NVarChar, frmAciklamasi.UstBaslik1);
			_baglanti.ParametreEkle("UstBaslik2", System.Data.SqlDbType.NVarChar, frmAciklamasi.UstBaslik2);
			_baglanti.ParametreEkle("UstBaslik3", System.Data.SqlDbType.NVarChar, frmAciklamasi.UstBaslik3);

			_baglanti.ParametreEkle("AltBaslik1", System.Data.SqlDbType.NVarChar, frmAciklamasi.AltBaslik1);
			_baglanti.ParametreEkle("AltBaslik2", System.Data.SqlDbType.NVarChar, frmAciklamasi.AltBaslik2);
			_baglanti.ParametreEkle("AltBaslik3", System.Data.SqlDbType.NVarChar, frmAciklamasi.AltBaslik3);
			
			int sonuc = _baglanti.SorguCalistir();

			_islemSonuc = new NIslemSonuc(true, veri: sonuc);
			
		}
		catch (Exception ex)
		{
			_islemSonuc = new NIslemSonuc(false, new NHata
			{
				Sinif = "Form Açıklamalarını Kaydet",
				Method = "Form Açıklamalarını Kaydet",
				KullaniciId = 0,
				HataMesaj = ex.Message,
				Tarih = DateTime.Now
			});
		}

		return _islemSonuc;
	}
}