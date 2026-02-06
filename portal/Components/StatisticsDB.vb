Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient


Namespace ASPNET.StarterKit.Portal

    '*********************************************************************
    '
    ' AnnounceDB Class
    '
    ' Class that encapsulates all data logic necessary to add/query/delete
    ' announcements within the Portal database.
    '
    '*********************************************************************

    Public Class StatisticsDB


        '*********************************************************************
        '
        ' GetSingleAnnouncement Method
        '
        ' The GetSingleAnnouncement method returns a SqlDataReader containing details
        ' about a specific announcement from the Announcements database table.
        '
        ' Other relevant sources:
        '     + <a href="GetSingleAnnouncement.htm" style="color:green">GetSingleAnnouncement Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetStatisticsBySite(ByVal sid As String) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetStatisticsBySite", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            'Dim parameterItemId As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            'parameterItemId.Value = itemId
            'myCommand.Parameters.Add(parameterItemId)


            Dim parameterSid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parameterSid.Value = sid
            myCommand.Parameters.Add(parameterSid)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader 
            Return result

        End Function

        Public Function GetStatisticsTotal(Optional ByVal sid As String = "") As Integer
            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetStatisticsTotal", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            'Dim parameterItemId As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            'parameterItemId.Value = itemId
            'myCommand.Parameters.Add(parameterItemId)


            Dim parameterSid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parameterSid.Value = sid
            myCommand.Parameters.Add(parameterSid)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            Dim total As Integer
            While result.Read
                total = CType(result.Item(0), Integer)

            End While
            ' Return the datareader 
            Return total


        End Function


        Public Function GetAllStatisticsSite() As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetAllStatisticsSite", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            'Dim parameterItemId As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            'parameterItemId.Value = itemId
            'myCommand.Parameters.Add(parameterItemId)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader 
            Return result

        End Function



        '*********************************************************************
        '
        ' AddAnnouncement Method
        '
        ' The AddAnnouncement method adds a new announcement to the
        ' Announcements database table, and returns the ItemId value as a result.
        '
        ' Other relevant sources:
        '     + <a href="AddAnnouncement.htm" style="color:green">AddAnnouncement Stored Procedure</a>
        '
        '*********************************************************************

        Public Function AddStatistics(ByVal tabIndex As Integer, ByVal tabName As String, ByVal sid As String, ByVal userName As String) As Integer


            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddStatistics", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterItemID)

            Dim parametertabIndex As New SqlParameter("@tabIndex", SqlDbType.Int, 4)
            parametertabIndex.Value = tabIndex
            myCommand.Parameters.Add(parametertabIndex)

            Dim parametertabName As New SqlParameter("@tabName", SqlDbType.NVarChar, 100)
            parametertabName.Value = tabName
            myCommand.Parameters.Add(parametertabName)

            Dim parameterSid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parameterSid.Value = sid
            myCommand.Parameters.Add(parameterSid)

            Dim parameteruserName As New SqlParameter("@userName", SqlDbType.NVarChar, 50)
            parameteruserName.Value = userName
            myCommand.Parameters.Add(parameteruserName)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            Return CInt(parameterItemID.Value)

        End Function




    End Class

End Namespace

