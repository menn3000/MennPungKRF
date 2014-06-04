<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalayLevel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalayLevel))
        Me.grdPositions = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.txtSalary = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumLevel = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSavingMode.SuspendLayout()
        CType(Me.txtSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPositions
        '
        Me.grdPositions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdPositions.Location = New System.Drawing.Point(13, 13)
        Me.grdPositions.Margin = New System.Windows.Forms.Padding(4)
        Me.grdPositions.Name = "grdPositions"
        Me.grdPositions.Size = New System.Drawing.Size(363, 455)
        Me.grdPositions.TabIndex = 24
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(386, 13)
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
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(532, 128)
        Me.txtSalary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSalary.MaxValue = 1000000.0R
        Me.txtSalary.MinValue = 0.0R
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtSalary.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtSalary.Size = New System.Drawing.Size(200, 21)
        Me.txtSalary.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(428, 132)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "อัตราเงินเดือน"
        '
        'txtNumLevel
        '
        Me.txtNumLevel.Location = New System.Drawing.Point(532, 97)
        Me.txtNumLevel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumLevel.MaxValue = 100.0R
        Me.txtNumLevel.MinValue = 1
        Me.txtNumLevel.Name = "txtNumLevel"
        Me.txtNumLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtNumLevel.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtNumLevel.Size = New System.Drawing.Size(200, 21)
        Me.txtNumLevel.TabIndex = 132
        Me.txtNumLevel.Value = 1.0R
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(449, 101)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "ระดับ"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.ImageIndex = 2
        Me.cmdDelete.ImageList = Me.ImageList2
        Me.cmdDelete.Location = New System.Drawing.Point(615, 175)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 51)
        Me.cmdDelete.TabIndex = 136
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
        Me.cmdSave.Location = New System.Drawing.Point(546, 175)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(57, 51)
        Me.cmdSave.TabIndex = 135
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(546, 238)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(125, 28)
        Me.cmdCancel.TabIndex = 137
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmSalayLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 481)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtSalary)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumLevel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grdPositions)
        Me.Controls.Add(Me.gbSavingMode)
        Me.Name = "frmSalayLevel"
        Me.Text = "frmSalayLevel"
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        CType(Me.txtSalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdPositions As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents txtSalary As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumLevel As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
