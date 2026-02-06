<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Votes" CodeBehind="Votes.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<table cellSpacing="0" cellPadding="0" width="98%" border="0">
	<tr>
		<td colSpan="3"><ASPNETPORTAL:TITLE id="Title1" EditText="編輯資料" EditUrl="~/DesktopModules/Votes/VotesAdmin.aspx" runat="server"></ASPNETPORTAL:TITLE></td>
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
				<TR>
					<TD vAlign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td width="20"><IMG alt=項目 src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' ></td>
								<TD><asp:label id="VoteSubject" runat="server" CssClass="subHead"></asp:label></TD>
								<td></td>
							</TR>
							<TR>
								<TD colSpan="3"><FONT face="新細明體">
										<HR width="100%" SIZE="1">
									</FONT>
								</TD>
							</TR>
							<tr>
								<td><FONT face="新細明體"></FONT></td>
								<td colSpan="2"><asp:label id="VoteDescription" runat="server" Font-Size="X-Small"></asp:label></td>
							</tr>
							<tr>
								<td><FONT face="新細明體"></FONT></td>
								<td colSpan="2"><asp:placeholder id="OptionControl" runat="server"></asp:placeholder></td>
							</tr>
							<tr>
								<td colspan="3" align="right"><asp:label id="VoteDateLabel" runat="server" CssClass="small" Font-Size="X-Small" ForeColor="RoyalBlue"></asp:label></td>
							</tr>
							<TR>
								<TD colSpan="3"><FONT face="新細明體">
										<DIV align="right">
											<table cellPadding="0" align="right" border="0" cellspacing0>
												<TR>
													<TD>
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																<TD 
                            background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																	<asp:linkbutton id="VoteLinkButton" runat="server" CssClass="CommandButton">我要投票</asp:linkbutton></TD>
																<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
															</TR>
														</TABLE>
													</TD>
													<TD>
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																<TD 
                            background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																	<asp:linkbutton id="ResultLinkButton" runat="server" CssClass="CommandButton">看結果</asp:linkbutton></TD>
																<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</table>
										</DIV>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3"><FONT face="新細明體">
										<asp:label id="ResultLabel" runat="server" CssClass="normalred" Font-Size="X-Small"></asp:label></FONT></TD>
							</TR>
						</TABLE>
						<P align="right"><ASPNETPORTAL:BOTTOM id="Title2" EditText="更多資料" EditUrl="~/DesktopModules/Votes/VotesList.aspx" runat="server"></ASPNETPORTAL:BOTTOM></P>
						<!----------------------------------------------------------------------------------------------------------------------></TD>
				</TR>
			</TABLE>
		</td>
		<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></td>
	</tr>
	<tr>
		<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif' ></td>
		<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ></td>
		<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></td>
	</tr>
</table>
