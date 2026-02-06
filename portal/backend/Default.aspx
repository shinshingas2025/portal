<%@ Page Language="vb" CodeBehind="Default.aspx.vb" AutoEventWireup="false" Inherits="CDefault" aspcompat="true" %>
<%@ Register TagPrefix="uc1" TagName="_NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="_footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<ASPNETCommerce:Header ID="Header1" runat="server" />
<!-- NAME: index.tpl -->
<tr>
	<td bgcolor="#A6C4E1">&nbsp;</td>
	<td width="930" bgcolor="#6699CC"><img src="images/title.gif"></td>
	<td bgcolor="#A6C4E1">&nbsp;</td>
</tr>
<tr>
	<td bgcolor="#D2E1F0">&nbsp;</td>
	<td width="930"><table width="930" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td height="50" valign="top" bgcolor="#a6c4e1">
					<table width="100%" border="0" cellpadding="2" cellspacing="4">
						<tr>
							<td><img src="images/title2.gif" width="140" height="18" border="0"></td>
						</tr>
						<tr>
							<td align="center"><font color="#666666"><%=Session("LoginID")%></font></td>
						</tr>
					</table>
				</td>
				<td align="center" valign="middle">&nbsp;<font color="#ff0000"></font></td>
			</tr>
			<tr>
				<td width="152" valign="top" bgcolor="#6699cc">
					<table width="100%" border="0" cellpadding="2" cellspacing="4">
						<tr>
							<td><img src="images/title1.gif" width="140" height="18"></td>
						</tr>
						<tr>
							<td>
								<!-- START: Keep all menus within masterdiv -->
<uc1:_NewMenu id=_NewMenu1 runat="server"></uc1:_NewMenu>
								
								<!-- END: Keep all menus within masterdiv -->
							</td>
						</tr>
					</table>
					<p>&nbsp;</p>
				</td>
				<td width="748" align="center" valign="top">
					<table width="95%" height="320" border="0" cellpadding="4" cellspacing="4" >
						<tr>
							<td align="center">
							</td>
						</tr>
					</table>
					<p><br>
					</p>
					<p>
					</p>
				</td>
			</tr>
			<tr>
				<td height="2" colspan="2" bgcolor="#d2e1f0"><IMG border="0" height="1" src="images/spacer.gif" width="4"></td>
			</tr>
		</table>
	</td>
	<td bgcolor="#D2E1F0">&nbsp;</td>
</tr>
<tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG alt="" border="0" height="1" src="images/spacer.gif" width="4"></td> 

</tr>
<!-- END: index.tpl -->
<uc1:_footer id=_footer1 runat="server"></uc1:_footer>
