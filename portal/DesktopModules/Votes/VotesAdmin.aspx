<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="VotesAdmin.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.VotesAdmin" %>
<HTML>
	<HEAD>
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner><FONT face="新細明體"><BR>
				<BR>
			</FONT>
			<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=104 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">所有投票列表</asp:label></td>
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
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td>
														<DIV align="left"><asp:datalist id="myDataList" runat="server" DataKeyField="EntityID">
																<ItemTemplate>
																	<asp:CheckBox id="Delete" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionAlias") %>' AutoPostBack="False" CssClass="normal">
																	</asp:CheckBox>
																</ItemTemplate>
															</asp:datalist></DIV>
													</td>
												</tr>
												<tr>
													<td>
														<P align="center">
															<asp:LinkButton id="LinkButtonPageUp" runat="server" CssClass="normal">上一頁</asp:LinkButton>
															<asp:LinkButton id="LinkButtonPageDown" runat="server" CssClass="normal">下一頁</asp:LinkButton></P>
													</td>
													<td></td>
												</tr>
												<tr>
													<td><FONT face="新細明體">
															<P align="center">
																<asp:Button id="ButtonAdd" runat="server" Text="新增"></asp:Button>
																<asp:Button id="ButtonModify" runat="server" Text="修改"></asp:Button>
																<asp:button id="ButtonDelete" runat="server" Text="刪除"></asp:button>
																<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></P>
														</FONT>
													</td>
												</tr>
											</table>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
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
