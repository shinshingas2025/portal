Imports System.IO
Public Class AuthorityBO

    Dim gUserID As String
    Dim gWebPage As Web.UI.Page

    ' 1150206 加入這個靜態鎖定物件，去搭配267行的using
    Private Shared ReadOnly fileLock As New Object()

    Public Function checkAuthority(ByVal LoginID As String, ByVal node As Integer, ByVal WebPage As Web.UI.Page) As Boolean
        gUserID = LoginID
        If gUserID = "" Then
            gUserID = "Guest"
        End If
        gWebPage = WebPage
        Return searchNode(node)

    End Function

    Public Function checkAuthorityEdit(ByVal LoginID As String, ByVal node As Integer, ByVal authority As Integer, ByVal WebPage As Web.UI.Page) As Boolean
        gUserID = LoginID
        If gUserID = "" Then
            gUserID = "Guest"
        End If
        gWebPage = WebPage
        Return searchNodeAuthority(node, authority)
    End Function

    Private Function searchNodeAuthority(ByVal funNo As Integer, ByVal authority As Integer) As Boolean

        Dim doc As New System.Xml.XPath.XPathDocument(getCurrentXmlfile())

        Dim nav As System.Xml.XPath.XPathNavigator
        Dim nav2 As System.Xml.XPath.XPathNavigator
        Dim expr As System.Xml.XPath.XPathExpression
        Dim iterator As System.Xml.XPath.XPathNodeIterator
        Dim i As Integer
        Dim Searchstr As String
        Dim count As Integer


        nav = doc.CreateNavigator()
        Searchstr = "//treenode[@id='N_" & funNo & "' and @Ulevel='" & authority & "']"
        expr = nav.Compile(Searchstr)

        iterator = nav.Select(expr)
        count = iterator.Count

        doc = Nothing
        nav = Nothing
        nav2 = Nothing
        expr = Nothing
        iterator = Nothing

        If count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Function searchNode(ByVal funNo As Integer) As Boolean

        Dim doc As New System.Xml.XPath.XPathDocument(getCurrentXmlfile())

        Dim nav As System.Xml.XPath.XPathNavigator
        Dim nav2 As System.Xml.XPath.XPathNavigator
        Dim expr As System.Xml.XPath.XPathExpression
        Dim iterator As System.Xml.XPath.XPathNodeIterator
        Dim i As Integer
        Dim Searchstr As String

        nav = doc.CreateNavigator()
        Searchstr = "//treenode[@id='N_" & funNo & "']"
        expr = nav.Compile(Searchstr)

        iterator = nav.Select(expr)
        If iterator.Count > 0 Then
            Return True
        Else
            Return False

        End If

        'ListBox1.Items.Clear()
        'While iterator.MoveNext
        '    nav2 = iterator.Current.Clone
        '    nav2.
        '    i = iterator.CurrentPosition()
        '    ListBox1.Items.Add(nav2.Value)

        'End While

    End Function

    Private Function getObjIDbyLoginID(ByVal loginid As String) As Integer

        Dim strsQL As String
        Dim UID As Integer

        strsQL = "Select * from sysSecurity where loginID='" & loginid & "'"
        Dim conn As New DBConn
        Dim dt As DataTable
        dt = conn.ReadDataTable(strsQL)
        If dt.Rows.Count > 0 Then
            UID = CType(dt.Rows(0).Item("UID"), Integer)
        End If
        conn.close()
        Return UID

    End Function



    Private Sub mainProcess(ByVal loginid As String)

        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim PID As Integer
        Dim objID As Integer

        gUserID = loginid

        strSQL = "Select * from sysCommunity where ObjID= " & getObjIDbyLoginID(loginid)
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)

        PID = CType(dt.Rows(0).Item("PID"), Integer)

        Dim strObjID As String = ""
        strObjID = objID & "," & PID
        While PID <> 0

            strSQL = "Select * from sysCommunity where ObjID= " & PID
            dt = conn.ReadDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                PID = CType(dt.Rows(0).Item("PID"), Integer)
                strObjID &= "," & PID
            Else
                PID = 0
            End If

        End While
        Dim exeSP As String
        exeSP = "EIISgetAuthorityByLoginID_SP '" & gUserID & "','" & strObjID & "'"
        conn.ExecuteNonQuery(exeSP)
        conn.close()


        WriteXmlTree()
    End Sub

    Private Function GetTempTreeFile() As String
        Dim fn As String
        'fn = gUserID & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
        fn = gUserID & ".xml"
        Return fn
    End Function

    Private Function getCurrentXmlfile() As String
        Dim treeFile1 As String

        Dim fls() As String = Directory.GetFiles(gWebPage.Server.MapPath("/PortalFiles/xml/User"), gUserID & "*.xml")

        If UBound(fls) < 1 Then
            WriteXmlTree()
            fls = Directory.GetFiles(gWebPage.Server.MapPath("/PortalFiles/xml/User"), gUserID & "*.xml")
        End If

        treeFile1 = (fls(UBound(fls)))
        Return treeFile1
    End Function



    Private Sub WriteXmlTree()

        Dim strSQL As String = ""
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim levelNode As String = "0"
        Dim childNode As String = ""
        Dim levelNodes() As String

        'Dim doc As New System.Xml.XPath.XPathDocument(Server.MapPath("../xml/aspnetbooksTV.xml"))
        'Dim nav As System.Xml.XPath.XPathNavigator
        'Dim nav2 As System.Xml.XPath.XPathNavigator
        'Dim expr As System.Xml.XPath.XPathExpression
        'Dim iterator As System.Xml.XPath.XPathNodeIterator
        'nav = doc.CreateNavigator()
        'expr = nav.Compile("//treenode[@id='5']")
        'iterator = nav.Select(expr)
        'ListBox1.Items.Clear()
        'While iterator.MoveNext
        '    nav2 = iterator.Current.Clone
        '    i = iterator.CurrentPosition()
        '    ListBox1.Items.Add(nav2.Value)
        'End While
        'Exit Sub

        Dim xmlDoc As New System.Xml.XmlDocument
        Dim xmlchild As System.Xml.XmlElement
        Dim root As System.Xml.XmlNode
        Dim xe1 As System.Xml.XmlElement
        xmlDoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><TREENODES></TREENODES>")

        Do
            Dim conn As New DBConn
            strSQL = "Select distinct * from vAuthoryFun where  loginID='" & gUserID & "' and  PID in (" & levelNode & ")"
            dt = conn.ReadDataTable(strSQL)
            conn.close()
            childNode = ""
            For i = 0 To dt.Rows.Count - 1
                childNode &= "," & CType(dt.Rows(i).Item("objID"), System.String)
            Next i

            If childNode <> "" Then
                childNode = Mid(childNode, 2)
                levelNodes = childNode.Split(CType(",", Char))

                For j = 0 To UBound(levelNodes)
                    ' Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(levelNodes(j)) '查找<bookstore>  
                    If levelNode = "0" Then
                        root = xmlDoc.SelectSingleNode("TREENODES")

                    Else
                        root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                    End If

                    xe1 = xmlDoc.CreateElement("treenode")  '創建一個<treenode>節點 

                    xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  
                    If CType(dt.Rows(j).Item("srcName"), String).ToLower = "groups" Then
                        xe1.SetAttribute("IMAGEURL", "../images/folder.gif")

                    Else
                        xe1.SetAttribute("IMAGEURL", "../images/User.gif")
                    End If
                    xe1.SetAttribute("EXPANDEDIMAGEURL", "../images/folderopen.gif")
                    xe1.SetAttribute("id", "N_" & CType(dt.Rows(j).Item("objID"), String))

                    xe1.SetAttribute("Qlevel", CType(dt.Rows(j).Item("Qlevel"), String))
                    xe1.SetAttribute("Ilevel", CType(dt.Rows(j).Item("Ilevel"), String))
                    xe1.SetAttribute("Ulevel", CType(dt.Rows(j).Item("Ulevel"), String))
                    xe1.SetAttribute("Dlevel", CType(dt.Rows(j).Item("Dlevel"), String))
                    xe1.SetAttribute("Clevel", CType(dt.Rows(j).Item("Clevel"), String))

                    'xe1.InnerText = "設置文本節點 "
                    root.AppendChild(xe1)

                Next j
            End If
            levelNode = childNode

        Loop Until levelNode = ""

        Dim TreefileTemp As String
        TreefileTemp = GetTempTreeFile()


        '1150206移除，因檔案沒有正確釋放
        'xmlDoc.Save(gWebPage.Server.MapPath("/PortalFiles/xml/User/" & TreefileTemp))

        '1150206 add' 使用 Using 確保檔案正確關閉
        Dim filePath As String = gWebPage.Server.MapPath("/PortalFiles/xml/User/" & TreefileTemp)

        SyncLock fileLock
            Try
                Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
                    xmlDoc.Save(fs)
                End Using
            Catch ex As Exception
                Throw
            End Try
        End SyncLock
        '1150206 add結束->AuthorityBO  類別最上方加上靜態鎖定物件

        root = Nothing
        xe1 = Nothing
        xmlDoc = Nothing


    End Sub
End Class
