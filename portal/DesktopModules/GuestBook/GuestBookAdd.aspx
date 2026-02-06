<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuestBookAdd.aspx.vb" Inherits="ASPNET.StarterKit.Portal.GuestBookAdd" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet>
			<script language="javascript" type="text/javascript">
function emote(emotion)
{
	var ctl;
	ctl=this.document.forms['Form1'].TextBoxDescription;
	ctl.value += "{/" + emotion + "}";
}
			</script>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner>
			<table cellSpacing="0" cellPadding="0" width="800" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">留言資料</asp:label></td>
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
														<P><FONT face="新細明體">
																<P>&nbsp; <FONT face="新細明體">
																</P>
																<P>
																	<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
																		<TR>
																			<TD width="78">
																				<asp:Label id="Label4" runat="server" CssClass="subhead">標題：</asp:Label></TD>
																			<TD>
																				<asp:TextBox id="TextBoxTitle" runat="server" Width="342px"></asp:TextBox>
																				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
																					ControlToValidate="TextBoxTitle" CssClass="normalred">請輸入標題!</asp:RequiredFieldValidator></TD>
																		</TR>
																		<TR>
																			<TD vAlign="top" width="78">
																				<asp:Label id="Label3" runat="server" CssClass="subhead" Width="80px">留言內容</asp:Label></TD>
																			<TD>
																				<asp:TextBox id="TextBoxDescription" runat="server" TextMode="MultiLine" Rows="5" Width="344px"
																					Height="142px"></asp:TextBox>
																				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
																					ControlToValidate="TextBoxDescription" CssClass="normalred">請輸入內容!</asp:RequiredFieldValidator></TD>
																		</TR>
																		<TR>
																			<TD width="78">
																				<asp:Label id="Label2" runat="server" CssClass="subhead">時間：</asp:Label></TD>
																			<TD>
																				<asp:label id="LabelCreatedDate" runat="server" CssClass="normal">Date</asp:label></TD>
																		</TR>
																		<TR>
																			<TD width="78">
																				<asp:Label id="Label1" runat="server" CssClass="subhead">留言者：</asp:Label></TD>
																			<TD>
																				<asp:TextBox id="TextBoxUser" runat="server"></asp:TextBox>
																				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxUser" ErrorMessage="請輸入您的大名!"
																					CssClass="normalred"></asp:RequiredFieldValidator></TD>
																		</TR>
																		<TR>
																			<TD colSpan="2">
																				<asp:CheckBox id="CheckBoxEmail" runat="server" Text="以電子郵件方式回覆留言" AutoPostBack="True" CssClass="normal"></asp:CheckBox><BR>
																				<asp:Label id="LabelEmail" runat="server" Visible="False" CssClass="normal">電子郵件帳號：</asp:Label>
																				<asp:TextBox id="TextBoxEmail" runat="server" Visible="False"></asp:TextBox></TD>
																		</TR>
																	</TABLE>
															</FONT></FONT>
														</P>
													</td>
													<td vAlign="top" align="left">
														<P>&nbsp;</P>
														<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD>
																	<asp:Label id="Label5" runat="server" CssClass="subhead">表情：</asp:Label></TD>
															</TR>
															<TR>
																<TD>
																	<P>
																		<table cellpadding="1" cellspacing="0" border='0' bordercolor='#e9e9e9' align='center'>
																			<TR align="center">
																				<TD><IMG onclick="emote('jy')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/jy.gif"></TD>
																				<TD><IMG onclick="emote('pz')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/pz.gif"></TD>
																				<TD><IMG onclick="emote('se')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/se.gif"></TD>
																				<TD><IMG onclick="emote('fd')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/fd.gif"></TD>
																				<TD><IMG onclick="emote('dy')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dy.gif"></TD>
																				<TD><IMG onclick="emote('ll')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ll.gif"></TD>
																				<TD><IMG onclick="emote('hx')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/hx.gif"></TD>
																				<TD><IMG onclick="emote('bz')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/bz.gif"></TD>
																				<TD><IMG onclick="emote('shui')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/shui.gif"></TD>
																				<TD><IMG onclick="emote('dk')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dk.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('gg')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/gg.gif"></TD>
																				<TD><IMG onclick="emote('fn')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/fn.gif"></TD>
																				<TD><IMG onclick="emote('tp')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/tp.gif"></TD>
																				<TD><IMG onclick="emote('cy')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/cy.gif"></TD>
																				<TD><IMG onclick="emote('wx')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/wx.gif"></TD>
																				<TD><IMG onclick="emote('ng')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ng.gif"></TD>
																				<TD><IMG onclick="emote('kuk')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/kuk.gif"></TD>
																				<TD><IMG onclick="emote('feid')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/feid.gif"></TD>
																				<TD><IMG onclick="emote('zk')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zk.gif"></TD>
																				<TD><IMG onclick="emote('tu')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/tu.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('tx')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/tx.gif"></TD>
																				<TD><IMG onclick="emote('ka')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ka.gif"></TD>
																				<TD><IMG onclick="emote('by')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/by.gif"></TD>
																				<TD><IMG onclick="emote('am')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/am.gif"></TD>
																				<TD><IMG onclick="emote('jie')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/jie.gif"></TD>
																				<TD><IMG onclick="emote('kun')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/kun.gif"></TD>
																				<TD><IMG onclick="emote('jk')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/jk.gif"></TD>
																				<TD><IMG onclick="emote('lh')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/lh.gif"></TD>
																				<TD><IMG onclick="emote('hanx')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/hanx.gif"></TD>
																				<TD><IMG onclick="emote('db')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/db.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('fendou')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/fendou.gif"></TD>
																				<TD><IMG onclick="emote('zhm')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zhm.gif"></TD>
																				<TD><IMG onclick="emote('yiw')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yiw.gif"></TD>
																				<TD><IMG onclick="emote('xu')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/xu.gif"></TD>
																				<TD><IMG onclick="emote('yun')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yun.gif"></TD>
																				<TD><IMG onclick="emote('zhem')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zhem.gif"></TD>
																				<TD><IMG onclick="emote('shuai')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/shuai.gif"></TD>
																				<TD><IMG onclick="emote('kl')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/kl.gif"></TD>
																				<TD><IMG onclick="emote('qiao')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/qiao.gif"></TD>
																				<TD><IMG onclick="emote('zj')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zj.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD height="32"><IMG onclick="emote('shan')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/shan.gif"></TD>
																				<TD height="32"><IMG onclick="emote('fad')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/fad.gif"></TD>
																				<TD height="32"><IMG onclick="emote('aiq')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/aiq.gif"></TD>
																				<TD height="32"><IMG onclick="emote('tiao')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/tiao.gif"></TD>
																				<TD height="32"><IMG onclick="emote('zhao')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zhao.gif"></TD>
																				<TD height="32"><IMG onclick="emote('mm')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/mm.gif"></TD>
																				<TD height="32"><IMG onclick="emote('zt')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zt.gif"></TD>
																				<TD height="32"><IMG onclick="emote('maom')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/maom.gif"></TD>
																				<TD height="32"><IMG onclick="emote('xg')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/xg.gif"></TD>
																				<TD height="32"><IMG onclick="emote('yb')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yb.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('qianc')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/qianc.gif"></TD>
																				<TD><IMG onclick="emote('dp')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dp.gif"></TD>
																				<TD><IMG onclick="emote('bei')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/bei.gif"></TD>
																				<TD><IMG onclick="emote('dg')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dg.gif"></TD>
																				<TD><IMG onclick="emote('shd')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/shd.gif"></TD>
																				<TD><IMG onclick="emote('zhd')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zhd.gif"></TD>
																				<TD><IMG onclick="emote('dao')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dao.gif"></TD>
																				<TD><IMG onclick="emote('zq')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/zq.gif"></TD>
																				<TD><IMG onclick="emote('yy')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yy.gif"></TD>
																				<TD><IMG onclick="emote('bb')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/bb.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('cf')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/cf.gif"></TD>
																				<TD><IMG onclick="emote('fan')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/fan.gif"></TD>
																				<TD><IMG onclick="emote('yw')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yw.gif"></TD>
																				<TD><IMG onclick="emote('mg')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/mg.gif"></TD>
																				<TD><IMG onclick="emote('dx')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dx.gif"></TD>
																				<TD><IMG onclick="emote('wen')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/wen.gif"></TD>
																				<TD><IMG onclick="emote('xin')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/xin.gif"></TD>
																				<TD><IMG onclick="emote('xs')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/xs.gif"></TD>
																				<TD><IMG onclick="emote('hy')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/hy.gif"></TD>
																				<TD><IMG onclick="emote('lw')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/lw.gif"></TD>
																			</TR>
																			<TR align="center">
																				<TD><IMG onclick="emote('dh')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/dh.gif"></TD>
																				<TD><IMG onclick="emote('sj')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/sj.gif"></TD>
																				<TD><IMG onclick="emote('yj')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yj.gif"></TD>
																				<TD><IMG onclick="emote('ds')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ds.gif"></TD>
																				<TD><IMG onclick="emote('ty')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ty.gif"></TD>
																				<TD><IMG onclick="emote('yl')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/yl.gif"></TD>
																				<TD><IMG onclick="emote('qiang')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/qiang.gif"></TD>
																				<TD><IMG onclick="emote('ruo')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ruo.gif"></TD>
																				<TD><IMG onclick="emote('ws')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/ws.gif"></TD>
																				<TD><IMG onclick="emote('shl')" 
                              src="<%=Global.GetApplicationPath(Request)%>/images/emotion/shl.gif"></TD>
																			</TR>
																		</table>
																	</P>
																</TD>
															</TR>
														</TABLE>
													</td>
												</tr>
											</table>
											<asp:button id="ButtonAdd" runat="server" Text="確定"></asp:button>
											<asp:Button id="ButtonCancel" runat="server" Text="取消"></asp:Button>
											<asp:Button id="ButtonReturn" runat="server" Text="返回" CausesValidation="False"></asp:Button>
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
