Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls



Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then

            SetBind()
            SetBind2()
        End If

    End Sub
    Protected Sub SetBind()


        Dim conn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("connectionString"))
        Dim da As New SqlDataAdapter("select * from stu,dep where stu.studepid=dep.depid", conn)
        Dim ds As New DataSet
        da.Fill(ds, "table1")
        DataGrid1.DataSource = ds.Tables("table1")
        DataGrid1.DataBind()

    End Sub

    Protected Sub SetBind2()


        Dim conn2 As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("connectionString"))
        Dim da2 As New SqlDataAdapter("select * from dep", conn2)

        Dim ds2 As New DataSet

        'da2.Fill(ds2, "table1")
        'DropDownList1.DataSource = ds2.Tables.Item(0)
        'DropDownList1.DataTextField = "depname"
        'DropDownList1.DataValueField = "depid"
        'DropDownList1.DataBind()
        'DropDownList1.Items.Insert(0, New ListItem("Select", ""))

    End Sub

    Protected Sub SetBind3()

        Dim s As String = DropDownList1.SelectedValue
        Dim conn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("connectionString"))
        Dim comm As New SqlCommand
        comm.Connection = conn

        If s <> "" Then

            comm.CommandText = "select * from stu,dep where stu.studepid=dep.depid and depid=@depid"
            Dim parm1 As New SqlParameter("@depid", SqlDbType.Int)
            parm1.Value = s
            comm.Parameters.Add(parm1)

        Else
            comm.CommandText = "select * from stu,dep where stu.studepid=dep.depid"
            Dim da As New SqlDataAdapter
            da.SelectCommand = comm
            Dim ds As New DataSet
            da.Fill(ds, "table1")
            DataGrid1.DataSource = ds.Tables("table1")
            DataGrid1.DataBind()
        End If

    End Sub


    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        Dim conn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("connectionString"))
        Dim da As New SqlDataAdapter("select * from dep", conn)
        Dim ds As New DataSet
        da.Fill(ds, "table1")
        If e.Item.ItemType = ListItemType.EditItem Then
            
            Dim ddl As DropDownList

            ddl = CType(e.Item.FindControl("dep"), DropDownList)

            ddl.DataSource = ds.Tables("table1")
            ddl.DataTextField = "depname"
            ddl.DataValueField = "depid"
            ddl.DataBind()
            ddl.Items.FindByValue(Convert.ToString(DataBinder.Eval(e.Item.DataItem, "depid"))).Selected = True
        End If

    End Sub

    Protected Sub edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)

    End Sub

    Protected Sub cancel(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
    End Sub


    Protected Sub update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)

    End Sub


End Class
