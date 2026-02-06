<%@ Page CodeBehind="HTMLeditor.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.HTMLeditor" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>HTML編輯器</TITLE> 
		<!-- saved from url=(0044)http://dob.tnc.edu.tw/authorHD/74/editor.htm -->
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<STYLE>BODY { FONT-SIZE: 12px; FONT-FAMILY: 細明體 }
	TD { FONT-SIZE: 12px; FONT-FAMILY: 細明體 }
	BUTTON { FONT-SIZE: 12px; FONT-FAMILY: 細明體 }
	INPUT { FONT-SIZE: 12px; FONT-FAMILY: 細明體 }
	DIV { BORDER-RIGHT: #d9cec4 1px solid; BORDER-TOP: #d9cec4 1px solid; BACKGROUND: #d9cec4; BORDER-LEFT: #d9cec4 1px solid; WIDTH: 24px; CURSOR: default; BORDER-BOTTOM: #d9cec4 1px solid; HEIGHT: 20px; TEXT-ALIGN: center; borderColor: #ffffff }
	.function { WIDTH: 80px }
	</STYLE>
		<SCRIPT>
function BtnOver(btn){
btn.style.borderTopColor="#efece8";
btn.style.borderBottomColor="#888070";
btn.style.borderLeftColor="#efece8";
btn.style.borderRightColor="#888070";
}
function BtnClick(btn){
btn.style.borderTopColor="#888070";
btn.style.borderBottomColor="#efece8";
btn.style.borderLeftColor="#888070";
btn.style.borderRightColor="#efece8";
}
function BtnOut(btn){
btn.style.borderColor="#d9cec4";
}
function doCut(){
doc.execCommand('Cut');
Editor.focus();
}
function doCopy(){
doc.execCommand('Copy');
Editor.focus();
}
function doPaste(){
doc.execCommand('Paste');
Editor.focus();
}
function doUndo(){
doc.execCommand('Undo');
Editor.focus();
}
function doDelete(){
doc.execCommand('Delete');
Editor.focus();
}
function doFontName(fn){
doc.execCommand('FontName', false, fn);
Editor.focus();
}
function doFontSize(fs){
doc.execCommand('FontSize', false, fs);
Editor.focus();
}
function doBold(){
doc.execCommand('Bold');
Editor.focus();
}
function doItalic(){
doc.execCommand('Italic');
Editor.focus();
}
function doUnderline(){
doc.execCommand('Underline');
Editor.focus();
}
function doStrikeThrough(){
doc.execCommand('StrikeThrough');
Editor.focus();
}
function doSubscript(){
doc.execCommand('Subscript');
Editor.focus();
}
function doSuperscript(){
doc.execCommand('Superscript');
Editor.focus();
}
function doJustifyLeft(){
doc.execCommand('JustifyLeft');
Editor.focus();
}
function doJustifyRight(){
doc.execCommand('JustifyRight');
Editor.focus();
}
function doJustifyCenter(){
doc.execCommand('JustifyCenter');
Editor.focus();
}
function doIndent(){
doc.execCommand('Indent');
Editor.focus();
}
function doOutdent(){
doc.execCommand('Outdent');
Editor.focus();
}
function doForeColor(){
var fcolor=showModalDialog("editor_color.htm",false,"dialogWidth:106px;dialogHeight:126px;status:0;");
doc.execCommand('ForeColor',false,fcolor);
Editor.focus();
}
function doBackColor(){
var bcolor=showModalDialog("editor_color.htm",false,"dialogWidth:106px;dialogHeight:126px;status:0;");
doc.execCommand('BackColor',false,bcolor);
Editor.focus();
}
function doInsertTable(){
var dotable=showModalDialog("editor_table.htm",false,"dialogWidth:200px;dialogHeight:156px;status:0;");
if (dotable!=undefined){
doc.body.innerHTML=doc.body.innerHTML+dotable;
}else{
return false;
}
Editor.focus();
}
function doInsertOrderedList(){
doc.execCommand('InsertOrderedList');
Editor.focus();
}
function doInsertUnorderedList(){
doc.execCommand('InsertUnorderedList');
Editor.focus();
}
function doCreateLink(){
doc.execCommand('CreateLink');
Editor.focus();
}
function doInsertImage(){
Editor.focus();
doc.execCommand('InsertImage','xxx');
}
function doInsertInputButton(){
Editor.focus();
doc.execCommand('InsertInputButton');
}
function doInsertHorizontalRule(){
Editor.focus();
doc.execCommand('InsertHorizontalRule');
}
function doInsertInputCheckbox(){
Editor.focus();
doc.execCommand('InsertInputCheckbox');
}
function doInsertInputRadio(){
Editor.focus();
doc.execCommand('InsertInputRadio');
}
function doInsertInputText(){
Editor.focus();
doc.execCommand('InsertInputText');
}
function doInsertInputPassword(){
Editor.focus();
doc.execCommand('InsertInputPassword');
}
function doInsertInputSubmit(){
Editor.focus();
doc.execCommand('InsertInputSubmit');
ShowMessage();
}
function doInsertInputReset(){
Editor.focus();
doc.execCommand('InsertInputReset');
ShowMessage();
}
function doInsertMarquee(){
Editor.focus();
doc.execCommand('InsertMarquee');
ShowMessage();
}
function doInsertSelectDropdown(){
Editor.focus();
doc.execCommand('InsertSelectDropdown');
}
function doInsertTextArea(){
Editor.focus();
doc.execCommand('InsertTextArea');
}
function doPrint(){
doc.execCommand('Print');
Editor.focus();
}
function doSaveAs(){
doc.execCommand('SaveAs',0,"未命名");
Editor.focus();
}
function doOpen(){
doc.execCommand('Open');
Editor.focus();
}


function EditResource(){
Preview.value=doc.body.innerHTML;
return false;
}
function ClearAll(){
doc.body.innerHTML='';
Preview.value='';
return false;
}
function SeePreview(){
doc.body.innerHTML=Preview.value;
return false;
}
function AutoPreview(){
if(vx.checked){
SeePreview();
}
}
function EditMode(){
doc.designMode = "On";
window.setTimeout('SeePreview()',100);
Preview.focus();
}
function PreviewMode(){
doc.designMode = "Off";
window.setTimeout('SeePreview()',100);
Preview.focus();
}
function ShowMessage(){
alert("請按兩下物件編輯內容");
}
		</SCRIPT>
		<META content="MSHTML 6.00.3790.2491" name="GENERATOR">
		<link rel="stylesheet" href='<%=Global_asax.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<BODY onkeyup="AutoPreview();" bgColor="#e0e0e0">
		<CENTER>
			<TABLE cellSpacing="0" borderColorDark="#efece8" cellPadding="0" width="600" borderColorLight="#888070"
				border="1">
				<TBODY>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0" border="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="存檔" onclick="doSaveAs();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f01.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="列印" onclick="doPrint();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f02.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="剪下" onclick="doCut();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f03.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="複製" onclick="doCopy();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f04.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="貼上" onclick="doPaste();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f05.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="刪除" onclick="doDelete();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f06.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="復原" onclick="doUndo();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f07.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0" border="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD><SELECT onchange="doFontName(this[this.selectedIndex].value);this.selectedIndex=0;">
												<OPTION value="" selected>
												字型<OPTION value="細明體">
												細明體<OPTION value="新細明體">
												新細明體<OPTION value="標楷體">
												標楷體<OPTION value="arial">
												arial<OPTION value="wingdings">wingdings</OPTION>
											</SELECT></TD>
										<TD><SELECT onchange="doFontSize(this[this.selectedIndex].value);this.selectedIndex=0;">
												<OPTION value="" selected>
												大小<OPTION value="1">
												1<OPTION value="2">
												2<OPTION value="3">
												3(預設)<OPTION value="4">
												4<OPTION value="5">
												5<OPTION value="6">
												6<OPTION value="7">7</OPTION>
											</SELECT></TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="粗體字" onclick="doBold();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f08.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="斜體字" onclick="doItalic();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f09.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="劃底線" onclick="doUnderline();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f10.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="刪除線" onclick="doStrikeThrough();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f11.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="上標字" onclick="doSuperscript();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f12.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="下標字" onclick="doSubscript();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f13.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="文字顏色" onclick="doForeColor();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f14.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="背景顏色" onclick="doBackColor();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f15.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="靠左對齊" onclick="doJustifyLeft();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f16.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="靠中對齊" onclick="doJustifyCenter();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f17.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="靠右對齊" onclick="doJustifyRight();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f18.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="增加縮排" onclick="doIndent();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f19.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="減少縮排" onclick="doOutdent();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f20.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="數字標題" onclick="doInsertOrderedList();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f21.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="無數字標題" onclick="doInsertUnorderedList();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f22.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="插入分隔線" onclick="doInsertHorizontalRule();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f23.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="插入表格" onclick="doInsertTable();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f24.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="插入連結" onclick="doCreateLink();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f25.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="插入圖片" onclick="doInsertImage();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f26.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="跑馬燈" onclick="doInsertMarquee();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f27.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="核取方塊" onclick="doInsertInputCheckbox();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f28.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="點選圓" onclick="doInsertInputRadio();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f29.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="文字輸入" onclick="doInsertInputText();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f30.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="密碼輸入" onclick="doInsertInputPassword();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f31.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="選單方塊" onclick="doInsertSelectDropdown();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f32.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="文字方塊" onclick="doInsertTextArea();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f33.gif"></DIV>
										</TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="自訂按鈕" onclick="doInsertInputButton();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f34.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="送出按鈕" onclick="doInsertInputSubmit();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f35.gif"></DIV>
										</TD>
										<TD>
											<DIV onmouseup="BtnOver(this);" onmousedown="BtnClick(this);" onmouseover="BtnOver(this);"
												title="重設按鈕" onclick="doInsertInputReset();" onmouseout="BtnOut(this);"><IMG src="htmlimage/editor_f36.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD><INPUT title="編輯模式" onclick="EditMode();" type="radio" CHECKED name="vm"></TD>
										<TD>
											<DIV title="編輯模式"><IMG src="htmlimage/editor_e.gif"></DIV>
										</TD>
										<TD>&nbsp;</TD>
										<TD><INPUT title="預覽模式" onclick="PreviewMode();" type="radio" name="vm"></TD>
										<TD>
											<DIV title="預覽模式"><IMG src="htmlimage/editor_p.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD><IFRAME id="Editor" style="WIDTH: 100%; HEIGHT: 150px; BACKGROUND-COLOR: white" marginWidth="1"
								src="about:blank" runat="server" name="DesktopText"></IFRAME></TD>
					</TR>
					<TR>
						<TD bgColor="#d9cec4">
							<TABLE cellSpacing="1" cellPadding="0">
								<TBODY>
									<TR>
										<TD><IMG src="htmlimage/editor_h.gif"></TD>
										<TD><BUTTON class="function" onclick="EditResource();Preview.focus();" type="button">編輯原始碼</BUTTON></TD>
										<TD><BUTTON class="function" onclick="ClearAll();Preview.focus();" type="button">全部清除</BUTTON></TD>
										<TD><BUTTON class="function" onclick="SeePreview();Preview.focus();" type="button">結果預覽</BUTTON></TD>
										<TD><IMG src="htmlimage/editor_s.gif"></TD>
										<TD><INPUT title="自動預覽" onclick="AutoPreview();Preview.focus();" type="checkbox" CHECKED name="vx"></TD>
										<TD>
											<DIV title="自動預覽"><IMG src="htmlimage/editor_a.gif"></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD><TEXTAREA id="Preview" style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 150px; BACKGROUND-COLOR: #ffffff"></TEXTAREA></TD>
					</TR>
				</TBODY></TABLE>
		</CENTER>
		<SCRIPT>
var doc;
doc=document.frames.Editor.document;
doc.designMode = "On";
window.setTimeout('Editor.focus()',100);
		</SCRIPT>
	</BODY>
</HTML>
