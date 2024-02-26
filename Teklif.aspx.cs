﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

public partial class Teklif : System.Web.UI.Page
{

    fonksiyonlar fnk = new fonksiyonlar();
    SqlConnection DbConBlaser = new SqlConnection(ConfigurationManager.ConnectionStrings["BlaserTeklifCS"].ToString());
    SqlConnection DbConLink = new SqlConnection(ConfigurationManager.ConnectionStrings["CsLink"].ToString());
    string Linkdb2, BlaserDb, Miktar, Miktar2, BirimFiyat, KafileBuyuklugu, Tutar, MalKodu, MalAdi, Birim, HesapKodu, BayiHesapKodu, BayiIskontoOrani,
        MusteriIskontoOrani, TeklifIskontoOrani, BayiIskontoTutari, MusteriIskontoTutari, TeklifIskontoTutari, DovizCinsi,
        DovizKuru, Aciklama1, Aciklama2, TeklifNumaramiz, TeklifKullaniciAdimiz;
    string[] LinkDb, DiziMiktar, DiziMiktar2, DiziBirimFiyat, DiziKafileBuyuklugu, DiziTutar, DiziMalKodu, DiziMalAdi, DiziBirim,
        DiziHesapKodu, DiziBayiHesapKodu, DiziBayiIskontoOrani, DiziMusteriIskontoOrani, DiziTeklifIskontoOrani, DiziBayiIskontoTutari,
        DiziMusteriIskontoTutari, DiziTeklifIskontoTutari, DiziDovizCinsi, DiziDovizKuru, DiziAciklama1, DiziAciklama2, DiziTeklifNumaramiz, DiziTeklifKullaniciAdimiz;

    protected void Page_Load(object sender, EventArgs e)
    {
        string GirisKontrol = Session["Giris"] as string;

        if (GirisKontrol != "Evet")
        {
            Response.Redirect("Default.aspx");
        }

        if (!IsPostBack)
        {
            HtmlGenericControl control = (HtmlGenericControl)Master.FindControl("menuTeklif");
            control.Attributes.Add("class", "active");
            TeklifOnayla.Visible = false;
            lnkTeklifRed.Visible = false;
        }

        BaslangicIslemleri();
        EvrakNumaralariGetir();

        if (IsPostBack)
        {
            TeklifEvrakNoGetir();
        }
    }

    protected void txtMusteriHesapKodu_ValueChanged(object sender, EventArgs e)
    {

       
    }
    protected void txtBayiKodu_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
    {
        txtBayiKodu.Text = "";
        txtBayiAdresi.Text = "";
        txtBayiAdresi1.Text = "";
        txtBayiAdresi2.Text = "";
        txtBayiUnvani.Text = "";
        txtBayiUnvani1.Text = "";
        txtBayiVergiDairesi.Text = "";
        grdUrunlerimiz.Columns[0].Visible = true;
        //DsBayiler.SelectCommand = "SELECT CAR002_Row_ID AS ID, CAR002_HesapKodu AS HesapKodu, CAR002_Unvan1 AS Unvan1, CAR002_Unvan2 AS Unvan2, CAR002_Adres1 AS Adres1, CAR002_Adres2 AS Adres2, CAR002_Adres3 AS Adres3, CAR002_VergiDairesi AS VergiDairesi, CAR002_VergiHesapNo AS VergiHesapNo, CAR002_Telefon1 AS Telefon1, CAR002_BolgeKodu AS BolgeKodu, CAR002_GrupKodu AS GrupKodu, CAR002_Fax AS Fax, CAR002_Kod1 AS Kod1, CAR002_Kod2 AS Kod2, CAR002_Kod3 AS Kod3, CAR002_Kod4 AS Kod4, CAR002_Kod5 AS Kod5, CAR002_Kod6 AS Kod6, CAR002_Kod7 AS Kod7, CAR002_Kod8 AS Kod8, CAR002_Kod9 AS Kod9 FROM CAR002 AS c Where c.CAR002_Kod6 = '" + txtMusteriHesapKodu.Text + "'";
        //DsBayiler.SelectCommandType = SqlDataSourceCommandType.Text;
        //DsBayiler.DataBind();

        //txtBayiKodu.DataBind();
    }

    protected void MalKodu_ValueChanged(object sender, EventArgs e)
    {


    }

    private void BaslangicIslemleri()
    {
        dtTeklifTarihi.Date = DateTime.Now;
        dtBitisTarihi.Date = DateTime.Now;
        dtOnayTarihi.Date = DateTime.Now;
        dtOnayTarihi.Enabled = false;

        txtTeklifiHazirlayan.Text = Session["KullaniciKodu"].ToString();
        txtCepNo.Text = Session["CepNo"].ToString();
        txtTelNo.Text = Session["TelNo"].ToString();
    }

    private void EvrakNumaralariGetir()
    {
        string BlaserVeritabani = ConfigurationManager.ConnectionStrings["BlaserTeklifCS"].ToString();
        string LinkVeritabani = ConfigurationManager.ConnectionStrings["CsLink"].ToString();

        string[] BlaserDizi = new string[6];
        string[] BlaserDizi2 = new string[3];
        string[] LinkDizi = new string[6];
        string[] LinkDizi2 = new string[3];

        LinkDizi = LinkVeritabani.Split('=');
        LinkVeritabani = LinkDizi[2].ToString();
        LinkDizi2 = LinkVeritabani.Split(';');
        Linkdb2 = LinkDizi2[0].ToString();

        BlaserDizi = BlaserVeritabani.Split('=');
        BlaserVeritabani = BlaserDizi[2].ToString();
        BlaserDizi2 = BlaserVeritabani.Split(';');
        BlaserDb = BlaserDizi2[0].ToString();

        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        string sorgu = @"SELECT TOP(1) 0 AS TeklifID, (SELECT REPLACE(EvrakSeri,' ','')+RIGHT('000000'+convert(varchar(6), EvrakNo), 6) FROM tblEvrakSeriNo WHERE EvrakTipiStr='Teklif') AS EvrakNumarasi, 
                      '' KullaniciKodu, '' MusteriHesapKodu,'' BayiHesapKodu,'' MalKodu,'' MalAdi,'' Birim,0 Miktar,0 Miktar2,0 BirimFiyat,
                      0 KafileBuyuklugu,0 Tutar,0 BayiIskTutari,0 MusteriIskTutari, 
                      0 TeklifIskTutari,0 TeklifTarihi,'' TeklifSeriNo,0 BitisTarihi,0 BayiIskOran,0 MusteriIskOran,0 TeklifIskOran,
                      0 TeklifTuru,'' TeklifiHazirlayan,'' CepNo,'' TelNo,'' DovizCinsi,0 DovizKuru,0 TeklifDurum,'' TeklifRedNeden1, 
                      '' TeklifRedNeden2,0 TeklifOnayTarihi,'' TeslimSuresi,'' TeslimYeri,'' OdemeSekli1,'' OdemeSekli2,'' OdemeSekli3,
                      '' Aciklama1,'' Aciklama2,'' Not1,'' Not2,'' Bilgiler,'' BayiUnvanAdres1,'' BayiUnvanAdres2, 
                      '' BayiUnvanAdres3,'' TelFax,
                      '' AS MusteriUnvan1,'' AS MusteriUnvan2,'' AS MusteriAdres1,
                      '' AS MusteriAdres2,'' AS MusteriAdres3,'' AS MusteriVergiDairesi,
                      '' AS MusteriVergiNo,'' AS BayiUnvan1,'' AS BayiUnvan2,'' AS BayiAdres1,
                      '' AS BayiAdres2,'' AS BayiAdres3,'' AS BayiVergiDairesi,'' AS BayiVergiNo
                      FROM BlaserTeklif.dbo.Teklif AS T
                      UNION ALL
                      SELECT TeklifID, EvrakNumarasi, KullaniciKodu, MusteriHesapKodu, BayiHesapKodu, MalKodu, MalAdi, Birim, Miktar, Miktar2, BirimFiyat, KafileBuyuklugu, Tutar, BayiIskTutari, MusteriIskTutari, 
                      TeklifIskTutari, TeklifTarihi, TeklifSeriNo, BitisTarihi, BayiIskOran, MusteriIskOran, TeklifIskOran, TeklifTuru, TeklifiHazirlayan, CepNo, TelNo, DovizCinsi, DovizKuru, TeklifDurum, TeklifRedNeden1, 
                      TeklifRedNeden2, TeklifOnayTarihi, TeslimSuresi, TeslimYeri, OdemeSekli1, OdemeSekli2, OdemeSekli3, Aciklama1, Aciklama2, Not1, Not2, Bilgiler, BayiUnvanAdres1, BayiUnvanAdres2, 
                      BayiUnvanAdres3, TelFax,
                      C.CAR002_Unvan1 AS MusteriUnvan1,C.CAR002_Unvan2 AS MusteriUnvan2,C.CAR002_Adres1 AS MusteriAdres1,
                      C.CAR002_Adres2 AS MusteriAdres2,C.CAR002_Adres3 AS MusteriAdres3,C.CAR002_VergiDairesi AS MusteriVergiDairesi,
                      C.CAR002_VergiHesapNo AS MusteriVergiNo,
                      C1.CAR002_Unvan1 AS BayiUnvan1,C1.CAR002_Unvan2 AS BayiUnvan2,C1.CAR002_Adres1 AS BayiAdres1,
                      C1.CAR002_Adres2 AS BayiAdres2,C1.CAR002_Adres3 AS BayiAdres3,C1.CAR002_VergiDairesi AS BayiVergiDairesi,
                      C1.CAR002_VergiHesapNo AS BayiVergiNo
                      FROM " + BlaserDb + @".dbo.Teklif AS T
                      INNER JOIN " + Linkdb2 + "." + Linkdb2 + @".CAR002 AS C ON C.CAR002_HesapKodu=T.MusteriHesapKodu
                      INNER JOIN " + Linkdb2 + "." + Linkdb2 + @".CAR002 AS C1 ON C1.CAR002_HesapKodu=T.BayiHesapKodu
                      WHERE T.TeklifDurum IN(0,2)";

        SqlDataAdapter da = new SqlDataAdapter(sorgu, DbConBlaser);
        DataTable dt = new DataTable();
        da.Fill(dt);

        grdEvrakNumaralari.DataSource = dt;
        grdEvrakNumaralari.DataBind();
    }

