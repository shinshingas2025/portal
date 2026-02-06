Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class APSTBLDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APSTBL", myConnection)
			myConnection.Open()
			Dim myReader As System.Data.OracleClient.OracleDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					valResult = CInt(myReader.GetValue(0))
				Catch ex As System.InvalidCastException
					valResult = 0
				End Try
			End While
			myReader.Close()
			Return valResult
		End Function
		Public Overridable Sub DeleteEntity(ByVal jOB_ID As Integer, ByVal lABOR_ID As Integer)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("delete from APSTBL where JOB_ID=:pJOB_ID and LABOR_ID=:pLABOR_ID", myConnection)
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub InsertEntity(ByVal jOB_ID As Integer, ByVal lABOR_ID As Integer, ByVal fA_FALG As String, ByVal fA_DATE As Date, ByVal bIRTHDAY As Date, ByVal sEX As String, ByVal eDGR As String, ByVal dEPTCD As String, ByVal oCCUCD1 As String, ByVal oCCUCD2 As String, ByVal oCCUCD3 As String, ByVal wKPLCD1 As String, ByVal wKPLCD2 As String, ByVal wKPLCD3 As String, ByVal sALARY_M As String, ByVal sALARY As String, ByVal tRANDATE As Date, ByVal cLOSE_REASON As String, ByVal cLOSE_ROLE As String, ByVal cLOSE_USER_ID As String, ByVal wKPLZIP1 As String, ByVal wKPLZIP2 As String, ByVal wKPLZIP3 As String, ByVal cLOSE_RGSTN As String, ByVal dEPT_OTHER As String, ByVal dEPTCD2 As String, ByVal dEPT_OTHER2 As String, ByVal dEPTCD3 As String, ByVal dEPT_OTHER3 As String, ByVal eDGR_OTHER As String, ByVal oCCU_DESC1 As String, ByVal oCCU_DESC2 As String, ByVal oCCU_DESC3 As String, ByVal cJOB_NO1 As String, ByVal cJOB_NO2 As String, ByVal cJOB_NO3 As String, ByVal bUSI_ID1 As String, ByVal bUSI_ID2 As String, ByVal bUSI_ID3 As String, ByVal cLOSE_REASON_OTHER As String)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("insert into APSTBL ( JOB_ID,LABOR_ID,FA_FALG,FA_DATE,BIRTHDAY,SEX,EDGR,DEPTCD,OCCUCD1,OCCUCD2,OCCUCD3,WKPLCD1,WKPLCD2,WKPLCD3,SALARY_M,SALARY,TRANDATE,CLOSE_REASON,CLOSE_ROLE,CLOSE_USER_ID,WKPLZIP1,WKPLZIP2,WKPLZIP3,CLOSE_RGSTN,DEPT_OTHER,DEPTCD2,DEPT_OTHER2,DEPTCD3,DEPT_OTHER3,EDGR_OTHER,OCCU_DESC1,OCCU_DESC2,OCCU_DESC3,CJOB_NO1,CJOB_NO2,CJOB_NO3,BUSI_ID1,BUSI_ID2,BUSI_ID3,CLOSE_REASON_OTHER ) values ( :pJOB_ID,:pLABOR_ID,:pFA_FALG,:pFA_DATE,:pBIRTHDAY,:pSEX,:pEDGR,:pDEPTCD,:pOCCUCD1,:pOCCUCD2,:pOCCUCD3,:pWKPLCD1,:pWKPLCD2,:pWKPLCD3,:pSALARY_M,:pSALARY,:pTRANDATE,:pCLOSE_REASON,:pCLOSE_ROLE,:pCLOSE_USER_ID,:pWKPLZIP1,:pWKPLZIP2,:pWKPLZIP3,:pCLOSE_RGSTN,:pDEPT_OTHER,:pDEPTCD2,:pDEPT_OTHER2,:pDEPTCD3,:pDEPT_OTHER3,:pEDGR_OTHER,:pOCCU_DESC1,:pOCCU_DESC2,:pOCCU_DESC3,:pCJOB_NO1,:pCJOB_NO2,:pCJOB_NO3,:pBUSI_ID1,:pBUSI_ID2,:pBUSI_ID3,:pCLOSE_REASON_OTHER )", myConnection)
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pFA_FALG", System.Data.OracleClient.OracleType.VarChar, 1).Value = fA_FALG
			myCommand.Parameters.Add(":pFA_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fA_DATE
			myCommand.Parameters.Add(":pBIRTHDAY", System.Data.OracleClient.OracleType.DateTime, 8).Value = bIRTHDAY
			myCommand.Parameters.Add(":pSEX", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEX
			myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
			myCommand.Parameters.Add(":pDEPTCD", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD
			myCommand.Parameters.Add(":pOCCUCD1", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD1
			myCommand.Parameters.Add(":pOCCUCD2", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD2
			myCommand.Parameters.Add(":pOCCUCD3", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD3
			myCommand.Parameters.Add(":pWKPLCD1", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD1
			myCommand.Parameters.Add(":pWKPLCD2", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD2
			myCommand.Parameters.Add(":pWKPLCD3", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD3
			myCommand.Parameters.Add(":pSALARY_M", System.Data.OracleClient.OracleType.VarChar, 1).Value = sALARY_M
			myCommand.Parameters.Add(":pSALARY", System.Data.OracleClient.OracleType.VarChar, 6).Value = sALARY
			myCommand.Parameters.Add(":pTRANDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = tRANDATE
			myCommand.Parameters.Add(":pCLOSE_REASON", System.Data.OracleClient.OracleType.VarChar, 1).Value = cLOSE_REASON
			myCommand.Parameters.Add(":pCLOSE_ROLE", System.Data.OracleClient.OracleType.VarChar, 1).Value = cLOSE_ROLE
			myCommand.Parameters.Add(":pCLOSE_USER_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = cLOSE_USER_ID
			myCommand.Parameters.Add(":pWKPLZIP1", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP1
			myCommand.Parameters.Add(":pWKPLZIP2", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP2
			myCommand.Parameters.Add(":pWKPLZIP3", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP3
			myCommand.Parameters.Add(":pCLOSE_RGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = cLOSE_RGSTN
			myCommand.Parameters.Add(":pDEPT_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER
			myCommand.Parameters.Add(":pDEPTCD2", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD2
			myCommand.Parameters.Add(":pDEPT_OTHER2", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER2
			myCommand.Parameters.Add(":pDEPTCD3", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD3
			myCommand.Parameters.Add(":pDEPT_OTHER3", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER3
			myCommand.Parameters.Add(":pEDGR_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = eDGR_OTHER
			myCommand.Parameters.Add(":pOCCU_DESC1", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC1
			myCommand.Parameters.Add(":pOCCU_DESC2", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC2
			myCommand.Parameters.Add(":pOCCU_DESC3", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC3
			myCommand.Parameters.Add(":pCJOB_NO1", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO1
			myCommand.Parameters.Add(":pCJOB_NO2", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO2
			myCommand.Parameters.Add(":pCJOB_NO3", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO3
			myCommand.Parameters.Add(":pBUSI_ID1", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID1
			myCommand.Parameters.Add(":pBUSI_ID2", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID2
			myCommand.Parameters.Add(":pBUSI_ID3", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID3
			myCommand.Parameters.Add(":pCLOSE_REASON_OTHER", System.Data.OracleClient.OracleType.VarChar, 256).Value = cLOSE_REASON_OTHER
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub UpdateEntity(ByVal jOB_ID As Integer, ByVal lABOR_ID As Integer, ByVal fA_FALG As String, ByVal fA_DATE As Date, ByVal bIRTHDAY As Date, ByVal sEX As String, ByVal eDGR As String, ByVal dEPTCD As String, ByVal oCCUCD1 As String, ByVal oCCUCD2 As String, ByVal oCCUCD3 As String, ByVal wKPLCD1 As String, ByVal wKPLCD2 As String, ByVal wKPLCD3 As String, ByVal sALARY_M As String, ByVal sALARY As String, ByVal tRANDATE As Date, ByVal cLOSE_REASON As String, ByVal cLOSE_ROLE As String, ByVal cLOSE_USER_ID As String, ByVal wKPLZIP1 As String, ByVal wKPLZIP2 As String, ByVal wKPLZIP3 As String, ByVal cLOSE_RGSTN As String, ByVal dEPT_OTHER As String, ByVal dEPTCD2 As String, ByVal dEPT_OTHER2 As String, ByVal dEPTCD3 As String, ByVal dEPT_OTHER3 As String, ByVal eDGR_OTHER As String, ByVal oCCU_DESC1 As String, ByVal oCCU_DESC2 As String, ByVal oCCU_DESC3 As String, ByVal cJOB_NO1 As String, ByVal cJOB_NO2 As String, ByVal cJOB_NO3 As String, ByVal bUSI_ID1 As String, ByVal bUSI_ID2 As String, ByVal bUSI_ID3 As String, ByVal cLOSE_REASON_OTHER As String)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("update APSTBL set FA_FALG=:pFA_FALG,FA_DATE=:pFA_DATE,BIRTHDAY=:pBIRTHDAY,SEX=:pSEX,EDGR=:pEDGR,DEPTCD=:pDEPTCD,OCCUCD1=:pOCCUCD1,OCCUCD2=:pOCCUCD2,OCCUCD3=:pOCCUCD3,WKPLCD1=:pWKPLCD1,WKPLCD2=:pWKPLCD2,WKPLCD3=:pWKPLCD3,SALARY_M=:pSALARY_M,SALARY=:pSALARY,TRANDATE=:pTRANDATE,CLOSE_REASON=:pCLOSE_REASON,CLOSE_ROLE=:pCLOSE_ROLE,CLOSE_USER_ID=:pCLOSE_USER_ID,WKPLZIP1=:pWKPLZIP1,WKPLZIP2=:pWKPLZIP2,WKPLZIP3=:pWKPLZIP3,CLOSE_RGSTN=:pCLOSE_RGSTN,DEPT_OTHER=:pDEPT_OTHER,DEPTCD2=:pDEPTCD2,DEPT_OTHER2=:pDEPT_OTHER2,DEPTCD3=:pDEPTCD3,DEPT_OTHER3=:pDEPT_OTHER3,EDGR_OTHER=:pEDGR_OTHER,OCCU_DESC1=:pOCCU_DESC1,OCCU_DESC2=:pOCCU_DESC2,OCCU_DESC3=:pOCCU_DESC3,CJOB_NO1=:pCJOB_NO1,CJOB_NO2=:pCJOB_NO2,CJOB_NO3=:pCJOB_NO3,BUSI_ID1=:pBUSI_ID1,BUSI_ID2=:pBUSI_ID2,BUSI_ID3=:pBUSI_ID3,CLOSE_REASON_OTHER=:pCLOSE_REASON_OTHER where JOB_ID=:pJOB_ID and LABOR_ID=:pLABOR_ID", myConnection)
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pFA_FALG", System.Data.OracleClient.OracleType.VarChar, 1).Value = fA_FALG
			myCommand.Parameters.Add(":pFA_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fA_DATE
			myCommand.Parameters.Add(":pBIRTHDAY", System.Data.OracleClient.OracleType.DateTime, 8).Value = bIRTHDAY
			myCommand.Parameters.Add(":pSEX", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEX
			myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
			myCommand.Parameters.Add(":pDEPTCD", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD
			myCommand.Parameters.Add(":pOCCUCD1", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD1
			myCommand.Parameters.Add(":pOCCUCD2", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD2
			myCommand.Parameters.Add(":pOCCUCD3", System.Data.OracleClient.OracleType.VarChar, 6).Value = oCCUCD3
			myCommand.Parameters.Add(":pWKPLCD1", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD1
			myCommand.Parameters.Add(":pWKPLCD2", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD2
			myCommand.Parameters.Add(":pWKPLCD3", System.Data.OracleClient.OracleType.VarChar, 2).Value = wKPLCD3
			myCommand.Parameters.Add(":pSALARY_M", System.Data.OracleClient.OracleType.VarChar, 1).Value = sALARY_M
			myCommand.Parameters.Add(":pSALARY", System.Data.OracleClient.OracleType.VarChar, 6).Value = sALARY
			myCommand.Parameters.Add(":pTRANDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = tRANDATE
			myCommand.Parameters.Add(":pCLOSE_REASON", System.Data.OracleClient.OracleType.VarChar, 1).Value = cLOSE_REASON
			myCommand.Parameters.Add(":pCLOSE_ROLE", System.Data.OracleClient.OracleType.VarChar, 1).Value = cLOSE_ROLE
			myCommand.Parameters.Add(":pCLOSE_USER_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = cLOSE_USER_ID
			myCommand.Parameters.Add(":pWKPLZIP1", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP1
			myCommand.Parameters.Add(":pWKPLZIP2", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP2
			myCommand.Parameters.Add(":pWKPLZIP3", System.Data.OracleClient.OracleType.VarChar, 5).Value = wKPLZIP3
			myCommand.Parameters.Add(":pCLOSE_RGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = cLOSE_RGSTN
			myCommand.Parameters.Add(":pDEPT_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER
			myCommand.Parameters.Add(":pDEPTCD2", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD2
			myCommand.Parameters.Add(":pDEPT_OTHER2", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER2
			myCommand.Parameters.Add(":pDEPTCD3", System.Data.OracleClient.OracleType.VarChar, 6).Value = dEPTCD3
			myCommand.Parameters.Add(":pDEPT_OTHER3", System.Data.OracleClient.OracleType.VarChar, 128).Value = dEPT_OTHER3
			myCommand.Parameters.Add(":pEDGR_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = eDGR_OTHER
			myCommand.Parameters.Add(":pOCCU_DESC1", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC1
			myCommand.Parameters.Add(":pOCCU_DESC2", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC2
			myCommand.Parameters.Add(":pOCCU_DESC3", System.Data.OracleClient.OracleType.VarChar, 256).Value = oCCU_DESC3
			myCommand.Parameters.Add(":pCJOB_NO1", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO1
			myCommand.Parameters.Add(":pCJOB_NO2", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO2
			myCommand.Parameters.Add(":pCJOB_NO3", System.Data.OracleClient.OracleType.VarChar, 4).Value = cJOB_NO3
			myCommand.Parameters.Add(":pBUSI_ID1", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID1
			myCommand.Parameters.Add(":pBUSI_ID2", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID2
			myCommand.Parameters.Add(":pBUSI_ID3", System.Data.OracleClient.OracleType.VarChar, 5).Value = bUSI_ID3
			myCommand.Parameters.Add(":pCLOSE_REASON_OTHER", System.Data.OracleClient.OracleType.VarChar, 256).Value = cLOSE_REASON_OTHER
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace
