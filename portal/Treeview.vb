
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class Treeview
    Inherits System.Web.UI.Page

    Private m_strMenuTable
    Private m_strIdField
    Private m_strParentIDField
    Private m_strTextField
    Private m_strConn



    Public Property MenuTable() As String
        Get
            Return m_strMenuTable
        End Get
        Set(ByVal Value As String)
            m_strMenuTable = Value
        End Set
    End Property

    Public Property IdField() As String
        Get
            Return m_strIdField
        End Get
        Set(ByVal Value As String)
            m_strIdField = Value
        End Set
    End Property

    Public Property ParentIDField() As String
        Get
            Return m_strParentIDField
        End Get
        Set(ByVal Value As String)
            m_strParentIDField = Value
        End Set
    End Property

    Public Property TextField() As String
        Get
            Return m_strTextField
        End Get
        Set(ByVal Value As String)
            m_strTextField = Value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return m_strConn
        End Get
        Set(ByVal Value As String)
            m_strConn = Value
        End Set
    End Property


    Public Sub New()
        m_strMenuTable = "Menu"
        m_strIdField = "MenuID"
        m_strParentIDField = "ParentID"
        m_strTextField = "[Text]"
    End Sub



    Public Function GetChildNodes(ByVal intParentId)
        Dim strSQL
        strSQL = "SELECT " & _
        m_strIdField & "," & _
        m_strTextField & "," & _
        "(SELECT COUNT(*) FROM " & m_strMenuTable & " B WHERE A." & m_strIdField & "=B." & m_strParentIDField & ") AS [HasChild]" & _
        " FROM " & m_strMenuTable & " A " & _
        " WHERE " & m_strParentIDField & " = " & intParentId

        Const strXsl = "treeview.xsl"
        GetChildNodes = GetDbXml(m_strConn, strSQL, strXsl)
    End Function

    Private Function GetDbXml(ByVal strConn, ByVal strSQL, ByVal strXsl)
        Dim strXml
        'test strsql
        strXml = GetDbString(strConn, strSQL, "__COL", "__ROW", "__NULL")
        strXml = Replace(strXml, "&", "&amp;")
        strXml = Replace(strXml, "<", "&lt;")
        strXml = Replace(strXml, "__COL", "</col><col>")
        strXml = Replace(strXml, "__ROW", "</col></row><row><col>")
        strXml = Replace(strXml, "__NULL", "")

        strXml = "<rows><row><col>" & strXml & "</col></row></rows>"

        strXml = Replace(strXml, "<row><col></col></row>", "")
        If strXsl <> "" Then
            Dim xml, xsl
            'Load XML
            If Not LoadXmlDoc(xml, strXml, "GetDb XML Source") Then Exit Function
            If Not LoadXmlDoc(xsl, strXsl, "GetDb XSL Stylesheet") Then Exit Function

            'Transform file
            strXml = xml.transformNode(xsl)
            xml = Nothing
            xsl = Nothing
        End If

        GetDbXml = strXml
    End Function

    Private Function GetDbString(ByVal strConn, ByVal strSQL, ByVal ColumnDelimiter, ByVal RowDelimiter, ByVal NullExpr)

        Dim myConnection As New SqlConnection(strConn)

        Dim myCommand As New SqlCommand(strSQL, myConnection)
        'myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 24).Value = groupID
        'myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)

        Dim dt As DataTable

        dt = myDataSet.Tables(0)

        If dt.Rows.Count > 0 Then

            GetDbString = dt.Rows(0).Item(0).GetString(, , ColumnDelimiter, RowDelimiter, NullExpr)

            'Cleanup!

        End If

        'Cleanup!		
        dt = Nothing
        myConnection.Close()
        myConnection = Nothing
    End Function

    Private Function LoadXmlDoc(ByRef xmldoc, ByVal source, ByVal title)
        If Trim(source) = "" Then
            Exit Function
        End If

        xmldoc = CreateObject("Microsoft.XMLDOM")
        If Left(source, 7) = "http://" Then
            xmldoc.setProperty("ServerHTTPRequest", True)
            xmldoc.async = False
            xmldoc.Load(source)
        Else
            'set xmldoc = Server.CreateObject("Microsoft.XMLDOM")
            xmldoc.async = False
            If InStr(source, "<") Then
                xmldoc.loadXml(source)
            Else
                If InStr(source, ":\") = 0 Then source = Server.MapPath(source)
                'test source
                xmldoc.load(source)
            End If
        End If

        If xmldoc.parseError.errorcode <> 0 Then
            '"<error code='" & xmldoc.parseError.errorcode & "'><![CDATA[" & xmldoc.parseError.reason & "]]></error>"
        Else
            LoadXmlDoc = True
        End If
    End Function


End Class
