<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuControl.aspx.vb" Inherits=".MenuControl"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>MenuControl</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<script language="javascript" src="ajax.js"></script>
		<script language="javascript" src="scripts.js"></script>
		<style>
		    div#TreeView1 a{color:blue;font-family:verdana;font-size:10pt;}
		    div#TreeView1 a:link{text-decoration:none;}
		    div#TreeView1 a:hover{text-decoration:underline;}
		    div#TreeView1 a:visited{text-decoration:none;}
		</style>
	</head>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td valign="top">
						<div id="TreeView1"></div>
					</td>
					<td valign="top">
						<div id="Loading" style="color:blue;display:none;">Loading...</div>
					</td>
				</tr>
			</table>
			<script>
			window.onload = function(){
				buildTree('TreeView1');
			}
			</script>
		</form>
	</body>
</html>
