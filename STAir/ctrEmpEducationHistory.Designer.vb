<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrEmpEducationHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrEmpEducationHistory))
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.grdEmpPosHistory = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSchoolName = New System.Windows.Forms.TextBox()
        Me.txtMajor = New System.Windows.Forms.TextBox()
        Me.txtDegreeName = New System.Windows.Forms.TextBox()
        Me.txtYearGrad = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.gbSavingMode.SuspendLayout()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtYearGrad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(143, 5)
        Me.gbSavingMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbSavingMode.Size = New System.Drawing.Size(639, 75)
        Me.gbSavingMode.TabIndex = 125
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(147, 24)
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
        Me.rblAddNewMode.Location = New System.Drawing.Point(332, 24)
        Me.rblAddNewMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(142, 17)
        Me.rblAddNewMode.TabIndex = 0
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มประวัติการศึกษาใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(143, 172)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(719, 82)
        Me.txtNote.TabIndex = 123
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(62, 175)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 20)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "หมายเหตุ"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Save-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Actions-list-remove-user-icon.png")
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.ImageIndex = 2
        Me.cmdDelete.ImageList = Me.ImageList2
        Me.cmdDelete.Location = New System.Drawing.Point(481, 276)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(54, 55)
        Me.cmdDelete.TabIndex = 116
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.ImageIndex = 1
        Me.cmdSave.ImageList = Me.ImageList2
        Me.cmdSave.Location = New System.Drawing.Point(419, 276)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(54, 55)
        Me.cmdSave.TabIndex = 115
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'grdEmpPosHistory
        '
        Me.grdEmpPosHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpPosHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdEmpPosHistory.Location = New System.Drawing.Point(4, 351)
        Me.grdEmpPosHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdEmpPosHistory.Name = "grdEmpPosHistory"
        Me.grdEmpPosHistory.Size = New System.Drawing.Size(947, 186)
        Me.grdEmpPosHistory.TabIndex = 114
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(274, 141)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 20)
        Me.Label25.TabIndex = 131
        Me.Label25.Text = "ชื่อสถานศึกษา"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(27, 141)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(102, 20)
        Me.Label26.TabIndex = 130
        Me.Label26.Text = "ปีการศึกษาที่จบ"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(446, 103)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 20)
        Me.Label23.TabIndex = 129
        Me.Label23.Text = "สาขา"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(80, 100)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 20)
        Me.Label24.TabIndex = 128
        Me.Label24.Text = "คุณวุฒิ"
        '
        'txtSchoolName
        '
        Me.txtSchoolName.Location = New System.Drawing.Point(375, 136)
        Me.txtSchoolName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSchoolName.Name = "txtSchoolName"
        Me.txtSchoolName.Size = New System.Drawing.Size(487, 26)
        Me.txtSchoolName.TabIndex = 135
        '
        'txtMajor
        '
        Me.txtMajor.Location = New System.Drawing.Point(494, 97)
        Me.txtMajor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMajor.Name = "txtMajor"
        Me.txtMajor.Size = New System.Drawing.Size(368, 26)
        Me.txtMajor.TabIndex = 133
        '
        'txtDegreeName
        '
        Me.txtDegreeName.Location = New System.Drawing.Point(143, 100)
        Me.txtDegreeName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDegreeName.Name = "txtDegreeName"
        Me.txtDegreeName.Size = New System.Drawing.Size(286, 26)
        Me.txtDegreeName.TabIndex = 132
        '
        'txtYearGrad
        '
        Me.txtYearGrad.Location = New System.Drawing.Point(143, 133)
        Me.txtYearGrad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtYearGrad.MaxValue = 3000
        Me.txtYearGrad.MinValue = 2500
        Me.txtYearGrad.Name = "txtYearGrad"
        Me.txtYearGrad.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtYearGrad.Size = New System.Drawing.Size(131, 21)
        Me.txtYearGrad.TabIndex = 136
        Me.txtYearGrad.Value = 2500
        '
        'ctrEmpEducationHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtYearGrad)
        Me.Controls.Add(Me.txtSchoolName)
        Me.Controls.Add(Me.txtMajor)
        Me.Controls.Add(Me.txtDegreeName)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.gbSavingMode)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grdEmpPosHistory)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ctrEmpEducationHistory"
        Me.Size = New System.Drawing.Size(955, 555)
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtYearGrad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents grdEmpPosHistory As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSchoolName As System.Windows.Forms.TextBox
    Friend WithEvents txtMajor As System.Windows.Forms.TextBox
    Friend WithEvents txtDegreeName As System.Windows.Forms.TextBox
    Friend WithEvents txtYearGrad As Infragistics.Win.UltraWinEditors.UltraNumericEditor

End Class
