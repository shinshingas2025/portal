Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class APLTBLDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL", myConnection)
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
		Public Overridable Sub DeleteEntity(ByVal lABOR_ID As Integer)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("delete from APLTBL where LABOR_ID=:pLABOR_ID", myConnection)
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub InsertEntity(ByVal lABOR_ID As Integer, ByVal nAME As String, ByVal iDNO As String, ByVal bIRTH As Date, ByVal sEX As String, ByVal mARRI As String, ByVal aDDR_CITY As String, ByVal aDDR_ZIP As String, ByVal aDDR As String, ByVal tEL1 As String, ByVal tEL2 As String, ByVal e_MAIL As String, ByVal pASSWD As String, ByVal mOBILE As String, ByVal uSER_IDENFITY As String, ByVal rEVIEW_RGSTN As String, ByVal rEVIEW_ID As String, ByVal rEVIEW_DATE As Date, ByVal rEVIEW_STATE As String, ByVal dEL_STATE As String, ByVal fAX As String, ByVal jOB_CENTER_ID As String, ByVal cONTACT As String, ByVal fIRSTDATE As Date, ByVal e_MAIL_FLAG As String, ByVal dATASOURCE As String, ByVal nOTE As String, ByVal iMPORT_DATE As Date, ByVal cONTACT_OTHER As String, ByVal lAST_LOGIN As Date, ByVal aPPROVE As String, ByVal aPPROVE_OTHER As String, ByVal sEND_ORG1 As String, ByVal sEND_ORG1_DATE As Date, ByVal gOV_LOGIN As Date)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("insert into APLTBL ( LABOR_ID,NAME,IDNO,BIRTH,SEX,MARRI,ADDR_CITY,ADDR_ZIP,ADDR,TEL1,TEL2,E_MAIL,PASSWD,MOBILE,USER_IDENFITY,REVIEW_RGSTN,REVIEW_ID,REVIEW_DATE,REVIEW_STATE,DEL_STATE,FAX,JOB_CENTER_ID,CONTACT,FIRSTDATE,E_MAIL_FLAG,DATASOURCE,NOTE,IMPORT_DATE,CONTACT_OTHER,LAST_LOGIN,APPROVE,APPROVE_OTHER,SEND_ORG1,SEND_ORG1_DATE,GOV_LOGIN ) values ( :pLABOR_ID,:pNAME,:pIDNO,:pBIRTH,:pSEX,:pMARRI,:pADDR_CITY,:pADDR_ZIP,:pADDR,:pTEL1,:pTEL2,:pE_MAIL,:pPASSWD,:pMOBILE,:pUSER_IDENFITY,:pREVIEW_RGSTN,:pREVIEW_ID,:pREVIEW_DATE,:pREVIEW_STATE,:pDEL_STATE,:pFAX,:pJOB_CENTER_ID,:pCONTACT,:pFIRSTDATE,:pE_MAIL_FLAG,:pDATASOURCE,:pNOTE,:pIMPORT_DATE,:pCONTACT_OTHER,:pLAST_LOGIN,:pAPPROVE,:pAPPROVE_OTHER,:pSEND_ORG1,:pSEND_ORG1_DATE,:pGOV_LOGIN )", myConnection)
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 4).Value = lABOR_ID
			myCommand.Parameters.Add(":pNAME", System.Data.OracleClient.OracleType.VarChar, 16).Value = nAME
			myCommand.Parameters.Add(":pIDNO", System.Data.OracleClient.OracleType.VarChar, 10).Value = iDNO
			myCommand.Parameters.Add(":pBIRTH", System.Data.OracleClient.OracleType.DateTime, 8).Value = bIRTH
			myCommand.Parameters.Add(":pSEX", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEX
			myCommand.Parameters.Add(":pMARRI", System.Data.OracleClient.OracleType.VarChar, 1).Value = mARRI
			myCommand.Parameters.Add(":pADDR_CITY", System.Data.OracleClient.OracleType.VarChar, 2).Value = aDDR_CITY
			myCommand.Parameters.Add(":pADDR_ZIP", System.Data.OracleClient.OracleType.VarChar, 3).Value = aDDR_ZIP
			myCommand.Parameters.Add(":pADDR", System.Data.OracleClient.OracleType.VarChar, 128).Value = aDDR
			myCommand.Parameters.Add(":pTEL1", System.Data.OracleClient.OracleType.VarChar, 20).Value = tEL1
			myCommand.Parameters.Add(":pTEL2", System.Data.OracleClient.OracleType.VarChar, 20).Value = tEL2
			myCommand.Parameters.Add(":pE_MAIL", System.Data.OracleClient.OracleType.VarChar, 64).Value = e_MAIL
			myCommand.Parameters.Add(":pPASSWD", System.Data.OracleClient.OracleType.VarChar, 10).Value = pASSWD
			myCommand.Parameters.Add(":pMOBILE", System.Data.OracleClient.OracleType.VarChar, 20).Value = mOBILE
			myCommand.Parameters.Add(":pUSER_IDENFITY", System.Data.OracleClient.OracleType.VarChar, 1).Value = uSER_IDENFITY
			myCommand.Parameters.Add(":pREVIEW_RGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = rEVIEW_RGSTN
			myCommand.Parameters.Add(":pREVIEW_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = rEVIEW_ID
			myCommand.Parameters.Add(":pREVIEW_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = rEVIEW_DATE
			myCommand.Parameters.Add(":pREVIEW_STATE", System.Data.OracleClient.OracleType.VarChar, 8).Value = rEVIEW_STATE
			myCommand.Parameters.Add(":pDEL_STATE", System.Data.OracleClient.OracleType.VarChar, 1).Value = dEL_STATE
			myCommand.Parameters.Add(":pFAX", System.Data.OracleClient.OracleType.VarChar, 20).Value = fAX
			myCommand.Parameters.Add(":pJOB_CENTER_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = jOB_CENTER_ID
			myCommand.Parameters.Add(":pCONTACT", System.Data.OracleClient.OracleType.VarChar, 6).Value = cONTACT
			myCommand.Parameters.Add(":pFIRSTDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fIRSTDATE
			myCommand.Parameters.Add(":pE_MAIL_FLAG", System.Data.OracleClient.OracleType.VarChar, 1).Value = e_MAIL_FLAG
			myCommand.Parameters.Add(":pDATASOURCE", System.Data.OracleClient.OracleType.VarChar, 6).Value = dATASOURCE
			myCommand.Parameters.Add(":pNOTE", System.Data.OracleClient.OracleType.VarChar, 200).Value = nOTE
			myCommand.Parameters.Add(":pIMPORT_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = iMPORT_DATE
			myCommand.Parameters.Add(":pCONTACT_OTHER", System.Data.OracleClient.OracleType.VarChar, 6).Value = cONTACT_OTHER
			myCommand.Parameters.Add(":pLAST_LOGIN", System.Data.OracleClient.OracleType.DateTime, 8).Value = lAST_LOGIN
			myCommand.Parameters.Add(":pAPPROVE", System.Data.OracleClient.OracleType.VarChar, 1).Value = aPPROVE
			myCommand.Parameters.Add(":pAPPROVE_OTHER", System.Data.OracleClient.OracleType.VarChar, 100).Value = aPPROVE_OTHER
			myCommand.Parameters.Add(":pSEND_ORG1", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEND_ORG1
			myCommand.Parameters.Add(":pSEND_ORG1_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = sEND_ORG1_DATE
			myCommand.Parameters.Add(":pGOV_LOGIN", System.Data.OracleClient.OracleType.DateTime, 8).Value = gOV_LOGIN
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub UpdateEntity(ByVal lABOR_ID As Integer, ByVal nAME As String, ByVal iDNO As String, ByVal bIRTH As Date, ByVal sEX As String, ByVal mARRI As String, ByVal aDDR_CITY As String, ByVal aDDR_ZIP As String, ByVal aDDR As String, ByVal tEL1 As String, ByVal tEL2 As String, ByVal e_MAIL As String, ByVal pASSWD As String, ByVal mOBILE As String, ByVal uSER_IDENFITY As String, ByVal rEVIEW_RGSTN As String, ByVal rEVIEW_ID As String, ByVal rEVIEW_DATE As Date, ByVal rEVIEW_STATE As String, ByVal dEL_STATE As String, ByVal fAX As String, ByVal jOB_CENTER_ID As String, ByVal cONTACT As String, ByVal fIRSTDATE As Date, ByVal e_MAIL_FLAG As String, ByVal dATASOURCE As String, ByVal nOTE As String, ByVal iMPORT_DATE As Date, ByVal cONTACT_OTHER As String, ByVal lAST_LOGIN As Date, ByVal aPPROVE As String, ByVal aPPROVE_OTHER As String, ByVal sEND_ORG1 As String, ByVal sEND_ORG1_DATE As Date, ByVal gOV_LOGIN As Date)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("update APLTBL set NAME=:pNAME,IDNO=:pIDNO,BIRTH=:pBIRTH,SEX=:pSEX,MARRI=:pMARRI,ADDR_CITY=:pADDR_CITY,ADDR_ZIP=:pADDR_ZIP,ADDR=:pADDR,TEL1=:pTEL1,TEL2=:pTEL2,E_MAIL=:pE_MAIL,PASSWD=:pPASSWD,MOBILE=:pMOBILE,USER_IDENFITY=:pUSER_IDENFITY,REVIEW_RGSTN=:pREVIEW_RGSTN,REVIEW_ID=:pREVIEW_ID,REVIEW_DATE=:pREVIEW_DATE,REVIEW_STATE=:pREVIEW_STATE,DEL_STATE=:pDEL_STATE,FAX=:pFAX,JOB_CENTER_ID=:pJOB_CENTER_ID,CONTACT=:pCONTACT,FIRSTDATE=:pFIRSTDATE,E_MAIL_FLAG=:pE_MAIL_FLAG,DATASOURCE=:pDATASOURCE,NOTE=:pNOTE,IMPORT_DATE=:pIMPORT_DATE,CONTACT_OTHER=:pCONTACT_OTHER,LAST_LOGIN=:pLAST_LOGIN,APPROVE=:pAPPROVE,APPROVE_OTHER=:pAPPROVE_OTHER,SEND_ORG1=:pSEND_ORG1,SEND_ORG1_DATE=:pSEND_ORG1_DATE,GOV_LOGIN=:pGOV_LOGIN where LABOR_ID=:pLABOR_ID", myConnection)
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pNAME", System.Data.OracleClient.OracleType.VarChar, 16).Value = nAME
			myCommand.Parameters.Add(":pIDNO", System.Data.OracleClient.OracleType.VarChar, 10).Value = iDNO
			myCommand.Parameters.Add(":pBIRTH", System.Data.OracleClient.OracleType.DateTime, 8).Value = bIRTH
			myCommand.Parameters.Add(":pSEX", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEX
			myCommand.Parameters.Add(":pMARRI", System.Data.OracleClient.OracleType.VarChar, 1).Value = mARRI
			myCommand.Parameters.Add(":pADDR_CITY", System.Data.OracleClient.OracleType.VarChar, 2).Value = aDDR_CITY
			myCommand.Parameters.Add(":pADDR_ZIP", System.Data.OracleClient.OracleType.VarChar, 3).Value = aDDR_ZIP
			myCommand.Parameters.Add(":pADDR", System.Data.OracleClient.OracleType.VarChar, 128).Value = aDDR
			myCommand.Parameters.Add(":pTEL1", System.Data.OracleClient.OracleType.VarChar, 20).Value = tEL1
			myCommand.Parameters.Add(":pTEL2", System.Data.OracleClient.OracleType.VarChar, 20).Value = tEL2
			myCommand.Parameters.Add(":pE_MAIL", System.Data.OracleClient.OracleType.VarChar, 64).Value = e_MAIL
			myCommand.Parameters.Add(":pPASSWD", System.Data.OracleClient.OracleType.VarChar, 10).Value = pASSWD
			myCommand.Parameters.Add(":pMOBILE", System.Data.OracleClient.OracleType.VarChar, 20).Value = mOBILE
			myCommand.Parameters.Add(":pUSER_IDENFITY", System.Data.OracleClient.OracleType.VarChar, 1).Value = uSER_IDENFITY
			myCommand.Parameters.Add(":pREVIEW_RGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = rEVIEW_RGSTN
			myCommand.Parameters.Add(":pREVIEW_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = rEVIEW_ID
			myCommand.Parameters.Add(":pREVIEW_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = rEVIEW_DATE
			myCommand.Parameters.Add(":pREVIEW_STATE", System.Data.OracleClient.OracleType.VarChar, 8).Value = rEVIEW_STATE
			myCommand.Parameters.Add(":pDEL_STATE", System.Data.OracleClient.OracleType.VarChar, 1).Value = dEL_STATE
			myCommand.Parameters.Add(":pFAX", System.Data.OracleClient.OracleType.VarChar, 20).Value = fAX
			myCommand.Parameters.Add(":pJOB_CENTER_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = jOB_CENTER_ID
			myCommand.Parameters.Add(":pCONTACT", System.Data.OracleClient.OracleType.VarChar, 6).Value = cONTACT
			myCommand.Parameters.Add(":pFIRSTDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fIRSTDATE
			myCommand.Parameters.Add(":pE_MAIL_FLAG", System.Data.OracleClient.OracleType.VarChar, 1).Value = e_MAIL_FLAG
			myCommand.Parameters.Add(":pDATASOURCE", System.Data.OracleClient.OracleType.VarChar, 6).Value = dATASOURCE
			myCommand.Parameters.Add(":pNOTE", System.Data.OracleClient.OracleType.VarChar, 200).Value = nOTE
			myCommand.Parameters.Add(":pIMPORT_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = iMPORT_DATE
			myCommand.Parameters.Add(":pCONTACT_OTHER", System.Data.OracleClient.OracleType.VarChar, 6).Value = cONTACT_OTHER
			myCommand.Parameters.Add(":pLAST_LOGIN", System.Data.OracleClient.OracleType.DateTime, 8).Value = lAST_LOGIN
			myCommand.Parameters.Add(":pAPPROVE", System.Data.OracleClient.OracleType.VarChar, 1).Value = aPPROVE
			myCommand.Parameters.Add(":pAPPROVE_OTHER", System.Data.OracleClient.OracleType.VarChar, 100).Value = aPPROVE_OTHER
			myCommand.Parameters.Add(":pSEND_ORG1", System.Data.OracleClient.OracleType.VarChar, 1).Value = sEND_ORG1
			myCommand.Parameters.Add(":pSEND_ORG1_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = sEND_ORG1_DATE
			myCommand.Parameters.Add(":pGOV_LOGIN", System.Data.OracleClient.OracleType.DateTime, 8).Value = gOV_LOGIN
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace
