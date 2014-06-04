Imports System.Data.SqlClient

Public Class frmSalayLevel
    Private cls As New clsDataSQL

    Private Sub frmSalayLevel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
    Private Sub frmSalayLevel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMainData()
    End Sub

    Private Sub LoadMainData()

        Dim sql(2) As String
        Dim tbl(2) As String
        Dim strSQL As String = ""

        Dim DS As New DataSet

        sql(0) = "Select * "
        sql(0) += " from tblSalaryLevel "
        sql(0) += " order by SalaryLevel"

        tbl(0) = "tblSalaryLevel"



        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing


        grdPositions.DataSource = DS.Tables("tblSalaryLevel")

        If grdPositions.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdPositions.ActiveRow = grdPositions.Rows(0)
        End If

    End Sub

    Private Sub grdPositions_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPositions.AfterRowActivate

        If rblUpdateMode.Checked = True Then
            GetPositionInfoForEdit()
        End If

    End Sub

    Private Sub ClearForm()
        txtNumLevel.Value = 1
        txtSalary.Value = 0

    End Sub
    Private Sub GetPositionInfoForEdit()
        ClearForm()

        txtNumLevel.Value = grdPositions.ActiveRow.Cells("SalaryLevel").Value
        txtSalary.Value = grdPositions.ActiveRow.Cells("Salary").Value

        rblUpdateMode.Checked = True


    End Sub

    Private Sub grdPositions_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdPositions.BeforeCellUpdate
        e.Cancel = True
    End Sub

    Private Sub grdPositions_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPositions.InitializeLayout
        grdPositions.DisplayLayout.AutoFitColumns = True


        grdPositions.DisplayLayout.Bands(0).Columns("SalaryLevel").Header.Caption = "ระดับ"
        grdPositions.DisplayLayout.Bands(0).Columns("Salary").Header.Caption = "อัตราเงินเดือน"

        grdPositions.DisplayLayout.Bands(0).Columns("ID").Hidden = True

    End Sub




   

    Private Sub SaveData()
        If grdPositions.ActiveRow Is Nothing Then
            SaveNewPosition()
        Else
            UpdatePosition(Me.grdPositions.ActiveRow.Cells("ID").Value)
        End If
    End Sub


    Private Sub SaveNewPosition()
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedPosition(txtNumLevel.Value) = True Then
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

        Dim intNewPositionID As Int64 = 0
        Dim strSQL As String = ""



        Dim tr As DataRow
        Try
            cmd.CommandText = GetInsertPositionSQL()
            ' Execute the command.
            cmd.ExecuteNonQuery()
            'Get New ID just inserted
            cmd.CommandText = "Select @@Identity"
            intNewPositionID = Int64.Parse(cmd.ExecuteScalar())


            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น ข้อมูลนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        Finally
            If Not objConn.State = ConnectionState.Closed Then objConn.Close()
        End Try

        If intNewPositionID > 0 Then
            clsUtility.PositionRecordsLatestTime = Now
            MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", vbInformation)
            LoadMainData()
        End If


    End Sub

    Private Function GetInsertPositionSQL() As String
        Dim strSQL As String
        strSQL = "Insert into tblSalaryLevel (SalaryLevel, Salary "
        strSQL += ") values ("
        strSQL += txtNumLevel.Value.ToString & ", "
        strSQL += txtSalary.Value.ToString & " "
        strSQL += ")"

        Return strSQL
    End Function



    Private Function verifyInput() As Boolean

      


        If txtNumLevel.Value = 0 Then
            MsgBox("กรุณาใส่ระดับ", vbCritical)
            Return False
        End If

        If txtSalary.Value.ToString = 0 Then
            MsgBox("กรุณาใส่อัตราเงินเดือน", vbCritical)
            Return False
        End If

       

        Return True
    End Function

 

    Private Function FindControl(ByVal ControlName As String, _
ByVal CurrentControl As Control _
) As Control
        Dim ctr As Control
        For Each ctr In CurrentControl.Controls
            If ctr.Name = ControlName Then
                Return ctr
            Else
                ctr = FindControl(ControlName, ctr)
                If Not ctr Is Nothing Then
                    Return ctr
                End If
            End If
        Next ctr
    End Function

    Private Function checkISExistedPosition(ByVal dblLevel As Double, Optional ByVal intUpdatingPositionID As Integer = 0) As Boolean


        Dim strSQL As String = "Select * from tblSalarylevel "
        strSQL += "  where SalaryLevel = '" & dblLevel.ToString & "'"

        If intUpdatingPositionID > 0 Then
            strSQL += " and ID <> " & intUpdatingPositionID.ToString
        End If

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then
            Dim msg As String = "ระดับซ้ำ กับระดับที่มีอยู่แล้ว กรุณาตรวจสอบ"
            dr.Close()
            MsgBox(msg, MsgBoxStyle.Critical)
            Return True
        Else
            dr.Close()
        End If
        Return False
    End Function

    Private Sub UpdatePosition(ByVal intPositionID As Integer)
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedPosition(txtNumLevel.Value, intPositionID) = True Then
            Exit Sub
        End If

        Dim bolReturn As Boolean = False

        Dim objConn As New SqlConnection(clsUtility.LiveCNS)
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        ' Make the transaction.
        Dim trans As SqlTransaction = _
            objConn.BeginTransaction(IsolationLevel.ReadCommitted)


        Dim cmd As New SqlCommand
        cmd.Connection = objConn
        cmd.Transaction = trans
        cmd.CommandTimeout = 0


        Dim strSQL As String = ""

        Dim tr As DataRow
        Try
            cmd.CommandText = GetUpdatePositionSQL(intPositionID)
            ' Execute the command.
            cmd.ExecuteNonQuery()

         

            trans.Commit()
            bolReturn = True
        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น ข้อมูลนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        Finally
            If Not objConn.State = ConnectionState.Closed Then objConn.Close()
        End Try


        If bolReturn = True Then
            clsUtility.PositionRecordsLatestTime = Now
            MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", vbInformation)
            LoadMainData()
        End If

    End Sub
    Private Function GetUpdatePositionSQL(ByVal intPositionID As Integer) As String
        Dim strSQL As String
        strSQL = "Update tblSalaryLevel Set  "
        strSQL += " SalaryLevel = '" & txtNumLevel.Value.ToString & "'"
        strSQL += " ,Salary = '" & txtSalary.Value.ToString & "'"
        strSQL += " Where ID = " & intPositionID.ToString

        Return strSQL
    End Function
    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdPositions.ActiveRow = Nothing
            ClearForm()
            txtNumLevel.Select()
        Else

            If grdPositions.Rows.Count > 0 Then
                grdPositions.ActiveRow = grdPositions.Rows(0)
            Else
                MsgBox("ยังไม่มีข้อมูลใดๆในระบบ กรุณาเพิ่มตำแหน่งในระบบก่อน", vbQuestion)
            End If

        End If
    End Sub


    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Not grdPositions.ActiveRow Is Nothing Then
            grdPositions.ActiveRow.Selected = True
            If Not MsgBox("คุณกำลังข้อมูลบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่?", vbQuestion + vbYesNo) = vbYes Then
                Exit Sub
            End If

            Dim strSQL As String = "Delete from tblSalaryLevel where ID = " & Me.grdPositions.ActiveRow.Cells("ID").Value
            cls.ExcuteData(strSQL)

            LoadMainData()
        End If
    End Sub

    Private Sub cmdSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveData()
    End Sub

    Private Sub cmdCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.ClearForm()
        Me.Hide()
    End Sub
    Private Sub txtNumLevel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumLevel.Leave
        Me.txtNumLevel.Value = RoundMe(txtNumLevel.Value, 0.5)
    End Sub
    Private Function RoundMe(ByVal num, ByVal roundto)
        num = num + 0.0000001
        roundto = 1 / roundto
        RoundMe = CLng(Num * Roundto) / Roundto
    End Function
End Class