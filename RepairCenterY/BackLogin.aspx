<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackLogin.aspx.cs" Inherits="RepairCenterY.BackLogin" %>

<!DOCTYPE html>
<link rel="stylesheet" href="assets/css/bootstrap.min.css">
	<link rel="stylesheet" href="assets/vendor/font-awesome/css/font-awesome.min.css">
	<link rel="stylesheet" href="assets/vendor/linearicons/style.css">
	<!-- MAIN CSS -->
	<link rel="stylesheet" href="assets/css/main.css">
	<!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
	<link rel="stylesheet" href="assets/css/demo.css">
	<!-- GOOGLE FONTS -->
	<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet">
	<!-- ICONS -->
	  <link rel="apple-touch-icon" sizes="76x76" href="../favicon1.ico"/>
    <link rel="icon"  sizes="96x96" href="../favicon1.ico"/>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
</head>
<body>
    	<!-- WRAPPER -->

	<div id="wrapper">
		<div class="vertical-align-wrap">
			<div class="vertical-align-middle">
				<div class="auth-box" style="margin-top: 12%;">
					<div class="left">
						<div class="content">
							<div class="header">
								<div class="logo text-center"><%--<img src="assets/img/logo-dark.png" width="139" height="21"/>--%>
                                    <img src="assets/img/未标题-2.jpg" />
								</div>
								<p class="lead">Login to your account</p>
							</div>
							<form id="form1" runat="server" class="form-auth-small" >
								<div class="form-group">
									<label for="signin-email" class="csontrol-label sr-only">用户名</label>
									<input type="text" class="form-control" id="signinemail" value="" placeholder="用户名" runat="server" maxlength="20"/>
								</div>
								<div class="form-group">
									<label for="signin-password" class="control-label sr-only">密码</label>
									<input type="password" class="form-control" id="signinpassword" value="" placeholder="密码" runat="server" maxlength="20"/>
								</div>
                                	<div class="form-group">
                                        <table>
                                            <tr>
                                                <td style="width:350px;">
                                                    <label for="signin-password" class="control-label sr-only">验证码</label>
									                <input type="text" class="form-control" id="Password1" value="" placeholder="验证码"  style="width:100%" runat="server" maxlength="4" onkeyup="this.value=this.value.replace(/[^a-zA-Z0-9]/g,'')"/>
                                                </td>
                                                <td style="width:145px; height:35px;">
                                                    <img src="ValidateCode.aspx" onclick="this.src='ValidateCode.aspx?'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer; width:75%; height:35px;"/>
                                                </td>
                                            </tr>
                                        </table>
                                    
								</div>
								<div class="form-group clearfix">
                                    <asp:label runat="server" style="color:#f00" id="FT"></asp:label>
								</div>
                                <asp:linkbutton runat="server" type="submit" class="btn btn-primary btn-lg btn-block" OnClick="Unnamed1_Click">登录</asp:linkbutton>
<%--								<div class="bottom">
									<span class="helper-text"><i class="fa fa-lock"></i> <a href="#">忘记密码？</a></span>
								</div>--%>
							</form>
						</div>
					</div>
					<div class="right">
						<div class="overlay"></div>
						<div class="content text">
							<h1 class="heading">信息化设备维修平台</h1>
							<p>Information Equipment Maintenance Platform</p>
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
			</div>
		</div>
	</div>
	<!-- END WRAPPER -->
</body>
</html>
