Imports System.Data.SqlClient
Imports STAir.LUNA
Imports System.IO

Public Class frmAddUser
    Private cls As New clsDataSQL
    Private fMain As frmMDIMain

    Private clsCustomPemission As New clsPermission

    Private EmpPositionRecordsLatestTime As DateTime = Now

    Private Sub frmAddUser_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If EmpPositionRecordsLatestTime < clsUtility.PositionRecordsLatestTime Then

            egridPosition.LoadPositions()

        End If
    End Sub

    Friend Overloads Sub Show(ByVal intID As Integer)
        Me.Show()
        LoadExistedEmp(intID)
    End Sub


    Private Sub frmAddUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fMain = Me.ParentForm

        LoadPrefix()
        LoadPermissionSource()
        LoadMainData()


    End Sub

    Private Sub LoadPrefix()
        cboPrefix.Items.Add("นาย")
        cboPrefix.Items.Add("นาง")
        cboPrefix.Items.Add("นางสาว")

    End Sub
    Private Sub LoadMainData()

        Dim sql(1) As String
        Dim tbl(1) As String
        Dim strSQL As String = ""

        Dim DS As New DataSet

        '----------------AUTO COMPLETE SOURCES--------------------------------

        sql(0) = "Select distinct WorkLine as data from tblEmployees  "
        tbl(0) = "AutoCompletedworkLine"


        '----------------------------------------


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing


        SetAutoCompleteSource(txtWorkLine, DS.Tables("AutoCompletedworkLine"))


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



    Private Sub LoadPermissionSource()

        Dim dtbPermission As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission)

        Me.cboPAir.DisplayMember = "LevelName"
        cboPAir.ValueMember = "ID"
        Me.cboPAir.DataSource = dtbPermission
        cboPAir.SelectedIndex = -1


        Dim dtbPermission2 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission2)

        Me.cboPAdmin.DisplayMember = "LevelName"
        cboPAdmin.ValueMember = "ID"
        Me.cboPAdmin.DataSource = dtbPermission2
        cboPAdmin.SelectedIndex = -1

        Dim dtbPermission3 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission3)

        Me.cboPInv.DisplayMember = "LevelName"
        cboPInv.ValueMember = "ID"
        Me.cboPInv.DataSource = dtbPermission3
        cboPInv.SelectedIndex = -1

        Dim dtbPermission4 As New DataTable
        clsCustomPemission.CreatePermissionLevelTable(dtbPermission4)

        Me.cboPFieldWork.DisplayMember = "LevelName"
        cboPFieldWork.ValueMember = "ID"
        Me.cboPFieldWork.DataSource = dtbPermission4
        cboPFieldWork.SelectedIndex = -1


    End Sub




    Private Function DecryptData(ByVal obj As Object)
        If IsDBNull(obj) Then
            Return String.Empty
        Else
            Return clsUtility.DecryptText(obj)
        End If
    End Function


    Private Sub cmdAddNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewEmployee.Click
        EmployeeTab.SelectedTab = EmployeeTab.TabPages("tbPosition")
    End Sub

    Private Sub ClearData()
        cboEmp.DataSource = Nothing
        txtEmployeeID.Text = ""
        txtNationalID.Text = ""
        txtName.Text = ""
        cboPrefix.SelectedIndex = -1
        txtPosition.Text = ""
        txtPassword.Text = ""
        cboPAir.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        cboPAdmin.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        cboPInv.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        cboPFieldWork.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition

        lblBreadCrumb.Text = ""
        txtMainCategoryID.Text = ""
        egridPosition.LoadAndDisplayData(0)
        egridEmpLevelHistory.LoadAndDisplayData(0)
        egridEmpEduHistory.LoadAndDisplayData(0)
        egridEmpKids.LoadAndDisplayData(0)
        egridWorkLog.LoadAndDisplayData(0)


        txtNameEn.Text = ""
        txtNickName.Text = ""
        dtDOB.Value = Today
        txtAddress.Text = ""
        txtWorkLine.Text = ""

        txtSalaryLevel.Text = "'"
        txtSalary.Text = ""

        txtFatherName.Text = ""
        txtMotherName.Text = ""
        txtSpouseName.Text = ""
        chkFatherAlive.Checked = True
        chkMotherAlive.Checked = True
        chkSpouseAlive.Checked = True

        chkDivorce.Checked = False



    End Sub

    Private Sub LoadExistedEmp(ByVal intID As Integer)

        ClearData()
        If intID = 0 Then
            egridPosition.Enabled = False
            egridEmpLevelHistory.Enabled = False
            egridEmpEduHistory.Enabled = False
            egridEmpKids.Enabled = False
            egridWorkLog.Enabled = False
            txtPosition.Text = "แรกเข้าทำงาน"
            Exit Sub
        ElseIf intID = clsUtility.UserID Then
            Dim targetControl() As Control = {cmdBreadCrumb, txtEmployeeID, txtNationalID, _
                                              cboPrefix, txtName, txtWorkLine, egridPosition _
                                             , egridEmpLevelHistory, egridEmpKids, egridEmpEduHistory _
                                             , pnlPermission, dtDOB}
            clsPermission.EnableDisableControlByPermission(targetControl, clsUtility.DefaultAdminModuleLevel, clsPermission.WhatUserCanDo.CanWrite)
          
        Else
            egridPosition.Enabled = True
            egridEmpLevelHistory.Enabled = True
            egridEmpEduHistory.Enabled = True
            egridEmpKids.Enabled = True
            egridWorkLog.Enabled = True
        End If



        Dim strSQL As String

        'strSQL = "Select e.*, p.DefaultAirModuleLevel,p.DefaultAdminModuleLevel,p.PositionAbv,p.PositionName"
        'strSQL += " from tblEmployees e, tblPositions p "
        'strSQL += "  where e.ID = " & intID.ToString
        'strSQL += "  and e.CurrentPositionID = p.ID "
        strSQL = "emp_GetEmpDataWithBreadCrumbByID " & intID.ToString


        Dim ds As New DataSet

        ds = cls.DB_GetDataSet(strSQL, "tblEmployees", False)

        cboEmp.DisplayMember = "FName"
        cboEmp.ValueMember = "ID"
        cboEmp.DataSource = ds.Tables("tblEmployees")

        If ds.Tables("tblEmployees").Rows.Count = 1 Then
            cboEmp.SelectedIndex = 0
        End If

        txtEmployeeID.Text = cboEmp.SelectedItem("EmployeeID")
        txtNationalID.Text = nvl(cboEmp.SelectedItem("NationalID"))
        txtName.Text = String.Format("{0} {1}", cboEmp.SelectedItem("Fname"), cboEmp.SelectedItem("Lname"))
        cboPrefix.Text = cboEmp.SelectedItem("Prefix")
        txtPosition.Text = cboEmp.SelectedItem("PositionAbv")
        txtPassword.Text = clsUtility.DecryptText(cboEmp.SelectedItem("password"))
        cboPAir.SelectedValue = cboEmp.SelectedItem("OverWriteAirModuleLevel")
        cboPAdmin.SelectedValue = cboEmp.SelectedItem("OverWriteAdminModuleLevel")
        cboPInv.SelectedValue = cboEmp.SelectedItem("OverWriteInvModuleLevel")
        cboPFieldWork.SelectedValue = cboEmp.SelectedItem("OverWriteFieldWorkModuleLevel")
        lblBreadCrumb.Text = cboEmp.SelectedItem("BreadCrumb")
        txtMainCategoryID.Text = cboEmp.SelectedItem("MainCategory")

        txtNameEn.Text = String.Format("{0} {1}", nvl(cboEmp.SelectedItem("FnameEN")), nvl(cboEmp.SelectedItem("LnameEN")))
        txtNickName.Text = nvl(cboEmp.SelectedItem("NickName"))
        dtDOB.Value = cboEmp.SelectedItem("DOB")
        txtAddress.Text = nvl(cboEmp.SelectedItem("Address"))
        txtWorkLine.Text = nvl(cboEmp.SelectedItem("WorkLine"))
        txtEmail.Text = nvl(cboEmp.SelectedItem("Email"))
        txtMobile.Text = nvl(cboEmp.SelectedItem("MobilePhone"))

        egridPosition.LoadAndDisplayData(cboEmp.SelectedItem("ID"))
        egridEmpLevelHistory.LoadAndDisplayData(cboEmp.SelectedItem("ID"))
        egridEmpEduHistory.LoadAndDisplayData(cboEmp.SelectedItem("ID"))
        egridEmpKids.LoadAndDisplayData(cboEmp.SelectedItem("ID"))
        egridWorkLog.LoadAndDisplayData(cboEmp.SelectedItem("ID"))


        txtSalaryLevel.Text = egridEmpLevelHistory.CurrenLevel
        txtSalary.Text = egridEmpLevelHistory.CurrentSalary

        txtFatherName.Text = nvl(cboEmp.SelectedItem("FatherName"))
        txtMotherName.Text = nvl(cboEmp.SelectedItem("MotherName"))
        txtSpouseName.Text = nvl(cboEmp.SelectedItem("SpouseName"))
        chkFatherAlive.Checked = nvl(cboEmp.SelectedItem("FatherAlive"), True)
        chkMotherAlive.Checked = nvl(cboEmp.SelectedItem("MotherAlive"), True)
        chkSpouseAlive.Checked = nvl(cboEmp.SelectedItem("SpouseAlive"), True)

        If nvl(cboEmp.SelectedItem("MariageStatus")) = "D" Then
            chkDivorce.Checked = True
        End If

    End Sub
    Private Function nvl(ByVal obj As Object, Optional ByVal returnValue As Object = "") As Object
        If IsDBNull(obj) Then
            Return returnValue
            Return ""
        Else
            Return obj
        End If
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If verifyInput() = False Then
            Exit Sub
        End If
        If SaveNewEmployee() = True Then
            MsgBox("ข้อมูลได้ถูกบันทึกเรียบร้อยแล้ว", vbInformation)
        End If
    End Sub

    Private Function SaveNewEmployee() As Boolean
        Dim bolReturn As Boolean = False
        Dim emp As Tblemployees
        Dim NewEmpID As Integer = 0
        Dim bolISNewEmployee As Boolean = False
        Try


            Dim Cn As New SqlClient.SqlConnection(clsUtility.LiveCNS)
            Dim cmd As SqlCommand
            LUNA.LunaContext.Connection = Cn
            LunaContext.Connection.Open()
            LunaContext.Transaction = LunaContext.Connection.BeginTransaction(IsolationLevel.ReadCommitted)
            LunaContext.TransactionBegin()
            cmd = LunaContext.Connection.CreateCommand
            cmd.Transaction = LunaContext.Transaction
            'LunaContext.Connection.CreateCommand.Transaction = LunaContext.Transaction

            emp = New Tblemployees
            Dim strName As String() = Trim(txtName.Text).Split(" ")
            Dim strNameEN As String() = Trim(txtNameEn.Text).Split(" ")

            With emp
                If cboEmp.DataSource Is Nothing Then
                    .ID = 0
                    bolISNewEmployee = True
                Else
                    .ID = cboEmp.SelectedItem("ID")
                End If

                'egridPosition will set its CurrenPositionID = 1 if no Position History Record found
                'this is hardcode in DB that tblPositions ID1 = แรกเข้าทำงาน permission = 0 for all
                .CurrentPositionID = egridPosition.CurrenPositionID


                .MainCategory = CInt(txtMainCategoryID.Text)
                .EmployeeID = txtEmployeeID.Text
                .Password = clsUtility.EncryptText(txtPassword.Text)
                .prefix = cboPrefix.Text
                .FName = strName(0)
                .LName = strName(1)

                If strNameEN.Count = 2 Then
                    .FNameEn = strNameEN(0)
                    .LNameEn = strNameEN(1)
                End If

                .NationalID = txtNationalID.Text
                .NickName = txtNickName.Text
                .DOB = cls.CtypeDateToEng(dtDOB.Value, 99)
                .Address = txtAddress.Text
                .WorkLine = txtWorkLine.Text
                .Email = txtEmail.Text
                .MobilePhone = txtMobile.Text
                .DateTimeStamp = cls.CtypeDateToEng(Now, 3)
                .UpdatedBy = clsUtility.UserID
                .OverWriteAirModuleLevel = cboPAir.SelectedValue
                .OverWriteAdminModuleLevel = cboPAdmin.SelectedValue
                .OverWriteInvModuleLevel = cboPInv.SelectedValue
                .OverWriteFieldWorkModuleLevel = cboPFieldWork.SelectedValue

                .FatherName = txtFatherName.Text
                .MotherName = txtMotherName.Text
                .SpouseName = txtSpouseName.Text

                .FatherAlive = chkFatherAlive.Checked
                .MotherAlive = chkMotherAlive.Checked
                .SpouseAlive = chkSpouseAlive.Checked
                .MariageStatus = GetMarriageStatus()

                ''will do later
                '.EmpImageFilePath = ""


                If .IsValid Then
                    NewEmpID = .Save
                End If


            End With

            If NewEmpID = 0 Then MessageBox.Show("มีความผิดพลาด พนักงานยังไม่ถูกบันทึก")


            LunaContext.TransactionCommit()
            bolReturn = True

        Catch ex As ApplicationException
            If ex.Message = "Luna Engine Exception: Object data is not valid" Then
                LunaContext.TransactionRollback()

            End If
            MsgBox(ex.Message)
        Finally

            LunaContext.Connection.Close()
        End Try

        '' Start Save the Position for newly Saved employee
        ''have to do this after the first transaction because
        ''egridPosition uses another transaction , so we can not created nested transaction

        'If bolISNewEmployee = True Then
        '    egridPosition.ProcessSavePositionForNewEmployee(NewEmpID)
        'End If


        If bolReturn = True Then
            LoadExistedEmp(emp.ID)
        End If
        Return bolReturn
    End Function

  

    Private Function GetMarriageStatus() As String

        If Trim(txtSpouseName.Text.Length) = 0 Then
            Return "S"
        ElseIf Trim(txtSpouseName.Text.Length) > 0 And chkDivorce.Checked = True Then
            Return "D"
        ElseIf Trim(txtSpouseName.Text.Length) > 0 And chkDivorce.Checked = False Then
            Return "M"
        End If
    End Function

    Private Function verifyInput() As Boolean


        If txtMainCategoryID.Text = "" Then
            MsgBox("กรุณาเลือกสังกัดของพนักงานท่านนี้", vbCritical)
            cmdBreadCrumb.Select()
            Return False
        End If

        Me.txtEmployeeID.Text = Trim(txtEmployeeID.Text)
        If txtEmployeeID.Text.Length = 0 Then
            MsgBox("กรุณาใส่เลขประจำตัว ทสค.", vbCritical)
            txtEmployeeID.Select()
            Return False
        End If
        If txtEmployeeID.Text.Length > 50 Then
            MsgBox("เลขประจำตัว ทสค. มีความยาวสูงสุดได้ไม่เกิน 50 ตัว", vbCritical)
            txtEmployeeID.Select()
            Return False
        End If

        Me.txtNationalID.Text = Trim(txtNationalID.Text)
        If txtNationalID.Text.Length > 20 Then
            MsgBox("หมายเลขบัตรประชาชน มีความยาวสูงสุดได้ไม่เกิน 20 ตัว", vbCritical)
            txtNationalID.Select()
            Return False
        End If



        Dim strName As String() = Trim(txtName.Text).Split(" ")

        If strName.Count = 2 Then
            If strName(0).Length > 100 Then
                MsgBox("ชื่อพนักงาน มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
                txtName.Select(0, strName(0).Length)
                Return False
            End If
            If strName(1).Length > 100 Then
                MsgBox("นามสกุลพนักงาน มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
                txtName.Select(strName(0).Length + 1, strName(1).Length)
                Return False
            End If

        Else
            MsgBox("กรุณาใส่ชื่อ เว้นวรรค และตามด้วยนามสกุล", vbCritical)
            txtName.Select()
            Return False
        End If

        If txtNameEn.Text.Length > 0 Then
            Dim strEnName As String() = Trim(txtNameEn.Text).Split(" ")

            If strEnName.Count = 2 Then
                If strEnName(0).Length > 100 Then
                    MsgBox("ชื่อพนักงาน (อังกฤษ) มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
                    txtNameEn.Select(0, strEnName(0).Length)
                    Return False
                End If
                If strEnName(1).Length > 100 Then
                    MsgBox("นามสกุลพนักงาน (อังกฤษ) มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
                    txtNameEn.Select(strEnName(0).Length + 1, strEnName(1).Length)
                    Return False
                End If
            Else
                MsgBox("กรุณาใส่ชื่อ (อังกฤษ) เว้นวรรค และตามด้วยนามสกุล (อังกฤษ)", vbCritical)
                txtNameEn.Select()
                Return False

            End If

        End If




        If txtNickName.Text.Length > 100 Then
            MsgBox("ชื่อเล่น มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
            txtNickName.Select()
            Return False
        End If


        If txtPassword.Text.Length < 4 Then
            MsgBox("รหัสผ่าน ต้องมีมีความยาวไม่น้อยกว่า 4 ตัว", vbCritical)
            txtPassword.Select()
            Return False
        End If
        If txtPassword.Text.Length > 10 Then
            MsgBox("รหัสผ่าน มีความยาวสูงสุดได้ไม่เกิน 10 ตัว", vbCritical)
            txtPassword.Select()
            Return False
        End If

        If txtWorkLine.Text.Length > 100 Then
            MsgBox("สายงาน มีความยาวสูงสุดได้ไม่เกิน 100 ตัว", vbCritical)
            txtWorkLine.Select()
            Return False
        End If

        If txtAddress.Text.Length > 512 Then
            MsgBox("ที่อยู่ มีความยาวสูงสุดได้ไม่เกิน 512 ตัว", vbCritical)
            txtPassword.Select()
            Return False
        End If

        If txtFatherName.Text.Length > 512 Then
            MsgBox("ชื่อบิดา มีความยาวสูงสุดได้ไม่เกิน 512 ตัว", vbCritical)
            txtFatherName.Select()
            Return False
        End If
        If txtMotherName.Text.Length > 512 Then
            MsgBox("ชื่อมารดา มีความยาวสูงสุดได้ไม่เกิน 512 ตัว", vbCritical)
            txtMotherName.Select()
            Return False
        End If
        If txtSpouseName.Text.Length > 512 Then
            MsgBox("ชื่อคู่สมรส มีความยาวสูงสุดได้ไม่เกิน 512 ตัว", vbCritical)
            txtSpouseName.Select()
            Return False
        End If



        If cboPAdmin.SelectedIndex = -1 Then
            cboPAdmin.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        End If

        If cboPAir.SelectedIndex = -1 Then
            cboPAir.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        End If

        If cboPInv.SelectedIndex = -1 Then
            cboPInv.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        End If

        If cboPFieldWork.SelectedIndex = -1 Then
            cboPFieldWork.SelectedValue = clsPermission.enuPerMission.UseDefaultFromPosition
        End If


        If CheckDubEmployeeNumber() = True Then
            Return False
        End If
        If CheckDubNationalID() = True Then
            Return False
        End If



        Return True
    End Function
    Private Function CheckDubEmployeeNumber() As Boolean

        Dim bolReturn As Boolean = False
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text


        Dim strSQL As String
        strSQL = "Select * from tblEmployees where EmployeeID = @EmployeeID"
        cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text)


        If Not cboEmp.DataSource Is Nothing Then ' updating emp
            strSQL += " and ID <> @ID"
            cmd.Parameters.AddWithValue("@ID", cboEmp.SelectedItem("ID"))
        End If

        cmd.CommandText = strSQL

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(cmd)

        If dr.Read Then
            bolReturn = True
            MsgBox(String.Format("หมายเลข ทคส.นี้ซ้ำกันกับ หมายเลขทคส.ของ ทคส.{0} {1} {2} ", dr("EmployeeID"), dr("FName"), dr("LName")), vbInformation)
        End If
        dr.Close()

        Return bolReturn

    End Function
    Private Function CheckDubNationalID() As Boolean


        Dim bolReturn As Boolean = False
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text


        Dim strSQL As String
        strSQL = "Select * from tblEmployees where NationalID = @NationalID"
        cmd.Parameters.AddWithValue("@NationalID", txtNationalID.Text)


        If Not cboEmp.DataSource Is Nothing Then ' updating emp
            strSQL += " and ID <> @ID"
            cmd.Parameters.AddWithValue("@ID", cboEmp.SelectedItem("ID"))
        End If


        cmd.CommandText = strSQL


        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(cmd)

        If dr.Read Then
            bolReturn = True
            MsgBox(String.Format("หมายเลขบัตรประชาชนนี้ ซ้ำกันกับ หมายเลขบัตรฯของ ทคส.{0} {1} {2} ", dr("EmployeeID"), dr("FName"), dr("LName")), vbInformation)
        End If
        dr.Close()

        Return bolReturn

    End Function

    Private Sub egridPosition_NewPositionHistoryCreated(ByVal intEmpID As Integer) Handles egridPosition.NewPositionHistoryCreated
        LoadExistedEmp(intEmpID)
    End Sub

    'Private Sub EmployeeTab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EmployeeTab.SelectedIndexChanged
    '    Select Case EmployeeTab.SelectedTab.Name
    '        Case tbPositionNLevel.Name
    '            If Not cboEmp.DataSource Is Nothing Then
    '                egridPosition.LoadAndDisplayData("tblEmpPositionHistory", cboEmp.SelectedItem("ID"))
    '            End If

    '    End Select
    'End Sub




    ''Private tempEPH As Tblemppositionhistory ' used to hold 1 position when user First create a new employee (DO not have ID of new emp yet)

    ''Private Sub egridPosition_PendingFortblEmployees_ID_Created(ByVal eph As Tblemppositionhistory) Handles egridPosition.PendingFortblEmployees_ID_Created
    ''    'this event fire when user first created New Employee, 
    ''    'we do not have ID for tblEmployees yet
    ''    'but we have to let user a position to the pending new user
    ''    tempEPH = eph

    ''End Sub

    Private Sub egridPosition_RequestAddNewPosition() Handles egridPosition.RequestAddNewPosition
        fMain.ShowPositionsForm()
    End Sub



    Private Sub cmdBreadCrumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBreadCrumb.Click
        If Not dgMainCategory.ShowDialog(Me, lblBreadCrumb.Text) = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtMainCategoryID.Text = dgMainCategory.SelectedCategoryID
        lblBreadCrumb.Text = dgMainCategory.BreadCum

    End Sub


    Private Sub lblBreadCrumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBreadCrumb.Click

    End Sub

    Private Sub egridEmpLevelHistory_NewLevelHistoryCreated(ByVal intEmpID As Integer) Handles egridEmpLevelHistory.NewLevelHistoryCreated
        txtSalaryLevel.Text = egridEmpLevelHistory.CurrenLevel
        txtSalary.Text = egridEmpLevelHistory.CurrentSalary
    End Sub

    Private Sub dtDOB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDOB.ValueChanged
        Dim dtTempDOB As Date = dtDOB.Value
        Dim AgeToRetire As Integer = 60

        AgeToRetire += 1

        If dtTempDOB.Month >= 10 Then
            AgeToRetire += 1
        End If

        Dim yearRetire As Int16 = dtTempDOB.AddYears(AgeToRetire).Year

        'change to พศ if need

        If yearRetire < 2500 Then
            yearRetire += 543
        End If

        lblYearWillRetire.Text = String.Format("เกษียณในปี {0}", yearRetire)
    End Sub


    Private Sub txtSpouseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtSpouseName.Text.Length > 0 Then
            chkDivorce.Enabled = True
        Else
            chkDivorce.Checked = False
            chkDivorce.Enabled = False
        End If
    End Sub

    Private Sub cmdEmpImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmpImage.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.ClearData()
        Me.Hide()
    End Sub

   
End Class