<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Batch_job_inquiries.aspx.vb" Inherits="Batch_job_inquiries" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<asp:datagrid id="dgBJ" runat="server" AllowSorting="True" Width="700px" AutoGenerateColumns="False"
					AllowPaging="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White"
					BackColor="White" GridLines="None" CellSpacing="1" Font-Size="Larger" Font-Names="細明體">
					<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
					<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
					<EditItemStyle  Width="600px"></EditItemStyle>
					<AlternatingItemStyle ></AlternatingItemStyle>
					<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
					<HeaderStyle Font-Size="10pt" Font-Names="細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="rb_no" HeaderText="批次號碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="StartDate" HeaderText="執行開始時間"></asp:BoundColumn>
						<asp:BoundColumn DataField="EndDate" HeaderText="執行結束時間"></asp:BoundColumn>
						<asp:BoundColumn DataField="rb_run_user" HeaderText="執行者帳號"></asp:BoundColumn>
						<asp:BoundColumn DataField="rbstatus" HeaderText="執行結果"></asp:BoundColumn>
						<asp:BoundColumn DataField="rb_success" HeaderText="成功筆數"></asp:BoundColumn>
						<asp:BoundColumn DataField="rb_failure" HeaderText="失敗筆數"></asp:BoundColumn>
					</Columns>
					<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
						Mode="NumericPages"></PagerStyle>
				</asp:datagrid></FONT>
		</form>
	</body>
</HTML>
