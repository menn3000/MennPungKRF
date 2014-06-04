Imports System.IO
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient

Public Class ctrEmpLevelHistory

    Private cls As New clsDataSQL
    Private eph As New Tblemplevelhistory

    Dim DS As New DataSet
    Dim CurrentEmpAutoID As Integer

    Private dblCurrentLevel As Double

    Public Event NewLevelHistoryCreated(ByVal intEmpID As Integer)

    Public Property CurrenLevel() As Double
        Get
            Return dblCurrentLevel
        End Get
        Set(ByVal value As Double)
            dblCurrentLevel = value
        End Set
    End Property

    Private decCurrentSalary As Decimal

    Public Property CurrentSalary() As Decimal
        Get
            Return decCurrentSalary
        End Get
        Set(ByVal value As Decimal)
            decCurrentSalary = value
        End Set
    End Property
    Friend Sub LoadAndDisplayData(ByVal intEmpAutoID As Integer)

       
        If intEmpAutoID = 0 Then
            CurrenLevel = 1 ' Set as default to 1
            grdEmpPosHistory.DataSource = Nothing
            ClearForm()
            Exit Sub

        End If


        CurrentEmpAutoID = intEmpAutoID
        LoadEmployeeLevelData(intEmpAutoID)
        grdEmpPosHistory.Refresh()

    End Sub
    Private Sub LoadEmployeeLevelData(ByVal intEmpAutoID As Integer)



        Dim sql(3) As String
        Dim tbl(3) As String


        sql(0) = "Select  h.ID, h.LevelNumber, h.Salary, h.EmpID, h.IsCurrent, h.DateAssigned, h.AssignProcessedBy , h.AssignNote, h.DateResign, h.ResignProcessedBy, h.ResignNote "
        sql(0) += " from  tblEmpLevelHistory h "
        sql(0) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(0) += " order by h.IsCurrent, h.DateAssigned"

        sql(1) = "Select   h.* "
        sql(1) += " from  tblEmpLevelHistory h"
        sql(1) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(1) += " and h.IsCurrent = 1"
        sql(1) += " order by h.IsCurrent, h.DateAssigned"

        sql(2) = "Select * "
        sql(2) += " from tblSalaryLevel "
        sql(2) += " order by SalaryLevel"



        tbl(0) = "tblEmpLevelHistory"
        tbl(1) = "tblCurrentLevel"
        tbl(2) = "tblSalaryLevel"

        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        Me.grdEmpPosHistory.DataSource = DS.Tables("tblEmpLevelHistory")

        If grdEmpPosHistory.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
        End If

        If DS.Tables("tblCurrentLevel").Rows.Count = 1 Then
            Me.CurrenLevel = DS.Tables("tblCurrentLevel").Rows(0)("LevelNumber")
            Me.CurrentSalary = DS.Tables("tblCurrentLevel").Rows(0)("Salary")

        Else
            Me.CurrenLevel = 1 ' set Default to 1
        End If


    End Sub


    Private Sub ClearForm()

        txtNumLevel.Value = 1
        txtSalary.Value = 0

        Me.cboDateAssignedPosition.Value = Today
        cboDateResign.Value = Today
        Me.txtNote.Text = ""
        chkIsCurrent.Checked = False
        chkResignDate.Checked = False

    End Sub
   
    Private Sub GetPositionHistoryInfoForEdit(ByVal intID As Integer)
        ClearForm()

        Dim strSQL As String = ""
        strSQL = "Select * from tblEmpLevelHistory where ID =" & intID.ToString

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then

            txtNumLevel.Value = dr("LevelNumber")
            txtSalary.Value = dr("Salary")

            cboDateAssignedPosition.Value = dr("DateAssigned")
            If Not IsDBNull(dr("DateResign")) Then
                chkResignDate.Checked = True
                cboDateResign.Value = dr("DateResign")
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




        e.Layout.Bands(0).Columns("DateAssigned").Format = "dd MMM yyyy"
        e.Layout.Bands(0).Columns("DateResign").Format = "dd MMM yyyy"

        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("EmpID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ResignNote").Hidden = True


        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("LevelNumber").Header.Caption = "ระดับ"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("IsCurrent").Header.Caption = "ปัจจุบัน"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DateAssigned").Header.Caption = "วันที่เข้าระดับ"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("AssignNote").Header.Caption = "หมายเหตู"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("AssignProcessedBy").Header.Caption = "บันทึกโดย"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DateResign").Header.Caption = "วันที่ออกจากระดับ"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ResignProcessedBy").Header.Caption = "บันทึกโดย"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("Salary").Header.Caption = "อัตราเงินเดือน"



        ' e.Layout.Bands(0).Columns("LevelNumber").Width = 50
        ' grdEmpPosHistory.Refresh()
        grdEmpPosHistory.DisplayLayout.AutoFitColumns = False

    End Sub

    Private Sub grdEmpPosHistory_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdEmpPosHistory.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

    End Sub



    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdEmpPosHistory.ActiveRow = Nothing
            ClearForm()
            txtNumLevel.Select()
        Else

            If grdEmpPosHistory.Rows.Count > 0 Then
                grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
            Else
                MsgBox("ยังไม่มีประวัติระดับใดๆในระบบให้แก้ไข", vbQuestion)
                rblAddNewMode.Checked = True
            End If

        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        SaveEmpLevelHistoryForExistedEmployee()

    End Sub
    Private Sub SaveEmpLevelHistoryForExistedEmployee()

        Dim AfterSaveID As Integer = 0
        Try

            eph = New Tblemplevelhistory

            If rblAddNewMode.Checked Then
                eph.ID = 0
            Else
                eph.ID = Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value
            End If

            eph.EmpID = CurrentEmpAutoID
            eph.Salary = txtSalary.Value
            eph.LevelNumber = txtNumLevel.Value
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

            LoadEmployeeLevelData(CurrentEmpAutoID)


            RaiseEvent NewLevelHistoryCreated(CurrentEmpAutoID)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally

        End Try
    End Sub

    Friend Sub ProcessSavePositionForNewEmployee(ByVal intEmpAutoID As Integer)
        If verifyInput() = False Then
            Exit Sub
        End If
        CurrentEmpAutoID = intEmpAutoID
        SaveEmpLevelHistoryForExistedEmployee()
    End Sub

    Private Function verifyInput() As Boolean

        Me.txtNote.Text = Trim(Replace(txtNote.Text, Chr(39), Chr(146)))

        If txtNumLevel.Value < 1 Then
            MsgBox("กรุณาใส่ระดับเป็นตังเลข เริ่มตั้งแต่ 1", vbCritical)
            txtNumLevel.Select()
            Return False
        End If

        If txtSalary.Value <= 0 Then
            MsgBox("กรุณาใส่ อัตราเงินเดือน และอัตราเงินเดือนไม่สามารถเป็น 0 บาทได้", vbCritical)
            txtSalary.Select()
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
        Else
            cboDateResign.Visible = False
            chkIsCurrent.Visible = True
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Not grdEmpPosHistory.ActiveRow Is Nothing Then

            grdEmpPosHistory.ActiveRow.Selected = True
            If MsgBox("คุณกำลังลบประวัติการทำงานบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่?", vbQuestion + vbYesNo) = vbNo Then
                Exit Sub
            End If
            If eph.Delete(Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value) = True Then
                LoadEmployeeLevelData(CurrentEmpAutoID)
            End If

        End If

    End Sub




    Private Sub txtNumLevel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumLevel.Leave
        Me.txtNumLevel.Value = RoundMe(txtNumLevel.Value, 0.5)
        txtSalary.Value = GetSalaryRate(Me.txtNumLevel.Value)
    End Sub
    Private Function RoundMe(ByVal num, ByVal roundto)
        num = num + 0.0000001
        roundto = 1 / roundto
        RoundMe = CLng(Num * Roundto) / Roundto
    End Function

   
   
    Private Function GetSalaryRate(ByVal dblSalaryLevel As Double)
        Dim dtb As DataTable
        dtb = DS.Tables("tblSalaryLevel")
        Dim tr As DataRow
        For Each tr In dtb.Rows
            If tr("SalaryLevel") = dblSalaryLevel Then
                Return tr("Salary")
            End If
        Next

        Return 0

    End Function
End Class
