Imports System.IO

Public Class editCss
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim path As String = Server.MapPath("..\csstemplate\ASPNETPortal.css")
        Dim path2 As String = Server.MapPath("..\css\test.css")

        ' Try
        'Dim fs As FileStream = File.Create(path)
        'fs.Close()

        ' Ensure that the target does not exist.
        File.Delete(path2)

        ' Copy the file.
        File.Copy(path, path2)
        ' Console.WriteLine("{0} copied to {1}", path, path2)

        ' Try to copy the same file again, which should succeed.
        File.Copy(path, path2, True)
        Response.Write("The second Copy operation succeeded, which was expected.")

        ' Catch
        'Response.Write("Double copying is not allowed, which was not expected.")
        'End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    'UploadFile = PostedFile
    'DM_FileName 要存的檔名
    'FilePath 要存的路徑
    Public Function PhotoUpload(ByVal UploadFile As HttpPostedFile, ByVal DM_FileName As String, ByVal FilePath As String) As String
        Dim UFileNamen As String
        Dim SaveFileName As String = ""
        Dim mypage As UI.Page = New UI.Page
        Dim Fe_Array() As String = {".PNG", ".JPG", ".GIF"}
        Dim For_I As Integer
        Dim Fe_State As Boolean
        If UploadFile.ContentLength <> Nothing Then
            Dim UFilePath As String = UploadFile.FileName
            UFileNamen = Path.GetFileName(UFilePath)
            Dim UFileExtension As String = Path.GetExtension(UFileNamen)
            UFileExtension = UFileExtension.ToUpper()
            Fe_State = False
            For For_I = 0 To Fe_Array.Length - 1
                If (Fe_Array(For_I) = UFileExtension) Then
                    Fe_State = True
                    Exit For
                End If
            Next

            If Fe_State Then
                SaveFileName = DM_FileName & UFileExtension
                FilePath = mypage.Server.MapPath(FilePath)
                UploadFile.SaveAs(FilePath & "\" & SaveFileName)
                FilePath = SaveFileName
            Else
                FilePath = ""
            End If
        Else
            FilePath = ""
        End If
        Return FilePath
    End Function
End Class
