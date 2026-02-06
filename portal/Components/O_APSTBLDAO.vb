Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class O_APSTBLDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from O_APSTBL", myConnection)
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
		Public Overridable Sub DeleteEntity(ByVal lABOR_ID As Integer, ByVal jOB_ID As Integer)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("delete from O_APSTBL where LABOR_ID=:pLABOR_ID and JOB_ID=:pJOB_ID", myConnection)
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub InsertEntity(ByVal jOB_ID As Integer, ByVal lABOR_ID As Integer, ByVal rGSTN As String, ByVal uSER_ID As String, ByVal rECNO As String, ByVal fIRSTDATE As Date, ByVal rGDATE As Date, ByVal lOOK_TYPE As String, ByVal nET As String, ByVal sOLDER As String, ByVal gRADU As String, ByVal sCHOOL As String, ByVal wORK_TIME As String, ByVal pART_TIME As String, ByVal tRANNING As String, ByVal aBILITY1 As String, ByVal aBILITY2 As String, ByVal aBILITY3 As String, ByVal eXPCD1 As String, ByVal eXPYM1 As String, ByVal eXPCD2 As String, ByVal eXPYM2 As String, ByVal dRI As String, ByVal tECHCD1 As String, ByVal tECHLV1 As String, ByVal tECHCD2 As String, ByVal tECHLV2 As String, ByVal iNDIVIDUAL As String, ByVal fORLNG As String, ByVal fORLNG_OTH As String, ByVal rESOU As String, ByVal dISABLED_CD As String, ByVal dISABLED_LABEL As String, ByVal iF_COMMUTE_TIME As String, ByVal jOIN_JOB As String, ByVal jOB_TYPE1 As String, ByVal jOB_TYPE2 As String, ByVal jOB_TYPE3 As String, ByVal jOB_CLASS1 As String, ByVal jOB_CLASS2 As String, ByVal jOB_CLASS3 As String, ByVal iF_USE_COMPUTER As String, ByVal uSE_POWER As String, ByVal uSE_OTHER As String, ByVal iF_ECONOMY_STRESS As String, ByVal sTRESS_TYPE As String, ByVal sTRESS_OTHER As String, ByVal jOB_LOCATION As String, ByVal lEAVE_DATE As Date, ByVal lEAVE_LONG As Integer, ByVal bEFORE_MONEY As Integer, ByVal uSER_IDENTITY As String, ByVal eXPWORK1 As String, ByVal eXPWORK2 As String, ByVal oNESELF As String, ByVal tECH_OTHER As String, ByVal sCHOOL_ID As String, ByVal sCHOOL_ID2 As String, ByVal sCHOOL2 As String, ByVal sCHOOL_ID3 As String, ByVal sCHOOL3 As String, ByVal gRADU2 As String, ByVal gRADU_YEAR2 As String, ByVal gRADU3 As String, ByVal gRADU_YEAR3 As String, ByVal gRADU_YEAR As String, ByVal iN_JOB As String, ByVal wISH_JOB_TYPE As String, ByVal wISH_JOB_DATE As Date, ByVal cOLLEGE_GRADU_YEAR As Integer, ByVal hIGH_GRADU_YEAR As Integer, ByVal jOB_MONTHS As Integer, ByVal cASE_SOURCE As String, ByVal cASE_OTHER As String, ByVal oTHER_DETAIL As String)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("insert into O_APSTBL ( JOB_ID,LABOR_ID,RGSTN,USER_ID,RECNO,FIRSTDATE,RGDATE,LOOK_TYPE,NET,SOLDER,GRADU,SCHOOL,WORK_TIME,PART_TIME,TRANNING,ABILITY1,ABILITY2,ABILITY3,EXPCD1,EXPYM1,EXPCD2,EXPYM2,DRI,TECHCD1,TECHLV1,TECHCD2,TECHLV2,INDIVIDUAL,FORLNG,FORLNG_OTH,RESOU,DISABLED_CD,DISABLED_LABEL,IF_COMMUTE_TIME,JOIN_JOB,JOB_TYPE1,JOB_TYPE2,JOB_TYPE3,JOB_CLASS1,JOB_CLASS2,JOB_CLASS3,IF_USE_COMPUTER,USE_POWER,USE_OTHER,IF_ECONOMY_STRESS,STRESS_TYPE,STRESS_OTHER,JOB_LOCATION,LEAVE_DATE,LEAVE_LONG,BEFORE_MONEY,USER_IDENTITY,EXPWORK1,EXPWORK2,ONESELF,TECH_OTHER,SCHOOL_ID,SCHOOL_ID2,SCHOOL2,SCHOOL_ID3,SCHOOL3,GRADU2,GRADU_YEAR2,GRADU3,GRADU_YEAR3,GRADU_YEAR,IN_JOB,WISH_JOB_TYPE,WISH_JOB_DATE,COLLEGE_GRADU_YEAR,HIGH_GRADU_YEAR,JOB_MONTHS,CASE_SOURCE,CASE_OTHER,OTHER_DETAIL ) values ( :pJOB_ID,:pLABOR_ID,:pRGSTN,:pUSER_ID,:pRECNO,:pFIRSTDATE,:pRGDATE,:pLOOK_TYPE,:pNET,:pSOLDER,:pGRADU,:pSCHOOL,:pWORK_TIME,:pPART_TIME,:pTRANNING,:pABILITY1,:pABILITY2,:pABILITY3,:pEXPCD1,:pEXPYM1,:pEXPCD2,:pEXPYM2,:pDRI,:pTECHCD1,:pTECHLV1,:pTECHCD2,:pTECHLV2,:pINDIVIDUAL,:pFORLNG,:pFORLNG_OTH,:pRESOU,:pDISABLED_CD,:pDISABLED_LABEL,:pIF_COMMUTE_TIME,:pJOIN_JOB,:pJOB_TYPE1,:pJOB_TYPE2,:pJOB_TYPE3,:pJOB_CLASS1,:pJOB_CLASS2,:pJOB_CLASS3,:pIF_USE_COMPUTER,:pUSE_POWER,:pUSE_OTHER,:pIF_ECONOMY_STRESS,:pSTRESS_TYPE,:pSTRESS_OTHER,:pJOB_LOCATION,:pLEAVE_DATE,:pLEAVE_LONG,:pBEFORE_MONEY,:pUSER_IDENTITY,:pEXPWORK1,:pEXPWORK2,:pONESELF,:pTECH_OTHER,:pSCHOOL_ID,:pSCHOOL_ID2,:pSCHOOL2,:pSCHOOL_ID3,:pSCHOOL3,:pGRADU2,:pGRADU_YEAR2,:pGRADU3,:pGRADU_YEAR3,:pGRADU_YEAR,:pIN_JOB,:pWISH_JOB_TYPE,:pWISH_JOB_DATE,:pCOLLEGE_GRADU_YEAR,:pHIGH_GRADU_YEAR,:pJOB_MONTHS,:pCASE_SOURCE,:pCASE_OTHER,:pOTHER_DETAIL )", myConnection)
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pRGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = rGSTN
			myCommand.Parameters.Add(":pUSER_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = uSER_ID
			myCommand.Parameters.Add(":pRECNO", System.Data.OracleClient.OracleType.VarChar, 18).Value = rECNO
			myCommand.Parameters.Add(":pFIRSTDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fIRSTDATE
			myCommand.Parameters.Add(":pRGDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = rGDATE
			myCommand.Parameters.Add(":pLOOK_TYPE", System.Data.OracleClient.OracleType.VarChar, 1).Value = lOOK_TYPE
			myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = nET
			myCommand.Parameters.Add(":pSOLDER", System.Data.OracleClient.OracleType.VarChar, 1).Value = sOLDER
			myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
			myCommand.Parameters.Add(":pSCHOOL", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL
			myCommand.Parameters.Add(":pWORK_TIME", System.Data.OracleClient.OracleType.VarChar, 7).Value = wORK_TIME
			myCommand.Parameters.Add(":pPART_TIME", System.Data.OracleClient.OracleType.VarChar, 8).Value = pART_TIME
			myCommand.Parameters.Add(":pTRANNING", System.Data.OracleClient.OracleType.VarChar, 1).Value = tRANNING
			myCommand.Parameters.Add(":pABILITY1", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY1
			myCommand.Parameters.Add(":pABILITY2", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY2
			myCommand.Parameters.Add(":pABILITY3", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY3
			myCommand.Parameters.Add(":pEXPCD1", System.Data.OracleClient.OracleType.VarChar, 4).Value = eXPCD1
			myCommand.Parameters.Add(":pEXPYM1", System.Data.OracleClient.OracleType.VarChar, 64).Value = eXPYM1
			myCommand.Parameters.Add(":pEXPCD2", System.Data.OracleClient.OracleType.VarChar, 4).Value = eXPCD2
			myCommand.Parameters.Add(":pEXPYM2", System.Data.OracleClient.OracleType.VarChar, 64).Value = eXPYM2
			myCommand.Parameters.Add(":pDRI", System.Data.OracleClient.OracleType.VarChar, 2).Value = dRI
			myCommand.Parameters.Add(":pTECHCD1", System.Data.OracleClient.OracleType.VarChar, 5).Value = tECHCD1
			myCommand.Parameters.Add(":pTECHLV1", System.Data.OracleClient.OracleType.VarChar, 1).Value = tECHLV1
			myCommand.Parameters.Add(":pTECHCD2", System.Data.OracleClient.OracleType.VarChar, 5).Value = tECHCD2
			myCommand.Parameters.Add(":pTECHLV2", System.Data.OracleClient.OracleType.VarChar, 1).Value = tECHLV2
			myCommand.Parameters.Add(":pINDIVIDUAL", System.Data.OracleClient.OracleType.VarChar, 1).Value = iNDIVIDUAL
			myCommand.Parameters.Add(":pFORLNG", System.Data.OracleClient.OracleType.VarChar, 5).Value = fORLNG
			myCommand.Parameters.Add(":pFORLNG_OTH", System.Data.OracleClient.OracleType.VarChar, 20).Value = fORLNG_OTH
			myCommand.Parameters.Add(":pRESOU", System.Data.OracleClient.OracleType.VarChar, 8).Value = rESOU
			myCommand.Parameters.Add(":pDISABLED_CD", System.Data.OracleClient.OracleType.VarChar, 1).Value = dISABLED_CD
			myCommand.Parameters.Add(":pDISABLED_LABEL", System.Data.OracleClient.OracleType.VarChar, 1).Value = dISABLED_LABEL
			myCommand.Parameters.Add(":pIF_COMMUTE_TIME", System.Data.OracleClient.OracleType.VarChar, 4).Value = iF_COMMUTE_TIME
			myCommand.Parameters.Add(":pJOIN_JOB", System.Data.OracleClient.OracleType.VarChar, 1).Value = jOIN_JOB
			myCommand.Parameters.Add(":pJOB_TYPE1", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE1
			myCommand.Parameters.Add(":pJOB_TYPE2", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE2
			myCommand.Parameters.Add(":pJOB_TYPE3", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE3
			myCommand.Parameters.Add(":pJOB_CLASS1", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS1
			myCommand.Parameters.Add(":pJOB_CLASS2", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS2
			myCommand.Parameters.Add(":pJOB_CLASS3", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS3
			myCommand.Parameters.Add(":pIF_USE_COMPUTER", System.Data.OracleClient.OracleType.VarChar, 1).Value = iF_USE_COMPUTER
			myCommand.Parameters.Add(":pUSE_POWER", System.Data.OracleClient.OracleType.VarChar, 7).Value = uSE_POWER
			myCommand.Parameters.Add(":pUSE_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = uSE_OTHER
			myCommand.Parameters.Add(":pIF_ECONOMY_STRESS", System.Data.OracleClient.OracleType.VarChar, 1).Value = iF_ECONOMY_STRESS
			myCommand.Parameters.Add(":pSTRESS_TYPE", System.Data.OracleClient.OracleType.VarChar, 4).Value = sTRESS_TYPE
			myCommand.Parameters.Add(":pSTRESS_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = sTRESS_OTHER
			myCommand.Parameters.Add(":pJOB_LOCATION", System.Data.OracleClient.OracleType.VarChar, 60).Value = jOB_LOCATION
			myCommand.Parameters.Add(":pLEAVE_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = lEAVE_DATE
			myCommand.Parameters.Add(":pLEAVE_LONG", System.Data.OracleClient.OracleType.Number, 8).Value = lEAVE_LONG
			myCommand.Parameters.Add(":pBEFORE_MONEY", System.Data.OracleClient.OracleType.Number, 8).Value = bEFORE_MONEY
			myCommand.Parameters.Add(":pUSER_IDENTITY", System.Data.OracleClient.OracleType.VarChar, 1).Value = uSER_IDENTITY
			myCommand.Parameters.Add(":pEXPWORK1", System.Data.OracleClient.OracleType.VarChar, 20).Value = eXPWORK1
			myCommand.Parameters.Add(":pEXPWORK2", System.Data.OracleClient.OracleType.VarChar, 20).Value = eXPWORK2
			myCommand.Parameters.Add(":pONESELF", System.Data.OracleClient.OracleType.VarChar, 1).Value = oNESELF
			myCommand.Parameters.Add(":pTECH_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = tECH_OTHER
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID
			myCommand.Parameters.Add(":pSCHOOL_ID2", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID2
			myCommand.Parameters.Add(":pSCHOOL2", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL2
			myCommand.Parameters.Add(":pSCHOOL_ID3", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID3
			myCommand.Parameters.Add(":pSCHOOL3", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL3
			myCommand.Parameters.Add(":pGRADU2", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU2
			myCommand.Parameters.Add(":pGRADU_YEAR2", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR2
			myCommand.Parameters.Add(":pGRADU3", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU3
			myCommand.Parameters.Add(":pGRADU_YEAR3", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR3
			myCommand.Parameters.Add(":pGRADU_YEAR", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR
			myCommand.Parameters.Add(":pIN_JOB", System.Data.OracleClient.OracleType.VarChar, 1).Value = iN_JOB
			myCommand.Parameters.Add(":pWISH_JOB_TYPE", System.Data.OracleClient.OracleType.VarChar, 1).Value = wISH_JOB_TYPE
			myCommand.Parameters.Add(":pWISH_JOB_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = wISH_JOB_DATE
			myCommand.Parameters.Add(":pCOLLEGE_GRADU_YEAR", System.Data.OracleClient.OracleType.Number, 4).Value = cOLLEGE_GRADU_YEAR
			myCommand.Parameters.Add(":pHIGH_GRADU_YEAR", System.Data.OracleClient.OracleType.Number, 4).Value = hIGH_GRADU_YEAR
			myCommand.Parameters.Add(":pJOB_MONTHS", System.Data.OracleClient.OracleType.Number, 4).Value = jOB_MONTHS
			myCommand.Parameters.Add(":pCASE_SOURCE", System.Data.OracleClient.OracleType.VarChar, 1).Value = cASE_SOURCE
			myCommand.Parameters.Add(":pCASE_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = cASE_OTHER
			myCommand.Parameters.Add(":pOTHER_DETAIL", System.Data.OracleClient.OracleType.VarChar, 128).Value = oTHER_DETAIL
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Sub UpdateEntity(ByVal jOB_ID As Integer, ByVal lABOR_ID As Integer, ByVal rGSTN As String, ByVal uSER_ID As String, ByVal rECNO As String, ByVal fIRSTDATE As Date, ByVal rGDATE As Date, ByVal lOOK_TYPE As String, ByVal nET As String, ByVal sOLDER As String, ByVal gRADU As String, ByVal sCHOOL As String, ByVal wORK_TIME As String, ByVal pART_TIME As String, ByVal tRANNING As String, ByVal aBILITY1 As String, ByVal aBILITY2 As String, ByVal aBILITY3 As String, ByVal eXPCD1 As String, ByVal eXPYM1 As String, ByVal eXPCD2 As String, ByVal eXPYM2 As String, ByVal dRI As String, ByVal tECHCD1 As String, ByVal tECHLV1 As String, ByVal tECHCD2 As String, ByVal tECHLV2 As String, ByVal iNDIVIDUAL As String, ByVal fORLNG As String, ByVal fORLNG_OTH As String, ByVal rESOU As String, ByVal dISABLED_CD As String, ByVal dISABLED_LABEL As String, ByVal iF_COMMUTE_TIME As String, ByVal jOIN_JOB As String, ByVal jOB_TYPE1 As String, ByVal jOB_TYPE2 As String, ByVal jOB_TYPE3 As String, ByVal jOB_CLASS1 As String, ByVal jOB_CLASS2 As String, ByVal jOB_CLASS3 As String, ByVal iF_USE_COMPUTER As String, ByVal uSE_POWER As String, ByVal uSE_OTHER As String, ByVal iF_ECONOMY_STRESS As String, ByVal sTRESS_TYPE As String, ByVal sTRESS_OTHER As String, ByVal jOB_LOCATION As String, ByVal lEAVE_DATE As Date, ByVal lEAVE_LONG As Integer, ByVal bEFORE_MONEY As Integer, ByVal uSER_IDENTITY As String, ByVal eXPWORK1 As String, ByVal eXPWORK2 As String, ByVal oNESELF As String, ByVal tECH_OTHER As String, ByVal sCHOOL_ID As String, ByVal sCHOOL_ID2 As String, ByVal sCHOOL2 As String, ByVal sCHOOL_ID3 As String, ByVal sCHOOL3 As String, ByVal gRADU2 As String, ByVal gRADU_YEAR2 As String, ByVal gRADU3 As String, ByVal gRADU_YEAR3 As String, ByVal gRADU_YEAR As String, ByVal iN_JOB As String, ByVal wISH_JOB_TYPE As String, ByVal wISH_JOB_DATE As Date, ByVal cOLLEGE_GRADU_YEAR As Integer, ByVal hIGH_GRADU_YEAR As Integer, ByVal jOB_MONTHS As Integer, ByVal cASE_SOURCE As String, ByVal cASE_OTHER As String, ByVal oTHER_DETAIL As String)
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("update O_APSTBL set RGSTN=:pRGSTN,USER_ID=:pUSER_ID,RECNO=:pRECNO,FIRSTDATE=:pFIRSTDATE,RGDATE=:pRGDATE,LOOK_TYPE=:pLOOK_TYPE,NET=:pNET,SOLDER=:pSOLDER,GRADU=:pGRADU,SCHOOL=:pSCHOOL,WORK_TIME=:pWORK_TIME,PART_TIME=:pPART_TIME,TRANNING=:pTRANNING,ABILITY1=:pABILITY1,ABILITY2=:pABILITY2,ABILITY3=:pABILITY3,EXPCD1=:pEXPCD1,EXPYM1=:pEXPYM1,EXPCD2=:pEXPCD2,EXPYM2=:pEXPYM2,DRI=:pDRI,TECHCD1=:pTECHCD1,TECHLV1=:pTECHLV1,TECHCD2=:pTECHCD2,TECHLV2=:pTECHLV2,INDIVIDUAL=:pINDIVIDUAL,FORLNG=:pFORLNG,FORLNG_OTH=:pFORLNG_OTH,RESOU=:pRESOU,DISABLED_CD=:pDISABLED_CD,DISABLED_LABEL=:pDISABLED_LABEL,IF_COMMUTE_TIME=:pIF_COMMUTE_TIME,JOIN_JOB=:pJOIN_JOB,JOB_TYPE1=:pJOB_TYPE1,JOB_TYPE2=:pJOB_TYPE2,JOB_TYPE3=:pJOB_TYPE3,JOB_CLASS1=:pJOB_CLASS1,JOB_CLASS2=:pJOB_CLASS2,JOB_CLASS3=:pJOB_CLASS3,IF_USE_COMPUTER=:pIF_USE_COMPUTER,USE_POWER=:pUSE_POWER,USE_OTHER=:pUSE_OTHER,IF_ECONOMY_STRESS=:pIF_ECONOMY_STRESS,STRESS_TYPE=:pSTRESS_TYPE,STRESS_OTHER=:pSTRESS_OTHER,JOB_LOCATION=:pJOB_LOCATION,LEAVE_DATE=:pLEAVE_DATE,LEAVE_LONG=:pLEAVE_LONG,BEFORE_MONEY=:pBEFORE_MONEY,USER_IDENTITY=:pUSER_IDENTITY,EXPWORK1=:pEXPWORK1,EXPWORK2=:pEXPWORK2,ONESELF=:pONESELF,TECH_OTHER=:pTECH_OTHER,SCHOOL_ID=:pSCHOOL_ID,SCHOOL_ID2=:pSCHOOL_ID2,SCHOOL2=:pSCHOOL2,SCHOOL_ID3=:pSCHOOL_ID3,SCHOOL3=:pSCHOOL3,GRADU2=:pGRADU2,GRADU_YEAR2=:pGRADU_YEAR2,GRADU3=:pGRADU3,GRADU_YEAR3=:pGRADU_YEAR3,GRADU_YEAR=:pGRADU_YEAR,IN_JOB=:pIN_JOB,WISH_JOB_TYPE=:pWISH_JOB_TYPE,WISH_JOB_DATE=:pWISH_JOB_DATE,COLLEGE_GRADU_YEAR=:pCOLLEGE_GRADU_YEAR,HIGH_GRADU_YEAR=:pHIGH_GRADU_YEAR,JOB_MONTHS=:pJOB_MONTHS,CASE_SOURCE=:pCASE_SOURCE,CASE_OTHER=:pCASE_OTHER,OTHER_DETAIL=:pOTHER_DETAIL where ,LABOR_ID=:pLABOR_ID,JOB_ID=:pJOB_ID", myConnection)
			myCommand.Parameters.Add(":pJOB_ID", System.Data.OracleClient.OracleType.Number, 8).Value = jOB_ID
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 8).Value = lABOR_ID
			myCommand.Parameters.Add(":pRGSTN", System.Data.OracleClient.OracleType.VarChar, 6).Value = rGSTN
			myCommand.Parameters.Add(":pUSER_ID", System.Data.OracleClient.OracleType.VarChar, 10).Value = uSER_ID
			myCommand.Parameters.Add(":pRECNO", System.Data.OracleClient.OracleType.VarChar, 18).Value = rECNO
			myCommand.Parameters.Add(":pFIRSTDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = fIRSTDATE
			myCommand.Parameters.Add(":pRGDATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = rGDATE
			myCommand.Parameters.Add(":pLOOK_TYPE", System.Data.OracleClient.OracleType.VarChar, 1).Value = lOOK_TYPE
			myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = nET
			myCommand.Parameters.Add(":pSOLDER", System.Data.OracleClient.OracleType.VarChar, 1).Value = sOLDER
			myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
			myCommand.Parameters.Add(":pSCHOOL", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL
			myCommand.Parameters.Add(":pWORK_TIME", System.Data.OracleClient.OracleType.VarChar, 7).Value = wORK_TIME
			myCommand.Parameters.Add(":pPART_TIME", System.Data.OracleClient.OracleType.VarChar, 8).Value = pART_TIME
			myCommand.Parameters.Add(":pTRANNING", System.Data.OracleClient.OracleType.VarChar, 1).Value = tRANNING
			myCommand.Parameters.Add(":pABILITY1", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY1
			myCommand.Parameters.Add(":pABILITY2", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY2
			myCommand.Parameters.Add(":pABILITY3", System.Data.OracleClient.OracleType.VarChar, 64).Value = aBILITY3
			myCommand.Parameters.Add(":pEXPCD1", System.Data.OracleClient.OracleType.VarChar, 4).Value = eXPCD1
			myCommand.Parameters.Add(":pEXPYM1", System.Data.OracleClient.OracleType.VarChar, 64).Value = eXPYM1
			myCommand.Parameters.Add(":pEXPCD2", System.Data.OracleClient.OracleType.VarChar, 4).Value = eXPCD2
			myCommand.Parameters.Add(":pEXPYM2", System.Data.OracleClient.OracleType.VarChar, 64).Value = eXPYM2
			myCommand.Parameters.Add(":pDRI", System.Data.OracleClient.OracleType.VarChar, 2).Value = dRI
			myCommand.Parameters.Add(":pTECHCD1", System.Data.OracleClient.OracleType.VarChar, 5).Value = tECHCD1
			myCommand.Parameters.Add(":pTECHLV1", System.Data.OracleClient.OracleType.VarChar, 1).Value = tECHLV1
			myCommand.Parameters.Add(":pTECHCD2", System.Data.OracleClient.OracleType.VarChar, 5).Value = tECHCD2
			myCommand.Parameters.Add(":pTECHLV2", System.Data.OracleClient.OracleType.VarChar, 1).Value = tECHLV2
			myCommand.Parameters.Add(":pINDIVIDUAL", System.Data.OracleClient.OracleType.VarChar, 1).Value = iNDIVIDUAL
			myCommand.Parameters.Add(":pFORLNG", System.Data.OracleClient.OracleType.VarChar, 5).Value = fORLNG
			myCommand.Parameters.Add(":pFORLNG_OTH", System.Data.OracleClient.OracleType.VarChar, 20).Value = fORLNG_OTH
			myCommand.Parameters.Add(":pRESOU", System.Data.OracleClient.OracleType.VarChar, 8).Value = rESOU
			myCommand.Parameters.Add(":pDISABLED_CD", System.Data.OracleClient.OracleType.VarChar, 1).Value = dISABLED_CD
			myCommand.Parameters.Add(":pDISABLED_LABEL", System.Data.OracleClient.OracleType.VarChar, 1).Value = dISABLED_LABEL
			myCommand.Parameters.Add(":pIF_COMMUTE_TIME", System.Data.OracleClient.OracleType.VarChar, 4).Value = iF_COMMUTE_TIME
			myCommand.Parameters.Add(":pJOIN_JOB", System.Data.OracleClient.OracleType.VarChar, 1).Value = jOIN_JOB
			myCommand.Parameters.Add(":pJOB_TYPE1", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE1
			myCommand.Parameters.Add(":pJOB_TYPE2", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE2
			myCommand.Parameters.Add(":pJOB_TYPE3", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_TYPE3
			myCommand.Parameters.Add(":pJOB_CLASS1", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS1
			myCommand.Parameters.Add(":pJOB_CLASS2", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS2
			myCommand.Parameters.Add(":pJOB_CLASS3", System.Data.OracleClient.OracleType.VarChar, 40).Value = jOB_CLASS3
			myCommand.Parameters.Add(":pIF_USE_COMPUTER", System.Data.OracleClient.OracleType.VarChar, 1).Value = iF_USE_COMPUTER
			myCommand.Parameters.Add(":pUSE_POWER", System.Data.OracleClient.OracleType.VarChar, 7).Value = uSE_POWER
			myCommand.Parameters.Add(":pUSE_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = uSE_OTHER
			myCommand.Parameters.Add(":pIF_ECONOMY_STRESS", System.Data.OracleClient.OracleType.VarChar, 1).Value = iF_ECONOMY_STRESS
			myCommand.Parameters.Add(":pSTRESS_TYPE", System.Data.OracleClient.OracleType.VarChar, 4).Value = sTRESS_TYPE
			myCommand.Parameters.Add(":pSTRESS_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = sTRESS_OTHER
			myCommand.Parameters.Add(":pJOB_LOCATION", System.Data.OracleClient.OracleType.VarChar, 60).Value = jOB_LOCATION
			myCommand.Parameters.Add(":pLEAVE_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = lEAVE_DATE
			myCommand.Parameters.Add(":pLEAVE_LONG", System.Data.OracleClient.OracleType.Number, 8).Value = lEAVE_LONG
			myCommand.Parameters.Add(":pBEFORE_MONEY", System.Data.OracleClient.OracleType.Number, 8).Value = bEFORE_MONEY
			myCommand.Parameters.Add(":pUSER_IDENTITY", System.Data.OracleClient.OracleType.VarChar, 1).Value = uSER_IDENTITY
			myCommand.Parameters.Add(":pEXPWORK1", System.Data.OracleClient.OracleType.VarChar, 20).Value = eXPWORK1
			myCommand.Parameters.Add(":pEXPWORK2", System.Data.OracleClient.OracleType.VarChar, 20).Value = eXPWORK2
			myCommand.Parameters.Add(":pONESELF", System.Data.OracleClient.OracleType.VarChar, 1).Value = oNESELF
			myCommand.Parameters.Add(":pTECH_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = tECH_OTHER
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID
			myCommand.Parameters.Add(":pSCHOOL_ID2", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID2
			myCommand.Parameters.Add(":pSCHOOL2", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL2
			myCommand.Parameters.Add(":pSCHOOL_ID3", System.Data.OracleClient.OracleType.VarChar, 6).Value = sCHOOL_ID3
			myCommand.Parameters.Add(":pSCHOOL3", System.Data.OracleClient.OracleType.VarChar, 64).Value = sCHOOL3
			myCommand.Parameters.Add(":pGRADU2", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU2
			myCommand.Parameters.Add(":pGRADU_YEAR2", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR2
			myCommand.Parameters.Add(":pGRADU3", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU3
			myCommand.Parameters.Add(":pGRADU_YEAR3", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR3
			myCommand.Parameters.Add(":pGRADU_YEAR", System.Data.OracleClient.OracleType.VarChar, 6).Value = gRADU_YEAR
			myCommand.Parameters.Add(":pIN_JOB", System.Data.OracleClient.OracleType.VarChar, 1).Value = iN_JOB
			myCommand.Parameters.Add(":pWISH_JOB_TYPE", System.Data.OracleClient.OracleType.VarChar, 1).Value = wISH_JOB_TYPE
			myCommand.Parameters.Add(":pWISH_JOB_DATE", System.Data.OracleClient.OracleType.DateTime, 8).Value = wISH_JOB_DATE
			myCommand.Parameters.Add(":pCOLLEGE_GRADU_YEAR", System.Data.OracleClient.OracleType.Number, 4).Value = cOLLEGE_GRADU_YEAR
			myCommand.Parameters.Add(":pHIGH_GRADU_YEAR", System.Data.OracleClient.OracleType.Number, 4).Value = hIGH_GRADU_YEAR
			myCommand.Parameters.Add(":pJOB_MONTHS", System.Data.OracleClient.OracleType.Number, 4).Value = jOB_MONTHS
			myCommand.Parameters.Add(":pCASE_SOURCE", System.Data.OracleClient.OracleType.VarChar, 1).Value = cASE_SOURCE
			myCommand.Parameters.Add(":pCASE_OTHER", System.Data.OracleClient.OracleType.VarChar, 128).Value = cASE_OTHER
			myCommand.Parameters.Add(":pOTHER_DETAIL", System.Data.OracleClient.OracleType.VarChar, 128).Value = oTHER_DETAIL
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace
