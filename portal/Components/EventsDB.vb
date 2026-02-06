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

    Public Class EventsDB

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

        Public Function GetEvents(ByVal moduleId As Integer, ByVal sid As String) As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetEvents", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleId.Value = moduleId
            myCommand.SelectCommand.Parameters.Add(parameterModuleId)

            ' Add Parameters to SPROC
            Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersId.Value = sId
            myCommand.SelectCommand.Parameters.Add(parametersId)


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

        Public Function GetSingleEvent(ByVal itemId As Integer) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetSingleEvent", myConnection)

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


        '*********************************************************************
        '
        ' DeleteEvent Method
        '
        ' The DeleteEvent method deletes a specified event from
        ' the events database.
        '
        ' Other relevant sources:
        '     + <a href="DeleteEvent.htm" style="color:green">DeleteEvent Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub DeleteEvent(ByVal itemID As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_DeleteEvent", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemID
            myCommand.Parameters.Add(parameterItemID)

            ' Open the database connection and execute SQL Command
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        '*********************************************************************
        '
        ' AddEvent Method
        '
        ' The AddEvent method adds a new event within the Events database table, 
        ' and returns the ItemID value as a result.
        '
        ' Other relevant sources:
        '     + <a href="AddEvent.htm" style="color:green">AddEvent Stored Procedure</a>
        '
        '*********************************************************************

        Public Function AddEvent(ByVal moduleId As Integer, ByVal itemId As Integer, ByVal userName As String, ByVal title As String, ByVal expireDate As DateTime, ByVal description As String, ByVal wherewhen As String, ByVal sid As String) As Integer

            If userName.Length < 1 Then
                userName = "unknown"
            End If

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddEvent", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterItemID)

            Dim parameterModuleID As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleID.Value = moduleId
            myCommand.Parameters.Add(parameterModuleID)

            Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            parameterUserName.Value = userName
            myCommand.Parameters.Add(parameterUserName)

            Dim parameterTitle As New SqlParameter("@Title", SqlDbType.NVarChar, 100)
            parameterTitle.Value = title
            myCommand.Parameters.Add(parameterTitle)

            Dim parameterWhereWhen As New SqlParameter("@WhereWhen", SqlDbType.NVarChar, 100)
            parameterWhereWhen.Value = wherewhen
            myCommand.Parameters.Add(parameterWhereWhen)

            Dim parameterExpireDate As New SqlParameter("@ExpireDate", SqlDbType.DateTime, 8)
            parameterExpireDate.Value = expireDate
            myCommand.Parameters.Add(parameterExpireDate)

            Dim parameterDescription As New SqlParameter("@Description", SqlDbType.NVarChar, 2000)
            parameterDescription.Value = description
            myCommand.Parameters.Add(parameterDescription)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parametersid.Value = sid
            myCommand.Parameters.Add(parametersid)


            ' Open the database connection and execute SQL Command
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            ' Return the new Event ItemID
            Return CInt(parameterItemID.Value)

        End Function


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

        Public Sub UpdateEvent(ByVal moduleId As Integer, ByVal itemId As Integer, ByVal userName As String, ByVal title As String, ByVal expireDate As DateTime, ByVal description As String, ByVal wherewhen As String)

            If userName.Length < 1 Then
                userName = "unknown"
            End If

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateEvent", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemId
            myCommand.Parameters.Add(parameterItemID)

            Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            parameterUserName.Value = userName
            myCommand.Parameters.Add(parameterUserName)

            Dim parameterTitle As New SqlParameter("@Title", SqlDbType.NVarChar, 100)
            parameterTitle.Value = title
            myCommand.Parameters.Add(parameterTitle)

            Dim parameterWhereWhen As New SqlParameter("@WhereWhen", SqlDbType.NVarChar, 100)
            parameterWhereWhen.Value = wherewhen
            myCommand.Parameters.Add(parameterWhereWhen)

            Dim parameterExpireDate As New SqlParameter("@ExpireDate", SqlDbType.DateTime, 8)
            parameterExpireDate.Value = expireDate
            myCommand.Parameters.Add(parameterExpireDate)

            Dim parameterDescription As New SqlParameter("@Description", SqlDbType.NVarChar, 2000)
            parameterDescription.Value = description
            myCommand.Parameters.Add(parameterDescription)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub

    End Class

End Namespace