Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions


Namespace ASPNET.StarterKit.Portal

    '*********************************************************************
    '
    ' PortalSecurity Class
    '
    ' The PortalSecurity class encapsulates two helper methods that enable
    ' developers to easily check the role status of the current browser client.
    '
    '*********************************************************************

    Public Class PortalSecurity

        '*********************************************************************
        '
        ' Security.Encrypt() Method
        '
        ' The Encrypt method encryts a clean string into a hashed string

        '
        '*********************************************************************

        Public Shared Function Encrypt(ByVal cleanString As String) As String
            Dim clearBytes As [Byte]()
            clearBytes = New UnicodeEncoding().GetBytes(cleanString)
            Dim hashedBytes As [Byte]() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(clearBytes)
            Dim hashedText As String = BitConverter.ToString(hashedBytes)
            Return hashedText
        End Function

        '*********************************************************************
        '
        ' PortalSecurity.IsInRole() Method
        '
        ' The IsInRole method enables developers to easily check the role
        ' status of the current browser client.
        '
        '*********************************************************************

        Public Shared Function IsInRole(ByVal role As String) As Boolean

            Return HttpContext.Current.User.IsInRole(role)

        End Function


        '*********************************************************************
        '
        ' PortalSecurity.IsInRoles() Method
        '
        ' The IsInRoles method enables developers to easily check the role
        ' status of the current browser client against an array of roles
        '
        '*********************************************************************

        Public Shared Function IsInRoles(ByVal roles As String) As Boolean

            Dim context As HttpContext = HttpContext.Current

            Dim role As String
            For Each role In roles.Split(New Char() {";"c})

                If role <> "" And Not role Is Nothing And (role = "All Users" Or context.User.IsInRole(role)) Then
                    Return True
                End If

            Next role

            Return False

        End Function

        '*********************************************************************
        '
        ' PortalSecurity.HasEditPermissions() Method
        '
        ' The HasEditPermissions method enables developers to easily check 
        ' whether the current browser client has access to edit the settings
        ' of a specified portal module
        '
        '*********************************************************************

        Public Shared Function HasEditPermissions(ByVal moduleId As Integer) As Boolean

            Dim accessRoles As String
            Dim editRoles As String

            ' Obtain SiteSettings from Current Context
            Dim siteSettings As SiteConfiguration = CType(HttpContext.Current.Items("SiteSettings"), SiteConfiguration)

            ' Find the appropriate Module in the Module table
            Dim moduleRow As SiteConfiguration._ModuleRow = siteSettings._Module.FindByModuleId(moduleId)

            editRoles = moduleRow.EditRoles
            accessRoles = moduleRow.TabRow.AccessRoles

            If PortalSecurity.IsInRoles(accessRoles) = False Or PortalSecurity.IsInRoles(editRoles) = False Then
                Return False
            Else
                Return True
            End If

        End Function

    End Class


    '*********************************************************************
    '
    ' UsersDB Class
    '
    ' The UsersDB class encapsulates all data logic necessary to add/login/query
    ' users within the Portal Users database.
    '
    ' Important Note: The UsersDB class is only used when forms-based cookie
    ' authentication is enabled within the portal.  When windows based
    ' authentication is used instead, then either the Windows SAM or Active Directory
    ' is used to store and validate all username/password credentials.
    '
    '*********************************************************************

    Public Class UsersDB

        '*********************************************************************
        '
        ' UsersDB.AddUser() Method <a name="AddUser"></a>
        '
        ' The AddUser method inserts a new user record into the "Users" database table.
        '
        ' Other relevant sources:
        '     + <a href="AddUser.htm" style="color:green">AddUser Stored Procedure</a>
        '
        '*********************************************************************

        Public Function AddUser(ByVal fullName As String, ByVal email As String, ByVal password As String, ByVal sid As String) As Integer

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_AddUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterFullName As New SqlParameter("@Name", SqlDbType.NVarChar, 50)
            parameterFullName.Value = fullName
            myCommand.Parameters.Add(parameterFullName)

            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
            parameterEmail.Value = email
            myCommand.Parameters.Add(parameterEmail)

            Dim parameterPassword As New SqlParameter("@Password", SqlDbType.NVarChar, 50)
            parameterPassword.Value = password
            myCommand.Parameters.Add(parameterPassword)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 50)
            parametersid.Value = sid
            myCommand.Parameters.Add(parametersid)

            Dim parameterUserId As New SqlParameter("@UserID", SqlDbType.Int)
            parameterUserId.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterUserId)

            ' Execute the command in a try/catch to catch duplicate username errors
            Try

                ' Open the connection and execute the Command
                myConnection.Open()
                myCommand.ExecuteNonQuery()

            Catch

                ' failed to create a new user
                Return -1

            Finally

                ' Close the Connection
                If myConnection.State = ConnectionState.Open Then
                    myConnection.Close()
                End If

            End Try

            Return CInt(parameterUserId.Value)

        End Function


        '*********************************************************************
        '
        ' UsersDB.DeleteUser() Method <a name="DeleteUser"></a>
        '
        ' The DeleteUser method deleted a  user record from the "Users" database table.
        '
        ' Other relevant sources:
        '     + <a href="DeleteUser.htm" style="color:green">DeleteUser Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub DeleteUser(ByVal userId As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_DeleteUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            Dim parameterUserId As New SqlParameter("@UserID", SqlDbType.Int)
            parameterUserId.Value = userId
            myCommand.Parameters.Add(parameterUserId)

            ' Open the database connection and execute the command
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        '*********************************************************************
        '
        ' UsersDB.UpdateUser() Method <a name="DeleteUser"></a>
        '
        ' The UpdateUser method deleted a  user record from the "Users" database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateUser.htm" style="color:green">UpdateUser Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub UpdateUser(ByVal userId As Integer, ByVal email As String, ByVal password As String)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_UpdateUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            Dim parameterUserId As New SqlParameter("@UserID", SqlDbType.Int)
            parameterUserId.Value = userId
            myCommand.Parameters.Add(parameterUserId)

            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
            parameterEmail.Value = email
            myCommand.Parameters.Add(parameterEmail)

            Dim parameterPassword As New SqlParameter("@Password", SqlDbType.NVarChar, 50)
            parameterPassword.Value = password
            myCommand.Parameters.Add(parameterPassword)

            ' Open the database connection and execute the command
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        '*********************************************************************
        '
        ' UsersDB.GetRolesByUser() Method <a name="GetRolesByUser"></a>
        '
        ' The DeleteUser method deleted a  user record from the "Users" database table.
        '
        ' Other relevant sources:
        '     + <a href="GetRolesByUser.htm" style="color:green">GetRolesByUser Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetRolesByUser(ByVal email As String) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetRolesByUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
            parameterEmail.Value = email
            myCommand.Parameters.Add(parameterEmail)

            ' Open the database connection and execute the command
            myConnection.Open()
            Dim dr As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader
            Return dr

        End Function


        '*********************************************************************
        '
        ' GetSingleUser Method
        '
        ' The GetSingleUser method returns a SqlDataReader containing details
        ' about a specific user from the Users database table.
        '
        '*********************************************************************

        Public Function GetSingleUser(ByVal email As String) As SqlDataReader

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetSingleUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
            parameterEmail.Value = email
            myCommand.Parameters.Add(parameterEmail)

            ' Open the database connection and execute the command
            myConnection.Open()
            Dim dr As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' Return the datareader
            Return dr

        End Function

        '*********************************************************************
        '
        ' GetRoles() Method <a name="GetRoles"></a>
        '
        ' The GetRoles method returns a list of role names for the user.
        '
        ' Other relevant sources:
        '     + <a href="GetRolesByUser.htm" style="color:green">GetRolesByUser Stored Procedure</a>
        '
        '*********************************************************************

        Public Function GetRoles(ByVal email As String) As String()

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_GetRolesByUser", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
            parameterEmail.Value = email
            myCommand.Parameters.Add(parameterEmail)

            ' Open the database connection and execute the command
            Dim dr As SqlDataReader

            myConnection.Open()
            dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            ' create a String array from the data
            Dim userRoles As New ArrayList

            While dr.Read()
                userRoles.Add(dr("RoleName"))
            End While

            dr.Close()

            ' Return the String array of roles
            Return CType(userRoles.ToArray(GetType(String)), String())

        End Function

        '*********************************************************************
        '
        ' UsersDB.Login() Method <a name="Login"></a>
        '
        ' The Login method validates a email/password pair against credentials
        ' stored in the users database.  If the email/password pair is valid,
        ' the method returns user's name.
        '
        ' Other relevant sources:
        '     + <a href="UserLogin.htm" style="color:green">UserLogin Stored Procedure</a>
        '
        '*********************************************************************

        Public Function Login(ByVal LoginID As String, ByVal password As String) As String

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_EIIS_UserLogin", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterLoginID As New SqlParameter("@LoginID", SqlDbType.NVarChar, 100)
            parameterLoginID.Value = LoginID
            myCommand.Parameters.Add(parameterLoginID)

            Dim parameterPassword As New SqlParameter("@Password", SqlDbType.NVarChar, 50)
            parameterPassword.Value = password
            myCommand.Parameters.Add(parameterPassword)

            Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            parameterUserName.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterUserName)

            'Dim parameterUserUnit As New SqlParameter("@UserUnit", SqlDbType.NVarChar, 50)
            'parameterUserUnit.Direction = ParameterDirection.Output
            'myCommand.Parameters.Add(parameterUserUnit)

            ' Open the database connection and execute the command
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            If Not parameterUserName.Value Is Nothing And Not parameterUserName.Value Is System.DBNull.Value Then
                'And Not parameterUserUnit.Value Is Nothing Then
                Return CStr(parameterUserName.Value).Trim()
            Else
                Return String.Empty
            End If

        End Function

        Public Function checkISExpired(ByVal UserID As String) As Boolean
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_EIIS_UserLoginISExpired", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.NVarChar, 100)
            parameterUserID.Value = UserID
            myCommand.Parameters.Add(parameterUserID)


            Dim parametercount As New SqlParameter("@count", SqlDbType.Int, 50)
            parametercount.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parametercount)

            ' Open the database connection and execute the command

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            If CType(parametercount.Value, Integer) > 0 Then
                Return True

            Else
                Return False
            End If
        End Function

        Public Function checkISOutService(ByVal UserID As String) As Boolean
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_EIIS_UserLoginISOutService", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.NVarChar, 100)
            parameterUserID.Value = UserID
            myCommand.Parameters.Add(parameterUserID)


            Dim parametercount As New SqlParameter("@count", SqlDbType.Int, 50)
            parametercount.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parametercount)

            ' Open the database connection and execute the command

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
            If CType(parametercount.Value, Integer) > 0 Then
                Return True

            Else
                Return False
            End If
        End Function

    End Class

End Namespace