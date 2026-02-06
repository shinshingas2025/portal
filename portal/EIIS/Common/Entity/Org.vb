Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal

	Public Class OrgNode
		Inherits CommunityNode


	End Class


	Public Class OrgMaster
		Public Function InsertOrg(ByVal ONode As OrgNode) As String


		End Function

	End Class

	Public Class OrgMasterDAO

		Public Function Insert(ByVal ONode As OrgNode) As String

		End Function

		Public Function Update(ByVal ONode As OrgNode) As Integer

		End Function

		Public Function Delete(ByVal ONode As OrgNode) As Integer

		End Function


		Public Function Query(ByVal ONode As OrgNode) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Site where PortalId=@PortalId order by ItemID desc", myConnection)

			myCommand.Parameters.Add("@objID", SqlDbType.Int, 4).Value = ONode.objID
			myCommand.Parameters.Add("@objName", SqlDbType.NVarChar, 200).Value = ONode.objName
			myCommand.Parameters.Add("@objValue", SqlDbType.NVarChar, 200).Value = ONode.objValue
			myCommand.Parameters.Add("@PID", SqlDbType.Int, 4).Value = ONode.PID
			myCommand.Parameters.Add("@SEQNO", SqlDbType.Int, 4).Value = ONode.SEQNO
			myCommand.Parameters.Add("@srcName", SqlDbType.Int, 4).Value = ONode.srcName
			myCommand.Parameters.Add("@state", SqlDbType.Int, 4).Value = ONode.state

			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet

		End Function

	End Class
End Namespace