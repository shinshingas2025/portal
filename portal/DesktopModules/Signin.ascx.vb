Imports System.Web.Security
Imports System.IO

Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class Signin
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents email As System.Web.UI.WebControls.TextBox
        Protected WithEvents password As System.Web.UI.WebControls.TextBox
        Protected WithEvents RememberCheckbox As System.Web.UI.WebControls.CheckBox
        Protected WithEvents LoginBtn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Message As System.Web.UI.WebControls.Label
        Dim UserID As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub LoginBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginBtn.Click

            ' Attempt to Validate User Credentials using UsersDB
            Dim accountSystem As New UsersDB
            UserID = accountSystem.Login(email.Text, PortalSecurity.Encrypt(password.Text))

            If Not (UserID Is Nothing) And UserID <> "" Then


                If accountSystem.checkISExpired(UserID) = False Then
                    Message.Text = "<" & "br" & ">帳號過期!" & "<" & "br" & ">"
                    Exit Sub
                End If

                If accountSystem.checkISOutService(UserID) = False Then
                    Message.Text = "<" & "br" & ">帳號已停用!" & "<" & "br" & ">"
                    Exit Sub
                End If

                ' Use security system to set the UserID within a client-side Cookie
                FormsAuthentication.SetAuthCookie(email.Text, RememberCheckbox.Checked)
                If Session("sid") Is Nothing Then
                    Session("sid") = "2"
                End If

                ' Redirect browser back to originating page
                'Response.Redirect(Global.GetApplicationPath(Request) & "?sid=" & CType(Session("sid"), String))
				mainProcess(UserID)

				Session("Notify") = False

                Response.Redirect("DesktopDefault.aspx" & "?sid=" & CType(Session("sid"), String))

            Else

                Message.Text = "<" & "br" & ">登入失敗!" & "<" & "br" & ">"

            End If

        End Sub

        Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("Admin/Register.aspx?sid=" & Request.Params("sid"))

        End Sub


        Private Function searchnode(ByVal funNo As Integer) As Boolean

            Dim doc As New System.Xml.XPath.XPathDocument(getCurrentXmlfile)

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
            objID = getObjIDbyLoginID(loginid)

            UserID = loginid

            strSQL = "Select * from sysCommunity where ObjID= " & objID
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
            strObjID = strObjID & "," & CType(objID, String)
            exeSP = "EIISgetAuthorityByLoginID_SP '" & UserID & "','" & strObjID & "'"
            conn.ExecuteNonQuery(exeSP)
            conn.close()


            WriteXmlTree()
        End Sub

        Private Function GetTempTreeFile() As String
            Dim fn As String
			'fn = UserID & "_" & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"

			fn = UserID & ".xml"
            Return fn
        End Function

        Private Function getCurrentXmlfile() As String
            Dim treeFile1 As String

			Dim fls() As String = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/User"), UserID & "*.xml")

            If UBound(fls) < 1 Then
                WriteXmlTree()
				fls = Directory.GetFiles(Server.MapPath("/PortalFiles/xml/User"), UserID & "*.xml")
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
                strSQL = "Select distinct * from vAuthoryFun where  loginID='" & UserID & "' and  PID in (" & levelNode & ")"
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

                        xe1.SetAttribute("Text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '設置該節點屬性  
						If CType(dt.Rows(j).Item("srcName"), String).ToLower = "groups" Then

							xe1.SetAttribute("IMAGEURL", "images/folder.gif")


						Else
							xe1.SetAttribute("IMAGEURL", "images/User.gif")

						End If
						xe1.SetAttribute("EXPANDEDIMAGEURL", "images/folderopen.gif")

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

            viewstate("tree") = TreefileTemp

            xmlDoc.Save(Server.MapPath("/PortalFiles/xml/User/" & TreefileTemp))

            root = Nothing
            xe1 = Nothing

            xmlDoc = Nothing


            'Call CopyFile("../View/TreeTemp.xml", "../View/Tree.xml")




        End Sub


        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Context.User.Identity.Name = "" Or Context.User.Identity.Name Is Nothing Then


				mainProcess("Guest")

			End If



		End Sub


	End Class

End Namespace
