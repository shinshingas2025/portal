Imports System.IO
Imports System.Text
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Shared.ExportOptions
Imports CrystalDecisions.CrystalReports.Engine
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Threading
Imports GenCode128
Imports System.Web.Mail
Imports System.Net
Imports System.Net.Sockets

Public Class eReceipt_check
    Inherits System.Web.UI.Page

    Public Structure calStr_str
        Dim outString As String
        Dim calResult As Integer
        Dim totDays As Integer
    End Structure

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid_invoice As System.Web.UI.WebControls.DataGrid
    Protected WithEvents form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents messege As System.Web.UI.WebControls.Label
    Protected WithEvents message As System.Web.UI.WebControls.Label
    Protected WithEvents Msg1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label_invoice As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Private thread_status As Boolean = False
    Private ErrCodeHT As Hashtable = New Hashtable
    Private RightCodeHT As Hashtable = New Hashtable
    Private stream As NetworkStream
    Private tcpClient As tcpClient
    Public wm_No As String
    Public DataValues(10) As String
    Dim DetailLog(21) As String
    Dim PHouseNo As String
    Dim PHouseName As String
    Dim PMounth As String
    Const PDFPath As String = "C:\RPT\" ' "C:\Inetpub\wwwroot\"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then
            If Session("wm_id") = "" Then
                Response.Redirect("eReceipt_login.aspx")
            End If
            If Session("org_flag") = 1 Then
                Datagrid2.Columns(6).Visible = False
            Else
                Datagrid2.Columns(6).Visible = True
            End If
        End If
        Msg1.Text = ""
        ShowGridData()
        'FileSystem.Dir("c:\rpt\", FileAttribute.Directory)
        'system.IO.Directory.
    End Sub

