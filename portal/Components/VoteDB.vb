
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal

    '*********************************************************************
    '
    ' LinkDB Class
    '
    ' Class that encapsulates all data logic necessary to add/query/delete
    ' links within the Portal database.
    '
    '*********************************************************************
Public Class VoteDB




        Public Function GetQuestion(ByVal moduleId As Integer, ByVal sid As String) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetVoteQuestion", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleId.Value = moduleId
            myCommand.Parameters.Add(parameterModuleId)

            ' Add Parameters to SPROC
            Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersId.Value = sid
            myCommand.Parameters.Add(parametersId)

            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader 
            Return result

        End Function


        '*********************************************************************
        '
        ' GetSingleLink Method
        '
        ' The GetSingleLink method returns a SqlDataReader containing details
        ' about a specific link from the Links database table.
        '
        ' Other relevant sources:
        '     + <a href="GetSingleLink.htm" style="color:green">GetSingleLink Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetSingleVoteQuestion(ByVal itemId As Integer) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetSingleVoteQuestion", myConnection)

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
        ' DeleteLink Method
        '
        ' The DeleteLink method deletes a specified link from
        ' the Links database table.
        '
        ' Other relevant sources:
        '     + <a href="DeleteLink.htm" style="color:green">DeleteLink Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub DeleteVoteQuestion(ByVal itemID As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_DeleteVoteQuestion", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemID
            myCommand.Parameters.Add(parameterItemID)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        '*********************************************************************
        '
        ' AddLink Method
        '
        ' The AddLink method adds a new link within the
        ' links database table, and returns ItemID value as a result.
        '
        ' Other relevant sources:
        '     + <a href="AddLink.htm" style="color:green">AddLink Stored Procedure</a>
        '
        '*********************************************************************

        Public Function AddVoteQuestion(ByVal moduleId As Integer, ByVal question As String, ByVal sid As String, ByVal userName As String) As Integer

            If userName.Length < 1 Then
                userName = "unknown"
            End If

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddVoteQuestion", myConnection)

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

            Dim parameterTitle As New SqlParameter("@question", SqlDbType.NVarChar, 500)
            parameterTitle.Value = question
            myCommand.Parameters.Add(parameterTitle)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parametersid.Value = sid
            myCommand.Parameters.Add(parametersid)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            Return CInt(parameterItemID.Value)

        End Function

        Public Function AddVoteAnswer(ByVal VoteID As Integer, ByVal answer As String, Optional ByVal userName As String = "") As Integer

            If userName.Length < 1 Then
                userName = "unknown"
            End If

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddVoteAnswer", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterItemID)

            Dim parameterModuleID As New SqlParameter("@VoteID", SqlDbType.Int, 4)
            parameterModuleID.Value = VoteID
            myCommand.Parameters.Add(parameterModuleID)

            Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            parameterUserName.Value = userName
            myCommand.Parameters.Add(parameterUserName)

            Dim parameterTitle As New SqlParameter("@answer", SqlDbType.NVarChar, 500)
            parameterTitle.Value = answer
            myCommand.Parameters.Add(parameterTitle)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            Return CInt(parameterItemID.Value)

        End Function


        '*********************************************************************
        '
        ' UpdateLink Method
        '
        ' The UpdateLink method updates a specified link within
        ' the Links database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateLink.htm" style="color:green">UpdateLink Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub Vote(ByVal moduleId As Integer, ByVal itemId As Integer)


            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateVoteAnswers", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemId
            myCommand.Parameters.Add(parameterItemID)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub

    End Class

End Namespace
