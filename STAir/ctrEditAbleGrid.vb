Imports System.Data.SqlClient
Imports STAir.LUNA

Public Class ctrEditAbleGrid
    Dim ArrID As New ArrayList
    Dim strTable As String
    Private CurrentEmpAutoID As Integer

    Private cls As New clsDataSQL



    Private Function getSQL(ByVal intEmpAutoID As Integer) As String
        Dim strSQL As String = ""
        Select Case strTable
            Case "tblEmpPositionHistory".ToLower
                strSQL = "Select *  "
                strSQL += " from  tblEmpPositionHistory h"
                strSQL += " where  h.EmpID = " & intEmpAutoID.ToString
                strSQL += " order by h.IsCurrent, h.DateAssigned"
        End Select

        Return strSQL
    End Function
    Private Sub GetData(ByVal strEmpAutoID As Integer)
        Dim str As String = getSQL(strEmpAutoID)
        Ds = cls.DB_GetDataSet(str, strTable, False)
        With dgvData
            .DataSource = Ds.Tables(strTable)
            .Focus()
        End With
        cmdSave.Enabled = False
        ArrID.Clear()
        Dim i As Integer
        For i = 0 To dgvData.Rows.Count - 2
            ArrID.Add(dgvData.Rows(i).Cells("ID").Value.ToString())
        Next i
    End Sub


    Private Sub GridColumn()
        If dgvData.ColumnCount > 0 Then
            Exit Sub
        End If

        With dgvData
            Select Case strTable
                Case "tblEmpPositionHistory".ToLower
                    lblCaption.Text = "ประวัติตำแหน้งงาน"
                    .Columns.Add(NewColumn("text", "ID", "ID", "ID", 50, 4, False))
                    .Columns.Add(NewColumn("text", "EmpID", "EmpID", "EmpID", 50, 4, False))
                    .Columns.Add(NewColumn("dropdown", "PositionID", "ตำแหน่ง", "PositionID", 150))
                    .Columns.Add(NewColumn("check", "IsCurrent", "ปัจจุบัน", "IsCurrent", 50))
                    .Columns.Add(NewColumn("text", "DateAssigned", "วันที่เข้าตำแหน่ง", "DateAssigned", 100, 50))
                    .Columns.Add(NewColumn("text", "AssignNote", "หมายเหตุการเข้าตำแหน่ง", "AssignNote", 200, 250))
                    .Columns.Add(NewColumn("text", "AssignProcessedBy", "AssignProcessedBy", "AssignProcessedBy", 50, 50, False))

                    .Columns.Add(NewColumn("text", "DateResign", "วันที่ออกจากตำแหน่ง", "DateResign", 100, 50))
                    .Columns.Add(NewColumn("text", "ResignNote", "หมายเหตุการออกจากตำแหน่ง", "ResignNote", 200, 200))
                    .Columns.Add(NewColumn("text", "ResignProcessedBy", "ResignProcessedBy", "ResignProcessedBy", 50, 50, False))

            End Select
            .Columns.Add(NewColumn("check", "colcancel", "ลบ", "bcancel", 50))
            .Columns.Add(NewColumn("check", "NewRow", "ใหม่", "NewRow", 50, 4, True))
        End With
    End Sub

    Private Function NewColumn(ByVal Type As String, ByVal Name As String, ByVal Header As String, ByVal DataName As String, Optional ByVal Width As Integer = 100, Optional ByVal MaxInput As Integer = 100, Optional ByVal Visible As Boolean = True, Optional ByVal colReadOnly As Boolean = False) As DataGridViewColumn
        Dim colText As DataGridViewTextBoxColumn
        Dim col As New DataGridViewColumn
        Dim colCheck As DataGridViewCheckBoxColumn
        Dim colDropDown As DataGridViewComboBoxColumn

        Select Case Type.ToLower()
            Case "text"
                colText = New DataGridViewTextBoxColumn
                colText.MaxInputLength = MaxInput
                col = colText
            Case "check"
                colCheck = New DataGridViewCheckBoxColumn
                colCheck.DefaultCellStyle.DataSourceNullValue = False
                col = colCheck
            Case "dropdown"
                colDropDown = New DataGridViewComboBoxColumn
                colDropDown.DisplayMember = "PositionAbv"
                colDropDown.ValueMember = "ID"
                colDropDown.DataSource = getTablePositions()
                col = colDropDown

        End Select
        col.Name = Name
        col.HeaderText = Header
        col.DataPropertyName = DataName
        col.Width = Width
        col.Visible = Visible
        col.ReadOnly = colReadOnly
        NewColumn = col
    End Function

    Friend Function getTablePositions() As DataTable
        Dim strSQL As String

        strSQL = "Select ID,PositionAbv  from tblPositions order by PositionName"

        Dim ds As New DataSet
        Dim dtb As DataTable

        dtb = cls.DB_GetDataSet(strSQL, "tblPositions").Tables(0)

        Dim tr As DataRow
        tr = dtb.NewRow
        tr("ID") = 0
        tr("PositionAbv") = "เลือกตำแหน่ง"
        dtb.Rows.InsertAt(tr, 0)


        Return dtb
    End Function



    Friend Sub LoadAndDisplayData(ByVal table As String, ByVal intEmpAutoID As Integer)
        strTable = table.ToLower()
        CurrentEmpAutoID = intEmpAutoID
        GridColumn()

        GetData(CurrentEmpAutoID)

        dgvData.Refresh()

    End Sub

   


    Private Sub dgvData_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvData.CellValidating
        Try
            Dim valueType As Type = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).ValueType
            Dim colName As String = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Name

            If dgvData.CurrentCell.IsInEditMode Then
                If Not cmdSave.Enabled Then cmdSave.Enabled = Not e.Cancel

              
                If valueType.Name = "DateTime" Then
                    If IsDBNull(dgvData.CurrentCell.EditedFormattedValue) Then
                        MsgBox("วันที่ที่คุณใส่ไม่ถูกต้อง", vbCritical)
                        e.Cancel = True
                    Else
                        If IsDate(dgvData.CurrentCell.EditedFormattedValue) = False Then
                            MsgBox("วันที่ที่คุณใส่ไม่ถูกต้อง", vbCritical)
                            e.Cancel = True
                        End If
                    End If
                End If


            End If
            If colName = "NewRow" Then
                If dgvData.CurrentCell.EditedFormattedValue = False Then
                    cmdSave.Enabled = True
                End If
            End If
           
            If e.RowIndex = dgvData.NewRowIndex Then ' this is newly add row not save to db yet

                cmdSave.Enabled = True


                'dgvData.CurrentRow.Cells("EmpID").Value = CurrentEmpAutoID
                'dgvData.CurrentRow.Cells("PositionID").Value = 1
                'If IsDBNull(dgvData.CurrentRow.Cells("IsCurrent").Value) Then
                '    dgvData.CurrentRow.Cells("IsCurrent").Value = False
                'End If
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub dgvData_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvData.RowValidating
        'Dim colType As Type = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).GetType
        'Dim colName As String = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Name

        'dgvData.CurrentRow.Cells("EmpID").Value = CurrentEmpAutoID

        'If IsDBNull(dgvData.CurrentRow.Cells("IsCurrent").Value) Then
        '    dgvData.CurrentRow.Cells("IsCurrent").Value = False
        'End If

        'If IsDBNull(dgvData.CurrentRow.Cells("DateAssigned").Value) Then
        '    MsgBox("กรุณาใส่วันที่เข้าตำแหน่ง", vbCritical)
        '    dgvData.CurrentCell = dgvData.CurrentRow.Cells("DateAssigned")
        '    e.Cancel = True
        'Else
        '    If IsDate(dgvData.CurrentRow.Cells("DateAssigned").Value) = False Then
        '        MsgBox("วันที่เข้าตำแหน่ง ไม่ถูกต้อง. กรุณาใส่ วว/ดด/ปปปป และใช้ปีพ.ศ.เท่านั้น", vbCritical)
        '        dgvData.CurrentCell = dgvData.CurrentRow.Cells("DateAssigned")
        '        e.Cancel = True
        '    End If
        'End If



    End Sub


    ' ''Private Sub dgvData_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvData.CellBeginEdit
    ' ''    Try
    ' ''        Dim bpass As Boolean = False
    ' ''        With dgvData
    ' ''            If .Columns(e.ColumnIndex).Name.ToLower() = "id" Then
    ' ''                If ArrID.IndexOf(.CurrentCell.Value.ToString()) >= 0 Then
    ' ''                    e.Cancel = True
    ' ''                End If
    ' ''            ElseIf .Columns(e.ColumnIndex).Name.ToLower() = "colcancel" Then
    ' ''                If ArrID.IndexOf(.CurrentRow.Cells("ID").Value.ToString()) < 0 Then
    ' ''                    e.Cancel = True
    ' ''                End If
    ' ''            Else
    ' ''                If e.ColumnIndex > 0 And (.CurrentRow.Cells("ID").Value Is DBNull.Value Or .CurrentRow.Cells("ID").Value.ToString() = "") Then
    ' ''                    e.Cancel = True
    ' ''                ElseIf e.ColumnIndex > 0 And ArrID.IndexOf(.CurrentRow.Cells("ID").Value.ToString()) >= 0 Then
    ' ''                    '  e.Cancel = Not User.GetAccess(IIf(strTable = "customer", Access.CustEdit, Access.GroupEdit))
    ' ''                End If
    ' ''            End If
    ' ''        End With
    ' ''    Catch ex As Exception
    ' ''        MsgError(ex)
    ' ''        e.Cancel = True
    ' ''    End Try
    ' ''End Sub
    Private Sub dgvData_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvData.DataError
        DataGridView_DataError(sender, e)
    End Sub
    Public Sub DataGridView_DataError(ByRef sender As Object, ByRef e As DataGridViewDataErrorEventArgs)
        Dim dgv As DataGridView = sender
        If e.Exception.Message = "Input string was not in a correct format." Then
            If dgv.CurrentCell.Value.ToString().Trim() <> "" Then
                MessageBox.Show("กรุณาใส่เฉพาะตัวเลขเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                dgv.CurrentCell.Value = dgv.Columns(e.ColumnIndex).DefaultCellStyle.NullValue
                e.Cancel = False
            End If

            '"The string was not recognized as a valid DateTime. There is a unknown word starting at index 0."
            'Column 'IsCurrent' does not allow nulls.
        ElseIf e.Exception.Message = "The string was not recognized as a valid DateTime. There is a unknown word starting at index 0." Then
            MsgBox("ข้อมูลวันที่ไม่ถูกต้อง กรุณาตรวจสอบ", vbCritical)
        Else
            Throw (e.Exception)
        End If
    End Sub

    Public Function MsgError(ByVal Err As Exception) As String
        Dim strErr As String
        Try
            'ShowWait()
            If Err.Message.IndexOf("A null context handle was passed from the client to the host during a remote procedure call") > -1 Then
                MessageBox.Show("ไม่สามารถพิมพ์รายการได้ กรุณาดูว่าเครื่องพิมพ์รายการเชื่อมต่อกับคอมพิวเตอร์หรือไม่", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strErr = "print"
            ElseIf Err.Message.IndexOf("insert duplicate key") > -1 Then
                MessageBox.Show("รหัสซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strErr = "id"
            ElseIf Err.Message.IndexOf("primary key") > -1 Then
                MessageBox.Show("รหัสซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strErr = "id"
            ElseIf Err.Message.IndexOf("The process cannot access the file") > -1 Then
                MessageBox.Show("ไม่สามารถคัดลอกไฟล์ภาพได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strErr = ""
            Else
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strErr = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strErr = ""
        End Try
        MsgError = strErr
    End Function

    Private Function verifyBeforeSavePositionHistory() As Boolean

        '   If row.RowState = DataRowState.Added Then


        Dim bolReturn As Boolean = False
        With dgvData

            For i = 0 To .Rows.Count - 2


                If .Rows(i).Cells("DateAssigned").Value.ToString().Trim() = "" Then
                    MsgBox("กรุณาใส่วันที่เข้าตำแหน่ง", vbCritical)
                    .CurrentCell = .Rows(i).Cells("DateAssigned")
                    Return False
                End If
                If IsDate(.Rows(i).Cells("DateAssigned").Value) = False Then
                    MsgBox("วันที่เข้าตำแหน่ง ไม่ถูกต้อง. กรุณาใส่ วว/ดด/ปปปป และใช้ปีพ.ศ.เท่านั้น", vbCritical)
                    .CurrentCell = .Rows(i).Cells("DateAssigned")
                    Return False
                End If
            Next i
        End With
        Return True
    End Function

    Private Function SaveNewEmployeePositionHistory(ByVal aryEPH As List(Of Tblemppositionhistory)) As Boolean
        Dim bolReturn As Boolean = False
        Dim eph As Tblemppositionhistory
        Try

            Dim Cn As New SqlClient.SqlConnection(clsUtility.LiveCNS)
            Dim cmd As SqlCommand
            LUNA.LunaContext.Connection = Cn
            LunaContext.Connection.Open()
            LunaContext.Transaction = LunaContext.Connection.BeginTransaction(IsolationLevel.ReadCommitted)
            LunaContext.TransactionBegin()
            cmd = LunaContext.Connection.CreateCommand
            cmd.Transaction = LunaContext.Transaction

            For Each eph In aryEPH
                eph.Save()
            Next

            LunaContext.TransactionCommit()
            bolReturn = True

        Catch ex As Exception
            clsDataSQL.WriteLog("Error SaveNewEmployeePositionHistory()", ex.Message)
            MsgBox(ex.Message)
            LunaContext.TransactionRollback()
            bolReturn = False
        Finally
            LunaContext.Connection.Close()
            aryEPH = Nothing
        End Try


        If bolReturn = True Then

        End If
        Return bolReturn
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim eph As Tblemppositionhistory
        Dim aryEph As New List(Of Tblemppositionhistory)
        Try

            For Each row As DataRow In Ds.Tables(strTable).Rows

                If row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified Then
                    eph = New Tblemppositionhistory

                    If row.RowState = DataRowState.Added Then
                        eph.ID = 0
                    Else
                        eph.ID = row("ID")
                    End If

                    eph.EmpID = row("EmpID")
                    eph.PositionID = row("PositionID")
                    eph.IsCurrent = row("IsCurrent")
                    eph.DateAssigned = cls.CtypeDateToEng(row("DateAssigned"), 99)
                    eph.AssignNote = row("AssignNote")
                    eph.AssignProcessedBy = clsUtility.UserID
                    eph.DateResign = row("DateResign")
                    eph.ResignNote = row("ResignNote")
                    eph.ResignProcessedBy = row("ResignProcessedBy")
                    aryEph.Add(eph)
                End If
            Next
            SaveNewEmployeePositionHistory(aryEph)
        Catch ex As Exception
            MsgError(ex)
        Finally

        End Try
    End Sub

    
    Public Function DateTimeToData(ByVal dtp As Date, Optional ByVal Type As String = "", Optional ByVal fTime As String = "") As String
        Dim str As String = ""
        If fTime = "" Then fTime = "HH:mm:ss"
        fTime = " " & fTime

        If Type = "access" Then
            str = "#" & dtp.ToString("M/d/") & dtp.Year & " " & dtp.ToString(fTime) & "#"
        ElseIf Type = "sql" Then
            str = "'" & dtp.Year & dtp.ToString("/MM/dd ") & dtp.ToString(fTime) & "'"
        Else
            str = "'" & dtp.ToString("dd/MM/") & dtp.Year & " " & dtp.ToString(fTime) & "'"
        End If
        DateTimeToData = str
    End Function


    
    
  
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click


        Dim dtb As DataTable
        dtb = DirectCast(dgvData.DataSource, DataTable)

        Dim newRow As DataRow
        newRow = dtb.NewRow

        newRow("ID") = 0
        newRow("EmpID") = CurrentEmpAutoID
        newRow("PositionID") = 0
        newRow("IsCurrent") = False
        newRow("AssignProcessedBy") = clsUtility.UserID
        newRow("DateAssigned") = Now.ToShortDateString

        dtb.Rows.Add(newRow)




        dgvData.CurrentCell = dgvData.Rows(dgvData.Rows.Count - 1).Cells("NewRow")
        dgvData.CurrentCell.Value = True
      
        dgvData.CurrentCell = dgvData.Rows(dgvData.Rows.Count - 1).Cells("PositionID")  





    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        dgvData.CurrentRow.Selected = True
        Application.DoEvents()
        If MsgBox("คุณกำลังจะลบข้อมูลบรรทัดนี้ ต้องการดำเนินการต่อหรือไม่", vbYesNo) = vbNo Then
            Exit Sub
        End If
        dgvData.Rows.Remove(dgvData.CurrentRow)
    End Sub

  
End Class
