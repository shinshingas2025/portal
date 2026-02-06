Imports System
Imports System.IO
Imports System.Math
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.Module
	Public Class AuditSystemUtility
		Public Function QueryPermissionFilter(ByVal myDataSet As DataSet, ByVal myTableName As String, ByVal myUserID As String) As DataSet
			Dim myAuthorityBO As New ContextAuthBO
			Dim myOutputDataSet As New DataSet
			Dim myEntityID As String
			Dim myItemArray() As Object
			Dim i As Integer
			Dim myCheckResult As Boolean

			If (Not (myDataSet Is Nothing)) And (myTableName.Trim.Length > 0) And (myUserID.Trim.Length > 0) Then
				myOutputDataSet = myDataSet.Clone
				If myDataSet.Tables(0).Rows.Count > 0 Then

					For i = 0 To myDataSet.Tables(0).Rows.Count - 1
						myEntityID = CType(myDataSet.Tables(0).Rows(i).Item("EntityID"), String)

						If myEntityID.Trim.Length > 0 Then
							myCheckResult = myAuthorityBO.CheckPurview(myTableName.Trim, myEntityID, myUserID.Trim, "Q")
							If myCheckResult = True Then
								myItemArray = myDataSet.Tables(0).Rows(i).ItemArray()
								myOutputDataSet.Tables(0).Rows.Add(myItemArray)
							End If
						Else
							'exception:entity id is empty
						End If
					Next
				End If
			Else
				'exception:input dataset is null or table name is empty or user id is empty
			End If
			Return myOutputDataSet
		End Function
		Public Function QueryPermissionFilter(ByVal myDataSet As DataSet, ByVal myTableName As String, ByVal myUserID As String, ByVal rowCount As Integer) As DataSet
			Dim myOutputDataSet As New DataSet
			Dim myItemArray() As Object
			Dim i As Integer

			If (Not (myDataSet Is Nothing)) And (myTableName.Trim.Length > 0) And (myUserID.Trim.Length > 0) And (rowCount > 0) Then
				myOutputDataSet = myDataSet.Clone
				If myDataSet.Tables(0).Rows.Count > 0 Then
					myDataSet = QueryPermissionFilter(myDataSet, myTableName.Trim, myUserID.Trim)

					If myDataSet.Tables(0).Rows.Count < rowCount Then
						rowCount = myDataSet.Tables(0).Rows.Count
					End If
					For i = 0 To rowCount - 1
						myItemArray = myDataSet.Tables(0).Rows(i).ItemArray()
						myOutputDataSet.Tables(0).Rows.Add(myItemArray)
					Next
				End If
			Else
				'exception:input dataset is null or table name is empty or user id is empty
			End If
			Return myOutputDataSet
		End Function
	End Class
End Namespace