    private void AcilisEvrakNumarasiBul()
    {
        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        string sorgu = "TeklifEvrakNo";
        SqlCommand cmdTeklifNo = new SqlCommand(sorgu, DbConBlaser);
        cmdTeklifNo.CommandType = CommandType.StoredProcedure;
        SqlDataReader drTeklif = cmdTeklifNo.ExecuteReader(CommandBehavior.CloseConnection);

        string TeklifEvrakNo = "";
        string TeklifEvrakSeri = "";

        if (drTeklif.Read())
        {
            TeklifEvrakNo = drTeklif["EvrakNo"].ToString();
            TeklifEvrakSeri = drTeklif["EvrakSeri"].ToString();
        }

        txtKullaniciAdi.Text = Session["KullaniciKodu"].ToString();
        TeklifEvrakNo = TeklifEvrakNo.PadLeft(6, '0');
        TeklifEvrakSeri = TeklifEvrakSeri + TeklifEvrakNo;
        grdEvrakNumaralari.Value = TeklifEvrakNo;

        txtTeklifEvrakNumarasi.Text = TeklifEvrakSeri.TrimStart(' ');
        grdEvrakNumaralari.Text = TeklifEvrakSeri.TrimStart(' ');

        DSTempStokHareketleri.Update();
        grdUrunlerimiz.DataBind();
        
        cmdTeklifNo.Dispose();
        drTeklif.Dispose();
        drTeklif.Close();

        btnKaydet.Visible = false;
        btnYenile.Visible = false;
    }

    private void TeklifEvrakNoGetir()
    {
        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        string sorgu = "TeklifEvrakNo";
        SqlCommand cmdTeklifNo = new SqlCommand(sorgu, DbConBlaser);
        cmdTeklifNo.CommandType = CommandType.StoredProcedure;
        SqlDataReader drTeklif = cmdTeklifNo.ExecuteReader(CommandBehavior.CloseConnection);

        string TeklifEvrakNo = grdEvrakNumaralari.Value.ToString();
        string TeklifEvrakSeri = "";

        if (drTeklif.Read())
        {
            TeklifEvrakSeri = drTeklif["EvrakSeri"].ToString();
        }

        TeklifEvrakNo = TeklifEvrakNo.PadLeft(6, '0');
        TeklifEvrakSeri = TeklifEvrakNo;

        txtTeklifEvrakNumarasi.Text = TeklifEvrakSeri.TrimStart(' ');
        grdEvrakNumaralari.Text = TeklifEvrakSeri.TrimStart(' ');
        
        DSTempStokHareketleri.Update();
        grdUrunlerimiz.DataBind();

        cmdTeklifNo.Dispose();
        drTeklif.Dispose();
        drTeklif.Close();

        int GridKontrol = grdUrunlerimiz.VisibleRowCount;

        if (GridKontrol > 0)
        {
            grdUrunlerimiz.Columns[0].Visible = false;
            EvrakCagiriyoruz();
        }
        else
        {
            grdUrunlerimiz.Columns[0].Visible = true;
        }
    }

    protected void rdTeklifRedEdildi_CheckedChanged(object sender, EventArgs e)
    {
        if (rdTeklifRedEdildi.Checked == true)
        {
            txtTeklifRed1.Text = txtTeklifRed1.Text;
            txtTeklifRed2.Text = txtTeklifRed2.Text;

            txtTeklifRed1.ReadOnly = false;
            txtTeklifRed2.ReadOnly = false;
            lnkTeklifRed.Visible = true;
            dtOnayTarihi.Enabled = false;
            TeklifOnayla.Visible = false;

            btnKaydet.Visible = false;
            btnYenile.Visible = false;
            rdTeklifRedEdildi.Checked = true;
        }
    }

    protected void rdTeklifOnaylandi_CheckedChanged(object sender, EventArgs e)
    {
        if (rdTeklifOnaylandi.Checked == true)
        {
            txtTeklifRed1.ReadOnly = true;
            txtTeklifRed2.ReadOnly = true;
            dtOnayTarihi.Enabled = true;
            TeklifOnayla.Visible = true;
            lnkTeklifRed.Visible = false;

            btnKaydet.Visible = false;
            btnYenile.Visible = false;
            rdTeklifOnaylandi.Checked = true;
        }
    }

    protected void rdTeklifBeklemede_CheckedChanged(object sender, EventArgs e)
    {
        if (rdTeklifBeklemede.Checked == true)
        {
            txtTeklifRed1.ReadOnly = true;
            txtTeklifRed2.ReadOnly = true;
            dtOnayTarihi.Enabled = false;
            TeklifOnayla.Visible = false;
            lnkTeklifRed.Visible = false;

            btnKaydet.Visible = true;
            btnYenile.Visible = true;
            rdTeklifBeklemede.Checked = true;
        }
    }