#Region "ReadFile　DownloadFile　檔案下載使用之程式"
    'Function ReadFile(ByVal FileName As String) As Boolean
    Function ReadFile(ByRef buffer() As Byte, ByVal FileName As String) As Boolean
        Dim MFile As System.IO.File
        Dim FileStream As System.IO.Stream
        If Not MFile.Exists(FileName) Then
            ReadFile = False
            Exit Function
        End If
        FileStream = MFile.OpenRead(FileName)
        ReDim buffer(FileStream.Length)
        FileStream.Read(buffer, 0, FileStream.Length)
        FileStream.Close()
        MFile = Nothing
        ReadFile = True
    End Function
    Sub DownloadFile(ByVal FileName As String)
        Dim buf(0) As Byte
        If ReadFile(buf, FileName) = False Then
            Response.Write("讀取檔案失敗 檔名：〔" & FileName & "]")
            Response.End()
        End If
        Response.ClearHeaders()
        Response.Clear()
        Response.Expires = 0
        Response.Buffer = True
        FileName = Right(FileName, InStr(StrReverse(FileName), "\") - 1)
        Response.AddHeader("content-disposition", "attachment;filename=" & Chr(34) & FileName & Chr(34))
        Response.ContentType = "Application/octet-stream"
        Response.BinaryWrite(buf)
    End Sub
#End Region

#Region "ShowGridData　從資料庫讀取使用者所登記的用戶號碼顯示在DataGrid"
    Sub ShowGridData()
        Dim GetCheckdata As New webmemberDAO
        Dim dt As DataTable
        wm_No = GetCheckdata.GetMemberAutoWm_no(Session("org_flag"), Session("wm_id"))
        dt = GetCheckdata.GetSearchData(wm_No, "")
        If dt.Rows.Count > 0 Then
            Datagrid2.DataSource = dt
            Datagrid2.DataBind()
        End If


        dt.Clear()
        Label_invoice.Visible = False
        If Session("org_flag") = 2 Then
            dt = GetCheckdata.GetinvoiceData_ForOrg(Session("wm_id"))
            Datagrid_invoice.DataSource = dt
            Datagrid_invoice.DataBind()
            Label_invoice.Visible = True
        End If
    End Sub
#End Region

#Region "ActionCommand　依不同功能執行不同的程式"
    Sub ActionCommand(ByVal HouseNo As String, ByVal HouseName As String, ByVal REDate As String, ByVal Currinput As Integer, ByVal EMail As String)
        Dim GetCheckdata As New webmemberDAO
        Dim dt As DataTable
        Dim TempStr As String
        Dim int_result As Integer
        ClearCheckData()

        FillCheckData(HouseNo, HouseName, REDate, Currinput, EMail)
        If Currinput <> 3 Then
            dt = Compact(HouseNo, HouseName, REDate)
            If dt.Rows.Count > 0 Then
                TempStr = ReportList(dt, Currinput)
                Dim A() As String = Split(TempStr, "|")
                If Currinput = 1 Then                                   '下載
                    DownloadFile(A(0))
                    Msg1.Text = ""
                    GetCheckdata.InsertSearchDataLog(DataValues)
                    System.IO.File.Delete(A(0))
                    System.IO.Directory.Delete(A(3))
                Else                                                    '補寄電子檔
                    'TrueSend(A(0), A(1), A(2), REDate, 2)
                    int_result = SendMailB(A(0), A(1), A(2), REDate, 2)
                    GetCheckdata.InsertSearchDataLog(DataValues)
                    System.IO.File.Delete(A(0))
                    System.IO.Directory.Delete(A(3))
                    If int_result = 1 Then
                        Response.Redirect("eReceipt_check_success.aspx?Flag=2")     '成功
                    Else
                        Response.Redirect("eReceipt_check_success.aspx?Flag=21")    '失敗
                    End If
                End If
            Else
                Msg1.Text = "無此月份資料"
            End If
        Else
            GetCheckdata.InsertSearchDataLog(DataValues)                 '補寄紙本
            ' dt = Compact(HouseNo, HouseName, REDate)
            'If dt.Rows.Count > 0 Then
            '   TempStr = ReportList(dt, Currinput)
            '  Dim A() As String = Split(TempStr, "|")
            'TrueSend(A(0), A(1), A(2), REDate, 3)
            TrueSend("", "", "", REDate, 3)
            GetCheckdata.InsertSearchDataLog(DataValues)
            ' System.IO.File.Delete(A(0))
            ' System.IO.Directory.Delete(A(3))

            'End If
            Response.Redirect("eReceipt_check_success.aspx?Flag=3")
        End If
    End Sub
#End Region

#Region "ClearCheckData　清除暫存Log檔的陣列"
    Sub ClearCheckData()
        Dim i As Integer
        For i = 0 To DataValues.Length - 1
            DataValues(i) = ""
        Next
    End Sub
#End Region

#Region "FillCheckData　填入正確值暫存到Log檔的陣列準備放入SQL"
    Sub FillCheckData(ByVal HouseNo As String, ByVal HouseName As String, ByVal REDate As String, ByVal Currinput As Integer, ByVal EMail As String)
        DataValues(0) = wm_No
        DataValues(1) = HouseNo
        DataValues(2) = REDate ' Format(Conversion.Val(Left(REDate, 4)) - 1911, "000") & Right(REDate, 2)
        DataValues(3) = Currinput
        DataValues(4) = IIf(Currinput = 3, 1, 2)
        DataValues(5) = EMail
        DataValues(6) = Session("wm_id")
        DataValues(7) = ""
    End Sub
#End Region

#Region "Datagrid2_ItemCommand　點選DataGrid欄位所觸發的動作"
    Private Sub Datagrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid2.ItemCommand
        Dim i As Integer
        Dim hNo As String
        Dim hUName As String
        Dim RDate As String
        Dim EMail As String
        Dim CurrInput As Integer
        i = e.Item.ItemIndex
        hNo = Trim(Datagrid2.Items(i).Cells(0).Text)
        hUName = Trim(Datagrid2.Items(i).Cells(1).Text)
        RDate = Trim(Datagrid2.Items(i).Cells(2).Text)
        EMail = Trim(Datagrid2.Items(i).Cells(3).Text)
        CurrInput = Trim(Right(e.CommandName, 1))
        PHouseNo = hNo
        PHouseName = hUName
        PMounth = RDate
        ActionCommand(hNo, hUName, RDate, CurrInput, EMail)
    End Sub
#End Region
#Region "Compact　讀取需要寄電子郵件的SQL"
    Function Compact(ByVal HouseNo As String, ByVal HouseName As String, ByVal REDate As String) As DataTable
        Dim GetData As New webmemberDAO
        Dim dt As New DataTable
        Dim sql = " Select DISTINCT  d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,d32,d33,d34,d35,d36,d37,d38,d39,d40,d41,d42,d43,d44,d45,d50"
        sql = sql & ",mh_wm_no, mh_house_no,mh_ers_flag "
        sql = sql & ",wm_password,wm_user_name,wm_email,wm_id,wm_open_flag "
        sql = sql & " from Receipt join member_house on d10 = mh_house_no join webmember on mh_wm_no=wm_no "
        sql = sql & " WHERE   " '  (member_house.mh_ers_flag = 'Y') "
        sql = sql & "  (Receipt.D10 = '" & HouseNo & "') AND (Receipt.D14 = '" & REDate & "') " 'AND (Receipt.D36 = '" & HouseName & "')"
        '                   0    1   2  3   4   5   6    7   8   9   0   1   2   3   4   5   6   7   8   9   0   1   2   3   4   5   6   7   8  9   0  1  2   3   4
        ' Dim sql1 = " Select d14,d18,d20,d22,d24,d25,d26,d27,d28,d29,d30,d31,d32,d33,d34,d35,d36,d37,d38,d39,d40,d41,d42,d43,d44,d45,d46,d47,d48,d49,d7,d8,d10,d6,d50"
        'sql1 = sql1 & ",mh_wm_no, mh_house_no,mh_ers_flag "
        'sql1 = sql1 & ",wm_password,wm_user_name,wm_email,wm_id,wm_open_flag "
        'sql1 = sql1 & " from Receipt join member_house on d10 = mh_house_no join webmember on mh_wm_no=wm_no "
        'sql1 = sql1 & " WHERE     (member_house.mh_ers_flag = 'Y')"
        dt = GetData.GetReceiptData(sql)
        Compact = dt
    End Function
#End Region

#If 0 Then
#Region "Compact　讀取需要寄電子郵件的SQL"
    Function Compact(ByVal HouseNo As String, ByVal HouseName As String, ByVal REDate As String) As DataTable
        Dim GetData As New webmemberDAO
        Dim dt As New DataTable
        Dim sql = " Select DISTINCT  d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,d32,d33,d34,d35,d36,d37,d38,d39,d40,d41,d42,d43,d44"
        sql = sql & ",mh_wm_no, mh_house_no,mh_ers_flag "
        sql = sql & ",wm_password,wm_user_name,wm_email,wm_id,wm_open_flag "
        sql = sql & " from Receipt join member_house on d10 = mh_house_no join webmember on mh_wm_no=wm_no "
        sql = sql & " WHERE   " '  (member_house.mh_ers_flag = 'Y') "
        sql = sql & "  (Receipt.D10 = '" & HouseNo & "') AND (Receipt.D14 = '" & REDate & "') " 'AND (Receipt.D36 = '" & HouseName & "')"
        '                   0    1   2  3   4   5   6    7   8   9   0   1   2   3   4   5   6   7   8   9   0   1   2   3   4   5   6   7   8  9   0  1  2   3   4
        ' Dim sql1 = " Select d14,d18,d20,d22,d24,d25,d26,d27,d28,d29,d30,d31,d32,d33,d34,d35,d36,d37,d38,d39,d40,d41,d42,d43,d44,d45,d46,d47,d48,d49,d7,d8,d10,d6,d50"
        'sql1 = sql1 & ",mh_wm_no, mh_house_no,mh_ers_flag "
        'sql1 = sql1 & ",wm_password,wm_user_name,wm_email,wm_id,wm_open_flag "
        'sql1 = sql1 & " from Receipt join member_house on d10 = mh_house_no join webmember on mh_wm_no=wm_no "
        'sql1 = sql1 & " WHERE     (member_house.mh_ers_flag = 'Y')"
        dt = GetData.GetReceiptData(sql)
        Compact = dt
    End Function
#End Region
#End If
#Region "ReadLongAD　讀取長廣告欄的文字"
#If 0 Then
    Function ReadLongAD(ByVal Line As Integer)
        Dim dt1 As New DataTable
        Dim GetData As New webmemberDAO
        Dim DateString As String
        DateString = Format(Now, "yyyy-MM-dd hh:mm:ss")
        dt1 = GetData.GetReceiptData("Select * from  Receipt_ad where ad_start_date <='" & DateString & "' and ad_end_date >='" & DateString & "' and ad_line=" & Line & " order by ad_end_date ")
        If dt1.Rows.Count > 0 Then
            ReadLongAD = dt1.Rows(0)(1)
        Else
            ReadLongAD = ""
        End If
    End Function
#End If
    Function ReadLongAD(ByVal Line As Integer, ByRef ADLong() As String)
        Dim dt1 As New DataTable
        Dim bj As New webmemberDAO
        Dim DateString As String
        DateString = Format(Now, "yyyy-MM-dd HH:mm:ss")
        dt1 = bj.GetReceiptData("Select * from  Receipt_ad where ad_start_date <='" & DateString & "' and ad_end_date >='" & DateString & "' order by ad_end_date DESC ") ' and ad_line=" & Line & "
        If dt1.Rows.Count > 0 Then
            ADLong(1) = dt1.Rows(0)(1)
            ADLong(2) = dt1.Rows(0)(2)
            ADLong(3) = dt1.Rows(0)(3)
        Else
            ADLong(1) = ""
            ADLong(2) = ""
            ADLong(3) = ""
        End If
    End Function
#End Region

#Region "ReportList　將資料逐筆填到報表內,再加密"






    Function ReportList(ByVal dt As DataTable, ByVal Val As Integer) As String
        Dim i As Integer
        Dim RptTextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim RptPictureObj As CrystalDecisions.CrystalReports.Engine.PictureObject
        Dim FileName As String
        Dim ReString As String
        Dim thisRptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim reader As PdfReader
        Dim stream As Stream
        Dim DateTemp As String = ""
        Dim asc As ASCIIEncoding
        Dim by() As Byte = New Byte(10) {}
        Dim logoninfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim thisPath As String = "C:\Inetpub\wwwroot\"
        Dim int_Exit_Flag As Integer = 0
        Dim int_Result As Integer = 0
        Dim Sendi As Integer
        Dim ADLong(3) As String
        Dim ADShort(6) As String
        Dim dt1 As New DataTable
        Dim GetData As New webmemberDAO

        '2014-03-26 Yeh Begin
        Dim calString(3) As calStr_str
        Dim realPrice As Integer
        Dim priceSel As Integer
        Dim j As Integer
        Dim TempPrice As String
        Dim TempPrice1 As String
        Dim TempPrice2 As String
        Dim rtPrice1 As String
        Dim rtPrice2 As String
        Dim rtPrice3 As String
        Dim rtPrice4 As String
        Dim DatePriceStr1 As String
        Dim DatePriceStr2 As String
        Dim DatePriceStr3 As String
        Dim DatePriceStr4 As String
        Dim DPriceStr(4) As String
        Dim Flag44 As Integer
        Dim objAPPM04 As New APPM04DAO
        Dim dt66 As DataTable
        Dim dt67 As DataTable
        Dim dt68 As DataTable
        Dim am04_rcp_no As Integer
        Dim type As String
        Dim beginSw1 As Integer = 0
        Dim beginSw2 As Integer = 0
        Dim beginSw3 As Integer = 0
        Dim use_degree As Integer
        Dim L_amt As Long
        Dim Curr_amt As Double
        Dim L_amt1 As Long
        Dim Curr_amt1 As Double
        Dim L_amt2 As Long
        Dim Curr_amt2 As Double
        Dim invno As String

        Dim invnoBar As String
        Dim invNum As String
        Dim invyy As String
        Dim invmms As String
        Dim invmme As String
        Dim invsdate As String
        Dim invedate As String
        Dim tempyy As Integer
        Dim tempmms As Integer
        Dim tempmme As Integer
        Dim sw1 As Long
        Dim sw2 As Long
        Dim pp1 As Long
        Dim pp2 As Long
        Dim ax19amt As Long
        Dim checks As Integer
        Dim ADay(3) As String
        Dim TDay As String
        Dim startI As Integer
        Dim endI As Integer
        Dim myimg As System.Drawing.Image
        Dim simg As System.Drawing.Image
        Dim tmpUID As New Guid
        tmpUID = Guid.NewGuid

        'add 1071005
        Dim invno1 As String = ""
        Dim myimg1 As System.Drawing.Image

        Dim ao As Long
        Dim ap As Long
        Dim strAnother As String = ""
        'end 1071005


        rtPrice1 = "" ' "2095=(20.50*4+21.00*23+21.50*1)*100/28"
        rtPrice2 = "" ' "補正金額13=(20*8 + 20.5*23)*90/31-(20*8+20.3*23*90/31"
        '2014-03-26 Yeh End

        dt1 = GetData.GetReceiptData("Select * from  Receipt_notice ")
        If dt1.Rows.Count > 0 Then
            For i = 0 To dt1.Rows.Count - 1
                ADShort(dt1.Rows(i)(2)) = dt1.Rows(i)(1)
            Next
        End If
        'For i = 1 To 3
        'ADLong(i) = ReadLongAD(i)
        'Next
        ReadLongAD(0, ADLong)
        'thisRptDoc.Load(thisPath + "SupShowLogoR-2.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        'thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2-NEW.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        thisRptDoc.Refresh()
        DateTemp = Format(Now, "yyyyMMddHHmmss")
        For i = 0 To dt.Rows.Count - 1

            '*****************20160217 bacom 修*****************************
            ' ''If FileIO.FileSystem.DirectoryExists("c:\img\OK") = True Then
            ' ''    Msg1.Text = "系統目前忙線中,請稍後再試"
            ' ''    ReportList = ""
            ' ''    Exit Function
            ' ''Else
            ' ''    FileIO.FileSystem.CreateDirectory("c:\img\OK")
            ' ''End If
            ' ''If FileIO.FileSystem.FileExists("c:\img\barc.jpg") = True Then
            ' ''    'FileIO.FileSystem.DeleteFile("c:\img\barc.jpg")
            ' ''    System.IO.File.Delete("c:\img\barc.jpg")
            ' ''End If
            ' ''If FileIO.FileSystem.FileExists("c:\img\ed0022.jpg") = True Then
            ' ''    'FileIO.FileSystem.DeleteFile("c:\img\ed0022.jpg")
            ' ''    System.IO.File.Delete("c:\img\ed0022.jpg")
            ' ''End If

            '*****************20160217 bacom 修*****************************



            '2014-03-26 Yeh Begin
            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then '燈別
                type = "2"
            Else
                type = "1"
            End If
            If Trim(dt.Rows(i).Item("D19")) <> "" Then  '統編
                priceSel = 2
            Else
                priceSel = 1
            End If

            'dt.Rows(i).Item("D14") = 10306
            'dt.Rows(i).Item("D18") = "D"
            ' dt.Rows(i).Item("D10") = 661696 '用戶號碼
            ' dt.Rows(i).Item("D34") 本次抄表日
            use_degree = dt.Rows(i).Item("D26")         '使用度數

            dt68 = objAPPM04.GetAM68(dt.Rows(i).Item("D14"), dt.Rows(i).Item("D10")).Tables(0)
            rtPrice1 = ""
            rtPrice2 = ""
            rtPrice3 = ""
            rtPrice4 = ""

            Dim ii As Integer
            For ii = 0 To 3
                DPriceStr(ii) = ""
            Next
            If Trim(dt.Rows(i).Item("D38")) <> "" Then
                DPriceStr(0) = Left(dt.Rows(i).Item("D38"), 12)
                DPriceStr(1) = Mid(dt.Rows(i).Item("D38"), 13, 12)
                DPriceStr(2) = Mid(dt.Rows(i).Item("D38"), 25, 12)
                DPriceStr(3) = Mid(dt.Rows(i).Item("D38"), 37, 12)
                If Trim(DPriceStr(0)) <> "" Then DPriceStr(0) = Left(DPriceStr(0), 7) & "調價每度" & Right(DPriceStr(0), 5) & "元"
                If Trim(DPriceStr(1)) <> "" Then DPriceStr(1) = Left(DPriceStr(1), 7) & "調價每度" & Right(DPriceStr(1), 5) & "元"
                If Trim(DPriceStr(2)) <> "" Then DPriceStr(2) = Left(DPriceStr(2), 7) & "調價每度" & Right(DPriceStr(2), 5) & "元"
                If Trim(DPriceStr(3)) <> "" Then DPriceStr(3) = Left(DPriceStr(3), 7) & "調價每度" & Right(DPriceStr(3), 5) & "元"

            End If
            If Trim(dt.Rows(i).Item("D45")) <> "" Then
                rtPrice1 = Left(dt.Rows(i).Item("D45"), 44)
                rtPrice2 = Mid(dt.Rows(i).Item("D45"), 45, 44)
                rtPrice3 = Mid(dt.Rows(i).Item("D45"), 89, 44)
                rtPrice4 = Mid(dt.Rows(i).Item("D45"), 133, 44)
            End If


            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr1")
            RptTextObj.Text = rtPrice1
            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr2")
            ' RptTextObj.Text = rtPrice2
            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr3")
            ' RptTextObj.Text = rtPrice3
            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr4")
            '  RptTextObj.Text = rtPrice4


            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice1")
            RptTextObj.Text = DPriceStr(0)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice2")
            RptTextObj.Text = DPriceStr(1)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice3")
            RptTextObj.Text = DPriceStr(2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice4")
            RptTextObj.Text = DPriceStr(3)

            '2014-03-26 Yeh End

            ADay = rtPrice1.Split("/")
            'ADay() = Right(rtPrice1, 2)
            TDay = Left(ADay(1), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("pdays")
            RptTextObj.Text = TDay

            If IsDBNull(dt.Rows(i).Item("D50")) = False Then
                If Trim(dt.Rows(i).Item("D50")) <> "" Then
                    'invno = Left(dt.Rows(i).Item("D50"), 30)
                    invno = Left(dt.Rows(i).Item("D50"), 15)
                    invno1 = Mid(dt.Rows(i).Item("D50"), 16, 15)
                    invNum = Mid(dt.Rows(i).Item("D50"), 31, 10)
                    tempyy = Mid(dt.Rows(i).Item("D50"), 41, 3)
                    tempmms = Mid(dt.Rows(i).Item("D50"), 44, 2)
                    tempmme = Mid(dt.Rows(i).Item("D50"), 46, 2)
                    invsdate = Mid(dt.Rows(i).Item("D50"), 48, 7)
                    invedate = Mid(dt.Rows(i).Item("D50"), 55, 7)
                    invsdate = Left(invsdate, 3) & "/" & Mid(invsdate, 4, 2) & "/" & Right(invsdate, 2)
                    invedate = Left(invedate, 3) & "/" & Mid(invedate, 4, 2) & "/" & Right(invedate, 2)
                    ax19amt = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 64, 7))
                    sw1 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 71, 7))
                    sw2 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 78, 7))
                    pp1 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 85, 7))
                    pp2 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 92, 7))

                    '1071006 add 
                    ao = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 99, 7))
                    ap = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 106, 7))
                    'end 
                Else
                    invno = ""
                    invno1 = ""
                    invNum = ""
                    tempyy = 0
                    tempmms = 0
                    tempmme = 0
                    invsdate = ""
                    invedate = ""
                End If
            Else

                invno = ""
                invno1 = ""
                invNum = ""
                tempyy = 0
                tempmms = 0
                tempmme = 0
                invsdate = ""
                invedate = ""
            End If
            If tempyy = 0 Then
                invyy = ""
            Else
                invyy = tempyy
            End If
            If tempmms = 0 Then
                invmms = ""
            Else
                invmms = tempmms
            End If
            If tempmme = 0 Then
                invmme = ""
            Else
                invmme = tempmme
            End If

            '******20160217  bacom修**************************


            If Trim(invno) <> "" And Conversion.Val(dt.Rows(i).Item("D7")) <> 0 Then
                myimg = Code128Rendering.MakeBarcodeImage(invno, 1, True)
                myimg.Save(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))

                myimg1 = Code128Rendering.MakeBarcodeImage(invno1, 1, True)
                myimg1.Save(Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg"))

                simg = Code128Rendering.MakeBarcodeImage("ED0022", 1, True)
                simg.Save(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
            Else
                FileIO.FileSystem.CopyFile(Server.MapPath("/images/barc.jpg"), Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
                FileIO.FileSystem.CopyFile(Server.MapPath("/images/barc2.jpg"), Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg"))
                FileIO.FileSystem.CopyFile(Server.MapPath("/images/ED0022.jpg"), Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
            End If

            ' ''If Trim(invno) <> "" And Conversion.Val(dt.Rows(i).Item("D7")) <> 0 Then
            ' ''    myimg = Code128Rendering.MakeBarcodeImage(invno, 1, True)
            ' ''    myimg.Save("C:\img\barc.jpg")
            ' ''    simg = Code128Rendering.MakeBarcodeImage("ED0022", 1, True)
            ' ''    simg.Save("C:\img\ed0022.jpg")
            ' ''Else
            ' ''    FileIO.FileSystem.CopyFile("C:\img\img1\barc.jpg", "C:\img\barc.jpg")
            ' ''    FileIO.FileSystem.CopyFile("C:\img\img1\ED0022.jpg", "C:\img\ED0022.jpg")
            ' ''End If


            '******20160217  bacom修**************************



            invno = Left(invno, 5) & " " & Mid(invno, 6, 10) & " " & Mid(invno, 16, Len(invno))

            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode1Path").Text = """" & Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg") & """"
            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode2Path").Text = """" & Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg") & """"

            '1071005
            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode3Path").Text = """" & Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg") & """"

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no11")
            RptTextObj.Text = invno

            '1071005
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no12")
            RptTextObj.Text = invno1

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("yyy")
            RptTextObj.Text = invyy

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("mm1")
            RptTextObj.Text = invmms

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("mm2")
            RptTextObj.Text = invmme

            invNum = Left(invNum, 2) & "-" & Mid(invNum, 3, Len(invNum))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no2")
            RptTextObj.Text = invNum

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text40")
            RptTextObj.Text = invsdate

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text97")
            RptTextObj.Text = invedate

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text102")
            RptTextObj.Text = ax19amt

            'If sw1 <> 0 Then
            '    RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw2")
            '    RptTextObj.Text = "2.1開關:      " & sw1
            'End If
            'If sw2 <> 0 Then
            '    RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw4")
            '    RptTextObj.Text = "3.6開關:      " & sw2
            'End If
            'If pp1 <> 0 Then
            '    RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_pp1")
            '    RptTextObj.Text = "熱水器銜接管: " & pp1
            'End If

            'If pp2 <> 0 Then
            '    RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_pp2")
            '    RptTextObj.Text = "瓦斯爐銜接管: " & pp2
            'End If

            '1071006 add 
            If sw1 <> 0 Then strAnother += " 2.1開關:      " & sw1 & Chr(13)
            If sw2 <> 0 Then strAnother += " 3.6開關:      " & sw2 & Chr(13)
            If ao <> 0 Then strAnother += " 5.0 開關:      " & ao & Chr(13)
            If pp1 <> 0 Then strAnother += " 熱水器銜接管: " & pp1 & Chr(13)
            If pp2 <> 0 Then strAnother += " 瓦斯爐銜接管: " & pp2 & Chr(13)
            If ap <> 0 Then strAnother += "  檢查費:       " & ap & Chr(13)

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw2")
            RptTextObj.Text = strAnother
            '1071006 end 
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lDate")
            If Trim(dt.Rows(i).Item("D16")) <> "" Then
                RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) '    Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
                RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
            Else
                RptTextObj.Text = ""
            End If
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lusedegree")
            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26")) ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lyear")
            RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lmonth") '
            RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("raddress")                     '裝置地址
            RptTextObj.Text = Trim(dt.Rows(i).Item("D37")) 'dt.Rows(i).Item("D23")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text94")                     '寶號
            RptTextObj.Text = dt.Rows(i).Item("D44") '通訊地址
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rid")                          '統一編號
            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19"))
            DetailLog(19) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rlightno")                     '燈別
            RptTextObj.Text = dt.Rows(i).Item("D21")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtotal")                       '實收總金額
            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) ' & "." & ReRight(dt.Rows(i).Item("D7"), 2)
            DetailLog(18) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpayment")                     '代繳帳號
            RptTextObj.Text = Left(dt.Rows(i).Item("D6"), 6) & "XXXX" & Right(dt.Rows(i).Item("D6"), 4)
            DetailLog(20) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbnum") '
            RptTextObj.Text = dt.Rows(i).Item("D18")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lhouseno") '
            RptTextObj.Text = Right("0000000" & dt.Rows(i).Item("D10"), 7) '
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lname") '
            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lcompany") '
            RptTextObj.Text = "" ' Trim(dt.Rows(i).Item("D22"))

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthedegree") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lpredegree") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lvol") '
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) ' ReVal(Trim(dt.Rows(i).Item("D28")))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbasic") '
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D40"))) 'ReVal(Trim(dt.Rows(i).Item("D29")))

            If Trim(dt.Rows(i).Item("D30")) = "-" Then
                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text93") '
                RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D31")) 'dt.Rows(i).Item("D30") &
                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount") '
                RptTextObj.Text = "0" 'dt.Rows(i).Item("D30") &
            Else
                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount") '
                RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D31")) 'dt.Rows(i).Item("D30") &
                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text93") '
                RptTextObj.Text = "0" 'dt.Rows(i).Item("D30") &
            End If

            ' 1071006  add 於應繳金額下方多顯示應繳金額
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Memoltax") '
            If Conversion.Val(dt.Rows(i).Item("D33")) <> "0" Then
                RptTextObj.Text = "(內含税金" & Conversion.Val(dt.Rows(i).Item("D33")) & "元)"
            Else
                RptTextObj.Text = ""
            End If
            ' end 1071006
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lother") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltax") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
            FileName = Trim(dt.Rows(i).Item("D10")) & Trim(dt.Rows(i).Item("D14"))




            thisRptDoc.Refresh()
            If FileIO.FileSystem.DirectoryExists("c:/img/OK") = True Then
                System.IO.Directory.Delete("c:/img/OK")
            End If

            System.IO.Directory.CreateDirectory("C:\RPT\" & DateTemp)

            thisRptDoc.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat, "c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")

            reader = New PdfReader("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
            stream = CType(New FileStream("c:\RPT\" & DateTemp & "\" & FileName & ".pdf", FileMode.Append), Stream)
            asc = New System.Text.ASCIIEncoding
            '*****20140929_Bacom**********************************************
            Dim cancelPWD As Boolean = False
            cancelPWD = GetData.GetPDFCancelPWD(dt.Rows(i).Item("wm_id"))
            If cancelPWD Then
                by = asc.GetBytes("", 0, 0)
            Else
                by = asc.GetBytes(dt.Rows(i).Item("wm_id"), 0, dt.Rows(i).Item("wm_id").Length)
            End If
            'by = asc.GetBytes(dt.Rows(i)(50), 0, dt.Rows(i)(50).Length)
            '*****************************************************************
            iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, stream, by, by, iTextSharp.text.pdf.PdfWriter.ALLOW_PRINTING, True)
            System.IO.File.Delete("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
            ReString = "c:\RPT\" & DateTemp & "\" & FileName & ".pdf" & "|" & Trim(dt.Rows(i).Item("wm_user_name")) & "|" & Trim(dt.Rows(i).Item("wm_email")) & "|" & "c:\RPT\" & DateTemp
        Next
        thisRptDoc.Close()
        thisRptDoc = Nothing
        ReportList = ReString 'PDFPath & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i)(49))

        '******************20160217 bacom修************************
        If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg")) = True Then
            System.IO.File.Delete(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
        End If
        If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg")) = True Then
            System.IO.File.Delete(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
        End If
        '******************20160217 bacom修************************

        If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg")) = True Then
            System.IO.File.Delete(Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg"))
        End If
    End Function

















    ' ''    Function ReportList_20180417_OLD(ByVal dt As DataTable, ByVal Val As Integer) As String
    ' ''        Dim i As Integer
    ' ''        Dim RptTextObj As CrystalDecisions.CrystalReports.Engine.TextObject
    ' ''        Dim RptPictureObj As CrystalDecisions.CrystalReports.Engine.PictureObject
    ' ''        Dim FileName As String
    ' ''        Dim ReString As String
    ' ''        Dim thisRptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    ' ''        Dim reader As PdfReader
    ' ''        Dim stream As Stream
    ' ''        Dim DateTemp As String = ""
    ' ''        Dim asc As ASCIIEncoding
    ' ''        Dim by() As Byte = New Byte(10) {}
    ' ''        Dim logoninfo As New CrystalDecisions.Shared.TableLogOnInfo
    ' ''        Dim thisPath As String = "C:\Inetpub\wwwroot\"
    ' ''        Dim int_Exit_Flag As Integer = 0
    ' ''        Dim int_Result As Integer = 0
    ' ''        Dim Sendi As Integer
    ' ''        Dim ADLong(3) As String
    ' ''        Dim ADShort(6) As String
    ' ''        Dim dt1 As New DataTable
    ' ''        Dim GetData As New webmemberDAO

    ' ''        '2014-03-26 Yeh Begin
    ' ''        Dim calString(3) As calStr_str
    ' ''        Dim realPrice As Integer
    ' ''        Dim priceSel As Integer
    ' ''        Dim j As Integer
    ' ''        Dim TempPrice As String
    ' ''        Dim TempPrice1 As String
    ' ''        Dim TempPrice2 As String
    ' ''        Dim rtPrice1 As String
    ' ''        Dim rtPrice2 As String
    ' ''        Dim rtPrice3 As String
    ' ''        Dim rtPrice4 As String
    ' ''        Dim DatePriceStr1 As String
    ' ''        Dim DatePriceStr2 As String
    ' ''        Dim DatePriceStr3 As String
    ' ''        Dim DatePriceStr4 As String
    ' ''        Dim DPriceStr(4) As String
    ' ''        Dim Flag44 As Integer
    ' ''        Dim objAPPM04 As New APPM04DAO
    ' ''        Dim dt66 As DataTable
    ' ''        Dim dt67 As DataTable
    ' ''        Dim dt68 As DataTable
    ' ''        Dim am04_rcp_no As Integer
    ' ''        Dim type As String
    ' ''        Dim beginSw1 As Integer = 0
    ' ''        Dim beginSw2 As Integer = 0
    ' ''        Dim beginSw3 As Integer = 0
    ' ''        Dim use_degree As Integer
    ' ''        Dim L_amt As Long
    ' ''        Dim Curr_amt As Double
    ' ''        Dim L_amt1 As Long
    ' ''        Dim Curr_amt1 As Double
    ' ''        Dim L_amt2 As Long
    ' ''        Dim Curr_amt2 As Double
    ' ''        Dim invno As String
    ' ''        Dim invnoBar As String
    ' ''        Dim invNum As String
    ' ''        Dim invyy As String
    ' ''        Dim invmms As String
    ' ''        Dim invmme As String
    ' ''        Dim invsdate As String
    ' ''        Dim invedate As String
    ' ''        Dim tempyy As Integer
    ' ''        Dim tempmms As Integer
    ' ''        Dim tempmme As Integer
    ' ''        Dim sw1 As Long
    ' ''        Dim sw2 As Long
    ' ''        Dim pp1 As Long
    ' ''        Dim pp2 As Long
    ' ''        Dim ax19amt As Long
    ' ''        Dim checks As Integer
    ' ''        Dim ADay(3) As String
    ' ''        Dim TDay As String
    ' ''        Dim startI As Integer
    ' ''        Dim endI As Integer
    ' ''        Dim myimg As System.Drawing.Image
    ' ''        Dim simg As System.Drawing.Image
    ' ''        Dim tmpUID As New Guid
    ' ''        tmpUID = Guid.NewGuid


    ' ''        rtPrice1 = "" ' "2095=(20.50*4+21.00*23+21.50*1)*100/28"
    ' ''        rtPrice2 = "" ' "補正金額13=(20*8 + 20.5*23)*90/31-(20*8+20.3*23*90/31"
    ' ''        '2014-03-26 Yeh End

    ' ''        dt1 = GetData.GetReceiptData("Select * from  Receipt_notice ")
    ' ''        If dt1.Rows.Count > 0 Then
    ' ''            For i = 0 To dt1.Rows.Count - 1
    ' ''                ADShort(dt1.Rows(i)(2)) = dt1.Rows(i)(1)
    ' ''            Next
    ' ''        End If
    ' ''        'For i = 1 To 3
    ' ''        'ADLong(i) = ReadLongAD(i)
    ' ''        'Next
    ' ''        ReadLongAD(0, ADLong)
    ' ''        'thisRptDoc.Load(thisPath + "SupShowLogoR-2.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
    ' ''        thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
    ' ''        thisRptDoc.Refresh()
    ' ''        DateTemp = Format(Now, "yyyyMMddHHmmss")
    ' ''        For i = 0 To dt.Rows.Count - 1

    ' ''            '*****************20160217 bacom 修*****************************
    ' ''            ' ''If FileIO.FileSystem.DirectoryExists("c:\img\OK") = True Then
    ' ''            ' ''    Msg1.Text = "系統目前忙線中,請稍後再試"
    ' ''            ' ''    ReportList = ""
    ' ''            ' ''    Exit Function
    ' ''            ' ''Else
    ' ''            ' ''    FileIO.FileSystem.CreateDirectory("c:\img\OK")
    ' ''            ' ''End If
    ' ''            ' ''If FileIO.FileSystem.FileExists("c:\img\barc.jpg") = True Then
    ' ''            ' ''    'FileIO.FileSystem.DeleteFile("c:\img\barc.jpg")
    ' ''            ' ''    System.IO.File.Delete("c:\img\barc.jpg")
    ' ''            ' ''End If
    ' ''            ' ''If FileIO.FileSystem.FileExists("c:\img\ed0022.jpg") = True Then
    ' ''            ' ''    'FileIO.FileSystem.DeleteFile("c:\img\ed0022.jpg")
    ' ''            ' ''    System.IO.File.Delete("c:\img\ed0022.jpg")
    ' ''            ' ''End If

    ' ''            '*****************20160217 bacom 修*****************************



    ' ''            '2014-03-26 Yeh Begin
    ' ''            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then '燈別
    ' ''                type = "2"
    ' ''            Else
    ' ''                type = "1"
    ' ''            End If
    ' ''            If Trim(dt.Rows(i).Item("D19")) <> "" Then  '統編
    ' ''                priceSel = 2
    ' ''            Else
    ' ''                priceSel = 1
    ' ''            End If

    ' ''            'dt.Rows(i).Item("D14") = 10306
    ' ''            'dt.Rows(i).Item("D18") = "D"
    ' ''            ' dt.Rows(i).Item("D10") = 661696 '用戶號碼
    ' ''            ' dt.Rows(i).Item("D34") 本次抄表日
    ' ''            use_degree = dt.Rows(i).Item("D26")         '使用度數

    ' ''            dt68 = objAPPM04.GetAM68(dt.Rows(i).Item("D14"), dt.Rows(i).Item("D10")).Tables(0)
    ' ''            rtPrice1 = ""
    ' ''            rtPrice2 = ""
    ' ''            rtPrice3 = ""
    ' ''            rtPrice4 = ""
    ' ''            TempPrice2 = ""
    ' ''            TempPrice1 = ""
    ' ''            If dt68.Rows.Count > 0 Then

    ' ''                TempPrice = Trim(dt68.Rows(0).Item("am68_str0"))
    ' ''                Dim Temp() As String = TempPrice.Split("=")
    ' ''                TempPrice1 = Temp(1) & "=" & Temp(0)


    ' ''                Dim a() As String = Temp(0).Split(")")
    ' ''                Dim b() As String = a(0).Split("(")
    ' ''                Dim c() As String = b(1).Split("+")
    ' ''                Dim yymmdd As String = Left(dt.Rows(i).Item("D14"), 3) & dt.Rows(i).Item("D34")

    ' ''                dt66 = objAPPM04.GetAM66(yymmdd).Tables(0)
    ' ''                Dim ii As Integer
    ' ''                For ii = 0 To 3
    ' ''                    DPriceStr(ii) = ""
    ' ''                Next
    ' ''                Dim jj As Int16
    ' ''                jj = 0
    ' ''                For ii = c.Length - 1 To 0 Step -1 ' 0 To c.Length - 1
    ' ''                    Dim d() As String = c(jj).Split("*")

    ' ''                    DPriceStr(jj) = dt66.Rows(ii).Item("am66_adj_date") & "調價每度" & d(0) & "元"
    ' ''                    If jj > 2 Then
    ' ''                        Exit For
    ' ''                    End If
    ' ''                    jj = jj + 1
    ' ''                Next

    ' ''                'If dt68.Rows(0).Item("am68_gas_amt1") > 0 And dt68.Rows(0).Item("am68_gas_amt2") > 0 Then

    ' ''                TempPrice = Trim(dt68.Rows(0).Item("am68_str1"))
    ' ''                If TempPrice <> "" Then
    ' ''                    Dim Temp1() As String = TempPrice.Split("=")
    ' ''                    TempPrice = Trim(dt68.Rows(0).Item("am68_str2"))
    ' ''                    If TempPrice <> "" Then
    ' ''                        Dim Temp2() As String = TempPrice.Split("=")
    ' ''                        TempPrice2 = dt68.Rows(0).Item("am68_gas_amt1") - dt68.Rows(0).Item("am68_gas_amt2") & "=" & Temp1(0) & "-" & Temp2(0)
    ' ''                    Else
    ' ''                        TempPrice2 = Temp1(1) & "=" & Temp1(0)
    ' ''                    End If
    ' ''                Else
    ' ''                    TempPrice2 = ""
    ' ''                End If
    ' ''                'End  If

    ' ''                If Len(TempPrice1) > 44 Then
    ' ''                    rtPrice1 = Left(TempPrice1, 44)
    ' ''                    rtPrice2 = Right(TempPrice1, Len(TempPrice1) - 44)
    ' ''                    Flag44 = 2
    ' ''                Else
    ' ''                    rtPrice1 = TempPrice1
    ' ''                    rtPrice2 = ""
    ' ''                    Flag44 = 1
    ' ''                End If

    ' ''                If Len(TempPrice2) > 0 Then
    ' ''                    If Flag44 = 1 Then
    ' ''                        rtPrice2 = Left(TempPrice2, 44)
    ' ''                        If Len(TempPrice2) > 44 Then  '20140725
    ' ''                            TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
    ' ''                            rtPrice3 = Left(TempPrice2, 44)
    ' ''                            If Len(TempPrice2) > 44 Then
    ' ''                                TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
    ' ''                                rtPrice4 = TempPrice2
    ' ''                            Else
    ' ''                                rtPrice4 = ""
    ' ''                            End If
    ' ''                        End If

    ' ''                    Else
    ' ''                        rtPrice3 = Left(TempPrice2, 44)
    ' ''                        If Len(TempPrice2) > 44 Then
    ' ''                            TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
    ' ''                            rtPrice4 = Left(TempPrice2, 44)
    ' ''                        Else
    ' ''                            rtPrice4 = ""
    ' ''                        End If
    ' ''                    End If


    ' ''                End If

    ' ''            End If


    ' ''#If 0 Then


    ' ''            dt67 = objAPPM04.GetAM67(Left(dt.Rows(i).Item("D18"), 1), dt.Rows(i).Item("D14"), type).Tables(0)  '17=冊別,13=使用年月
    ' ''            rtPrice1 = ""
    ' ''            rtPrice2 = ""
    ' ''            If dt67.Rows.Count > 0 Then
    ' ''                For j = 0 To dt67.Rows.Count - 1
    ' ''                    If dt67.Rows(j).Item("am67_yymm") = dt67.Rows(j).Item("am67_org_yymm") Then
    ' ''                        If beginSw1 > 0 Then
    ' ''                            calString(0).outString = calString(0).outString & "+"
    ' ''                        End If
    ' ''                        If beginSw1 = 0 Then
    ' ''                            calString(0).outString = "("
    ' ''                            calString(0).totDays = dt67.Rows(j).Item("am67_use_days")
    ' ''                            beginSw1 = 1
    ' ''                        End If
    ' ''                        realPrice = 0
    ' ''                        If priceSel = 2 Then
    ' ''                            realPrice = dt67.Rows(j).Item("am67_adj_price2")
    ' ''                        Else
    ' ''                            realPrice = dt67.Rows(j).Item("am67_adj_price1")
    ' ''                        End If
    ' ''                        calString(0).calResult = calString(0).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                        calString(0).outString = calString(0).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")

    ' ''                    Else
    ' ''                        If Trim(dt67.Rows(j).Item("am67_am67_mark")) = "*" Then
    ' ''                            If beginSw2 > 0 Then
    ' ''                                calString(1).outString = calString(1).outString & "+"
    ' ''                            End If
    ' ''                            If beginSw2 = 0 Then
    ' ''                                calString(1).outString = "("
    ' ''                                calString(1).totDays = dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                                beginSw2 = 1
    ' ''                            End If
    ' ''                            realPrice = 0
    ' ''                            If priceSel = 2 Then
    ' ''                                realPrice = dt67.Rows(j).Item("am67_adj_price2")
    ' ''                            Else
    ' ''                                realPrice = dt67.Rows(j).Item("am67_adj_price1")
    ' ''                            End If
    ' ''                            calString(1).calResult = calString(1).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                            calString(1).outString = calString(1).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                        Else
    ' ''                            If beginSw3 > 0 Then
    ' ''                                calString(2).outString = calString(2).outString & "+"
    ' ''                            End If
    ' ''                            If beginSw3 = 0 Then
    ' ''                                calString(2).outString = "("
    ' ''                                calString(2).totDays = dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                                beginSw3 = 1
    ' ''                            End If
    ' ''                            realPrice = 0
    ' ''                            If priceSel = 2 Then
    ' ''                                realPrice = dt67.Rows(j).Item("am67_adj_price2")
    ' ''                            Else
    ' ''                                realPrice = dt67.Rows(j).Item("am67_adj_price1")
    ' ''                            End If
    ' ''                            calString(2).calResult = calString(2).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
    ' ''                            calString(2).outString = calString(2).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")

    ' ''                        End If
    ' ''                    End If

    ' ''                Next
    ' ''                L_amt = calString(0).calResult * use_degree / calString(0).totDays
    ' ''                Curr_amt = calString(0).calResult * use_degree / calString(0).totDays
    ' ''                L_amt = L_amt / 100
    ' ''                Curr_amt = Curr_amt / 100 + 0.5
    ' ''                L_amt = Int(Curr_amt)
    ' ''                rtPrice1 = Trim(calString(0).outString) & ")"
    ' ''                rtPrice1 = rtPrice1 & "*" & Str(use_degree) & "/" & Str(calString(0).totDays) & "=" & Str(L_amt)


    ' ''            End If
    ' ''#End If
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text21")
    ' ''            'RptTextObj.Text = rtPrice1
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text22")
    ' ''            ' RptTextObj.Text = rtPrice2

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr1")
    ' ''            RptTextObj.Text = rtPrice1
    ' ''            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr2")
    ' ''            ' RptTextObj.Text = rtPrice2
    ' ''            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr3")
    ' ''            ' RptTextObj.Text = rtPrice3
    ' ''            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr4")
    ' ''            '  RptTextObj.Text = rtPrice4


    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice1")
    ' ''            RptTextObj.Text = DPriceStr(0)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice2")
    ' ''            RptTextObj.Text = DPriceStr(1)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice3")
    ' ''            RptTextObj.Text = DPriceStr(2)
    ' ''            ' RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice4")
    ' ''            ' RptTextObj.Text = DPriceStr(3)

    ' ''            '2014-03-26 Yeh End

    ' ''            ADay = rtPrice1.Split("/")
    ' ''            'ADay() = Right(rtPrice1, 2)
    ' ''            TDay = Left(ADay(1), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("pdays")
    ' ''            RptTextObj.Text = TDay
    ' ''#If 1 Then
    ' ''            If IsDBNull(dt.Rows(i).Item("D50")) = False Then
    ' ''                If Trim(dt.Rows(i).Item("D50")) <> "" Then
    ' ''                    invno = Left(dt.Rows(i).Item("D50"), 30)
    ' ''                    invNum = Mid(dt.Rows(i).Item("D50"), 31, 10)
    ' ''                    tempyy = Mid(dt.Rows(i).Item("D50"), 41, 3)
    ' ''                    tempmms = Mid(dt.Rows(i).Item("D50"), 44, 2)
    ' ''                    tempmme = Mid(dt.Rows(i).Item("D50"), 46, 2)
    ' ''                    invsdate = Mid(dt.Rows(i).Item("D50"), 48, 7)
    ' ''                    invedate = Mid(dt.Rows(i).Item("D50"), 55, 7)
    ' ''                    invsdate = Left(invsdate, 3) & "/" & Mid(invsdate, 4, 2) & "/" & Right(invsdate, 2)
    ' ''                    invedate = Left(invedate, 3) & "/" & Mid(invedate, 4, 2) & "/" & Right(invedate, 2)
    ' ''                    ax19amt = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 64, 7))
    ' ''                    sw1 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 71, 7))
    ' ''                    sw2 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 78, 7))
    ' ''                    pp1 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 85, 7))
    ' ''                    pp2 = Conversion.Val(Mid(dt.Rows(i).Item("D50"), 92, 7))
    ' ''                Else
    ' ''                    invno = ""
    ' ''                    invNum = ""
    ' ''                    tempyy = 0
    ' ''                    tempmms = 0
    ' ''                    tempmme = 0
    ' ''                    invsdate = ""
    ' ''                    invedate = ""
    ' ''                End If
    ' ''            Else
    ' ''#End If
    ' ''                invno = ""
    ' ''                invNum = ""
    ' ''                tempyy = 0
    ' ''                tempmms = 0
    ' ''                tempmme = 0
    ' ''                invsdate = ""
    ' ''                invedate = ""
    ' ''            End If
    ' ''            If tempyy = 0 Then
    ' ''                invyy = ""
    ' ''            Else
    ' ''                invyy = tempyy
    ' ''            End If
    ' ''            If tempmms = 0 Then
    ' ''                invmms = ""
    ' ''            Else
    ' ''                invmms = tempmms
    ' ''            End If
    ' ''            If tempmme = 0 Then
    ' ''                invmme = ""
    ' ''            Else
    ' ''                invmme = tempmme
    ' ''            End If

    ' ''            '******20160217  bacom修**************************


    ' ''            If Trim(invno) <> "" And Conversion.Val(dt.Rows(i).Item("D7")) <> 0 Then
    ' ''                myimg = Code128Rendering.MakeBarcodeImage(invno, 1, True)
    ' ''                myimg.Save(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
    ' ''                simg = Code128Rendering.MakeBarcodeImage("ED0022", 1, True)
    ' ''                simg.Save(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
    ' ''            Else
    ' ''                FileIO.FileSystem.CopyFile(Server.MapPath("/images/barc.jpg"), Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
    ' ''                FileIO.FileSystem.CopyFile(Server.MapPath("/images/ED0022.jpg"), Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
    ' ''            End If

    ' ''            ' ''If Trim(invno) <> "" And Conversion.Val(dt.Rows(i).Item("D7")) <> 0 Then
    ' ''            ' ''    myimg = Code128Rendering.MakeBarcodeImage(invno, 1, True)
    ' ''            ' ''    myimg.Save("C:\img\barc.jpg")
    ' ''            ' ''    simg = Code128Rendering.MakeBarcodeImage("ED0022", 1, True)
    ' ''            ' ''    simg.Save("C:\img\ed0022.jpg")
    ' ''            ' ''Else
    ' ''            ' ''    FileIO.FileSystem.CopyFile("C:\img\img1\barc.jpg", "C:\img\barc.jpg")
    ' ''            ' ''    FileIO.FileSystem.CopyFile("C:\img\img1\ED0022.jpg", "C:\img\ED0022.jpg")
    ' ''            ' ''End If


    ' ''            '******20160217  bacom修**************************



    ' ''            invno = Left(invno, 5) & " " & Mid(invno, 6, 10) & " " & Mid(invno, 16, Len(invno))

    ' ''            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode1Path").Text = """" & Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg") & """"
    ' ''            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode2Path").Text = """" & Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg") & """"

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no11")
    ' ''            RptTextObj.Text = invno

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("yyy")
    ' ''            RptTextObj.Text = invyy

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("mm1")
    ' ''            RptTextObj.Text = invmms

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("mm2")
    ' ''            RptTextObj.Text = invmme

    ' ''            invNum = Left(invNum, 2) & "-" & Mid(invNum, 3, Len(invNum))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no2")
    ' ''            RptTextObj.Text = invNum

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text40")
    ' ''            RptTextObj.Text = invsdate

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text97")
    ' ''            RptTextObj.Text = invedate

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text102")
    ' ''            RptTextObj.Text = ax19amt

    ' ''            If sw1 <> 0 Then
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw2")
    ' ''                RptTextObj.Text = "2.1開關:      " & sw1
    ' ''            End If
    ' ''            If sw2 <> 0 Then
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw4")
    ' ''                RptTextObj.Text = "3.6開關:      " & sw2
    ' ''            End If
    ' ''            If pp1 <> 0 Then
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_pp1")
    ' ''                RptTextObj.Text = "熱水器銜接管: " & pp1
    ' ''            End If
    ' ''            If pp2 <> 0 Then
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_pp2")
    ' ''                RptTextObj.Text = "瓦斯爐銜接管: " & pp2
    ' ''            End If
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lDate")
    ' ''            If Trim(dt.Rows(i).Item("D16")) <> "" Then
    ' ''                RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) '    Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
    ' ''                RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
    ' ''            Else
    ' ''                RptTextObj.Text = ""
    ' ''            End If
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lusedegree")
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26")) ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lyear")
    ' ''            RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lmonth") '
    ' ''            RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("raddress")                     '裝置地址
    ' ''            RptTextObj.Text = Trim(dt.Rows(i).Item("D37")) 'dt.Rows(i).Item("D23")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text94")                     '寶號
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D44") '通訊地址
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rid")                          '統一編號
    ' ''            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19"))
    ' ''            DetailLog(19) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rlightno")                     '燈別
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D21")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtotal")                       '實收總金額
    ' ''            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) ' & "." & ReRight(dt.Rows(i).Item("D7"), 2)
    ' ''            DetailLog(18) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpayment")                     '代繳帳號
    ' ''            RptTextObj.Text = Left(dt.Rows(i).Item("D6"), 6) & "XXXX" & Right(dt.Rows(i).Item("D6"), 4)
    ' ''            DetailLog(20) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbnum") '
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D18")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lhouseno") '
    ' ''            RptTextObj.Text = Right("0000000" & dt.Rows(i).Item("D10"), 7) '
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lname") '
    ' ''            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lcompany") '
    ' ''            RptTextObj.Text = "" ' Trim(dt.Rows(i).Item("D22"))

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthedegree") '
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lpredegree") '
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lvol") '
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) ' ReVal(Trim(dt.Rows(i).Item("D28")))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbasic") '
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D40"))) 'ReVal(Trim(dt.Rows(i).Item("D29")))

    ' ''            If Trim(dt.Rows(i).Item("D30")) = "-" Then
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text93") '
    ' ''                RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D31")) 'dt.Rows(i).Item("D30") &
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount") '
    ' ''                RptTextObj.Text = "0" 'dt.Rows(i).Item("D30") &
    ' ''            Else
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount") '
    ' ''                RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D31")) 'dt.Rows(i).Item("D30") &
    ' ''                RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text93") '
    ' ''                RptTextObj.Text = "0" 'dt.Rows(i).Item("D30") &
    ' ''            End If
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lother") '
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltax") '
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
    ' ''            FileName = Trim(dt.Rows(i).Item("D10")) & Trim(dt.Rows(i).Item("D14"))
    ' ''#If 0 Then
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine1")
    ' ''            RptTextObj.Text = ADLong(1)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine2")
    ' ''            RptTextObj.Text = ADLong(2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine3")
    ' ''            RptTextObj.Text = ADLong(3)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine1")
    ' ''            RptTextObj.Text = ADShort(1)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine2")
    ' ''            RptTextObj.Text = ADShort(2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine3")
    ' ''            RptTextObj.Text = ADShort(3)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine4")
    ' ''            RptTextObj.Text = ADShort(4)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine5")
    ' ''            RptTextObj.Text = ADShort(5)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine6")
    ' ''            RptTextObj.Text = ADShort(6)

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lyear")
    ' ''            'dt.Rows(i).Item("D14") = "10001"
    ' ''            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
    ' ''                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
    ' ''                    RptTextObj.Text = Format(Left(dt.Rows(i).Item("D14"), 3) - 1, "000") & " - " & Left(dt.Rows(i).Item("D14"), 3)
    ' ''                Else
    ' ''                    RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''                End If
    ' ''            Else
    ' ''                RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''            End If

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lmonth")

    ' ''            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
    ' ''                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
    ' ''                    RptTextObj.Text = "12 - " & Right(dt.Rows(i).Item("D14"), 2)
    ' ''                Else
    ' ''                    RptTextObj.Text = Format(Right(dt.Rows(i).Item("D14"), 2) - 1, "00") & " - " & Right(dt.Rows(i).Item("D14"), 2)
    ' ''                End If
    ' ''            Else
    ' ''                RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)
    ' ''            End If

    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbnum")
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D18")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lhouseno")
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D10")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lname")
    ' ''            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lcompany")
    ' ''            RptTextObj.Text = "" ' Trim(dt.Rows(i).Item("D22"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthemonth")
    ' ''            RptTextObj.Text = Left(dt.Rows(i).Item("D34"), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltheday")
    ' ''            RptTextObj.Text = Right(dt.Rows(i).Item("D34"), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lnextmonth")
    ' ''            RptTextObj.Text = Left(dt.Rows(i).Item("D35"), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lnextday")
    ' ''            RptTextObj.Text = Right(dt.Rows(i).Item("D35"), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthedegree")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lpredegree")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lusedegree")
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26")) ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lprice")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D27"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lvol")
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) 'Conversion.Val(Trim(dt.Rows(i).Item("D28")))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbasic")
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D40"))) ' Conversion.Val(Trim(dt.Rows(i).Item("D29")))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lgas")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D41"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount")
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D30") & Conversion.Val(dt.Rows(i).Item("D31"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lother")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lsubtotal")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D32"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltax")
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltotal")
    ' ''            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) '& "." & Right(dt.Rows(i).Item("D7"), 2)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lid")
    ' ''            ' RptTextObj.Text = dt.Rows(i).Item("D8") 統一編號應為客戶非欣欣的
    ' ''            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19")) ' dt.Rows(i).Item("D32")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lDate")
    ' ''            If IsDBNull(dt.Rows(i).Item("D16")) Then
    ' ''                RptTextObj.Text = ""
    ' ''            Else
    ' ''                If Trim(dt.Rows(i).Item("D16")) <> "" Then
    ' ''                    RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) '    Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
    ' ''                    'RptTextObj.Text = Format(Now, "yyyy/MM/dd")
    ' ''                    RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
    ' ''                Else
    ' ''                    RptTextObj.Text = ""
    ' ''                End If
    ' ''            End If
    ' ''            FileName = Trim(dt.Rows(i).Item("D10")) & Trim(dt.Rows(i).Item("D14"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ryear")                        '收費年

    ' ''            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
    ' ''                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
    ' ''                    RptTextObj.Text = Format(Left(dt.Rows(i).Item("D14"), 3) - 1, "000") & " - " & Left(dt.Rows(i).Item("D14"), 3)
    ' ''                Else
    ' ''                    RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''                End If
    ' ''            Else
    ' ''                RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''            End If

    ' ''            'RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rmonth")                       '收費月

    ' ''            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
    ' ''                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
    ' ''                    RptTextObj.Text = "12 - " & Right(dt.Rows(i).Item("D14"), 2)
    ' ''                Else
    ' ''                    RptTextObj.Text = Format(Right(dt.Rows(i).Item("D14"), 2) - 1, "00") & " - " & Right(dt.Rows(i).Item("D14"), 2)
    ' ''                End If
    ' ''            Else
    ' ''                RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)
    ' ''            End If


    ' ''            DetailLog(1) = dt.Rows(i).Item("D14")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rbnum")                        '冊別
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D18")
    ' ''            DetailLog(2) = dt.Rows(i).Item("D18")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rhouseno")                     '用戶號碼
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D10")
    ' ''            DetailLog(3) = dt.Rows(i).Item("D10")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rname")                        '先生
    ' ''            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
    ' ''            DetailLog(4) = dt.Rows(i).Item("D36")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rcompany")                     '寶號
    ' ''            RptTextObj.Text = Trim(dt.Rows(i).Item("D37")) '通訊地址
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rthemonth")                    '本次抄表月
    ' ''            'RptTextObj.Text = Left(dt.Rows(i).Item("D34"), 2)
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtheday")                      '本次抄表日
    ' ''            'RptTextObj.Text = Right(dt.Rows(i).Item("D34"), 2)
    ' ''            DetailLog(5) = dt.Rows(i).Item("D34")
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnextmonth")                   '下次抄表月
    ' ''            'RptTextObj.Text = Left(dt.Rows(i).Item("D35"), 2)
    ' ''            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnextday")                     '下次抄表日
    ' ''            'RptTextObj.Text = Right(dt.Rows(i).Item("D35"), 2)
    ' ''            DetailLog(6) = dt.Rows(i).Item("D35")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rthedegree")                   '本月抄表度
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
    ' ''            DetailLog(7) = dt.Rows(i).Item("D22")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpredegree")                   '上月抄表度
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
    ' ''            DetailLog(8) = dt.Rows(i).Item("D23")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rusedegree")                   '使用度數
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26"))  ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E
    ' ''            DetailLog(9) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rprice")                       '單價
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D27"))
    ' ''            DetailLog(10) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rvol")                         '從量費
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) 'Conversion.Val(Trim(dt.Rows(i).Item("D28")))
    ' ''            DetailLog(11) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rbasic")                       '基本費
    ' ''            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D40"))) ' Conversion.Val(Trim(dt.Rows(i).Item("D29")))
    ' ''            DetailLog(12) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rgas")                         '天然氣費
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D41"))
    ' ''            DetailLog(13) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ramount")                      '追退金額
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D30") & Conversion.Val(dt.Rows(i).Item("D31"))
    ' ''            DetailLog(14) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rother")                       '其他費用
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
    ' ''            DetailLog(15) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rsubtotal")                    '小計
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D32"))
    ' ''            DetailLog(16) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtax")                         '營業稅
    ' ''            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
    ' ''            DetailLog(17) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtotal")                       '實收總金額
    ' ''            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) '& "." & Right(dt.Rows(i).Item("D7"), 2)
    ' ''            DetailLog(18) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rid")                          '統一編號
    ' ''            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19")) ' dt.Rows(i).Item("D32")
    ' ''            DetailLog(19) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rlightno")                     '燈別
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D21")
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpayment")                     '代繳帳號
    ' ''            RptTextObj.Text = Left(dt.Rows(i).Item("D6"), 6) & "XXXX" & Right(dt.Rows(i).Item("D6"), 4)
    ' ''            DetailLog(20) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("raddress")                     '裝置地址
    ' ''            RptTextObj.Text = dt.Rows(i).Item("D44") 'dt.Rows(i).Item("D23")
    ' ''            DetailLog(21) = RptTextObj.Text
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnum")                         '代碼
    ' ''            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D43")), "", dt.Rows(i).Item("D43"))
    ' ''            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rDate")
    ' ''            If IsDBNull(dt.Rows(i).Item("D16")) Then
    ' ''                RptTextObj.Text = ""
    ' ''            Else
    ' ''                If Trim(dt.Rows(i).Item("D16")) <> "" Then
    ' ''                    RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) ' Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
    ' ''                    'RptTextObj.Text = Format(Now, "yyyy/MM/dd")
    ' ''                    RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
    ' ''                Else
    ' ''                    RptTextObj.Text = ""
    ' ''                End If
    ' ''            End If
    ' ''            'thisRptDoc.SaveAs(PDFPath & FileName & ".rpt", True)
    ' ''            ' DateTemp = Format(Now, "yyyyMMddHHmmss")
    ' ''            'FileIO.FileSystem.CreateDirectory("C:\RPT\" & DateTemp)

    ' ''#End If
    ' ''            thisRptDoc.Refresh()
    ' ''            'If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/barc.jpg")) = True Then
    ' ''            '    System.IO.File.Delete(Server.MapPath("./zRecord/barc.jpg"))
    ' ''            'End If
    ' ''            'If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/ED0022.jpg")) = True Then
    ' ''            '    System.IO.File.Delete(Server.MapPath("./zRecord/ED0022.jpg"))
    ' ''            'End If
    ' ''            'If FileIO.FileSystem.DirectoryExists(Server.MapPath("./zRecord/OK")) = True Then
    ' ''            '    System.IO.Directory.Delete(Server.MapPath("./zRecord/OK"))
    ' ''            'End If
    ' ''            If FileIO.FileSystem.DirectoryExists("c:/img/OK") = True Then
    ' ''                System.IO.Directory.Delete("c:/img/OK")
    ' ''            End If

    ' ''            System.IO.Directory.CreateDirectory("C:\RPT\" & DateTemp)

    ' ''            thisRptDoc.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat, "c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")

    ' ''            reader = New PdfReader("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
    ' ''            stream = CType(New FileStream("c:\RPT\" & DateTemp & "\" & FileName & ".pdf", FileMode.Append), Stream)
    ' ''            asc = New System.Text.ASCIIEncoding
    ' ''            '*****20140929_Bacom**********************************************
    ' ''            Dim cancelPWD As Boolean = False
    ' ''            cancelPWD = GetData.GetPDFCancelPWD(dt.Rows(i)(50))
    ' ''            If cancelPWD Then
    ' ''                by = asc.GetBytes("", 0, 0)
    ' ''            Else
    ' ''                by = asc.GetBytes(dt.Rows(i)(50), 0, dt.Rows(i)(50).Length)
    ' ''            End If
    ' ''            'by = asc.GetBytes(dt.Rows(i)(50), 0, dt.Rows(i)(50).Length)
    ' ''            '*****************************************************************
    ' ''            iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, stream, by, by, iTextSharp.text.pdf.PdfWriter.ALLOW_PRINTING, True)
    ' ''            System.IO.File.Delete("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
    ' ''            ReString = "c:\RPT\" & DateTemp & "\" & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i).Item("wm_email")) & "|" & "c:\RPT\" & DateTemp
    ' ''        Next
    ' ''        thisRptDoc.Close()
    ' ''        thisRptDoc = Nothing
    ' ''        ReportList = ReString 'PDFPath & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i)(49))

    ' ''        '******************20160217 bacom修************************
    ' ''        If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg")) = True Then
    ' ''            System.IO.File.Delete(Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
    ' ''        End If
    ' ''        If FileIO.FileSystem.FileExists(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg")) = True Then
    ' ''            System.IO.File.Delete(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))
    ' ''        End If
    ' ''        '******************20160217 bacom修************************

    ' ''    End Function
