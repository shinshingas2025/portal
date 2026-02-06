
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
    Public Class SiteDB


        Public Function GetAllSite() As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetAllSite", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function

        Public Function GetAllSchoolAreaCode() As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetAllSchoolAreaCode", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


        Public Function GetSchoolCodeByArea(ByVal SchoolArea As String) As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetSchoolCodeByArea", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim parameterSchoolArea As New SqlParameter("@SchoolArea", SqlDbType.NChar, 2)
            parameterSchoolArea.Value = SchoolArea
            myCommand.SelectCommand.Parameters.Add(parameterSchoolArea)
            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


        Public Function GetSite(ByVal itemid As Integer) As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetSiteInfo", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim parameteritemid As New SqlParameter("@itemid", SqlDbType.Int, 4)
            parameteritemid.Value = itemid
            myCommand.SelectCommand.Parameters.Add(parameteritemid)
            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


        Public Function GetSiteBySid(ByVal sid As Integer) As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetSiteInfoBySid", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim parametersid As New SqlParameter("@sid", SqlDbType.Int, 4)
            parametersid.Value = sid
            myCommand.SelectCommand.Parameters.Add(parametersid)
            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

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


        Public Function AddModule(ByVal tabId As Integer, ByVal moduleOrder As Integer, ByVal paneName As String, ByVal title As String, ByVal moduleDefId As Integer, ByVal cacheTime As Integer, ByVal editRoles As String, ByVal showMobile As Boolean, ByVal sid As String) As Integer

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddModule", myConnection)
            Dim moduleID As Integer

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parametertabId As New SqlParameter("@tabId", SqlDbType.Int, 4)
            parametertabId.Value = tabId
            myCommand.Parameters.Add(parametertabId)


            Dim parametermoduleOrder As New SqlParameter("@moduleOrder", SqlDbType.Int, 4)
            parametermoduleOrder.Value = moduleOrder
            myCommand.Parameters.Add(parametermoduleOrder)

            Dim parameterpaneName As New SqlParameter("@paneName", SqlDbType.NVarChar, 20)
            parameterpaneName.Value = paneName
            myCommand.Parameters.Add(parameterpaneName)

            Dim parametertitle As New SqlParameter("@title", SqlDbType.NVarChar, 255)
            parametertitle.Value = title
            myCommand.Parameters.Add(parametertitle)


            Dim parametermoduleDefId As New SqlParameter("@moduleDefId", SqlDbType.Int, 4)
            parametermoduleDefId.Value = moduleDefId
            myCommand.Parameters.Add(parametermoduleDefId)


            Dim parametercacheTime As New SqlParameter("@cacheTime", SqlDbType.Int, 4)
            parametercacheTime.Value = cacheTime
            myCommand.Parameters.Add(parametercacheTime)


            Dim parametereditRoles As New SqlParameter("@editRoles", SqlDbType.NVarChar, 255)
            parametereditRoles.Value = editRoles
            myCommand.Parameters.Add(parametereditRoles)

            Dim parametershowMobile As New SqlParameter("@showMobile", SqlDbType.Bit, 4)
            parametershowMobile.Value = showMobile
            myCommand.Parameters.Add(parametershowMobile)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parametersid.Value = sid
            myCommand.Parameters.Add(parametersid)


            Dim parametermoduleID As New SqlParameter("@moduleID", SqlDbType.NVarChar, 5)
            parametermoduleID.Direction = ParameterDirection.Output

            myCommand.Parameters.Add(parametermoduleID)


            ' Execute the command
            myConnection.Open()
            Dim result As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            myConnection.Close()

            Return CType(parametermoduleID.Value, Integer)


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

        Public Function GetTop10Site() As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetTop10Site", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


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

        Public Function SearchSite(ByVal strSearch As String) As DataSet

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_GetSearchSite", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim parameterstrSearch As New SqlParameter("@strSearch", SqlDbType.NVarChar, 255)
            parameterstrSearch.Value = strSearch
            myCommand.SelectCommand.Parameters.Add(parameterstrSearch)
            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function



        Public Function AddSite(ByVal PortalName As String, ByVal SchoolCode As String, ByVal SchoolDN As String) As Integer


            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_AddSite", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim parameterPortalName As New SqlParameter("@objName", SqlDbType.NVarChar, 255)
            parameterPortalName.Value = PortalName
            myCommand.SelectCommand.Parameters.Add(parameterPortalName)


            Dim parameterobjValue As New SqlParameter("@objValue", SqlDbType.NVarChar, 255)
            parameterobjValue.Value = ""
            myCommand.SelectCommand.Parameters.Add(parameterobjValue)


            Dim parameterPID As New SqlParameter("@PID", SqlDbType.NVarChar, 255)
            parameterPID.Value = 1
            myCommand.SelectCommand.Parameters.Add(parameterPID)


            Dim parameterSEQNO As New SqlParameter("@SEQNO", SqlDbType.NVarChar, 255)
            parameterSEQNO.Value = "1"
            myCommand.SelectCommand.Parameters.Add(parameterSEQNO)


            Dim parameterstate As New SqlParameter("@state", SqlDbType.NVarChar, 255)
            parameterstate.Value = ""
            myCommand.SelectCommand.Parameters.Add(parameterstate)

            Dim parameterDataType As New SqlParameter("@DataType", SqlDbType.NVarChar, 255)
            parameterDataType.Value = "Joblist"
            myCommand.SelectCommand.Parameters.Add(parameterDataType)

            Dim parametersrcName As New SqlParameter("@srcName", SqlDbType.NVarChar, 255)
            parametersrcName.Value = "Joblist"
            myCommand.SelectCommand.Parameters.Add(parametersrcName)

            Dim parameterSchoolCode As New SqlParameter("@SchoolCode", SqlDbType.NVarChar, 255)
            parameterSchoolCode.Value = SchoolCode
            myCommand.SelectCommand.Parameters.Add(parameterSchoolCode)

            Dim parameterSchoolDN As New SqlParameter("@SchoolDN", SqlDbType.NVarChar, 255)
            parameterSchoolDN.Value = SchoolDN
            myCommand.SelectCommand.Parameters.Add(parameterSchoolDN)


            Dim parametersid As New SqlParameter("@sid", SqlDbType.Int, 4)
            parametersid.Direction = ParameterDirection.Output
            myCommand.SelectCommand.Parameters.Add(parametersid)

            myConnection.Open()
            myCommand.SelectCommand.ExecuteNonQuery()
            myConnection.Close()
            ' Return the DataSet

            Return CType(parametersid.Value, Integer)


        End Function


        Public Sub UpdateSiteLogo(ByVal sid As String, ByVal imagelogo As String)

            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_UpdateSiteLogo", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure


            Dim parameterimagelogo As New SqlParameter("@imagelogo", SqlDbType.NVarChar, 255)
            parameterimagelogo.Value = imagelogo
            myCommand.SelectCommand.Parameters.Add(parameterimagelogo)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parametersid.Value = sid
            myCommand.SelectCommand.Parameters.Add(parametersid)

            myConnection.Open()
            myCommand.SelectCommand.ExecuteNonQuery()
            myConnection.Close()
            ' Return the DataSet


        End Sub



    End Class

End Namespace
