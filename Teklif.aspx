<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Teklif.aspx.cs" Inherits="Teklif" %>
<%@ Register assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>











<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        // <![CDATA[       
        function txtMusteriHesapKodu_RowClick(s, e) {
            var gridview = ASPxClientGridView.Cast(s);
            gridview.GetRowValues(e.visibleIndex, "HesapKodu;Unvan1;Unvan2;Adres1;Adres2;Adres3;VergiDairesi;VergiHesapNo;Kod8;Telefon1", OnGetRowValues);
        }
        function OnGetRowValues(values) {
            //txtMusteriHesapKodu.SetText("");
            txtMusteriUnvani.SetText(values[1]);
            txtMusteriUnvani1.SetText(values[2]);
            txtMusteriAdresi.SetText(values[3]);
            txtMusteriAdresi1.SetText(values[4]);
            txtMusteriAdresi2.SetText(values[5]);
            txtMusteriVergiDairesi.SetText(values[6] + "/ " + values[7]);
            txtTelefonFax.SetText(values[9]);
            txtDovizKuru.SetText(values[8]);
        }


        function txtBayiKodu_RowClick(s, e) {
            var gridview = ASPxClientGridView.Cast(s);
            gridview.GetRowValues(e.visibleIndex, "HesapKodu;Unvan1;Unvan2;Adres1;Adres2;Adres3;VergiDairesi;VergiHesapNo", OnGetRowValues1);
        }
        function OnGetRowValues1(values) {
            //txtMusteriHesapKodu.SetText("");
            txtBayiUnvani.SetText(values[1]);
            txtBayiUnvani1.SetText(values[2]);
            txtBayiAdresi.SetText(values[3]);
            txtBayiAdresi1.SetText(values[4]);
            txtBayiAdresi2.SetText(values[5]);
            txtBayiVergiDairesi.SetText(values[6] + "/ " + values[7]);
            txtUnvanAdres1.SetText(values[3]);
            txtUnvanAdres2.SetText(values[4]);
            txtUnvanAdres3.SetText(values[5]);
        }

        //Mal Kodları Lookup Tarafı
        function MalKodu_RowClick(s, e) {
            //var gridview = ASPxClientGridView.Cast(s);
            var gridview = ASPxClientGridView.Cast(s);
            gridview.GetRowValues(e.visibleIndex, "MalID;MalKodu;MalAdi;Birim;Miktar;Miktar2;KafileBuyuklugu;BirimFiyat", GridicindeMalAdiAl);
        }
        function GridicindeMalAdiAl(values) {
            txtKullaniciKodu.SetText('<%= Session["KullaniciKodu"] %>');
            txtStokKodu.SetText(values[1]);
            txtMalAdi.SetText(values[2]);
            txtBirim.SetText(values[3]);
            txtMiktar2.SetText(values[5]);
            txtKafileBuyuklugu.SetText(values[6]);
        }

        function OdemeSekli_RowClick(s, e) {
            var gridview = ASPxClientGridView.Cast(s);
            gridview.GetRowValues(e.visibleIndex,"ID;Aciklama",GridicindeAciklamaAl);
        }
        function GridicindeAciklamaAl(values) {
            txtOdemeSekli2.SetText(values[1]);
        }

    // ]]> 
    </script>
 
    <script type = "text/javascript">
        function SiparisOnayla() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Seçtiğiniz Teklif Sipariş Olarak Kaydedilecektir.Bu işlemi Onaylıyor musunuz?")) {
                confirm_value.value = "Evet";
            } else {
                confirm_value.value = "Hayır";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function TeklifRed() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Seçtiğiniz Teklif Red Olarak Kaydedilecektir.Bu işlemi Onaylıyor musunuz?")) {
                confirm_value.value = "Evet";
            } else {
                confirm_value.value = "Hayır";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <asp:Panel ID="Panel1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>						
                <dx:ASPxPageControl ID="pageTabControl" runat="server" ActiveTabIndex="0" 
                    Height="220px" Width="865px" TabAlign="Justify" TabPosition="Bottom">
                    <TabPages>
                        <dx:TabPage Text="Müşteri- Teklif Bilgileri">
                            <ActiveTabStyle BackColor="#66FF99" Font-Bold="True">
                            </ActiveTabStyle>
                            <TabStyle Font-Bold="True">
                            </TabStyle>
                            <ContentCollection>
                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                    <table style="width:100%;">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:Label ID="lblMusteriBilgileri" runat="server" Font-Bold="True" 
                                                    Text="Müşteri Bilgileri" BackColor="Silver" Width="100%"></asp:Label></center> 
                                            </td>
                                            
                                            <td colspan="2">
                                                <center><asp:Label ID="lblBayiBilgileri" runat="server" Font-Bold="True" 
                                                        Text="Bayi Bilgileri" BackColor="Silver" BorderColor="White" BorderWidth="1px" 
                                                        Width="98%"></asp:Label></center>
                                            </td>
                                             <td colspan="2">
                                                <center><asp:Label ID="lblTarihIslemleri" runat="server" Font-Bold="True" 
                                                        Text="İşlemler" BackColor="Silver" Width="100%"></asp:Label></center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 14px;">
                                                &nbsp;
                                                <asp:Label ID="lblHesapKodu" runat="server" Font-Bold="True" Text="Hesap Kodu"></asp:Label>
                                            </td>
                                            <td style="width: 167px; height: 14px;">
                                                <asp:SqlDataSource ID="DsMusteri" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:CsLink %>" 
                                                    SelectCommand="SELECT CAR002_Row_ID AS ID, CAR002_HesapKodu AS HesapKodu, CAR002_Unvan1 AS Unvan1, 
                                                    CAR002_Unvan2 AS Unvan2, CAR002_Adres1 AS Adres1, CAR002_Adres2 AS Adres2, CAR002_Adres3 AS Adres3, 
                                                    CAR002_VergiDairesi AS VergiDairesi, CAR002_VergiHesapNo AS VergiHesapNo, CAR002_Telefon1 AS Telefon1, 
                                                    CAR002_BolgeKodu AS BolgeKodu, CAR002_GrupKodu AS GrupKodu, CAR002_Fax AS Fax, CAR002_Kod1 AS Kod1, 
                                                    CAR002_Kod2 AS Kod2, CAR002_Kod3 AS Kod3, CAR002_Kod4 AS Kod4, CAR002_Kod5 AS Kod5, CAR002_Kod6 AS Kod6, 
                                                    CAR002_Kod7 AS Kod7, CAR002_Kod8 AS Kod8, CAR002_Kod9 AS Kod9,CAR002_ParaBirimi AS ParaBirimi FROM CAR002 AS c">
                                                </asp:SqlDataSource>
                                                <dx:ASPxGridLookup ID="txtMusteriHesapKodu" runat="server" 
                                                    AutoGenerateColumns="False" DataSourceID="DsMusteri" KeyFieldName="ID"  TextFormatString="{1}" 
                                                    IncrementalFilteringMode="StartsWith" Width="100%" 
                                                    ClientInstanceName="txtMusteriHesapKodu" 
                                                    OnValueChanged="txtMusteriHesapKodu_ValueChanged">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterBar="Visible" ShowFilterRow="True" />
                                                    </GridViewProperties>
                                                    <GridViewClientSideEvents RowClick="txtMusteriHesapKodu_RowClick"/>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"
                                                            ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="HesapKodu" ShowInCustomizationForm="True" 
                                                            VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Unvan1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Unvan2" ShowInCustomizationForm="True" 
                                                            VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="4" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres2" ShowInCustomizationForm="True" 
                                                            VisibleIndex="5" Visible="False">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres3" ShowInCustomizationForm="True" 
                                                            VisibleIndex="6" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VergiDairesi" 
                                                            ShowInCustomizationForm="True" VisibleIndex="7" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VergiHesapNo" 
                                                            ShowInCustomizationForm="True" VisibleIndex="8" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Telefon1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="9" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BolgeKodu" ShowInCustomizationForm="True" 
                                                            VisibleIndex="10" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="GrupKodu" ShowInCustomizationForm="True" 
                                                            VisibleIndex="11" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Fax" ShowInCustomizationForm="True" 
                                                            VisibleIndex="12" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="13" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod2" ShowInCustomizationForm="True" 
                                                            VisibleIndex="14" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod3" ShowInCustomizationForm="True" 
                                                            VisibleIndex="15" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod4" ShowInCustomizationForm="True" 
                                                            VisibleIndex="16" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod5" ShowInCustomizationForm="True" 
                                                            VisibleIndex="17" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod6" ShowInCustomizationForm="True" 
                                                            VisibleIndex="18" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod7" ShowInCustomizationForm="True" 
                                                            VisibleIndex="19" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod8" ShowInCustomizationForm="True" 
                                                            VisibleIndex="20" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod9" ShowInCustomizationForm="True" 
                                                            VisibleIndex="21" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                         <dx:GridViewDataTextColumn FieldName="ParaBirimi" ShowInCustomizationForm="True" 
                                                            VisibleIndex="22" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridLookup>
                                            </td>
                                            <td style="width: 114px; height: 14px;">
                                                &nbsp;
                                                <asp:Label ID="lblBayiHesapKodu" runat="server" Font-Bold="True" Text="Hesap Kodu"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 14px;">
                                                
                                                <asp:SqlDataSource ID="DsBayiler" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:CsLink %>" 
                                                    
                                                    SelectCommand="SELECT CAR002_Row_ID AS ID, CAR002_HesapKodu AS HesapKodu, CAR002_Unvan1 AS Unvan1, CAR002_Unvan2 AS Unvan2, CAR002_Adres1 AS Adres1, CAR002_Adres2 AS Adres2, CAR002_Adres3 AS Adres3, CAR002_VergiDairesi AS VergiDairesi, CAR002_VergiHesapNo AS VergiHesapNo, CAR002_Telefon1 AS Telefon1, CAR002_BolgeKodu AS BolgeKodu, CAR002_GrupKodu AS GrupKodu, CAR002_Fax AS Fax, CAR002_Kod1 AS Kod1, CAR002_Kod2 AS Kod2, CAR002_Kod3 AS Kod3, CAR002_Kod4 AS Kod4, CAR002_Kod5 AS Kod5, CAR002_Kod6 AS Kod6, CAR002_Kod7 AS Kod7, CAR002_Kod8 AS Kod8, CAR002_Kod9 AS Kod9 FROM CAR002 AS c Where c.CAR002_Kod6 = @MusteriKodu"
                                                    EnableCaching="True">
                                                    <SelectParameters>
                                                    <asp:controlparameter Name="MusteriKodu" ControlID="txtMusteriHesapKodu" PropertyName="Text"/>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <dx:ASPxGridLookup ID="txtBayiKodu" runat="server" AutoGenerateColumns="False" 
                                                    ClientInstanceName="txtBayiKodu" DataSourceID="DsBayiler" 
                                                    IncrementalFilteringMode="StartsWith" KeyFieldName="ID" TextFormatString="{1}" 
                                                    Width="100%" OnButtonClick="txtBayiKodu_ButtonClick">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterBar="Visible" ShowFilterRow="True" />
                                                    </GridViewProperties>
                                                    <GridViewClientSideEvents RowClick="txtBayiKodu_RowClick" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" 
                                                            ShowInCustomizationForm="True" Visible="False" VisibleIndex="0">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="HesapKodu" ShowInCustomizationForm="True" 
                                                            VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Unvan1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Unvan2" ShowInCustomizationForm="True" 
                                                            VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres1" ShowInCustomizationForm="True" 
                                                            VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres2" ShowInCustomizationForm="True" 
                                                            VisibleIndex="5">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Adres3" ShowInCustomizationForm="True" 
                                                            VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VergiDairesi" 
                                                            ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VergiHesapNo" 
                                                            ShowInCustomizationForm="True" Visible="False" VisibleIndex="8">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Telefon1" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="9">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BolgeKodu" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="10">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="GrupKodu" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="11">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Fax" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="12">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod1" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="13">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod2" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="14">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod3" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="15">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod4" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="16">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod5" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="17">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod6" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="18">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod7" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="19">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod8" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="20">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Kod9" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="21">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Buttons>
                                                        <dx:EditButton>
                                                        </dx:EditButton>
                                                    </Buttons>
                                                </dx:ASPxGridLookup>
                                            </td>
                                            <td style="width: 104px; height: 14px;">
                                                &nbsp;
                                                <asp:Label ID="lblTeklifTarihi" runat="server" Font-Bold="True" Text="Teklif Tarihi"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 14px;">
                                                <dx:ASPxDateEdit ID="dtTeklifTarihi" runat="server" Width="100%" DisplayFormatString="dd-MM-yyyy">
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 19px;">
                                                &nbsp;
                                                <asp:Label ID="lblUnvan" runat="server" Font-Bold="True" Text="Ünvan"></asp:Label>
                                            </td>
                                            <td style="width: 167px; height: 19px;">										   
                                                        <dx:ASPxTextBox ID="txtMusteriUnvani" runat="server" 
                                                            ClientInstanceName="txtMusteriUnvani" ReadOnly="True" Width="100%">
                                                            <ReadOnlyStyle BackColor="#EBEBEB">
                                                            </ReadOnlyStyle>
                                                        </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 114px; height: 19px;">
                                            &nbsp;&nbsp;<asp:Label ID="lblBayiUnvan" runat="server" Font-Bold="True" Text="Ünvan"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 19px;">
                                                <dx:ASPxTextBox ID="txtBayiUnvani" runat="server" 
                                                    ClientInstanceName="txtBayiUnvani" ReadOnly="True" Width="100%">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                                </td>
                                            <td style="width: 104px; height: 19px;">
                                                &nbsp;
                                                <asp:Label ID="lblTeklifSeriNo" runat="server" Font-Bold="True" Text="Teklif Seri No"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 19px;"> 
                                                <dx:ASPxGridLookup ID="grdEvrakNumaralari" runat="server" AutoGenerateColumns="False" 
                                                    KeyFieldName="EvrakNumarasi"  TextFormatString="{1}" AutoPostBack="true"
                                                    IncrementalFilteringMode="StartsWith" Width="100%" OnLoad="grdEvrakNumaralari_Load">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterBar="Visible" ShowFilterRow="True" />
                                                    </GridViewProperties>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="0">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="EvrakNumarasi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="KullaniciKodu" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriHesapKodu" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiHesapKodu" ShowInCustomizationForm="True" Visible="False" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MalKodu" ShowInCustomizationForm="True" VisibleIndex="5">
                                                             <Settings AllowAutoFilter="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MalAdi" ShowInCustomizationForm="True" VisibleIndex="6">
                                                             <Settings AllowAutoFilter="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Birim" ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Miktar" ShowInCustomizationForm="True" VisibleIndex="8">
                                                             <Settings AllowAutoFilter="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Miktar2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BirimFiyat" ShowInCustomizationForm="True" VisibleIndex="10">
                                                             <Settings AllowAutoFilter="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="KafileBuyuklugu" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Tutar" ShowInCustomizationForm="True" VisibleIndex="12">
                                                             <Settings AllowAutoFilter="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiIskTutari" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriIskTutari" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifIskTutari" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifTarihi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="16">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifSeriNo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="17">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BitisTarihi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="18">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiIskOran" ShowInCustomizationForm="True" Visible="False" VisibleIndex="19">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriIskOran" ShowInCustomizationForm="True" Visible="False" VisibleIndex="20">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifIskOran" ShowInCustomizationForm="True" Visible="False" VisibleIndex="21">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifTuru" ShowInCustomizationForm="True" Visible="False" VisibleIndex="22">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifiHazirlayan" ShowInCustomizationForm="True" Visible="False" VisibleIndex="23">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CepNo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="24">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TelNo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="25">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DovizCinsi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="26">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DovizKuru" ShowInCustomizationForm="True" Visible="False" VisibleIndex="27">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifDurum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="28">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifRedNeden1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="29">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifRedNeden2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="30">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeklifOnayTarihi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="31">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeslimSuresi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="32">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TeslimYeri" ShowInCustomizationForm="True" Visible="False" VisibleIndex="33">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="OdemeSekli1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="34">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="OdemeSekli2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="35">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="OdemeSekli3" ShowInCustomizationForm="True" Visible="False" VisibleIndex="36">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Aciklama1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="37">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Aciklama2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="38">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Not1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="39">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Not2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="40">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Bilgiler" ShowInCustomizationForm="True" Visible="False" VisibleIndex="41">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiUnvanAdres1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="42">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiUnvanAdres2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="43">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiUnvanAdres3" ShowInCustomizationForm="True" Visible="False" VisibleIndex="44">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="TelFax" ShowInCustomizationForm="True" Visible="False" VisibleIndex="45">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriUnvan1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="46">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriUnvan2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="47">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriAdres1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="48">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriAdres2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="49">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriAdres3" ShowInCustomizationForm="True" Visible="False" VisibleIndex="50">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriVergiDairesi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="51">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MusteriVergiNo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="52">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiUnvan1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="53">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiUnvan2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="54">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiAdres1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="55">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiAdres2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="56">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiAdres3" ShowInCustomizationForm="True" Visible="False" VisibleIndex="57">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiVergiDairesi" ShowInCustomizationForm="True" Visible="False" VisibleIndex="58">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BayiVergiNo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="59">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridLookup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 20px;"></td>
                                            <td style="width: 167px; height: 20px;">
                                                <dx:ASPxTextBox ID="txtMusteriUnvani1" runat="server" 
                                                    ClientInstanceName="txtMusteriUnvani1" ReadOnly="True" Width="100%">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 114px; height: 20px;"></td>
                                            <td style="width: 163px; height: 20px;">
                                                <dx:ASPxTextBox ID="txtBayiUnvani1" runat="server" Width="100%" ReadOnly="True" 
                                                    ClientInstanceName="txtBayiUnvani1">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 104px; height: 20px;">
                                                &nbsp;
                                                <asp:Label ID="lblBitisTarihi" runat="server" Font-Bold="True" Text="Bitiş Tarihi"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 20px;">
                                                <dx:ASPxDateEdit ID="dtBitisTarihi" runat="server" Width="100%" DisplayFormatString="dd-MM-yyyy">
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 21px;">
                                                &nbsp;
                                                <asp:Label ID="lblAdres" runat="server" Font-Bold="True" Text="Adresi"></asp:Label>
                                            </td>
                                            <td style="width: 167px; height: 21px;">

                                                        <dx:ASPxTextBox ID="txtMusteriAdresi" runat="server" ReadOnly="True" 
                                                            Width="100%" ClientInstanceName="txtMusteriAdresi">
                                                            <ReadOnlyStyle BackColor="#EBEBEB">
                                                            </ReadOnlyStyle>
                                                        </dx:ASPxTextBox>
        
                                            </td>
                                            <td style="width: 114px; height: 21px;">
                                                &nbsp;
                                                <asp:Label ID="lblBayiAdresi" runat="server" Font-Bold="True" Text="Adresi"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 21px;">
                                                <dx:ASPxTextBox ID="txtBayiAdresi" runat="server" Width="100%" ReadOnly="True" 
                                                    ClientInstanceName="txtBayiAdresi">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 104px; height: 21px;">
                                                &nbsp;
                                                <asp:Label ID="lblBayiIskonto" runat="server" Font-Bold="True" Text="Bayi İskonto %"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <dx:ASPxTextBox ID="txtBayiIskonto" runat="server" Width="100px" DisplayFormatString="{0:N2}" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 19px;"></td>
                                            <td style="width: 167px; height: 19px;">
                                                <dx:ASPxTextBox ID="txtMusteriAdresi1" runat="server" Width="100%" 
                                                    ReadOnly="True" ClientInstanceName="txtMusteriAdresi1">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 114px; height: 19px;">
                                                </td>
                                            <td style="width: 163px; height: 19px;">
                                                <dx:ASPxTextBox ID="txtBayiAdresi1" runat="server" Width="100%" ReadOnly="True" 
                                                    ClientInstanceName="txtBayiAdresi1">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 104px; height: 19px;">
                                                &nbsp;
                                                <asp:Label ID="lblMusteriIskonto" runat="server" Font-Bold="True" Text=" Müş. İskonto"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 19px;">
                                                <dx:ASPxTextBox ID="txtMusteriIskonto" runat="server" Width="100%" DisplayFormatString="{0:N2}" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; "></td>
                                            <td style="width: 167px; ">
                                                <dx:ASPxTextBox ID="txtMusteriAdresi2" runat="server" Width="100%" 
                                                    ReadOnly="True" ClientInstanceName="txtMusteriAdresi2">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            
                                                <td style="width: 114px; "></td>
                                                <td style="width: 104px; ">
                                                    <dx:ASPxTextBox ID="txtBayiAdresi2" runat="server" ReadOnly="True" Width="100%" 
                                                        ClientInstanceName="txtBayiAdresi2" Height="20px">
                                                        <ReadOnlyStyle BackColor="#EBEBEB">
                                                        </ReadOnlyStyle>
                                                    </dx:ASPxTextBox>
                                                    </td>
                                                <td style="width: 100px; ">
                                                 &nbsp;&nbsp;<asp:Label ID="lblTeklifIskonto" runat="server" Font-Bold="True" Text="Teklif İskonto"></asp:Label>
                                                </td>
                                            <td style="width: 100px; ">
                                                 <dx:ASPxTextBox ID="txtTeklifIskonto" runat="server" DisplayFormatString="{0:N2}" Text="0" Width="100%">
                                                 </dx:ASPxTextBox>
                                                </td>
                                            </tr>                                        
                                        <tr>
                                            <td style="width: 100px; height: 18px;">
                                                &nbsp;
                                                <asp:Label ID="lblVergiDairesi" runat="server" Font-Bold="True" Text="V.D"></asp:Label>
                                            </td>
                                            <td style="width: 167px; ">
                                                <dx:ASPxTextBox ID="txtMusteriVergiDairesi" runat="server" ReadOnly="True" 
                                                    Width="100%" ClientInstanceName="txtMusteriVergiDairesi">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 114px; height: 18px;">
                                                &nbsp;
                                                <asp:Label ID="lblBayiVergiDairesi" runat="server" Font-Bold="True" 
                                                    Text="V.D"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 18px;">
                                                <dx:ASPxTextBox ID="txtBayiVergiDairesi" runat="server" Width="100%" 
                                                    ReadOnly="True" ClientInstanceName="txtBayiVergiDairesi">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 104px; height: 18px;">
                                                &nbsp;
                                                <asp:Label ID="lblTeklifTuru" runat="server" Font-Bold="True" Text="Teklif Türü"></asp:Label>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:DropDownList ID="drpTeklifTuru" runat="server" Font-Names="Calibri" Font-Size="12px" Width="100px">
                                                    <asp:ListItem>Seçim Yapınız</asp:ListItem>
                                                    <asp:ListItem Value="0">Baglantı Teklifi</asp:ListItem>
                                                    <asp:ListItem Value="1">Sipariş Teklifi</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Text="Teklif Parametreleri">
                            <ActiveTabStyle BackColor="#66FF99" Font-Bold="True">
                            </ActiveTabStyle>
                            <TabStyle Font-Bold="True">
                            </TabStyle>
                            <ContentCollection>
                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table style="width:100%; height: 100%;">
                                        <tr>
                                            <td style="height: 14px; width: 142px">
                                                <asp:Label ID="lblTeklifiHazirlayan" runat="server" Text="Teklifi Hazırlayan" 
                                                    Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 14px; width: 227px;">
                                                <dx:ASPxTextBox ID="txtTeklifiHazirlayan" ClientInstanceName="txtTeklifiHazirlayan" runat="server" Width="100%" Enabled="False">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="height: 14px">
                                               <div style="float:left;">
                                                   <dx:ASPxRadioButton ID="rdTeklifRedEdildi" runat="server" Font-Bold="True" Text="Teklif Reddetildi" 
                                                       GroupName="TeklifGrubu" OnCheckedChanged="rdTeklifRedEdildi_CheckedChanged" AutoPostBack="True">
                                                   </dx:ASPxRadioButton></div>
                                                 <div style="float:left; margin-left:5px; height:16px;">
                                                    <asp:linkbutton id="lnkTeklifRed" runat="server" OnClick="TeklifRed" OnClientClick="TeklifRed()"> 
                                                   <img src="img/aktif.png" alt="" title="" style="margin-top:2px; height:16px; width:16px;" />
                                                        </asp:linkbutton>
                                                 </div>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 142px; height: 19px">
                                                <asp:Label ID="lblCepNo" runat="server" Font-Bold="True" Text="Cep No"></asp:Label>
                                            </td>
                                            <td style="height: 19px; width: 227px;">
                                                <dx:ASPxTextBox ID="txtCepNo" runat="server" Width="100%" Enabled="False">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="height: 19px">
                                                <dx:ASPxTextBox ID="txtTeklifRed1" runat="server" 
                                                    ClientInstanceName="txtTeklifRed1" ReadOnly="True" Width="100%">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px; width: 142px">
                                                <asp:Label ID="lblTelNo" runat="server" Text="Tel No" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 20px; width: 227px;">
                                                <dx:ASPxTextBox ID="txtTelNo" runat="server" Width="100%" Enabled="False">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="height: 20px">
                                                <dx:ASPxTextBox ID="txtTeklifRed2" runat="server" 
                                                    ClientInstanceName="txtTeklifRed2" ReadOnly="True" Width="100%" ViewStateMode="Enabled">
                                                    <ReadOnlyStyle BackColor="#EBEBEB">
                                                    </ReadOnlyStyle>
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 13px; width: 142px">
                                                <asp:Label ID="lblDovizCinsi" runat="server" Text="Döviz Cinsi" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 13px; width: 227px;">
                                                <asp:DropDownList ID="drpDovizCinsi" runat="server" Font-Names="Calibri" Font-Size="12px" Width="100%">
                                                    <asp:ListItem Selected="True">CHF</asp:ListItem>
                                                    <asp:ListItem>USD</asp:ListItem>
                                                    <asp:ListItem>EUR</asp:ListItem>
                                                    <asp:ListItem>TL</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 13px">
                                                <div style="float:left;">
                                                    <dx:ASPxRadioButton ID="rdTeklifOnaylandi" runat="server" Font-Bold="True" 
                                                    Text="Teklif Onaylandı" GroupName="TeklifGrubu" AutoPostBack="True" 
                                                        OnCheckedChanged="rdTeklifOnaylandi_CheckedChanged">
                                                </dx:ASPxRadioButton>
                                                </div>
                                                <div style="float:left; margin-left:5px; height:16px;">
                                                    <asp:linkbutton id="TeklifOnayla" runat="server" OnClick="SiparisOnayla" OnClientClick="SiparisOnayla()"> 
                                                   <img src="img/aktif.png" alt="" title="" style="margin-top:2px; height:16px; width:16px;" />
                                                        </asp:linkbutton>
                                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblDovizKuru" runat="server" Font-Bold="True" Text="Döviz Kuru"></asp:Label>
                                            </td>
                                            <td style="width: 227px">
                                                <dx:ASPxTextBox ID="txtDovizKuru" runat="server" Width="100%" DisplayFormatString="{0:N2}" Text="0" ClientInstanceName="txtDovizKuru">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxDateEdit ID="dtOnayTarihi" runat="server" Enabled="False" DisplayFormatString="dd-MM-yyyy">
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px; width: 142px">&nbsp;</td>
                                            <td style="height: 14px; width: 227px;">
                                                &nbsp;</td>
                                            <td style="height: 14px">
                                                <dx:ASPxRadioButton ID="rdTeklifBeklemede" runat="server" Font-Bold="True" 
                                                    Text="Teklif Beklemede" GroupName="TeklifGrubu" AutoPostBack="True" Checked="True" OnCheckedChanged="rdTeklifBeklemede_CheckedChanged">
                                                </dx:ASPxRadioButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 142px">
                                                &nbsp;</td>
                                            <td style="width: 227px">
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Text="Açıklamalar">
                            <ActiveTabStyle BackColor="#66FF99" Font-Bold="True">
                            </ActiveTabStyle>
                            <TabStyle Font-Bold="True">
                            </TabStyle>
                            <ContentCollection>
                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="height: 14px; width: 155px">
                                                <asp:Label ID="lblTeslimSuresi" runat="server" Text="Teslim Süresi" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 14px">
                                                <dx:ASPxTextBox ID="txtTeklifSuresi" runat="server" Width="100%" Text="Siparişten üç gün sonra">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 155px; height: 19px">
                                                <asp:Label ID="lblTeslimYeri" runat="server" Text="Teslim Yeri" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 19px">
                                                <dx:ASPxTextBox ID="txtTeslimYeri" runat="server" Width="100%" Text="Adrese teslim">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px; width: 155px">
                                                <asp:Label ID="lblOdemeSekli" runat="server" Text="Ödeme Şekli" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 20px">
                                                <dx:ASPxTextBox ID="txtOdemeSekli1" runat="server" Width="70%" Text="Fatura bedelleri teslimden itibaren">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px; width: 155px">&nbsp;</td>
                                            <td style="height: 14px">
                                                <div style="float:left; width:70%;"><dx:ASPxTextBox ID="txtOdemeSekli2" ClientInstanceName="txtOdemeSekli2" runat="server" Width="100%"></dx:ASPxTextBox></div>
                                                <dx:ASPxGridLookup ID="grdOdemeSekli" runat="server" 
                                                    AutoGenerateColumns="False" DataSourceID="SqlOdemeSekli" KeyFieldName="ID"  TextFormatString="{1}" 
                                                    IncrementalFilteringMode="StartsWith" ClientInstanceName="grdOdemeSekli" >
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <Settings ShowFilterBar="Visible" ShowFilterRow="False" />
                                                    </GridViewProperties>
                                                    <GridViewClientSideEvents RowClick="OdemeSekli_RowClick"/>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"
                                                            ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Aciklama" ShowInCustomizationForm="True" 
                                                            VisibleIndex="1" Caption="Ödeme Şekli Açıklaması">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridLookup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 155px">&nbsp;</td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtOdemeSekli3" runat="server" Width="100%" Text="Fiyatlarımıza KDV / ÖTV dahil değildir.">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px; width: 155px">
                                                <asp:Label ID="lblAciklama" runat="server" Text="Açıklama" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 14px">
                                                <dx:ASPxTextBox ID="txtAciklama1" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 155px">&nbsp;</td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtAciklama2" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Text="Notlar">
                            <ActiveTabStyle BackColor="#66FF99" Font-Bold="True">
                            </ActiveTabStyle>
                            <TabStyle Font-Bold="True">
                            </TabStyle>
                            <ContentCollection>
                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">                                  
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="height: 14px; width: 155px">
                                                <asp:Label ID="lblNotlar" runat="server" Text="Notlar" Font-Bold="True" 
                                                    Width="100%"></asp:Label>
                                            </td>
                                            <td style="height: 14px">
                                                <dx:ASPxTextBox ID="txtNot1" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 155px; height: 19px">&nbsp;</td>
                                            <td style="height: 19px">
                                                <dx:ASPxTextBox ID="txtNot2" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px; width: 155px">
                                                <asp:Label ID="lblBilgiler" runat="server" Text="Bilgiler" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 20px">
                                                <dx:ASPxTextBox ID="txtBilgiler" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px; width: 155px">
                                                <asp:Label ID="lblBayiUnvani" runat="server" Text="Bayi Ünvan / Adres" 
                                                    Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="height: 14px">
                                                <dx:ASPxTextBox ID="txtUnvanAdres1" runat="server" Width="100%" ClientInstanceName="txtUnvanAdres1">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 155px">&nbsp;</td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtUnvanAdres2" runat="server" Width="100%" ClientInstanceName="txtUnvanAdres2">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px; width: 155px">&nbsp;</td>
                                            <td style="height: 14px">
                                                <dx:ASPxTextBox ID="txtUnvanAdres3" runat="server" Width="100%" ClientInstanceName="txtUnvanAdres3">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTelefonFax" runat="server" Text="Tel / Fax" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtTelefonFax" runat="server" Width="170px" ClientInstanceName="txtTelefonFax">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>                                  
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                    </TabPages>
                </dx:ASPxPageControl>

    </asp:Panel>
    <table border="0" style="width:60px;">
  <tr style="height:30px;">
    <td><dx:ASPxButton ID="btnYenile" runat="server" Text="Yenile" OnClick="btnYenile_Click"></dx:ASPxButton></td>
    <td><dx:ASPxButton ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click"></dx:ASPxButton></td>
  </tr>
</table>
    <div style="height:225px; width:900px; overflow:auto;">
        <dx:ASPxGridView ID="grdUrunlerimiz" runat="server" AutoGenerateColumns="False" 
           DataSourceID="DSTempStokHareketleri" KeyFieldName="ID" Width="863px">
            <Columns>
                <dx:GridViewCommandColumn ButtonType="Image" FixedStyle="Left" 
                    VisibleIndex="0" Caption="İşlemler">
                    <EditButton Visible="True" Text="Düzenle">
                        <Image Url="~/img/duzenle.png">
                        </Image>
                    </EditButton>
                    <NewButton Visible="True" Text="Yeni">
                        <Image Url="~/img/yeni.png">
                        </Image>
                    </NewButton>
                    <DeleteButton Visible="True" Text="Sil">
                        <Image Url="~/img/sil.png">
                        </Image>
                    </DeleteButton>
                    <CancelButton Text="Vazgeç">
                        <Image Url="~/img/iptal.png">
                        </Image>
                    </CancelButton>
                    <UpdateButton Text="Güncelle">
                        <Image Url="~/img/kaydet.png">
                        </Image>
                    </UpdateButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TeklifEvrakNo" Caption="EvrakNumarası" VisibleIndex="0" Name="txtEvrakNumarasi" ReadOnly="True">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtEvrakNumarasi">
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="KullaniciKodu"  ReadOnly="True" VisibleIndex="1" Name="txtKullaniciKodu" Visible="True">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtKullaniciKodu">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="MalKodu" Caption="Mal Kodu" VisibleIndex="2" Name="txtMalKodu">
                            <PropertiesComboBox ValueType="System.String" DataSourceID="sqlMalKodlari"
                            Width="100px" Height="25px" TextField="MalKodu" ValueField="MalKodu"
                            IncrementalFilteringMode="StartsWith" ClientInstanceName="txtMalKodu">
                            </PropertiesComboBox>
                <EditItemTemplate>
                   <dx:ASPxGridLookup ID="GrdMalKodu" runat="server"
                     AutoGenerateColumns="False" DataSourceID="sqlMalKodlari" KeyFieldName="MalKodu"  TextFormatString="{1}" 
                     IncrementalFilteringMode="StartsWith" Width="100px" 
                     OnValueChanged="MalKodu_ValueChanged">
                     <GridViewProperties>
                         <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                               <Settings ShowFilterBar="Visible" ShowFilterRow="True" />
                     </GridViewProperties>
                    <GridViewClientSideEvents RowClick="MalKodu_RowClick"/>
                               <Columns>
                           <dx:GridViewDataTextColumn FieldName="MalID" ReadOnly="True"
                               ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="MalKodu"  ShowInCustomizationForm="True" 
                               VisibleIndex="1">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="MalAdi" ShowInCustomizationForm="True" 
                               VisibleIndex="2">
                               </dx:GridViewDataTextColumn>
                               </Columns>
                         </dx:ASPxGridLookup>
                    </EditItemTemplate>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="MalAdi" VisibleIndex="3" Name="txtMalAdi" ReadOnly="True">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtMalAdi">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Birim" VisibleIndex="4" Name="txtBirim" ReadOnly="True">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtBirim">
                     </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Miktar2" VisibleIndex="5" Name="txtMiktar2">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtMiktar2">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Miktar" ReadOnly="True" VisibleIndex="6">
                    <PropertiesTextEdit Width="100px">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="BirimFiyat" VisibleIndex="7" Name="txtBirimFiyat">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtBirimFiyat">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Tutar" VisibleIndex="9" ReadOnly="True">
                    <PropertiesTextEdit Width="100px">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="KafileBuyuklugu" ReadOnly="True" VisibleIndex="8" Name="txtKafileBuyuklugu">
                    <PropertiesTextEdit Width="100px" ClientInstanceName="txtKafileBuyuklugu">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior ConfirmDelete="True" />
            <SettingsEditing Mode="PopupEditForm" />
            <SettingsText PopupEditFormCaption="Ürün Ekleme" Title="Ürün Ekleme" />
            <SettingsPopup>
                <EditForm AllowResize="True" HorizontalAlign="Center" Modal="True" />
            </SettingsPopup>
        </dx:ASPxGridView>
        </div>
    <div style="opacity:0;">
        <dx:ASPxTextBox runat="server" Width="100px" ReadOnly="True" ClientInstanceName="txtStokKodu" ID="txtStokKodu">
<ReadOnlyStyle BackColor="#EBEBEB"></ReadOnlyStyle>
</dx:ASPxTextBox>
        <dx:ASPxTextBox runat="server" Width="100px" ReadOnly="True" ClientInstanceName="txtTeklifEvrakNumarasi" ID="txtTeklifEvrakNumarasi">
<ReadOnlyStyle BackColor="#EBEBEB"></ReadOnlyStyle>
</dx:ASPxTextBox>
        <dx:ASPxTextBox runat="server" Width="100px" ReadOnly="True" ClientInstanceName="txtKullaniciAdi" ID="txtKullaniciAdi">
<ReadOnlyStyle BackColor="#EBEBEB"></ReadOnlyStyle>
</dx:ASPxTextBox>
    </div>
        <asp:SqlDataSource ID="DSTempStokHareketleri" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BlaserTeklifCS %>" 
            DeleteCommand="DELETE FROM [tblTempStokHareketleri] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [tblTempStokHareketleri] ([TeklifEvrakNo], [KullaniciKodu], [MalKodu], [MalAdi], [Birim], [Miktar], [Miktar2], 
            [BirimFiyat],[KafileBuyuklugu], [Tutar]) 
            VALUES (@EvrakNumarasi, @KullaniciKodu, @MalKodu, @MalAdi, @Birim, (@Miktar2*@KafileBuyuklugu), @Miktar2, @BirimFiyat,@KafileBuyuklugu, 
            (@Miktar2*@KafileBuyuklugu)*@BirimFiyat)" 
            SelectCommand="SELECT ISNULL(TS.ID,TE.TeklifID) AS ID,ISNULL(TE.MalKodu,TS.MalKodu) AS MalKodu,
            ISNULL(TE.MalAdi,TS.MalAdi) AS MalAdi,ISNULL(TE.EvrakNumarasi,TS.TeklifEvrakNo) AS TeklifEvrakNo,
            ISNULL(TE.KullaniciKodu,TS.KullaniciKodu) AS KullaniciKodu,ISNULL(TE.Miktar,TS.Miktar) AS Miktar,
            ISNULL(TE.Miktar2,TS.Miktar2) AS Miktar2, ISNULL(TE.KafileBuyuklugu,TS.KafileBuyuklugu) AS KafileBuyuklugu,
            ISNULL(TE.Birim,TS.Birim) AS Birim,ISNULL(TE.BirimFiyat,TS.BirimFiyat) AS BirimFiyat,ISNULL(TE.Tutar,TS.Tutar) AS Tutar
            FROM [tblTempStokHareketleri] AS TS
            RIGHT JOIN Teklif AS TE ON TS.TeklifEvrakNo=TE.EvrakNumarasi
            WHERE TE.EvrakNumarasi = @EvrakNumarasi AND TE.KullaniciKodu = @KullaniciKodu
            GROUP BY TS.ID,TE.TeklifID,TE.MalKodu,TS.MalKodu,TE.MalAdi,TS.MalAdi,
            TE.EvrakNumarasi,TS.TeklifEvrakNo,TE.KullaniciKodu,TS.KullaniciKodu,TE.Miktar,TS.Miktar,
            TE.Miktar2,TS.Miktar2,TE.KafileBuyuklugu,TS.KafileBuyuklugu,TE.Birim,TS.Birim,
            TE.BirimFiyat,TS.BirimFiyat,TE.Tutar,TS.Tutar" 
            UpdateCommand="UPDATE [tblTempStokHareketleri] SET [KullaniciKodu] = @KullaniciKodu, [MalKodu] = @MalKodu, 
            [MalAdi] = @MalAdi, [Birim] = @Birim, [Miktar] = (@Miktar2*@KafileBuyuklugu), [Miktar2] = @Miktar2, 
            [BirimFiyat] = @BirimFiyat, [KafileBuyuklugu] = @KafileBuyuklugu, [Tutar] = ((@Miktar2*@KafileBuyuklugu)*@BirimFiyat) WHERE [ID] = @ID">
            <SelectParameters>
            <asp:ControlParameter ControlID="txtTeklifEvrakNumarasi" Name="EvrakNumarasi" Type="String" />
            <asp:ControlParameter ControlID="txtKullaniciAdi" Name="KullaniciKodu" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="KullaniciKodu" Type="String" />
                <asp:ControlParameter ControlID="txtTeklifEvrakNumarasi" Name="EvrakNumarasi" Type="String" />
                <asp:ControlParameter ControlID="txtStokKodu" Name="MalKodu" Type="String" />
                <asp:Parameter Name="MalAdi" Type="String"/>
                <asp:Parameter Name="Birim" Type="String" />
                <asp:Parameter Name="Miktar2" Type="Decimal" />
                <asp:Parameter Name="BirimFiyat" Type="Decimal" />
                <asp:Parameter Name="KafileBuyuklugu" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="MalAdi" Type="String" />
                <asp:Parameter Name="KullaniciKodu" Type="String" />
                <asp:Parameter Name="MalKodu" Type="String" />
                <asp:Parameter Name="Birim" Type="String" />
                <asp:Parameter Name="Miktar" Type="Decimal" />
                <asp:Parameter Name="Miktar2" Type="Decimal" />
                <asp:Parameter Name="BirimFiyat" Type="Decimal" />
                <asp:Parameter Name="KafileBuyuklugu" Type="Decimal" />
                <asp:Parameter Name="Tutar" Type="Decimal" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlMalKodlari" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CsLink %>" 
                    SelectCommand="SELECT STK004_Row_ID AS MalID,STK004_MalKodu AS MalKodu,
            STK004_Aciklama+' ' +STK004_Aciklama2+' '+STK004_Aciklama3 AS MalAdi,STK004_Birim1 AS Birim,0 AS Miktar,
            0 AS Miktar2,STK004_KafileBuyuklugu AS KafileBuyuklugu,0 AS BirimFiyat
            FROM STK004 ORDER BY STK004_Row_ID ASC">
                </asp:SqlDataSource>
        
    <asp:Panel ID="Panel3" runat="server" Height="96px">
<asp:SqlDataSource ID="DsStokKartlari" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CsLink %>" 
                    SelectCommand="SELECT [CAR002_HesapKodu], [CAR002_Unvan1], [CAR002_Unvan2] FROM [CAR002]">
                </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlOdemeSekli" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BlaserTeklifCS %>" 
            SelectCommand="SELECT  ID, Aciklama FROM tblFormAciklamalari_OdemeSekli">
        </asp:SqlDataSource>
    </asp:Panel>
  
   </asp:Content>



