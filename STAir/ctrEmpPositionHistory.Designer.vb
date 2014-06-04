<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrEmpPositionHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrEmpPositionHistory))
        Me.grdEmpPosHistory = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cboDateAssignedPosition = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdAddNewEmployee = New System.Windows.Forms.Button()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkIsCurrent = New System.Windows.Forms.CheckBox()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.chkResignDate = New System.Windows.Forms.CheckBox()
        Me.cboDateResign = New System.Windows.Forms.DateTimePicker()
        Me.cboAutoNote = New System.Windows.Forms.ComboBox()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSavingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdEmpPosHistory
        '
        Me.grdEmpPosHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpPosHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdEmpPosHistory.Location = New System.Drawing.Point(88, 370)
        Me.grdEmpPosHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdEmpPosHistory.Name = "grdEmpPosHistory"
        Me.grdEmpPosHistory.Size = New System.Drawing.Size(840, 158)
        Me.grdEmpPosHistory.TabIndex = 1
        Me.grdEmpPosHistory.Text = "ประวัติตำแหน่ง"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.ImageIndex = 2
        Me.cmdDelete.ImageList = Me.ImageList2
        Me.cmdDelete.Location = New System.Drawing.Point(490, 305)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(54, 55)
        Me.cmdDelete.TabIndex = 101
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Save-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Actions-list-remove-user-icon.png")
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.ImageIndex = 1
        Me.cmdSave.ImageList = Me.ImageList2
        Me.cmdSave.Location = New System.Drawing.Point(428, 305)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(54, 55)
        Me.cmdSave.TabIndex = 99
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cboDateAssignedPosition
        '
        Me.cboDateAssignedPosition.Location = New System.Drawing.Point(88, 122)
        Me.cboDateAssignedPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboDateAssignedPosition.Name = "cboDateAssignedPosition"
        Me.cboDateAssignedPosition.Size = New System.Drawing.Size(344, 26)
        Me.cboDateAssignedPosition.TabIndex = 106
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(34, 131)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 20)
        Me.Label22.TabIndex = 105
        Me.Label22.Text = "วันเที่"
        '
        'cmdAddNewEmployee
        '
        Me.cmdAddNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNewEmployee.ImageIndex = 0
        Me.cmdAddNewEmployee.ImageList = Me.ImageList2
        Me.cmdAddNewEmployee.Location = New System.Drawing.Point(444, 77)
        Me.cmdAddNewEmployee.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddNewEmployee.Name = "cmdAddNewEmployee"
        Me.cmdAddNewEmployee.Size = New System.Drawing.Size(38, 35)
        Me.cmdAddNewEmployee.TabIndex = 104
        Me.cmdAddNewEmployee.UseVisualStyleBackColor = False
        '
        'cboPosition
        '
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Location = New System.Drawing.Point(88, 80)
        Me.cboPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(344, 28)
        Me.cboPosition.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 85)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 20)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "ตำแหน่ง"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(88, 208)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(840, 82)
        Me.txtNote.TabIndex = 108
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 217)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 20)
        Me.Label17.TabIndex = 107
        Me.Label17.Text = "หมายเหตุ"
        '
        'chkIsCurrent
        '
        Me.chkIsCurrent.AutoSize = True
        Me.chkIsCurrent.Location = New System.Drawing.Point(88, 168)
        Me.chkIsCurrent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkIsCurrent.Name = "chkIsCurrent"
        Me.chkIsCurrent.Size = New System.Drawing.Size(145, 24)
        Me.chkIsCurrent.TabIndex = 109
        Me.chkIsCurrent.Text = "เป็นตำแหน่งปัจจุบัน"
        Me.chkIsCurrent.UseVisualStyleBackColor = True
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(88, 5)
        Me.gbSavingMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbSavingMode.Size = New System.Drawing.Size(639, 66)
        Me.gbSavingMode.TabIndex = 110
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(148, 25)
        Me.rblUpdateMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        Me.rblAddNewMode.Location = New System.Drawing.Point(332, 25)
        Me.rblAddNewMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(105, 17)
        Me.rblAddNewMode.TabIndex = 0
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มตำแหน่งใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'chkResignDate
        '
        Me.chkResignDate.AutoSize = True
        Me.chkResignDate.Location = New System.Drawing.Point(444, 126)
        Me.chkResignDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkResignDate.Name = "chkResignDate"
        Me.chkResignDate.Size = New System.Drawing.Size(127, 24)
        Me.chkResignDate.TabIndex = 111
        Me.chkResignDate.Text = "ออกจากตำแหน่ง"
        Me.chkResignDate.UseVisualStyleBackColor = True
        '
        'cboDateResign
        '
        Me.cboDateResign.Location = New System.Drawing.Point(744, 122)
        Me.cboDateResign.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboDateResign.Name = "cboDateResign"
        Me.cboDateResign.Size = New System.Drawing.Size(184, 26)
        Me.cboDateResign.TabIndex = 113
        Me.cboDateResign.Visible = False
        '
        'cboAutoNote
        '
        Me.cboAutoNote.FormattingEnabled = True
        Me.cboAutoNote.Items.AddRange(New Object() {"เลื่อนตำแหน่ง", "ลาออก", "เกษียณ", "ให้ออก", "พักงาน", "เสียชีวิต"})
        Me.cboAutoNote.Location = New System.Drawing.Point(567, 122)
        Me.cboAutoNote.Name = "cboAutoNote"
        Me.cboAutoNote.Size = New System.Drawing.Size(170, 28)
        Me.cboAutoNote.TabIndex = 114
        '
        'ctrEmpPositionHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboAutoNote)
        Me.Controls.Add(Me.cboDateResign)
        Me.Controls.Add(Me.chkResignDate)
        Me.Controls.Add(Me.gbSavingMode)
        Me.Controls.Add(Me.chkIsCurrent)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboDateAssignedPosition)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmdAddNewEmployee)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grdEmpPosHistory)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ctrEmpPositionHistory"
        Me.Size = New System.Drawing.Size(988, 555)
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdEmpPosHistory As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cboDateAssignedPosition As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNewEmployee As System.Windows.Forms.Button
    Friend WithEvents cboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkIsCurrent As System.Windows.Forms.CheckBox
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents chkResignDate As System.Windows.Forms.CheckBox
    Friend WithEvents cboDateResign As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboAutoNote As System.Windows.Forms.ComboBox

End Class
