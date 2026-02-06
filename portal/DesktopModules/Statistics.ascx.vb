Namespace ASPNET.StarterKit.Portal
    Public Class Statistics
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
        Protected WithEvents dlSite As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

        '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
        '請勿刪除或移動它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
            '請勿使用程式碼編輯器進行修改。
            InitializeComponent()
        End Sub

#End Region
        Private tabIndex As Integer = 0
        Private tabId As Integer = 1
        Private sid As String = ""
        Private voteid As Integer = 0

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁
            ' Verify that the current user has access to access this page
            'If PortalSecurity.IsInRoles("Admins") = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If

            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If
            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If
            If Not (Request.Params("sid") Is Nothing) Then
                sid = CType(Request.Params("sid"), String)
            End If

            If Not IsPostBack Then

                filldlsite()

                Dim st As New StatisticsDB
                If dlSite.SelectedValue = "全部" Then
                    fillStatistics(st.GetAllStatisticsSite(), st.GetStatisticsTotal())
                Else


                    fillStatistics(st.GetStatisticsBySite(dlSite.SelectedValue), st.GetStatisticsTotal(dlSite.SelectedValue))
                End If
            End If





        End Sub
        Private Sub filldlsite()
            Dim st As New SiteDB
            Dim dt As DataTable
            Dim i As Integer
            dt = st.GetAllSite.Tables(0)
            dlSite.Items.Add("全部")

            For i = 0 To dt.Rows.Count - 1
                Dim listitem As New listitem
                listitem.Text = CType(dt.Rows(i).Item("PortalName"), String)
                listitem.Value = CType(dt.Rows(i).Item("PortalID"), String)
                dlSite.Items.Add(listitem)
            Next
        End Sub


        Private Sub fillStatistics(ByVal dr As SqlDataReader, ByVal total As Integer)


            Dim txtBody As New Literal
            'Dim total As Integer
            'Dim dr1 As SqlDataReader

            'dr1 = dr

            'While dr1.Read

            '    total += CType(dr.Item("Counter"), Integer)
            'End While
            'If total = 0 Then
            '    total = 1
            'End If
            Dim HtmlBody As String = ""
            'dr = st.GetStatisticsBySite()
            HtmlBody = "<table><TR><TD width='30%' class=head>站名\項目</TD><TD class=head>計數</TD><TD width='5%' class=head>百分比</TD</TR>"
            While dr.Read



                HtmlBody &= "<TR><TD  class=""subhead"">"
                HtmlBody &= CType(dr.Item("PortalName"), String) & "\" & CType(dr.Item("tabName"), String)
                HtmlBody &= "</TD><TD class=subsubhead>"
                HtmlBody &= "<IMG SRC=""images/bar.jpg"" height=""16"" width=" & CType(CType(dr.Item("Counter"), Integer) / total * 400, String) & " Align=TextTop>" & CType(dr.Item("Counter"), Integer)
                HtmlBody &= "</TD><TD  class=""SubSubHead"">"
                HtmlBody &= CType(CType(dr.Item("Counter"), Integer) / total * 100, Integer) & "%"
                HtmlBody &= "</TD</TR>"


            End While


            HtmlBody &= "</TABLE>"

            txtBody.Text = HtmlBody
            Panel1.Controls.Add(txtBody)

        End Sub


        Private Sub dlSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlSite.SelectedIndexChanged
            Dim st As New StatisticsDB
            If dlSite.SelectedValue = "全部" Then
                fillStatistics(st.GetAllStatisticsSite(), st.GetStatisticsTotal())
            Else


                fillStatistics(st.GetStatisticsBySite(dlSite.SelectedValue), st.GetStatisticsTotal(dlSite.SelectedValue))
            End If
        End Sub
    End Class
End Namespace
