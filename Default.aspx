<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
<meta charset="utf-8">
<title>Blaser Web Sipariş</title>
<link rel="stylesheet" type="text/css" href="CSS/loginStyle.css" />
</head>
<body>
<div class="container">
	<section id="content">
		<form id="form1" runat="server">
			<h1>Kullanıcı Girişi</h1>
			<div>
                <asp:TextBox id="username" placeholder="Kullanıcı Adı" required="" runat="server"></asp:TextBox>
			</div>
			<div>
                <asp:TextBox ID="password" placeholder="Şifre" required="" runat="server"  TextMode="Password"></asp:TextBox>
			    <asp:Button ID="btnGiris" runat="server" OnClick="btnGiris_Click" Text="Giriş" />
                <asp:Label ID = "mesaj" runat =server></asp:Label>
			</div>
		</form>
        <!-- form -->
		<!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>