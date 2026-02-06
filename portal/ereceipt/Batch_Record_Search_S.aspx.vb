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
Public Class Batch_Record_Search_S
    Inherits System.Web.UI.Page
    Public Structure calStr_str
        Dim outString As String
        Dim calResult As Integer
        Dim totDays As Integer
    End Structure
    Private thread_status As Boolean = False
    Private ErrCodeHT As Hashtable = New Hashtable
    Private RightCodeHT As Hashtable = New Hashtable
    Private stream As NetworkStream
    Private tcpClient As tcpClient
    Public wm_No As String
    Public DataValues(10) As String
    Dim DetailLog(22) As String
    Public UserName As String
    Const PDFPath As String = "C:\RPT\" ' "C:\Inetpub\wwwroot\"

    Protected WithEvents lblManager As System.Web.UI.WebControls.Label
    Protected WithEvents lblSorF As System.Web.UI.WebControls.Label
    Public CurrInput As Integer '1=成功,2=失敗
    Protected WithEvents Msg1 As System.Web.UI.WebControls.Label
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Public AStatus As String
#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblBatchNo As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents lblStartTime As System.Web.UI.WebControls.Label
    Protected WithEvents lblSeccess As System.Web.UI.WebControls.Label
    Protected WithEvents lblEndTime As System.Web.UI.WebControls.Label
    Protected WithEvents lblFailure As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '判斷登入
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        'If CType(Session("sid"), String) = "" Or Session("sid") Is Nothing Then
        '    Response.Redirect("~/Default.aspx")
        'End If
        SMTPCodeAdd()
        ReadUserData()

        If Not IsPostBack Then
            CurrInput = Request("CurrInput")
            ShowInitData(Request("BatchNo"))
            If CurrInput = 1 Then
                lblSorF.Text = "發送成功明細"
            Else
                lblSorF.Text = "發送失敗明細"
            End If
        End If

    End Sub
    Sub ReadUserData()
        Dim mybo As New User
        Dim strname As String
        Dim tmpdt As System.Data.DataTable
        Dim myUser01BO As New User01BO
        Dim myEmployeeID As String

        strname = context.User.Identity.Name
        tmpdt = mybo.QueryUserInfo(strname)
        UserName = Trim(CType(tmpdt.Rows(0).Item("cname"), String))
        '取得員工編號
        myEmployeeID = myUser01BO.getEmployeeID(context.User.Identity.Name.Trim)

    End Sub

    Sub ShowInitData(ByVal BatchNo As String)
        Dim bj As New Batch_job
        Dim dt As New DataTable
        dgCart.CurrentPageIndex = 0
        dt = bj.Search_Receipt_Batch_From_BatchNo(BatchNo)
        lblBatchNo.Text = BatchNo
        If dt.Rows.Count > 0 Then
            lblStartTime.Text = Format(dt.Rows(0)(2), "yyyy/MM/dd HH:mm:ss")
            lblEndTime.Text = Format(dt.Rows(0)(3), "yyyy/MM/dd HH:mm:ss")
            lblManager.Text = IIf(IsDBNull(dt.Rows(0)(4)), "", dt.Rows(0)(4))
            lblSeccess.Text = dt.Rows(0)(6)
            lblFailure.Text = dt.Rows(0)(7)
            AStatus = dt.Rows(0)(5)
            ShowInitDetailData(BatchNo, CurrInput)
        End If
    End Sub
    Sub ShowInitDetailData(ByVal BatchNo As String, ByVal CurrInput As String)
        Dim bj As New Batch_job
        Dim dt As New DataTable
        dt = bj.Search_Receipt_Batch_Log_From_BatchNo(BatchNo, CurrInput)
        dgCart.DataSource = dt
        dgCart.DataBind()

    End Sub


    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged

        dgCart.CurrentPageIndex = e.NewPageIndex
        ' dgCart.DataBind()
        ShowInitDetailData(Request("BatchNo"), Request("CurrInput"))
    End Sub

    Private Sub dgCart_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCart.ItemCommand
        Dim i As Integer
        Dim HouseNo As String
        Dim ReceiptDate As String
        Dim SendEmail As String
        Dim WmNo As String
        Dim UserName As String
        Dim CurrInput As Integer
        Dim RbNo As String
        i = e.Item.ItemIndex
        If i > -1 Then
            HouseNo = Trim(dgCart.Items(i).Cells(1).Text)
            ReceiptDate = Trim(dgCart.Items(i).Cells(2).Text)
            SendEmail = Trim(dgCart.Items(i).Cells(4).Text)
            WmNo = Trim(dgCart.Items(i).Cells(5).Text)
            UserName = Trim(dgCart.Items(i).Cells(6).Text)
            CurrInput = 3 ' Trim(Right(e.CommandName, 1))
            RbNo = Trim(dgCart.Items(i).Cells(9).Text)
            ActionCommand(HouseNo, ReceiptDate, SendEmail, WmNo, UserName, CurrInput, Trim(dgCart.Items(i).Cells(3).Text), RbNo)
        End If
    End Sub



