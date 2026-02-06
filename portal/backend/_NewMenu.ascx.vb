Public Class __NewMenu
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cn = New System.Data.SqlClient.SqlConnection
        Me.cmd = New System.Data.SqlClient.SqlCommand
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        '
        'cn
        '
        Me.cn.ConnectionString = "workstation id=""RPTI3-2003"";packet size=4096;user id=shinshin;data source=""RPTI3-" & _
        "2003\W2003"";persist security info=False;initial catalog=shinshin"
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "hotnews", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("newno", "newno"), New System.Data.Common.DataColumnMapping("new_subject", "new_subject"), New System.Data.Common.DataColumnMapping("new_content", "new_content"), New System.Data.Common.DataColumnMapping("new_act", "new_act"), New System.Data.Common.DataColumnMapping("new_link", "new_link"), New System.Data.Common.DataColumnMapping("creater", "creater"), New System.Data.Common.DataColumnMapping("creatdate", "creatdate")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT newno, new_subject, new_content, new_act, new_link, creater, creatdate FRO" & _
        "M dbo.hotnews"
        Me.SqlSelectCommand1.Connection = Me.cn
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO dbo.hotnews(new_subject, new_content, new_act, new_link, creater, cre" & _
        "atdate) VALUES (@new_subject, @new_content, @new_act, @new_link, @creater, @crea" & _
        "tdate); SELECT newno, new_subject, new_content, new_act, new_link, creater, crea" & _
        "tdate FROM dbo.hotnews WHERE (newno = @@IDENTITY)"
        Me.SqlInsertCommand1.Connection = Me.cn
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_subject", System.Data.SqlDbType.VarChar, 125, "new_subject"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_content", System.Data.SqlDbType.VarChar, 2147483647, "new_content"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_act", System.Data.SqlDbType.Int, 4, "new_act"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_link", System.Data.SqlDbType.Int, 4, "new_link"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@creater", System.Data.SqlDbType.VarChar, 125, "creater"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@creatdate", System.Data.SqlDbType.DateTime, 8, "creatdate"))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE dbo.hotnews SET new_subject = @new_subject, new_content = @new_content, ne" & _
        "w_act = @new_act, new_link = @new_link, creater = @creater, creatdate = @creatda" & _
        "te WHERE (newno = @Original_newno) AND (creatdate = @Original_creatdate) AND (cr" & _
        "eater = @Original_creater OR @Original_creater IS NULL AND creater IS NULL) AND " & _
        "(new_act = @Original_new_act) AND (new_link = @Original_new_link OR @Original_ne" & _
        "w_link IS NULL AND new_link IS NULL) AND (new_subject = @Original_new_subject); " & _
        "SELECT newno, new_subject, new_content, new_act, new_link, creater, creatdate FR" & _
        "OM dbo.hotnews WHERE (newno = @newno)"
        Me.SqlUpdateCommand1.Connection = Me.cn
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_subject", System.Data.SqlDbType.VarChar, 125, "new_subject"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_content", System.Data.SqlDbType.VarChar, 2147483647, "new_content"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_act", System.Data.SqlDbType.Int, 4, "new_act"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@new_link", System.Data.SqlDbType.Int, 4, "new_link"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@creater", System.Data.SqlDbType.VarChar, 125, "creater"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@creatdate", System.Data.SqlDbType.DateTime, 8, "creatdate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_newno", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "newno", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_creatdate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "creatdate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_creater", System.Data.SqlDbType.VarChar, 125, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "creater", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_act", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_act", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_link", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_link", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_subject", System.Data.SqlDbType.VarChar, 125, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_subject", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@newno", System.Data.SqlDbType.Int, 4, "newno"))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM dbo.hotnews WHERE (newno = @Original_newno) AND (creatdate = @Origina" & _
        "l_creatdate) AND (creater = @Original_creater OR @Original_creater IS NULL AND c" & _
        "reater IS NULL) AND (new_act = @Original_new_act) AND (new_link = @Original_new_" & _
        "link OR @Original_new_link IS NULL AND new_link IS NULL) AND (new_subject = @Ori" & _
        "ginal_new_subject)"
        Me.SqlDeleteCommand1.Connection = Me.cn
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_newno", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "newno", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_creatdate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "creatdate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_creater", System.Data.SqlDbType.VarChar, 125, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "creater", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_act", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_act", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_link", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_link", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_new_subject", System.Data.SqlDbType.VarChar, 125, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "new_subject", System.Data.DataRowVersion.Original, Nothing))

    End Sub
    Protected WithEvents cn As System.Data.SqlClient.SqlConnection
    Protected WithEvents cmd As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

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
        cn.ConnectionString = "Server=localhost;DataBase=shinshin;uid=shinshin;pwd=shinshin;"
        cn.Open()
        cmd.CommandText = ""
      End Sub

    Private Sub SqlDataAdapter1_RowUpdated(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs) Handles SqlDataAdapter1.RowUpdated

    End Sub
End Class
