Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal

    Public Class ContactList
        Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Iframe1 As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents TextBoxStartDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents TextBoxEndDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents ButtonOK As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label

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
        Private sid As String = ""
        Private moduleId As Integer = 0
        Private tabId As Integer = 0
        'Private ProcedureName As String = ""
        Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e7%b6%b2%e7%ab%99%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%98%a0%e8%a1%a8&rc:Parameters=false"
        Private IFrameHeight As Integer = 0
        Private IFrameWeight As Integer = 0

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁()
            'Session("sid") = "9999"
            'If PortalSecurity.IsInRoles("Admins") = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If
            ' Calculate userid
            If Not (Request.Params("sid") Is Nothing) Then
                sid = Request.Params("sid")
            End If

            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If

            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If

            If Not (Request.Params("mid") Is Nothing) Then
                moduleId = Int32.Parse(Request.Params("mid"))
            End If

            If Not IsPostBack Then
                If Not (Request.UrlReferrer Is Nothing) Then
                    ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
                End If
                PageLoad()
            End If
        End Sub
        Private Sub PageLoad()
            TextBoxStartDate.Text = ""
            TextBoxEndDate.Text = ""
            Me.Iframe1.Attributes("src") = ""
        End Sub

        Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
            Dim delimStr As String = "/-:. "
            Dim delimiter As Char() = delimStr.ToCharArray()
            Dim tempString As String = ""
            Dim tempArray As String() = Nothing
            Dim mySiteDAO As New Share_TRGSTNDAO
            Dim mySiteDataSet As DataSet
            Dim myStartDate As Date = Now.AddMonths(-1)
            Dim myEndDate As Date = Now
            Dim myUserFlag As String = "0"
            Dim myUserID As String = context.User.Identity.Name.Trim
            Dim myDeptFlag As String = "1"
            Dim myDeptID As String = "0"
            Dim myRandom As Integer = New Random(Now.Second).Next
            If TextBoxStartDate.Text.Trim <> "" Then
                tempString = TextBoxStartDate.Text.Trim
                tempArray = tempString.Split(delimiter)
                If tempArray.Length = 3 Then
                    myStartDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
                End If
            End If
            If TextBoxEndDate.Text.Trim <> "" Then
                tempString = TextBoxEndDate.Text.Trim
                tempArray = tempString.Split(delimiter)
                If tempArray.Length = 3 Then
                    myEndDate = New Date(CType(tempArray(0), Integer), CType(tempArray(1), Integer), CType(tempArray(2), Integer))
                End If
            End If
            If sid.Trim.Length > 0 Then
                Me.Iframe1.Attributes("src") = IFrameSrc & "&myStartDate=" & myStartDate.Year & "/" & myStartDate.Month & "/" & myStartDate.Day & "&myEndDate=" & myEndDate.Year & "/" & myEndDate.Month & "/" & myEndDate.Day & "&myUserFlag=" & myUserFlag & "&myUserID=" & myUserID & "&myDeptFlag=" & myDeptFlag & "&myDeptID=" & myDeptID
            Else
                'exception:school id is empty
            End If
        End Sub
    End Class
End Namespace