#Region "目前不用"

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

#Region "ActionCommand　依不同功能執行不同的程式"
    Sub ActionCommand(ByVal HouseNo As String, ByVal ReceiptDate As String, ByVal SendEmail As String, ByVal WmNo As String, ByVal UserName As String, ByVal Currinput As Integer, ByVal EMail As String, ByVal RbNo As String)
        Dim bj As New Batch_job
        Dim dt As DataTable
        Dim TempStr As String
        ClearCheckData()
        FillCheckData(HouseNo, ReceiptDate, WmNo, Currinput, EMail)
        If Currinput = 3 Then
            dt = Compact(HouseNo, UserName, ReceiptDate, RbNo)
            If dt.Rows.Count > 0 Then
                TempStr = ReportList(dt, 0)
                Dim A() As String = Split(TempStr, "|")
                DownloadFile(A(0))
                msgbox.Text = ""
                bj.InsertSearchDataLog(DataValues, 0)
                System.IO.File.Delete(A(0))
                'System.IO.File.Delete(A(0))
                System.IO.Directory.Delete(A(4))
            Else
                msgbox.Text = "無此月份資料"
            End If
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
    Sub FillCheckData(ByVal HouseNo As String, ByVal REDate As String, ByVal WmNo As String, ByVal Currinput As Integer, ByVal EMail As String)
        DataValues(0) = WmNo
        DataValues(1) = HouseNo
        DataValues(2) = REDate ' Format(Conversion.Val(Left(REDate, 4)) - 1911, "000") & Right(REDate, 2)
        DataValues(3) = Currinput
        DataValues(4) = 2 'Format(Now, "yyyy/MM/dd HH:mm:ss")
        DataValues(5) = EMail ' 2 'IIf(Currinput = 3, 1, 2)
        DataValues(6) = UserName
        DataValues(7) = ""
    End Sub
#End Region


#Region "Compact　讀取需要寄電子郵件的SQL"
    Function Compact(ByVal HouseNo As String, ByVal HouseName As String, ByVal REDate As String, ByVal RbNo As String) As DataTable
        Dim bj As New Batch_job
        Dim dt As New DataTable
        Dim sql = " Select d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,d32,d33,d34,d35,d36,d37,d38,d39,d40,d41,d42,d43,d44,d45,d50"
        sql = sql & ",mh_wm_no, mh_house_no,mh_ers_flag "
        sql = sql & ",wm_password,wm_user_name,wm_email,wm_id,wm_open_flag  "
        sql = sql & " from Receipt join member_house on d10 = mh_house_no join webmember on mh_wm_no=wm_no "
        'sql = sql & " WHERE     (member_house.mh_ers_flag = 'Y') "
        sql = sql & " where (Receipt.D10 = '" & HouseNo & "') AND (Receipt.D14 = '" & REDate & "') " 'AND (Receipt.D36 = '" & HouseName & "')"
        sql = sql & " and receipt.temp2='" & RbNo & "'"
        dt = bj.ReadEReceiptData(sql)
        Compact = dt
    End Function
#End Region

