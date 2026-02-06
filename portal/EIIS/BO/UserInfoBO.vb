Public Class UserInfoBO


	Public Function QueryUserInfo(ByVal UID As String) As DataTable
		Dim strSQL As String = ""
		Dim dt As DataTable
		strSQL = "Select * from sysUserInfo where UID = '" & UID & "'"
		Dim conn As New DBConn
		dt = conn.ReadDataTable(strSQL)
		conn.close()

		Return dt

	End Function





	Public Function UpdateUserInfo(ByVal node As User) As Integer
		Dim strSQL As String = ""

		strSQL &= "UPDATE sysUserInfo Set "

		strSQL &= "U_Class='" & node.U_Class.Trim & "',"
		strSQL &= "Cname='" & node.Cname.Trim & "',"
		strSQL &= "Ename='" & node.Ename.Trim & "',"
		strSQL &= "Alias='" & node.Alias1.Trim & "',"

		strSQL &= "IDNum='" & node.IDNum.Trim & "',"
		strSQL &= "Sex=" & node.Sex & ","
		strSQL &= "Addr_ZIP='" & node.Addr_ZIP.Trim & "',"
		strSQL &= "Addr_DIV='" & node.Addr_DIV.Trim & "',"
		strSQL &= "Addr_VIL='" & node.Addr_VIL.Trim & "',"

		strSQL &= "Addr_DOOR='" & node.Addr_DOOR.Trim & "',"
		strSQL &= "nation='" & node.nation.Trim & "',"
		strSQL &= "TelCompany='" & node.TelCompany.Trim & "',"
		strSQL &= "TelHome='" & node.TelHome.Trim & "',"
		strSQL &= "TelMobile='" & node.TelMobile.Trim & "',"

		strSQL &= "Email='" & node.Email.Trim & "',"
		strSQL &= "HomePage='" & node.HomePage.Trim & "',"
		strSQL &= "Company='" & node.Company.Trim & "',"
		strSQL &= "Dept='" & node.Dept.Trim & "',"
		strSQL &= "Title='" & node.Title.Trim & "'"
		strSQL &= " Where UID='" & node.UID.Trim & "'"


		Dim conn As New DBConn
		conn.ExecuteNonQuery(strSQL)
		conn.close()

		Return 0

	End Function

	Public Function InsertUserInfo(ByVal node As User) As Integer
		Dim strSQL As String = ""

		strSQL &= "INSERT INTO sysUserInfo ( UID, U_Class, Cname, Ename, Alias,"
		strSQL &= " IDNum, Sex, Addr_ZIP, Addr_DIV, Addr_VIL, "
		strSQL &= "Addr_DOOR, nation, TelCompany, TelHome, TelMobile,"
		strSQL &= " Email, HomePage, Company, Dept, Title) values("
		strSQL &= "'" & node.UID.Trim & "',"
		strSQL &= "'" & node.U_Class.Trim & "',"
		strSQL &= "'" & node.Cname.Trim & "',"
		strSQL &= "'" & node.Ename.Trim & "',"
		strSQL &= "'" & node.Alias1.Trim & "',"

		strSQL &= "'" & node.IDNum.Trim & "',"
		strSQL &= " " & node.Sex & ","
		strSQL &= "'" & node.Addr_ZIP.Trim & "',"
		strSQL &= "'" & node.Addr_DIV.Trim & "',"
		strSQL &= "'" & node.Addr_VIL.Trim & "',"

		strSQL &= "'" & node.Addr_DOOR.Trim & "',"
		strSQL &= "'" & node.nation.Trim & "',"
		strSQL &= "'" & node.TelCompany.Trim & "',"
		strSQL &= "'" & node.TelHome.Trim & "',"
		strSQL &= "'" & node.TelMobile.Trim & "',"

		strSQL &= "'" & node.Email.Trim & "',"
		strSQL &= "'" & node.HomePage.Trim & "',"
		strSQL &= "'" & node.Company.Trim & "',"
		strSQL &= "'" & node.Dept.Trim & "',"
		strSQL &= "'" & node.Title.Trim & "'"
		strSQL &= ");"
		strSQL &= "INSERT INTO sysCommunity (objName,objValue,srcName,PID,SEQNO,state) values ("
		strSQL &= "'" & node.Cname.Trim & "',"
		strSQL &= "'" & node.UID.Trim & "',"
		strSQL &= "'UserInfo',"
		strSQL &= "" & node.PID & ","
		strSQL &= "'" & node.SEQNO.Trim & "',"
		strSQL &= "'" & node.state.Trim & "'"
		strSQL &= ")"

		Dim conn As New DBConn
		conn.ExecuteNonQuery(strSQL)
		conn.close()

		Return 0

	End Function


	Public Function GetDeptEmp(ByVal DeptID As String) As DataSet
		Dim objUserInfoDAO As New UserInfoDAO

		Return objUserInfoDAO.QueryDS(DeptID)


	End Function

	Public Function SearchUser(ByVal objuser As User) As DataTable
		Dim objUserInfo As New UserInfoDAO
		Dim dt As DataTable
		dt = objUserInfo.QueryUserInfo(objuser).Tables(0)
		Return dt

	End Function

	Public Function updateUserDept(ByVal objuser As User) As Boolean
		Dim objUserInfo As New UserInfoDAO
		Dim flag As Boolean
		flag = objUserInfo.Update(objuser)

	End Function




End Class
