<%Option Explicit%>
<!--#include file="treeview.asp"-->
<%

Sub GetItems(parentId)
	Dim strConn,strTable
	
	'strTable = "TreeViewMenu"
	'strConn = "Provider=MSDASQL;Driver={SQL Server};Server=(local);Database=test;User ID=sa;Password=sa;" 
	    
	strTable = "Menu"
	strConn = "DRIVER={Microsoft Access Driver (*.mdb)};DBQ=" & Server.MapPath("site.mdb")
    
	Dim tv
	Set tv = New TreeView
	tv.MenuTable = strTable
	tv.ConnectionString = strConn
	Response.Write tv.GetChildNodes(parentId)
	Set tv = Nothing
	
End Sub


Dim parentId:parentId = Request("p") 
If parentId="" Then parentId = 0
Response.ContentType = "text/xml"

%>
<%= "<?xml version='1.0' encoding='ISO-8859-1'  standalone='yes'?>" %>
<response>
  <method>getItems</method>
  <result><% Call GetItems(parentId) %></result>
</response>