#Region "ReadLongAD　讀取長廣告欄的文字"
    Function ReadLongAD(ByVal Line As Integer, ByRef ADLong() As String)
        Dim dt1 As New DataTable
        Dim bj As New Batch_job
        Dim DateString As String
        DateString = Format(Now, "yyyy-MM-dd HH:mm:ss")
        dt1 = bj.ReadEReceiptData("Select * from  Receipt_ad where ad_start_date <='" & DateString & "' and ad_end_date >='" & DateString & "' order by ad_end_date DESC ") ' and ad_line=" & Line & "
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
        Dim thisRptDoc As New ReportDocument
        Dim reader As PdfReader
        Dim stream As stream
        Dim asc As ASCIIEncoding
        Dim by() As Byte = New Byte(10) {}
        Dim logoninfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim thisPath As String = Server.MapPath("/") + "\" '"C:\Inetpub\wwwroot\"
        Dim int_Exit_Flag As Integer = 0
        Dim int_Result As Integer = 0
        Dim Sendi As Integer
        Dim ADLong(3) As String
        Dim ADShort(6) As String
        Dim dt1 As New DataTable
        Dim bj As New Batch_job
        Dim DateTemp As String = ""
        Dim GetData As New WebmemberDotDAO


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
        Dim objAPPM04 As New APPX01DAO ' APPM04DAO
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
        Dim invno As String
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
        Dim ADay(3) As String
        Dim TDay As String
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


        dt1 = bj.ReadEReceiptData("Select * from  Receipt_notice ")
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
        'thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2-NEW.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)
        '1081126 change 
        thisRptDoc.Load(Server.MapPath("/SupShowLogoR-2V2-NEW.rpt"), CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

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
                'rtPrice1 = Left(dt.Rows(i).Item("D45"), 44)
                'rtPrice2 = Mid(dt.Rows(i).Item("D45"), 45, 44)
                'rtPrice3 = Mid(dt.Rows(i).Item("D45"), 89, 44)
                'rtPrice4 = Mid(dt.Rows(i).Item("D45"), 133, 44)
                ' change 1081126 
                rtPrice1 = Left(dt.Rows(i).Item("D45"), 40)
                rtPrice2 = Mid(dt.Rows(i).Item("D45"), 41, 38)
                rtPrice3 = Trim(Mid(dt.Rows(i).Item("D45"), 80, 40))
                rtPrice4 = Trim(Mid(dt.Rows(i).Item("D45"), 120, 40))
            End If


            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("rPriceStr1")
            RptTextObj.Text = rtPrice1 & rtPrice2
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
                    ' invno = Left(dt.Rows(i).Item("D50"), 30)

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

                    '1071008 add 
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
                simg = Code128Rendering.MakeBarcodeImage("ED0022", 1, True)
                simg.Save(Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))

                '1071009 add 
                myimg1 = Code128Rendering.MakeBarcodeImage(invno1, 1, True)
                myimg1.Save(Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg"))
                '1071009 end 

            Else
                FileIO.FileSystem.CopyFile(Server.MapPath("/images/barc.jpg"), Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg"))
                FileIO.FileSystem.CopyFile(Server.MapPath("/images/ED0022.jpg"), Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg"))

                FileIO.FileSystem.CopyFile(Server.MapPath("/images/barc2.jpg"), Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg")) '1071009
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



            'invno = Left(invno, 5) & " " & Mid(invno, 6, 10) & " " & Mid(invno, 16, Len(invno))
            invno = Left(invno, 5) & " " & Mid(invno, 6, 10)

            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode1Path").Text = """" & Server.MapPath("./zRecord/ED0022-" & tmpUID.ToString & ".jpg") & """"
            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode2Path").Text = """" & Server.MapPath("./zRecord/barc-" & tmpUID.ToString & ".jpg") & """"

            '1071008 add 
            thisRptDoc.DataDefinition.FormulaFields.Item("BarCode3Path").Text = """" & Server.MapPath("./zRecord/barc2-" & tmpUID.ToString & ".jpg") & """"


            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no11")
            RptTextObj.Text = invno


            '1071008 add 
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("inv_no12")
            RptTextObj.Text = invno1
            '1071008 

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

            strAnother = ""
            '1071008 add 
            If sw1 <> 0 Then strAnother += " 2.1開關:      " & sw1 & Chr(13)
            If sw2 <> 0 Then strAnother += " 3.6開關:      " & sw2 & Chr(13)
            If ao <> 0 Then strAnother += " 5.0 開關:      " & ao & Chr(13)
            If pp1 <> 0 Then strAnother += " 熱水器銜接管: " & pp1 & Chr(13)
            If pp2 <> 0 Then strAnother += " 瓦斯爐銜接管: " & pp2 & Chr(13)
            If ap <> 0 Then strAnother += "  檢查費:       " & ap & Chr(13)

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("oth_sw2")
            RptTextObj.Text = strAnother
            '1071008 end 

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
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("lother") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D42"))
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("ltax") '
            RptTextObj.Text = Conversion.Val(dt.Rows(i).Item("D33"))



            ' 1071008  add 於應繳金額下方多顯示應繳金額
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("Memoltax") '
            If Conversion.Val(dt.Rows(i).Item("D33")) <> "0" Then
                RptTextObj.Text = "(內含税金" & Conversion.Val(dt.Rows(i).Item("D33")) & "元)"
            Else
                RptTextObj.Text = ""
            End If

            ' end 1071008
            '1081126 add 

            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine1")
            RptTextObj.Text = rtPrice3 ' ADLong(1)
            RptTextObj = thisRptDoc.ReportDefinition.ReportObjects.Item("AdLine2")
            RptTextObj.Text = rtPrice4 'ADLong(2)
            '1081126 end 

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
            ReString = "c:\RPT\" & DateTemp & "\" & FileName & ".pdf" & "|" & Trim(dt.Rows(i).Item("wm_user_name")) & "|" & Trim(dt.Rows(i).Item("wm_email")) & "|" & Trim(dt.Rows(i).Item("mh_wm_no")) & "|" & "c:\RPT\" & DateTemp 'mh_wm_no
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
#End Region


#Region "ReportListNext　將資料逐筆填到報表內,再加密"
    Function ReportListNext(ByVal dt As DataTable, ByVal Val As Integer) As String
        Dim i As Integer
        Dim RptTextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim FileName As String
        Dim ReString As String
        Dim thisRptDoc As New ReportDocument
        Dim reader As PdfReader
        Dim stream As stream
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
        Dim bj As New Batch_job

        For i = 0 To dt.Rows.Count - 1
            FileName = Trim(dt.Rows(i)(9)) & Trim(dt.Rows(i)(13))
            ReString = PDFPath & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i)(49)) & "|" & Trim(dt.Rows(i)(44))
        Next
        ReportListNext = ReString 'PDFPath & FileName & ".pdf" & "|" & Trim(dt.Rows(i)(50)) & "|" & Trim(dt.Rows(i)(49))
    End Function
#End Region

#Region "TrueSend　真正送出Email的函數"
    Function TrueSend(ByVal FilePath As String, ByVal UserName As String, ByVal Email As String, ByVal REDate As String, ByVal WmNo As Integer)
        Dim Sendi As Integer
        Dim int_result As String
        int_result = SendMailB(FilePath, UserName, Email, REDate)
        'For Sendi = 0 To 2
        '    int_result = SendMailB(FilePath, UserName, Email, REDate)
        '    If int_result = "1" Then
        '        ' WriteDetailLog("1", "Receipt_batch_log", Sendi, "", WmNo)
        '        Exit For
        '    Else
        '        'WriteDetailLog("2", "Receipt_batch_log", Sendi, int_result, WmNo)
        '    End If
        'Next
        TrueSend = int_result
    End Function
#End Region

#Region "SendMailB　實際發送Email的程序"
    Function SendMailB(ByVal AttPath As String, ByVal ToUserName As String, ByVal ToEmail As String, ByVal REDate As String) As String
        Dim mailmsg As MailMessage
        Dim tcpclient As tcpclient
        Dim stream As NetworkStream
        Dim BodyStr As String
        Dim strmessage As String
        Dim check As Boolean
        Dim hostName As String = Dns.GetHostName
        Dim Att As MailAttachment
        Dim Temp As System.Text.Encoding
        Dim i As String
        Try
            '  SMTPCodeAdd()
            If thread_status = False Then
                thread_status = True
                mailmsg = New MailMessage
                mailmsg.From = "contactus@shinshingas.com.tw"
                mailmsg.To = ToEmail
                mailmsg.Subject = "欣欣天然氣" & Left(REDate, 3) & "/" & Right(REDate, 2) & "月份電子繳費憑證"
                mailmsg.Priority = MailPriority.Normal
                Temp = System.Text.Encoding.GetEncoding("big5")
                mailmsg.BodyFormat = MailFormat.Html
                BodyStr = "親愛的客戶:<br/><br/>"
                BodyStr = BodyStr & "感謝您使用欣欣天然氣電子繳費憑證，謹附上您本期的電子繳費憑證（請參閱附件ＰＤＦ檔）。<br/>"
                BodyStr = BodyStr & "開啟附加檔案需輸入<font color=red>密碼</font>方可瀏覽（密碼即「身份證字號<font color=blue>《第一碼英文字母須大寫》</font>或統一編號」）。<br/>"
                BodyStr = BodyStr & "若您有任何疑問，歡迎電洽本公司電話：02-2921-7811（可參閱天然氣費繳費憑證之業務分機）。<br/>"
                BodyStr = BodyStr & "敬祝  生活愉快<br/>"
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
                'Att = New MailAttachment(AttPath)
                mailmsg.Attachments.Add(AttPath)
                'If SendEmail("msa.hinet.net", 25, True, "欣欣天然氣", "22325804", mailmsg) = True Then ' "ebill"
                If SendEmail("mail.shinshingas.com.tw", 25, True, "contactus", "22325804", mailmsg) = True Then ' "ebill"
                    'message.Text = "補寄成功"

                    i = 1
                Else
                    'message.Text = "補寄失敗"
                    i = 0
                End If
            End If
        Catch ex As Exception
            i = ex.Message
            ' message.Text = "補寄失敗" & ex.StackTrace
        End Try
        thread_status = False
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
#If 1 Then
    Function WriteDetailLog(ByVal Status As Integer, ByVal TableName As String, ByVal reSend As Integer, ByVal StatusR As String, ByVal WmNo As Integer) As Integer
        Dim sqlStr As String = ""
        Dim Sql As String = ""
        Dim subStr As String = ""
        Dim i As Integer
        Dim bj As New Batch_job
        sqlStr = "Insert into " & TableName & " ( "
        For i = 1 To 22
            sqlStr = sqlStr & "rl_" & Format(i, "00") & ","
        Next
        sqlStr = sqlStr & "rl_rb_no,rl_file_srarus,rl_status,rl_status_Reason,rl_runtime,rl_resend,rl_wmno ) values ('"

        Sql = ""
        For i = 1 To 22
            Sql = Sql & Trim(DetailLog(i))
            Sql = Sql & "','"
        Next
        Sql = Sql & "0','1','" & Status & "','" & StatusR & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "'," & reSend & "," & WmNo & ")"
        subStr = sqlStr & Sql
        bj.Insert(subStr)
    End Function
#End If
#End Region


#If 1 Then
#Region "SendEmail　真正透過Socket送出信件內容"
    Private Function SendEmail(ByVal smtpServer As String, ByVal port As Integer, ByVal ESmtp As Boolean, ByVal username As String, ByVal password As String, ByVal mailMessage As MailMessage) As Boolean
        Dim priority As String
        Dim Html As Boolean
        Dim SendBuffer1() As String = New String(3) {}
        Dim SendBuffer2() As String = New String(1) {}
        Dim SendBufferstr As String
        Dim strSendFrom As String
        Dim strSendSubject As String ' 1130318   
        Dim encData_byte_1() As Byte = New Byte(username.Length) {}
        Dim encData_byte_2() As Byte = New Byte(password.Length) {}
        Dim encData_byte_3() As Byte = New Byte("郵件內容為HTML格，請選擇HTML方式查看".Length) {}
        Dim encData_byte_4() As Byte = New Byte(mailMessage.Body.Length) {}
        Dim encData_byte_5() As Byte = New Byte(mailMessage.Body.Length) {}
        Dim enCdata_byte_0() As Byte = New Byte(mailMessage.Subject.Length) {} ' 1130318 add 
        Dim enCdata_byte_F() As Byte = New Byte(10) {} ' 1130318 add 

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
            'SendBufferstr = "Subject:" & mailMessage.Subject & vbCrLf
            '1130318
            enCdata_byte_0 = System.Text.Encoding.Default.GetBytes(mailMessage.Subject)
            strSendSubject = Convert.ToBase64String(enCdata_byte_0)
            SendBufferstr = "Subject: =?big5?B?" & strSendSubject & "?=" & vbCrLf
        End If

        '1130318 
        enCdata_byte_F = System.Text.Encoding.Default.GetBytes("欣欣天然氣")
        strSendFrom = Convert.ToBase64String(enCdata_byte_F)

        SendBufferstr &= "X-Priority:" & priority & vbCrLf
        SendBufferstr &= "X-MSMail-Priority:" & priority & vbCrLf
        SendBufferstr &= "Importance:" & priority & vbCrLf
        SendBufferstr &= "X-Mailer:Lion. Web. Mail. SmtpMail Pubclass [cn]" & vbCrLf
        SendBufferstr &= "MIME-Version: 1.0" & vbCrLf
        'SendBufferstr &= "From:欣欣天然氣<" & mailMessage.From & ">" & vbCrLf
        SendBufferstr &= "From: =?big5?B?" & strSendFrom & "?=<" & mailMessage.From & ">" & vbCrLf
        SendBufferstr &= "to:" & mailMessage.To & vbCrLf
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
            tcpClient = New tcpClient
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

#Region "SendEReceipt  單或多筆補寄電子檔"
    Sub SendEReceipt()
        Msg1.Text = ""
        Dim bj As New Batch_job
        Dim dt As DataTable
        Dim TempStr As String
        Dim i As Integer = 0
        Dim selChkBxItem As CheckBox
        Dim selID As Label
        Dim objDataGridItem As DataGridItem
        Dim HouseNo As String
        Dim ReceiptDate As String
        Dim SendEmail As String
        Dim WmNo As String
        Dim UserName As String
        Dim RbNo As String
        Dim CurrInput As Integer
        Dim CheckCount As Integer = 0
        Dim SendCount As Integer = 0
        Dim FaiList As String = ""
        Dim j As Double
        For Each objDataGridItem In dgCart.Items
            selChkBxItem = objDataGridItem.FindControl("itemcheck")
            If selChkBxItem.Checked = True Then
                CheckCount += 1
                ClearCheckData()
                HouseNo = Trim(dgCart.Items(i).Cells(1).Text)
                ReceiptDate = Trim(dgCart.Items(i).Cells(2).Text)
                SendEmail = Trim(dgCart.Items(i).Cells(4).Text)
                WmNo = Trim(dgCart.Items(i).Cells(5).Text)
                UserName = Trim(dgCart.Items(i).Cells(6).Text)
                RbNo = Trim(dgCart.Items(i).Cells(9).Text)
                CurrInput = 2 ' Trim(Right(e.CommandName, 1))
                FillCheckData(HouseNo, ReceiptDate, WmNo, CurrInput, Trim(dgCart.Items(i).Cells(3).Text))
                dt = Compact(HouseNo, UserName, ReceiptDate, RbNo)
                If dt.Rows.Count > 0 Then
                    TempStr = ReportList(dt, 0)
                    Dim A() As String = Split(TempStr, "|")
                    'TrueSend(A(0), A(1), A(2), ReceiptDate, A(3))

                    '20150107 Bacom改讀A(2)****************************
                    'j = TrueSend(A(0), A(1), SendEmail, ReceiptDate, A(3))
                    j = TrueSend(A(0), A(1), A(2), ReceiptDate, A(3))
                    DataValues(5) = A(2)
                    '**************************************************
                    If j = 1 Then
                        SendCount += 1
                    Else
                        FaiList &= HouseNo & ","
                    End If
                    msgbox.Text = ""
                    bj.InsertSearchDataLog(DataValues, 0)
                    System.IO.File.Delete(A(0))
                    System.IO.Directory.Delete(A(4))
                End If
            End If
            i = i + 1
        Next
        Msg1.Text = "發送完成,共勾選 " & CheckCount & "筆. 寄出 " & SendCount & " 筆. "
        If FaiList <> "" Then
            Msg1.Text &= "失敗用戶號碼:" & Left(FaiList, Len(FaiList) - 1)
        End If
    End Sub
#End Region




#End Region




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        SendEReceipt()
    End Sub
End Class
