Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmHoliday

    Private cls As New clsDataSQL
    Private clsCustomPemission As New clsPermission
    Dim DS As New DataSet


    Private Sub frmHoliday_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtFromDate.Value = Today

       
        dtFromDate.MinDate = New Date(dtYearDisplay.Value.Year, 1, 1)
        dtFromDate.MaxDate = New Date(dtYearDisplay.Value.Year + 1, 1, 31)


        LoadMainData()
        If IsDate(dtYearDisplay.Value) Then
            GetHoliday(dtYearDisplay.Value.Year.ToString)
        End If
    End Sub

    'Private Sub LoadYear()
    '    Dim dt As Date = Today.AddYears(1)
    '    Dim intYearThai As Integer
    '    For i As Int16 = 0 To 59

    '        intYearThai = dt.AddYears(-i).Year
    '        'If intYearThai < 2500 Then
    '        '    intYearThai += 543
    '        'End If
    '        cboYearDisplay.Items.Add(intYearThai)
    '    Next

    '    cboYearDisplay.SelectedIndex = -1
    '    cboYearDisplay.SelectedText = Today.Year


    'End Sub

    Private Sub GetHoliday(ByVal strYearToDisplay As String)
        Dim strSQL As String

        strSQL = "Select * from tblHoliday where IsEnable <> 0 and DATEPART(year, HolidayDate) = " & strYearToDisplay & "  order by HolidayDate"

        Dim dtb As New DataSet

        dtb = cls.DB_GetDataSet(strSQL, "tblHoliday")
        grdHoliday.DataSource = dtb

        If grdHoliday.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdHoliday.ActiveRow = grdHoliday.Rows(0)
        Else
            MsgBox("ยังไม่มีวันหยุดของปี " & dtYearDisplay.Value.Year.ToString & " กรุณาสร้างวันหยุด ", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub LoadMainData()

        Dim sql(1) As String
        Dim tbl(1) As String
        Dim strSQL As String = ""



        '----------------AUTO COMPLETE SOURCES--------------------------------

        sql(0) = "Select distinct HolidayName as data from tblHoliday  "
        tbl(0) = "HolidayName"



        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing

        SetAutoCompleteSource(txtHolidayName, DS.Tables("HolidayName"))

    End Sub
    Private Sub SetAutoCompleteSource(ByVal txt As TextBox, ByVal dtbData As DataTable)

        Dim source As New AutoCompleteStringCollection()

        Dim tr As DataRow
        Dim lstTemp As New List(Of String)
        For Each tr In dtbData.Rows
            If Not IsDBNull(tr("data")) Then
                lstTemp.Add(tr("data"))
            End If
        Next

        source.AddRange(lstTemp.ToArray)
        txt.AutoCompleteCustomSource = source
        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub

  

    Private Sub grdHoliday_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHoliday.AfterRowActivate

        If rblUpdateMode.Checked = True Then
            DisPlayInventoryInfoForEdit()
        End If


    End Sub
    Private Sub grdHoliday_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdHoliday.BeforeCellUpdate
        e.Cancel = True
    End Sub

    Private Sub grdHoliday_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdHoliday.InitializeLayout
        grdHoliday.DisplayLayout.AutoFitColumns = True


        grdHoliday.DisplayLayout.Bands(0).Columns("HolidayDate").Header.Caption = "วันที่"
        grdHoliday.DisplayLayout.Bands(0).Columns("HolidayName").Header.Caption = "ชื่อวันหยุด"

        Dim cultureThTh As CultureInfo = CultureInfo.CreateSpecificCulture("th-th")
        e.Layout.Bands(0).Columns("HolidayDate").Format = "D"
        e.Layout.Bands(0).Columns("HolidayDate").FormatInfo = cultureThTh

        grdHoliday.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdHoliday.DisplayLayout.Bands(0).Columns("IsEnable").Hidden = True




    End Sub

    Private Sub DisPlayInventoryInfoForEdit()

        rblUpdateMode.Checked = True

        dtFromDate.Value = grdHoliday.ActiveRow.Cells("HolidayDate").Value
        txtHolidayName.Text = grdHoliday.ActiveRow.Cells("HolidayName").Value

    End Sub

    Private Function CheckDBNull(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            Return obj
        End If
    End Function
    Private Sub ClearForm()
        txtHolidayName.Text = ""

    End Sub
    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdHoliday.ActiveRow = Nothing
            ClearForm()
            dtToDate.Enabled = True
            dtFromDate.Select()
            cmdDelete.Visible = False

        End If
    End Sub


    Private Sub rblUpdateMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblUpdateMode.CheckedChanged
        If rblUpdateMode.Checked = True Then
            If grdHoliday.Rows.Count > 0 Then
                grdHoliday.ActiveRow = grdHoliday.Rows(0)
                dtToDate.Enabled = False
                cmdDelete.Visible = True
            Else
                MsgBox("ยังไม่มีวันหยุดใดๆในระบบ กรุณาเพิ่มวันหยุดในระบบก่อน", vbQuestion)
            End If

        End If
    End Sub



    Private Sub grdHoliday_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdHoliday.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveData()
    End Sub


    Private Sub SaveData()
        If grdHoliday.ActiveRow Is Nothing Then
            SaveNewInv()
        Else
            UpdatedRecord(Me.grdHoliday.ActiveRow.Cells("ID").Value)
        End If
    End Sub
    Private Sub UpdatedRecord(ByVal intInvID As Integer)
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedInv(dtFromDate.Value, intInvID) = True Then
            Exit Sub
        End If


        Try
            Dim strSQL As String
            strSQL = "Update tblHoliday Set  "
            strSQL += " HolidayDate = '" & cls.CtypeDateToEng(dtFromDate.Value, 0) & "'"
            strSQL += " ,HolidayName = '" & txtHolidayName.Text & "'"
            strSQL += " Where ID = " & intInvID.ToString

            If cls.ExcuteData(strSQL, clsUtility.UserID) = True Then
                MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
                GetHoliday(dtYearDisplay.Value.Year.ToString)
            End If

        Catch ex As Exception
            MsgBox("มีความผิดพลาดเกิดขึ้น วันหยุดนี้ยังไม่ถูกแก้ไข " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        End Try



    End Sub

    Private Function checkISExistedInv(ByVal dtDate As Date, Optional ByVal intUpdatingInvID As Integer = 0) As Boolean

        Dim strSQL As String = "Select * from tblHoliday "
        strSQL += "  where HolidayDate = '" & cls.CtypeDateToEng(dtDate, 0) & "'"
        strSQL += "  and IsEnable <> 0 "

        If intUpdatingInvID > 0 Then
            strSQL += " and ID <> " & intUpdatingInvID.ToString
        End If

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then
            Dim msg As String = "วันหยุดนี้ถูกสร้างแล้วในระบบ กรุณาตรวจสอบ"
            dr.Close()
            MsgBox(msg, MsgBoxStyle.Critical)
            Return True
        Else
            dr.Close()
        End If
        Return False
    End Function
    Private Sub SaveNewInv()
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedInv(dtFromDate.Value) = True Then
            Exit Sub
        End If

        Dim objConn As New SqlConnection(clsUtility.LiveCNS)
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        ' Make the transaction.
        Dim trans As SqlTransaction = _
            objConn.BeginTransaction(IsolationLevel.ReadCommitted)


        Dim cmd As New SqlCommand
        cmd.Connection = objConn
        cmd.Transaction = trans
        cmd.CommandTimeout = 0

        Dim intNewInvID As Int64 = 0
        Dim strSQL As String = ""


        Try
            Dim aryDayToLeave As ArrayList = GetActualHoliday(dtFromDate.Value, dtToDate.Value)

            For Each dtToLeave As Date In aryDayToLeave
                cmd.CommandText = GetInsertInvSQL(dtToLeave)
                ' Execute the command.
                cmd.ExecuteNonQuery()
                'Get New ID just inserted
                cmd.CommandText = "Select @@Identity"
                intNewInvID = Int64.Parse(cmd.ExecuteScalar())

            Next

            trans.Commit()

        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น วันหยุดนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        Finally
            If Not objConn.State = ConnectionState.Closed Then objConn.Close()
        End Try

        If intNewInvID > 0 Then
            MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", vbInformation)
            GetHoliday(dtYearDisplay.Value.Year.ToString)
        End If


    End Sub

    Private Function GetActualHoliday(ByVal dtFromDate As Date, ByVal dtToDate As Date) As ArrayList

        Dim AmountDay As Int16 = DateDiff(DateInterval.Day, dtFromDate, dtToDate)

        Dim aryDate As New ArrayList

        If AmountDay < 1 Then
            aryDate.Add(dtFromDate)
            Return aryDate
        End If

        For i = 0 To AmountDay
            aryDate.Add(dtFromDate.AddDays(i))
        Next

        Return aryDate
    End Function

    Private Function GetInsertInvSQL(ByVal dtDate As Date) As String
        Dim strSQL As String
        strSQL = "Insert into tblHoliday (HolidayDate, HolidayName "
        strSQL += ") values ( "
        strSQL += "'" & cls.CtypeDateToEng(dtDate, 0) & "',"
        strSQL += "'" & txtHolidayName.Text & "'"
        strSQL += ")"

        Return strSQL
    End Function
    Private Function verifyInput() As Boolean

        Me.txtHolidayName.Text = Trim(Replace(txtHolidayName.Text, Chr(39), Chr(146)))

        If txtHolidayName.Text.Length = 0 Then
            MsgBox("กรุณาใส่ ชื่อวันหยุด", vbCritical)
            Return False
        End If



        Return True
    End Function


    Private Sub dtFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromDate.ValueChanged
        dtToDate.MinDate = dtFromDate.MinDate
        dtToDate.MaxDate = dtFromDate.MaxDate

        dtToDate.Value = dtFromDate.Value

        dtToDate.MinDate = dtFromDate.Value
        dtToDate.MaxDate = dtFromDate.MaxDate


    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        DeleteHoliday(Me.grdHoliday.ActiveRow.Cells("ID").Value)
    End Sub

    Private Sub DeleteHoliday(ByVal intInvID As Integer)

        Try
            Dim strSQL As String
            strSQL = "Update tblHoliday Set  "
            strSQL += " IsEnable = 0 "
            strSQL += " Where ID = " & intInvID.ToString

            If cls.ExcuteData(strSQL, clsUtility.UserID) = True Then
                MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
                GetHoliday(dtYearDisplay.Value.Year.ToString)
            End If

        Catch ex As Exception
            MsgBox("มีความผิดพลาดเกิดขึ้น วันหยุดนี้ยังไม่ถูกแก้ไข " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        End Try



    End Sub


  

    Private Sub dtYearDisplay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtYearDisplay.ValueChanged
        If IsDate(dtYearDisplay.Value) Then

            If dtYearDisplay.Value < dtYearDisplay.MinDate Or dtYearDisplay.Value > dtYearDisplay.MaxDate Then
                MsgBox("ปีที่คุณใส่ไม่ถูกต้อง", vbCritical)
                Exit Sub
            End If
            dtFromDate.MinDate = dtYearDisplay.MinDate
            dtFromDate.MaxDate = dtYearDisplay.MaxDate

            dtFromDate.Value = New Date(dtYearDisplay.Value.Year, 1, 1)

            dtFromDate.MinDate = New Date(dtYearDisplay.Value.Year, 1, 1)
            dtFromDate.MaxDate = New Date(dtYearDisplay.Value.Year + 1, 1, 31)
            GetHoliday(dtYearDisplay.Value.Year.ToString)
        End If
    End Sub
End Class