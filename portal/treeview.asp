<%

Class TreeView

Private m_strMenuTable
Private m_strIdField
Private m_strParentIDField
Private m_strTextField
Private m_strConn

Public Property Let MenuTable(vNewValue): m_strMenuTable = vNewValue: End Property
Public Property Let IdField(vNewValue): m_strIdField = vNewValue: End Property
Public Property Let ParentIDField(vNewValue): m_strParentIdField = vNewValue: End Property
Public Property Let TextField(vNewValue): m_strTextField = vNewValue: End Property

Public Property Let ConnectionString(vNewValue): m_strConn = vNewValue: End Property

Private Sub Class_Initialize
	m_strMenuTable = "Menu"
	m_strIdField = "MenuID"
	m_strParentIDField = "ParentID"
	m_strTextField = "[Text]"
End Sub
	
Private Sub Class_Terminate
	'Clear Objects			
End Sub

Public Function GetChildNodes(intParentId)
	Dim strSQL
	strSQL = "SELECT " & _
	m_strIdField & "," & _
	m_strTextField & "," & _
	"(SELECT COUNT(*) FROM " & m_strMenuTable & " B WHERE A."& m_strIdField &"=B." & m_strParentIDField & ") AS [HasChild]" & _
	" FROM " & m_strMenuTable &" A "& _
	" WHERE " & m_strParentIDField & " = " & intParentId
	
	Const strXsl = "treeview.xsl"
	GetChildNodes = GetDbXml(m_strConn,strSQL, strXsl)
End Function

Private Function GetDbXml(strConn,strSQL,strXsl)
	Dim strXml
	'test strsql
	strXml = GetDbString(strConn,strSql,"__COL","__ROW","__NULL")
	strXml = Replace(strXml,"&","&amp;")
	strXml = Replace(strXml,"<","&lt;")
	strXml = Replace(strXml,"__COL","</col><col>")
	strXml = Replace(strXml,"__ROW","</col></row><row><col>")
	strXml = Replace(strXml,"__NULL","")	
		
	strXml = "<rows><row><col>" & strXml & "</col></row></rows>"			
		
	strXml = Replace(strXml,"<row><col></col></row>","")
	If strXsl <> "" Then		
		Dim xml,xsl
		'Load XML
		if not loadXmlDoc(xml,strXml,"GetDb XML Source") then exit Function
		if not loadXmlDoc(xsl,strXsl,"GetDb XSL Stylesheet") then exit Function
		
		'Transform file
		strXml = xml.transformNode(xsl)
		Set xml = Nothing
		Set xsl = Nothing
	End If
				
	GetDbXml = strXml        	
End Function 

Private Function GetDbString(strConn,strSQL, ColumnDelimiter, RowDelimiter, NullExpr)
	Dim Conn 
	Set Conn = Server.CreateObject("ADODB.Connection")
	Conn.Open strConn
			
	Dim RS
	Set RS = Conn.Execute(strSql)		
	If Not RS.EOF Then		
		
		GetDbString = RS.GetString(,, ColumnDelimiter, RowDelimiter, NullExpr) 

		'Cleanup!
		RS.Close
	End If	
		
	'Cleanup!		
	Set RS = Nothing
	Conn.Close 
	Set Conn = Nothing					
End function

Private Function LoadXmlDoc(ByRef xmldoc, ByVal source, ByVal title)
	If Trim(source) = "" Then
		Exit Function
	End If
	
	Set xmldoc = Server.CreateObject("Microsoft.XMLDOM")
	If Left(source,7) = "http://" Then
		xmldoc.setProperty "ServerHTTPRequest", True
		xmldoc.async =  False
		xmldoc.Load(source)
	Else
		'set xmldoc = Server.CreateObject("Microsoft.XMLDOM")
		xmldoc.async = false
		If InStr(source,"<") Then 
			xmldoc.loadXml(source)
		else
			if InStr(source,":\") = 0 then source = Server.MapPath(source)
			'test source
			xmldoc.load(source)
		end if
	End If
	
	if xmldoc.parseError.errorcode<>0 then
		'"<error code='" & xmldoc.parseError.errorcode & "'><![CDATA[" & xmldoc.parseError.reason & "]]></error>"
	else
		LoadXmlDoc = True
	end if		
End Function
		
End Class

%>