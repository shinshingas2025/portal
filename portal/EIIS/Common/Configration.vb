Imports System.Configuration
Public Class Configration

    Public Shared DBServerName As String = ConfigurationSettings.AppSettings("DBServerName")
    Public Shared DBUserId As String = ConfigurationSettings.AppSettings("DBUserId")
    Public Shared DBPassword As String = ConfigurationSettings.AppSettings("DBPassword")
    Public Shared DBDatabase As String = ConfigurationSettings.AppSettings("DBDatabase")

    Public Shared DBServerName2 As String = ConfigurationSettings.AppSettings("DBServerName2")
    Public Shared DBUserId2 As String = ConfigurationSettings.AppSettings("DBUserId2")
    Public Shared DBPassword2 As String = ConfigurationSettings.AppSettings("DBPassword2")
    Public Shared DBDatabase2 As String = ConfigurationSettings.AppSettings("DBDatabase2")

    Public Shared DBServerName3 As String = ConfigurationSettings.AppSettings("DBServerName3")
    Public Shared DBUserId3 As String = ConfigurationSettings.AppSettings("DBUserId3")
    Public Shared DBPassword3 As String = ConfigurationSettings.AppSettings("DBPassword3")
    Public Shared DBDatabase3 As String = ConfigurationSettings.AppSettings("DBDatabase3")

    Public Shared ReportServerURL As String = ConfigurationSettings.AppSettings("ReportServerURL")

    Public Shared SmtpServer As String = ConfigurationSettings.AppSettings("SmtpServer")
    '1090924 add 
    Public Shared OracleConnectionString As String = ConfigurationSettings.AppSettings("OracleConnectionString")


    Public Shared Function Text2Html(ByVal strText As String, Optional ByVal maxNum As Integer = 0) As String
        Dim tempText As String
        tempText = strText.Replace(Chr(13) & Chr(10), "<BR>")
        If maxNum > 0 Then
            tempText = Mid(tempText, 1, maxNum)
        End If
        Return tempText

    End Function


End Class


