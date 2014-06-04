<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosition
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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboPAir = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboPAdmin = New System.Windows.Forms.ComboBox()
        Me.txtPositionAbv = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPositionName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdPositions = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboPInv = New System.Windows.Forms.ComboBox()
        Me.cboPFieldWork = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grbPositionBudget = New System.Windows.Forms.GroupBox()
        Me.txtAccountNumber4 = New System.Windows.Forms.TextBox()
        Me.txtAccountNumber3 = New System.Windows.Forms.TextBox()
        Me.txtAccountNumber2 = New System.Windows.Forms.TextBox()
        Me.txtAccountNumber1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBudgetPercent4 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBudgetPercent3 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBudgetPercent2 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBudgetPercent1 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grbPositionBudget.SuspendLayout()
        CType(Me.txtBudgetPercent4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudgetPercent3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudgetPercent2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudgetPercent1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSavingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(36, 173)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(172, 17)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "สิทธิการใช้งานแผนกสารบรรณ"
        '
        'cboPAir
        '
        Me.cboPAir.FormattingEnabled = True
        Me.cboPAir.Location = New System.Drawing.Point(248, 203)
        Me.cboPAir.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPAir.Name = "cboPAir"
        Me.cboPAir.Size = New System.Drawing.Size(340, 24)
        Me.cboPAir.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(69, 206)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(141, 17)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "สิทธิการใช้งานแผนกแอร์"
        '
        'cboPAdmin
        '
        Me.cboPAdmin.FormattingEnabled = True
        Me.cboPAdmin.Location = New System.Drawing.Point(248, 170)
        Me.cboPAdmin.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPAdmin.Name = "cboPAdmin"
        Me.cboPAdmin.Size = New System.Drawing.Size(340, 24)
        Me.cboPAdmin.TabIndex = 2
        '
        'txtPositionAbv
        '
        Me.txtPositionAbv.Location = New System.Drawing.Point(248, 139)
        Me.txtPositionAbv.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPositionAbv.Name = "txtPositionAbv"
        Me.txtPositionAbv.Size = New System.Drawing.Size(340, 23)
        Me.txtPositionAbv.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "ตัวย่อตำแหน่ง"
        '
        'txtPositionName
        '
        Me.txtPositionName.Location = New System.Drawing.Point(248, 107)
        Me.txtPositionName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPositionName.Name = "txtPositionName"
        Me.txtPositionName.Size = New System.Drawing.Size(340, 23)
        Me.txtPositionName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 107)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "ชื่อตำแหน่ง"
        '
        'grdPositions
        '
        Me.grdPositions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdPositions.Location = New System.Drawing.Point(16, 15)
        Me.grdPositions.Margin = New System.Windows.Forms.Padding(4)
        Me.grdPositions.Name = "grdPositions"
        Me.grdPositions.Size = New System.Drawing.Size(363, 537)
        Me.grdPositions.TabIndex = 23
        Me.grdPositions.Text = "ตำแหน่งในระบบ"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(597, 573)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 28)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(708, 573)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(113, 28)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboPInv)
        Me.Panel1.Controls.Add(Me.cboPFieldWork)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.grbPositionBudget)
        Me.Panel1.Controls.Add(Me.gbSavingMode)
        Me.Panel1.Controls.Add(Me.cboPAir)
        Me.Panel1.Controls.Add(Me.cboPAdmin)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtPositionAbv)
        Me.Panel1.Controls.Add(Me.txtPositionName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(387, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(645, 537)
        Me.Panel1.TabIndex = 27
        '
        'cboPInv
        '
        Me.cboPInv.FormattingEnabled = True
        Me.cboPInv.Location = New System.Drawing.Point(248, 238)
        Me.cboPInv.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPInv.Name = "cboPInv"
        Me.cboPInv.Size = New System.Drawing.Size(340, 24)
        Me.cboPInv.TabIndex = 4
        '
        'cboPFieldWork
        '
        Me.cboPFieldWork.FormattingEnabled = True
        Me.cboPFieldWork.Location = New System.Drawing.Point(248, 272)
        Me.cboPFieldWork.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPFieldWork.Name = "cboPFieldWork"
        Me.cboPFieldWork.Size = New System.Drawing.Size(340, 24)
        Me.cboPFieldWork.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(69, 242)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 17)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "สิทธิการใช้งานระบบวัสดุ"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(36, 275)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(167, 17)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "สิทธิการใช้งานระบบภาคสนาม"
        '
        'grbPositionBudget
        '
        Me.grbPositionBudget.Controls.Add(Me.txtAccountNumber4)
        Me.grbPositionBudget.Controls.Add(Me.txtAccountNumber3)
        Me.grbPositionBudget.Controls.Add(Me.txtAccountNumber2)
        Me.grbPositionBudget.Controls.Add(Me.txtAccountNumber1)
        Me.grbPositionBudget.Controls.Add(Me.Label9)
        Me.grbPositionBudget.Controls.Add(Me.txtBudgetPercent4)
        Me.grbPositionBudget.Controls.Add(Me.Label10)
        Me.grbPositionBudget.Controls.Add(Me.Label7)
        Me.grbPositionBudget.Controls.Add(Me.txtBudgetPercent3)
        Me.grbPositionBudget.Controls.Add(Me.Label8)
        Me.grbPositionBudget.Controls.Add(Me.Label5)
        Me.grbPositionBudget.Controls.Add(Me.txtBudgetPercent2)
        Me.grbPositionBudget.Controls.Add(Me.Label6)
        Me.grbPositionBudget.Controls.Add(Me.Label2)
        Me.grbPositionBudget.Controls.Add(Me.txtBudgetPercent1)
        Me.grbPositionBudget.Controls.Add(Me.Label1)
        Me.grbPositionBudget.Location = New System.Drawing.Point(26, 329)
        Me.grbPositionBudget.Margin = New System.Windows.Forms.Padding(4)
        Me.grbPositionBudget.Name = "grbPositionBudget"
        Me.grbPositionBudget.Padding = New System.Windows.Forms.Padding(4)
        Me.grbPositionBudget.Size = New System.Drawing.Size(582, 192)
        Me.grbPositionBudget.TabIndex = 27
        Me.grbPositionBudget.TabStop = False
        Me.grbPositionBudget.Text = "ใช้เงินจากบัญชี"
        '
        'txtAccountNumber4
        '
        Me.txtAccountNumber4.Location = New System.Drawing.Point(122, 148)
        Me.txtAccountNumber4.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccountNumber4.Name = "txtAccountNumber4"
        Me.txtAccountNumber4.Size = New System.Drawing.Size(215, 23)
        Me.txtAccountNumber4.TabIndex = 6
        '
        'txtAccountNumber3
        '
        Me.txtAccountNumber3.Location = New System.Drawing.Point(122, 108)
        Me.txtAccountNumber3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccountNumber3.Name = "txtAccountNumber3"
        Me.txtAccountNumber3.Size = New System.Drawing.Size(215, 23)
        Me.txtAccountNumber3.TabIndex = 4
        '
        'txtAccountNumber2
        '
        Me.txtAccountNumber2.Location = New System.Drawing.Point(122, 70)
        Me.txtAccountNumber2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccountNumber2.Name = "txtAccountNumber2"
        Me.txtAccountNumber2.Size = New System.Drawing.Size(215, 23)
        Me.txtAccountNumber2.TabIndex = 2
        '
        'txtAccountNumber1
        '
        Me.txtAccountNumber1.Location = New System.Drawing.Point(122, 36)
        Me.txtAccountNumber1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccountNumber1.Name = "txtAccountNumber1"
        Me.txtAccountNumber1.Size = New System.Drawing.Size(215, 23)
        Me.txtAccountNumber1.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(346, 150)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "จำนวน ร้อยละ"
        '
        'txtBudgetPercent4
        '
        Me.txtBudgetPercent4.Location = New System.Drawing.Point(453, 146)
        Me.txtBudgetPercent4.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtBudgetPercent4.MaxValue = 100
        Me.txtBudgetPercent4.MinValue = 0
        Me.txtBudgetPercent4.Name = "txtBudgetPercent4"
        Me.txtBudgetPercent4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBudgetPercent4.Size = New System.Drawing.Size(108, 21)
        Me.txtBudgetPercent4.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(46, 150)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 17)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "บัญชีเลขที่"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(346, 112)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 17)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "จำนวน ร้อยละ"
        '
        'txtBudgetPercent3
        '
        Me.txtBudgetPercent3.Location = New System.Drawing.Point(453, 108)
        Me.txtBudgetPercent3.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtBudgetPercent3.MaxValue = 100
        Me.txtBudgetPercent3.MinValue = 0
        Me.txtBudgetPercent3.Name = "txtBudgetPercent3"
        Me.txtBudgetPercent3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBudgetPercent3.Size = New System.Drawing.Size(108, 21)
        Me.txtBudgetPercent3.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(46, 112)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "บัญชีเลขที่"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(346, 74)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 142
        Me.Label5.Text = "จำนวน ร้อยละ"
        '
        'txtBudgetPercent2
        '
        Me.txtBudgetPercent2.Location = New System.Drawing.Point(453, 70)
        Me.txtBudgetPercent2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtBudgetPercent2.MaxValue = 100
        Me.txtBudgetPercent2.MinValue = 0
        Me.txtBudgetPercent2.Name = "txtBudgetPercent2"
        Me.txtBudgetPercent2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBudgetPercent2.Size = New System.Drawing.Size(108, 21)
        Me.txtBudgetPercent2.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 74)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 17)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "บัญชีเลขที่"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(346, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "จำนวน ร้อยละ"
        '
        'txtBudgetPercent1
        '
        Me.txtBudgetPercent1.Location = New System.Drawing.Point(453, 32)
        Me.txtBudgetPercent1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtBudgetPercent1.MaxValue = 100
        Me.txtBudgetPercent1.MinValue = 0
        Me.txtBudgetPercent1.Name = "txtBudgetPercent1"
        Me.txtBudgetPercent1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBudgetPercent1.Size = New System.Drawing.Size(108, 21)
        Me.txtBudgetPercent1.TabIndex = 1
        Me.txtBudgetPercent1.Value = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "บัญชีเลขที่"
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(147, 20)
        Me.gbSavingMode.Margin = New System.Windows.Forms.Padding(4)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Padding = New System.Windows.Forms.Padding(4)
        Me.gbSavingMode.Size = New System.Drawing.Size(441, 75)
        Me.gbSavingMode.TabIndex = 23
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(78, 34)
        Me.rblUpdateMode.Margin = New System.Windows.Forms.Padding(4)
        Me.rblUpdateMode.Name = "rblUpdateMode"
        Me.rblUpdateMode.Size = New System.Drawing.Size(96, 17)
        Me.rblUpdateMode.TabIndex = 0
        Me.rblUpdateMode.TabStop = True
        Me.rblUpdateMode.Text = "แก้ไขข้อมูลเดิม"
        Me.rblUpdateMode.UseVisualStyleBackColor = True
        '
        'rblAddNewMode
        '
        Me.rblAddNewMode.AutoSize = True
        Me.rblAddNewMode.Checked = True
        Me.rblAddNewMode.Location = New System.Drawing.Point(241, 34)
        Me.rblAddNewMode.Margin = New System.Windows.Forms.Padding(4)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(105, 17)
        Me.rblAddNewMode.TabIndex = 1
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มตำแหน่งใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'frmPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 614)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grdPositions)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPosition"
        Me.Text = "ตั้งค่าตำแหน่ง"
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbPositionBudget.ResumeLayout(False)
        Me.grbPositionBudget.PerformLayout()
        CType(Me.txtBudgetPercent4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudgetPercent3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudgetPercent2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudgetPercent1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboPAir As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboPAdmin As System.Windows.Forms.ComboBox
    Friend WithEvents txtPositionAbv As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPositionName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdPositions As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents grbPositionBudget As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetPercent1 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetPercent4 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetPercent3 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetPercent2 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNumber3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents cboPInv As System.Windows.Forms.ComboBox
    Friend WithEvents cboPFieldWork As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
