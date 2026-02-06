<%@ Page validateRequest="false" language="vb" CodeBehind="EditPrivateAnnounce.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditPrivateAnnounce" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2"><aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner></td>
				</tr>
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="100">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="750">
										<tr>
											<td class="Head" align="left">內容編輯
											</td>
										</tr>
										<tr>
											<td colSpan="2">
												<hr noShade SIZE="1">
											</td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="720">
										<tr vAlign="top">
											<td class="SubHead" width="72">&nbsp;內容摘要
											</td>
											<td vAlign="middle" align="center" width="133" colSpan="2"><FONT face="新細明體"><asp:textbox id="DesktopText" runat="server" textmode="multiline" rows="5" columns="80">
											
											<font color=blue size=2>隱私權保護服務及宣告</font>
											</asp:textbox></FONT></td>
											<td vAlign="top" align="left"></td>
										</tr>
										<TR>
											<TD class="SubHead" width="72" valign="top"><FONT face="新細明體">詳細內容</FONT></TD>
											<TD width="264" colSpan="3"><FONT face="新細明體">
													<asp:TextBox id="DetailText" runat="server" TextMode="MultiLine" Rows="13" Columns="80">
<font color=blue >隱私權保護服務及宣告</font><br>
<font size=2>
親愛的使用者，您的個人隱私權，校園聯名網網站（以下簡稱本站）絕對尊重並予以保護。為了幫助您瞭解，本站如何蒐集、應用及保護您所提供的個人資訊，請您詳細閱讀本局的隱私權保護政策。
<BR>適用範圍 <BR>
以下的隱私權保護政策，適用於您在本站活動時，所涉及的個人資料蒐集、運用與保護。線上登錄履歷表，本站會請您提供姓名、身分證字號、電話、 email 及住址等相關資料。 
本站會保留您在上網瀏覽或查詢時，伺服器自行產生的相關記錄，包括您使用連線設備的 IP 位址、使用時間、使用的瀏覽器、瀏覽及點選資料紀錄等。本站會對個別連線者的瀏覽器予以標示，歸納使用者瀏覽器在本站內部所瀏覽的網頁，除非您願意告知你的個人資料，否則本站不會亦無法將此項記錄對外公布。 
請您注意，在本站刊登廣告之機關，或與本站連結的網站，也可能蒐集您個人的資料。對於您主動提供的個人資訊，這些廣告機關、或連結網站有其個別的隱私權保護政策，其資料處理措施不適用本站隱私權保護政策，本站不負任何連帶責任。 
除了您主動登錄網站，提供的個人資料之外，您也可能在本站中的留言版主動提供個人資料如電子郵件、姓名等。這種形式的資料提供，不在本站隱私權保護政策的範圍之內。 <BR>
本站上述蒐集資料之運用宣告<BR> 
當您在本站主動註冊履歷成為會員後，其資料會連結匯入全國就業e網，其隱私權保也受到全國就業e網的隱私權保護服務，其所輸入的資料，僅供本站依服務或活動設計參考使用。凡未經您主動註冊所產生的資料，例如使用者機器的 IP 位址、使用時間、使用的瀏覽器、瀏覽及點選紀錄等資料，本站僅對全體使用者行為總和進行分析，並不會對個別使用者進行分析。 <BR>
本站cookies的運用與宣告 <BR>
Cookies 是伺服端為了區別使用者的不同喜好，經由瀏覽器寫入使用者硬碟的一些簡短資訊。您可以在 Netscape 的「功能設定」的「進階」或是 IE 的「 Internet 選項」的「安全性」中選擇修改您瀏覽器對 Cookies 的接受程度，包括接受所有 cookies 、設定 cookies 時得到通知、拒絕所有 cookies 等 3 種。如果您選擇拒絕所有的 cookies ，您就可能無法使用部份個人化服務，或是參與部份的活動。 
依據以下目的及情況，本站會在本政策原則之下，在您瀏覽器中寫入並讀取 Cookies ：  <BR>
本站與第三者共用個人資料之政策本站絕不會任意出售、交換、或出租任何您的個人資料給其他團體或個人。以下 3 種狀況，本站會在本政策原則之下，與第三者共用您的個人資料。 <BR>
司法單位因公眾安全，要求本站公開特定個人資料時，本站將視司法單位合法正式的程序，以及對本站所有使用者安全考量下做可能必要的配合。 <BR>
當有人可能違反本站服務條款，或者可能損害或妨礙本站、本站使用者或相關第三人之權益時，若本站有理由相信揭露此資料係為辨識、連絡或對該人採取法律行動所必要者，本站得揭露使用者之個人資料。此外，基於善意相信揭露為法律需要，或為維護和改進產品、服務而用於管理或其他目的時，本站亦得揭露或讀取使用者之個人資料。  <BR>
本站傳送宣傳本網站資訊或電子郵件之宣告 <BR><BR>
請妥善保管您的密碼及或任何個人資料，不要將任何個人資料，尤其是密碼提供給任何人。<BR>
本站隱私權保護政策諮詢 <BR>若您對自己在本站的隱私權有任何疑問，都歡迎您與我們聯絡。<BR>													
													
													</asp:TextBox></FONT></TD>
										</TR>
										<!--tr valign="top">
											<td class="SubHead">
												行動摘要 (選擇項):
											</td>
											<td>
												&nbsp;&nbsp;
											</td>
											<td>
												<asp:textbox id="MobileSummary" columns="75" width="650" rows="3" textmode="multiline" runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												行動詳細資料 (選擇項):
											</td>
											<td>
												&nbsp;&nbsp;
											</td>
											<td>
												<asp:textbox id="MobileDetails" columns="75" width="650" rows="5" textmode="multiline" runat="server" />
											</td>
										</tr--></table>
									<p>
										<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
										&nbsp;
										<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
											borderstyle="none" />
										&nbsp;
									</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
