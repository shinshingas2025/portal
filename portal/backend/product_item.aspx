<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="product_item.aspx.vb" Inherits="product_item" %>
<script type="text/javascript" language="javascript">
    function checkfile(sender) {

        // 可接受的附檔名
        var validExts = new Array(".jpg", ".JPG");

        var fileExt = sender.value;
        fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
        if (validExts.indexOf(fileExt) < 0) {
            alert("檔案類型錯誤，可接受的副檔名有：" + validExts.toString());
            sender.value = null;
            return false;
        }
        else return true;
    }
    </script>
<!-- NAME: index.tpl --><tr>
	<td bgcolor="#A6C4E1"></td>
	<td bgcolor="#6699CC" width="930"></td>
	<td bgcolor="#A6C4E1"></td>
</tr>
<tr>
	<td bgcolor="#D2E1F0"></td>
	<td width="930">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
			<tr>
				<td vAlign="middle" align="center">
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">產品資料管理</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" width="748">
					<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
						<tr>
							<td align="center">
								<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" CellSpacing="1" BorderStyle="Ridge" BorderWidth="2px"
											CellPadding="3" ShowFooter="True" DataKeyField="pdno" AllowPaging="True" AutoGenerateColumns="False"
											BorderColor="White" BackColor="White" Width="600px" OnDeleteCommand="dgCart_Delete" AllowSorting="True"
											GridLines="None">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="群組">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
													<ItemTemplate>
														<%#Container.DataItem("pdgrpname")%>
														<FONT face="新細明體"></FONT>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="pdname" HeaderText="產品名稱">
													<HeaderStyle ForeColor="White" Width="40%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="圖形" Target="_blank" DataNavigateUrlField="pdimages" DataNavigateUrlFormatString="../UpImage/{0}"
													DataTextField="pdimages" HeaderText="產品圖形" NavigateUrl="圖形">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="pdno" DataNavigateUrlFormatString="product_item.aspx?pdno={0}"
													DataTextField="pdno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
													<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<%--
									<P><FONT face="新細明體">
											<asp:button id="btnFirstPage" runat="server" Text="第一頁" CommandName="第一頁" ToolTip="檢視第一頁資料"></asp:button><asp:button id="btnPreviousPage" runat="server" Text="上一頁" CommandName="上一頁" ToolTip="檢視上一頁資料"></asp:button><asp:button id="btnNextPage" runat="server" Text="下一頁" CommandName="下一頁" ToolTip="檢視下一頁資料"></asp:button><asp:button id="btnLastPage" runat="server" Text="最後一頁" CommandName="最後一頁" ToolTip="檢視最後一頁資料"></asp:button><BR>
									</P>
									--%>
									</FONT>
									<P><asp:label id="Message" runat="server"></asp:label></P>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
											border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="27"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>群組</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><asp:label id="txtdbpdgrp" runat="server"></asp:label><asp:dropdownlist id="txtpdgrp" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="lavender" height="27">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>產品名稱</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtname" runat="server" Width="352px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="28"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>產品簡介</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
															<asp:textbox id="txtintor" runat="server" Width="350px" TextMode="MultiLine" Height="156px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="28"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>詳細敘述</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:textbox id="txtcontent" runat="server" Width="350px" TextMode="MultiLine" Height="164px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="28">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>所屬廠商</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:textbox id="txtcompany" runat="server" Width="352px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="99"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>廠商資訊</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="99">
														<asp:textbox id="txtcompanyinfor" runat="server" Width="350px" TextMode="MultiLine" Height="92px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="10">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>建議售價</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:TextBox id="AccountText" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="#e6e6fa" height="28">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>廠商連結</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:textbox id="txtcompanylink" runat="server" Width="350px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD width="117" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>圖形上傳</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體">
															<asp:label id="txtdbfile" runat="server"></asp:label><INPUT type="file" id="txtfile" name="txtfile" runat="server" style="WIDTH: 344px; HEIGHT: 22px"  onchange="checkfile(this);" 
																size="38"> </FONT>
													</TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<% If (Request("pdno") IS Nothing) Then %>
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
														<% 
											Else 
											Response.write("<INPUT id='pdno' type='hidden' value='" & Request("pdno") & "'>")
										%>
														<asp:button id="btnupdate" runat="server" Text="儲存"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
														<% End If %>
														<INPUT type="reset" value="清除"></FONT></TD>
												</TR>
												<TR>
													<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
												</TR>
											</TBODY>
										</TABLE>
									</P>
								</form>
								</FORM></td>
						</tr>
					</table>
					<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
					<P><FONT face="新細明體"></FONT><br>
					</P>
					<p><FONT face="新細明體"></FONT></p>
				</td>
			</tr>
		</table>
	</td>
	<td bgcolor="#D2E1F0">&nbsp;</td>
</tr>
<tr bgcolor="#000000">
	<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></ASP:FILEUPLOAD>
