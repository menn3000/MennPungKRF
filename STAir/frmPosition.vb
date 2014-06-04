Imports System.Data.SqlClient

Public Class frmPosition
    Private cls As New clsDataSQL
    Private clsCustomPemission As New clsPermission
    Private Const MaxBudgetAccountPerPosition As Integer = 4


    Private Sub frmPosition_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPermissionSource()
        LoadMainData()
    End Sub

    Private Sub LoadMainData()

        Dim sql(2) As String
        Dim tbl(2) As String
        Dim strSQL As String = ""

        Dim DS As New DataSet

        sql(0) = "Select PositionAbv,PositionName, ID, DefaultAirModuleLevel, DefaultAdminModuleLevel "
        sql(0) += " ,DefaultInvModuleLevel,DefaultFieldWorkModuleLevel, L2CategoryID "
        sql(0) += " from tblPositions "
        sql(0) += " where (L2CategoryID = " & clsUtility.UserLevel2Category.ToString
        sql(0) += " Or DefaultAdminModuleLevel = " & clsPermission.enuPerMission.ExecutiveViewer & ")"
        sql(0) += " order by PositionName"

        tbl(0) = "tblPositions"


        sql(1) = "Select AccountNo as data from tblBudgetAccount order by AccountNo"
        tbl(1) = "tblBudgetAccount"


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing


        grdPositions.DataSource = DS.Tables("tblPositions")

        If grdPositions.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdPositions.ActiveRow = grdPositions.Rows(0)
        End If



        SetAutoCompleteSource(txtAccountNumber1, DS.Tables("tblBudgetAccount"))
        SetAutoCompleteSource(txtAccountNumber2, DS.Tables("tblBudgetAccount"))
        SetAutoCompleteSource(txtAccountNumber3, DS.Tables("tblBudgetAccount"))
        SetAutoCompleteSource(txtAccountNumber4, DS.Tables("tblBudgetAccount"))


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



    Private Sub grdPositions_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPositions.AfterRowActivate

        If rblUpdateMode.Checked = True Then
            GetPositionInfoForEdit()
        End If


    End Sub

    Private Sub LoadPermissionSource()

        Dim dtbPermission As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission, True)

        Dim dtbPermission2 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission2, True)

        Dim dtbPermission3 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission3, True)

        Dim dtbPermission4 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission4, True)

        Me.cboPAir.DisplayMember = "LevelName"
        cboPAir.ValueMember = "ID"
        Me.cboPAir.DataSource = dtbPermission
        cboPAir.SelectedIndex = -1


        Me.cboPAdmin.DisplayMember = "LevelName"
        cboPAdmin.ValueMember = "ID"
        Me.cboPAdmin.DataSource = dtbPermission2
        cboPAdmin.SelectedIndex = -1

        Me.cboPInv.DisplayMember = "LevelName"
        cboPInv.ValueMember = "ID"
        Me.cboPInv.DataSource = dtbPermission3
        cboPInv.SelectedIndex = -1

        Me.cboPFieldWork.DisplayMember = "LevelName"
        cboPFieldWork.ValueMember = "ID"
        Me.cboPFieldWork.DataSource = dtbPermission4
        cboPFieldWork.SelectedIndex = -1


    End Sub


    Private Sub ClearForm()
        txtPositionName.Text = ""
        txtPositionAbv.Text = ""
        cboPAdmin.SelectedIndex = -1
        cboPAir.SelectedIndex = -1
        cboPInv.SelectedIndex = -1
        cboPFieldWork.SelectedIndex = -1

        txtAccountNumber1.Text = ""
        txtAccountNumber2.Text = ""
        txtAccountNumber3.Text = ""
        txtAccountNumber4.Text = ""

        txtBudgetPercent1.Text = "100"
        txtBudgetPercent2.Text = "0"
        txtBudgetPercent3.Text = "0"
        txtBudgetPercent4.Text = "0"


    End Sub
    Private Sub GetPositionInfoForEdit()
        ClearForm()



        txtPositionName.Text = grdPositions.ActiveRow.Cells("PositionName").Value
        txtPositionAbv.Text = grdPositions.ActiveRow.Cells("PositionAbv").Value
        cboPAdmin.SelectedValue = grdPositions.ActiveRow.Cells("DefaultAdminModuleLevel").Value
        cboPAir.SelectedValue = grdPositions.ActiveRow.Cells("DefaultAirModuleLevel").Value
        cboPInv.SelectedValue = grdPositions.ActiveRow.Cells("DefaultInvModuleLevel").Value
        cboPFieldWork.SelectedValue = grdPositions.ActiveRow.Cells("DefaultFieldWorkModuleLevel").Value


        rblUpdateMode.Checked = True


        Dim strSQL As String = ""
        strSQL = "Select p.BudgetAccountID, p.PositionBudgetID, a.AccountNo, p.Percentage "
        strSQL += " from tblPositionBudget p, tblBudgetAccount a"
        strSQL += "  where p.BudgetAccountID = a.AccountNo "
        strSQL += "  and p.PositionID =" & grdPositions.ActiveRow.Cells("ID").Value
        strSQL += " order by a.AccountNo,  p.Percentage "


        Dim dr As SqlDataReader
        Dim counter As Integer = 1
        Dim txtAcc As TextBox
        Dim txtpercent As Infragistics.Win.UltraWinEditors.UltraNumericEditor

        dr = cls.DB_GetDataReader(strSQL)

        Do While dr.Read
            If counter <= MaxBudgetAccountPerPosition Then
                txtAcc = CType(FindControl("txtAccountNumber" & counter.ToString, grbPositionBudget), TextBox)
                txtpercent = CType(FindControl("txtBudgetPercent" & counter.ToString, grbPositionBudget), Infragistics.Win.UltraWinEditors.UltraNumericEditor)
                txtAcc.Text = dr("BudgetAccountID")
                txtpercent.Text = dr("Percentage")
                counter += 1
            End If
        Loop

        dr.Close()


    End Sub

    Private Sub grdPositions_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdPositions.BeforeCellUpdate
        e.Cancel = True
    End Sub

   

    Private Sub grdPositions_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPositions.InitializeLayout
        grdPositions.DisplayLayout.AutoFitColumns = True


        grdPositions.DisplayLayout.Bands(0).Columns("PositionName").Header.Caption = "ตำแหน่ง"
        grdPositions.DisplayLayout.Bands(0).Columns("PositionAbv").Header.Caption = "ชื่อย่อตำแหน่ง"
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultAirModuleLevel").Header.Caption = "สิทธิระบบสารบรรณ"
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultAdminModuleLevel").Header.Caption = "สิทธิระบบแอร์"



        grdPositions.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultAirModuleLevel").Hidden = True
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultAdminModuleLevel").Hidden = True
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultInvModuleLevel").Hidden = True
        grdPositions.DisplayLayout.Bands(0).Columns("DefaultFieldWorkModuleLevel").Hidden = True
        grdPositions.DisplayLayout.Bands(0).Columns("L2CategoryID").Hidden = True


    End Sub


  

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveData()
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
        If checkISExistedPosition(txtPositionAbv.Text) = True Then
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


            'Delete Previous records in tblPositionBudget
            cmd.CommandText = "Delete from tblPositionBudget  where PositionID =  " & intNewPositionID.ToString
            cmd.ExecuteNonQuery()


            Dim counter As Integer = 1
            Dim txtAcc As TextBox
            Dim txtpercent As Infragistics.Win.UltraWinEditors.UltraNumericEditor


            For counter = 1 To MaxBudgetAccountPerPosition
                If counter <= MaxBudgetAccountPerPosition Then
                    txtAcc = CType(FindControl("txtAccountNumber" & counter.ToString, grbPositionBudget), TextBox)
                    txtpercent = CType(FindControl("txtBudgetPercent" & counter.ToString, grbPositionBudget), Infragistics.Win.UltraWinEditors.UltraNumericEditor)

                    If txtAcc.Text <> "" Then
                        Try ' if accountNo is existed (key) then it will error, we will just skip it
                            cmd.CommandText = "INSERT INTO tblBudgetAccount (AccountNo) Values (" & txtAcc.Text & ")  "
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                       
                        ' Insert New tblPositionBudget
                        cmd.CommandText = "INSERT INTO tblPositionBudget (PositionID,BudgetAccountID,Percentage) Values (" & intNewPositionID & "," & txtAcc.Text & "," & txtpercent.Value & ")"
                        ' Execute the command.
                        cmd.ExecuteNonQuery()
                    End If
                    counter += 1
                End If
            Next


            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น ตำแหน่งนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
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
        strSQL = "Insert into tblPositions (PositionName, PositionAbv,[DefaultAirModuleLevel],DefaultAdminModuleLevel, DefaultInvModuleLevel,DefaultFieldWorkModuleLevel, L2CategoryID"
        strSQL += ") values ("
        strSQL += "'" & txtPositionName.Text & "', "
        strSQL += "'" & txtPositionAbv.Text & "', "
        strSQL += cboPAir.SelectedValue.ToString & ", "
        strSQL += cboPAdmin.SelectedValue.ToString & ", "
        strSQL += cboPInv.SelectedValue.ToString & ", "
        strSQL += cboPFieldWork.SelectedValue.ToString & ", "
        strSQL += clsUtility.UserLevel2Category.ToString
        strSQL += ")"

        Return strSQL
    End Function

    

    Private Function verifyInput() As Boolean

        Me.txtPositionName.Text = Trim(Replace(txtPositionName.Text, Chr(39), Chr(146)))
        Me.txtPositionAbv.Text = Trim(Replace(txtPositionAbv.Text, Chr(39), Chr(146)))


        If txtPositionName.Text.Length = 0 Then
            MsgBox("กรุณาใส่ชื่อตำแหน่ง", vbCritical)
            Return False
        End If

        If txtPositionAbv.Text.Length = 0 Then
            MsgBox("กรุณาใส่ตัวย่อตำแหน่ง", vbCritical)
            Return False
        End If

        If cboPAir.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก สิทธิการใช้งานแผนกแอร์ สำหรับพนักงานตำแหน่งนี้", vbCritical)
            Return False
        End If

        If cboPAdmin.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก สิทธิการใช้งานแผนกสารบรรณ สำหรับพนักงานตำแหน่งนี้", vbCritical)
            Return False
        End If

        If cboPInv.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก สิทธิการใช้งานระบบวัสดุ สำหรับพนักงานตำแหน่งนี้", vbCritical)
            Return False
        End If

        If cboPFieldWork.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก สิทธิการใช้งานระบบภาคสนาม สำหรับพนักงานตำแหน่งนี้", vbCritical)
            Return False
        End If


        If verifyAccountBudgeting() = False Then
            Return False
        End If

        Return True
    End Function

    Private Function verifyAccountBudgeting() As Boolean


        Dim totalPercentage As Int16
        Dim counter As Integer = 1
        Dim txtAcc As TextBox
        Dim txtpercent As Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Dim intEmptyAccountCounter As Integer = 0

        For counter = 1 To MaxBudgetAccountPerPosition


            txtAcc = CType(FindControl("txtAccountNumber" & counter.ToString, grbPositionBudget), TextBox)
            txtpercent = CType(FindControl("txtBudgetPercent" & counter.ToString, grbPositionBudget), Infragistics.Win.UltraWinEditors.UltraNumericEditor)


            ' skip empty account no

            If txtAcc.Text = "" Then ' if it is "" then set percent to 0
                If txtpercent.Value > 0 Then
                    txtpercent.Value = 0
                End If
                intEmptyAccountCounter += 1
            End If

            totalPercentage += CInt(txtpercent.Value)


            'loop to see any dubplicate accountNo in each textbox

            Dim dubCount As Integer = 0
            For Each ctr As Control In Me.grbPositionBudget.Controls

                If TypeOf (ctr) Is TextBox And Not ctr.Name = txtAcc.Name Then
                    Dim txt As TextBox = CType(ctr, TextBox)
                    If txt.Text = txtAcc.Text And txtAcc.Text <> "" Then ' check dub account number if it is not ""
                        dubCount += 1
                    End If
                    txt = Nothing
                End If

            Next

            If dubCount > 0 Then
                MsgBox("คุณใส่เลขบัญชีซ้ำกัน กรุณาตรวจสอบ เลขบัญชี " & txtAcc.Text, vbCritical)
                txtAcc.Select()
                Return False
            End If

        Next

        ' if all account box are empty
        If intEmptyAccountCounter = MaxBudgetAccountPerPosition Then
            MsgBox("กรุณาใส่เลขที่บัญชี ที่ใช้ในการจ่ายเงินเดือนสำหรับตำแหน่งนี้ อย่างน้อย 1 เลขบัญชี", vbCritical)
            txtAccountNumber1.Select()
            Return False
        End If

        If Not totalPercentage = 100 Then
            MsgBox("อัตราร้อยละของทุกบัญชีรวมกันแล้ว ต้องได้เท่ากับ 100 พอดี กรุณาตรวจสอบ ", vbCritical)
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

    Private Function checkISExistedPosition(ByVal strPositionAbv As String, Optional ByVal intUpdatingPositionID As Integer = 0) As Boolean

        ' Allow same name but not allow same abbv. in the same ศูนย์

        Dim strSQL As String = "Select * from tblPositions "
        strSQL += "  where PositionAbv = '" & strPositionAbv & "'"
        strSQL += " and (L2CategoryID = " & clsUtility.UserLevel2Category.ToString
        strSQL += " Or DefaultAdminModuleLevel = " & clsPermission.enuPerMission.ExecutiveViewer & ")"

        If intUpdatingPositionID > 0 Then
            strSQL += " and ID <> " & intUpdatingPositionID.ToString
        End If

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then
            Dim msg As String = "ชื่อย่อตำแหน่งนี้ซ้ำกับ ตำแหน่งที่มีอยู่แล้ว กรุณาตรวจสอบ" & vbCrLf & "ชื่อตำแหน่งในระบบ คือ" & dr("PositionName") & vbCrLf & " ชื่อย่อในระบบ คือ " & dr("PositionAbv")
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
        If checkISExistedPosition(txtPositionAbv.Text, intPositionID) = True Then
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

            'Delete Previous records in tblPositionBudget
            cmd.CommandText = "Delete from tblPositionBudget  where PositionID =  " & intPositionID.ToString
            cmd.ExecuteNonQuery()


            Dim counter As Integer = 1
            Dim txtAcc As TextBox
            Dim txtpercent As Infragistics.Win.UltraWinEditors.UltraNumericEditor


            For counter = 1 To MaxBudgetAccountPerPosition
                If counter <= MaxBudgetAccountPerPosition Then
                    txtAcc = CType(FindControl("txtAccountNumber" & counter.ToString, grbPositionBudget), TextBox)
                    txtpercent = CType(FindControl("txtBudgetPercent" & counter.ToString, grbPositionBudget), Infragistics.Win.UltraWinEditors.UltraNumericEditor)

                    If txtAcc.Text <> "" Then
                        Try
                            ' Insert if New AccountNo
                            cmd.CommandText = "INSERT INTO tblBudgetAccount (AccountNo) Values (" & txtAcc.Text & ")  "
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                       
                        ' Insert New tblPositionBudget
                        cmd.CommandText = "INSERT INTO tblPositionBudget (PositionID,BudgetAccountID,Percentage) Values (" & intPositionID & "," & txtAcc.Text & "," & txtpercent.Value & ")"
                        ' Execute the command.
                        cmd.ExecuteNonQuery()
                    End If

                End If
            Next


            trans.Commit()
            bolReturn = True
        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น ตำแหน่งนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
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
        strSQL = "Update tblPositions Set  "
        strSQL += " PositionName = '" & txtPositionName.Text & "'"
        strSQL += " ,PositionAbv = '" & txtPositionAbv.Text & "'"
        strSQL += " ,DefaultAirModuleLevel = " & cboPAir.SelectedValue.ToString
        strSQL += " ,DefaultAdminModuleLevel = " & cboPAdmin.SelectedValue.ToString
        strSQL += " ,DefaultInvModuleLevel = " & cboPInv.SelectedValue.ToString
        strSQL += " ,DefaultFieldWorkModuleLevel = " & cboPFieldWork.SelectedValue.ToString
        strSQL += " Where ID = " & intPositionID.ToString

        Return strSQL
    End Function
    'Private Sub UpdatedRecord(ByVal intPositionID As Integer)
    '    If verifyInput() = False Then
    '        Exit Sub
    '    End If
    '    If checkISExistedPosition(txtPositionName.Text, intPositionID) = True Then
    '        Exit Sub
    '    End If

    '    Try
    '        Dim strSQL As String
    '        strSQL = "Update tblPositions Set  "
    '        strSQL += " PositionName = '" & txtPositionName.Text & "'"
    '        strSQL += " ,PositionAbv = '" & txtPositionAbv.Text & "'"
    '        strSQL += " ,DefaultAirModuleLevel = " & cboPAir.SelectedValue.ToString
    '        strSQL += " ,DefaultAdminModuleLevel = " & cboPAdmin.SelectedValue.ToString
    '        strSQL += " Where ID = " & intPositionID.ToString

    '        If cls.ExcuteData(strSQL, clsUtility.UserID) = True Then
    '            clsUtility.PositionRecordsLatestTime = Now
    '            MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
    '            LoadMainData()
    '        End If

    '    Catch ex As Exception
    '        MsgBox("มีความผิดพลาดเกิดขึ้น ตำแหน่งนี้ยังไม่ถูกแก้ไข " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
    '        clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
    '    End Try



    'End Sub

    
  
    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdPositions.ActiveRow = Nothing
            ClearForm()
            txtPositionName.Select()
        Else

            If grdPositions.Rows.Count > 0 Then
                grdPositions.ActiveRow = grdPositions.Rows(0)
            Else
                MsgBox("ยังไม่มีตำแหน่งใดๆในระบบ กรุณาเพิ่มตำแหน่งในระบบก่อน", vbQuestion)
            End If

        End If
    End Sub

   
   
   
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.ClearForm()
        Me.Hide()
    End Sub

End Class