#End Region
#If 0 Then
#Region "ReportList　將資料逐筆填到報表內,再加密"
    Function ReportList(ByVal dt As DataTable, ByVal Val As Integer) As String
        Dim i As Integer
        Dim RptTextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim FileName As String
        Dim ReString As String
        Dim thisRptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim reader As PdfReader
        Dim stream As Stream
        Dim DateTemp As String = ""
        Dim asc As ASCIIEncoding
        Dim by() As Byte = New Byte(10) {}
        Dim logoninfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim thisPath As String = "C:\Inetpub\wwwroot\"
        Dim int_Exit_Flag As Integer = 0
        Dim int_Result As Integer = 0
        Dim Sendi As Integer
        Dim ADLong(3) As String
        Dim ADShort(6) As String
        Dim dt1 As New DataTable
        Dim GetData As New webmemberDAO

        '2014-03-26 Yeh Begin
        Dim calString(3) As calStr_str
        Dim realPrice As Integer
        Dim priceSel As Integer
        Dim j As Integer
        Dim TempPrice As String
        Dim TempPrice1 As String
        Dim TempPrice2 As String
        Dim rtPrice1 As String
        Dim rtPrice2 As String
        Dim rtPrice3 As String
        Dim rtPrice4 As String
        Dim DatePriceStr1 As String
        Dim DatePriceStr2 As String
        Dim DatePriceStr3 As String
        Dim DatePriceStr4 As String
        Dim DPriceStr(4) As String
        Dim Flag44 As Integer
        Dim objAPPM04 As New APPM04DAO
        Dim dt66 As DataTable
        Dim dt67 As DataTable
        Dim dt68 As DataTable
        Dim am04_rcp_no As Integer
        Dim type As String
        Dim beginSw1 As Integer = 0
        Dim beginSw2 As Integer = 0
        Dim beginSw3 As Integer = 0
        Dim use_degree As Integer
        Dim L_amt As Long
        Dim Curr_amt As Double
        Dim L_amt1 As Long
        Dim Curr_amt1 As Double
        Dim L_amt2 As Long
        Dim Curr_amt2 As Double
        rtPrice1 = "" ' "2095=(20.50*4+21.00*23+21.50*1)*100/28"
        rtPrice2 = "" ' "補正金額13=(20*8 + 20.5*23)*90/31-(20*8+20.3*23*90/31"
        '2014-03-26 Yeh End

        dt1 = GetData.GetReceiptData("Select * from  Receipt_notice ")
        If dt1.Rows.Count > 0 Then
            For i = 0 To dt1.Rows.Count - 1
                ADShort(dt1.Rows(i)(2)) = dt1.Rows(i)(1)
            Next
        End If
        'For i = 1 To 3
        'ADLong(i) = ReadLongAD(i)
        'Next
        ReadLongAD(0, ADLong)
        'thisRptDoc.Load(thisPath + "SupShowLogoR-2.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        thisRptDoc.Refresh()
        DateTemp = Format(Now, "yyyyMMddHHmmss")
        For i = 0 To dt.Rows.Count - 1

            '2014-03-26 Yeh Begin
            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then '燈別
                type = "2"
            Else
                type = "1"
            End If
            If Trim(dt.Rows(i).Item("D19")) <> "" Then  '統編
                priceSel = 2
            Else
                priceSel = 1
            End If

            'dt.Rows(i).Item("D14") = 10306
            'dt.Rows(i).Item("D18") = "D"
            ' dt.Rows(i).Item("D10") = 661696 '用戶號碼
            ' dt.Rows(i).Item("D34") 本次抄表日
            use_degree = dt.Rows(i).Item("D26")         '使用度數

            dt68 = objAPPM04.GetAM68(dt.Rows(i).Item("D14"), dt.Rows(i).Item("D10")).Tables(0)
            rtPrice1 = ""
            rtPrice2 = ""
            rtPrice3 = ""
            rtPrice4 = ""
            TempPrice2 = ""
            TempPrice1 = ""
            If dt68.Rows.Count > 0 Then

                TempPrice = Trim(dt68.Rows(0).Item("am68_str0"))
                Dim Temp() As String = TempPrice.Split("=")
                TempPrice1 = Temp(1) & "=" & Temp(0)


                Dim a() As String = Temp(0).Split(")")
                Dim b() As String = a(0).Split("(")
                Dim c() As String = b(1).Split("+")
                Dim yymmdd As String = Left(dt.Rows(i).Item("D14"), 3) & dt.Rows(i).Item("D34")

                dt66 = objAPPM04.GetAM66(yymmdd).Tables(0)
                Dim ii As Integer
                For ii = 0 To 3
                    DPriceStr(ii) = ""
                Next
                Dim jj As Int16
                jj = 0
                For ii = c.Length - 1 To 0 Step -1 ' 0 To c.Length - 1
                    Dim d() As String = c(jj).Split("*")

                    DPriceStr(jj) = dt66.Rows(ii).Item("am66_adj_date") & "調價每度" & d(0) & "元"
                    If jj > 2 Then
                        Exit For
                    End If
                    jj = jj + 1
                Next

                'If dt68.Rows(0).Item("am68_gas_amt1") > 0 And dt68.Rows(0).Item("am68_gas_amt2") > 0 Then

                TempPrice = Trim(dt68.Rows(0).Item("am68_str1"))
                If TempPrice <> "" Then
                    Dim Temp1() As String = TempPrice.Split("=")
                    TempPrice = Trim(dt68.Rows(0).Item("am68_str2"))
                    If TempPrice <> "" Then
                        Dim Temp2() As String = TempPrice.Split("=")
                        TempPrice2 = dt68.Rows(0).Item("am68_gas_amt1") - dt68.Rows(0).Item("am68_gas_amt2") & "=" & Temp1(0) & "-" & Temp2(0)
                    Else
                        TempPrice2 = Temp1(1) & "=" & Temp1(0)
                    End If
                Else
                    TempPrice2 = ""
                End If
                'End  If

                If Len(TempPrice1) > 44 Then
                    rtPrice1 = Left(TempPrice1, 44)
                    rtPrice2 = Right(TempPrice1, Len(TempPrice1) - 44)
                    Flag44 = 2
                Else
                    rtPrice1 = TempPrice1
                    rtPrice2 = ""
                    Flag44 = 1
                End If

                If Len(TempPrice2) > 0 Then
                    If Flag44 = 1 Then
                        rtPrice2 = Left(TempPrice2, 44)
                        If Len(TempPrice2) > 44 Then  '20140725
                            TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
                            rtPrice3 = Left(TempPrice2, 44)
                            If Len(TempPrice2) > 44 Then
                                TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
                                rtPrice4 = TempPrice2
                            Else
                                rtPrice4 = ""
                            End If
                        End If

                    Else
                        rtPrice3 = Left(TempPrice2, 44)
                        If Len(TempPrice2) > 44 Then
                            TempPrice2 = Right(TempPrice2, Len(TempPrice2) - 44)
                            rtPrice4 = Left(TempPrice2, 44)
                        Else
                            rtPrice4 = ""
                        End If
                    End If


                End If

            End If


