<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserInfoView.aspx.vb" Inherits="UserInfoView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserInfoView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="TTable" id="Table1" cellSpacing="1" cellPadding="1" width="504" align="center"
				border="0" style="WIDTH: 504px; HEIGHT: 572px">
				<TR>
					<TD style="WIDTH: 75px; HEIGHT: 39px"><FONT face="新細明體" size="2" color="#ff0000">使用者ID</FONT></TD>
					<TD style="HEIGHT: 39px"><asp:textbox id="txtUID" runat="server" Width="150px"></asp:textbox><asp:label id="lblUID" runat="server"></asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtUID" ErrorMessage="*"></asp:requiredfieldvalidator>
						<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="不可使用中文ID" ControlToValidate="txtIDNum"
							CssClass="normalred" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px; HEIGHT: 39px"><FONT face="新細明體" size="2">
							<asp:Label id="lblSeqno" runat="server">次序</asp:Label></FONT></TD>
					<TD style="HEIGHT: 39px" colSpan="3"><FONT face="新細明體"><FONT size="2"><asp:textbox id="txtSeqno" runat="server" Width="50px">1</asp:textbox>
								<asp:Label id="errmsg" runat="server" CssClass="normalred"></asp:Label>
								<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtSeqno"
									MaximumValue="100" MinimumValue="1"></asp:RangeValidator></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2" color="#ff0000">中文姓名</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtCname" runat="server" Width="296px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtCname" ErrorMessage="*"></asp:requiredfieldvalidator><FONT size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">類別</FONT></TD>
					<TD><asp:dropdownlist id="selU_Class" runat="server">
							<asp:ListItem Value="0">類別</asp:ListItem>
							<asp:ListItem Value="1">類別一</asp:ListItem>
							<asp:ListItem Value="2">類別二</asp:ListItem>
							<asp:ListItem Value="3">類別三</asp:ListItem>
							<asp:ListItem Value="4">類別四</asp:ListItem>
							<asp:ListItem Value="5">類別五</asp:ListItem>
							<asp:ListItem Value="6">類別六</asp:ListItem>
							<asp:ListItem Value="7">類別七</asp:ListItem>
							<asp:ListItem Value="8">類別八</asp:ListItem>
							<asp:ListItem Value="9">類別九</asp:ListItem>
						</asp:dropdownlist><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">員工編號</FONT></TD>
					<TD><asp:textbox id="txtAlias" runat="server" Width="150px" MaxLength="4"></asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">英文姓名</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtEname" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">身份證號 </FONT>
					</TD>
					<TD><asp:textbox id="txtIDNum" runat="server" Width="150px"></asp:textbox></TD>
					<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">姓別</FONT></TD>
					<TD><asp:dropdownlist id="selSex" runat="server">
							<asp:ListItem Value="1" Selected="True">男</asp:ListItem>
							<asp:ListItem Value="0">女</asp:ListItem>
						</asp:dropdownlist><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT size="2">郵遞區號</FONT></TD>
					<TD><asp:textbox id="txtAddr_zip" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px"><FONT size="2">縣市</FONT></TD>
					<TD><asp:textbox id="txtAddr_div" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px; HEIGHT: 18px"><FONT size="2">鄉鎮市區</FONT></TD>
					<TD style="HEIGHT: 18px"><asp:textbox id="txtAddr_vil" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px; HEIGHT: 18px"><FONT size="2">國家</FONT></TD>
					<TD style="HEIGHT: 18px"><asp:textbox id="txtnation" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT size="2">街路號</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtAddr_door" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD colSpan="4"><FONT face="新細明體" size="2">
							<HR width="100%" color="#000000" SIZE="1">
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px; HEIGHT: 28px"><FONT size="2">公司</FONT></TD>
					<TD style="HEIGHT: 28px" colSpan="3"><FONT face="新細明體"><asp:textbox id="txtCompany" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT size="2">行動電話</FONT></TD>
					<TD><asp:textbox id="txtTelmobile" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px"><FONT size="2">電話(公)</FONT></TD>
					<TD><asp:textbox id="txtTelcompany" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT size="2">電話(家)</FONT></TD>
					<TD><FONT face="新細明體"><asp:textbox id="txtTelhome" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
					<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">部門</FONT></TD>
					<TD><asp:textbox id="txtDept" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">職稱</FONT></TD>
					<TD><asp:textbox id="txttitle" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 60px"><FONT size="2">mask</FONT></TD>
					<TD><asp:textbox id="txtmask" runat="server" Width="50px">0</asp:textbox><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">網站</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtHomepage" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 75px"><FONT face="新細明體" size="2">電子郵件</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtEmail" runat="server" Width="304px"></asp:textbox>
							<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
								ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></FONT></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="4"><FONT face="新細明體"><asp:button id="btnAdd" runat="server" Text="確定"></asp:button></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
