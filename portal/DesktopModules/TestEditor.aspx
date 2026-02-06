<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TestEditor.aspx.vb" Inherits="ASPNET.StarterKit.Portal.TestEditor"%>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet>
<html>
			<script language="javascript" type="text/javascript" src="../jscripts/tiny_mce/tiny_mce.js"></script>
			<script language="javascript" type="text/javascript">
tinyMCE.init({
	mode : "textareas",
	theme : "advanced",
	plugins : "table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,zoom,flash,searchreplace,print,contextmenu",
	theme_advanced_buttons1_add_before : "save,separator",
	theme_advanced_buttons1_add : "fontselect,fontsizeselect",
	theme_advanced_buttons2_add : "separator,insertdate,inserttime,preview,zoom,separator,forecolor,backcolor",
	theme_advanced_buttons2_add_before: "cut,copy,paste,separator,search,replace,separator",
	theme_advanced_buttons3_add_before : "tablecontrols,separator",
	theme_advanced_buttons3_add : "emotions,iespell,flash,advhr,separator,print",
	theme_advanced_toolbar_location : "top",
	theme_advanced_toolbar_align : "left",
	theme_advanced_path_location : "bottom",
	plugin_insertdate_dateFormat : "%Y-%m-%d",
	plugin_insertdate_timeFormat : "%H:%M:%S",
	extended_valid_elements : "a[name|href|target|title|onclick],img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name],hr[class|width|size|noshade],font[face|size|color|style],span[class|align|style]",
	external_link_list_url : "example_data/example_link_list.js",
	external_image_list_url : "example_data/example_image_list.js",
	flash_external_list_url : "example_data/example_flash_list.js"
});
		</script>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">

    <form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2"><aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner></td>
				</tr>
				<tr>
					<td>
						<textarea id="content" cols="50" rows="15"><%=sid %></textarea>
					</td>
				</tr>
			</table>
    </form>

  </body>
</html>
