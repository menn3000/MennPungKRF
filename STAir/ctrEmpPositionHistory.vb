Imports System.IO
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient



Public Class ctrEmpPositionHistory

    Private cls As New clsDataSQL
    Private eph As New Tblemppositionhistory

    Dim DS As New DataSet
    Private intPositionIDForFirstInsertEmployee As Integer = 0 ' this will never change once we query it first time
    Dim CurrentEmpAutoID As Integer


    Public Event NewPositionHistoryCreated(ByVal intEmpID As Integer)
    Public Event RequestAddNewPosition()

    'Public Event PendingFortblEmployees_ID_Created(ByVal eph As Tblemppositionhistory)


    Private intCurrentPositionID As Integer

    Public Property CurrenPositionID() As Integer
        Get
            Return intCurrentPositionID
        End Get
        Set(ByVal value As Integer)
            intCurrentPositionID = value
        End Set
    End Property




    Private Sub GetPositionIDForNewEmp()
        If intPositionIDForFirstInsertEmployee = 0 Then
            Dim strSQL As String = "Select top 1 ID from tblPositions where L2CategoryID = 0"
            Dim dr As SqlDataReader
            dr = cls.DB_GetDataReader(strSQL)
            If dr.Read Then
                ' CurrenPositionID = 1 ' Set as default to Position แรกเข้าทำงาน ID = 1
                CurrenPositionID = dr("ID")
            End If
            dr.Close()
        End If

        If CurrenPositionID = 0 Then
            Dim strSQL As String = ""
            strSQL = "Insert into tblPositions (PositionName, PositionAbv,[DefaultAirModuleLevel],DefaultAdminModuleLevel, DefaultInvModuleLevel,DefaultFieldWorkModuleLevel, L2CategoryID"
            strSQL += ") values ("
            strSQL += "'แรกเข้า', "
            strSQL += "'แรกเข้า', "
            strSQL += "0, "
            strSQL += "0, "
            strSQL += "0, "
            strSQL += "0, "
            strSQL += "0 "
            strSQL += ")"
            CurrenPositionID = cls.InsertData(strSQL)
        End If
    End Sub


    Friend Sub LoadAndDisplayData(ByVal intEmpAutoID As Integer)

        LoadPositions()

        If intEmpAutoID = 0 Then
            GetPositionIDForNewEmp()
            grdEmpPosHistory.DataSource = Nothing
            ClearForm()
            Exit Sub

        End If


        CurrentEmpAutoID = intEmpAutoID
        LoadEmployeePositionData(intEmpAutoID)
        grdEmpPosHistory.Refresh()

    End Sub


    Private Sub LoadEmployeePositionData(ByVal intEmpAutoID As Integer)



        Dim sql(2) As String
        Dim tbl(2) As String


        sql(0) = "Select  p.PositionAbv , h.* "
        sql(0) += " from  tblEmpPositionHistory h, tblPositions p"
        sql(0) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(0) += " and h.PositionId = p.ID"
        sql(0) += " order by h.IsCurrent, h.DateAssigned"

        sql(1) = "Select  p.PositionAbv , h.* "
        sql(1) += " from  tblEmpPositionHistory h, tblPositions p"
        sql(1) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(1) += " and h.PositionId = p.ID"
        sql(1) += " and h.IsCurrent = 1"
        sql(1) += " order by h.IsCurrent, h.DateAssigned"

        tbl(0) = "tblEmpPositionHistory"
        tbl(1) = "tblCurrentPosition"

        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        Me.grdEmpPosHistory.DataSource = DS.Tables("tblEmpPositionHistory")

        If grdEmpPosHistory.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
        End If

        If DS.Tables("tblCurrentPosition").Rows.Count = 1 Then
            Me.CurrenPositionID = DS.Tables("tblCurrentPosition").Rows(0)("PositionID")

        Else
            Me.CurrenPositionID = 1 ' set Default to แรกเข้าทำงาน ID =1
        End If


    End Sub


    Private Sub ClearForm()
        Me.cboPosition.SelectedIndex = -1
        Me.cboDateAssignedPosition.Value = Today
        cboDateResign.Value = Today
        Me.txtNote.Text = ""
        chkIsCurrent.Checked = False
        chkResignDate.Checked = False
        cboAutoNote.Text = ""

    End Sub

    Private Sub GetPositionHistoryInfoForEdit(ByVal intID As Integer)
        ClearForm()

        Dim strSQL As String = ""
        strSQL = "Select * from tblEmpPositionHistory where ID =" & intID.ToString

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then
            cboPosition.SelectedValue = dr("PositionID")
            cboDateAssignedPosition.Value = dr("DateAssigned")
            If Not IsDBNull(dr("DateResign")) Then
                chkResignDate.Checked = True
                cboDateResign.Value = dr("DateResign")
                'Else
                '    chkResignDate.Checked = False
            End If
            txtNote.Text = dr("AssignNote")
            rblUpdateMode.Checked = True
            chkIsCurrent.Checked = dr("IsCurrent")
        End If

        dr.Close()

    End Sub

    Private Sub grdEmpPosHistory_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmpPosHistory.AfterRowActivate
        If rblUpdateMode.Checked = True Then
            GetPositionHistoryInfoForEdit(Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value)
        End If
    End Sub


    Private Sub grdEmpPosHistory_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEmpPosHistory.InitializeLayout
        grdEmpPosHistory.DisplayLayout.AutoFitColumns = True

        e.Layout.Bands(0).Columns("DateAssigned").Format = "dd MMM yyyy"
        e.Layout.Bands(0).Columns("DateResign").Format = "dd MMM yyyy"

        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("EmpID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("PositionID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ResignNote").Hidden = True


        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("PositionAbv").Header.Caption = "ตำแหน่ง"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("IsCurrent").Header.Caption = "ปัจจุบัน"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DateAssigned").Header.Caption = "วันที่เข้าตำแหน่ง"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("AssignNote").Header.Caption = "หมายเหตู"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("AssignProcessedBy").Header.Caption = "บันทึกโดย"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DateResign").Header.Caption = "วันที่ออกจากตำแหน่ง"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ResignProcessedBy").Header.Caption = "บันทึกโดย"





        e.Layout.Bands(0).Columns("PositionID").Width = 150



    End Sub

    Private Sub grdEmpPosHistory_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdEmpPosHistory.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit



    End Sub


    Friend Sub LoadPositions()
        Dim strSQL As String


        strSQL = "Select * "
        strSQL += " from tblPositions "
        strSQL += " where (L2CategoryID = " & clsUtility.UserLevel2Category.ToString
        strSQL += " Or DefaultAdminModuleLevel = " & clsPermission.enuPerMission.ExecutiveViewer & ")"
        strSQL += " order by PositionName"


        Dim ds As New DataSet

        ds = cls.DB_GetDataSet(strSQL, "tblPositions")

        cboPosition.DisplayMember = "PositionAbv"
        cboPosition.ValueMember = "ID"
        cboPosition.DataSource = ds.Tables("tblPositions")

        cboPosition.SelectedIndex = -1





    End Sub

    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdEmpPosHistory.ActiveRow = Nothing
            ClearForm()
            cboPosition.Select()
        Else

            If grdEmpPosHistory.Rows.Count > 0 Then
                grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
            Else
                MsgBox("ยังไม่มีประวัติตำแหน่งใดๆในระบบให้แก้ไข", vbQuestion)
                rblAddNewMode.Checked = True
            End If

        End If
    End Sub


    Private Sub ctrEmpPositionHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If verifyInput() = False Then
            Exit Sub
        End If

        SaveEmpPositionHistoryForExistedEmployee()

    End Sub
    Friend Sub ProcessSavePositionForNewEmployee(ByVal intEmpAutoID As Integer)
        If verifyInput() = False Then
            Exit Sub
        End If
        CurrentEmpAutoID = intEmpAutoID
        SaveEmpPositionHistoryForExistedEmployee()
    End Sub
    'Private Sub SaveEmpPositionHistoryForPendingNewEmployee()


    '    Try

    '        eph = New Tblemppositionhistory


    '        eph.ID = 0
    '        eph.EmpID = 0 ' set to 0 for now that we do not have ID of tblEmplyees yet

    '        eph.PositionID = cboPosition.SelectedValue
    '        eph.IsCurrent = chkIsCurrent.Checked
    '        eph.DateAssigned = cls.CtypeDateToEng(cboDateAssignedPosition.Value, 99)
    '        eph.AssignNote = txtNote.Text
    '        eph.AssignProcessedBy = clsUtility.GetUserFullName

    '        If chkResignDate.Checked = True Then
    '            eph.DateResign = cboDateResign.Value
    '            eph.ResignNote = Nothing
    '            eph.ResignProcessedBy = clsUtility.GetUserFullName
    '        Else
    '            eph.DateResign = Nothing
    '            eph.ResignNote = Nothing
    '            eph.ResignProcessedBy = Nothing
    '        End If



    '        RaiseEvent PendingFortblEmployees_ID_Created(eph)

    '    Catch ex As Exception
    '        MsgBox(ex, vbCritical)
    '    Finally

    '    End Try
    'End Sub
    Private Sub SaveEmpPositionHistoryForExistedEmployee()

        Dim AfterSaveID As Integer = 0
        Try

            eph = New Tblemppositionhistory

            If rblAddNewMode.Checked Then
                eph.ID = 0
            Else
                eph.ID = Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value
            End If

            eph.EmpID = CurrentEmpAutoID
            eph.PositionID = cboPosition.SelectedValue
            eph.IsCurrent = chkIsCurrent.Checked
            eph.DateAssigned = cls.CtypeDateToEng(cboDateAssignedPosition.Value, 99)
            eph.AssignNote = txtNote.Text
            eph.AssignProcessedBy = clsUtility.GetUserFullName

            If chkResignDate.Checked = True Then
                eph.DateResign = cboDateResign.Value
                eph.ResignNote = Nothing
                eph.ResignProcessedBy = clsUtility.GetUserFullName
            Else
                eph.DateResign = Nothing
                eph.ResignNote = Nothing
                eph.ResignProcessedBy = Nothing
            End If

            AfterSaveID = eph.Save()
            If AfterSaveID <= 0 Then
                MsgBox("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองอีกครั้ง", vbCritical)
                Exit Sub
            End If

            LoadEmployeePositionData(CurrentEmpAutoID)


            RaiseEvent NewPositionHistoryCreated(CurrentEmpAutoID)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally

        End Try
    End Sub


    Private Function verifyInput() As Boolean

        Me.txtNote.Text = Trim(Replace(txtNote.Text, Chr(39), Chr(146)))

        If cboPosition.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือกตำแหน่ง", vbCritical)
            cboPosition.Select()
            Return False
        End If


        If cboDateAssignedPosition.Value > Today Then
            MsgBox("วันเที่เข้าสู่ตำแหน่ง ไม่สามารถเป็นวันที่ในอนาคตได้", vbCritical)
            cboDateAssignedPosition.Select()
            Return False
        End If

        If chkResignDate.Checked = True Then
            If cboDateAssignedPosition.Value > cboDateResign.Value Then
                MsgBox("วันเที่เข้าสู่ตำแหน่ง และวันที่ออกจากตำแหน่งไม่สัมพันธ์กัน", vbCritical)
                cboDateAssignedPosition.Select()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub chkResignDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResignDate.CheckedChanged
        If chkResignDate.Checked Then
            chkIsCurrent.Checked = False
            chkIsCurrent.Visible = False
            cboDateResign.Visible = True
            cboAutoNote.Visible = True
        Else
            cboDateResign.Visible = False
            chkIsCurrent.Visible = True
            cboAutoNote.Visible = False
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Not grdEmpPosHistory.ActiveRow Is Nothing Then

            grdEmpPosHistory.ActiveRow.Selected = True
            If MsgBox("คุณกำลังลบประวัติการทำงานบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่?", vbQuestion + vbYesNo) = vbNo Then
                Exit Sub
            End If
            If eph.Delete(Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value) = True Then
                LoadEmployeePositionData(CurrentEmpAutoID)
            End If

        End If

    End Sub




    Private Sub cmdAddNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewEmployee.Click
        RaiseEvent RequestAddNewPosition()
    End Sub


    Private Sub cboAutoNote_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAutoNote.TextChanged
        txtNote.Text = cboAutoNote.Text
    End Sub
End Class
