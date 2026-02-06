<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="EditDocs.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditDocs" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form enctype="multipart/form-data" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server" />
			<table cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">內容設定</asp:label></td>
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
												<tr>
													<td>
														<br>
														<table width="98%" cellspacing="0" cellpadding="4" border="0">
															<tr valign="top">
																<td width="150">
																	&nbsp;
																</td>
																<td>
																	<table width="500" cellspacing="0" cellpadding="0">
																		<tr>
																			<td align="left" class="Head">
																				資料
																			</td>
																		</tr>
																		<tr>
																			<td colspan="2">
																				<hr noshade size="1">
																			</td>
																		</tr>
																	</table>
																	<table width="726" cellspacing="0" cellpadding="0" border="0">
																		<tr valign="top">
																			<td width="100" class="SubHead">
																				名稱:
																			</td>
																			<td>
																				&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="NameField" cssclass="NormalTextBox" width="353" columns="28" maxlength="150"
																					runat="server" />
																			</td>
																			<td width="25" rowspan="6">
																				&nbsp;
																			</td>
																			<td class="Normal" width="250">
																				<asp:requiredfieldvalidator display="Static" runat="server" errormessage="您必須輸入有效名稱" controltovalidate="NameField"
																					id="RequiredFieldValidator1" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				分類:
																			</td>
																			<td>
																				&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="CategoryField" cssclass="NormalTextBox" width="353" columns="28" maxlength="50"
																					runat="server" />
																			</td>
																		</tr>
																		<tr>
																			<td>
																				&nbsp;
																			</td>
																			<td colspan="2">
																				<hr noshade size="1" width="100%">
																			</td>
																		</tr>
																		<tr valign="top">
																			<td width="100" class="SubHead">
																				瀏覽 URL:
																			</td>
																			<td>
																				&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="PathField" cssclass="NormalTextBox" width="353" columns="28" maxlength="250"
																					runat="server" />
																			</td>
																		</tr>
																		<tr>
																			<td class="SubHead">
																				— 或 —
																			</td>
																			<td colspan="2">
																				&nbsp;
																				<br>
																				<br>
																			</td>
																		</tr>
																		<tr valign="top">
																			<td nowrap class="SubHead">
																				上傳至 Web 伺服器:&nbsp;
																			</td>
																			<td>
																				&nbsp;
																			</td>
																			<td>
																				<asp:checkbox id="Upload" cssclass="Normal" text="上傳文件至伺服器" runat="server" />
																				<br>
																				<asp:checkbox id="storeInDatabase" cssclass="Normal" text="存放在資料庫 (支援 Web Farm)" runat="server" />
																				<br>
																				<input type="file" id="FileUpload" width="300" style="WIDTH:353px;FONT-FAMILY:verdana"
																					runat="server" NAME="FileUpload">
																			</td>
																		</tr>
																	</table>
																	<p>
																		<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="200" border="0" >
																			<TR>
																				<TD >
																					<table border="0" cellspacing="0" cellpadding="0">
																						<TR>
																							<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																							<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																								<asp:linkbutton class="CommandButton" id="updateButton" runat="server" text="更新" borderstyle="none"></asp:linkbutton></TD>
																							<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																						</TR>
																					</table>
																				</TD>
																				<TD >
																					<TABLE cellSpacing="0" cellPadding="0" border="0">
																						<TR>
																							<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																							<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																								<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" text="取消" borderstyle="none"
																									causesvalidation="False"></asp:linkbutton></TD>
																							<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																						</TR>
																					</TABLE>
																				</TD>
																				<TD ><FONT face="新細明體">
																						<table border="0" cellspacing="0" cellpadding="0" >
																							<TR>
																								<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																								<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																									<asp:linkbutton class="CommandButton" id="deleteButton" runat="server" text="刪除此項目" borderstyle="none"
																										causesvalidation="False"></asp:linkbutton></TD>
																								<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																							</TR>
																						</table>
																					</FONT>
																				</TD>
																			</TR>
																		</TABLE>
																		<hr noshade size="1" width="500">
																		<span class="Normal">建立者
                                            <asp:label id="CreatedBy" runat="server" />
                                            建立日期
                                            <asp:label id="CreatedDate" runat="server" />
                                            <br>
                                        </span>
																	<P></P>
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
