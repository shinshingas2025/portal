<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubscriptionListAdmin.aspx.vb" Inherits="ASPNET.StarterKit.Portal.SubscriptionListAdmin" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link 
href='/Portalfiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">編輯訂閱清單</asp:label></td>
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
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR>
												<TD class="SubHead">
													<asp:Label id="Label4" runat="server" CssClass="subhead">電子報標題</asp:Label></TD>
												<TD class="SubHead">
													<asp:Label id="Label5" runat="server" CssClass="subhead">電子報描述</asp:Label></TD>
											</TR>
											<TR>
												<TD height="4"><asp:label id="LabelSubscriptionTitle" runat="server" CssClass="itemtitle"></asp:label></TD>
												<TD height="4"><asp:label id="LabelSubscriptionDescription" runat="server" CssClass="itemtitle"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2">
													<HR width="100%" SIZE="1">
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="2">
													<asp:Label id="Label3" runat="server" CssClass="subsubhead">訂閱者清單列表</asp:Label></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<th width="250">
																編號</th>
															<th width="100">
																姓名</th>
															<th width="400">
																電子郵件帳號</th>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="left" colSpan="2" width="750">
													<asp:datalist id="DataList1" runat="server" DataKeyField="EntityID" CssClass="itemtitle" Width="750px">
														<ItemTemplate>
															<asp:CheckBox id=CheckBox1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' AutoPostBack="False" width="260">
															</asp:CheckBox>
															<asp:Label id="Label1" runat="server" width="100">
																<%# DataBinder.Eval(Container.DataItem, "Name") %>
															</asp:Label>
															<asp:Label id="Label2" runat="server" width="380">
																<%# DataBinder.Eval(Container.DataItem, "Email") %>
															</asp:Label>
														</ItemTemplate>
													</asp:datalist>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="2">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="5%"><asp:linkbutton id="LinkButtonSubscriptionListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonSubscriptionListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
															<td align="center" width="80%"><asp:placeholder id="PlaceHolderSubscriptionListPageIndex" runat="server"></asp:placeholder></td>
															<td width="5%"><asp:linkbutton id="LinkButtonSubscriptionListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonSubscriptionListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="2"><asp:button id="ButtonSubscriptionListInsert" runat="server" Text="新增"></asp:button><asp:button id="ButtonSubscriptionListUpdate" runat="server" Text="修改"></asp:button><asp:button id="ButtonSubscriptionListDelete" runat="server" Text="刪除"></asp:button>
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
											</tr>
										</TABLE>
										<!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
							</TABLE>
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
				</table>
		</form>
		</P>
	</body>
</HTML>
