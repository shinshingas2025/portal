Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal

    Public Class Portal_DefModuleDB

        Public Function GetDefModule(ByVal ModuleDefId As Integer, ByVal sid As String) As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetDefModule", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleDefId As New SqlParameter("@ModuleDefId", SqlDbType.Int, 4)
            parameterModuleDefId.Value = ModuleDefId
            myCommand.SelectCommand.Parameters.Add(parameterModuleDefId)


            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function



        Public Function GetALLModule() As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetALLModule", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC


            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function

        Public Sub AddDefModule(ByVal FriendlyName As String, ByVal DesktopSourceFile As String, ByVal MobileSourceFile As String)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddDefModule", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC

            Dim parameterFriendlyName As New SqlParameter("@FriendlyName", SqlDbType.NVarChar, 255)
            parameterFriendlyName.Value = FriendlyName
            myCommand.Parameters.Add(parameterFriendlyName)

            Dim parameterDesktopSourceFile As New SqlParameter("@DesktopSourceFile", SqlDbType.NVarChar, 255)
            parameterDesktopSourceFile.Value = DesktopSourceFile
            myCommand.Parameters.Add(parameterDesktopSourceFile)

            Dim parameterMobileSourceFile As New SqlParameter("@MobileSourceFile", SqlDbType.NVarChar, 255)
            parameterMobileSourceFile.Value = MobileSourceFile
            myCommand.Parameters.Add(parameterMobileSourceFile)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        '*********************************************************************
        '
        ' UpdateEvent Method
        '
        ' The UpdateEvent method updates the specified event within
        ' the Events database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateEvent.htm" style="color:green">UpdateEvent Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub UpdateDefModule(ByVal ModuleDefId As Integer, ByVal FriendlyName As String, ByVal DesktopSourceFile As String, ByVal MobileSourceFile As String)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateDefModule", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleDefId As New SqlParameter("@ModuleDefId", SqlDbType.Int, 4)
            parameterModuleDefId.Value = ModuleDefId
            myCommand.Parameters.Add(parameterModuleDefId)

            Dim parameterFriendlyName As New SqlParameter("@FriendlyName", SqlDbType.NVarChar, 255)
            parameterFriendlyName.Value = FriendlyName
            myCommand.Parameters.Add(parameterFriendlyName)

            Dim parameterDesktopSourceFile As New SqlParameter("@DesktopSourceFile", SqlDbType.NVarChar, 255)
            parameterDesktopSourceFile.Value = DesktopSourceFile
            myCommand.Parameters.Add(parameterDesktopSourceFile)

            Dim parameterMobileSourceFile As New SqlParameter("@MobileSourceFile", SqlDbType.NVarChar, 255)
            parameterMobileSourceFile.Value = MobileSourceFile
            myCommand.Parameters.Add(parameterMobileSourceFile)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        Public Sub DeleteDefModule(ByVal ModuleDefId As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_DeleteDefModule", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleDefId As New SqlParameter("@ModuleDefId", SqlDbType.Int, 4)
            parameterModuleDefId.Value = ModuleDefId
            myCommand.Parameters.Add(parameterModuleDefId)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub
    End Class

End Namespace