#If 0 Then


            dt67 = objAPPM04.GetAM67(Left(dt.Rows(i).Item("D18"), 1), dt.Rows(i).Item("D14"), type).Tables(0)  '17=冊別,13=使用年月
            rtPrice1 = ""
            rtPrice2 = ""
            If dt67.Rows.Count > 0 Then
                For j = 0 To dt67.Rows.Count - 1
                    If dt67.Rows(j).Item("am67_yymm") = dt67.Rows(j).Item("am67_org_yymm") Then
                        If beginSw1 > 0 Then
                            calString(0).outString = calString(0).outString & "+"
                        End If
                        If beginSw1 = 0 Then
                            calString(0).outString = "("
                            calString(0).totDays = dt67.Rows(j).Item("am67_use_days")
                            beginSw1 = 1
                        End If
                        realPrice = 0
                        If priceSel = 2 Then
                            realPrice = dt67.Rows(j).Item("am67_adj_price2")
                        Else
                            realPrice = dt67.Rows(j).Item("am67_adj_price1")
                        End If
                        calString(0).calResult = calString(0).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
                        calString(0).outString = calString(0).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")

                    Else
                        If Trim(dt67.Rows(j).Item("am67_am67_mark")) = "*" Then
                            If beginSw2 > 0 Then
                                calString(1).outString = calString(1).outString & "+"
                            End If
                            If beginSw2 = 0 Then
                                calString(1).outString = "("
                                calString(1).totDays = dt67.Rows(j).Item("am67_use_tot_days")
                                beginSw2 = 1
                            End If
                            realPrice = 0
                            If priceSel = 2 Then
                                realPrice = dt67.Rows(j).Item("am67_adj_price2")
                            Else
                                realPrice = dt67.Rows(j).Item("am67_adj_price1")
                            End If
                            calString(1).calResult = calString(1).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
                            calString(1).outString = calString(1).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")
                        Else
                            If beginSw3 > 0 Then
                                calString(2).outString = calString(2).outString & "+"
                            End If
                            If beginSw3 = 0 Then
                                calString(2).outString = "("
                                calString(2).totDays = dt67.Rows(j).Item("am67_use_tot_days")
                                beginSw3 = 1
                            End If
                            realPrice = 0
                            If priceSel = 2 Then
                                realPrice = dt67.Rows(j).Item("am67_adj_price2")
                            Else
                                realPrice = dt67.Rows(j).Item("am67_adj_price1")
                            End If
                            calString(2).calResult = calString(2).calResult + realPrice * dt67.Rows(j).Item("am67_use_tot_days")
                            calString(2).outString = calString(2).outString & realPrice / 100 & "*" & dt67.Rows(j).Item("am67_use_tot_days")

                        End If
                    End If

                Next
                L_amt = calString(0).calResult * use_degree / calString(0).totDays
                Curr_amt = calString(0).calResult * use_degree / calString(0).totDays
                L_amt = L_amt / 100
                Curr_amt = Curr_amt / 100 + 0.5
                L_amt = Int(Curr_amt)
                rtPrice1 = Trim(calString(0).outString) & ")"
                rtPrice1 = rtPrice1 & "*" & Str(use_degree) & "/" & Str(calString(0).totDays) & "=" & Str(L_amt)


            End If
