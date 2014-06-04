Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports System.Text

Public Class dgEmpWorkLog

    Private cls As New clsDataSQL
    Private strEmpID As String
    Private dsInfo As New DataSet
    Friend bolSomeDataSaved As Boolean = False


    Private Function verify() As Boolean

        If cboWorkLogType.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก บันทึกการทำงาน", vbCritical)
            cboWorkLogType.Select()
            Return False
        End If

        If dtForDate.Value > Today Then
            If cboWorkLogType.SelectedItem("IsOverTime") = True Then
                'เดี๋ยวกลัวไป conflict กับ วันลา เวลาที่เลือกวันมากกว่า 1
                MsgBox("ไม่อนุญาติให้ลงบันทึกการทำงานล่วงหน้าได้", vbCritical)
                cboWorkLogType.Select()
                Return False
            End If

        End If


        Return True
    End Function


    Private Sub SaveWorkRecord()

        If verify() = False Then
            Exit Sub
        End If

        Dim intEmpID As Integer = 0
        Dim intNewLogID As Integer
        Dim iCounter As Integer = 0
        Dim iErrorCounter As Integer = 0
        Dim iCompletedCounter As Integer

        Dim strWorkLog_SetID As String = ""

        Dim intDay As Integer = txtDayAmount.Value

        For Each TempRow In grdEmployees.Rows

            strWorkLog_SetID = System.Guid.NewGuid.ToString

            If intDay = 0 Then
                If SaveEachWorkLogForEachDay(TempRow, dtForDate.Value, intDay, strWorkLog_SetID) = True Then
                    iCompletedCounter += 1
                Else
                    iErrorCounter += 1
                End If
                iCounter += 1
            End If

            If intDay > 0 Then
                Dim subDayCompleted As Int16 = 0
                Dim subDayError As Int16 = 0

                For i As Integer = 1 To intDay
                    If SaveEachWorkLogForEachDay(TempRow, dtForDate.Value.AddDays(i - 1), 1, strWorkLog_SetID) = True Then
                        subDayCompleted += 1
                    Else
                        subDayError += 1
                    End If

                Next
                If subDayCompleted = intDay Then
                    iCompletedCounter += 1
                End If
                If subDayError > 0 Then
                    iErrorCounter += 1
                End If

                iCounter += 1
            End If

        Next


        AddStatus("สำเร็จ: " & iCompletedCounter & "คน ไม่สำเร็จ: " & iErrorCounter & "คน จากทั้งหมด: " & iCounter, Color.Black)
        AddStatus("----- ผลการบันทึก -------" & vbTab & Now.ToString, Color.Black)

        SearchEmployee(strEmpID)



    End Sub

    Private Function SaveEachWorkLogForEachDay(ByVal tempRow As UltraGridRow, ByVal dtMyForDate As Date, ByVal intDay As Integer, ByVal strWorkLog_SetID As String) As Boolean
        Dim bolReturn As Boolean = False

        Dim intEmpID As Integer = 0
        Dim intNewLogID As Integer

        intNewLogID = 0

        grdEmployees.ActiveRow = tempRow
        tempRow.Cells("EmployeeID").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Application.DoEvents()

        intEmpID = tempRow.Cells("ID").Value

        'WorkLog_SetID will be used to detemine how manytime emp request vacation or sick regardless of the amount leave

        Dim strSQL As String = ""
        strSQL = "Insert into tblEmpWorkLog (ForDate,EmpAutoID,WorkLogTypeID,DayAmount,HourAmount,RecordBy,DateTimeStamp,WorkLog_SetID) Values "
        strSQL += "(@ForDate,@EmpAutoID,@WorkLogTypeID,@DayAmount,@HourAmount,@RecordBy,CURRENT_TIMESTAMP, @WorkLog_SetID)"

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strSQL
        cmd.Parameters.AddWithValue("@ForDate", dtMyForDate)
        cmd.Parameters.AddWithValue("@EmpAutoID", intEmpID)
        cmd.Parameters.AddWithValue("@WorkLogTypeID", cboWorkLogType.SelectedValue)
        cmd.Parameters.AddWithValue("@DayAmount", intDay)
        cmd.Parameters.AddWithValue("@HourAmount", txtHours.Value)
        cmd.Parameters.AddWithValue("@RecordBy", clsUtility.UserFName)
        cmd.Parameters.AddWithValue("@WorkLog_SetID", strWorkLog_SetID)

        intNewLogID = cls.ExcuteData(cmd)

        If intNewLogID > 0 Then
            bolReturn = True
            AddStatus(vbTab & tempRow.Cells("FullName").Value & " บันทึกเรียบร้อยแล้ว ", Color.Blue)
        Else
            bolReturn = False
            AddStatus("***" & vbTab & tempRow.Cells("FullName").Value & " ไม่สามารถบันทึกได้ กรุณาตรวจสอบอีกครั้ง", Color.Red)
        End If

        tempRow.Cells("EmployeeID").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False

        Return bolReturn
    End Function


    Private Sub AddStatus(ByVal text As String, ByVal TextColor As Color)
        rtxtStatus.Select(0, 0)
        rtxtStatus.SelectionColor = TextColor
        rtxtStatus.SelectedText = vbCrLf & text
    End Sub
    Private Sub SaveWorkRecord2()

        If verify() = False Then
            Exit Sub
        End If

        Dim strSQL As String = ""

        Dim intEmpID As Integer = 0
        Dim intNewLogID As Integer
        Dim iCounter As Integer = 0
        Dim iErrorCounter As Integer = 0
        Dim iCompletedCounter As Integer

        Dim strWorkLog_SetID As String = ""

        Dim intDay As Integer = txtDayAmount.Value
        Dim objConn As New SqlConnection(clsUtility.LiveCNS)


        For Each TempRow In grdEmployees.Rows
            strWorkLog_SetID = System.Guid.NewGuid.ToString


            Dim aryDayToWork As New ArrayList

            If CheckHolidayForWorkExtra(aryDayToWork, dtForDate.Value, txtDayAmount.Value) = False Then
                MsgBox("วันที่ บางวัน ไม่ใช่วันหยุด หรือ วันเสาร์-อาทิตย์. ไม่สามารถบันทึกการทำงานนี้ได้ กรุณาตรวจสอบรายละเอียดจากสถานะด้านล่าง", vbCritical)
                Exit Sub
            End If


            If Not objConn.State = ConnectionState.Open Then objConn.Open()
            ' Make the transaction.
            Dim trans As SqlTransaction = _
                objConn.BeginTransaction(IsolationLevel.ReadCommitted)

            Dim cmd As New SqlCommand
            cmd.Connection = objConn
            cmd.Transaction = trans
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            Try
                'check existing record
                Dim bolFoundConflict As Boolean = False
                strSQL = "Select w.WorkLogName, l.* , w.IsOffWork, w.IsOverTime"
                strSQL += " from tblEmpWorkLog l, tblWorkLogType w "
                strSQL += " where l.EmpAutoID = " & TempRow.Cells("ID").Value
                strSQL += " and l.ForDate between '" & cls.CtypeDateToEng(dtForDate.Value, 1) & "'"
                strSQL += " and '" & cls.CtypeDateToEng(getLastDateToleave(aryDayToWork), 2) & "'"
                strSQL += " and l.WorkLogTypeID = w.WorkLogID "
                strSQL += " Order by w.IsOffWork, l.WorkLogTypeID, l.ForDate"

                cmd.CommandText = strSQL

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    Do While dr.Read
                        If Not dr("IsOffWork") = cboWorkLogType.SelectedItem("IsOffWork") Then
                            AddStatus(TempRow.Cells("FullName").Value & " ไม่สามารถใช้บันทึกการทำงาน """ & cboWorkLogType.SelectedItem("WorkLogName") & """ ได้ เนื่องจากขัดกันกับ บันทึกการทำงานที่มีอยู่ก่อนแล้ว """ & dr("WorkLogName") & """ ในวันที่ " & dr("ForDate"), Color.Red)
                            bolFoundConflict = True
                        End If
                    Loop
                End If
                dr.Close()

                If bolFoundConflict = True Then
                    GoTo NextRow
                End If


                For Each dtToLeave As Date In aryDayToWork
                    intNewLogID = 0
                   
                    intEmpID = TempRow.Cells("ID").Value

                    strSQL = "Insert into tblEmpWorkLog (ForDate,EmpAutoID,WorkLogTypeID,DayAmount,HourAmount,RecordBy,DateTimeStamp,WorkLog_SetID) Values "
                    strSQL += "(@ForDate,@EmpAutoID,@WorkLogTypeID,@DayAmount,@HourAmount,@RecordBy,CURRENT_TIMESTAMP, @WorkLog_SetID)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("@ForDate", dtToLeave)
                    cmd.Parameters.AddWithValue("@EmpAutoID", intEmpID)
                    cmd.Parameters.AddWithValue("@WorkLogTypeID", cboWorkLogType.SelectedValue)
                    If txtDayAmount.Value = 0 Then
                        'ถ้า ไม่ถึงวัน
                        cmd.Parameters.AddWithValue("@DayAmount", 0)
                    Else
                        cmd.Parameters.AddWithValue("@DayAmount", 1)
                    End If

                    cmd.Parameters.AddWithValue("@HourAmount", txtHours.Value)
                    cmd.Parameters.AddWithValue("@RecordBy", clsUtility.UserFName)
                    cmd.Parameters.AddWithValue("@WorkLog_SetID", strWorkLog_SetID)

                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    cmd.CommandText = "Select @@Identity"
                    intNewLogID = Int16.Parse(cmd.ExecuteScalar())


                    If intNewLogID > 0 Then
                        AddStatus(vbTab & TempRow.Cells("FullName").Value & " วันที่ " & dtToLeave.ToShortDateString & " บันทึกเรียบร้อยแล้ว ", Color.Blue)
                    Else
                        AddStatus(vbTab & TempRow.Cells("FullName").Value & " วันที่ " & dtToLeave.ToShortDateString & " ไม่ถูกบันทึก ", Color.Red)
                    End If

                Next

                trans.Commit()
                iCompletedCounter += 1
                TempRow.Cells("EmployeeID").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False


NextRow:
            Catch ex As Exception
                trans.Rollback()
                MsgBox("มีความผิดพลาดเกิดขึ้น ข้อมูลยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
                iErrorCounter += 1
                AddStatus("มีความผิดพลาด....การบันทึกข้อมูลของ " & TempRow.Cells("FullName").Value & " ถูกยกเลิก", Color.Red)

                'clsDataSQL.WriteLog("dgEmpWorkLog.SaveWorkLog: " & vbCrLf & ex.StackTrace, ex.Message)
            Finally
                If Not objConn.State = ConnectionState.Closed Then objConn.Close()
            End Try

            iCounter += 1

nextRow2:

        Next


        AddStatus("สำเร็จ: " & iCompletedCounter & "คน ไม่สำเร็จ: " & iErrorCounter & "คน จากทั้งหมด: " & iCounter, Color.Black)
        AddStatus("----- ผลการบันทึก -------" & vbTab & Now.ToString, Color.Black)

        SearchEmployee(strEmpID)

    End Sub

    Private Sub SaveLeavRecord()

        If verify() = False Then
            Exit Sub
        End If

        Dim strSQL As String = ""

        Dim intEmpID As Integer = 0
        Dim intNewLogID As Integer
        Dim iCounter As Integer = 0
        Dim iErrorCounter As Integer = 0
        Dim iCompletedCounter As Integer

        Dim strWorkLog_SetID As String = ""

        Dim intDay As Integer = txtDayAmount.Value
        Dim objConn As New SqlConnection(clsUtility.LiveCNS)

        Dim aryDayToLeave As ArrayList



        For Each TempRow In grdEmployees.Rows
            strWorkLog_SetID = System.Guid.NewGuid.ToString

            If cboWorkLogType.SelectedItem("IsOffWork") = True Then
                'SAVING OFFWORK TYPE
                aryDayToLeave = GetActualDayForLeaving(dtForDate.Value, txtDayAmount.Value)
                If ConfirmMultipleDayProcesing(aryDayToLeave) = False Then
                    GoTo NextRow2
                End If
            Else
                'SAVING EXTRAWORK TYPE
                aryDayToLeave = New ArrayList
                If CheckHolidayForWorkExtra(aryDayToLeave, dtForDate.Value, txtDayAmount.Value) = False Then
                    MsgBox("วันที่ บางวัน ไม่ใช่วันหยุด หรือ วันเสาร์-อาทิตย์. ไม่สามารถบันทึกการทำงานนี้ได้ กรุณาตรวจสอบรายละเอียดจากสถานะด้านล่าง", vbCritical)
                    Exit Sub
                End If
            End If



            If Not objConn.State = ConnectionState.Open Then objConn.Open()
            ' Make the transaction.
            Dim trans As SqlTransaction = _
                objConn.BeginTransaction(IsolationLevel.ReadCommitted)

            Dim cmd As New SqlCommand
            cmd.Connection = objConn
            cmd.Transaction = trans
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            Try
                'check existing record
                Dim bolFoundConflict As Boolean = False
                strSQL = "Select w.WorkLogName, l.* , w.IsOffWork, w.IsOverTime"
                strSQL += " from tblEmpWorkLog l, tblWorkLogType w "
                strSQL += " where l.EmpAutoID = " & TempRow.Cells("ID").Value
                strSQL += " and l.ForDate between '" & cls.CtypeDateToEng(dtForDate.Value, 1) & "'"
                strSQL += " and '" & cls.CtypeDateToEng(getLastDateToleave(aryDayToLeave), 2) & "'"
                strSQL += " and l.WorkLogTypeID = w.WorkLogID "
                strSQL += " Order by w.IsOffWork, l.WorkLogTypeID, l.ForDate"

                cmd.CommandText = strSQL

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    Do While dr.Read
                        If Not dr("IsOffWork") = cboWorkLogType.SelectedItem("IsOffWork") Then
                            AddStatus(TempRow.Cells("FullName").Value & " ไม่สามารถใช้บันทึกการทำงาน """ & cboWorkLogType.SelectedItem("WorkLogName") & """ ได้ เนื่องจากขัดกันกับ บันทึกการทำงานที่มีอยู่ก่อนแล้ว """ & dr("WorkLogName") & """ ในวันที่ " & dr("ForDate"), Color.Red)
                            bolFoundConflict = True
                        End If
                    Loop
                End If
                dr.Close()

                If bolFoundConflict = True Then
                    GoTo NextRow
                End If


                For Each dtToLeave As Date In aryDayToLeave
                    intNewLogID = 0
                    'grdEmployees.ActiveRow = TempRow
                    'TempRow.Cells("EmployeeID").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    'Application.DoEvents()
                    intEmpID = TempRow.Cells("ID").Value

                    strSQL = "Insert into tblEmpWorkLog (ForDate,EmpAutoID,WorkLogTypeID,DayAmount,HourAmount,RecordBy,DateTimeStamp,WorkLog_SetID) Values "
                    strSQL += "(@ForDate,@EmpAutoID,@WorkLogTypeID,@DayAmount,@HourAmount,@RecordBy,CURRENT_TIMESTAMP, @WorkLog_SetID)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("@ForDate", dtToLeave)
                    cmd.Parameters.AddWithValue("@EmpAutoID", intEmpID)
                    cmd.Parameters.AddWithValue("@WorkLogTypeID", cboWorkLogType.SelectedValue)
                    If txtDayAmount.Value = 0 Then
                        'ถ้าเป็นการลาแค่ ไม่ถึงวัน
                        cmd.Parameters.AddWithValue("@DayAmount", 0)
                    Else
                        cmd.Parameters.AddWithValue("@DayAmount", 1)
                    End If

                    cmd.Parameters.AddWithValue("@HourAmount", txtHours.Value)
                    cmd.Parameters.AddWithValue("@RecordBy", clsUtility.UserFName)
                    cmd.Parameters.AddWithValue("@WorkLog_SetID", strWorkLog_SetID)

                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    cmd.CommandText = "Select @@Identity"
                    intNewLogID = Int16.Parse(cmd.ExecuteScalar())


                    If intNewLogID > 0 Then
                        AddStatus(vbTab & TempRow.Cells("FullName").Value & " วันที่ " & dtToLeave.ToShortDateString & " บันทึกเรียบร้อยแล้ว ", Color.Blue)
                    Else
                        AddStatus(vbTab & TempRow.Cells("FullName").Value & " วันที่ " & dtToLeave.ToShortDateString & " ไม่ถูกบันทึก ", Color.Red)
                    End If

                Next

                trans.Commit()
                iCompletedCounter += 1
                TempRow.Cells("EmployeeID").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
                bolSomeDataSaved = True

NextRow:
            Catch ex As Exception
                trans.Rollback()
                MsgBox("มีความผิดพลาดเกิดขึ้น ข้อมูลยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
                iErrorCounter += 1
                AddStatus("มีความผิดพลาด....การบันทึกข้อมูลของ " & TempRow.Cells("FullName").Value & " ถูกยกเลิก", Color.Red)

                'clsDataSQL.WriteLog("dgEmpWorkLog.SaveWorkLog: " & vbCrLf & ex.StackTrace, ex.Message)
            Finally
                If Not objConn.State = ConnectionState.Closed Then objConn.Close()
            End Try

            iCounter += 1

nextRow2:

        Next


        AddStatus("สำเร็จ: " & iCompletedCounter & "คน ไม่สำเร็จ: " & iErrorCounter & "คน จากทั้งหมด: " & iCounter, Color.Black)
        AddStatus("----- ผลการบันทึก -------" & vbTab & Now.ToString, Color.Black)

        SearchEmployee(strEmpID)

    End Sub
    Private Function ConfirmMultipleDayProcesing(ByVal aryActualDayProcessing As ArrayList) As Boolean

        If aryActualDayProcessing.Count = 1 Then
            Return True
        End If


        Dim str As New StringBuilder

        str.AppendLine("ระบบได้ทำการตรวจสอบวันหยุดกับฐานข้อมูล")
        str.AppendLine("กรุณาตรวจสอบวันที่ทั้งหมดอีกครั้ง")
        str.AppendLine("")
        For Each dt As Date In aryActualDayProcessing
            str.AppendLine(String.Format("วันที่ : {0}", dt.ToShortDateString))
        Next
        str.AppendLine("")
        str.AppendLine("หากวันที่ไม่ถูกต้องกรุณากด No เพื่อกลับไปแก้ไข")

        If MsgBox(str.ToString, vbYesNo) = vbYes Then
            Return True
        End If

        Return False
    End Function

    
    Private Function CheckHolidayForWorkExtra(ByRef aryDateFromUsers As ArrayList, ByVal dtStartDate As Date, ByVal AmountDay As Integer) As Boolean
        'Dim aryDateFromUsers As New ArrayList

        Dim bolFoundHoliday As Boolean = False
        Dim bolDateIsHoliday As Boolean = False
        Dim bolSomeDateInvalid As Boolean = False

        Dim strSQL As String = ""
        strSQL = "Select * from tblHoliday where IsEnable <> 0 "

        For i = 1 To AmountDay
            Dim dtDateToLeave As Date
            dtDateToLeave = dtStartDate.AddDays(i - 1)
            If i = 1 Then ' First Date
                strSQL += "and HolidayDate >= '" & cls.CtypeDateToEng(dtDateToLeave, 1) & "' "
            End If
            'Add Each Date to Array 
            aryDateFromUsers.Add(dtStartDate.AddDays(i - 1))
        Next
        strSQL += " order by HolidayDate" ' this is important, must be sort by HolidayDate for later use
        Dim ds As New DataSet
        ds = cls.DB_GetDataSet(strSQL, "tblHoliday")

        Dim dtbHoliday As DataTable
        dtbHoliday = ds.Tables("tblHoliday")

        If dtbHoliday.Rows.Count = 0 Then
            bolFoundHoliday = False
        Else
            bolFoundHoliday = True
        End If

        ' NOW MATCH THE DATE WITH WEEKEND AND HOLIDAY

        For Each dateFromUser As Date In aryDateFromUsers

            bolDateIsHoliday = False

            'CHECK FOR WEEKEND AND MAKR FLAG
            If dateFromUser.DayOfWeek.ToString.ToLower = "saturday" Then
                bolDateIsHoliday = True
            ElseIf dateFromUser.DayOfWeek.ToString.ToLower = "sunday" Then
                bolDateIsHoliday = True
            End If

            If bolDateIsHoliday = True Then
                'SO WE DO NOT NEED TO LOOP THROUG THE HOLIDAY 
                GoTo nextDate
            End If

            Dim tr As DataRow
            For Each tr In dtbHoliday.Rows
                If dateFromUser = tr("HolidayDate") Then
                    bolDateIsHoliday = True
                    Exit For
                End If
            Next

            If bolDateIsHoliday = False Then
                AddStatus(String.Format("วันที่ {0} ไม่ใช่วันหยุด หรือ วันเสาร์-อาทิตย์. ไม่สามารถบันทึกการทำงานนี้ได้", dateFromUser.ToShortDateString), Color.Red)
                bolSomeDateInvalid = True

            End If
nextDate:
        Next

        If bolSomeDateInvalid = True Then
            Return False
        End If

        Return True

    End Function

    Private Function GetActualDayForLeaving(ByVal dtStartDate As Date, ByVal AmountDay As Integer) As ArrayList

        Dim aryDateFromUsers As New ArrayList


        If AmountDay < 1 Then
            Return aryDateFromUsers
        End If

        Dim bolFoundHoliday As Boolean = False

        Dim strSQL As String = ""
        strSQL = "Select * from tblHoliday where IsEnable <> 0 "


        For i = 1 To AmountDay
            Dim dtDateToLeave As Date
            dtDateToLeave = dtStartDate.AddDays(i - 1)
            If i = 1 Then ' First Date
                strSQL += "and HolidayDate >= '" & cls.CtypeDateToEng(dtDateToLeave, 1) & "' "
            End If
            'Add Each Date to Array 
            aryDateFromUsers.Add(dtStartDate.AddDays(i - 1))
        Next

        strSQL += " order by HolidayDate" ' this is important, must be sort by HolidayDate for later use


        Dim ds As New DataSet
        ds = cls.DB_GetDataSet(strSQL, "tblHoliday")

        Dim dtb As DataTable
        dtb = ds.Tables("tblHoliday")

        If dtb.Rows.Count = 0 Then
            bolFoundHoliday = False
        Else
            bolFoundHoliday = True
        End If

        Dim aryDateAfterSkipWeekendAndHoliday As New ArrayList

        ' set the eairliest date as first start point
        Dim dtActualDateToleave As Date = aryDateFromUsers.Item(0)

        'Check for sat and Sun


        For Each dateFromUser As Date In aryDateFromUsers

            'Check the privous date were change to avoid weekend and holiday
            If Not dateFromUser = dtActualDateToleave Then
                dateFromUser = dtActualDateToleave
            End If

            'First Check for Weekend, if it is weekend then make it Monday else keep the date
            dateFromUser = CalcDateToLeaveSkipWeekEnd(dateFromUser)

            'if found Holiday from DB make it the next day and restart the process all over agian
            If bolFoundHoliday = True Then
                dateFromUser = CalcDateToleaveSkipHoliday(dateFromUser, dtb)
            End If

            'set the result to our new vairable so we can set the next startPoint
            dtActualDateToleave = dateFromUser
            'Add the FinalDate to the return Array
            aryDateAfterSkipWeekendAndHoliday.Add(dtActualDateToleave)

            ' Set next start point for next DateFromUser
            dtActualDateToleave = dtActualDateToleave.AddDays(1)
        Next


        Return aryDateAfterSkipWeekendAndHoliday
    End Function

    Private Function CalcDateToLeaveSkipWeekEnd(ByVal dtDateToLeave As Date) As Date
        If dtDateToLeave.DayOfWeek.ToString.ToLower = "saturday" Then
            dtDateToLeave = dtDateToLeave.AddDays(2)
        ElseIf dtDateToLeave.DayOfWeek.ToString.ToLower = "sunday" Then
            dtDateToLeave = dtDateToLeave.AddDays(1)
        End If

        Return dtDateToLeave
    End Function

    Private Function CalcDateToleaveSkipHoliday(ByVal dtDateToLeave As Date, ByVal dtbHoliday As DataTable) As Date


        Dim tr As DataRow
        For Each tr In dtbHoliday.Rows
            If dtDateToLeave = tr("HolidayDate") Then
                dtDateToLeave = dtDateToLeave.AddDays(1)
                'ReCheck ForWeekend after changeDate
                dtDateToLeave = CalcDateToLeaveSkipWeekEnd(dtDateToLeave)
                'ReCheck For Holiday After change date
                dtDateToLeave = CalcDateToleaveSkipHoliday(dtDateToLeave, dtbHoliday)
                Exit For
            End If
        Next

        Return dtDateToLeave

    End Function
    Private Function getLastDateToleave(ByVal aryDayToleave As ArrayList)



        If aryDayToleave.Count = 0 Then
            Return dtForDate.Value
        End If

        Dim MaxDate As Date = aryDayToleave.Item(0)

        For Each dtDate As Date In aryDayToleave
            If MaxDate < dtDate Then
                MaxDate = dtDate
            End If
        Next

        Return MaxDate
    End Function
    Friend Overloads Function ShowDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal intEmpID As Integer) As System.Windows.Forms.DialogResult
        bolSomeDataSaved = False
        Me.SuspendLayout()

        strEmpID = intEmpID.ToString

        ClearForm()

        LoadData()

        SearchEmployee(strEmpID)

        Me.WindowState = FormWindowState.Maximized
        Me.ResizeRedraw = True

        Me.ResumeLayout()

        Return ShowDialog(owner)

    End Function

    Friend Overloads Function ShowDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal aryEmpID As ArrayList) As System.Windows.Forms.DialogResult
        bolSomeDataSaved = False
        Me.SuspendLayout()

        strEmpID = ""

        For Each i As Integer In aryEmpID
            If strEmpID = "" Then
                strEmpID = i.ToString
            Else
                strEmpID += "," & i.ToString
            End If

        Next



        ClearForm()

        LoadData()

        SearchEmployee(strEmpID)



        Me.WindowState = FormWindowState.Maximized
        Me.ResizeRedraw = True

        Me.ResumeLayout()

        Return ShowDialog(owner)

    End Function

    Private Sub ClearForm()
        Me.txtDayAmount.Value = 1
        Me.txtHours.Value = 0
        dtForDate.Value = Today
        cboWorkLogType.SelectedIndex = -1
        rtxtStatus.Text = ""

    End Sub


    Private Sub SearchEmployee(ByVal strEmpID As String)

        Me.Cursor = Cursors.WaitCursor



        Dim str(2) As String
        Dim tbl(2) As String

        Dim strSQL As String = ""

        strSQL += "Select  e.EmployeeID,  p.PositionAbv + ' ' + e.FName + ' ' + e.LName as FullName, c.CategoryName  "
        strSQL += " ,e.Email, e.MobilePhone , e.ID, e.CurrentPositionID as PID"
        strSQL += " from tblEmployees e, tblPositions p, Category c "

        strSQL += " where e.[CurrentPositionID] = p.[ID] "
        strSQL += " and c.CategoryID  = e.MainCategory "
        strSQL += " and e.ID in ( " & strEmpID & ")"
        strSQL += " order by c.CategoryLevel, p.positionAbv, e.Fname"


        str(0) = strSQL
        tbl(0) = "tblEmployees"



        str(1) = "Select w.WorkLogName, l.* , w.IsOffWork, w.IsOverTime"
        str(1) += " from tblEmpWorkLog l, tblWorkLogType w "
        str(1) += " where l.EmpAutoID in ( " & strEmpID & ")"
        str(1) += " and l.ForDate between '" & cls.CtypeDateToEng(dtForDate.Value, 1) & "'"
        str(1) += " and '" & cls.CtypeDateToEng(dtForDate.Value, 2) & "'"
        str(1) += " and l.WorkLogTypeID = w.WorkLogID "
        str(1) += " Order by l.WorkLogTypeID"

        tbl(1) = "tblEmpWorkLog"



        Dim dsGrid As New DataSet
        dsGrid = cls.DB_GetDataSet_MultiTable(str, tbl, False)


        'Relationship 

        Dim Keys(0) As DataColumn
        Keys(0) = dsGrid.Tables("tblEmployees").Columns("ID")
        dsGrid.Tables("tblEmployees").PrimaryKey = Keys

        Dim Keys2(1) As DataColumn
        Keys2(0) = dsGrid.Tables("tblEmpWorkLog").Columns("ID")
        Keys2(1) = dsGrid.Tables("tblEmpWorkLog").Columns("EmpAutoID")
        dsGrid.Tables("tblEmpWorkLog").PrimaryKey = Keys2


        Dim relEmpLog As New DataRelation("rel1" _
        , dsGrid.Tables("tblEmployees").Columns("ID") _
        , dsGrid.Tables("tblEmpWorkLog").Columns("EmpAutoID"))
        dsGrid.Relations.Add(relEmpLog)
        '----------------------------------------------------



        If dsGrid.Tables("tblEmployees").Rows.Count = 0 Then

            Me.grdEmployees.DataSource = Nothing
            MsgBox("สิ้นสุดการค้นหา ไม่พบพนักงาน ตรงตามข้อมูลที่คุณหา", MsgBoxStyle.Information)
            Me.grdEmployees.Visible = False
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        grdEmployees.SuspendLayout()
        Me.grdEmployees.DataSource = dsGrid
        Me.grdEmployees.Visible = True

        grdEmployees.Refresh()

        grdEmployees.ResumeLayout(True)


        Me.Cursor = Cursors.Arrow
    End Sub


  
    Private Sub LoadData()
        Dim strSQL As String = ""
        strSQL = "Select * from tblWorkLogType where IsActive = 1  order by WorkLogID"


        Dim str(1) As String
        Dim tbl(1) As String


        strSQL = "Select * from tblWorkLogType where IsActive = 1  order by WorkLogID"

        str(0) = strSQL
        tbl(0) = "tblWorkLogType"



        dsInfo = cls.DB_GetDataSet_MultiTable(str, tbl, False)

        Dim dtbEmp As DataTable = DirectCast(grdEmployees.DataSource, DataSet).Tables("tblEmployees")

        Me.cboWorkLogType.DisplayMember = "WorkLogName"
        cboWorkLogType.ValueMember = "WorkLogID"


        If dtbEmp.Rows.Count > 1 Then ' only allow add IsOffWork = False for multiAdding
            Dim dtv As New DataView(dsInfo.Tables("tblWorkLogType"), "IsOffWork = 0", "WorkLogID", DataViewRowState.CurrentRows)
            Me.cboWorkLogType.DataSource = dtv.ToTable
        Else ' if only one emp allow adding everything
            Me.cboWorkLogType.DataSource = dsInfo.Tables("tblWorkLogType")
        End If




        cboWorkLogType.SelectedIndex = -1



    End Sub

    Private Sub dtForDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtForDate.ValueChanged

        'If Not dtForDate.Value.Year = CurrentYearHolliday Then
        '    LoadData()
        'End If

        SearchEmployee(strEmpID)
    End Sub

    Private Sub grdEmployees_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdEmployees.BeforeCellUpdate
        e.Cancel = True
    End Sub

    Private Sub grdEmployees_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEmployees.InitializeLayout


        grdEmployees.DisplayLayout.AutoFitColumns = True


        grdEmployees.DisplayLayout.Bands(0).Columns("EmployeeID").Header.Caption = "รหัสพนักงาน"
        grdEmployees.DisplayLayout.Bands(0).Columns("FullName").Header.Caption = "ชื่อ"
        grdEmployees.DisplayLayout.Bands(0).Columns("Email").Header.Caption = "อีเมล์"
        grdEmployees.DisplayLayout.Bands(0).Columns("MobilePhone").Header.Caption = "มือถือ"
        grdEmployees.DisplayLayout.Bands(0).Columns("CategoryName").Header.Caption = "สังกัด"


        grdEmployees.DisplayLayout.Bands(1).Columns("ForDate").Header.Caption = "วันที่"
        grdEmployees.DisplayLayout.Bands(1).Columns("WorkLogName").Header.Caption = "การทำงาน"
        grdEmployees.DisplayLayout.Bands(1).Columns("DayAmount").Header.Caption = "จำนวนวัน"
        grdEmployees.DisplayLayout.Bands(1).Columns("HourAmount").Header.Caption = "จำนวนชั่วโมง"
        grdEmployees.DisplayLayout.Bands(1).Columns("RecordBy").Header.Caption = "โดย"
        grdEmployees.DisplayLayout.Bands(1).Columns("DateTimeStamp").Header.Caption = "บันทึกเมื่อ"




        With Me.grdEmployees.DisplayLayout




            .Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free

            Dim col As Infragistics.Win.UltraWinGrid.UltraGridColumn
            For Each col In Me.grdEmployees.DisplayLayout.Bands(0).Columns
                If col.Key = "FullName" Then
                    col.Width = (grdEmployees.Width * 0.25)

                End If
            Next

            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("PID").Hidden = True
            .Bands(0).Columns("Email").Hidden = True
            .Bands(0).Columns("MobilePhone").Hidden = True
            .Bands(0).Columns("EmployeeID").Hidden = True




            .Bands(1).Columns("ID").Hidden = True
            .Bands(1).Columns("EmpAutoID").Hidden = True
            .Bands(1).Columns("ForDate").Hidden = True
            .Bands(1).Columns("WorkLogTypeID").Hidden = True
            .Bands(1).Columns("IsOffWork").Hidden = True
            .Bands(1).Columns("IsOverTime").Hidden = True
            .Bands(1).Columns("WorkLog_SetID").Hidden = True




            '.Bands(0).Columns("EmployeeID").Width = (grdEmployees.Width * 15) / 100
            '.Bands(0).Columns("FullName").Width = (grdEmployees.Width * 25) / 100
            '.Bands(0).Columns("email").Width = (grdEmployees.Width * 25) / 100
            '.Bands(0).Columns("MobilePhone").Width = (grdEmployees.Width * 35) / 100


            .Bands(0).Override.DefaultRowHeight = 30

        End With

        'Me.grdEmployees.DisplayLayout.Bands(0).Columns("FullName").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
        'Me.grdEmployees.DisplayLayout.Bands(0).Columns("FullName").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

        Dim oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn
        For Each oColumn In Me.grdEmployees.DisplayLayout.Bands(0).Columns
            oColumn.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Next


        'Me.ApplyCurrentLook(grdEmployees, 0, 12)

        Me.ApplyCurrentLook(grdEmployees, 0, 2)
        Me.ApplyCurrentLook(grdEmployees, 1, 7)

        'SetCardViewOnBand(grdEmployees, 1, 7, False)


        grdEmployees.DisplayLayout.Bands(0).Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.CheckOnDisplay



    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If MsgBox("คุณกำลังบันทึก การทำงานของพนักงานทุกคนในรายชื่อ. ดำเนินการต่อหรือไม่?", vbYesNo) = vbNo Then
            Exit Sub
        End If

        Me.rtxtStatus.Text = ""
        

        SaveLeavRecord()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#Region "Grid Appear Setting"

    Private Sub SetCardViewOnBand(ByVal grid As UltraGrid, ByVal intBand As Integer, ByVal intLookStyle As Integer, ByVal bolTurnCardViewOffForOtherBands As Boolean)
        Dim band As UltraGridBand
        ' Dim currentBand As UltraGridBand = Me.grdSerachResult.DisplayLayout.Bands(intBand)



        For Each band In grid.DisplayLayout.Bands

            If Not band.Index = intBand Then
                If bolTurnCardViewOffForOtherBands = True Then
                    ' Turn off CardView on other bands and reset any customizations
                    ' we may have done to the CardSettings and Band Overrides.
                    band.CardView = False
                    band.CardSettings.Reset()
                    band.Override.Reset()
                End If
            Else
                ' Make the newly selected Band a CardView band and apply the current look.
                band.CardView = True
                Me.ApplyCurrentLook(grid, intBand, intLookStyle)
            End If
        Next

    End Sub



    Private Sub Set_Appearance_UseAlpha(ByVal App As Infragistics.Win.Appearance, _
                                      ByVal AlphaLevel As Short, _
                                      ByVal Use As Infragistics.Win.Alpha)
        With App
            .AlphaLevel = AlphaLevel
            .BackColorAlpha = Use
            .BorderAlpha = Use
            .ForegroundAlpha = Use
            .ImageAlpha = Use
            .ImageBackgroundAlpha = Use
        End With

    End Sub

    Private Sub SetGridAlpha(ByVal grid As UltraGrid)
        With grid.DisplayLayout.Override
            'background
            'Set_Appearance_UseAlpha GetGrid.Appearance, 192, ssAlphaUseAlphaLevel
            'headers
            Set_Appearance_UseAlpha(.HeaderAppearance, 192, Infragistics.Win.Alpha.UseAlphaLevel)
            'selectors
            Set_Appearance_UseAlpha(.RowSelectorAppearance, 192, Infragistics.Win.Alpha.UseAlphaLevel)
            'rows
            Set_Appearance_UseAlpha(.RowAppearance, 128, Infragistics.Win.Alpha.UseAlphaLevel)
            'cells
            Set_Appearance_UseAlpha(.CellAppearance, 129, Infragistics.Win.Alpha.UseAlphaLevel)
            .CellAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Opaque
        End With
    End Sub

    Private Sub SetGridBackGround(ByVal grid As UltraGrid, ByVal strBackGroundImagePath As String, ByVal ImageBackgroundStyle As Infragistics.Win.ImageBackgroundStyle)
        With grid.DisplayLayout.Appearance
            'grid background
            .ImageBackground = _
                Image.FromFile(strBackGroundImagePath)
            .ImageBackgroundStyle = ImageBackgroundStyle


        End With
    End Sub


#Region "ApplyCurrentLook"

    Private Sub ApplyCurrentLook(ByVal grid As UltraGrid, ByVal intBand As Integer, Optional ByVal intLookStyle As Integer = 10)

        ' For convenience.
        Dim currentBand As UltraGridBand = grid.DisplayLayout.Bands(intBand)

        ' Reset CardSettings and Overrides to their defaults.
        currentBand.CardSettings.Reset()
        currentBand.Override.Reset()

        ' Reset some properties to their defaults.
        currentBand.ResetHeaderVisible()
        grid.SupportThemes = True

        ' An alpha level of 128 looks better for the card labels.
        currentBand.Override.HeaderAppearance.AlphaLevel = 128

        ' Set properties appropriately depending on the selected look.
        Select Case (intLookStyle)

            Case 0 ' Default
                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 140

            Case 1 ' Traditional
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 0

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200


            Case 2 ' Fun With Gradients
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Etched

                currentBand.Override.CardCaptionAppearance.BackColor = Color.RoyalBlue
                currentBand.Override.CardCaptionAppearance.BackColor2 = Color.White
                currentBand.Override.CardCaptionAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Circular
                currentBand.Override.CardCaptionAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                currentBand.Override.HeaderAppearance.BackColor = Color.WhiteSmoke

                currentBand.Override.CellAppearance.BackColor = Color.White
                currentBand.Override.CellAppearance.BackColor2 = Color.RoyalBlue
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200


            Case 3 ' Fun With Gradients 2
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

                currentBand.Override.CardCaptionAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                currentBand.Override.CardCaptionAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                currentBand.Override.CardCaptionAppearance.ForeColor = Color.Lavender

                currentBand.Override.HeaderAppearance.BackColor = Color.LightSteelBlue
                currentBand.Override.HeaderAppearance.BackColor2 = Color.Lavender
                currentBand.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
                currentBand.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200


            Case 4 ' Fun With Gradients 3
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 10
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dashed

                currentBand.Override.CardCaptionAppearance.BackColor = Color.LightSeaGreen
                currentBand.Override.CardCaptionAppearance.BackColor2 = Color.Turquoise
                currentBand.Override.CardCaptionAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Circular
                currentBand.Override.CardCaptionAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                currentBand.Override.HeaderAppearance.BackColor = Color.PaleTurquoise
                currentBand.Override.HeaderAppearance.BackColor2 = Color.DarkTurquoise
                currentBand.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
                currentBand.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                currentBand.Override.CellAppearance.BackColor = Color.White
                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200


            Case 5 ' Corporate
                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.RaisedSoft
                currentBand.Override.CardSpacing = 10

                currentBand.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                currentBand.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                currentBand.Override.CellAppearance.BackColor = Color.WhiteSmoke

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 6 ' 3D
                currentBand.CardSettings.Style = CardStyle.StandardLabels

                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Raised
                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.Etched
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.InsetSoft
                currentBand.Override.CardSpacing = 10

                currentBand.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200

            Case 7 ' Conservative
                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted

                currentBand.Override.CardCaptionAppearance.BackColor = Color.DarkGoldenrod
                currentBand.Override.CardCaptionAppearance.FontData.SizeInPoints = 10

                currentBand.Override.CellAppearance.BackColor = Color.Ivory

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 8 ' High Contrast - green
                currentBand.Override.CellSpacing = 1
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dashed

                currentBand.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                currentBand.Override.HeaderAppearance.BackColor = Color.Black
                currentBand.Override.HeaderAppearance.ForeColor = Color.Lime

                currentBand.Override.CardCaptionAppearance.BackColor = Color.LimeGreen
                currentBand.Override.CardCaptionAppearance.ForeColor = Color.Black

                currentBand.Override.CellAppearance.BackColor = Color.Black
                currentBand.Override.CellAppearance.ForeColor = Color.Lime

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 9 ' Borders
                currentBand.Override.CellSpacing = 0
                currentBand.Override.CardSpacing = 0

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid

                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 10 ' Borders 2
                currentBand.CardSettings.Style = CardStyle.StandardLabels

                grid.SupportThemes = False

                currentBand.Override.CellSpacing = 0
                currentBand.Override.CardSpacing = 3

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid

                currentBand.HeaderVisible = True

                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200

            Case 11 ' Borders 3
                currentBand.CardSettings.Style = CardStyle.StandardLabels

                grid.SupportThemes = False

                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 0

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200

            Case 12 ' Borders 4
                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 2

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 13 ' Borders 5
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 2

                currentBand.CardSettings.ShowCaption = False

                currentBand.HeaderVisible = True

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.RaisedSoft
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid

                currentBand.Override.CellAppearance.BackColor2 = Color.Gainsboro
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200

            Case 14 ' Borders 6
                currentBand.CardSettings.Style = CardStyle.StandardLabels
                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 5

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

                currentBand.Override.RowAppearance.BackColor = Color.Transparent

                currentBand.Override.HeaderAppearance.BackColor = Color.Transparent

                currentBand.Override.CellAppearance.BorderColor = Color.Blue

                currentBand.Override.CardAreaAppearance.BackColor = Color.White
                currentBand.Override.CardAreaAppearance.BackColor2 = Color.SkyBlue
                currentBand.Override.CardAreaAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Rectangular

                currentBand.CardSettings.LabelWidth = 85
                currentBand.CardSettings.Width = 200

            Case 15 ' Borders 7
                currentBand.Override.CellSpacing = 0
                currentBand.Override.CardSpacing = 5

                grid.SupportThemes = False

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid

                currentBand.Override.HeaderAppearance.BackColor = Color.PaleTurquoise

                currentBand.HeaderVisible = True

                currentBand.Override.CardCaptionAppearance.BackColor = Color.DarkTurquoise
                currentBand.Override.CardCaptionAppearance.ForeColor = Color.DarkBlue
                currentBand.Override.CardCaptionAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

            Case 16 ' Techno
                currentBand.Override.CellSpacing = 1
                currentBand.Override.CardSpacing = 5

                grid.SupportThemes = False

                currentBand.Override.BorderStyleCardArea = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Dotted
                currentBand.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
                currentBand.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid

                currentBand.Override.HeaderAppearance.BackColor = Color.Silver
                currentBand.Override.HeaderAppearance.BackColor2 = Color.White
                currentBand.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump

                currentBand.Override.CardAreaAppearance.BackColor = Color.LightGray

                currentBand.Override.CardCaptionAppearance.BackColor = Color.DarkGray
                currentBand.Override.CardCaptionAppearance.BackColor2 = Color.White
                currentBand.Override.CardCaptionAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
                currentBand.Override.CardCaptionAppearance.ForeColor = Color.Black

                currentBand.Override.SelectedCardCaptionAppearance.ForeColor = Color.Black

                currentBand.Override.CellAppearance.BackColor = Color.White
                currentBand.Override.CellAppearance.BackColor2 = Color.DarkGray
                currentBand.Override.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
                currentBand.Override.CellAppearance.ForeColor = Color.Black

                currentBand.CardSettings.LabelWidth = 95
                currentBand.CardSettings.Width = 140

        End Select
    End Sub

#End Region

#End Region


    Private Sub txtDayAmount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDayAmount.ValueChanged
        If txtDayAmount.Value > 1 Then
            txtHours.Value = 0
        End If
    End Sub

    Private Sub cboWorkLogType_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboWorkLogType.SelectionChangeCommitted
        If CheckConflictWorkLogType() = True Then
            MsgBox("คุณไม่สามารถเลือกบันทึกการทำงาน ประเภทนี้กับพนักงานบางคนได้ กรุณาตรวจสอบรายละเอียดจากข้อความด้านล่าง", MsgBoxStyle.Critical)
            cboWorkLogType.SelectedIndex = -1
        End If
    End Sub
    Private Function CheckConflictWorkLogType() As Boolean

        'this sub check if user select some worklogtype that conflict to the existed one each emp has in that day

        If cboWorkLogType.SelectedIndex = -1 Then
            Return False
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim bolFoundConflict As Boolean = False


        Dim TempRow As Infragistics.Win.UltraWinGrid.UltraGridRow


        Dim IsOffWork As Boolean = False
        Dim isOverTime As Boolean = False

        rtxtStatus.Text = ""

        '  grdEmployees.Rows.ExpandAll(True)


        For Each TempRow In grdEmployees.Rows
            grdEmployees.ActiveRow = TempRow

            If TempRow.HasChild = False Then
                GoTo nextTempRow
            End If



            Dim ChildTempRow As Infragistics.Win.UltraWinGrid.UltraGridRow

            Dim TempchildBand As Infragistics.Win.UltraWinGrid.UltraGridChildBand
            'this case we only have 1 child band so no need to do loop for childBands
            TempchildBand = TempRow.ChildBands(0)

            For Each ChildTempRow In TempchildBand.Rows
                grdEmployees.ActiveRow = ChildTempRow
                Application.DoEvents()

                If Not ChildTempRow.Cells("IsOffWork").Value = cboWorkLogType.SelectedItem("IsOffWork") Then
                    'Add status show conflict
                    AddStatus(TempRow.Cells("FullName").Value & " ไม่สามารถใช้บันทึกการทำงาน """ & cboWorkLogType.SelectedItem("WorkLogName") & """ ได้ เนื่องจากขัดกันกับ บันทึกการทำงานที่มีอยู่ก่อนแล้ว """ & ChildTempRow.Cells("WorkLogName").Value & """", Color.Red)
                    'set flag
                    bolFoundConflict = True
                End If

            Next

nextTempRow:

        Next

        grdEmployees.Rows.CollapseAll(True)

        grdEmployees.ActiveRow = grdEmployees.Rows(0)

        Me.Cursor = Cursors.Arrow

        Return bolFoundConflict
    End Function

    'Private Function CheckExistedWorkLog(ByVal TempRow As Infragistics.Win.UltraWinGrid.UltraGridRow, ByVal AddingIsOffWork As Boolean) As Boolean
    '    ' retrieve reference to current ActiveRow

    '    Dim bolFoundConflict As Boolean = False




    '    If TempRow.HasChild = False Then
    '        Return bolFoundConflict
    '    End If


    '    Dim ChildTempRow As Infragistics.Win.UltraWinGrid.UltraGridRow

    '    Dim TempchildBand As Infragistics.Win.UltraWinGrid.UltraGridChildBand
    '    'this case we only have 1 child band so no need to do loop for childBands
    '    TempchildBand = TempRow.ChildBands(0)

    '    For Each ChildTempRow In TempchildBand.Rows
    '        grdEmployees.ActiveRow = ChildTempRow
    '        Application.DoEvents()

    '        If Not ChildTempRow.Cells("IsOffWork").Value = AddingIsOffWork Then
    '            'Add status show conflict
    '            AddStatus("***" & vbTab & TempRow.Cells("FullName").Value & " ไม่สามารถใช้บันทึกการทำงานนี้ได้ เนื่องจากขัดกันกับ บันทึกการทำงานที่มีอยู่ก่อนแล้ว --" & ChildTempRow.Cells("WorkLogName").Value, Color.Red)
    '            'set flag
    '            bolFoundConflict = True
    '        End If

    '    Next

    '    Return bolFoundConflict

    'End Function




    Private Sub cboWorkLogType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWorkLogType.SelectedIndexChanged
        If cboWorkLogType.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cboWorkLogType.SelectedItem("HourOnly") = True Then
            txtDayAmount.Value = 0
            txtDayAmount.ReadOnly = True
            txtHours.Select()
        Else
            txtDayAmount.ReadOnly = False
            txtDayAmount.Select()
        End If
    End Sub
End Class
