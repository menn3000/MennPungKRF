<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoliday
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
        Me.grdHoliday = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHolidayName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtYearDisplay = New System.Windows.Forms.DateTimePicker()
        CType(Me.grdHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbSavingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdHoliday
        '
        Me.grdHoliday.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdHoliday.Location = New System.Drawing.Point(12, 55)
        Me.grdHoliday.Name = "grdHoliday"
        Me.grdHoliday.Size = New System.Drawing.Size(363, 435)
        Me.grdHoliday.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdDelete)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.dtToDate)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.dtFromDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.gbSavingMode)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtHolidayName)
        Me.Panel1.Location = New System.Drawing.Point(407, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 377)
        Me.Panel1.TabIndex = 32
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(217, 243)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 116
        Me.cmdDelete.Text = "ลบ"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(260, 205)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(85, 23)
        Me.cmdSave.TabIndex = 115
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(179, 205)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 114
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'dtToDate
        '
        Me.dtToDate.Location = New System.Drawing.Point(298, 83)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(169, 20)
        Me.dtToDate.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(273, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "ถึง"
        '
        'dtFromDate
        '
        Me.dtFromDate.Location = New System.Drawing.Point(98, 83)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(169, 20)
        Me.dtFromDate.TabIndex = 111
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "วันที่"
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(22, 16)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Size = New System.Drawing.Size(445, 61)
        Me.gbSavingMode.TabIndex = 23
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(108, 28)
        Me.rblUpdateMode.Name = "rblUpdateMode"
        Me.rblUpdateMode.Size = New System.Drawing.Size(96, 17)
        Me.rblUpdateMode.TabIndex = 1
        Me.rblUpdateMode.Text = "แก้ไขข้อมูลเดิม"
        Me.rblUpdateMode.UseVisualStyleBackColor = True
        '
        'rblAddNewMode
        '
        Me.rblAddNewMode.AutoSize = True
        Me.rblAddNewMode.Checked = True
        Me.rblAddNewMode.Location = New System.Drawing.Point(272, 28)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(45, 17)
        Me.rblAddNewMode.TabIndex = 0
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่ม"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "ชื่อวันหยุด"
        '
        'txtHolidayName
        '
        Me.txtHolidayName.Location = New System.Drawing.Point(98, 112)
        Me.txtHolidayName.Name = "txtHolidayName"
        Me.txtHolidayName.Size = New System.Drawing.Size(369, 20)
        Me.txtHolidayName.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "ปี"
        '
        'dtYearDisplay
        '
        Me.dtYearDisplay.CustomFormat = "yyyy"
        Me.dtYearDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtYearDisplay.Location = New System.Drawing.Point(32, 28)
        Me.dtYearDisplay.Name = "dtYearDisplay"
        Me.dtYearDisplay.ShowUpDown = True
        Me.dtYearDisplay.Size = New System.Drawing.Size(169, 20)
        Me.dtYearDisplay.TabIndex = 112
        '
        'frmHoliday
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 522)
        Me.Controls.Add(Me.dtYearDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdHoliday)
        Me.Name = "frmHoliday"
        Me.Text = "วันหยุดประจำปี"
        CType(Me.grdHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdHoliday As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHolidayName As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents dtYearDisplay As System.Windows.Forms.DateTimePicker
End Class
