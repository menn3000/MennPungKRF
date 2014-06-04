Imports System.IO
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient

Public Class ctrEmpEducationHistory
    Private cls As New clsDataSQL
    Private eph As New Tblempeducationhistory

    Dim DS As New DataSet
    Dim CurrentEmpAutoID As Integer

    Friend Sub LoadAndDisplayData(ByVal intEmpAutoID As Integer)


        If intEmpAutoID = 0 Then

            grdEmpPosHistory.DataSource = Nothing
            ClearForm()
            Exit Sub

        End If


        CurrentEmpAutoID = intEmpAutoID
        LoadEmployeeEduData(intEmpAutoID)
        grdEmpPosHistory.Refresh()

    End Sub
    Private Sub ClearForm()

        txtDegreeName.Text = ""
        txtMajor.Text = ""
        txtNote.Text = ""
        txtSchoolName.Text = ""
        txtYearGrad.Value = txtYearGrad.MinValue

    End Sub
    Private Sub LoadEmployeeEduData(ByVal intEmpAutoID As Integer)



        Dim sql(2) As String
        Dim tbl(2) As String


        sql(0) = "Select h.* "
        sql(0) += " from  tblEmpEducationHistory h "
        sql(0) += " where  h.EmpID = " & intEmpAutoID.ToString
        sql(0) += " order by h.YearGrad "

      

        tbl(0) = "tblEmpEducationHistory"


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        Me.grdEmpPosHistory.DataSource = DS.Tables("tblEmpEducationHistory")

        If grdEmpPosHistory.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
        End If

      


    End Sub

    Private Sub GetEduHistoryInfoForEdit()
        ClearForm()

        txtDegreeName.Text = Me.grdEmpPosHistory.ActiveRow.Cells("DegreeName").Value
        txtMajor.Text = Me.grdEmpPosHistory.ActiveRow.Cells("major").Value
        txtNote.Text = Me.grdEmpPosHistory.ActiveRow.Cells("EduHisNote").Value
        txtSchoolName.Text = Me.grdEmpPosHistory.ActiveRow.Cells("SchoolName").Value
        txtYearGrad.Value = Me.grdEmpPosHistory.ActiveRow.Cells("YearGrad").Value


    End Sub
    Private Sub grdEmpPosHistory_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmpPosHistory.AfterRowActivate
        If rblUpdateMode.Checked = True Then
            GetEduHistoryInfoForEdit()
        End If
    End Sub

    Private Sub grdEmpPosHistory_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEmpPosHistory.InitializeLayout

        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("EmpID").Hidden = True


        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("DegreeName").Header.Caption = "คุณวุฒิ"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("Major").Header.Caption = "สาขา"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("YearGrad").Header.Caption = "ปีการศึกษา"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("SchoolName").Header.Caption = "สถานศึกษา"
        grdEmpPosHistory.DisplayLayout.Bands(0).Columns("EduHisNote").Header.Caption = "หมายเหตุ"

      
        grdEmpPosHistory.DisplayLayout.AutoFitColumns = True

    End Sub

    Private Sub grdEmpPosHistory_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdEmpPosHistory.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

    End Sub

    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdEmpPosHistory.ActiveRow = Nothing
            ClearForm()
            txtDegreeName.Select()
        Else

            If grdEmpPosHistory.Rows.Count > 0 Then
                grdEmpPosHistory.ActiveRow = grdEmpPosHistory.Rows(0)
            Else
                MsgBox("ยังไม่มีประวัติการศึกษาใดๆในระบบให้แก้ไข", vbQuestion)
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

            eph = New Tblempeducationhistory

            If rblAddNewMode.Checked Then
                eph.ID = 0
            Else
                eph.ID = Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value
            End If

            eph.EmpID = CurrentEmpAutoID
            eph.DegreeName = txtDegreeName.Text
            eph.Major = txtMajor.Text
            eph.YearGrad = txtYearGrad.Value
            eph.SchoolName = txtSchoolName.Text
            eph.EduHisNote = txtNote.Text

            AfterSaveID = eph.Save()
            If AfterSaveID <= 0 Then
                MsgBox("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองอีกครั้ง", vbCritical)
                Exit Sub
            End If

            LoadEmployeeEduData(CurrentEmpAutoID)


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

        Me.txtNote.Text = Trim(Replace(txtNote.Text, Chr(39), Chr(146)))

        If txtDegreeName.Text.Length < 1 Then
            MsgBox("กรุณาใส่คุณวุฒิ", vbCritical)
            txtDegreeName.Select()
            Return False
        ElseIf txtDegreeName.Text.Length > 512 Then
            MsgBox("คุณวุฒิ ยาวเกินไป", vbCritical)
            txtDegreeName.Select()
            Return False
        End If

        If txtYearGrad.Value > Today.Year Then
            MsgBox("ปีการศึกษาที่จบ ไม่สามารถเป็นปีในอนาคตได้", vbCritical)
            txtYearGrad.Select()
            Return False
        End If

        If txtMajor.Text.Length < 1 Then
            MsgBox("กรุณาใส่สาขา", vbCritical)
            txtMajor.Select()
            Return False
        ElseIf txtMajor.Text.Length > 512 Then
            MsgBox("ชื่อสาขา ยาวเกินไป", vbCritical)
            txtMajor.Select()
            Return False
        End If

        If txtSchoolName.Text.Length < 1 Then
            MsgBox("กรุณาใส่สาขา", vbCritical)
            txtSchoolName.Select()
            Return False
        ElseIf txtSchoolName.Text.Length > 512 Then
            MsgBox("ชื่อสาขา ยาวเกินไป", vbCritical)
            txtSchoolName.Select()
            Return False
        End If

        Return True
    End Function


    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Not grdEmpPosHistory.ActiveRow Is Nothing Then

            grdEmpPosHistory.ActiveRow.Selected = True
            If MsgBox("คุณกำลังลบประวัติการศึกษาบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่?", vbQuestion + vbYesNo) = vbNo Then
                Exit Sub
            End If
            If eph.Delete(Me.grdEmpPosHistory.ActiveRow.Cells("ID").Value) = True Then
                LoadEmployeeEduData(CurrentEmpAutoID)
            End If

        End If

    End Sub

    Private Sub ctrEmpEducationHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Today.Year < 2300 Then
            txtYearGrad.Value = Today.Year + 543
        Else
            txtYearGrad.Value = Today.Year
        End If

        Try
            LoadMainData()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadMainData()

        Dim sql(6) As String
        Dim tbl(6) As String
        Dim strSQL As String = ""

     

        '----------------AUTO COMPLETE SOURCES--------------------------------

        strSQL = "Select distinct SchoolName as data  from tblEmpEducationHistory  "
        sql(0) = strSQL
        tbl(0) = "SchoolName"


        sql(1) = "Select distinct DegreeName as data from tblEmpEducationHistory  "
        tbl(1) = "DegreeName"


        strSQL = "Select distinct Major as data  from tblEmpEducationHistory "
        sql(2) = strSQL
        tbl(2) = "Major"

      
        '----------------------------------------


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing


        SetAutoCompleteSource(txtSchoolName, DS.Tables("SchoolName"))
        SetAutoCompleteSource(txtDegreeName, DS.Tables("DegreeName"))
        SetAutoCompleteSource(txtMajor, DS.Tables("Major"))
       


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
End Class
