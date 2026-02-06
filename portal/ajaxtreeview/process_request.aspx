<%@ Page Language="vb" AutoEventWireup="false" Codebehind="process_request.aspx.vb" Inherits="process_request"%>
<%
Response.ContentType = "text/xml"

%>
<%= "<?xml version='1.0' encoding='ISO-8859-1'  standalone='yes'?>" %>
<response>
	<method>
getItems</method>
	<result>
	<asp:Literal id="Literal1" runat="server"></asp:Literal>
		
	</result>
</response>
