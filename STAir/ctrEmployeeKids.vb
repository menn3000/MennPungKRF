Imports System.IO
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient

Public Class ctrEmployeeKids

    Private cls As New clsDataSQL
    Private eph As New Tblemployee_kids

    Dim DS As New DataSet
    Dim CurrentEmpAutoID As Integer

    Friend Sub LoadAndDisplayData(ByVal intEmpAutoID As Integer)


        If intEmpAutoID = 0 Then

            grdEmpPosHistory.DataSource = Nothing
            ClearForm()
            Exit Sub

        End If


        CurrentEmpAutoID = intEmpAutoID
        LoadEmployeeData(intEmpAutoID)
        grdEmpPosHistory.Refresh()

    End Sub
    Private Sub ClearForm()

        txtKidName.Text = ""
        dtKidDOB.Value = Today
        chkInschool.Checked = False
        chkMale.Checked = True

    End Sub

    Private Sub LoadEmployeeData(ByVal intEmpAutoID As Integer)



        Dim sql(2) As String
        Dim tbl(2) As String


        sql(0) = "Select h.* "
        sql(0) += " from  tblEmployee_Kids h "
        sql(0) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(0) += " order by h.DOB "



        tbl(0) = "tblEmployee_Kids"


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        Me.grdEmpPosHistory.DataSource = DS.Tables("tblEmployee_Kids")

        If grdEmpPosHistory.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
        End If


    End Sub

    Private Sub GetEduHistoryInfoForEdit()
        ClearForm()

        txtKidName.Text = Me.grdEmpPosHistory.ActiveRow.Cells("FullName").Value
        dtKidDOB.Value = Me.grdEmpPosHistory.ActiveRow.Cells("DOB").Value
        chkInschool.Checked = Me.grdEmpPosHistory.ActiveRow.Cells("InSchool").Value
        If Me.grdEmpPosHistory.ActiveRow.Cells("Sex").Value = "ชาย" Then
            chkMale.Checked = True
            chkFemale.Checked = False
        Else
            chkMale.Checked = False
            chkFemale.Checked = True
        End If


    End Sub


    Private Sub chkSex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMale.CheckedChanged
        If chkMale.Checked = True Then
            chkFemale.Checked = False
        Else
            chkFemale.Checked = True
        End If
    End Sub


    Private Sub chkFemale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFemale.CheckedChanged
        If chkFemale.Checked = True Then
            chkMale.Checked = False
        Else
            chkMale.Checked = True
        End If
    End Sub

    Private Sub grdEmpPosHistory_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmpPosHistory.AfterRowActivate
        If rblUpdateMode.Checked = True Then
            GetEduHistoryInfoForEdit()
        End If
    End Sub

    Private Sub grdEmpPosHistory_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEmpPosHistory.InitializeLayout

        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("EmpID").Hidden = True


        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("FullName").Header.Caption = "ชื่อบุตร"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("Sex").Header.Caption = "เพศ"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DOB").Header.Caption = "วันเดือนปีเกิด"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("InSchool").Header.Caption = "เรียน"



        grdEmpPosHistory.DisplayLayout.AutoFitColumns = True

    End Sub

    Private Sub grdEmpPosHistory_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdEmpPosHistory.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

    End Sub

    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdEmpPosHistory.ActiveRow = Nothing
            ClearForm()
            txtKidName.Select()
        Else

            If grdEmpPosHistory.Rows.Count > 0 Then
                grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
            Else
                MsgBox("ยังไม่มีประวัติบุตร ในระบบให้แก้ไข", vbQuestion)
                rblAddNewMode.Checked = True
            End If

        End If
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        SaveEmpHistoryForExistedEmployee()

    End Sub
    Private Sub SaveEmpHistoryForExistedEmployee()

        Dim AfterSaveID As Integer = 0
        Try

            eph = New Tblemployee_kids

            If rblAddNewMode.Checked Then
                eph.ID = 0
            Else
                eph.ID = Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value
            End If

            eph.EmpID = CurrentEmpAutoID
            eph.FullName = txtKidName.Text
            eph.Sex = chkMale.Text
            eph.DOB = dtKidDOB.Value
            eph.InSchool = chkInschool.Checked

            AfterSaveID = eph.Save()
            If AfterSaveID <= 0 Then
                MsgBox("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองอีกครั้ง", vbCritical)
                Exit Sub
            End If

            LoadEmployeeData(CurrentEmpAutoID)


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
        SaveEmpHistoryForExistedEmployee()
    End Sub

    Private Function verifyInput() As Boolean



        If txtKidName.Text.Length < 1 Then
            MsgBox("กรุณาใส่ชื่อบตร", vbCritical)
            txtKidName.Select()
            Return False
        ElseIf txtKidName.Text.Length > 100 Then
            MsgBox("คุณวุฒิ ยาวเกินไป", vbCritical)
            txtKidName.Select()
            Return False
        End If

        If chkFemale.Checked = False And chkMale.Checked = False Then
            MsgBox("กรุณาใส่ข้อมูล เพศของบุตร", vbCritical)
            chkMale.Select()
            Return False
        End If

        If dtKidDOB.Value > Today Then
            MsgBox("วันเกิด ไม่สามารถเป็นปีในอนาคตได้", vbCritical)
            dtKidDOB.Select()
            Return False
        End If


        Return True
    End Function

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Not grdEmpPosHistory.ActiveRow Is Nothing Then

            grdEmpPosHistory.ActiveRow.Selected = True
            If MsgBox("คุณกำลังลบรายการบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่?", vbQuestion + vbYesNo) = vbNo Then
                Exit Sub
            End If
            If eph.Delete(Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value) = True Then
                LoadEmployeeData(CurrentEmpAutoID)
            End If

        End If

    End Sub

End Class
