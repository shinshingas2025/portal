Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class DesktopPortalBanner
        Inherits System.Web.UI.UserControl

        Protected WelcomeMessage As System.Web.UI.WebControls.Label
        Protected siteName As System.Web.UI.WebControls.Label
        Protected tabs As System.Web.UI.WebControls.DataList
        Protected lblLogout As System.Web.UI.WebControls.Label
        Public tabIndex As Integer
        Public tabId As Integer
        Public ShowTabs As Boolean = True

        Protected LogoffLink As String = ""
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            If CType(Session("sid"), String) = "" Or Session("sid") Is Nothing Then
                Response.Redirect("~/Default.aspx")
            End If
            ' Dynamically Populate the Portal Site Name
			'siteName.Text = _portalSettings.PortalName
            siteName.Text = "欣欣天然氣股份有限公司"
            siteName.Visible = True
            tabIndex = CType(Request.Params("tabindex"), Integer)
            tabId = CType(Request.Params("tabid"), Integer)

            ' Call getSiteLogo()
            ' If user logged in, customize welcome message
            If Request.IsAuthenticated = True Then
                Dim mybo As New User
                Dim strname As String
                Dim tmpdt As System.Data.DataTable
                Dim myUser01BO As New User01BO
                Dim myEmployeeID As String

                strname = context.User.Identity.Name
                tmpdt = mybo.QueryUserInfo(strname)
                strname = CType(tmpdt.Rows(0).Item("cname"), String)
                Session("UserName") = strname.Trim       '2010/11/19 Camille Add 將員工姓名加入Session中
                '取得員工編號
                myEmployeeID = myUser01BO.getEmployeeID(context.User.Identity.Name.Trim)
                '顯示員工編號
                If myEmployeeID <> "" Then
                    WelcomeMessage.Text = "歡迎 " & strname & "(員工編號：" & myEmployeeID & ")<" & "span class=Accent" & ">|<" & "/span" & ">"
                Else
                    WelcomeMessage.Text = "歡迎 " & strname & " <" & "span class=Accent" & ">|<" & "/span" & ">"
                End If


                ' if authentication mode is Cookie, provide a logoff link
                If Context.User.Identity.AuthenticationType = "Forms" Then
                    lblLogout.Text = "<" & "span class=""Accent"">|</span>" & ControlChars.Cr & "<" & "a href=" & Global_asax.GetApplicationPath(Request) & "/Admin/Logoff.aspx?sid=" & CType(Session("sid"), String) & " class=SiteLink> 登出" & "<" & "/a>"
                End If

            End If

            ' Dynamically render portal tab strip
            Dim tabName As String = ""

            If ShowTabs = True Then

                tabIndex = _portalSettings.ActiveTab.TabIndex
                tabName = _portalSettings.ActiveTab.TabName

                Call AddStatistic(tabIndex, tabName, Request.Params("sid"))


                ' Build list of tabs to be shown to user
                Dim authorizedTabs As New ArrayList
                Dim addedTabs As Integer = 0

                Dim i As Integer


                Dim au As New AuthorityBO
                Dim bb As Boolean
                Dim LoginID As String
                If Context.User.Identity.Name = "" Or Context.User.Identity.Name Is Nothing Then
                    LoginID = "Guest"
                Else
                    LoginID = Context.User.Identity.Name()
                    UserID = LoginID
                End If

                For i = 0 To _portalSettings.DesktopTabs.Count - 1

                    Dim tab As TabStripDetails = CType(_portalSettings.DesktopTabs(i), TabStripDetails)

                    'If PortalSecurity.IsInRoles(tab.AuthorizedRoles) Then
                    '    authorizedTabs.Add(tab)
                    'End If

                    If au.checkAuthority(LoginID, CType(tab.AuthorizedRoles, Integer), Me.Page) Then
                        authorizedTabs.Add(tab)
                    End If

                    If addedTabs = tabIndex Then
                        tabs.SelectedIndex = addedTabs
                    End If

                    addedTabs += 1

                Next i




                ' Populate Tab List at Top of the Page with authorized tabs
                tabs.DataSource = authorizedTabs
                tabs.DataBind()

            End If


            If CType(Session("Authed"), Boolean) = True Then
                If Context.User.Identity.Name = "" Or Context.User.Identity.Name Is Nothing Then

                    mainProcess("Guest")

                Else

                    mainProcess(Context.User.Identity.Name)
                End If
                Session("Authed") = False

            End If


        End Sub

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
                        ' Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(levelNodes(j)) '?交<bookstore>  
                        If levelNode = "0" Then
                            root = xmlDoc.SelectSingleNode("TREENODES")

                        Else
                            root = xmlDoc.SelectSingleNode("//treenode[@id='N_" & CType(dt.Rows(j).Item("PID"), String) & "']")
                        End If

                        xe1 = xmlDoc.CreateElement("treenode")  '?萄遣銝??treenode>蝭暺?

                        xe1.SetAttribute("text", CType(dt.Rows(j).Item("objID"), String) & " " & CType(dt.Rows(j).Item("objName"), String)) '閮剔蔭閰脩?暺惇?? 
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



                        'xe1.InnerText = "閮剔蔭?蝭暺?"
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

        Private Function GetTempTreeFile() As String
            Dim fn As String
            '  fn = UserID & Year(Now()) & Right("0" & Month(Now()), 2) & Right("0" & Day(Now()), 2) & Right("0" & Hour(Now()), 2) & Right("0" & Minute(Now()), 2) & Right("0" & Second(Now()), 2) & ".xml"
            fn = UserID & ".xml"
            Return fn
        End Function


        'Private Sub getSiteLogo()
        '    Dim objSiteDB As New ASPNET.StarterKit.Portal.SiteDB
        '    Dim dt As DataTable = objSiteDB.GetSiteBySid(CType(Session("sid"), Integer)).Tables(0)

        '    If dt.Rows.Count > 0 Then
        '        If CType(dt.Rows(0).Item("imagelogo"), String).Trim <> "" Then
        '            imglogo.ImageUrl = "/PortalFiles/UpLoadFiles/schoollogo/" & CType(dt.Rows(0).Item("imagelogo"), String)
        '        Else
        '            imglogo.Visible = False
        '        End If
        '    Else


        '    End If

        '    ' Close the datareader
        '    dt = Nothing
        'End Sub

        '-------------------------------

        '-------------------------------


        Private Sub AddStatistic(ByVal tabIndex As Integer, ByVal tabName As String, ByVal sid As String)
            Dim Statistics As New StatisticsDB
            If sid Is Nothing Then sid = "2"
            Statistics.AddStatistics(tabIndex, tabName, sid, Request.UserHostAddress)
            Statistics = Nothing

        End Sub

    End Class

End Namespace