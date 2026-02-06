
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal


    Public Class CounterDB


        Public Function GetCounter(ByVal sid As String) As Integer

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetCounter", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersId.Value = sid
            myCommand.Parameters.Add(parametersId)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            Dim intCounter As Integer = 0
            While result.Read
                intCounter = CType(result.Item(0), Integer)


            End While

            Return intCounter

        End Function



        Public Sub UpdateCounter(ByVal sid As String)


            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateCounter", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            ' Add Parameters to SPROC
            Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersId.Value = sid
            myCommand.Parameters.Add(parametersId)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub
    End Class

End Namespace