    protected void grdEvrakNumaralari_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AcilisEvrakNumarasiBul();
        }
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        if (drpTeklifTuru.SelectedItem.Text.ToString() == "Seçim Yapınız")
        {
            Alert.Show("Teklif Türünü Seçmediniz.Lütfen Kontrol Edip Tekrar Deneyin");
            return;
        }

        TeklifKayitDegiskenleri.TeklifTuru = Convert.ToInt32(drpTeklifTuru.SelectedValue.ToString());

        if (string.IsNullOrEmpty(txtNot1.Text))
        {
            TeklifKayitDegiskenleri.Not1 = "";
        }
        else
        {
            TeklifKayitDegiskenleri.Not1 = txtNot1.Text;
        }

        if (string.IsNullOrEmpty(txtNot2.Text))
        {
            TeklifKayitDegiskenleri.Not2 = "";
        }
        else
        {
            TeklifKayitDegiskenleri.Not2 = txtNot2.Text;
        }

        #region Tarih Ayarları

        double BitisTarihi = 0;
        int BitisTarihiRakam = 0;
        DateTime BitTarih = new DateTime();
        BitTarih = dtBitisTarihi.Date;
        string strBitis;
        BitisTarihi = 0;
        BitisTarihi = BitTarih.ToOADate();
        strBitis = BitisTarihi.ToString().Substring(0, 5);
        BitisTarihiRakam = Convert.ToInt32(strBitis);
        TeklifKayitDegiskenleri.BitisTarihi = BitisTarihiRakam;

        double TeklifTarihi = 0;
        int TeklifTarihiRakam = 0;
        DateTime TeklifTarih = new DateTime();
        TeklifTarih = dtTeklifTarihi.Date;
        string strTeklif;
        TeklifTarihi = 0;
        TeklifTarihi = TeklifTarih.ToOADate();
        strTeklif = TeklifTarihi.ToString().Substring(0, 5);
        TeklifTarihiRakam = Convert.ToInt32(strTeklif);
        TeklifKayitDegiskenleri.TeklifTarihi = TeklifTarihiRakam;

        double TeklifOnayTarihi = 0;
        int TeklifOnayRakam = 0;
        DateTime TeklifOnayTarih = new DateTime();
        TeklifOnayTarih = dtOnayTarihi.Date;
        string strTeklifOnay;
        TeklifOnayTarihi = 0;
        TeklifOnayTarihi = TeklifOnayTarih.ToOADate();
        strTeklifOnay = TeklifOnayTarihi.ToString().Substring(0, 5);
        TeklifOnayRakam = Convert.ToInt32(strTeklifOnay);
        TeklifKayitDegiskenleri.TeklifOnayTarihi = TeklifOnayRakam;

        #endregion

        TeklifKayitDegiskenleri.TeklifEvrakNo = grdEvrakNumaralari.Text.ToString();

        if (rdTeklifBeklemede.Checked == true)
        {
            TeklifKayitDegiskenleri.TeklifDurum = 0;
        }
        else if (rdTeklifOnaylandi.Checked == true)
        {
            TeklifKayitDegiskenleri.TeklifDurum = 1;
        }
        else if (rdTeklifRedEdildi.Checked == true)
        {
            TeklifKayitDegiskenleri.TeklifDurum = 2;
        }

        #region Bağşlantı ve Döngüler

        string StokKartiSorgu = "spTempStokKartlari";
        SqlCommand cmdStokKarti = new SqlCommand(StokKartiSorgu, DbConBlaser);
        cmdStokKarti.CommandType = CommandType.StoredProcedure;
        cmdStokKarti.Parameters.Add("@EvrakNumarasi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifEvrakNo.ToString();
        SqlDataReader drStokKarti = cmdStokKarti.ExecuteReader();

        string EvrakNumarasiGuncelle = "spTeklifEvrakNoGuncelle";
        SqlCommand cmdEvrakNoUpdate = new SqlCommand(EvrakNumarasiGuncelle, DbConBlaser);

        string StokKartiSil = "spTempStokKartiSil";
        SqlCommand cmdStokKartiSil = new SqlCommand(StokKartiSil, DbConBlaser);
        cmdStokKartiSil.CommandType = CommandType.StoredProcedure;

        string sorgu = "spTeklifInsert";
        SqlCommand cmdTeklifInsert = new SqlCommand(sorgu, DbConBlaser);
        cmdTeklifInsert.CommandType = CommandType.StoredProcedure;

        while (drStokKarti.Read())
        {
            MalKodu += drStokKarti["MalKodu"].ToString() + ",";
            MalAdi += drStokKarti["MalAdi"].ToString() + ",";
            Birim += drStokKarti["Birim"].ToString() + ",";
            Miktar += drStokKarti["Miktar"].ToString().Replace(',','.') + ",";
            Miktar2 += drStokKarti["Miktar2"].ToString().Replace(',', '.') + ",";
            BirimFiyat += drStokKarti["BirimFiyat"].ToString().Replace(',', '.') + ",";
            KafileBuyuklugu += drStokKarti["KafileBuyuklugu"].ToString().Replace(',', '.') + ",";
            Tutar += drStokKarti["Tutar"].ToString().Replace(',','.') + ",";
        }

        drStokKarti.Dispose();
        drStokKarti.Close();

        #endregion

        MalKodu = MalKodu.TrimEnd(',');
        MalAdi = MalAdi.TrimEnd(',');
        Birim = Birim.TrimEnd(',');
        Miktar = Miktar.TrimEnd(',');
        Miktar2 = Miktar2.TrimEnd(',');
        BirimFiyat = BirimFiyat.TrimEnd(',');
        KafileBuyuklugu = KafileBuyuklugu.TrimEnd(',');
        Tutar = Tutar.TrimEnd(',');

        DiziMalKodu = MalKodu.Split(',');
        DiziMalAdi = MalAdi.Split(',');
        DiziBirim = Birim.Split(',');
        DiziMiktar = Miktar.Split(',');
        DiziMiktar2 = Miktar2.Split(',');
        DiziBirimFiyat = BirimFiyat.Split(',');
        DiziKafileBuyuklugu = KafileBuyuklugu.Split(',');
        DiziTutar = Tutar.Split(',');

        for (int i = 0; i < DiziMalKodu.Length; i++)
        {

            #region Değişkenleri Alıyoruz

            TeklifKayitDegiskenleri.MalKodu = DiziMalKodu[i].ToString();
            TeklifKayitDegiskenleri.MalAdi = DiziMalAdi[i].ToString();
            TeklifKayitDegiskenleri.Birim = DiziBirim[i].ToString();
            TeklifKayitDegiskenleri.Miktar = Convert.ToDecimal(DiziMiktar[i].ToString().Replace('.',','));
            TeklifKayitDegiskenleri.Miktar2 = Convert.ToDecimal(DiziMiktar2[i].ToString().Replace('.', ','));
            TeklifKayitDegiskenleri.BirimFiyat = Convert.ToDecimal(DiziBirimFiyat[i].ToString().Replace('.', ','));
            TeklifKayitDegiskenleri.KafileBuyuklugu = Convert.ToDecimal(DiziKafileBuyuklugu[i].ToString().Replace('.', ','));
            TeklifKayitDegiskenleri.Tutar = Convert.ToDecimal(DiziTutar[i].ToString().Replace('.', ','));

            TeklifKayitDegiskenleri.KullaniciKodu = txtTeklifiHazirlayan.Text;
            TeklifKayitDegiskenleri.MusteriHesapKodu = txtMusteriHesapKodu.Text;
            TeklifKayitDegiskenleri.BayiHesapKodu = txtBayiKodu.Text;
            TeklifKayitDegiskenleri.BayiIskTutari = 0;
            TeklifKayitDegiskenleri.MusteriIskTutari = 0;
            TeklifKayitDegiskenleri.TeklifIskTutari = 0;
            TeklifKayitDegiskenleri.TeklifSeriNo = grdEvrakNumaralari.Text.ToString();
            TeklifKayitDegiskenleri.BayiIskOran = Convert.ToDecimal(txtBayiIskonto.Text);
            TeklifKayitDegiskenleri.MusteriIskOran = Convert.ToDecimal(txtMusteriIskonto.Text);
            TeklifKayitDegiskenleri.TeklifIskOran = Convert.ToDecimal(txtTeklifIskonto.Text);
            TeklifKayitDegiskenleri.TeklifiHazirlayan = txtTeklifiHazirlayan.Text;
            TeklifKayitDegiskenleri.CepNo = txtCepNo.Text;
            TeklifKayitDegiskenleri.TelNo = txtTelNo.Text;
            TeklifKayitDegiskenleri.DovizCinsi = drpDovizCinsi.SelectedItem.Text.ToString();

            if (Convert.ToDecimal(txtDovizKuru.Text) == 0)
            {
                TeklifKayitDegiskenleri.DovizKuru = DovizKurumuz(TeklifKayitDegiskenleri.MusteriHesapKodu, TeklifKayitDegiskenleri.DovizCinsi);
            }
            else
            {
                TeklifKayitDegiskenleri.DovizKuru = Convert.ToDecimal(txtDovizKuru.Text);
            }
            
            TeklifKayitDegiskenleri.TeklifRedNeden1 = txtTeklifRed1.Text;
            TeklifKayitDegiskenleri.TeklifRedNeden2 = txtTeklifRed2.Text;
            TeklifKayitDegiskenleri.TeslimSuresi = txtTeklifSuresi.Text;
            TeklifKayitDegiskenleri.TeslimYeri = txtTeslimYeri.Text;
            TeklifKayitDegiskenleri.OdemeSekli1 = txtOdemeSekli1.Text;
            TeklifKayitDegiskenleri.OdemeSekli2 = txtOdemeSekli2.Text;
            TeklifKayitDegiskenleri.OdemeSekli3 = txtOdemeSekli3.Text;
            TeklifKayitDegiskenleri.Aciklama1 = txtAciklama1.Text;
            TeklifKayitDegiskenleri.Aciklama2 = txtAciklama2.Text;
            TeklifKayitDegiskenleri.Bilgiler = txtBilgiler.Text;
            TeklifKayitDegiskenleri.BayiUnvanAdres1 = txtUnvanAdres1.Text;
            TeklifKayitDegiskenleri.BayiUnvanAdres2 = txtUnvanAdres2.Text;
            TeklifKayitDegiskenleri.BayiUnvanAdres3 = txtUnvanAdres3.Text;
            TeklifKayitDegiskenleri.TelFax = txtTelefonFax.Text;

            #endregion

            cmdTeklifInsert.Parameters.AddWithValue("@EvrakNumarasi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifEvrakNo.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@KullaniciKodu", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.KullaniciKodu.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@MusteriHesapKodu", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.MusteriHesapKodu.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BayiHesapKodu", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.BayiHesapKodu.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@MalKodu", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.MalKodu.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@MalAdi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.MalAdi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Birim", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Birim.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Miktar", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.Miktar.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@Miktar2", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.Miktar2.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@BirimFiyat", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.BirimFiyat.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@KafileBuyuklugu", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.KafileBuyuklugu.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.Tutar.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@BayiIskTutari", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.BayiIskTutari.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@MusteriIskTutari", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.MusteriIskTutari.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifIskTutari", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.TeklifIskTutari.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifTarihi", SqlDbType.Int).Value = TeklifKayitDegiskenleri.TeklifTarihi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifSeriNo", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifSeriNo.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BitisTarihi", SqlDbType.Int).Value = TeklifKayitDegiskenleri.BitisTarihi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BayiIskOran", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.BayiIskOran.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@MusteriIskOran", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.MusteriIskOran.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifIskOran", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.TeklifIskOran.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifTuru", SqlDbType.Int).Value = TeklifKayitDegiskenleri.TeklifTuru.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifiHazirlayan", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifiHazirlayan.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@CepNo", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.CepNo.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TelNo", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TelNo.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.DovizCinsi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = TeklifKayitDegiskenleri.DovizKuru.ToString().Replace(',', '.');
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifDurum", SqlDbType.Int).Value = TeklifKayitDegiskenleri.TeklifDurum.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifRedNeden1", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifRedNeden1.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifRedNeden2", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifRedNeden2.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeklifOnayTarihi", SqlDbType.Int).Value = TeklifKayitDegiskenleri.TeklifOnayTarihi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeslimSuresi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeslimSuresi.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TeslimYeri", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeslimYeri.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@OdemeSekli1", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.OdemeSekli1.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@OdemeSekli2", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.OdemeSekli2.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@OdemeSekli3", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.OdemeSekli3.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Aciklama1", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Aciklama1.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Aciklama2", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Aciklama2.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Not1", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Not1.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Not2", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Not2.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@Bilgiler", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.Bilgiler.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BayiUnvanAdres1", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.BayiUnvanAdres1.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BayiUnvanAdres2", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.BayiUnvanAdres2.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@BayiUnvanAdres3", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.BayiUnvanAdres3.ToString();
            cmdTeklifInsert.Parameters.AddWithValue("@TelFax", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TelFax.ToString();

            cmdTeklifInsert.ExecuteNonQuery();
            cmdTeklifInsert.Parameters.Clear();
        }

        cmdEvrakNoUpdate.ExecuteNonQuery();

        cmdStokKartiSil.Parameters.Add("@EvrakNumarasi", SqlDbType.NVarChar).Value = TeklifKayitDegiskenleri.TeklifEvrakNo.ToString();
        cmdStokKartiSil.ExecuteNonQuery();

        #region Ekranı Temizle

        txtMusteriHesapKodu.Text = null;
        txtMusteriUnvani.Text = null;
        txtMusteriUnvani1.Text = null;
        txtMusteriAdresi.Text = null;
        txtMusteriAdresi1.Text = null;
        txtMusteriAdresi2.Text = null;
        txtMusteriVergiDairesi.Text = null;

        txtBayiKodu.Text = null;
        txtBayiUnvani.Text = null;
        txtBayiUnvani1.Text = null;
        txtBayiAdresi.Text = null;
        txtBayiAdresi1.Text = null;
        txtBayiAdresi2.Text = null; ;
        txtBayiVergiDairesi.Text = null;

        txtBayiIskonto.Text = null;
        txtMusteriIskonto.Text = null;
        txtTeklifIskonto.Text = null;
        drpTeklifTuru.SelectedValue = null;

        txtTeklifiHazirlayan.Text = null;
        txtCepNo.Text = null;
        txtTelNo.Text = null;
        drpDovizCinsi.Text = null;
        txtDovizKuru.Text = null;

        txtTeklifRed1.Text = null;
        txtTeklifRed2.Text = null;

        txtTeklifSuresi.Text = null;
        txtTeslimYeri.Text = null;
        txtOdemeSekli1.Text = null;
        txtOdemeSekli2.Text = null;
        txtOdemeSekli3.Text = null;
        txtAciklama1.Text = null;
        txtAciklama2.Text = null;

        txtNot1.Text = null;
        txtNot2.Text = null;
        txtBilgiler.Text = null;
        txtUnvanAdres1.Text = null;
        txtUnvanAdres2.Text = null;
        txtUnvanAdres3.Text = null;
        txtTelefonFax.Text = null;

        #endregion

        TeklifEvrakNoGetir();

        Alert.Show("Teklifiniz Başarılı Bir Şekilde Kayıt Edilmiştir.");
    }

    private void EvrakCagiriyoruz()
    {
        string BlaserVeritabani = ConfigurationManager.ConnectionStrings["BlaserTeklifCS"].ToString();
        string LinkVeritabani = ConfigurationManager.ConnectionStrings["CsLink"].ToString();

        string[] BlaserDizi = new string[6];
        string[] BlaserDizi2 = new string[3];
        string[] LinkDizi = new string[6];
        string[] LinkDizi2 = new string[3];

        LinkDizi = LinkVeritabani.Split('=');
        LinkVeritabani = LinkDizi[2].ToString();
        LinkDizi2 = LinkVeritabani.Split(';');
        Linkdb2 = LinkDizi2[0].ToString();

        BlaserDizi = BlaserVeritabani.Split('=');
        BlaserVeritabani = BlaserDizi[2].ToString();
        BlaserDizi2 = BlaserVeritabani.Split(';');
        BlaserDb = BlaserDizi2[0].ToString();

        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        string sorgu = @"SELECT TeklifID, EvrakNumarasi, KullaniciKodu, MusteriHesapKodu, BayiHesapKodu, MalKodu, MalAdi, Birim, Miktar, Miktar2, BirimFiyat, KafileBuyuklugu, Tutar, BayiIskTutari, MusteriIskTutari, 
                      TeklifIskTutari, CONVERT(VARCHAR(10),CONVERT(DATETIME,TeklifTarihi-2),120) AS TeklifTarihi, TeklifSeriNo, 
                      CONVERT(VARCHAR(10),CONVERT(DATETIME,BitisTarihi-2),120) AS BitisTarihi, BayiIskOran, MusteriIskOran, TeklifIskOran, TeklifTuru, TeklifiHazirlayan, CepNo, TelNo, DovizCinsi, DovizKuru, TeklifDurum, TeklifRedNeden1, 
                      TeklifRedNeden2, CONVERT(VARCHAR(10),CONVERT(DATETIME,TeklifOnayTarihi-2),120) AS TeklifOnayTarihi, TeslimSuresi, TeslimYeri, OdemeSekli1, OdemeSekli2, OdemeSekli3, Aciklama1, Aciklama2, Not1, Not2, Bilgiler, BayiUnvanAdres1, BayiUnvanAdres2, 
                      BayiUnvanAdres3, TelFax,
                      C.CAR002_Unvan1 AS MusteriUnvan1,C.CAR002_Unvan2 AS MusteriUnvan2,C.CAR002_Adres1 AS MusteriAdres1,
                      C.CAR002_Adres2 AS MusteriAdres2,C.CAR002_Adres3 AS MusteriAdres3,C.CAR002_VergiDairesi AS MusteriVergiDairesi,
                      C.CAR002_VergiHesapNo AS MusteriVergiNo,
                      C1.CAR002_Unvan1 AS BayiUnvan1,C1.CAR002_Unvan2 AS BayiUnvan2,C1.CAR002_Adres1 AS BayiAdres1,
                      C1.CAR002_Adres2 AS BayiAdres2,C1.CAR002_Adres3 AS BayiAdres3,C1.CAR002_VergiDairesi AS BayiVergiDairesi,
                      C1.CAR002_VergiHesapNo AS BayiVergiNo
                      FROM " + BlaserDb + @".dbo.Teklif AS T
                      INNER JOIN " + Linkdb2 + "." + Linkdb2 + @".CAR002 AS C ON C.CAR002_HesapKodu=T.MusteriHesapKodu
                      INNER JOIN " + Linkdb2 + "." + Linkdb2 + @".CAR002 AS C1 ON C1.CAR002_HesapKodu=T.BayiHesapKodu
                      WHERE T.EvrakNumarasi='" + txtTeklifEvrakNumarasi.Text + "' AND T.KullaniciKodu='" + txtKullaniciAdi.Text + "'";

        SqlCommand cmdTeklifGetir = new SqlCommand(sorgu, DbConBlaser);
        SqlDataReader drTeklifGetir = cmdTeklifGetir.ExecuteReader();

        if (drTeklifGetir.Read())
        {
            txtMusteriHesapKodu.Text = drTeklifGetir["MusteriHesapKodu"].ToString();
            txtMusteriUnvani.Text = drTeklifGetir["MusteriUnvan1"].ToString();
            txtMusteriUnvani1.Text = drTeklifGetir["MusteriUnvan2"].ToString();
            txtMusteriAdresi.Text = drTeklifGetir["MusteriAdres1"].ToString();
            txtMusteriAdresi1.Text = drTeklifGetir["MusteriAdres2"].ToString();
            txtMusteriAdresi2.Text = drTeklifGetir["MusteriAdres3"].ToString();
            txtMusteriVergiDairesi.Text = drTeklifGetir["MusteriVergiDairesi"].ToString() + " / " + drTeklifGetir["MusteriVergiNo"].ToString();

            txtBayiKodu.Text = drTeklifGetir["BayiHesapKodu"].ToString();
            txtBayiUnvani.Text = drTeklifGetir["BayiUnvan1"].ToString();
            txtBayiUnvani1.Text = drTeklifGetir["BayiUnvan2"].ToString();
            txtBayiAdresi.Text = drTeklifGetir["BayiAdres1"].ToString();
            txtBayiAdresi1.Text = drTeklifGetir["BayiAdres2"].ToString();
            txtBayiAdresi2.Text = drTeklifGetir["BayiAdres3"].ToString();
            txtBayiVergiDairesi.Text = drTeklifGetir["BayiVergiDairesi"].ToString() + " / " + drTeklifGetir["BayiVergiNo"].ToString();

            dtTeklifTarihi.Date = Convert.ToDateTime(drTeklifGetir["TeklifTarihi"].ToString());
            dtBitisTarihi.Date = Convert.ToDateTime(drTeklifGetir["BitisTarihi"].ToString());
            txtBayiIskonto.Text = drTeklifGetir["BayiIskOran"].ToString();
            txtMusteriIskonto.Text = drTeklifGetir["MusteriIskOran"].ToString();
            txtTeklifIskonto.Text = drTeklifGetir["TeklifIskOran"].ToString();
            drpTeklifTuru.SelectedValue = drTeklifGetir["TeklifTuru"].ToString();

            txtTeklifiHazirlayan.Text = drTeklifGetir["TeklifiHazirlayan"].ToString();
            txtCepNo.Text = drTeklifGetir["CepNo"].ToString();
            txtTelNo.Text = drTeklifGetir["TelNo"].ToString();
            drpDovizCinsi.Text = drTeklifGetir["DovizCinsi"].ToString();
            txtDovizKuru.Text = drTeklifGetir["DovizKuru"].ToString();

            txtTeklifRed1.Text = drTeklifGetir["TeklifRedNeden1"].ToString();
            txtTeklifRed2.Text = drTeklifGetir["TeklifRedNeden2"].ToString();

            TeklifRedDegiskenleri.RedNeden1 = drTeklifGetir["TeklifRedNeden1"].ToString();
            TeklifRedDegiskenleri.RedNeden2 = drTeklifGetir["TeklifRedNeden2"].ToString();

            if (!IsPostBack)
            {
                if (Convert.ToInt32(drTeklifGetir["TeklifDurum"].ToString()) == 0)
                {
                    rdTeklifBeklemede.Checked = true;
                }
                else if (Convert.ToInt32(drTeklifGetir["TeklifDurum"].ToString()) == 1)
                {
                    rdTeklifOnaylandi.Checked = true;
                    TeklifOnayla.Visible = true;
                }
                else if (Convert.ToInt32(drTeklifGetir["TeklifDurum"].ToString()) == 2)
                {
                    rdTeklifRedEdildi.Checked = true;

                    txtTeklifRed1.ReadOnly = false;
                    txtTeklifRed2.ReadOnly = false;
                }
            }

            dtOnayTarihi.Date = Convert.ToDateTime(drTeklifGetir["TeklifOnayTarihi"].ToString());

            txtTeklifSuresi.Text = drTeklifGetir["TeslimSuresi"].ToString();
            txtTeslimYeri.Text = drTeklifGetir["TeslimYeri"].ToString();
            txtOdemeSekli1.Text = drTeklifGetir["OdemeSekli1"].ToString();
            txtOdemeSekli2.Text = drTeklifGetir["OdemeSekli2"].ToString();
            txtOdemeSekli3.Text = drTeklifGetir["OdemeSekli3"].ToString();
            txtAciklama1.Text = drTeklifGetir["Aciklama1"].ToString();
            txtAciklama2.Text = drTeklifGetir["Aciklama2"].ToString();

            txtNot1.Text = drTeklifGetir["Not1"].ToString();
            txtNot2.Text = drTeklifGetir["Not2"].ToString();
            txtBilgiler.Text = drTeklifGetir["Bilgiler"].ToString();
            txtUnvanAdres1.Text = drTeklifGetir["BayiUnvanAdres1"].ToString();
            txtUnvanAdres2.Text = drTeklifGetir["BayiUnvanAdres2"].ToString();
            txtUnvanAdres3.Text = drTeklifGetir["BayiUnvanAdres3"].ToString();
            txtTelefonFax.Text = drTeklifGetir["TelFax"].ToString();
        }

        drTeklifGetir.Dispose();
        drTeklifGetir.Close();
    }

    private int SeqNo()
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string sorgu = @"SELECT 
                    ISNULL((CASE 
                    WHEN MAX(STK002_SEQNo) < 2000000 THEN 2000000 ELSE MAX(STK002_SEQNo)+1 
                    END),2000000+1) AS SEQ  
                    FROM STK002 
                    WHERE (STK002_SEQNo > 2000000 AND STK002_SEQNo < 5000000)";

        SqlCommand  cmd = new SqlCommand(sorgu, DbConLink);
        cmd.CommandTimeout = 120;
        return (int)cmd.ExecuteScalar();
    }

    private string MalSeriNo(string MalKodu)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string Sorgu = @"SELECT STK004_GTIPN FROM YNS00006.STK004
                        WHERE STK004_MalKodu='" + MalKodu + "'";

        SqlCommand cmdMalSeri = new SqlCommand(Sorgu, DbConLink);
        cmdMalSeri.CommandTimeout = 120;
        return (string)cmdMalSeri.ExecuteScalar();

    }

    private int KdvOrani(string MalKodu)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string Sorgu = @"SELECT (CASE STK004_KDV
                         WHEN 1 THEN 0
                         WHEN 2 THEN 1
                         WHEN 3 THEN 8
                         WHEN 4 THEN 18
                         WHEN 5 THEN 26
                         WHEN 6 THEN 40 END) KDV FROM STK004
                         WHERE STK004_MalKodu='" + MalKodu + "'";

        SqlCommand cmdMalSeri = new SqlCommand(Sorgu, DbConLink);
        cmdMalSeri.CommandTimeout = 120;
        return (int)Convert.ToInt32(cmdMalSeri.ExecuteScalar());
    }

    private int KdvOranFlag(string MalKodu)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string sorgu = "SELECT STK004_KDV FROM STK004 WHERE STK004_MalKodu='" + MalKodu + "'";
        SqlCommand cmdKdvFlag = new SqlCommand(sorgu, DbConLink);
        cmdKdvFlag.CommandTimeout = 120;
        return (int)Convert.ToInt32(cmdKdvFlag.ExecuteScalar());
    }

    private void Car005Ekle(int FaturaTarihi, string FaturaNo, decimal MalBedeli,decimal GenelToplam,decimal NetTutar,string CHKodu, decimal Iskonto1, decimal Iskonto2,
        decimal Iskonto3, decimal KdvTutar, decimal KdvOrani, int ParaBirimi, string DovizCinsi, decimal DovizKuru, string TeslimKodu)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        decimal TotaleYaz = 0;

        string sorgu = @"INSERT INTO CAR005(CAR005_Secenek, CAR005_FaturaTarihi, CAR005_FaturaNo, CAR005_BA, CAR005_CariIslemTipi, CAR005_SatirTipi, 
                        CAR005_SatirNo, CAR005_SatirKodu, CAR005_Filler, CAR005_SatirAciklama, CAR005_CHKodu, CAR005_Tutar, CAR005_Oran, 
                        CAR005_TevkOrani, CAR005_TevkKDVOrani, CAR005_EkBilgi1, CAR005_EFaturaOTVListeNo, CAR005_EFaturaTipi, 
                        CAR005_EFaturaDonemAciklama, CAR005_EFaturaNot, CAR005_EFaturaReferansNo, CAR005_ParaBirimi, CAR005_DovizCinsi, 
                        CAR005_DovizKuru, CAR005_DovizTutari, CAR005_TeslimCHKodu, CAR005_KDVMuafAciklama, CAR005_EFaturaGonBirimEtiketi, 
                        CAR005_EFaturaAliciEtiketi, CAR005_AliciSiparisNo)
                        VALUES (5,@FaturaTarihi,@FaturaNo, N'B', 4,@SatirTipi,@SatirNo, @SatirKodu,@Filler,@SatirAciklama,@HesapKodu,@Tutar,@Oran, N'', 0, N'', N'', 0, N'', N'',
                        N'',@ParaBirimi,@DovizCinsi,@DovizKuru,@DovizTutari,@TeslimKodu, N'', N'', N'', N'')";

        SqlCommand cmdCarEkle = new SqlCommand(sorgu, DbConLink);

        int Say = 2;

        for (int i = 0; i < 11; i++)
        {
            if (i == 0)
            {
                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "Z";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 1)
            {
                if (DovizKuru == 0)
                {
                    TotaleYaz = 0;
                }
                else
                {
                    TotaleYaz = MalBedeli / DovizKuru;
                }

                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "T";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "MAL BEDELİ";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = MalBedeli;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
                TotaleYaz = 0;
            }
            if (i == 2)
            {
                if (Iskonto1 > 0)
                {
                    if (DovizKuru == 0)
                    {
                        TotaleYaz = 0;
                    }
                    else
                    {
                        TotaleYaz = Iskonto1 / DovizKuru;
                    }

                    cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                    cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                    cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "I";
                    cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                    cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "O1";
                    cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "1";
                    cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "1.İSKONTO";
                    cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                    cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = Iskonto1;
                    cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = Iskonto1;
                    cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                    cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                    cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                    cmdCarEkle.ExecuteNonQuery();
                    cmdCarEkle.Parameters.Clear();
                    Say++;
                }
            }
            if (i == 3)
            {
                if (Iskonto2 > 0)
                {
                    if (DovizKuru == 0)
                    {
                        TotaleYaz = 0;
                    }
                    else
                    {
                        TotaleYaz = Iskonto2 / DovizKuru;
                    }

                    cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                    cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                    cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "I";
                    cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                    cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "O2";
                    cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "1";
                    cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "2.İSKONTO";
                    cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                    cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = Iskonto2;
                    cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = Iskonto2;
                    cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                    cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                    cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                    cmdCarEkle.ExecuteNonQuery();
                    cmdCarEkle.Parameters.Clear();
                    Say++;
                }
            }
            if (i == 4)
            {
                if (Iskonto3 > 0)
                {
                    if (DovizKuru == 0)
                    {
                        TotaleYaz = 0;
                    }
                    else
                    {
                        TotaleYaz = Iskonto3 / DovizKuru;
                    }

                    cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                    cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                    cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "I";
                    cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                    cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "O3";
                    cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "1";
                    cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "3.İSKONTO";
                    cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                    cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = Iskonto3;
                    cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = Iskonto3;
                    cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                    cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                    cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                    cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                    cmdCarEkle.ExecuteNonQuery();
                    cmdCarEkle.Parameters.Clear();
                    Say++;
                }
            }
            if (i == 5)
            {
                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "Z";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = "";

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 6)
            {
                if (DovizKuru == 0)
                {
                    TotaleYaz = 0;
                }
                else
                {
                    TotaleYaz = NetTutar / DovizKuru;
                }

                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "N";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "NET TOPLAM";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = NetTutar;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 7)
            {
                if (DovizKuru == 0)
                {
                    TotaleYaz = 0;
                }
                else
                {
                    TotaleYaz = KdvTutar / DovizKuru;
                }

                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "K";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "1";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "KATMA DEĞER VERGİSİ";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = KdvTutar;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = KdvOrani;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 8)
            {
                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "Z";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = "";

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 9)
            {
                if (DovizKuru == 0)
                {
                    TotaleYaz = 0;
                }
                else
                {
                    TotaleYaz = GenelToplam / DovizKuru;
                }

                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "G";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "GENEL TOPLAM";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = GenelToplam;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = ParaBirimi;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = DovizCinsi;
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = DovizKuru;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = TotaleYaz;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = TeslimKodu;

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
            if (i == 10)
            {
                cmdCarEkle.Parameters.AddWithValue("@FaturaTarihi", SqlDbType.Int).Value = FaturaTarihi;
                cmdCarEkle.Parameters.AddWithValue("@FaturaNo", SqlDbType.NVarChar).Value = FaturaNo;
                cmdCarEkle.Parameters.AddWithValue("@SatirTipi", SqlDbType.NVarChar).Value = "Z";
                cmdCarEkle.Parameters.AddWithValue("@SatirNo", SqlDbType.Int).Value = Say;
                cmdCarEkle.Parameters.AddWithValue("@SatirKodu", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@Filler", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@SatirAciklama", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = CHKodu;
                cmdCarEkle.Parameters.AddWithValue("@Tutar", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@Oran", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = "";
                cmdCarEkle.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = 0;
                cmdCarEkle.Parameters.AddWithValue("@TeslimKodu", SqlDbType.NVarChar).Value = "";

                cmdCarEkle.ExecuteNonQuery();
                cmdCarEkle.Parameters.Clear();
                Say++;
            }
        }
    }

    private decimal DovizKurumuz(string HesapKodumuz, string DovizParaBirimi)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string sorgu = @"SELECT (CASE 
                        WHEN CAR002_UygulanacakFiyatTipi=1 AND CAR002_ParaBirimi='CHF' THEN CHF_Alis
                        WHEN CAR002_UygulanacakFiyatTipi=2 AND CAR002_ParaBirimi='CHF' THEN CHF_Satis
                        WHEN CAR002_UygulanacakFiyatTipi=3 AND CAR002_ParaBirimi='CHF' THEN CHF_EfektifAlis
                        WHEN CAR002_UygulanacakFiyatTipi=4 AND CAR002_ParaBirimi='CHF' THEN CHF_EfektifSatis
                        WHEN CAR002_UygulanacakFiyatTipi=1 AND CAR002_ParaBirimi='EUR' THEN EUR_Alis
                        WHEN CAR002_UygulanacakFiyatTipi=2 AND CAR002_ParaBirimi='EUR' THEN EUR_Satis
                        WHEN CAR002_UygulanacakFiyatTipi=3 AND CAR002_ParaBirimi='EUR' THEN EUR_EfektifAlis
                        WHEN CAR002_UygulanacakFiyatTipi=4 AND CAR002_ParaBirimi='EUR' THEN EUR_EfektifSatis
                        WHEN CAR002_UygulanacakFiyatTipi=1 AND CAR002_ParaBirimi='USD' THEN USD_Alis
                        WHEN CAR002_UygulanacakFiyatTipi=2 AND CAR002_ParaBirimi='USD' THEN USD_Satis
                        WHEN CAR002_UygulanacakFiyatTipi=3 AND CAR002_ParaBirimi='USD' THEN USD_EfektifAlis
                        WHEN CAR002_UygulanacakFiyatTipi=4 AND CAR002_ParaBirimi='USD' THEN USD_EfektifSatis
                        ELSE 0 END) AS DovizKuru FROM 
                        (SELECT TOP(1) DVZ002_DvzAlis1 AS CHF_Alis,DVZ002_DvzSatis1 AS CHF_Satis,
                        DVZ002_DvzEfektifAlis1 AS CHF_EfektifAlis,DVZ002_DvzEfektisSatis1 AS CHF_EfektifSatis,
                        DVZ002_DvzAlis2 AS EUR_Alis,DVZ002_DvzSatis2 AS EUR_Satis,DVZ002_DvzEfektifAlis2 AS EUR_EfektifAlis,
                        DVZ002_DvzEfektisSatis2 AS EUR_EfektifSatis,DVZ002_DvzAlis3 AS USD_Alis,DVZ002_DvzSatis3 AS USD_Satis,
                        DVZ002_DvzEfektifAlis3 AS USD_EfektifAlis,DVZ002_DvzEfektisSatis3 AS USD_EfektifSatis FROM DVZ002
                        INNER JOIN CAR002 ON CAR002_HesapKodu='" + HesapKodumuz + "' AND CAR002_ParaBirimi='" + DovizParaBirimi + "' " +
                        "ORDER BY DVZ002_Row_ID DESC) AS TBL " +
                        "INNER JOIN CAR002 ON CAR002_HesapKodu='" + HesapKodumuz + "' AND CAR002_ParaBirimi='" + DovizParaBirimi + "'";

        SqlCommand cmdDovizKuru = new SqlCommand(sorgu, DbConLink);
        cmdDovizKuru.CommandTimeout = 120;
        return (decimal)Convert.ToDecimal(cmdDovizKuru.ExecuteScalar());
    }

    private string ParaBirimi(string HesapKodu)
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        string sorgu = "SELECT CAR002_ParaBirimi FROM CAR002 WHERE CAR002_HesapKodu='" + HesapKodu + "'";

        SqlCommand cmdParaBirimi = new SqlCommand(sorgu, DbConLink);
        cmdParaBirimi.CommandTimeout = 120;
        return (string)cmdParaBirimi.ExecuteScalar();
    }

    public void SiparisOnayla(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Evet")
        {
            TeklifimiOnayla();
        }
    }

    public void TeklifRed(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Evet")
        {
            TeklifRed();
        }
    }

    private void TeklifimiOnayla()
    {
        if (DbConLink.State == ConnectionState.Closed)
            DbConLink.Open();

        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        string StkEkle = @"INSERT INTO STK002(STK002_MalKodu, STK002_IslemTarihi, STK002_GC, STK002_CariHesapKodu, STK002_EvrakSeriNo, STK002_Miktari, STK002_BirimFiyati, STK002_Tutari, STK002_Iskonto, 
                      STK002_KDVTutari, STK002_IslemTipi, STK002_Kod1, STK002_Kod2, STK002_IrsaliyeNo, STK002_TeslimMiktari, STK002_SipDurumu, STK002_Bos, STK002_KDVDurumu, STK002_TeslimTarihi, 
                      STK002_ParaBirimi, STK002_SEQNo, STK002_GirenKaynak, STK002_GirenTarih, STK002_GirenSaat, STK002_GirenKodu, STK002_GirenSurum, STK002_DegistirenKaynak, STK002_DegistirenTarih, 
                      STK002_DegistirenSaat, STK002_DegistirenKodu, STK002_DegistirenSurum, STK002_IptalDurumu, STK002_AsilEvrakTarihi, STK002_Miktar2, STK002_Tutar2, STK002_KalemIskontoOrani1, 
                      STK002_KalemIskontoOrani2, STK002_KalemIskontoOrani3, STK002_KalemIskontoOrani4, STK002_KalemIskontoOrani5, STK002_KalemIskontoTutari1, STK002_KalemIskontoTutari2, 
                      STK002_KalemIskontoTutari3, STK002_KalemIskontoTutari4, STK002_KalemIskontoTutari5, STK002_DovizCinsi, STK002_DovizTutari, STK002_DovizKuru, STK002_Aciklama1, STK002_Aciklama2, 
                      STK002_Depo, STK002_Kod3, STK002_Kod4, STK002_Kod5, STK002_Kod6, STK002_Kod7, STK002_Kod8, STK002_Kod9, STK002_Kod10, STK002_Kod11, STK002_Kod12, STK002_Vasita, 
                      STK002_MalSeriNo, STK002_VadeTarihi, STK002_Masraf, STK002_EvrakSeriNo2, STK002_Tarih2, STK002_Kod9Flag, STK002_Kod10Flag,STK002_KDVOranFlag, STK002_TeslimCHKodu, STK002_SonSevkTarihi)
                      VALUES (@MalKodu,@IslemTarihi, 1,@HesapKodu,@EvrakNumarasi,@Miktar,@BirimFiyati,@Tutari,0,@KdvTutari, 2, N'', N'True', N'', 0, 0, N'', 
                      0,@TeslimTarihi,@ParaBirimi,@SEQNo,@GirenKaynak,@GirenTarih,@GirenSaat,@GirenKodu, N'5.1.10',@GirenKaynak,@GirenTarih,@GirenSaat,@GirenKodu, N'5.1.10', 1,@IslemTarihi,@Miktar2, 
                      0,@BayiIskontoOrani,@MusteriIskontoOrani,@TeklifIskontoOrani, 0, 0,@BayiIskontoTutari,@MusteriIskontoTutari,@TeklifIskontoTutari, 0, 
                      0,@DovizCinsi,@DovizTutari,@DovizKuru,@Aciklama1,@Aciklama2, N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, 0, N'',@MalSeriNo,@IslemTarihi, 0, N'', 0, 0, 0,@KDVOranFlag, @TeslimCHKodu, 0)";

        SqlCommand cmdStk = new SqlCommand(StkEkle, DbConLink);

        #region Sipariş Evrak Numarası ve Teklif Durum Güncelleme Bölümü

        string TeklifDurumUps = "spTeklifDurumGuncelle";
        SqlCommand cmdTeklifDurums = new SqlCommand(TeklifDurumUps, DbConBlaser);
        cmdTeklifDurums.CommandType = CommandType.StoredProcedure;

        string SiparisEvrakUps = "spSiparisEvrakNoGuncelle";
        SqlCommand cmdSipEvrak = new SqlCommand(SiparisEvrakUps, DbConBlaser);
        cmdSipEvrak.CommandType = CommandType.StoredProcedure;

        #endregion

        #region Teklif Çağırıyoruz

        string TeklifCagir = @"SELECT * FROM Teklif
                               WHERE EvrakNumarasi='" + txtTeklifEvrakNumarasi.Text + "' AND KullaniciKodu='" + txtKullaniciAdi.Text + "'";

        SqlCommand cmdTeklifCagir = new SqlCommand(TeklifCagir, DbConBlaser);
        SqlDataReader drTeklifCagir = cmdTeklifCagir.ExecuteReader();

        while (drTeklifCagir.Read())
        {
            TeklifNumaramiz += drTeklifCagir["EvrakNumarasi"].ToString() + ",";
            TeklifKullaniciAdimiz += drTeklifCagir["KullaniciKodu"].ToString() + ",";
            Miktar += drTeklifCagir["Miktar"].ToString().Replace(',', '.') + ",";
            Miktar2 += drTeklifCagir["Miktar2"].ToString().Replace(',', '.') + ",";
            BirimFiyat += drTeklifCagir["BirimFiyat"].ToString().Replace(',', '.') + ",";
            Tutar += drTeklifCagir["Tutar"].ToString().Replace(',', '.') + ",";
            MalKodu += drTeklifCagir["MalKodu"].ToString() + ",";
            HesapKodu += drTeklifCagir["MusteriHesapKodu"].ToString() + ",";
            BayiHesapKodu += drTeklifCagir["BayiHesapKodu"].ToString() + ",";
            BayiIskontoOrani += drTeklifCagir["BayiIskOran"].ToString().Replace(',', '.') + ",";
            MusteriIskontoOrani += drTeklifCagir["MusteriIskOran"].ToString().Replace(',', '.') + ",";
            TeklifIskontoOrani += drTeklifCagir["TeklifIskOran"].ToString().Replace(',', '.') + ",";
            BayiIskontoTutari += drTeklifCagir["BayiIskTutari"].ToString().Replace(',', '.') + ",";
            MusteriIskontoTutari += drTeklifCagir["MusteriIskTutari"].ToString().Replace(',', '.') + ",";
            TeklifIskontoTutari += drTeklifCagir["TeklifIskTutari"].ToString().Replace(',', '.') + ",";
            DovizCinsi += drTeklifCagir["DovizCinsi"].ToString() + ",";
            DovizKuru += drTeklifCagir["DovizKuru"].ToString().Replace(',', '.') + ",";

            if (!string.IsNullOrEmpty(drTeklifCagir["Aciklama1"].ToString()))
            {
                Aciklama1 += drTeklifCagir["Aciklama1"].ToString() + ",";
            }
            else
            {
                Aciklama1 += " " + ",";
            }
            if (!string.IsNullOrEmpty(drTeklifCagir["Aciklama2"].ToString()))
            {
                Aciklama2 += drTeklifCagir["Aciklama2"].ToString() + ",";
            }
            else
            {
                Aciklama2 += " " + ",";
            }
        }

        drTeklifCagir.Dispose();
        drTeklifCagir.Close();


        TeklifNumaramiz = TeklifNumaramiz.TrimEnd(',');
        TeklifKullaniciAdimiz = TeklifKullaniciAdimiz.TrimEnd(',');
        Miktar = Miktar.TrimEnd(',');
        Miktar2 = Miktar2.TrimEnd(',');
        BirimFiyat = BirimFiyat.TrimEnd(',');
        Tutar = Tutar.TrimEnd(',');
        MalKodu = MalKodu.TrimEnd(',');
        HesapKodu = HesapKodu.TrimEnd(',');
        BayiHesapKodu = BayiHesapKodu.TrimEnd(',');
        BayiIskontoOrani = BayiIskontoOrani.TrimEnd(',');
        MusteriIskontoOrani = MusteriIskontoOrani.TrimEnd(',');
        TeklifIskontoOrani = TeklifIskontoOrani.TrimEnd(',');
        BayiIskontoTutari = BayiIskontoTutari.TrimEnd(',');
        MusteriIskontoTutari = MusteriIskontoTutari.TrimEnd(',');
        TeklifIskontoTutari = TeklifIskontoTutari.TrimEnd(',');
        DovizCinsi = DovizCinsi.TrimEnd(',');
        DovizKuru = DovizKuru.TrimEnd(',');
        Aciklama1 = Aciklama1.TrimEnd(',');
        Aciklama2 = Aciklama2.TrimEnd(',');

        DiziTeklifNumaramiz = TeklifNumaramiz.Split(',');
        DiziTeklifKullaniciAdimiz = TeklifKullaniciAdimiz.Split(',');
        DiziMiktar = Miktar.Split(',');
        DiziMiktar2 = Miktar2.Split(',');
        DiziBirimFiyat = BirimFiyat.Split(',');
        DiziTutar = Tutar.Split(',');
        DiziMalKodu = MalKodu.Split(',');
        DiziHesapKodu = HesapKodu.Split(',');
        DiziBayiHesapKodu = BayiHesapKodu.Split(',');
        DiziBayiIskontoOrani = BayiIskontoOrani.Split(',');
        DiziMusteriIskontoOrani = MusteriIskontoOrani.Split(',');
        DiziTeklifIskontoOrani = TeklifIskontoOrani.Split(',');
        DiziBayiIskontoTutari = BayiIskontoTutari.Split(',');
        DiziMusteriIskontoTutari = MusteriIskontoTutari.Split(',');
        DiziTeklifIskontoTutari = TeklifIskontoTutari.Split(',');
        DiziDovizCinsi = DovizCinsi.Split(',');
        DiziDovizKuru = DovizKuru.Split(',');
        DiziAciklama1 = Aciklama1.Split(',');
        DiziAciklama2 = Aciklama2.Split(',');

        #endregion

        #region Sipariş Numarasını Alıyoruz

        string SiparisSorgu = @"SELECT EvrakSeri,EvrakNo FROM tblEvrakSeriNo WHERE EvrakTipiStr='Sipariş'";
        SqlCommand cmdSiparis = new SqlCommand(SiparisSorgu, DbConBlaser);
        SqlDataReader drSiparis = cmdSiparis.ExecuteReader(CommandBehavior.CloseConnection);

        string SiparisEvrakNo = "";
        string SiparisEvrakSeri = "";

        if (drSiparis.Read())
        {
            SiparisEvrakNo = drSiparis["EvrakNo"].ToString();
            SiparisEvrakSeri = drSiparis["EvrakSeri"].ToString();
        }

        drSiparis.Dispose();
        drSiparis.Close();

        SiparisEvrakNo = SiparisEvrakNo.PadLeft(6, '0');
        SiparisEvrakSeri = SiparisEvrakSeri + " " + SiparisEvrakNo;

        StkKayitDegiskenleri.EvrakNumarasi = SiparisEvrakSeri.TrimStart(' ');

        #endregion

        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();

        for (int i = 0; i < DiziTeklifNumaramiz.Length; i++)
        {
            StkKayitDegiskenleri.SEQNo = SeqNo();

            StkKayitDegiskenleri.MalKodu = DiziMalKodu[i].ToString();
            StkKayitDegiskenleri.HesapKodu = DiziHesapKodu[i].ToString();
            StkKayitDegiskenleri.TeslimKodu = DiziBayiHesapKodu[i].ToString();
            StkKayitDegiskenleri.GirenKaynak = "Y6016";
            StkKayitDegiskenleri.GirenKodu = DiziTeklifKullaniciAdimiz[i].ToString();

            #region Tarih ve Saat İşlemleri

            DateTime DtSaat = DateTime.Now;
            StkKayitDegiskenleri.GirenSaat = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

            if (StkKayitDegiskenleri.GirenSaat.ToString().Length == 18)
            {
                StkKayitDegiskenleri.GirenSaat = StkKayitDegiskenleri.GirenSaat.ToString().Substring(10, 8);
            }
            else if (StkKayitDegiskenleri.GirenSaat.ToString().Length == 19)
            {
                StkKayitDegiskenleri.GirenSaat = StkKayitDegiskenleri.GirenSaat.ToString().Substring(11, 8);
            }
            StkKayitDegiskenleri.GirenSaat = StkKayitDegiskenleri.GirenSaat.ToString().Replace(":", "");

            if (StkKayitDegiskenleri.GirenSaat.ToString().Length > 8)
            {
                StkKayitDegiskenleri.GirenSaat = StkKayitDegiskenleri.GirenSaat.ToString().Substring(0, 8);
            }

            DateTime objIslemTarihi = new DateTime();
            objIslemTarihi = DateTime.Now;
            string strIslemTarihi;
            double IslemTarihi = 0;
            IslemTarihi = objIslemTarihi.ToOADate();
            strIslemTarihi = IslemTarihi.ToString().Substring(0, 5);
            StkKayitDegiskenleri.IslemTarihi = Convert.ToInt32(strIslemTarihi);
            StkKayitDegiskenleri.GirenTarih = StkKayitDegiskenleri.IslemTarihi;
            StkKayitDegiskenleri.TeslimTarihi = StkKayitDegiskenleri.IslemTarihi;

            #endregion

            StkKayitDegiskenleri.Aciklama1 = DiziAciklama1[i].ToString();
            StkKayitDegiskenleri.Aciklama2 = DiziAciklama2[i].ToString();
            StkKayitDegiskenleri.MalSeriNo = MalSeriNo(DiziMalKodu[i].ToString());
            StkKayitDegiskenleri.Miktar = Convert.ToDecimal(DiziMiktar[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.Miktar2 = Convert.ToDecimal(DiziMiktar2[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.BirimFiyati = Convert.ToDecimal(DiziBirimFiyat[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.Tutari = Convert.ToDecimal(DiziTutar[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.KdvOranFlag = KdvOranFlag(DiziMalKodu[i].ToString());

            if (DiziDovizCinsi[i].ToString() != "TL")
            {
                StkKayitDegiskenleri.ParaBirimi = "2";
                StkKayitDegiskenleri.DovizCinsi = DiziDovizCinsi[i].ToString();
                StkKayitDegiskenleri.DovizKuru = Convert.ToDecimal(DiziDovizKuru[i].ToString().Replace('.', ','));
                StkKayitDegiskenleri.DovizTutari = StkKayitDegiskenleri.Tutari / StkKayitDegiskenleri.DovizKuru;
            }
            else
            {
                StkKayitDegiskenleri.ParaBirimi = "1";
                StkKayitDegiskenleri.DovizCinsi = "";
                StkKayitDegiskenleri.DovizKuru = 0;
                StkKayitDegiskenleri.DovizTutari = 0;
            }

            StkKayitDegiskenleri.BayiIskontoOrani = Convert.ToDecimal(DiziBayiIskontoOrani[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.MusteriIskontoOrani = Convert.ToDecimal(DiziMusteriIskontoOrani[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.TeklifIskontoOrani = Convert.ToDecimal(DiziTeklifIskontoOrani[i].ToString().Replace('.', ','));
            StkKayitDegiskenleri.KdvOrani = Convert.ToDecimal(KdvOrani(DiziMalKodu[i].ToString()));

            #region İskonto Tutarlarını Hesaplıyoruz

            if (StkKayitDegiskenleri.BayiIskontoOrani > 0)
            {
                StkKayitDegiskenleri.BayiIskontoTutari = (StkKayitDegiskenleri.Tutari * StkKayitDegiskenleri.BayiIskontoOrani) / 100;
            }
            else
            {
                StkKayitDegiskenleri.BayiIskontoTutari = 0;
            }

            if (StkKayitDegiskenleri.MusteriIskontoOrani > 0)
            {
                StkKayitDegiskenleri.MusteriIskontoTutari = ((StkKayitDegiskenleri.Tutari - StkKayitDegiskenleri.BayiIskontoTutari) * StkKayitDegiskenleri.MusteriIskontoOrani) / 100;
            }
            else
            {
                StkKayitDegiskenleri.MusteriIskontoTutari = 0;
            }

            if (StkKayitDegiskenleri.TeklifIskontoOrani > 0)
            {
                StkKayitDegiskenleri.TeklifIskontoTutari = ((StkKayitDegiskenleri.Tutari - StkKayitDegiskenleri.MusteriIskontoTutari) * StkKayitDegiskenleri.MusteriIskontoOrani) / 100;
            }
            else
            {
                StkKayitDegiskenleri.TeklifIskontoTutari = 0;
            }

            StkKayitDegiskenleri.KdvTutari = (((StkKayitDegiskenleri.Tutari - (StkKayitDegiskenleri.BayiIskontoTutari +
                StkKayitDegiskenleri.MusteriIskontoTutari + StkKayitDegiskenleri.TeklifIskontoTutari)) * StkKayitDegiskenleri.KdvOrani) / 100);

            #endregion

            #region Car005 Parametreleri

            StkKayitDegiskenleri.Genelisk1 = StkKayitDegiskenleri.Genelisk1 + StkKayitDegiskenleri.BayiIskontoTutari;
            StkKayitDegiskenleri.Genelisk2 = StkKayitDegiskenleri.Genelisk2 + StkKayitDegiskenleri.MusteriIskontoTutari;
            StkKayitDegiskenleri.Genelisk3 = StkKayitDegiskenleri.Genelisk3 + StkKayitDegiskenleri.TeklifIskontoTutari;
            StkKayitDegiskenleri.GenelKdvTutar = StkKayitDegiskenleri.GenelKdvTutar + StkKayitDegiskenleri.KdvTutari;
            StkKayitDegiskenleri.GenelMalBedeli = StkKayitDegiskenleri.GenelMalBedeli + StkKayitDegiskenleri.Tutari;
            StkKayitDegiskenleri.GenelNetTutar = StkKayitDegiskenleri.GenelMalBedeli - (StkKayitDegiskenleri.Genelisk1 + StkKayitDegiskenleri.Genelisk2 + StkKayitDegiskenleri.Genelisk3);
            StkKayitDegiskenleri.GenelToplam = StkKayitDegiskenleri.GenelNetTutar + StkKayitDegiskenleri.GenelKdvTutar;
            StkKayitDegiskenleri.GenelKdvOran = StkKayitDegiskenleri.KdvOrani;
            StkKayitDegiskenleri.GenelDovizKuru = StkKayitDegiskenleri.DovizKuru;

            #endregion

            #region STK002 Insert Parametreleri

            cmdStk.Parameters.AddWithValue("@MalKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.MalKodu.ToString();
            cmdStk.Parameters.AddWithValue("@IslemTarihi", SqlDbType.Int).Value = StkKayitDegiskenleri.IslemTarihi;
            cmdStk.Parameters.AddWithValue("@HesapKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.HesapKodu.ToString();
            cmdStk.Parameters.AddWithValue("@EvrakNumarasi", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.EvrakNumarasi.ToString();
            cmdStk.Parameters.AddWithValue("@Miktar", SqlDbType.Decimal).Value = StkKayitDegiskenleri.Miktar.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@BirimFiyati", SqlDbType.Decimal).Value = StkKayitDegiskenleri.BirimFiyati.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@Tutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.Tutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@KdvTutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.KdvTutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@TeslimTarihi", SqlDbType.Int).Value = StkKayitDegiskenleri.TeslimTarihi;
            cmdStk.Parameters.AddWithValue("@ParaBirimi", SqlDbType.Int).Value = StkKayitDegiskenleri.ParaBirimi.ToString();
            cmdStk.Parameters.AddWithValue("@SEQNo", SqlDbType.Int).Value = StkKayitDegiskenleri.SEQNo;
            cmdStk.Parameters.AddWithValue("@GirenKaynak", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.GirenKaynak.ToString();
            cmdStk.Parameters.AddWithValue("@GirenTarih", SqlDbType.Int).Value = StkKayitDegiskenleri.GirenTarih;
            cmdStk.Parameters.AddWithValue("@GirenSaat", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.GirenSaat.ToString();
            cmdStk.Parameters.AddWithValue("@GirenKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.GirenKodu.ToString();
            cmdStk.Parameters.AddWithValue("@Miktar2", SqlDbType.Decimal).Value = StkKayitDegiskenleri.Miktar2.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@BayiIskontoOrani", SqlDbType.Decimal).Value = StkKayitDegiskenleri.BayiIskontoOrani.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@MusteriIskontoOrani", SqlDbType.Decimal).Value = StkKayitDegiskenleri.MusteriIskontoOrani.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@TeklifIskontoOrani", SqlDbType.Decimal).Value = StkKayitDegiskenleri.TeklifIskontoOrani.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@BayiIskontoTutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.BayiIskontoTutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@MusteriIskontoTutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.MusteriIskontoTutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@TeklifIskontoTutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.TeklifIskontoTutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@DovizCinsi", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.DovizCinsi.ToString();
            cmdStk.Parameters.AddWithValue("@DovizTutari", SqlDbType.Decimal).Value = StkKayitDegiskenleri.DovizTutari.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@DovizKuru", SqlDbType.Decimal).Value = StkKayitDegiskenleri.DovizKuru.ToString().Replace(',', '.');
            cmdStk.Parameters.AddWithValue("@Aciklama1", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.Aciklama1.ToString();
            cmdStk.Parameters.AddWithValue("@Aciklama2", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.Aciklama2.ToString();
            cmdStk.Parameters.AddWithValue("@MalSeriNo", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.MalSeriNo.ToString();
            cmdStk.Parameters.AddWithValue("@KDVOranFlag", SqlDbType.Int).Value = StkKayitDegiskenleri.KdvOranFlag;
            cmdStk.Parameters.AddWithValue("@TeslimCHKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.TeslimKodu.ToString();

            cmdStk.ExecuteNonQuery();
            cmdStk.Parameters.Clear();

            #endregion

            cmdTeklifDurums.Parameters.AddWithValue("@EvrakNumarasi", SqlDbType.NVarChar).Value = DiziTeklifNumaramiz[i].ToString();
            cmdTeklifDurums.Parameters.AddWithValue("@KullaniciKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.GirenKodu.ToString();
            cmdTeklifDurums.Parameters.AddWithValue("@MalKodu", SqlDbType.NVarChar).Value = StkKayitDegiskenleri.MalKodu.ToString();
            cmdTeklifDurums.Parameters.AddWithValue("@TeklifDurum", SqlDbType.NVarChar).Value = "1";
            cmdTeklifDurums.ExecuteNonQuery();
            cmdTeklifDurums.Parameters.Clear();
        }

        cmdSipEvrak.ExecuteNonQuery();

        Car005Ekle(StkKayitDegiskenleri.IslemTarihi, StkKayitDegiskenleri.EvrakNumarasi.ToString(), StkKayitDegiskenleri.GenelMalBedeli, StkKayitDegiskenleri.GenelToplam,
            StkKayitDegiskenleri.GenelNetTutar, StkKayitDegiskenleri.HesapKodu, StkKayitDegiskenleri.Genelisk1, StkKayitDegiskenleri.Genelisk2, StkKayitDegiskenleri.Genelisk3,
            StkKayitDegiskenleri.GenelKdvTutar, StkKayitDegiskenleri.GenelKdvOran, Convert.ToInt32(StkKayitDegiskenleri.ParaBirimi), StkKayitDegiskenleri.DovizCinsi,
            StkKayitDegiskenleri.DovizKuru, StkKayitDegiskenleri.TeslimKodu);

        AcilisEvrakNumarasiBul();

        Alert.Show("Seçtiğiniz Teklif Başarılı Bir Şekilde Siparişe Çevrilmiştir.");
    }

    private void TeklifRed()
    {
        if (DbConBlaser.State == ConnectionState.Closed)
            DbConBlaser.Open();


        TeklifRedDegiskenleri.RedNeden1 = Request.Form[txtTeklifRed1.UniqueID].ToString();
        TeklifRedDegiskenleri.RedNeden2 = Request.Form[txtTeklifRed2.UniqueID].ToString();
        TeklifRedDegiskenleri.EvrakNumarasi = txtTeklifEvrakNumarasi.Text.ToString();

        string sorgu = "spTeklifRedGuncelle";
        SqlCommand cmdRedUp = new SqlCommand(sorgu, DbConBlaser);
        cmdRedUp.CommandType = CommandType.StoredProcedure;
        cmdRedUp.Parameters.AddWithValue("@RedNeden1", SqlDbType.NVarChar).Value = TeklifRedDegiskenleri.RedNeden1.ToString();
        cmdRedUp.Parameters.AddWithValue("@RedNeden2", SqlDbType.NVarChar).Value = TeklifRedDegiskenleri.RedNeden2.ToString();
        cmdRedUp.Parameters.AddWithValue("@EvrakNumarasi", SqlDbType.NVarChar).Value = TeklifRedDegiskenleri.EvrakNumarasi.ToString();
        cmdRedUp.ExecuteNonQuery();

        AcilisEvrakNumarasiBul();

        Alert.Show("Teklif Başarılı Bir Şekilde Red Edilmiştir.");

    }

    protected void btnYenile_Click(object sender, EventArgs e)
    {
        txtMusteriHesapKodu.Text = null;
        txtMusteriUnvani.Text = null;
        txtMusteriUnvani1.Text = null;
        txtMusteriAdresi.Text = null;
        txtMusteriAdresi1.Text = null;
        txtMusteriAdresi2.Text = null;
        txtMusteriVergiDairesi.Text = null;

        txtBayiKodu.Text = null;
        txtBayiUnvani.Text = null;
        txtBayiUnvani1.Text = null;
        txtBayiAdresi.Text = null;
        txtBayiAdresi1.Text = null;
        txtBayiAdresi2.Text = null; ;
        txtBayiVergiDairesi.Text = null;

        txtBayiIskonto.Text = null;
        txtMusteriIskonto.Text = null;
        txtTeklifIskonto.Text = null;
        drpTeklifTuru.SelectedValue = null;

        txtTeklifiHazirlayan.Text = null;
        txtCepNo.Text = null;
        txtTelNo.Text = null;
        drpDovizCinsi.Text = null;
        txtDovizKuru.Text = null;

        txtTeklifRed1.Text = null;
        txtTeklifRed2.Text = null;

        txtTeklifSuresi.Text = null;
        txtTeslimYeri.Text = null;
        txtOdemeSekli1.Text = null;
        txtOdemeSekli2.Text = null;
        txtOdemeSekli3.Text = null;
        txtAciklama1.Text = null;
        txtAciklama2.Text = null;

        txtNot1.Text = null;
        txtNot2.Text = null;
        txtBilgiler.Text = null;
        txtUnvanAdres1.Text = null;
        txtUnvanAdres2.Text = null;
        txtUnvanAdres3.Text = null;
        txtTelefonFax.Text = null;
    }
}