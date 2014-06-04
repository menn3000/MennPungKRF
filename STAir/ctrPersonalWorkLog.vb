Imports System.Globalization

Public Class ctrPersonalWorkLog
    Private cls As New clsDataSQL

    Dim DS As New DataSet
    Dim CurrentEmpAutoID As Integer


    Friend Sub LoadAndDisplayData(ByVal intEmpAutoID As Integer)
        If intEmpAutoID = 0 Then

            grdWorkLog.DataSource = Nothing
            ' ClearForm()
            Exit Sub

        End If
        CurrentEmpAutoID = intEmpAutoID
        'LoadEmployeeEduData(intEmpAutoID)
        'grdEmpPosHistory.Refresh()

    End Sub



    Private Sub dtFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromDate.ValueChanged

        If dtFromDate.Value > dtToDate.Value Then
            dtToDate.Value = dtFromDate.Value
        End If

        dtToDate.MinDate = dtFromDate.Value
        dtToDate.MaxDate = dtFromDate.MaxDate


    End Sub

    Private Sub ctrPersonalWorkLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFromDate.Value = New Date(Now.Year, Now.Month, 1)
        dtToDate.Value = New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
    End Sub


    Private Sub LoadWorkLogData(ByVal strEmpID As String)

        Me.Cursor = Cursors.WaitCursor

        Dim str(1) As String
        Dim tbl(1) As String

        Dim strSQL As String = ""

        'Select  h.HolidayName, l.ForDate, w.WorkLogName, l.DayAmount, l.HourAmount,l.RecordBy, l.DateTimeStamp, l.WorkLog_SetID, l.EmpAutoID, l.WorkLogTypeID , l.ID, w.IsOffWork, w.IsOverTime 


        'from tblEmpWorkLog l
        'left join tblHoliday h
        'ON l.ForDate= h.HolidayDate

        'join tblWorkLogType w  
        'on l.WorkLogTypeID = w.WorkLogID 

        'where l.EmpAutoID = 1 and l.ForDate between '1/Jan/2014 00:00:00' and '31/Jan/2014 23:59:59' 
        'and w.IsOverTime = 1  



        'Order by l.ForDate,l.WorkLogTypeID

        str(0) = "Select   l.ForDate,h.HolidayName, w.WorkLogName, l.DayAmount, l.HourAmount,l.RecordBy, l.DateTimeStamp, l.WorkLog_SetID, l.EmpAutoID, l.WorkLogTypeID , l.ID, w.IsOffWork, w.IsOverTime "
        str(0) += " from tblEmpWorkLog l"
        str(0) += " left join tblHoliday h"
        str(0) += " ON l.ForDate= h.HolidayDate"
        str(0) += " join tblWorkLogType w"
        str(0) += " on l.WorkLogTypeID = w.WorkLogID "
        str(0) += " where l.EmpAutoID = " & CurrentEmpAutoID.ToString
        str(0) += " and l.ForDate between '" & cls.CtypeDateToEng(dtFromDate.Value, 1) & "'"
        str(0) += " and '" & cls.CtypeDateToEng(dtToDate.Value, 2) & "'"

        If rblOffWork.Checked Then
            str(0) += " and w.IsOffWork = 1 "
        Else
            str(0) += " and w.IsOverTime = 1 "
        End If

        str(0) += " Order by l.ForDate,l.WorkLogTypeID"

        tbl(0) = "tblEmpWorkLog"


        Dim dsGrid As New DataSet
        dsGrid = cls.DB_GetDataSet_MultiTable(str, tbl, False)

        If dsGrid.Tables("tblEmpWorkLog").Rows.Count = 0 Then
            Me.grdWorkLog.DataSource = Nothing
            MsgBox("สิ้นสุดการค้นหา ไม่พบข้อมูลใดๆ ตรงตามข้อมูลที่คุณหา", MsgBoxStyle.Information)
            Me.grdWorkLog.Visible = False
            Me.Cursor = Cursors.Arrow
            ' Exit Sub
        End If

        If clsPermission.CheckWhatUserCanDO(clsUtility.DefaultAdminModuleLevel) >= clsPermission.WhatUserCanDo.CanWrite Then
            cmdAddWorkLog.Visible = True
            If dsGrid.Tables("tblEmpWorkLog").Rows.Count = 0 Then
                pnlGridFunction.Visible = False
            Else
                pnlGridFunction.Visible = True
            End If
        Else
            pnlGridFunction.Visible = False
            cmdAddWorkLog.Visible = False
        End If


        grdWorkLog.SuspendLayout()
        Me.grdWorkLog.DataSource = dsGrid
        Me.grdWorkLog.Visible = True

        grdWorkLog.Refresh()

        grdWorkLog.ResumeLayout(True)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        LoadWorkLogData(CurrentEmpAutoID)
    End Sub

    Private Sub grdWorkLog_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdWorkLog.BeforeCellActivate
        If Not e.Cell.Column.Key = "Select" Then
            e.Cell.Column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Else
            e.Cell.Column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
    End Sub

 

    Private Sub grdWorkLog_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdWorkLog.InitializeLayout

        Try
            grdWorkLog.DisplayLayout.Bands(0).Columns.Add("Select").DataType = GetType(Boolean)
            grdWorkLog.DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            grdWorkLog.DisplayLayout.Bands(0).Columns("Select").Header.VisiblePosition = 0
        Catch ex As Exception
        End Try

        grdWorkLog.DisplayLayout.AutoFitColumns = True



        grdWorkLog.DisplayLayout.Bands(0).Columns("HolidayName").Header.Caption = "วันหยุด"
        grdWorkLog.DisplayLayout.Bands(0).Columns("ForDate").Header.Caption = "วันที่"
        grdWorkLog.DisplayLayout.Bands(0).Columns("WorkLogName").Header.Caption = "การทำงาน"
        grdWorkLog.DisplayLayout.Bands(0).Columns("DayAmount").Header.Caption = "จำนวนวัน"
        grdWorkLog.DisplayLayout.Bands(0).Columns("HourAmount").Header.Caption = "จำนวนชั่วโมง"
        grdWorkLog.DisplayLayout.Bands(0).Columns("RecordBy").Header.Caption = "โดย"
        grdWorkLog.DisplayLayout.Bands(0).Columns("DateTimeStamp").Header.Caption = "บันทึกเมื่อ"


        With Me.grdWorkLog.DisplayLayout

            .Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("EmpAutoID").Hidden = True
            .Bands(0).Columns("WorkLogTypeID").Hidden = True
            .Bands(0).Columns("IsOffWork").Hidden = True
            .Bands(0).Columns("IsOverTime").Hidden = True
            .Bands(0).Columns("WorkLog_SetID").Hidden = True
            .Bands(0).Override.DefaultRowHeight = 30

            If rblOT.Checked Then
                .Bands(0).Columns("HolidayName").Hidden = False
            Else
                .Bands(0).Columns("HolidayName").Hidden = True
            End If

        End With

        Dim oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn
        For Each oColumn In Me.grdWorkLog.DisplayLayout.Bands(0).Columns
            oColumn.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Next

        'Dim cultureThTh As CultureInfo = CultureInfo.CreateSpecificCulture("th-th")
        e.Layout.Bands(0).Columns("ForDate").Format = "dd MMMM yyyy (dddd)"

        e.Layout.Bands(0).Columns("ForDate").CellAppearance.TextHAlign = Left

        '  e.Layout.Bands(0).Columns("ForDate").FormatInfo = cultureThTh

        e.Layout.Bands(0).Columns("DateTimeStamp").Format = "F"
        ' e.Layout.Bands(0).Columns("DateTimeStamp").CellAppearance.FontData.SizeInPoints = 10
        ' e.Layout.Bands(0).Columns("DateTimeStamp").FormatInfo = cultureThTh




    End Sub

    Private Sub grdWorkLog_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdWorkLog.InitializeRow
        'Select Case e.Row.Band.Index
        '    Case 0


        'End Select
    End Sub

   
    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        Dim i As Integer
        For i = grdWorkLog.Rows.Count - 1 To 0 Step -1
            grdWorkLog.ActiveRow = grdWorkLog.Rows(i)
            grdWorkLog.Rows(i).Cells("Select").Value = chkCheckAll.Checked

        Next
    End Sub

    Private Sub cmdAddNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewEmployee.Click
        BatchDeleteWorkLog()
    End Sub
    Private Sub BatchDeleteWorkLog()
        Me.Cursor = Cursors.WaitCursor

        Dim strIDs As String = ""

        Dim i, counter As Integer
        Dim ary As New ArrayList


        For i = 0 To grdWorkLog.Rows.Count - 1
            If grdWorkLog.Rows(i).Cells("Select").Value = True Then
                counter += 1
                Dim intID As Integer = grdWorkLog.Rows(i).Cells("ID").Value
                If strIDs = "" Then
                    strIDs = intID.ToString
                Else
                    strIDs += "," & intID.ToString
                End If
            End If
        Next

        If counter = 0 Then
            If Not grdWorkLog.ActiveRow Is Nothing Then
                strIDs = grdWorkLog.ActiveRow.Cells("ID").Value
            Else
                Me.Cursor = Cursors.Arrow
                MsgBox("คุณต้องเลือกรายการจากผลการค้าหาก่อน ถึงจะสามารถทำรายการนี้ได้", vbInformation)
                Exit Sub
            End If
        End If

        Me.Cursor = Cursors.Arrow

        If Not MsgBox("คุณกำลังจะลบข้อมูลบันทึกการทำงานของพนักงาน ดำเนินการต่อหรือไม่?", vbYesNo) = vbYes Then
            Exit Sub
        End If

        Dim strSQl As String = "Delete from tblEmpWorkLog where ID in ( " & strIDs & ")"
        cls.ExcuteData(strSQl)

        LoadWorkLogData(CurrentEmpAutoID)

    End Sub

    Private Sub cmdAddWorkLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddWorkLog.Click
        dgEmpWorkLog.ShowDialog(Me, CurrentEmpAutoID)

        If dgEmpWorkLog.bolSomeDataSaved = True Then
            LoadWorkLogData(CurrentEmpAutoID)
        End If
    End Sub
End Class

