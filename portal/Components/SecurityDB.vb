Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Public Class SecurityDB
    Public Function GetGlobalBySiteID(ByVal sid As String) As DataSet

        ' Create Instance of Connection and Command Object
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetSite", myConnection)

        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parametersId As New SqlParameter("@sid", SqlDbType.NChar, 5)
        parametersId.Value = sid
        myCommand.SelectCommand.Parameters.Add(parametersId)


        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        ' Return the DataSet
        Return myDataSet

    End Function

    Public Function GetTabBySiteID(ByVal sid As String) As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetTab", myConnection)

        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parametersId As New SqlParameter("@sid", SqlDbType.NChar, 5)
        parametersId.Value = sid
        myCommand.SelectCommand.Parameters.Add(parametersId)


        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        ' Return the DataSet
        Return myDataSet
    End Function

    Public Function GetModuleByTabID(ByVal tabID As String) As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetModule", myConnection)

        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parametertabID As New SqlParameter("@tabID", SqlDbType.NChar, 5)
        parametertabID.Value = tabID
        myCommand.SelectCommand.Parameters.Add(parametertabID)


        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        ' Return the DataSet
        Return myDataSet
    End Function

    Public Function GetALLModule() As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetALLModule", myConnection)
        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure
 
        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        ' Return the DataSet
        Return myDataSet
    End Function




    Public Function GetALLModuleExceptSM() As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetALLModuleExceptSM", myConnection)
        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        ' Return the DataSet
        Return myDataSet
    End Function
    Public Function GetPidByUserID(ByVal UserID As String) As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetPidByUserID", myConnection)
        Dim PID As Integer = 0
        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.NChar, 50)
        parameterUserID.Value = UserID
        myCommand.SelectCommand.Parameters.Add(parameterUserID)


        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        If myDataSet.Tables(0).Rows.Count > 0 Then
            PID = CType(myDataSet.Tables(0).Rows(0).Item("PID"), Integer)
        End If

        ' Return the DataSet
        Return PID
    End Function

    Public Function GetUpidByUserID(ByVal UserID As String) As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
        Dim myCommand As New SqlDataAdapter("Portal_GetUPidByUserID", myConnection)
        Dim PID As Integer = 0
        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.NChar, 50)
        parameterUserID.Value = UserID
        myCommand.SelectCommand.Parameters.Add(parameterUserID)


        ' Create and Fill the DataSet
        Dim myDataSet As New DataSet
        myCommand.Fill(myDataSet)

        If myDataSet.Tables(0).Rows.Count > 0 Then
            PID = CType(myDataSet.Tables(0).Rows(0).Item("PID"), Integer)
        End If

        ' Return the DataSet
        Return PID
    End Function
End Class
