<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page validateRequest="false"  language="vb" CodeBehind="EditImageList.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditImageList" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
			<uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><FONT face="新細明體"><BR>
				<BR>
				<table cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
					<TBODY>
						<tr>
							<td colSpan="3">
								<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
									<tr>
										<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
										<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">圖片內容設定</asp:label></td>
										<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
										<td></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></td>
							<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' ></td>
							<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif' ></td>
						</tr>
						<tr>
							<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' ></td>
							<td bgColor="#ffffff">
								<TABLE width="100%" border="0">
									<TBODY>
										<TR>
											<TD vAlign="top" align="center">
												<!---------------------------------------------------------------------------------------------------------------------->
												<TABLE class="TTable" id="Table1" height="328" cellSpacing="1" cellPadding="1" width="400"
													align="center" border="0" runat="server">
													<TBODY>
														<TR>
															<TD vAlign="middle">
																<TABLE height="112" cellSpacing="0" cellPadding="0" width="95%" align="center">
																	<TBODY>
																		<TR>
																			<TD class="SubHead" width="72" colSpan="4" height="15">
																				<HR align="center" width="507.61%" SIZE="1">
																			</TD>
																		</TR>
																		<TR vAlign="top">
																			<TD class="SubHead" width="72" height="35"><FONT face="新細明體">圖片</FONT>
																			</TD>
																			<TD vAlign="middle" align="center" width="178" colSpan="3" height="35"><asp:image id="Image1" runat="server"></asp:image><FONT face="新細明體"></FONT></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" height="26"><FONT face="新細明體">URL連結</FONT>&nbsp;</TD>
																			<TD vAlign="middle" width="178" colSpan="3" height="26"><FONT face="新細明體"><asp:textbox id="Url" runat="server" columns="75" width="206px" rows="12"></asp:textbox></FONT></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" height="26"><FONT face="新細明體">影像高度</FONT></TD>
																			<TD vAlign="middle" align="left" width="178" height="26"><asp:textbox id="TextBox1" runat="server" Width="50px"></asp:textbox><FONT face="新細明體" size="2">px</FONT></TD>
																			<TD class="SubHead" align="left" width="43" height="26"><FONT face="新細明體">順序</FONT></TD>
																			<TD align="left" height="26"><asp:dropdownlist id="OrderNO" runat="server">
																					<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
																					<asp:ListItem Value="2">2</asp:ListItem>
																					<asp:ListItem Value="4">4</asp:ListItem>
																					<asp:ListItem Value="3">3</asp:ListItem>
																					<asp:ListItem Value="5">5</asp:ListItem>
																					<asp:ListItem Value="6">6</asp:ListItem>
																					<asp:ListItem Value="7">7</asp:ListItem>
																					<asp:ListItem Value="8">8</asp:ListItem>
																					<asp:ListItem Value="9">9</asp:ListItem>
																					<asp:ListItem Value="10">10</asp:ListItem>
																				</asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" height="26"><FONT face="新細明體">影像寛度</FONT></TD>
																			<TD vAlign="middle" align="left" width="178" height="26"><asp:textbox id="TextBox2" runat="server" Width="50px"></asp:textbox><FONT face="新細明體" size="2">px</FONT></TD>
																			<TD class="SubHead" align="left" width="43" height="26"><FONT face="新細明體"></FONT></TD>
																			<TD align="left" height="26"></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" height="26"><FONT face="新細明體">檔名</FONT></TD>
																			<TD vAlign="middle" align="center" width="178" height="26"><FONT face="新細明體">
																					<P align="left"><asp:label id="lblFileName" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label></P>
																				</FONT>
																			</TD>
																			<TD class="SubHead" align="left" width="43" height="26"><FONT face="新細明體"></FONT></TD>
																			<TD align="left" height="26"><FONT face="新細明體"></FONT></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72">上傳圖片</TD>
																			<TD width="264" colSpan="3"><FONT face="新細明體"><INPUT id="file1" type="file" size="20" runat="server" NAME="file1">
																					<asp:button id="Button1" runat="server" Text="上傳"></asp:button></FONT></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72"><FONT face="新細明體"></FONT></TD>
																			<TD width="264" colSpan="3"><FONT face="新細明體"></FONT></TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" colSpan="4">
																				<table border="0" cellspacing="0" cellpadding="0">
																					<tr>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																							<asp:linkbutton class="CommandButton" id="updateButton" runat="server" text="更新" borderstyle="none"></asp:linkbutton></td>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																					</tr>
																				</table>
																				<table border="0" cellspacing="0" cellpadding="0">
																					<tr>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																							<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" borderstyle="none" text="取消"
																								causesvalidation="False"></asp:linkbutton></td>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																					</tr>
																				</table>
																				<BR>
																				<BR>
																				<table border="0" cellspacing="0" cellpadding="0">
																					<tr>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																							<asp:LinkButton id="btnDelete" borderstyle="none" class="CommandButton" runat="server">刪除</asp:LinkButton></td>
																						<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																					</tr>
																				</table>
			</FONT></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE> 
			<!---------------------------------------------------------------------------------------------------------------------->
			<DIV></DIV>
			</TD></TR></TBODY></TABLE></TD>
			<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
			</TR>
			<tr>
				<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
				<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
				<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
			</tr>
			</TBODY></TABLE>
		</form>
		</FONT>
	</body>
</HTML>
