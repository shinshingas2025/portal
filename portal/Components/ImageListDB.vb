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

    Public Class ImageListDB

        '*********************************************************************
        '
        ' GetAnnouncements Method
        '
        ' The GetAnnouncements method returns a DataSet containing all of the
        ' announcements for a specific portal module from the Announcements
        ' database table.
        '
        ' NOTE: A DataSet is returned from this method to allow this method to support
        ' both desktop and mobile Web UI.
        '
        ' Other relevant sources:
        '     + <a href="GetAnnouncements.htm" style="color:green">GetAnnouncements Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetImageList(ByVal moduleId As Integer, ByVal sid As String) As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetImage", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleId.Value = moduleId
            myCommand.SelectCommand.Parameters.Add(parameterModuleId)

            ' Add Parameters to SPROC
            Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
            parametersId.Value = sid
            myCommand.SelectCommand.Parameters.Add(parametersId)

            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)



            ' Return the DataSet
            Return myDataSet

        End Function


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

        Public Function GetSingleImage(ByVal itemId As Integer) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetSingleImage", myConnection)

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
        ' DeleteAnnouncement Method
        '
        ' The DeleteAnnouncement method deletes the specified announcement from
        ' the Announcements database table.
        '
        ' Other relevant sources:
        '     + <a href="DeleteAnnouncement.htm" style="color:green">DeleteAnnouncement Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub DeleteImage(ByVal itemID As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_DeleteImage", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemID
            myCommand.Parameters.Add(parameterItemID)

            'Dim parameterSID As New SqlParameter("@SID", SqlDbType.NVarChar, 5)
            'parameterSID.Value = sid
            'myCommand.Parameters.Add(parameterSID)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


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

        Public Function AddImage(ByVal moduleId As Integer, ByVal userName As String, ByVal ImagePath As String, ByVal ImageName As String, ByVal Url As String, ByVal OrderNO As Integer, ByVal sid As String) As Integer

            If userName.Length < 1 Then
                userName = "unknown"
            End If

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddImage", myConnection)

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

            Dim parameterImagePath As New SqlParameter("@ImagePath", SqlDbType.NVarChar, 150)
            parameterImagePath.Value = ImagePath
            myCommand.Parameters.Add(parameterImagePath)

            Dim parameterImageName As New SqlParameter("@ImageName", SqlDbType.NVarChar, 150)
            parameterImageName.Value = ImageName
            myCommand.Parameters.Add(parameterImageName)

            Dim parameterMobileUrl As New SqlParameter("@Url", SqlDbType.NVarChar, 150)
            parameterMobileUrl.Value = Url
            myCommand.Parameters.Add(parameterMobileUrl)

            Dim parameterOrderNO As New SqlParameter("@OrderNO", SqlDbType.Int, 4)
            parameterOrderNO.Value = OrderNO
            myCommand.Parameters.Add(parameterOrderNO)

            Dim parameterSid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parameterSid.Value = sid
            myCommand.Parameters.Add(parameterSid)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            Return CInt(parameterItemID.Value)

        End Function


        '*********************************************************************
        '
        ' UpdateAnnouncement Method
        '
        ' The UpdateAnnouncement method updates the specified announcement within
        ' the Announcements database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateAnnouncement.htm" style="color:green">UpdateAnnouncement Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub UpdateImage(ByVal OrderNO As Integer, ByVal itemId As Integer, ByVal userName As String, ByVal ImagePath As String, ByVal ImageName As String, ByVal Url As String)
            If userName.Length < 1 Then
                userName = "unknown"
            End If
            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateImage", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterItemID As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemID.Value = itemId
            myCommand.Parameters.Add(parameterItemID)

            Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            parameterUserName.Value = userName
            myCommand.Parameters.Add(parameterUserName)

            Dim parameterImagePath As New SqlParameter("@ImagePath", SqlDbType.NVarChar, 100)
            parameterImagePath.Value = ImagePath
            myCommand.Parameters.Add(parameterImagePath)

            Dim parameterImageName As New SqlParameter("@ImageName", SqlDbType.NVarChar, 100)
            parameterImageName.Value = ImageName
            myCommand.Parameters.Add(parameterImageName)

            Dim parameterUrl As New SqlParameter("@Url", SqlDbType.NVarChar, 150)
            parameterUrl.Value = Url
            myCommand.Parameters.Add(parameterUrl)

            Dim parameterOrderNO As New SqlParameter("@OrderNO", SqlDbType.Int, 4)
            parameterOrderNO.Value = OrderNO
            myCommand.Parameters.Add(parameterOrderNO)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub

    End Class

End Namespace

