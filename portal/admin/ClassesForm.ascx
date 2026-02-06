<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.ClassesForm" CodeBehind="ClassesForm.ascx.vb" AutoEventWireup="false" %>
<table cellSpacing="0" cellPadding="0" width="98%" border="0">
	<tr>
		<td colSpan="3"><ASPNETPORTAL:TITLE id="Title1" runat="server" EditUrl="~/admin/EditClasses.aspx"></ASPNETPORTAL:TITLE></td>
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
		<td width="100%" bgColor="#ffffff">
			<table width="100%" border="0">
				<tr>
					<td><asp:datalist id="DataList1" runat="server">
							<itemtemplate>
								<span class="Normal">
									<img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'>
									<asp:HyperLink id="editLink" ImageUrl="<%# linkImage %>" NavigateUrl='<%# ChooseURL(DataBinder.Eval(Container.DataItem,"EntityID"), ModuleId, DataBinder.Eval(Container.DataItem,"EntityID")) %>' Target='<%# ChooseTarget() %>' ToolTip='<%# ChooseTip(DataBinder.Eval(Container.DataItem,"ClassTitle")) %>' runat="server" />
									<asp:HyperLink Text='<%# DataBinder.Eval(Container.DataItem,"ClassTitle") %>' NavigateUrl='<%# "signupform.aspx?ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem,"ClassTitle") %>' Target="_new" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
								</span>
								<br>
							</itemtemplate>
						</asp:datalist></td>
				</tr>
			</table>
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
