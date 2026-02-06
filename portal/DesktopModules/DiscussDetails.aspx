<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="DiscussDetails.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.DiscussDetails" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" marginwidth="0" marginheight="0"  background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server" name="form1">
			<aspnetportal:banner showtabs="false" runat="server" id="Banner1" />
			<table cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">討論區資料</asp:label></td>
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
											<table width="100%" cellspacing="0" cellpadding="0" border="0">
												<tr valign="top">
													<td width="10%">
														&nbsp;
													</td>
													<td>
														<br>
														<table width="600" cellspacing="0" cellpadding="0">
															<tr>
																<td align="left">
																	<span class="Head">討論區資料</span>
																</td>
																<td align="right">
																	<asp:panel id="ButtonPanel" runat="server"><A class="CommandButton" id="prevItem" title="上個訊息" runat="server">
																			<IMG 
                        src='<%=Global.GetApplicationPath(Request) & "/images/rew.gif"  %>' 
                        border=0></A>&nbsp; <A class="CommandButton" id="nextItem" title="下個訊息" runat="server"><IMG 
                        src='<%=Global.GetApplicationPath(Request) & "/images/fwd.gif"  %>' 
                        border=0></A>&nbsp; 
<asp:linkbutton id="ReplyBtn" runat="server" enableviewstate="false" cssclass="CommandButton" text="回覆此訊息"></asp:linkbutton>
                              </asp:panel>
																</td>
															</tr>
															<tr>
																<td colspan="2">
																	<hr noshade size="1">
																</td>
															</tr>
														</table>
														<asp:panel id="EditPanel" visible="false" runat="server">
															<TABLE cellSpacing="0" cellPadding="4" width="600" border="0">
																<TR vAlign="top">
																	<TD class="SubHead" width="150">標題:
																	</TD>
																	<TD rowSpan="4">&nbsp;
																	</TD>
																	<TD width="*">
																		<asp:textbox id="TitleField" runat="server" cssclass="NormalTextBox" maxlength="100" columns="40"
																			width="500"></asp:textbox></TD>
																</TR>
																<TR vAlign="top">
																	<TD class="SubHead">內文:
																	</TD>
																	<TD width="*">
																		<asp:textbox id="BodyField" runat="server" columns="59" width="500" rows="15" textmode="Multiline"></asp:textbox></TD>
																</TR>
																<TR vAlign="top">
																	<TD>&nbsp;
																	</TD>
																	<TD>
																		<asp:linkbutton class="CommandButton" id="updateButton" runat="server" text="送出"></asp:linkbutton>&nbsp;
																		<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" text="取消" causesvalidation="False"></asp:linkbutton>&nbsp;
																	</TD>
																</TR>
																<TR vAlign="top">
																	<TD class="SubHead">原始訊息:
																	</TD>
																	<TD>&nbsp;
																	</TD>
																</TR>
															</TABLE>
														</asp:panel>
														<table width="600" cellspacing="0" cellpadding="4" border="0">
															<tr valign="top">
																<td align="left" class="Message">
																	<b>主題: </b>
																	<asp:label id="Title" runat="server" />
																	<br>
																	<b>作者:</b>
																	<asp:label id="CreatedByUser" runat="server" />
																	<br>
																	<b>日期: </b>
																	<asp:label id="CreatedDate" runat="server" />
																	<br>
																	<br>
																	<asp:label id="Body" runat="server" />
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</td>
						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
					</tr>
					<tr>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</TBODY></table>
		</form>
	</body>
</HTML>
