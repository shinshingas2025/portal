Public Class OrgBO
	Dim objOrgDAO As New OrgDAO
	Dim objDeptDAO As New DeptDAO

	Public Function AddDept(ByVal objDeptEntity As DeptExtendOrgEntity) As Boolean
		Dim flag As Boolean
		Dim OrgKey As Int64
		Dim deptKey As Int64
		OrgKey = CType(objOrgDAO.QueryMaxKey.Tables(0).Rows(0).Item(0), Int64) + 1
		deptKey = CType(objDeptDAO.QueryMaxKey.Tables(0).Rows(0).Item(0), Int64) + 1
		objDeptEntity.DeptID = CType(deptKey, String)
		objDeptEntity.objValue = CType(deptKey, String)
		objDeptEntity.objID = CType(OrgKey, String)
		flag = objOrgDAO.Insert(objDeptEntity)
		flag = objDeptDAO.Insert(objDeptEntity)

	End Function


	Public Function QueryDept(ByVal objDeptEntity As DeptExtendOrgEntity) As DataTable

		Dim dt As DataTable
		dt = objOrgDAO.QueryDS(objDeptEntity).Tables(0)

		Return dt
	End Function


	Public Function DeleteDept(ByVal ObjID As String) As Boolean
		Dim OB As New OrgDAO
		Dim DD As New DeptDAO
		Dim objValue As String
		Dim objDeptEntity As New DeptExtendOrgEntity
		Dim OrgEntity As New OrgEntity
		Dim dt As DataTable
		objDeptEntity.objID = ObjID
		OrgEntity.objID = ObjID
		dt = OB.QueryDS(objDeptEntity).Tables(0)
		If dt.Rows.Count > 0 Then
			objValue = CType(dt.Rows(0).Item("ObjValue"), String)
			objDeptEntity.DeptID = objValue
		End If

		OB.Delete(OrgEntity)
		DD.Delete(objDeptEntity)


	End Function

End Class
