<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmployeeTab = New System.Windows.Forms.TabControl()
        Me.tbPersonalData = New System.Windows.Forms.TabPage()
        Me.chkDivorce = New System.Windows.Forms.CheckBox()
        Me.chkSpouseAlive = New System.Windows.Forms.CheckBox()
        Me.chkMotherAlive = New System.Windows.Forms.CheckBox()
        Me.chkFatherAlive = New System.Windows.Forms.CheckBox()
        Me.txtSpouseName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMotherName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFatherName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblYearWillRetire = New System.Windows.Forms.Label()
        Me.cmdEditLevel = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblBreadCrumb = New System.Windows.Forms.Label()
        Me.cmdBreadCrumb = New System.Windows.Forms.Button()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlHidden = New System.Windows.Forms.Panel()
        Me.txtMainCategoryID = New System.Windows.Forms.TextBox()
        Me.cboEmp = New System.Windows.Forms.ComboBox()
        Me.Emp = New System.Windows.Forms.Label()
        Me.cmdEmpImage = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtNickName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtWorkLine = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSalaryLevel = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdAddNewEmployee = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPrefix = New System.Windows.Forms.ComboBox()
        Me.txtNameEn = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNationalID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPermission = New System.Windows.Forms.TabPage()
        Me.pnlPermission = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboPFieldWork = New System.Windows.Forms.ComboBox()
        Me.cboPInv = New System.Windows.Forms.ComboBox()
        Me.cboPAdmin = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboPAir = New System.Windows.Forms.ComboBox()
        Me.tbPosition = New System.Windows.Forms.TabPage()
        Me.tbLevel = New System.Windows.Forms.TabPage()
        Me.tbEducation = New System.Windows.Forms.TabPage()
        Me.tbFamily = New System.Windows.Forms.TabPage()
        Me.tbWorkLog = New System.Windows.Forms.TabPage()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.egridPosition = New STAir.ctrEmpPositionHistory()
        Me.egridEmpLevelHistory = New STAir.ctrEmpLevelHistory()
        Me.egridEmpEduHistory = New STAir.ctrEmpEducationHistory()
        Me.egridEmpKids = New STAir.ctrEmployeeKids()
        Me.egridWorkLog = New STAir.ctrPersonalWorkLog()
        Me.EmployeeTab.SuspendLayout()
        Me.tbPersonalData.SuspendLayout()
        Me.pnlHidden.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPermission.SuspendLayout()
        Me.pnlPermission.SuspendLayout()
        Me.tbPosition.SuspendLayout()
        Me.tbLevel.SuspendLayout()
        Me.tbEducation.SuspendLayout()
        Me.tbFamily.SuspendLayout()
        Me.tbWorkLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(421, 487)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(112, 35)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(541, 487)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 35)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(189, 77)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(391, 26)
        Me.txtEmployeeID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 83)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "เลขประจำตัว ทสค."
        '
        'EmployeeTab
        '
        Me.EmployeeTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmployeeTab.Controls.Add(Me.tbPersonalData)
        Me.EmployeeTab.Controls.Add(Me.tbPermission)
        Me.EmployeeTab.Controls.Add(Me.tbPosition)
        Me.EmployeeTab.Controls.Add(Me.tbLevel)
        Me.EmployeeTab.Controls.Add(Me.tbEducation)
        Me.EmployeeTab.Controls.Add(Me.tbFamily)
        Me.EmployeeTab.Controls.Add(Me.tbWorkLog)
        Me.EmployeeTab.Location = New System.Drawing.Point(18, 18)
        Me.EmployeeTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EmployeeTab.Name = "EmployeeTab"
        Me.EmployeeTab.SelectedIndex = 0
        Me.EmployeeTab.Size = New System.Drawing.Size(1276, 750)
        Me.EmployeeTab.TabIndex = 13
        '
        'tbPersonalData
        '
        Me.tbPersonalData.AutoScroll = True
        Me.tbPersonalData.Controls.Add(Me.chkDivorce)
        Me.tbPersonalData.Controls.Add(Me.cmdCancel)
        Me.tbPersonalData.Controls.Add(Me.chkSpouseAlive)
        Me.tbPersonalData.Controls.Add(Me.cmdSave)
        Me.tbPersonalData.Controls.Add(Me.chkMotherAlive)
        Me.tbPersonalData.Controls.Add(Me.chkFatherAlive)
        Me.tbPersonalData.Controls.Add(Me.txtSpouseName)
        Me.tbPersonalData.Controls.Add(Me.Label13)
        Me.tbPersonalData.Controls.Add(Me.txtMotherName)
        Me.tbPersonalData.Controls.Add(Me.Label7)
        Me.tbPersonalData.Controls.Add(Me.txtFatherName)
        Me.tbPersonalData.Controls.Add(Me.Label12)
        Me.tbPersonalData.Controls.Add(Me.lblYearWillRetire)
        Me.tbPersonalData.Controls.Add(Me.cmdEditLevel)
        Me.tbPersonalData.Controls.Add(Me.lblBreadCrumb)
        Me.tbPersonalData.Controls.Add(Me.cmdBreadCrumb)
        Me.tbPersonalData.Controls.Add(Me.txtPosition)
        Me.tbPersonalData.Controls.Add(Me.txtPassword)
        Me.tbPersonalData.Controls.Add(Me.Label2)
        Me.tbPersonalData.Controls.Add(Me.pnlHidden)
        Me.tbPersonalData.Controls.Add(Me.cmdEmpImage)
        Me.tbPersonalData.Controls.Add(Me.Label20)
        Me.tbPersonalData.Controls.Add(Me.PictureBox1)
        Me.tbPersonalData.Controls.Add(Me.txtNickName)
        Me.tbPersonalData.Controls.Add(Me.Label19)
        Me.tbPersonalData.Controls.Add(Me.txtEmail)
        Me.tbPersonalData.Controls.Add(Me.Label18)
        Me.tbPersonalData.Controls.Add(Me.txtMobile)
        Me.tbPersonalData.Controls.Add(Me.Label17)
        Me.tbPersonalData.Controls.Add(Me.dtDOB)
        Me.tbPersonalData.Controls.Add(Me.txtAddress)
        Me.tbPersonalData.Controls.Add(Me.Label16)
        Me.tbPersonalData.Controls.Add(Me.Label11)
        Me.tbPersonalData.Controls.Add(Me.txtSalary)
        Me.tbPersonalData.Controls.Add(Me.Label10)
        Me.tbPersonalData.Controls.Add(Me.txtWorkLine)
        Me.tbPersonalData.Controls.Add(Me.Label9)
        Me.tbPersonalData.Controls.Add(Me.txtSalaryLevel)
        Me.tbPersonalData.Controls.Add(Me.Label8)
        Me.tbPersonalData.Controls.Add(Me.cmdAddNewEmployee)
        Me.tbPersonalData.Controls.Add(Me.Label6)
        Me.tbPersonalData.Controls.Add(Me.cboPrefix)
        Me.tbPersonalData.Controls.Add(Me.txtNameEn)
        Me.tbPersonalData.Controls.Add(Me.Label4)
        Me.tbPersonalData.Controls.Add(Me.txtName)
        Me.tbPersonalData.Controls.Add(Me.Label5)
        Me.tbPersonalData.Controls.Add(Me.txtNationalID)
        Me.tbPersonalData.Controls.Add(Me.Label3)
        Me.tbPersonalData.Controls.Add(Me.txtEmployeeID)
        Me.tbPersonalData.Controls.Add(Me.Label1)
        Me.tbPersonalData.Location = New System.Drawing.Point(4, 29)
        Me.tbPersonalData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbPersonalData.Name = "tbPersonalData"
        Me.tbPersonalData.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbPersonalData.Size = New System.Drawing.Size(1268, 717)
        Me.tbPersonalData.TabIndex = 0
        Me.tbPersonalData.Text = "ข้อมูลทั่วไป"
        Me.tbPersonalData.UseVisualStyleBackColor = True
        '
        'chkDivorce
        '
        Me.chkDivorce.AutoSize = True
        Me.chkDivorce.Checked = True
        Me.chkDivorce.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDivorce.Location = New System.Drawing.Point(541, 412)
        Me.chkDivorce.Name = "chkDivorce"
        Me.chkDivorce.Size = New System.Drawing.Size(73, 24)
        Me.chkDivorce.TabIndex = 114
        Me.chkDivorce.Text = "หย่าร้าง"
        Me.chkDivorce.UseVisualStyleBackColor = True
        '
        'chkSpouseAlive
        '
        Me.chkSpouseAlive.AutoSize = True
        Me.chkSpouseAlive.Checked = True
        Me.chkSpouseAlive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSpouseAlive.Location = New System.Drawing.Point(462, 411)
        Me.chkSpouseAlive.Name = "chkSpouseAlive"
        Me.chkSpouseAlive.Size = New System.Drawing.Size(79, 24)
        Me.chkSpouseAlive.TabIndex = 113
        Me.chkSpouseAlive.Text = "มีชีวิตอยู่"
        Me.chkSpouseAlive.UseVisualStyleBackColor = True
        '
        'chkMotherAlive
        '
        Me.chkMotherAlive.AutoSize = True
        Me.chkMotherAlive.Checked = True
        Me.chkMotherAlive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMotherAlive.Location = New System.Drawing.Point(462, 375)
        Me.chkMotherAlive.Name = "chkMotherAlive"
        Me.chkMotherAlive.Size = New System.Drawing.Size(79, 24)
        Me.chkMotherAlive.TabIndex = 112
        Me.chkMotherAlive.Text = "มีชีวิตอยู่"
        Me.chkMotherAlive.UseVisualStyleBackColor = True
        '
        'chkFatherAlive
        '
        Me.chkFatherAlive.AutoSize = True
        Me.chkFatherAlive.Checked = True
        Me.chkFatherAlive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFatherAlive.Location = New System.Drawing.Point(462, 340)
        Me.chkFatherAlive.Name = "chkFatherAlive"
        Me.chkFatherAlive.Size = New System.Drawing.Size(79, 24)
        Me.chkFatherAlive.TabIndex = 111
        Me.chkFatherAlive.Text = "มีชีวิตอยู่"
        Me.chkFatherAlive.UseVisualStyleBackColor = True
        '
        'txtSpouseName
        '
        Me.txtSpouseName.Location = New System.Drawing.Point(189, 409)
        Me.txtSpouseName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSpouseName.Name = "txtSpouseName"
        Me.txtSpouseName.Size = New System.Drawing.Size(266, 26)
        Me.txtSpouseName.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(102, 412)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 20)
        Me.Label13.TabIndex = 110
        Me.Label13.Text = "ชื่อคู่สมรส"
        '
        'txtMotherName
        '
        Me.txtMotherName.Location = New System.Drawing.Point(189, 373)
        Me.txtMotherName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMotherName.Name = "txtMotherName"
        Me.txtMotherName.Size = New System.Drawing.Size(266, 26)
        Me.txtMotherName.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(104, 376)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "ชื่อมารดา"
        '
        'txtFatherName
        '
        Me.txtFatherName.Location = New System.Drawing.Point(189, 341)
        Me.txtFatherName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFatherName.Name = "txtFatherName"
        Me.txtFatherName.Size = New System.Drawing.Size(266, 26)
        Me.txtFatherName.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(119, 344)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 20)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "ชื่อบิดา"
        '
        'lblYearWillRetire
        '
        Me.lblYearWillRetire.AutoSize = True
        Me.lblYearWillRetire.Location = New System.Drawing.Point(1040, 215)
        Me.lblYearWillRetire.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYearWillRetire.Name = "lblYearWillRetire"
        Me.lblYearWillRetire.Size = New System.Drawing.Size(78, 20)
        Me.lblYearWillRetire.TabIndex = 104
        Me.lblYearWillRetire.Text = "เกษียณในปี"
        '
        'cmdEditLevel
        '
        Me.cmdEditLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditLevel.ImageIndex = 1
        Me.cmdEditLevel.ImageList = Me.ImageList1
        Me.cmdEditLevel.Location = New System.Drawing.Point(541, 210)
        Me.cmdEditLevel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdEditLevel.Name = "cmdEditLevel"
        Me.cmdEditLevel.Size = New System.Drawing.Size(38, 35)
        Me.cmdEditLevel.TabIndex = 103
        Me.cmdEditLevel.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList1.Images.SetKeyName(1, "Actions-user-properties-icon.png")
        '
        'lblBreadCrumb
        '
        Me.lblBreadCrumb.AutoSize = True
        Me.lblBreadCrumb.Location = New System.Drawing.Point(195, 40)
        Me.lblBreadCrumb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBreadCrumb.Name = "lblBreadCrumb"
        Me.lblBreadCrumb.Size = New System.Drawing.Size(96, 20)
        Me.lblBreadCrumb.TabIndex = 102
        Me.lblBreadCrumb.Text = "กรุณาใส่ สังกัด"
        '
        'cmdBreadCrumb
        '
        Me.cmdBreadCrumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBreadCrumb.Location = New System.Drawing.Point(51, 32)
        Me.cmdBreadCrumb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBreadCrumb.Name = "cmdBreadCrumb"
        Me.cmdBreadCrumb.Size = New System.Drawing.Size(128, 35)
        Me.cmdBreadCrumb.TabIndex = 0
        Me.cmdBreadCrumb.Text = "สังกัด"
        Me.cmdBreadCrumb.UseVisualStyleBackColor = True
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(189, 175)
        Me.txtPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.txtPosition.Size = New System.Drawing.Size(344, 26)
        Me.txtPosition.TabIndex = 100
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(189, 142)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(391, 26)
        Me.txtPassword.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 148)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "รหัสผ่าน"
        '
        'pnlHidden
        '
        Me.pnlHidden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHidden.Controls.Add(Me.txtMainCategoryID)
        Me.pnlHidden.Controls.Add(Me.cboEmp)
        Me.pnlHidden.Controls.Add(Me.Emp)
        Me.pnlHidden.Location = New System.Drawing.Point(866, 602)
        Me.pnlHidden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlHidden.Name = "pnlHidden"
        Me.pnlHidden.Size = New System.Drawing.Size(390, 71)
        Me.pnlHidden.TabIndex = 97
        Me.pnlHidden.Visible = False
        '
        'txtMainCategoryID
        '
        Me.txtMainCategoryID.Enabled = False
        Me.txtMainCategoryID.Location = New System.Drawing.Point(285, 25)
        Me.txtMainCategoryID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMainCategoryID.Name = "txtMainCategoryID"
        Me.txtMainCategoryID.Size = New System.Drawing.Size(85, 26)
        Me.txtMainCategoryID.TabIndex = 102
        '
        'cboEmp
        '
        Me.cboEmp.FormattingEnabled = True
        Me.cboEmp.Location = New System.Drawing.Point(70, 23)
        Me.cboEmp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboEmp.Name = "cboEmp"
        Me.cboEmp.Size = New System.Drawing.Size(134, 28)
        Me.cboEmp.TabIndex = 101
        '
        'Emp
        '
        Me.Emp.AutoSize = True
        Me.Emp.Location = New System.Drawing.Point(34, 28)
        Me.Emp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Emp.Name = "Emp"
        Me.Emp.Size = New System.Drawing.Size(26, 20)
        Me.Emp.TabIndex = 98
        Me.Emp.Text = "ID"
        '
        'cmdEmpImage
        '
        Me.cmdEmpImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEmpImage.ImageIndex = 1
        Me.cmdEmpImage.ImageList = Me.ImageList1
        Me.cmdEmpImage.Location = New System.Drawing.Point(140, 455)
        Me.cmdEmpImage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdEmpImage.Name = "cmdEmpImage"
        Me.cmdEmpImage.Size = New System.Drawing.Size(38, 35)
        Me.cmdEmpImage.TabIndex = 94
        Me.cmdEmpImage.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(73, 463)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 20)
        Me.Label20.TabIndex = 93
        Me.Label20.Text = "รูปถ่าย"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Enabled = False
        Me.PictureBox1.Location = New System.Drawing.Point(188, 455)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(204, 207)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 92
        Me.PictureBox1.TabStop = False
        '
        'txtNickName
        '
        Me.txtNickName.Location = New System.Drawing.Point(766, 142)
        Me.txtNickName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNickName.Name = "txtNickName"
        Me.txtNickName.Size = New System.Drawing.Size(266, 26)
        Me.txtNickName.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(698, 148)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 20)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "ชื่อเล่น"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(766, 250)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(266, 26)
        Me.txtEmail.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(706, 250)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 20)
        Me.Label18.TabIndex = 86
        Me.Label18.Text = "อีเมล์"
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(766, 286)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(391, 26)
        Me.txtMobile.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(628, 289)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 20)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "หมายเลขโทรศัพท์"
        '
        'dtDOB
        '
        Me.dtDOB.Location = New System.Drawing.Point(766, 210)
        Me.dtDOB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.Size = New System.Drawing.Size(266, 26)
        Me.dtDOB.TabIndex = 9
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(188, 250)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(391, 83)
        Me.txtAddress.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(92, 254)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 20)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "ที่อยู่ปัจจุบัน"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(657, 219)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 20)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "วันเดือนปีเกิด"
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(376, 214)
        Me.txtSalary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.ReadOnly = True
        Me.txtSalary.Size = New System.Drawing.Size(157, 26)
        Me.txtSalary.TabIndex = 66
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(280, 220)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 20)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "อัตราเงินเดือน"
        '
        'txtWorkLine
        '
        Me.txtWorkLine.Location = New System.Drawing.Point(766, 177)
        Me.txtWorkLine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtWorkLine.Name = "txtWorkLine"
        Me.txtWorkLine.Size = New System.Drawing.Size(267, 26)
        Me.txtWorkLine.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(692, 183)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 20)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "สายงาน"
        '
        'txtSalaryLevel
        '
        Me.txtSalaryLevel.Location = New System.Drawing.Point(189, 214)
        Me.txtSalaryLevel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSalaryLevel.Name = "txtSalaryLevel"
        Me.txtSalaryLevel.ReadOnly = True
        Me.txtSalaryLevel.Size = New System.Drawing.Size(85, 26)
        Me.txtSalaryLevel.TabIndex = 62
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(136, 220)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 20)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "ระดับ"
        '
        'cmdAddNewEmployee
        '
        Me.cmdAddNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNewEmployee.ImageIndex = 1
        Me.cmdAddNewEmployee.ImageList = Me.ImageList1
        Me.cmdAddNewEmployee.Location = New System.Drawing.Point(541, 171)
        Me.cmdAddNewEmployee.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddNewEmployee.Name = "cmdAddNewEmployee"
        Me.cmdAddNewEmployee.Size = New System.Drawing.Size(38, 35)
        Me.cmdAddNewEmployee.TabIndex = 58
        Me.cmdAddNewEmployee.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(114, 181)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "ตำแหน่ง"
        '
        'cboPrefix
        '
        Me.cboPrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrefix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPrefix.FormattingEnabled = True
        Me.cboPrefix.Location = New System.Drawing.Point(189, 107)
        Me.cboPrefix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPrefix.Name = "cboPrefix"
        Me.cboPrefix.Size = New System.Drawing.Size(142, 28)
        Me.cboPrefix.TabIndex = 3
        '
        'txtNameEn
        '
        Me.txtNameEn.Location = New System.Drawing.Point(766, 109)
        Me.txtNameEn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNameEn.Name = "txtNameEn"
        Me.txtNameEn.Size = New System.Drawing.Size(266, 26)
        Me.txtNameEn.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(647, 115)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "ชื่อภาษาอังกฤษ"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(342, 109)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(238, 26)
        Me.txtName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(112, 115)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "ชื่อ - สกุล"
        '
        'txtNationalID
        '
        Me.txtNationalID.Location = New System.Drawing.Point(766, 77)
        Me.txtNationalID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNationalID.Name = "txtNationalID"
        Me.txtNationalID.Size = New System.Drawing.Size(266, 26)
        Me.txtNationalID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(633, 83)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "เลขบัตรประชาชน"
        '
        'tbPermission
        '
        Me.tbPermission.Controls.Add(Me.pnlPermission)
        Me.tbPermission.Location = New System.Drawing.Point(4, 29)
        Me.tbPermission.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbPermission.Name = "tbPermission"
        Me.tbPermission.Size = New System.Drawing.Size(1268, 717)
        Me.tbPermission.TabIndex = 4
        Me.tbPermission.Text = "สิทธิการใช้โปรแกรม"
        Me.tbPermission.UseVisualStyleBackColor = True
        '
        'pnlPermission
        '
        Me.pnlPermission.Controls.Add(Me.Label14)
        Me.pnlPermission.Controls.Add(Me.Label15)
        Me.pnlPermission.Controls.Add(Me.cboPFieldWork)
        Me.pnlPermission.Controls.Add(Me.cboPInv)
        Me.pnlPermission.Controls.Add(Me.cboPAdmin)
        Me.pnlPermission.Controls.Add(Me.Label28)
        Me.pnlPermission.Controls.Add(Me.Label27)
        Me.pnlPermission.Controls.Add(Me.cboPAir)
        Me.pnlPermission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPermission.Location = New System.Drawing.Point(0, 0)
        Me.pnlPermission.Name = "pnlPermission"
        Me.pnlPermission.Size = New System.Drawing.Size(1268, 724)
        Me.pnlPermission.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(137, 171)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(153, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "สิทธิการใช้งานระบบวัสดุ"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(102, 213)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 20)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "สิทธิการใช้งานระบบสารวัตร"
        '
        'cboPFieldWork
        '
        Me.cboPFieldWork.FormattingEnabled = True
        Me.cboPFieldWork.Location = New System.Drawing.Point(329, 210)
        Me.cboPFieldWork.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPFieldWork.Name = "cboPFieldWork"
        Me.cboPFieldWork.Size = New System.Drawing.Size(505, 28)
        Me.cboPFieldWork.TabIndex = 8
        '
        'cboPInv
        '
        Me.cboPInv.FormattingEnabled = True
        Me.cboPInv.Location = New System.Drawing.Point(329, 168)
        Me.cboPInv.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPInv.Name = "cboPInv"
        Me.cboPInv.Size = New System.Drawing.Size(505, 28)
        Me.cboPInv.TabIndex = 10
        '
        'cboPAdmin
        '
        Me.cboPAdmin.FormattingEnabled = True
        Me.cboPAdmin.Location = New System.Drawing.Point(329, 83)
        Me.cboPAdmin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPAdmin.Name = "cboPAdmin"
        Me.cboPAdmin.Size = New System.Drawing.Size(505, 28)
        Me.cboPAdmin.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(100, 83)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(190, 20)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "สิทธิการใช้งานแผนกสารบรรณ"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(133, 124)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(157, 20)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "สิทธิการใช้งานแผนกแอร์"
        '
        'cboPAir
        '
        Me.cboPAir.FormattingEnabled = True
        Me.cboPAir.Location = New System.Drawing.Point(329, 124)
        Me.cboPAir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPAir.Name = "cboPAir"
        Me.cboPAir.Size = New System.Drawing.Size(505, 28)
        Me.cboPAir.TabIndex = 6
        '
        'tbPosition
        '
        Me.tbPosition.Controls.Add(Me.egridPosition)
        Me.tbPosition.Location = New System.Drawing.Point(4, 29)
        Me.tbPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.Size = New System.Drawing.Size(1268, 717)
        Me.tbPosition.TabIndex = 3
        Me.tbPosition.Text = "ประวัติตำแหน่ง"
        Me.tbPosition.UseVisualStyleBackColor = True
        '
        'tbLevel
        '
        Me.tbLevel.Controls.Add(Me.egridEmpLevelHistory)
        Me.tbLevel.Location = New System.Drawing.Point(4, 29)
        Me.tbLevel.Name = "tbLevel"
        Me.tbLevel.Size = New System.Drawing.Size(1268, 717)
        Me.tbLevel.TabIndex = 5
        Me.tbLevel.Text = "ประวัติระดับ"
        Me.tbLevel.UseVisualStyleBackColor = True
        '
        'tbEducation
        '
        Me.tbEducation.Controls.Add(Me.egridEmpEduHistory)
        Me.tbEducation.Location = New System.Drawing.Point(4, 29)
        Me.tbEducation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbEducation.Name = "tbEducation"
        Me.tbEducation.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbEducation.Size = New System.Drawing.Size(1268, 717)
        Me.tbEducation.TabIndex = 1
        Me.tbEducation.Text = "การศึกษา"
        Me.tbEducation.UseVisualStyleBackColor = True
        '
        'tbFamily
        '
        Me.tbFamily.Controls.Add(Me.egridEmpKids)
        Me.tbFamily.Location = New System.Drawing.Point(4, 29)
        Me.tbFamily.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbFamily.Name = "tbFamily"
        Me.tbFamily.Size = New System.Drawing.Size(1268, 717)
        Me.tbFamily.TabIndex = 2
        Me.tbFamily.Text = "บุตร"
        Me.tbFamily.UseVisualStyleBackColor = True
        '
        'tbWorkLog
        '
        Me.tbWorkLog.Controls.Add(Me.egridWorkLog)
        Me.tbWorkLog.Location = New System.Drawing.Point(4, 29)
        Me.tbWorkLog.Name = "tbWorkLog"
        Me.tbWorkLog.Size = New System.Drawing.Size(1268, 717)
        Me.tbWorkLog.TabIndex = 6
        Me.tbWorkLog.Text = "บันทึกการทำงาน"
        Me.tbWorkLog.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'egridPosition
        '
        Me.egridPosition.AutoScroll = True
        Me.egridPosition.CurrenPositionID = 0
        Me.egridPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.egridPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.egridPosition.Location = New System.Drawing.Point(0, 0)
        Me.egridPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.egridPosition.Name = "egridPosition"
        Me.egridPosition.Size = New System.Drawing.Size(1268, 724)
        Me.egridPosition.TabIndex = 0
        '
        'egridEmpLevelHistory
        '
        Me.egridEmpLevelHistory.CurrenLevel = 0.0R
        Me.egridEmpLevelHistory.CurrentSalary = New Decimal(New Integer() {0, 0, 0, 0})
        Me.egridEmpLevelHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.egridEmpLevelHistory.Location = New System.Drawing.Point(0, 0)
        Me.egridEmpLevelHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.egridEmpLevelHistory.Name = "egridEmpLevelHistory"
        Me.egridEmpLevelHistory.Size = New System.Drawing.Size(1194, 752)
        Me.egridEmpLevelHistory.TabIndex = 0
        '
        'egridEmpEduHistory
        '
        Me.egridEmpEduHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.egridEmpEduHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.egridEmpEduHistory.Location = New System.Drawing.Point(4, 5)
        Me.egridEmpEduHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.egridEmpEduHistory.Name = "egridEmpEduHistory"
        Me.egridEmpEduHistory.Size = New System.Drawing.Size(1260, 714)
        Me.egridEmpEduHistory.TabIndex = 0
        '
        'egridEmpKids
        '
        Me.egridEmpKids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.egridEmpKids.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.egridEmpKids.Location = New System.Drawing.Point(0, 0)
        Me.egridEmpKids.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.egridEmpKids.Name = "egridEmpKids"
        Me.egridEmpKids.Size = New System.Drawing.Size(1268, 724)
        Me.egridEmpKids.TabIndex = 29
        '
        'egridWorkLog
        '
        Me.egridWorkLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.egridWorkLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.egridWorkLog.Location = New System.Drawing.Point(0, 0)
        Me.egridWorkLog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.egridWorkLog.Name = "egridWorkLog"
        Me.egridWorkLog.Size = New System.Drawing.Size(1268, 724)
        Me.egridWorkLog.TabIndex = 0
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1284, 782)
        Me.Controls.Add(Me.EmployeeTab)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAddUser"
        Me.Text = "พนักงาน"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.EmployeeTab.ResumeLayout(False)
        Me.tbPersonalData.ResumeLayout(False)
        Me.tbPersonalData.PerformLayout()
        Me.pnlHidden.ResumeLayout(False)
        Me.pnlHidden.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPermission.ResumeLayout(False)
        Me.pnlPermission.ResumeLayout(False)
        Me.pnlPermission.PerformLayout()
        Me.tbPosition.ResumeLayout(False)
        Me.tbLevel.ResumeLayout(False)
        Me.tbEducation.ResumeLayout(False)
        Me.tbFamily.ResumeLayout(False)
        Me.tbWorkLog.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmployeeTab As System.Windows.Forms.TabControl
    Friend WithEvents tbPersonalData As System.Windows.Forms.TabPage
    Friend WithEvents tbEducation As System.Windows.Forms.TabPage
    Friend WithEvents tbFamily As System.Windows.Forms.TabPage
    Friend WithEvents tbPosition As System.Windows.Forms.TabPage
    Friend WithEvents txtNameEn As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNationalID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbPermission As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPrefix As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSalary As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtWorkLine As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSalaryLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNewEmployee As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtNickName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHidden As System.Windows.Forms.Panel
    Friend WithEvents Emp As System.Windows.Forms.Label
    Friend WithEvents cmdEmpImage As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboPAir As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboPAdmin As System.Windows.Forms.ComboBox
    Friend WithEvents cboEmp As System.Windows.Forms.ComboBox
    Friend WithEvents egridPosition As STAir.ctrEmpPositionHistory
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblBreadCrumb As System.Windows.Forms.Label
    Friend WithEvents cmdBreadCrumb As System.Windows.Forms.Button
    Friend WithEvents txtMainCategoryID As System.Windows.Forms.TextBox
    Friend WithEvents cmdEditLevel As System.Windows.Forms.Button
    Friend WithEvents tbLevel As System.Windows.Forms.TabPage
    Friend WithEvents egridEmpLevelHistory As STAir.ctrEmpLevelHistory
    Friend WithEvents lblYearWillRetire As System.Windows.Forms.Label
    Friend WithEvents egridEmpEduHistory As STAir.ctrEmpEducationHistory
    Friend WithEvents egridEmpKids As STAir.ctrEmployeeKids
    Friend WithEvents chkDivorce As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpouseAlive As System.Windows.Forms.CheckBox
    Friend WithEvents chkMotherAlive As System.Windows.Forms.CheckBox
    Friend WithEvents chkFatherAlive As System.Windows.Forms.CheckBox
    Friend WithEvents txtSpouseName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMotherName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFatherName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbWorkLog As System.Windows.Forms.TabPage
    Friend WithEvents egridWorkLog As STAir.ctrPersonalWorkLog
    Friend WithEvents pnlPermission As System.Windows.Forms.Panel
    Friend WithEvents cboPFieldWork As System.Windows.Forms.ComboBox
    Friend WithEvents cboPInv As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
