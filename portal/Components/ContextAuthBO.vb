Public Class ContextAuthBO


	Public Function CheckPurview(ByVal ObjID As String, ByVal RecID As String, ByVal UserID As String, ByVal OP As String) As Boolean
		Dim objCA As New ContextAuthDAO
		Dim dt As DataTable
		'找出要檢查的記錄
		dt = objCA.QueryObjTableRec(ObjID, RecID).Tables(0)
		If dt.Rows.Count = 0 Then
			Return False
			Exit Function
		End If
		Dim Permission As String
		Dim CreatorID As String

		Permission = CType(dt.Rows(0).Item("Permission"), String)
		CreatorID = CType(dt.Rows(0).Item("CreatorID"), String)
		'分析三級權限
		Dim OPAuth As String
		Dim CrAuth As Boolean = False
		Dim GrAuth As Boolean = False
		Dim OtAuth As Boolean = False

		Select Case OP
			Case "Q"
				OPAuth = Mid(Permission, 1, 3)
			Case "U"
				OPAuth = Mid(Permission, 4, 3)
			Case "D"
				OPAuth = Mid(Permission, 4, 3)
		End Select
		'other
		If Mid(OPAuth, 3, 1) = "1" Then
			OtAuth = True
			'其他使用者為授權為true...傳回true
			Return True
			Exit Function
		End If
		'group
		If Mid(OPAuth, 2, 1) = "1" Then
			GrAuth = True
		End If
		'creator
		If Mid(OPAuth, 1, 1) = "1" Then
			CrAuth = True
		End If

		'判斷是否為同一使用者
		If CreatorID.Trim = UserID.Trim Then
			If CrAuth = True Then
				Return True
				Exit Function
			End If
		End If

		'找出創造者的組

		Dim objQI As New UserInfoBO
		Dim CreatorDeptID As String
		Dim UserDeptID As String
		Dim fSameGroup As Boolean = False

		dt = objQI.QueryUserInfo(CreatorID)
		CreatorDeptID = CType(dt.Rows(0).Item("Dept"), String)

		dt = objQI.QueryUserInfo(UserID)
		UserDeptID = CType(dt.Rows(0).Item("Dept"), String)
		'判斷使用者與創造者是否為同一組
		If Trim(CreatorDeptID) = Trim(UserDeptID) Then
			fSameGroup = True
			If GrAuth = True Then
				Return True
				Exit Function
			End If
		Else
			fSameGroup = False
		End If

		'找出特別設定的權限
		Dim AuthMask As String
		Dim SAuth As String
		'群組


		dt = objCA.QuerySpecAuthContext(ObjID, RecID, "G", UserDeptID).Tables(0)
		If dt.Rows.Count > 0 Then
			AuthMask = CType(dt.Rows(0).Item("AuthMask"), String).Trim
			Select Case OP
				Case "Q"
					SAuth = Mid(AuthMask, 1, 1)
				Case "U"
					SAuth = Mid(AuthMask, 2, 1)
				Case "D"
					SAuth = Mid(AuthMask, 3, 1)
			End Select

			If SAuth = "1" Then
				Return True
				Exit Function
			End If
		End If

		dt = objCA.QuerySpecAuthContext(ObjID, RecID, "U", UserID).Tables(0)
		If dt.Rows.Count > 0 Then
			AuthMask = CType(dt.Rows(0).Item("AuthMask"), String)
			Select Case OP
				Case "Q"
					SAuth = Mid(AuthMask, 1, 1)
				Case "U"
					SAuth = Mid(AuthMask, 2, 1)
				Case "D"
					SAuth = Mid(AuthMask, 3, 1)
			End Select

			If SAuth = "1" Then
				Return True
				Exit Function
			End If
		End If

		Return False

	End Function

	Public Function QueryRecSpecAuthList(ByVal ObjID As String, ByVal RecID As String) As DataTable
		Dim objCA As New ContextAuthDAO
		Dim dt As DataTable
		dt = objCA.QueryPortal_ConAuth(ObjID, RecID).Tables(0)
		Return dt

	End Function


	Public Function QueryRecGenAuthority(ByVal ObjID As String, ByVal RecID As String) As DataTable
		Dim objCA As New ContextAuthDAO
		Dim dt As DataTable
		dt = objCA.QueryObjTableRec(ObjID, RecID).Tables(0)
		Return dt

	End Function


	Public Function UpdatePermission(ByVal ObjID As String, ByVal RecID As String, ByVal Permission As String) As Boolean
		Dim objCA As New ContextAuthDAO
		Dim flag As Boolean
		flag = objCA.UpdateObjTable(ObjID, RecID, Permission)
		Return flag
	End Function


	Public Function AddRecSpecAuthority(ByVal objid As String, ByVal recid As String, ByVal authType As String, ByVal authid As String, ByVal authmask As String) As Boolean
		Dim ca As New ContextAuthDAO
		Dim flag As Boolean
		flag = ca.InsertConAuth(objid, recid, authType, authid, authmask)
		Return True
	End Function

	Public Function DeleteSpecAuthority(ByVal itemID As Integer) As Boolean
		Dim ca As New ContextAuthDAO
		Dim flag As Boolean
		flag = ca.DeleteConAuth(itemID)
		Return flag
	End Function

End Class
