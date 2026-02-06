<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Contacts" CodeBehind="Contacts.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title  EditUrl="~/DesktopModules/EditContacts.aspx" runat="server" id="Title1" />
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="ffffff">
		
		<TABLE border="0">
				<TBODY>
					<TR>
						<TD vAlign="top">		
<!---------------------------------------------------------------------------------------------------------------------->		
		

						
						
						
							<asp:datagrid id="myDataGrid" Border="0" width="100%" AutoGenerateColumns="False" EnableViewState="False"
								runat="server" BorderColor="Aqua">
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# "~/DesktopModules/EditContacts.aspx?ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID") & "&mid=" & ModuleId & "&sid=" & ctype(session("sid"),string) %>' Visible="<%# IsEditable %>" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
											<Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'  alt=項目>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Name" HeaderText="名稱">
										<HeaderStyle CssClass="NormalBold"></HeaderStyle>
										<ItemStyle CssClass="Normal"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Role" HeaderText="角色">
										<HeaderStyle CssClass="NormalBold"></HeaderStyle>
										<ItemStyle CssClass="Normal"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Email" HeaderText="電子郵件地址">
										<HeaderStyle CssClass="NormalBold"></HeaderStyle>
										<ItemStyle CssClass="Normal"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Contact1" HeaderText="連絡人 1">
										<HeaderStyle CssClass="NormalBold"></HeaderStyle>
										<ItemStyle CssClass="Normal"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Contact2" HeaderText="連絡人 2">
										<HeaderStyle CssClass="NormalBold"></HeaderStyle>
										<ItemStyle CssClass="Normal"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
				
				


<!---------------------------------------------------------------------------------------------------------------------->				
			</TD></TR>
				</TBODY>	
				</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>
