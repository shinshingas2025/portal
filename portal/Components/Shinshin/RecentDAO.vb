Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc


Public Class RECENTDAO
    Public Overridable Function GetWmOpenCode(ByVal sWmEmail As String) As String
        Dim sWmOpenCode As String = ""
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString1"))

        Dim selectSQL As String
        selectSQL = "SELECT wm_user_name,wm_open_code FROM webmember where wm_email='" & sWmEmail.Trim() & "'"

        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                sWmOpenCode = CStr(myReader.GetValue(0)) & Space(10) & CStr(myReader.GetValue(1))
            Catch ex As System.InvalidCastException
                sWmOpenCode = ""
            End Try
        End While
        myReader.Close()

        Return sWmOpenCode




    End Function

    Public Overridable Function GetWmOpenCode2(ByVal no As String) As String
        Dim sWmOpenCode As String = ""
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString1"))

        Dim selectSQL As String
        selectSQL = "SELECT wm_user_name,wm_open_code FROM webmember where wm_no=" & no.Trim() & ""

        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                sWmOpenCode = CStr(myReader.GetValue(0)) & Space(10) & CStr(myReader.GetValue(1))
            Catch ex As System.InvalidCastException
                sWmOpenCode = ""
            End Try
        End While
        myReader.Close()

        Return sWmOpenCode

    End Function


    Public Overridable Function GetWmOpenCode1(ByVal no As String) As String
        Dim sWmOpenCode As String = ""
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString1"))

        Dim selectSQL As String
        selectSQL = "SELECT wm_user_name FROM webmember where wm_email=" & no.Trim() & ""

        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                sWmOpenCode = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                sWmOpenCode = ""
            End Try
        End While
        myReader.Close()

        Return sWmOpenCode




    End Function


End Class
