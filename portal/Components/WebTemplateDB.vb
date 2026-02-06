
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal

    '*********************************************************************
    '
    ' EventDB Class
    '
    ' Class that encapsulates all data logic necessary to add/query/delete
    ' events within the Portal database.
    '
    '*********************************************************************

    Public Class WebTemplateDB

        '*********************************************************************
        '
        ' GetEvents Method
        '
        ' The GetEvents method returns a DataSet containing all of the
        ' events for a specific portal module from the events
        ' database.
        '
        ' NOTE: A DataSet is returned from this method to allow this method to support
        ' both desktop and mobile Web UI.
        '
        ' Other relevant sources:
        '     + <a href="GetEvents.htm" style="color:green">GetEvents Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetTemplates() As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetTemplates", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            'parameterModuleId.Value = moduleId
            'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

            '' Add Parameters to SPROC
            'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            'parametersId.Value = sid
            'myCommand.SelectCommand.Parameters.Add(parametersId)


            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


        '*********************************************************************
        '
        ' GetSingleEvent Method
        '
        ' The GetSingleEvent method returns a SqlDataReader containing details
        ' about a specific event from the events database.
        '
        ' Other relevant sources:
        '     + <a href="GetSingleEvent.htm" style="color:green">GetSingleEvent Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetSingleTemplate(ByVal itemId As Integer) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetSingleTemplate", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemId As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemId.Value = itemId
            myCommand.Parameters.Add(parameterItemId)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader 
            Return result

        End Function
    End Class

End Namespace