#End If
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text21")
            'RptTextObj.Text = rtPrice1
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Text22")
            ' RptTextObj.Text = rtPrice2

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr1")
            RptTextObj.Text = rtPrice1
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr2")
            RptTextObj.Text = rtPrice2
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr3")
            RptTextObj.Text = rtPrice3
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr4")
            RptTextObj.Text = rtPrice4


            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice1")
            RptTextObj.Text = DPriceStr(0)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice2")
            RptTextObj.Text = DPriceStr(1)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice3")
            RptTextObj.Text = DPriceStr(2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rUpPrice4")
            RptTextObj.Text = DPriceStr(3)

            '2014-03-26 Yeh End




            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine1")
            RptTextObj.Text = ADLong(1)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine2")
            RptTextObj.Text = ADLong(2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine3")
            RptTextObj.Text = ADLong(3)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine1")
            RptTextObj.Text = ADShort(1)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine2")
            RptTextObj.Text = ADShort(2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine3")
            RptTextObj.Text = ADShort(3)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine4")
            RptTextObj.Text = ADShort(4)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine5")
            RptTextObj.Text = ADShort(5)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdSLine6")
            RptTextObj.Text = ADShort(6)

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lyear")
            'dt.Rows(i).Item("D14") = "10001"
            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
                    RptTextObj.Text = Format(Left(dt.Rows(i).Item("D14"), 3) - 1, "000") & " - " & Left(dt.Rows(i).Item("D14"), 3)
                Else
                    RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
                End If
            Else
                RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
            End If

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lmonth")

            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
                    RptTextObj.Text = "12 - " & Right(dt.Rows(i).Item("D14"), 2)
                Else
                    RptTextObj.Text = Format(Right(dt.Rows(i).Item("D14"), 2) - 1, "00") & " - " & Right(dt.Rows(i).Item("D14"), 2)
                End If
            Else
                RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)
            End If

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbnum")
            RptTextObj.Text = dt.Rows(i).Item("D18")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lhouseno")
            RptTextObj.Text = dt.Rows(i).Item("D10")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lname")
            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lcompany")
            RptTextObj.Text = "" ' Trim(dt.Rows(i).Item("D22"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthemonth")
            RptTextObj.Text = Left(dt.Rows(i).Item("D34"), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltheday")
            RptTextObj.Text = Right(dt.Rows(i).Item("D34"), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lnextmonth")
            RptTextObj.Text = Left(dt.Rows(i).Item("D35"), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lnextday")
            RptTextObj.Text = Right(dt.Rows(i).Item("D35"), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lthedegree")
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lpredegree")
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lusedegree")
            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26")) ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lprice")
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D27"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lvol")
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) 'Conversion.Val(Trim(dt.Rows(i).Item("D28")))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lbasic")
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i)(39))) ' Conversion.Val(Trim(dt.Rows(i).Item("D29")))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lgas")
            RptTextObj.Text = Conversion.Val(dt.Rows(i)(40))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lamount")
            RptTextObj.Text = dt.Rows(i).Item("D30") & Conversion.Val(dt.Rows(i).Item("D31"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lother")
            RptTextObj.Text = Conversion.Val(dt.Rows(i)(41))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lsubtotal")
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D32"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltax")
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltotal")
            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) '& "." & Right(dt.Rows(i).Item("D7"), 2)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lid")
            ' RptTextObj.Text = dt.Rows(i).Item("D8") 統一編號應為客戶非欣欣的
            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19")) ' dt.Rows(i).Item("D32")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lDate")
            If IsDBNull(dt.Rows(i).Item("D16")) Then
                RptTextObj.Text = ""
            Else
                If Trim(dt.Rows(i).Item("D16")) <> "" Then
                    RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) '    Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
                    'RptTextObj.Text = Format(Now, "yyyy/MM/dd")
                    RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
                Else
                    RptTextObj.Text = ""
                End If
            End If
            FileName = Trim(dt.Rows(i).Item("D10")) & Trim(dt.Rows(i).Item("D14"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ryear")                        '收費年

            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
                    RptTextObj.Text = Format(Left(dt.Rows(i).Item("D14"), 3) - 1, "000") & " - " & Left(dt.Rows(i).Item("D14"), 3)
                Else
                    RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
                End If
            Else
                RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
            End If

            'RptTextObj.Text = Left(dt.Rows(i).Item("D14"), 3)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rmonth")                       '收費月

            If Right(dt.Rows(i).Item("D21"), 1) = "A" Or Right(dt.Rows(i).Item("D21"), 1) = "B" Then
                If Right(dt.Rows(i).Item("D14"), 2) = "01" Then
                    RptTextObj.Text = "12 - " & Right(dt.Rows(i).Item("D14"), 2)
                Else
                    RptTextObj.Text = Format(Right(dt.Rows(i).Item("D14"), 2) - 1, "00") & " - " & Right(dt.Rows(i).Item("D14"), 2)
                End If
            Else
                RptTextObj.Text = Right(dt.Rows(i).Item("D14"), 2)
            End If


            DetailLog(1) = dt.Rows(i).Item("D14")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rbnum")                        '冊別
            RptTextObj.Text = dt.Rows(i).Item("D18")
            DetailLog(2) = dt.Rows(i).Item("D18")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rhouseno")                     '用戶號碼
            RptTextObj.Text = dt.Rows(i).Item("D10")
            DetailLog(3) = dt.Rows(i).Item("D10")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rname")                        '先生
            RptTextObj.Text = Trim(dt.Rows(i).Item("D36"))
            DetailLog(4) = dt.Rows(i).Item("D36")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rcompany")                     '寶號
            RptTextObj.Text = Trim(dt.Rows(i).Item("D37")) '通訊地址
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rthemonth")                    '本次抄表月
            'RptTextObj.Text = Left(dt.Rows(i).Item("D34"), 2)
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtheday")                      '本次抄表日
            'RptTextObj.Text = Right(dt.Rows(i).Item("D34"), 2)
            DetailLog(5) = dt.Rows(i).Item("D34")
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnextmonth")                   '下次抄表月
            'RptTextObj.Text = Left(dt.Rows(i).Item("D35"), 2)
            'RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnextday")                     '下次抄表日
            'RptTextObj.Text = Right(dt.Rows(i).Item("D35"), 2)
            DetailLog(6) = dt.Rows(i).Item("D35")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rthedegree")                   '本月抄表度
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D22"))
            DetailLog(7) = dt.Rows(i).Item("D22")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpredegree")                   '上月抄表度
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D23"))
            DetailLog(8) = dt.Rows(i).Item("D23")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rusedegree")                   '使用度數
            RptTextObj.Text = dt.Rows(i).Item("D25") & Conversion.Val(dt.Rows(i).Item("D26"))  ' ReVal(dt.Rows(i).Item("D8") - dt.Rows(i).Item("D9")) 20120206 增加推定度數flasg顯示E
            DetailLog(9) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rprice")                       '單價
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D27"))
            DetailLog(10) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rvol")                         '從量費
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D39"))) 'Conversion.Val(Trim(dt.Rows(i).Item("D28")))
            DetailLog(11) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rbasic")                       '基本費
            RptTextObj.Text = Conversion.Val(Trim(dt.Rows(i).Item("D40"))) ' Conversion.Val(Trim(dt.Rows(i).Item("D29")))
            DetailLog(12) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rgas")                         '天然氣費
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D41"))
            DetailLog(13) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ramount")                      '追退金額
            RptTextObj.Text = dt.Rows(i).Item("D30") & Conversion.Val(dt.Rows(i).Item("D31"))
            DetailLog(14) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rother")                       '其他費用
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
            DetailLog(15) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rsubtotal")                    '小計
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D32"))
            DetailLog(16) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtax")                         '營業稅
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))
            DetailLog(17) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rtotal")                       '實收總金額
            RptTextObj.Text = Conversion.Val(Left(dt.Rows(i).Item("D7"), 12)) '& "." & Right(dt.Rows(i).Item("D7"), 2)
            DetailLog(18) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rid")                          '統一編號
            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D19")), "", dt.Rows(i).Item("D19")) ' dt.Rows(i).Item("D32")
            DetailLog(19) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rlightno")                     '燈別
            RptTextObj.Text = dt.Rows(i).Item("D21")
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rpayment")                     '代繳帳號
            RptTextObj.Text = Left(dt.Rows(i).Item("D6"), 6) & "XXXX" & Right(dt.Rows(i).Item("D6"), 4)
            DetailLog(20) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("raddress")                     '裝置地址
            RptTextObj.Text = dt.Rows(i).Item("D44") 'dt.Rows(i).Item("D23")
            DetailLog(21) = RptTextObj.Text
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rnum")                         '代碼
            RptTextObj.Text = IIf(IsDBNull(dt.Rows(i).Item("D43")), "", dt.Rows(i).Item("D43"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rDate")
            If IsDBNull(dt.Rows(i).Item("D16")) Then
                RptTextObj.Text = ""
            Else
                If Trim(dt.Rows(i).Item("D16")) <> "" Then
                    RptTextObj.Text = Left(dt.Rows(i).Item("D16"), 4) & "/" & Mid(dt.Rows(i).Item("D16"), 5, 2) & "/" & Right(dt.Rows(i).Item("D16"), 2) ' Format(ReVal(dt.Rows(i).Item("D16")), "yyyy/MM/dd")
                    'RptTextObj.Text = Format(Now, "yyyy/MM/dd")
                    RptTextObj.Text = Str(Left(RptTextObj.Text, 4) - 1911) & Right(RptTextObj.Text, 6)
                Else
                    RptTextObj.Text = ""
                End If
            End If
            'thisRptDoc.SaveAs(PDFPath & FileName & ".rpt", True)
            ' DateTemp = Format(Now, "yyyyMMddHHmmss")
            'FileIO.FileSystem.CreateDirectory("C:\RPT\" & DateTemp)
            System.IO.Directory.CreateDirectory("C:\RPT\" & DateTemp)

            thisRptDoc.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat, "c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")

            reader = New PdfReader("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
            stream = CType(New FileStream("c:\RPT\" & DateTemp & "\" & FileName & ".pdf", FileMode.Append), Stream)
            asc = New System.Text.ASCIIEncoding
            '*****20140929_Bacom**********************************************
            Dim cancelPWD As Boolean = False
            cancelPWD = GetData.GetPDFCancelPWD(dt.Rows(i)(50))
            If cancelPWD Then
                by = asc.GetBytes("", 0, 0)
            Else
                by = asc.GetBytes(dt.Rows(i)(50), 0, dt.Rows(i)(50).Length)
            End If
            'by = asc.GetBytes(dt.Rows(i)(50), 0, dt.Rows(i)(50).Length)
            '*****************************************************************
            iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, stream, by, by, iTextSharp.text.pdf.PdfWriter.ALLOW_PRINTING, True)
            System.IO.File.Delete("c:\RPT\" & DateTemp & "\no" & FileName & ".pdf")
            ReString = "c:\RPT\" & DateTemp & "\" & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i).Item("wm_email")) & "|" & "c:\RPT\" & DateTemp
        Next
        thisRptDoc.Close()
        thisRptDoc = Nothing
        ReportList = ReString 'PDFPath & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i)(49))
    End Function
#End Region
#End If
#Region "TrueSend　真正送出Email的函數"
    Function TrueSend(ByVal FilePath As String, ByVal UserName As String, ByVal Email As String, ByVal REDate As String, ByVal Flag As Integer)
        Dim Sendi As Integer
        Dim int_result As Integer

        For Sendi = 0 To 2
            int_result = SendMailB(FilePath, UserName, Email, REDate, Flag)
            If int_result = 1 Then
                'WriteDetailLog("1", "Receipt_batch_log", Sendi)
                Exit For
            Else
                ' WriteDetailLog("2", "Receipt_batch_log", Sendi)
            End If
        Next
    End Function
#End Region

#Region "SendMailB　實際發送Email的程序"
    Function SendMailB(ByVal AttPath As String, ByVal ToUserName As String, ByVal ToEmail As String, ByVal REDate As String, ByVal Flag As Integer) As Integer
        Dim mailmsg As MailMessage
        Dim tcpclient As TcpClient
        Dim stream As NetworkStream
        Dim BodyStr As String
        Dim strmessage As String
        Dim check As Boolean
        Dim hostName As String = Dns.GetHostName
        Dim Temp As System.Text.Encoding
        Dim i As Integer
        Try
            SMTPCodeAdd()
            If thread_status = False Then
                thread_status = True
                mailmsg = New MailMessage
                If Flag <> 3 Then
                    mailmsg.From = "欣欣天然氣<contactus@shinshingas.com.tw>"
                    mailmsg.To = ToEmail '& "><" & ToEmail '& "><葉先生"  'txtEmail.Text  '"yehjyh@gmail.com" '"cherryli@gmail.com"  ' "<yehjyh@gmail.com>測試 "   ' <yehjyh@pchome.com.tw>; "kate0419@ms37.hinet.net" '  "yehjyh@yahoo.com.tw" ' 
                    mailmsg.Subject = "欣欣天然氣" & Left(REDate, 3) & "/" & Right(REDate, 2) & "月份電子繳費憑證"
                    mailmsg.Priority = MailPriority.Normal
                    Temp = System.Text.Encoding.GetEncoding("big5")
                    mailmsg.BodyFormat = MailFormat.Html
                    BodyStr = "親愛的客戶:<br/><br/>"
                    BodyStr = BodyStr & "感謝您使用欣欣天然氣電子繳費憑證，謹附上您本期的電子繳費憑證（請參閱附件PDF檔）。<br/>"
                    BodyStr = BodyStr & "開啟附加檔案需輸入密碼方可瀏覽（<font color=red>密碼</font>即「身份證字號<font color=blue>《第一碼英文字母須大寫》</font>或統一編號」）。<br/>"
                    BodyStr = BodyStr & "若您有任何疑問，歡迎電洽本公司電話：02-2921-7811（可參閱天然氣費繳費憑證之業務分機）。<br/>"
                    BodyStr = BodyStr & "敬祝(生活愉快)<br/>"
                    BodyStr = BodyStr & "<DIV align=""right"">欣欣天然氣股份有限公司&nbsp;敬上</DIV><br/><br/>"
                    BodyStr = BodyStr & "※重要訊息公告※<br/>"
                    BodyStr = BodyStr & "1.  本公司電子繳費憑證版面與實體繳費憑證一致。<br/>"
                    BodyStr = BodyStr & "2.  我們所寄送的電子繳費憑證為PDF格式&nbsp;PDF檔案的讀取須透過特別的軟體才可閱讀，所以如果您尚未安裝此軟體，請至網址<a href=""http://www.adobe.com/tw/"">http://www.adobe.com/tw/</a> 下載安裝。<br/>"
                    BodyStr = BodyStr & "<font color=red>3.  此為系統發出的電子郵件，請勿直接回覆。</font><br/><br/><br/>"
                    BodyStr = BodyStr & "※敬告事項※<br/>"
                    BodyStr = BodyStr & "1.  近有假藉本公司名義，偽稱安全檢查乘機推銷器材或改管工程，請注意<font color=red>不要先行付費，以免上當受騙。</font><br/>"
                    BodyStr = BodyStr & "2.  房屋買賣或租賃前請確認計量表<font color=red>度數</font>結算，並聯絡本公司查詢有無積欠氣費，否則概由屋主負責清償。<br/>"
                    BodyStr = BodyStr & "3.  委託郵、銀代扣、繳氣費用戶，如有房屋買賣，租賃終止或其他情事，請至<font color=red>郵局、銀行</font>辦理代繳<font color=red>委託終止</font>作業，<br/>"
                    BodyStr = BodyStr & "&nbsp;&nbsp;&nbsp;    如有續扣情事發生，<font color=red>本公司僅提供氣費繳費證明。</font><br/>"
                    BodyStr = BodyStr & "4.  貴戶如為空戶，可聯絡本公司申請拆表，免計基本費。<br/>"
                    BodyStr = BodyStr & "5.  本公司每<font color=red>十年免費換表</font>乙次。<br/>"
                    BodyStr = BodyStr & "6.  本公司每<font color=red>兩年免費安全檢查</font>乙次，並事先以<font color=red>明信片</font>通知檢查時間。如需更換天然氣開關，<font color=red>現場不收費</font>，改隨氣費收取。<br/>"
                    mailmsg.Body = BodyStr
                    mailmsg.BodyEncoding = Temp
                    mailmsg.Attachments.Add(AttPath)
                    'If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", mailmsg) = True Then
                    If SendEmail("172.16.0.5", 25, True, "contactus", "22325804", mailmsg) = True Then
                        Msg1.Text = "補寄成功"
                        i = 1
                    Else
                        Msg1.Text = "補寄失敗"
                        i = 0
                    End If
                Else
                    mailmsg.From = "contactus@shinshingas.com.tw"
                    mailmsg.To = "contactus@shinshingas.com.tw"  '"yehjyh@yahoo.com.tw" '& "><" & ToEmail '& "><葉先生"  'txtEmail.Text  '"yehjyh@gmail.com" '"cherryli@gmail.com"  ' "<yehjyh@gmail.com>測試 "   ' <yehjyh@pchome.com.tw>; "kate0419@ms37.hinet.net" '  "yehjyh@yahoo.com.tw" ' 
                    mailmsg.Subject = "會員申請補寄紙本"
                    mailmsg.Priority = MailPriority.Normal
                    Temp = System.Text.Encoding.GetEncoding("big5")
                    mailmsg.BodyFormat = MailFormat.Html
                    BodyStr = "執行時間:&nbsp;&nbsp;&nbsp;" & Now & "<br/><br/>"
                    BodyStr = BodyStr & "用戶號碼:&nbsp;&nbsp;&nbsp;" & PHouseNo & "<br/><br/>"
                    BodyStr = BodyStr & "用戶姓名:&nbsp;&nbsp;&nbsp;" & PHouseName & "<br/><br/>"
                    BodyStr = BodyStr & "繳費憑證月份:&nbsp;&nbsp;&nbsp;" & PMounth & "<br/><br/>"
                    mailmsg.Body = BodyStr
                    mailmsg.BodyEncoding = Temp
                    'mailmsg.Attachments.Add(AttPath)
                    'If SendEmail("msa.hinet.net", 25, True, "欣欣天然氣", "22325804", mailmsg) = True Then
                    If SendEmail("172.16.0.5", 25, True, "contactus", "22325804", mailmsg) = True Then
                        Msg1.Text = "補寄成功"
                        i = 1
                    Else
                        Msg1.Text = "補寄失敗"
                        i = 0
                    End If
                End If
            End If
        Catch ex As Exception
            i = 0
            Msg1.Text = "補寄失敗" & ex.StackTrace
        End Try
        SendMailB = i
    End Function
#End Region

#Region "WriteLog　寫入批次LOG主檔,讓執行者知道是否已傳送完畢　在此不需填入"
#If 0 Then
    Function WriteLog(ByVal Flag As Integer, ByVal TableName As String, ByVal Str As String) As Integer
        Dim sqlStr As String = ""
        Dim dt As New DataTable
        Dim CheckDate As String
        Dim CurrDate As String
        Dim A() As String = Split(TxtName, "\")
        MOpen()
        If Flag = 1 Then    '產生檔案中
            dt = Read_Sql_Fill_DataSet(TableName, "Select top 1 rb_no from " & TableName & " order by rb_no DESC") ' where rb_file_name='" & A(A.Length - 1) & "'")  '讀取索引值
            If dt.Rows.Count > 0 Then
                CheckDate = Format(Year(Now) - 1911, "000") & Format(Now, "MMdd")
                CurrDate = ReLeft(dt.Rows(0)(0), 7)
                If CheckDate = CurrDate Then
                    rb_no = CurrDate & Format(Val(ReRight(dt.Rows(0)(0), 3)) + 1, "000")
                Else
                    rb_no = CheckDate & "001"
                End If
            Else
                rb_no = Format(Year(Now) - 1911, "000") & Format(Now, "MMdd") & "001"
            End If
            sqlStr = "Insert into " & TableName & " (rb_no,rb_file_name,rb_start_datetime,rb_end_datetime,rb_run_user,rb_status,rb_success,rb_failure) "
            sqlStr = sqlStr & " values ('" & rb_no & "','" & A(A.Length - 1) & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "','','','1',0,0)"
        ElseIf Flag = 2 Then    '發送EMAIL中
            sqlStr = "Update " & TableName & " set rb_status='2' where rb_no='" & rb_no & "'" ' rb_file_name='" & A(A.Length - 1) & "'"
        ElseIf Flag = 3 Then    '執行完成
            sqlStr = "Update " & TableName & " set rb_status='3',rb_end_datetime='" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "',rb_success=" & Success & ",rb_failure=" & Failure & " where  rb_no='" & rb_no & "'" ' rb_file_name='" & A(A.Length - 1) & "'"
        End If
        MSaveData(TableName, sqlStr)
        MClose()

    End Function
#End If

#End Region

#Region "WriteDetailLog　寫入批次LOG明細檔,讓執行者查詢每筆傳送的詳細資料"
    Function WriteDetailLog(ByVal Status As Integer, ByVal TableName As String, ByVal reSend As Integer) As Integer
        Dim sqlStr As String = ""
        Dim Sql As String = ""
        Dim subStr As String = ""
        Dim i As Integer
        Dim GetData As New webmemberDAO
        sqlStr = "Insert into " & TableName & " ( "
        For i = 1 To 21
            sqlStr = sqlStr & "rl_" & Format(i, "00") & ","
        Next
        sqlStr = sqlStr & "rl_rb_no,rl_file_srarus,rl_status,rl_runtime,rl_resend ) values ('"

        Sql = ""
        For i = 1 To 21
            Sql = Sql & Trim(DetailLog(i))
            Sql = Sql & "','"
        Next
        Sql = Sql & "0','1','" & Status & "','" & Format(Now, "yyyy/MM/dd hh:mm:ss") & "'," & reSend & ")"
        subStr = sqlStr & Sql
        GetData.InsertReceiptData(subStr)
    End Function
#End Region

#Region "目前不用"
#If 1 Then
#Region "SendEmail　真正透過Socket送出信件內容"
    Private Function SendEmail(ByVal smtpServer As String, ByVal port As Integer, ByVal ESmtp As Boolean, ByVal username As String, ByVal password As String, ByVal mailMessage As MailMessage) As Boolean
        Dim priority As String
        Dim Html As Boolean
        Dim SendBuffer1() As String = New String(3) {}
        Dim SendBuffer2() As String = New String(1) {}
        Dim SendBufferstr As String
        Dim encData_byte_1() As Byte = New Byte(username.Length) {}
        Dim encData_byte_2() As Byte = New Byte(password.Length) {}
        Dim encData_byte_3() As Byte = New Byte("郵件內容為HTML格，請選擇HTML方式查看".Length) {}
        Dim encData_byte_4() As Byte = New Byte(mailMessage.Body.Length) {}
        Dim encData_byte_5() As Byte = New Byte(mailMessage.Body.Length) {}
        Dim i As Integer
        Dim filepath As String

        '測試連接服務器是否成功
        If connect(smtpServer, port) = False Then
            Return False
        End If
        priority = GetPriorityString(mailMessage.Priority)
        If mailMessage.BodyFormat = MailFormat.Html Then
            Html = True
        Else
            Html = False
        End If

        '進行SMTP驗證，現在大部分SMTP服務器都要認證
        If ESmtp = True Then
            SendBuffer1(0) = "EHLO " & smtpServer & vbCrLf
            SendBuffer1(1) = "AUTH LOGIN" & vbCrLf
            'SendBuffer1(2) = username & vbCrLf
            'SendBuffer1(3) = password & vbCrLf
            encData_byte_1 = System.Text.Encoding.Default.GetBytes(username)
            SendBuffer1(2) = Convert.ToBase64String(encData_byte_1) & vbCrLf
            encData_byte_2 = System.Text.Encoding.Default.GetBytes(password)
            SendBuffer1(3) = Convert.ToBase64String(encData_byte_2) & vbCrLf

            If Dialog(SendBuffer1, "SMTP服務器驗證失敗，請核對用戶名和密碼。") = False Then
                SendBuffer1 = Nothing
                Return False
            End If
        Else
            '不需要身份認證
            SendBufferstr = "HELO" & smtpServer & vbCrLf
            If Dialog(SendBufferstr, "") = False Then
                Return False
            End If
        End If

        '發件人地址
        SendBufferstr = "MAIL FROM:<" & mailMessage.From & ">" & vbCrLf
        If Dialog(SendBufferstr, "發件人地址錯誤，或不能為空") = False Then
            Return False
        End If
#If 1 Then
        SendBuffer2(0) = "RCPT TO: <" & mailMessage.To & ">" & vbCrLf   '
        If Dialog(SendBuffer2(0), "收件人地址有誤") = False Then
            Return False
        End If

        '    SendBuffer2(1) = "Forwarding email to:<yehjyh@yahoo.com.tw>" & vbCrLf ' <" & mailMessage.To & ">" & vbCrLf  '
        '   If Dialog(SendBuffer2(1), "收件人地址有誤") = False Then
        '  Return False
        ' End If
#Else
        SendBufferstr = "RCPT TO:<" & mailMessage.To & ">" & vbCrLf
        If Dialog(SendBufferstr, "收件人地址有誤") = False Then
            Return False
        End If
#End If

        SendBufferstr = "DATA" & vbCrLf
        If Dialog(SendBufferstr, "") = False Then
            Return False
        End If

        If mailMessage.Subject = String.Empty Or mailMessage.Subject Is Nothing Then
            SendBufferstr = "Subject:"
        Else
            SendBufferstr = "Subject:" & mailMessage.Subject & vbCrLf
        End If
        SendBufferstr &= "from:" & mailMessage.From & vbCrLf
        SendBufferstr &= "to:" & mailMessage.To & vbCrLf
        SendBufferstr &= "X-Priority:" & priority & vbCrLf
        SendBufferstr &= "X-MSMail-Priority:" & priority & vbCrLf
        SendBufferstr &= "Importance:" & priority & vbCrLf
        SendBufferstr &= "X-Mailer:Lion. Web. Mail. SmtpMail Pubclass [cn]" & vbCrLf
        SendBufferstr &= "MIME-Version: 1.0" & vbCrLf
        SendBufferstr &= "Date: " & Now.ToString("ddd dd MMM yyyy HH:mm:ss", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) & " +0800 " & vbCrLf
        If mailMessage.Attachments.Count <> 0 Then
            SendBufferstr &= "Content-Type: multipart/mixed;" & vbCrLf
            If Html = True Then
                SendBufferstr &= " boundary=""=====001_Dragon520636771063_=====""" & vbCrLf & vbCrLf
            Else
                SendBufferstr &= " boundary=""=====001_Dragon303406132050_=====""" & vbCrLf & vbCrLf
            End If
        End If

        If Html = True Then
            If mailMessage.Attachments.Count = 0 Then
                SendBufferstr &= "Content-Type: multipart/alternative;" & vbCrLf
                SendBufferstr &= " boundary=""=====003_Dragon520636771063_=====""" & vbCrLf & vbCrLf
                SendBufferstr &= "This is a multi-part message in MIME format." & vbCrLf & vbCrLf
            Else
                SendBufferstr &= "This is a multi-part message in MIME format." & vbCrLf & vbCrLf
                SendBufferstr &= "--=====001_Dragon520636771063_=====" & vbCrLf
                SendBufferstr &= "Content-Type: multipart/alternative;" & vbCrLf
                SendBufferstr &= " boundary=""=====003_Dragon520636771063_=====""" & vbCrLf & vbCrLf
            End If
            SendBufferstr &= "--=====003_Dragon520636771063_=====" & vbCrLf
            SendBufferstr &= "Content-Type: text/plain;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= " Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_3 = System.Text.Encoding.Default.GetBytes("郵件內容為HTML格式，請選擇HTML方式查看")
            SendBufferstr &= Convert.ToBase64String(encData_byte_3) & vbCrLf & vbCrLf
            SendBufferstr &= "--=====003_Dragon520636771063_=====" & vbCrLf
            SendBufferstr &= "Content-Type: text/html;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_4 = System.Text.Encoding.Default.GetBytes(mailMessage.Body)
            SendBufferstr &= Convert.ToBase64String(encData_byte_4) & vbCrLf
            SendBufferstr &= "--=====003_Dragon520636771063_=====--" & vbCrLf
        Else
            If mailMessage.Attachments.Count <> 0 Then
                SendBufferstr &= "--=====001_Dragon303406132050_=====" & vbCrLf
            End If
            SendBufferstr &= "Content-Type: text/plain;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_4 = System.Text.Encoding.Default.GetBytes(mailMessage.Body)
            SendBufferstr &= Convert.ToBase64String(encData_byte_4) & vbCrLf
        End If
#If 1 Then
        If mailMessage.Attachments.Count <> 0 Then
            For i = 0 To mailMessage.Attachments.Count - 1
                filepath = mailMessage.Attachments(i)
                Dim A() As String = Split(filepath, "\")
                If Html = True Then
                    SendBufferstr &= "--=====001_Dragon520636771063_=====" & vbCrLf
                Else
                    SendBufferstr &= "--=====001_Dragon303406132050_=====" & vbCrLf
                End If
                SendBufferstr &= "Content-Type: text/plain" & vbCrLf
                SendBufferstr &= " name=""=?" & "GB2312" & "?B?"
                encData_byte_5 = System.Text.Encoding.Default.GetBytes(A(A.Length - 1)) '(filepath.Substring(filepath.LastIndexOf("\\") + 1))
                SendBufferstr &= Convert.ToBase64String(encData_byte_5) & "?=""" & vbCrLf
                SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf
                SendBufferstr &= "Content-Disposition: attachment;" & vbCrLf
                SendBufferstr &= " filename=""=?GB2312?B?" & Convert.ToBase64String(encData_byte_5) & "?=""" & vbCrLf & vbCrLf
                SendBufferstr &= GetStream(filepath) & vbCrLf & vbCrLf
            Next

            If Html = True Then
                SendBufferstr &= "--=====001_Dragon520636771063_=====--" & vbCrLf & vbCrLf
            Else
                SendBufferstr &= "--=====001_Dragon303406132050_=====--" & vbCrLf & vbCrLf
            End If
        End If
#End If
        SendBufferstr &= vbCrLf & "." & vbCrLf
        If Dialog(SendBufferstr, "錯誤信件信息") = False Then
            Return False
        End If
        '先拿掉
        'SendBufferstr &= "QUIT" & vbCrLf
        'If Dialog(SendBufferstr, "斷開連接時錯誤") = False Then
        '    Return False
        'End If

        stream.Close()
        tcpClient.Close()
        Return True

    End Function
#End Region

#Region "GetStream　讀取檔案資料"
    Private Function GetStream(ByVal FilePath As String) As String
        Dim FileStr As FileStream
        FileStr = New FileStream(FilePath, FileMode.Open)

        Dim by() As Byte = New Byte(System.Convert.ToInt32(FileStr.Length)) {}
        FileStr.Read(by, 0, by.Length)
        FileStr.Close()
        Return (System.Convert.ToBase64String(by))
    End Function
#End Region

#Region "connect　連接TCPIP"
    Private Function connect(ByVal smtpServer As String, ByVal port As Integer) As Boolean
        Dim s As String
        Dim ipAddr As System.Net.IPAddress
        '創建Tcp連接
        Try
            tcpClient = New TcpClient
            tcpClient.Connect(smtpServer, port)
        Catch ex As Exception
            s = ex.Message
            Return False
        End Try

        stream = tcpClient.GetStream()
        If RightCodeHT(RecvResponse().Substring(0, 3)) Is Nothing Then
            Return False
        End If
        Return True

    End Function
#End Region

#Region "SendCommand　發送SMTP命令"
    '發送SMTP命令
    Private Function SendCommand(ByVal str As String) As Boolean
        Dim WriteBuffer() As Byte = New Byte(str.Length) {}

        If str.Trim = String.Empty Or str Is Nothing Then
            Return True
        End If
        WriteBuffer = System.Text.Encoding.Default.GetBytes(str)

        Try
            stream.Write(WriteBuffer, 0, WriteBuffer.Length)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "RecvResponse　接收SMTP服務器回應"
    '接收SMTP服務器回應
    Private Function RecvResponse() As String
        Dim StreamSize As Integer
        Dim Returnvalue As String = String.Empty
        Dim ReadBuffer() As Byte = New Byte(9216) {}

        Try
            StreamSize = stream.Read(ReadBuffer, 0, ReadBuffer.Length)
        Catch ex As Exception
            Return "false"
        End Try

        If StreamSize = 0 Then
            Return Returnvalue
        Else
            Returnvalue = System.Text.Encoding.Default.GetString(ReadBuffer).Substring(0, StreamSize)
            Return Returnvalue
        End If
    End Function
#End Region

#Region "SMTPCodeAdd　回應代碼訊息表"
    'SMTP回應代碼哈希表
    Private Sub SMTPCodeAdd()
        ErrCodeHT.Add("421", "服務未就緒，關閉傳輸信道")
        ErrCodeHT.Add("432", "需要一個密碼轉換")
        ErrCodeHT.Add("450", "要求的郵件操作未完成，郵箱不可用(例如，郵箱忙)")
        ErrCodeHT.Add("451", "放棄要求的操作；處理過程中出錯")
        ErrCodeHT.Add("452", "系統存儲不足，要求的操作未執行")
        ErrCodeHT.Add("454", "臨時認證失敗")
        ErrCodeHT.Add("500", "郵箱地址錯誤")
        ErrCodeHT.Add("501", "參數格式錯誤")
        ErrCodeHT.Add("502", "命令不可實現")
        ErrCodeHT.Add("503", "服務器需要SMTP驗證")
        ErrCodeHT.Add("504", "命令參數不可實現")
        ErrCodeHT.Add("530", "需要認證")
        ErrCodeHT.Add("534", "認證機制過於簡單")
        ErrCodeHT.Add("538", "當前請求的認證機制需要加密")
        ErrCodeHT.Add("550", "要求的郵件操作未完成，郵箱不可用(例如，郵箱未找到，或不可訪問)")
        ErrCodeHT.Add("551", "用戶非本地，請嘗試<forward-path>")
        ErrCodeHT.Add("552", "過量的存儲分配，要求的操作未執行")
        ErrCodeHT.Add("553", "郵箱名不可用，要求的操作未執行(例如郵箱格式錯誤)")
        ErrCodeHT.Add("554", "傳輸失敗")

        RightCodeHT.Add("220", "服務就緒")
        RightCodeHT.Add("221", "服務關閉傳輸信道")
        RightCodeHT.Add("235", "驗證成功")
        RightCodeHT.Add("250", "要求的郵件操作完成")
        RightCodeHT.Add("251", "非本地用戶，將轉發向<forward-path>")
        RightCodeHT.Add("334", "服務器響應驗證Base64字符串")
        RightCodeHT.Add("354", "開始郵件輸入，以<CRLF>.<CRLF>結束")
    End Sub
#End Region

#Region "Dialog　"
    Private Overloads Function Dialog(ByVal str As String, ByVal errsstr As String) As Boolean
        Dim RR As String
        Dim RRCode As String
        If str Is Nothing Or str.Trim() = String.Empty Then
            Return True
        End If
        If SendCommand(str) Then
            RR = RecvResponse()
            If RR = "false" Then
                Return False
            End If

            RRCode = RR.Substring(0, 3)
            If RightCodeHT(RRCode) Is Nothing Then
                Return True
            Else
                If ErrCodeHT(RRCode) Is Nothing Then
                    Return True
                Else
                    ' Me.Label9.Text = errstr
                    Return False
                End If
            End If
        Else
            'Me.Label9.Text = errstr
            Return False
        End If
    End Function

    Private Overloads Function Dialog(ByVal str() As String, ByVal errstr As String) As Boolean
        Dim i As Integer
        For i = 0 To str.Length - 1
            If Dialog(str(i), "") = False Then
                Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region "GetPriorityString　判斷郵件優先權"
    Private Function GetPriorityString(ByVal mailPriority As MailPriority) As String
        Dim priority As String = "Normal"

        If mailPriority = mailPriority.Low Then
            priority = "Low"
        ElseIf mailPriority = mailPriority.High Then
            priority = "High"
        End If

        Return priority
    End Function
#End Region
#End If




#If 0 Then
        'Dim fromAddress As System.Net.Mail.MailAddress = Nothing
        'Dim toAddress As System.Net.Mail.MailAddress = Nothing
        'Dim mailClient As System.Net.Mail.SmtpClient
        'Dim Att As System.Net.Mail.Attachment
        ' Dim oMail As New MailMessage
        'Dim MailServer As String = "msa.hinet.net" ' "192.168.80.87"
        Dim MailServer As String = "172.16.0.5"
        Dim NewMail As System.Web.Mail.SmtpMail
        Dim oMail As New System.Web.Mail.MailMessage
        Dim Att As System.Web.Mail.MailAttachment
        Dim BodyStr As String
        Dim i As Integer
        Try
            SMTPCodeAdd()
            'mailClient = New SmtpClient("msa.hinet.net", 25)
            NewMail.SmtpServer = MailServer

            'fromAddress = New MailAddress("yehjyh@rpti3.com.tw", "管理者")
            'toAddress = New MailAddress(TextBox1.Text, TextBox2.Text) 'MailAddress("yehjyh@yahoo.com.tw", "葉智勇")
            'oMail = New MailMessage(fromAddress, toAddress)
            'oMail.To.Add(New Net.Mail.MailAddress(TextBox1.Text, TextBox2.Text))
            'oMail.To.Add(New Net.Mail.MailAddress("yehjyh@rpti3qwe.com.tw", "JJ"))
            'oMail.To.Add(New Net.Mail.MailAddress("yehjyh@gmail.com", "jehjyh"))

            oMail.From = "contactus@shinshingas.com.tw"  'New MailAddress("contactus@shinshingas.com.tw", "管理者") '("yehjyh@yahoo.com.tw", "管理者")
            oMail.To = ToEmail '(New Net.Mail.MailAddress(ToEmail, ToUserName))
            oMail.Subject = "欣欣天然氣10月份電子繳費憑證" ' "此為測試信件,於:" & tDate & "時由系統自動發送.第 " & count & " 次"
            oMail.BodyEncoding = System.Text.Encoding.UTF8
            oMail.BodyFormat = Mail.MailFormat.Text

            BodyStr = "親愛的客戶:<br/><br/>"
            BodyStr = BodyStr & "感謝您使用欣欣天然氣電子繳費憑證，謹附上您本期的電子繳費憑證（請參閱附件PDF檔）。<br/>"
            BodyStr = BodyStr & "開啟附加檔案需輸入密碼方可瀏覽（<font color=red>密碼</font>即「身份證字號<font color=blue>《第一碼英文字母須大寫》</font>或統一編號」）。<br/>"
            BodyStr = BodyStr & "若您有任何疑問，歡迎電洽本公司電話：02-2921-7811（可參閱天然氣費繳費憑證之業務分機）。<br/>"
            BodyStr = BodyStr & "敬祝(生活愉快)<br/>"
            BodyStr = BodyStr & "<DIV align=""right"">欣欣天然氣股份有限公司敬上()</DIV><br/><br/>"
            BodyStr = BodyStr & "※重要訊息公告※<br/>"
            BodyStr = BodyStr & "1.  本公司電子繳費憑證版面與實體繳費憑證一致。<br/>"
            BodyStr = BodyStr & "2.  我們所寄送的電子繳費憑證為PDF格式 PDF檔案的讀取須透過特別的軟體才可閱讀，所以如果您尚未安裝此軟體，請至網址<a href=""http://www.adobe.com/tw/"">http://www.adobe.com/tw/</a> 下載安裝。<br/>"
            BodyStr = BodyStr & "<font color=red>3.  此為系統發出的電子郵件，請勿直接回覆。</font><br/><br/><br/>"
            BodyStr = BodyStr & "※敬告事項※<br/>"
            BodyStr = BodyStr & "1.  近有假藉本公司名義，偽稱安全檢查乘機推銷器材或改管工程，請注意<font color=red>不要先行付費，以免上當受騙。</font><br/>"
            BodyStr = BodyStr & "2.  房屋買賣或租賃前請確認計量表<font color=red>度數</font>結算，並聯絡本公司查詢有無積欠氣費，否則概由屋主負責清償。<br/>"
            BodyStr = BodyStr & "3.  委託郵、銀代扣、繳氣費用戶，如有房屋買賣，租賃終止或其他情事，請至<font color=red>郵局、銀行</font>辦理代繳<font color=red>委託終止</font>作業，如有續扣情事發生，<font color=red>本公司僅提供氣費繳費證明。</font><br/>"
            BodyStr = BodyStr & "4.  貴戶如為空戶，可聯絡本公司申請拆表，免計基本費。<br/>"
            BodyStr = BodyStr & "5.  本公司每<font color=red>十年免費換表</font>乙次。<br/>"
            BodyStr = BodyStr & "6.  本公司每<font color=red>兩年免費安全檢查</font>乙次，並事先以<font color=red>明信片</font>通知檢查時間。如需更換天然氣開關，<font color=red>現場不收費</font>，改隨氣費收取。<br/>"
            oMail.Body = BodyStr
            Att = New MailAttachment(AttPath) '("D:\test\附加檔案.txt")
            oMail.Attachments.Add(Att)

            Dim CurThread As Thread = System.Threading.Thread.CurrentThread
            SyncLock CurThread
                'If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", oMail) = True Then       '"smtp.rpti3.com.tw"   NewMail.Send(oMail) '  mailClient.Send(oMail)
                If SendEmail("172.16.0.5", 25, True, "contactus", "22325804", oMail) = True Then       '"smtp.rpti3.com.tw"   NewMail.Send(oMail) '  mailClient.Send(oMail)
                    messege.Text = "補寄成功"
                    i = 1
                Else
                    messege.Text = "補寄失敗"
                    i = 0
                End If
            End SyncLock
            'i = 1
        Catch ex As Exception
            i = 0
        End Try
        SendMail = i



#End If

#If 0 Then

#Region "SendMail　實際發送Email的程序"
    Function SendMail(ByVal AttPath As String, ByVal ToUserName As String, ByVal ToEmail As String) As Integer
        Dim NewMail As SmtpMail   ' System.Web.Mail.SmtpMail
        Dim mailmsg As New MailMessage
        Dim Att As MailAttachment
        Dim Encod As MailEncoding
        Dim Prio As MailPriority
        Dim Format1 As MailFormat
        'Dim MailServer As String ="msa.hinet.net"
        Dim MailServer As String = "172.16.0.5"

        Dim tcpclient As TcpClient
        Dim stream As NetworkStream
        Dim BodyStr As String
        Dim strmessage As String
        Dim check As Boolean
        Dim hostName As String = Dns.GetHostName
        Dim Temp As System.Text.Encoding

        Dim i As Integer
        'Try
        'SMTPCodeAdd()
        NewMail.SmtpServer = MailServer
        If thread_status = False Then
            thread_status = True
            mailmsg.From = "contactus@shinshingas.com.tw"
            mailmsg.To = " yehjyh@yahoo.com.tw " 'gmail.com" 'ToEmail  ''"cherryli@gmail.com"  ' "<yehjyh@gmail.com>測試 "   ' <yehjyh@pchome.com.tw>; "kate0419@ms37.hinet.net" '  "yehjyh@yahoo.com.tw" ' 
            mailmsg.Subject = "欣欣天然氣11月份電子繳費憑證"
            Att = New MailAttachment(AttPath)
            mailmsg.Attachments.Add(Att)
            mailmsg.Priority = Prio.High ' MailPriority.Normal
            Temp = System.Text.Encoding.GetEncoding("big5")
            mailmsg.BodyEncoding = System.Text.Encoding.GetEncoding("big5") ' Temp
            mailmsg.BodyFormat = Format1.Html ' MailFormat.Html
            BodyStr = "親愛的客戶:<br/><br/>"
            BodyStr = BodyStr & "感謝您使用欣欣天然氣電子繳費憑證，謹附上您本期的電子繳費憑證（請參閱附件PDF檔）。<br/>"
            BodyStr = BodyStr & "開啟附加檔案需輸入密碼方可瀏覽（<font color=red>密碼</font>即「身份證字號<font color=blue>《第一碼英文字母須大寫》</font>或統一編號」）。<br/>"
            BodyStr = BodyStr & "若您有任何疑問，歡迎電洽本公司電話：02-2921-7811（可參閱天然氣費繳費憑證之業務分機）。<br/>"
            BodyStr = BodyStr & "敬祝(生活愉快)<br/>"
            BodyStr = BodyStr & "<DIV align=""right"">欣欣天然氣股份有限公司敬上()</DIV><br/><br/>"
            BodyStr = BodyStr & "※重要訊息公告※<br/>"
            BodyStr = BodyStr & "1.  本公司電子繳費憑證版面與實體繳費憑證一致。<br/>"
            BodyStr = BodyStr & "2.  我們所寄送的電子繳費憑證為PDF格式 PDF檔案的讀取須透過特別的軟體才可閱讀，所以如果您尚未安裝此軟體，請至網址<a href=""http://www.adobe.com/tw/"">http://www.adobe.com/tw/</a> 下載安裝。<br/>"
            BodyStr = BodyStr & "<font color=red>3.  此為系統發出的電子郵件，請勿直接回覆。</font><br/><br/><br/>"
            BodyStr = BodyStr & "※敬告事項※<br/>"
            BodyStr = BodyStr & "1.  近有假藉本公司名義，偽稱安全檢查乘機推銷器材或改管工程，請注意<font color=red>不要先行付費，以免上當受騙。</font><br/>"
            BodyStr = BodyStr & "2.  房屋買賣或租賃前請確認計量表<font color=red>度數</font>結算，並聯絡本公司查詢有無積欠氣費，否則概由屋主負責清償。<br/>"
            BodyStr = BodyStr & "3.  委託郵、銀代扣、繳氣費用戶，如有房屋買賣，租賃終止或其他情事，請至<font color=red>郵局、銀行</font>辦理代繳<font color=red>委託終止</font>作業，如有續扣情事發生，<font color=red>本公司僅提供氣費繳費證明。</font><br/>"
            BodyStr = BodyStr & "4.  貴戶如為空戶，可聯絡本公司申請拆表，免計基本費。<br/>"
            BodyStr = BodyStr & "5.  本公司每<font color=red>十年免費換表</font>乙次。<br/>"
            BodyStr = BodyStr & "6.  本公司每<font color=red>兩年免費安全檢查</font>乙次，並事先以<font color=red>明信片</font>通知檢查時間。如需更換天然氣開關，<font color=red>現場不收費</font>，改隨氣費收取。<br/>"

            mailmsg.Body = BodyStr
            NewMail.Send(mailmsg) 'mailmsg.From, mailmsg.To, mailmsg.Subject, mailmsg.Body, )
            If Err.Number <> 0 Then
                i = 0
            Else
                i = 1
            End If


        End If
        'Catch ex As Exception
        'Msg1.Text = "失敗" & ex.StackTrace
        'i = 0
        'End Try

        SendMail = i


    End Function

#End Region


#End If

#End Region

End Class
