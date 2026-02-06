<%@ Page validateRequest="false" language="vb" CodeBehind="EditSiteLogo.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditSiteLogo" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
		<ASPNETPortal:Banner id="DesktopPortalBanner1" runat="server"></ASPNETPortal:Banner>
			<table width="40%" border="0" cellpadding="0" cellspacing="0" align="center">
				<tr>
					<td colspan="3">
						<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
							<tr>
								<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
								<td width=144 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">網站LOGO維護</asp:label></td>
								<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
				</tr>
				<tr>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
					<td bgcolor="#ffffff" width="100%">
						<table width="100%" border="0">
							<tr>
								<td>
									<!------------------------------------------------------------------------------------------>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><br>
												<table cellSpacing="0" cellPadding="4" width="98%" border="0">
													<tr vAlign="top">
														<td width="100">&nbsp;
														</td>
														<td width="*">
															<table cellSpacing="0" cellPadding="0" width="750">
																<tr>
																	<td class="Head" align="left">內容&nbsp;設定
																	</td>
																</tr>
																<tr>
																	<td colSpan="2">
																		<hr noShade SIZE="1">
																	</td>
																</tr>
															</table>
															<table cellSpacing="0" cellPadding="0" width="720">
																<tr vAlign="top">
																	<td class="SubHead" width="72"><FONT face="新細明體">圖片</FONT>
																	</td>
																	<td vAlign="middle" align="center" width="178"><asp:image id="Image1" runat="server"></asp:image></td>
																	<TD vAlign="top" class="SubHead" align="left" width="79">&nbsp;
																	</TD>
																	<td vAlign="top" align="left"></td>
																</tr>
																<TR>
																	<TD class="SubHead" width="72"><FONT face="新細明體">檔名</FONT></TD>
																	<TD vAlign="middle" align="center" width="178"><FONT face="新細明體">
																			<P align="left">
																				<asp:Label id="lblFileName" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label></P>
																		</FONT>
																	</TD>
																	<TD vAlign="top" align="left" width="79"><FONT face="新細明體"><asp:button id="btnDelete" runat="server" Text="刪除"></asp:button></FONT></TD>
																	<TD vAlign="top" align="left"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD class="SubHead" width="72">上傳圖片</TD>
																	<TD width="264" colSpan="3"><FONT face="新細明體"><INPUT id="file1" type="file" size="20" runat="server" NAME="file1">
																			<asp:Button id="Button1" runat="server" Text="上傳"></asp:Button></FONT></TD>
																</TR>
																<!--tr valign="top">
											<td class="SubHead">
												行動摘要 (選擇項):
											</td>
											<td>
												&nbsp;&nbsp;
											</td>
											<td>
												<asp:textbox id="MobileSummary" columns="75" width="650" rows="3" textmode="multiline" runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												行動詳細資料 (選擇項):
											</td>
											<td>
												&nbsp;&nbsp;
											</td>
											<td>
												<asp:textbox id="MobileDetails" columns="75" width="650" rows="5" textmode="multiline" runat="server" />
											</td>
										</tr--></table>
															<p>
																<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
																&nbsp;
																<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
																	borderstyle="none" />
																&nbsp;
															</p>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!------------------------------------------------------------------------------------------------>
								</td>
							</tr>
						</table>
					</td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
				</tr>
				<tr>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
