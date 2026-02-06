Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports System.IO

Namespace ASPNET.StarterKit.Portal

    '*********************************************************************
    '
    ' HtmlTextDB Class
    '
    ' Class that encapsulates all data logic necessary to add/query/delete
    ' HTML/text within the Portal database.
    '
    '*********************************************************************

    Public Class HtmlTextDB

        '*********************************************************************
        '
        ' GetHtmlText Method
        '
        ' The GetHtmlText method returns a SqlDataReader containing details
        ' about a specific item from the HtmlText database table.
        '
        ' Other relevant sources:
        '     + <a href="GetHtmlText.htm" style="color:green">GetHtmlText Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetHtmlText(ByVal moduleId As Integer, ByVal sid As String) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetHtmlText", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleID As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleID.Value = moduleId
            myCommand.Parameters.Add(parameterModuleID)

            Dim parametersID As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersID.Value = sId
            myCommand.Parameters.Add(parametersID)


            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader 
            Return result

        End Function


        '*********************************************************************
        '
        ' UpdateHtmlText Method
        '
        ' The UpdateHtmlText method updates a specified item within
        ' the HtmlText database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateHtmlText.htm" style="color:green">UpdateHtmlText Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub UpdateHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal DetailHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String, ByVal sid As String, Optional ByVal ImgPost As String = "", Optional ByVal fileName As String = "")

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateHtmlText", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleID As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleID.Value = moduleId
            myCommand.Parameters.Add(parameterModuleID)

            Dim parameterDesktopHtml As New SqlParameter("@DesktopHtml", SqlDbType.NText)
            parameterDesktopHtml.Value = desktopHtml
            myCommand.Parameters.Add(parameterDesktopHtml)


            Dim parameterDetailHtml As New SqlParameter("@DetailHtml", SqlDbType.NText)
            parameterDetailHtml.Value = DetailHtml
            myCommand.Parameters.Add(parameterDetailHtml)

            Dim parameterMobileSummary As New SqlParameter("@MobileSummary", SqlDbType.NText)
            parameterMobileSummary.Value = mobileSummary
            myCommand.Parameters.Add(parameterMobileSummary)

            Dim parameterFileName As New SqlParameter("@FileName", SqlDbType.NVarChar, 100)
            parameterFileName.Value = fileName
            myCommand.Parameters.Add(parameterFileName)

            Dim parameterImgPost As New SqlParameter("@ImgPost", SqlDbType.NVarChar, 2)
            parameterImgPost.Value = ImgPost
            myCommand.Parameters.Add(parameterImgPost)

            Dim parameterMobileDetails As New SqlParameter("@MobileDetails", SqlDbType.NText)
            parameterMobileDetails.Value = mobileDetails
            myCommand.Parameters.Add(parameterMobileDetails)

            Dim parametersID As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersID.Value = sid
            myCommand.Parameters.Add(parametersID)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

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

  
End Namespace
