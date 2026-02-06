<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="querymeber_house.aspx.vb" Inherits="querymeber_house" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    	<table>
				<tr>
					<td bgColor="#a6c4e1"></td>
					<td width="930" bgColor="#6699cc"></td>
					<td bgColor="#a6c4e1"></td>
				</tr>
				<tr>
					<td bgColor="#d2e1f0"></td>
					<td width="930">
						<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
							<tr>
								<td vAlign="middle" align="center">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="666">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">用戶號碼多次新增明細</FONT><font color="red"></font></FONT></td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" CssClass="normal" ForeColor="Red"></asp:label></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="748">
									<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="left" height="92">
												<TABLE height="112" cellSpacing="0" cellPadding="0" width="620" border="0" ms_1d_layout="TRUE">
													<TR>
														<TD>
															<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="600" border="0">
																<TR>
																	<TD width="40px;">
                                                                        <FONT face="新細明體"><FONT face="新細明體" size="2">
																		  <asp:label id="Label1" runat="server" CssClass="normal" Width="96px">日期:</asp:label>
                                                                         </FONT>
																	</TD>
                                                                    <TD >                                                                     
																       <asp:textbox id="txtYMDS" runat="server" Width="100px" MaxLength="8"></asp:textbox>~
                                                                       <asp:textbox id="txtYMDE" runat="server" Width="100px" MaxLength="8"></asp:textbox>~
                                                                      <FONT face="細明體" color="#3399cc" size="2"> (請輸西元年月日ex:20230101) </FONT>
																  </TD>
															
																</TR>
																<TR>
                                                                    <td>
                                                                        <font face="新細明體"><FONT face="新細明體" size="2">
																		<asp:label id="Label6" runat="server" CssClass="normal" Width="96px">用戶號碼</asp:label>
                                                                    </FONT></td>
                                                                    <td>
																	   <asp:textbox id="txtHouseNo" runat="server" Width="100px" MaxLength="7"></asp:textbox>
                                                                     
                                                                    </td>
																   </TR>                                                               
                                                                <TR>
																	<TD ><FONT face="新細明體" size="2"><asp:label id="Label3" runat="server" Width="72px">類別</asp:label></FONT></TD>
																	<TD><FONT face="新細明體">
                                                                        
                                                                        <asp:DropDownList ID ="selType" runat="server" >
                                                                            <asp:ListItem Text="顯示全部" Value="" ></asp:ListItem>
                                                                             <asp:ListItem Text="只顯示新增" Value="1" ></asp:ListItem>
                                                                        </asp:DropDownList>
																	    </FONT></TD>
																	<TD ></TD>
																</TR>
																 <TR>
																	<TD ><FONT face="新細明體" size="2"><asp:label id="Label2" runat="server" Width="72px">查詢單位</asp:label></FONT></TD>
																	<TD><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																	<TD ></TD>
																</TR>
																<TR>
																	<TD ><FONT face="新細明體"><FONT face="新細明體" size="2"><asp:label id="Label5" runat="server" Width="64px">查詢人員</asp:label></FONT></FONT></TD>
																	<TD><asp:label id="Creater" runat="server" ></asp:label>
                                                                        <asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<hr>
											</TD>
										</TR>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="688px" CellSpacing="1" GridLines="None" BackColor="White"
														BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" 
														AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<SelectedItemStyle  Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
															BackColor="#9471DE"></SelectedItemStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
														
															<asp:TemplateColumn HeaderText="用戶號碼" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="lblHouseNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mh_house_no")%>'>
																	</asp:Label>
																</ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
															</asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="新增日期" HeaderStyle-HorizontalAlign="Center" >
																<HeaderStyle Width="30%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="lblAddDT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.add_datetime")%>'>
																	</asp:Label>
																</ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
															</asp:TemplateColumn>
                                                             <asp:TemplateColumn HeaderText="新增帳號" HeaderStyle-HorizontalAlign="Center" >
																<HeaderStyle Width="20%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="lblAddUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.add_user")%>'>
																	</asp:Label>
																</ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" />
															</asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="推廣人員" HeaderStyle-HorizontalAlign="Center" >
																<HeaderStyle Width="15%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="lblAddUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mh_gen_user") %>'>
																	</asp:Label>
																</ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
															</asp:TemplateColumn>

                                                               <asp:TemplateColumn HeaderText="類別" HeaderStyle-HorizontalAlign="Center" >
																<HeaderStyle Width="20%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cupdate") %>'>
																	</asp:Label>
																</ItemTemplate>
                                                                   <ItemStyle HorizontalAlign="Center" />
															</asp:TemplateColumn>															
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
												</FONT>
												<P><asp:label id="Message" runat="server"></asp:label></P>
											</td>
										</tr>
									</table>
									<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
									</p>
									<p><FONT face="新細明體"></FONT></p>
								</td>
							</tr>
						</table>
					</td>
					<td bgColor="#d2e1f0">&nbsp;</td>
				</tr>
			</table>
    </form>
</body>
</html>
