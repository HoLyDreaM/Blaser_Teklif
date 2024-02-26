<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Sevk.aspx.cs" Inherits="Default2" %>

<%@ Register assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>








<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" 
            OnClick="ASPxButton1_Click" Text="ASPxButton">
        </dx:ASPxButton>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
            </dx:ASPxTextBox>

        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
</asp:Content>

