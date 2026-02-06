<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="queryDegS.aspx.vb" Inherits=".queryDegS" %>

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
													<FONT color="#003366">自報度數資料來源查詢</FONT><font color="red"></font></FONT></td>
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
																		  <asp:label id="Label1" runat="server" CssClass="normal" Width="96px">抄表年月:</asp:label>
                                                                         </FONT>
																	</TD>
                                                                    <TD >                                                                     
																       <asp:textbox id="txtYM" runat="server" Width="60px" MaxLength="7"></asp:textbox>
                                                                      <FONT face="細明體" color="#3399cc" size="2"> (請輸年月ex:10901) </FONT>
																  </TD>
															
																</TR>
																<TR>
                                                                    <td>
                                                                        <font face="新細明體"><FONT face="新細明體" size="2">
																		<asp:label id="Label6" runat="server" CssClass="normal" Width="96px">輸入冊別</asp:label>
                                                                    </FONT></td>
                                                                    <td>
																	   <asp:textbox id="VolNoS" runat="server" Width="56px" MaxLength="3"></asp:textbox>
                                                                       至
                                                                     <asp:textbox id="VolNoE" runat="server" Width="56px" MaxLength="3"></asp:textbox>
                                                                     
                                                                    </td>
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
														
															<asp:TemplateColumn HeaderText="來源">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.kind")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="抄表人員">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.clip_name")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
                                                             <asp:TemplateColumn HeaderText="登錄日期">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.input_dt")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="冊別">
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AM01_VOL_NO") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="用戶號碼">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id=AccountNo runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AX33_HOUSE_NO") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="裝置地址">
																<HeaderStyle Width="30%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>															
															<asp:BoundColumn DataField="tel" HeaderText="聯絡電話">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
                                                             <asp:BoundColumn DataField="AX33_NOTE" HeaderText="交辦事項">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>

                                                           
                                                            <asp:BoundColumn DataField="AX33_MTR_POINT" HeaderText="自報度數">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
                                                             <asp:BoundColumn DataField="AX33_FILE_SEQ" HeaderText="語音檔號">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>

                                                             <asp:BoundColumn DataField="input_name" HeaderText="登錄人員">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															
                                                             <asp:BoundColumn DataField="AX33_CHK" HeaderText="已確認">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
                                                             <asp:BoundColumn DataField="AX33_USE" HeaderText="使用">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
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
