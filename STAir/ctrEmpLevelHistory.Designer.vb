<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrEmpLevelHistory
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrEmpLevelHistory))
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.chkIsCurrent = New System.Windows.Forms.CheckBox()
        Me.cboDateAssignedPosition = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.cboDateResign = New System.Windows.Forms.DateTimePicker()
        Me.chkResignDate = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSalary = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txtNumLevel = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.grdEmpPosHistory = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gbSavingMode.SuspendLayout()
        CType(Me.txtSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(116, 28)
        Me.gbSavingMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.gbSavingMode.Size = New System.Drawing.Size(683, 93)
        Me.gbSavingMode.TabIndex = 125
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(151, 35)
        Me.rblUpdateMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.rblUpdateMode.Name = "rblUpdateMode"
        Me.rblUpdateMode.Size = New System.Drawing.Size(96, 17)
        Me.rblUpdateMode.TabIndex = 1
        Me.rblUpdateMode.TabStop = True
        Me.rblUpdateMode.Text = "แก้ไขข้อมูลเดิม"
        Me.rblUpdateMode.UseVisualStyleBackColor = True
        '
        'rblAddNewMode
        '
        Me.rblAddNewMode.AutoSize = True
        Me.rblAddNewMode.Checked = True
        Me.rblAddNewMode.Location = New System.Drawing.Point(381, 35)
        Me.rblAddNewMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(90, 17)
        Me.rblAddNewMode.TabIndex = 0
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มระดับใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'chkIsCurrent
        '
        Me.chkIsCurrent.AutoSize = True
        Me.chkIsCurrent.Location = New System.Drawing.Point(116, 217)
        Me.chkIsCurrent.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.chkIsCurrent.Name = "chkIsCurrent"
        Me.chkIsCurrent.Size = New System.Drawing.Size(127, 24)
        Me.chkIsCurrent.TabIndex = 124
        Me.chkIsCurrent.Text = "เป็นระดับปัจจุบัน"
        Me.chkIsCurrent.UseVisualStyleBackColor = True
        '
        'cboDateAssignedPosition
        '
        Me.cboDateAssignedPosition.Location = New System.Drawing.Point(116, 175)
        Me.cboDateAssignedPosition.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cboDateAssignedPosition.Name = "cboDateAssignedPosition"
        Me.cboDateAssignedPosition.Size = New System.Drawing.Size(200, 26)
        Me.cboDateAssignedPosition.TabIndex = 121
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(33, 178)
        Me.Label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 20)
        Me.Label22.TabIndex = 120
        Me.Label22.Text = "วันเที่"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Save-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Actions-list-remove-user-icon.png")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 138)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "ระดับ"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.ImageIndex = 2
        Me.cmdDelete.ImageList = Me.ImageList2
        Me.cmdDelete.Location = New System.Drawing.Point(394, 388)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 51)
        Me.cmdDelete.TabIndex = 116
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.ImageIndex = 1
        Me.cmdSave.ImageList = Me.ImageList2
        Me.cmdSave.Location = New System.Drawing.Point(325, 388)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(57, 51)
        Me.cmdSave.TabIndex = 115
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 257)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 20)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "หมายเหตุ"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(116, 257)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(635, 124)
        Me.txtNote.TabIndex = 123
        '
        'cboDateResign
        '
        Me.cboDateResign.Location = New System.Drawing.Point(473, 178)
        Me.cboDateResign.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cboDateResign.Name = "cboDateResign"
        Me.cboDateResign.Size = New System.Drawing.Size(278, 26)
        Me.cboDateResign.TabIndex = 127
        Me.cboDateResign.Visible = False
        '
        'chkResignDate
        '
        Me.chkResignDate.AutoSize = True
        Me.chkResignDate.Location = New System.Drawing.Point(354, 179)
        Me.chkResignDate.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.chkResignDate.Name = "chkResignDate"
        Me.chkResignDate.Size = New System.Drawing.Size(109, 24)
        Me.chkResignDate.TabIndex = 126
        Me.chkResignDate.Text = "ออกจากระดับ"
        Me.chkResignDate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(369, 138)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "อัตราเงินเดือน"
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(473, 134)
        Me.txtSalary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSalary.MaxValue = 1000000.0R
        Me.txtSalary.MinValue = 0.0R
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSalary.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtSalary.Size = New System.Drawing.Size(278, 21)
        Me.txtSalary.TabIndex = 130
        '
        'txtNumLevel
        '
        Me.txtNumLevel.Location = New System.Drawing.Point(116, 134)
        Me.txtNumLevel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumLevel.MaxValue = 100.0R
        Me.txtNumLevel.MinValue = 1
        Me.txtNumLevel.Name = "txtNumLevel"
        Me.txtNumLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtNumLevel.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtNumLevel.Size = New System.Drawing.Size(200, 21)
        Me.txtNumLevel.TabIndex = 128
        Me.txtNumLevel.Value = 1.0R
        '
        'grdEmpPosHistory
        '
        Me.grdEmpPosHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpPosHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdEmpPosHistory.Location = New System.Drawing.Point(24, 452)
        Me.grdEmpPosHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdEmpPosHistory.Name = "grdEmpPosHistory"
        Me.grdEmpPosHistory.Size = New System.Drawing.Size(775, 186)
        Me.grdEmpPosHistory.TabIndex = 131
        '
        'ctrEmpLevelHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grdEmpPosHistory)
        Me.Controls.Add(Me.txtSalary)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumLevel)
        Me.Controls.Add(Me.cboDateResign)
        Me.Controls.Add(Me.chkResignDate)
        Me.Controls.Add(Me.gbSavingMode)
        Me.Controls.Add(Me.chkIsCurrent)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboDateAssignedPosition)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ctrEmpLevelHistory"
        Me.Size = New System.Drawing.Size(817, 648)
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        CType(Me.txtSalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents chkIsCurrent As System.Windows.Forms.CheckBox
    Friend WithEvents cboDateAssignedPosition As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents cboDateResign As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkResignDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSalary As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtNumLevel As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents grdEmpPosHistory As Infragistics.Win.UltraWinGrid.UltraGrid

End Class
