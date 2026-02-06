<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuestBookReview.aspx.vb" Inherits="ASPNET.StarterKit.Portal.GuestBookReview" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
			<script language='javascript'>
function emote(emotion)
{
	var ctl;
	ctl=this.document.forms['Form1'].TextBoxReply;
	ctl.value += "{/" + emotion + "}";
}
			</script>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner>
			<table cellSpacing="0" cellPadding="0" width="768" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">詳細資料</asp:label></td>
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
													<td width="394">
														<P><FONT face="新細明體">
														</P>
														<FONT face="新細明體">
															<P>
																<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
																	<TR>
																		<TD width="106">
																			<asp:Label id="Label1" runat="server" CssClass="subhead">標題：</asp:Label></TD>
																		<TD>
																			<P><asp:label id="LabelTitle" runat="server" CssClass="normal"></asp:label></P>
																		</TD>
																	</TR>
																	<TR>
																		<TD width="106">
																			<asp:Label id="Label2" runat="server" CssClass="subhead">留言內容：</asp:Label></TD>
																		<TD>
																			<P><asp:label id="LabelDescription" runat="server" CssClass="normal"></asp:label></P>
																		</TD>
																	</TR>
																	<TR>
																		<TD width="106">
																			<asp:Label id="Label3" runat="server" CssClass="subhead">時間：</asp:Label></TD>
																		<TD>
																			<asp:label id="LabelCreatedDate" runat="server" CssClass="normal"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="106">
																			<asp:Label id="Label4" runat="server" CssClass="subhead">留言者：</asp:Label></TD>
																		<TD>
																			<asp:label id="LabelCreatedByUser" runat="server" CssClass="normal"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="106">
																			<asp:Label id="LabelEmail" runat="server" Visible="False" CssClass="subhead" Width="112px">電子郵件帳號：</asp:Label></TD>
																		<TD>
																			<P>
																				<asp:Label id="LabelEmailText" runat="server" Visible="False" CssClass="normal"></asp:Label></P>
																		</TD>
																	</TR>
																	<TR>
																		<TD vAlign="top" width="106">
																			<asp:Label id="Label5" runat="server" CssClass="subhead">回覆：</asp:Label></TD>
																		<TD><asp:textbox id="TextBoxReply" runat="server" TextMode="MultiLine" Rows="10" Width="275px"></asp:textbox>
																			<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="normalred" ControlToValidate="TextBoxReply"
																				ErrorMessage="RequiredFieldValidator" DESIGNTIMEDRAGDROP="56">請輸入回覆內容!</asp:requiredfieldvalidator></TD>
																	</TR>
																	<TR>
																		<TD width="106"></TD>
																		<TD></TD>
																	</TR>
																</TABLE>
														</FONT></FONT></P>
													</td>
													<td>
														<table cellpadding="0" cellspacing="0" border='0' bordercolor='#e9e9e9' align='center'>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/jy.gif' onclick="emote('jy')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/pz.gif' onclick="emote('pz')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/se.gif' onclick="emote('se')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/fd.gif' onclick="emote('fd')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dy.gif' onclick="emote('dy')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ll.gif' onclick="emote('ll')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/hx.gif' onclick="emote('hx')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/bz.gif' onclick="emote('bz')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/shui.gif' onclick="emote('shui')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dk.gif' onclick="emote('dk')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/gg.gif' onclick="emote('gg')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/fn.gif' onclick="emote('fn')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/tp.gif' onclick="emote('tp')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/cy.gif' onclick="emote('cy')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/wx.gif' onclick="emote('wx')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ng.gif' onclick="emote('ng')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/kuk.gif' onclick="emote('kuk')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/feid.gif' onclick="emote('feid')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zk.gif' onclick="emote('zk')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/tu.gif' onclick="emote('tu')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/tx.gif' onclick="emote('tx')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ka.gif' onclick="emote('ka')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/by.gif' onclick="emote('by')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/am.gif' onclick="emote('am')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/jie.gif' onclick="emote('jie')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/kun.gif' onclick="emote('kun')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/jk.gif' onclick="emote('jk')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/lh.gif' onclick="emote('lh')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/hanx.gif' onclick="emote('hanx')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/db.gif' onclick="emote('db')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/fendou.gif' onclick="emote('fendou')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zhm.gif' onclick="emote('zhm')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yiw.gif' onclick="emote('yiw')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/xu.gif' onclick="emote('xu')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yun.gif' onclick="emote('yun')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zhem.gif' onclick="emote('zhem')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/shuai.gif' onclick="emote('shuai')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/kl.gif' onclick="emote('kl')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/qiao.gif' onclick="emote('qiao')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zj.gif' onclick="emote('zj')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/shan.gif' onclick="emote('shan')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/fad.gif' onclick="emote('fad')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/aiq.gif' onclick="emote('aiq')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/tiao.gif' onclick="emote('tiao')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zhao.gif' onclick="emote('zhao')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/mm.gif' onclick="emote('mm')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zt.gif' onclick="emote('zt')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/maom.gif' onclick="emote('maom')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/xg.gif' onclick="emote('xg')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yb.gif' onclick="emote('yb')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/qianc.gif' onclick="emote('qianc')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dp.gif' onclick="emote('dp')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/bei.gif' onclick="emote('bei')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dg.gif' onclick="emote('dg')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/shd.gif' onclick="emote('shd')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zhd.gif' onclick="emote('zhd')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dao.gif' onclick="emote('dao')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/zq.gif' onclick="emote('zq')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yy.gif' onclick="emote('yy')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/bb.gif' onclick="emote('bb')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/cf.gif' onclick="emote('cf')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/fan.gif' onclick="emote('fan')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yw.gif' onclick="emote('yw')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/mg.gif' onclick="emote('mg')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dx.gif' onclick="emote('dx')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/wen.gif' onclick="emote('wen')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/xin.gif' onclick="emote('xin')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/xs.gif' onclick="emote('xs')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/hy.gif' onclick="emote('hy')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/lw.gif' onclick="emote('lw')"></td>
															</tr>
															<tr align='center'>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/dh.gif' onclick="emote('dh')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/sj.gif' onclick="emote('sj')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yj.gif' onclick="emote('yj')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ds.gif' onclick="emote('ds')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ty.gif' onclick="emote('ty')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/yl.gif' onclick="emote('yl')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/qiang.gif' onclick="emote('qiang')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ruo.gif' onclick="emote('ruo')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/ws.gif' onclick="emote('ws')"></td>
																<td><img src='<%=Global.GetApplicationPath(Request)%>/images/emotion/shl.gif' onclick="emote('shl')"></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<asp:button id="ButtonReply" runat="server" Text="回覆"></asp:button>
											<asp:Button id="ButtonDelete" runat="server" Text="刪除"></asp:Button>
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
