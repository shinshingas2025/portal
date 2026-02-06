<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page validateRequest="false" language="vb" CodeBehind="EditHtml2.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditHtml2" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2"><aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner></td>
				</tr>
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
											<TD vAlign="top" class="SubHead" align="left" width="79">文字內容
											</TD>
											<td vAlign="top" align="left"><asp:textbox id="DesktopText" runat="server" textmode="multiline" rows="8" width="334px" columns="75"></asp:textbox></td>
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
											<TD class="SubHead" width="72"><FONT face="新細明體">圖片位置</FONT></TD>
											<TD width="264" colSpan="3"><FONT face="新細明體">
													<asp:RadioButtonList id="rblImgPost" runat="server" RepeatDirection="Horizontal" CssClass="SubHead">
														<asp:ListItem Value="左" Selected="True">左</asp:ListItem>
														<asp:ListItem Value="右">右</asp:ListItem>
													</asp:RadioButtonList></FONT></TD>
										</TR>
										<TR>
											<TD class="SubHead" width="72">上傳圖片</TD>
											<TD width="264" colSpan="3"><FONT face="新細明體"><INPUT id="file1" type="file" size="20" runat="server">
													<asp:Button id="Button1" runat="server" Text="上傳"></asp:Button></FONT></TD>
										</TR>
										<TR>
											<TD class="SubHead" width="72" valign="top"><FONT face="新細明體">詳細內容</FONT></TD>
											<TD width="264" colSpan="3"><FONT face="新細明體">
													<asp:TextBox id="DetailText" runat="server" TextMode="MultiLine" Rows="13" Columns="80"></asp:TextBox></FONT></TD>
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
		</form>
	</body>
</HTML>
