<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="EvrakSeriNoTanimlari.aspx.cs" Inherits="Default3" %>

<%@ Register assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxGridView ID="ASPxGridView2" runat="server" 
    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" 
    KeyFieldName="EvrakTipi" Width="690px">
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                <editbutton visible="True">
                    <image url="~/img/duzenle.png">
                    </image>
                </editbutton>
                <cancelbutton>
                    <image url="~/img/iptal.png">
                    </image>
                </cancelbutton>
                <updatebutton>
                    <image url="~/img/kaydet.png">
                    </image>
                </updatebutton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="EvrakTipiStr" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EvrakSeri" VisibleIndex="3">
                <PropertiesTextEdit MaxLength="2">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EvrakNo" VisibleIndex="4">
                <PropertiesTextEdit MaxLength="6">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsEditing Mode="Inline" />
        <Settings ShowTitlePanel="True" />
        <SettingsText ConfirmDelete="Satırı Silmek İstediğinize Emin misiniz?" 
            Title="Evrak Seri-No Tanımları" />
        <Styles>
            <HeaderPanel Font-Bold="False" Font-Italic="False">
            </HeaderPanel>
        </Styles>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:BlaserTeklifCS %>" 
        DeleteCommand="DELETE FROM [tblEvrakSeriNo] WHERE [EvrakTipi] = @original_EvrakTipi AND (([EvrakTipiStr] = @original_EvrakTipiStr) OR ([EvrakTipiStr] IS NULL AND @original_EvrakTipiStr IS NULL)) AND (([EvrakSeri] = @original_EvrakSeri) OR ([EvrakSeri] IS NULL AND @original_EvrakSeri IS NULL)) AND (([EvrakNo] = @original_EvrakNo) OR ([EvrakNo] IS NULL AND @original_EvrakNo IS NULL))" 
        InsertCommand="INSERT INTO [tblEvrakSeriNo] ([EvrakTipi], [EvrakTipiStr], [EvrakSeri], [EvrakNo]) VALUES (@EvrakTipi, @EvrakTipiStr, @EvrakSeri, @EvrakNo)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [tblEvrakSeriNo]" 
        UpdateCommand="UPDATE [tblEvrakSeriNo] SET [EvrakTipiStr] = @EvrakTipiStr, [EvrakSeri] = @EvrakSeri, [EvrakNo] = @EvrakNo WHERE [EvrakTipi] = @original_EvrakTipi AND (([EvrakTipiStr] = @original_EvrakTipiStr) OR ([EvrakTipiStr] IS NULL AND @original_EvrakTipiStr IS NULL)) AND (([EvrakSeri] = @original_EvrakSeri) OR ([EvrakSeri] IS NULL AND @original_EvrakSeri IS NULL)) AND (([EvrakNo] = @original_EvrakNo) OR ([EvrakNo] IS NULL AND @original_EvrakNo IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_EvrakTipi" Type="Byte" />
            <asp:Parameter Name="original_EvrakTipiStr" Type="String" />
            <asp:Parameter Name="original_EvrakSeri" Type="String" />
            <asp:Parameter Name="original_EvrakNo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EvrakTipi" Type="Byte" />
            <asp:Parameter Name="EvrakTipiStr" Type="String" />
            <asp:Parameter Name="EvrakSeri" Type="String" />
            <asp:Parameter Name="EvrakNo" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="EvrakTipiStr" Type="String" />
            <asp:Parameter Name="EvrakSeri" Type="String" />
            <asp:Parameter Name="EvrakNo" Type="Int32" />
            <asp:Parameter Name="original_EvrakTipi" Type="Byte" />
            <asp:Parameter Name="original_EvrakTipiStr" Type="String" />
            <asp:Parameter Name="original_EvrakSeri" Type="String" />
            <asp:Parameter Name="original_EvrakNo" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

