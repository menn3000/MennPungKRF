<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrEmployeeKids
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrEmployeeKids))
        Me.txtKidName = New System.Windows.Forms.TextBox()
        Me.chkInschool = New System.Windows.Forms.CheckBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdEmpPosHistory = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.dtKidDOB = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.chkMale = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkFemale = New System.Windows.Forms.CheckBox()
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSavingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtKidName
        '
        Me.txtKidName.Location = New System.Drawing.Point(201, 83)
        Me.txtKidName.Name = "txtKidName"
        Me.txtKidName.Size = New System.Drawing.Size(506, 26)
        Me.txtKidName.TabIndex = 0
        '
        'chkInschool
        '
        Me.chkInschool.AutoSize = True
        Me.chkInschool.Location = New System.Drawing.Point(412, 161)
        Me.chkInschool.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.chkInschool.Name = "chkInschool"
        Me.chkInschool.Size = New System.Drawing.Size(115, 24)
        Me.chkInschool.TabIndex = 4
        Me.chkInschool.Text = "เรียนหนังสืออยู่"
        Me.chkInschool.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Save-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Actions-list-remove-user-icon.png")
        '
        'grdEmpPosHistory
        '
        Me.grdEmpPosHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpPosHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdEmpPosHistory.Location = New System.Drawing.Point(13, 265)
        Me.grdEmpPosHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdEmpPosHistory.Name = "grdEmpPosHistory"
        Me.grdEmpPosHistory.Size = New System.Drawing.Size(779, 101)
        Me.grdEmpPosHistory.TabIndex = 140
        '
        'dtKidDOB
        '
        Me.dtKidDOB.Location = New System.Drawing.Point(200, 159)
        Me.dtKidDOB.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.dtKidDOB.Name = "dtKidDOB"
        Me.dtKidDOB.Size = New System.Drawing.Size(200, 26)
        Me.dtKidDOB.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(117, 162)
        Me.Label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 20)
        Me.Label22.TabIndex = 136
        Me.Label22.Text = "เกิดวันที่"
        '
        'rblAddNewMode
        '
        Me.rblAddNewMode.AutoSize = True
        Me.rblAddNewMode.Checked = True
        Me.rblAddNewMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rblAddNewMode.Location = New System.Drawing.Point(382, 21)
        Me.rblAddNewMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(70, 21)
        Me.rblAddNewMode.TabIndex = 1
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(118, 86)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 20)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "ชื่อบุตร"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.ImageIndex = 2
        Me.cmdDelete.ImageList = Me.ImageList2
        Me.cmdDelete.Location = New System.Drawing.Point(412, 201)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 51)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.ImageIndex = 1
        Me.cmdSave.ImageList = Me.ImageList2
        Me.cmdSave.Location = New System.Drawing.Point(343, 201)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(57, 51)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rblUpdateMode.Location = New System.Drawing.Point(148, 21)
        Me.rblUpdateMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.rblUpdateMode.Name = "rblUpdateMode"
        Me.rblUpdateMode.Size = New System.Drawing.Size(107, 21)
        Me.rblUpdateMode.TabIndex = 0
        Me.rblUpdateMode.TabStop = True
        Me.rblUpdateMode.Text = "แก้ไขข้อมูลเดิม"
        Me.rblUpdateMode.UseVisualStyleBackColor = True
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(109, 17)
        Me.gbSavingMode.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.gbSavingMode.Size = New System.Drawing.Size(683, 55)
        Me.gbSavingMode.TabIndex = 139
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'chkMale
        '
        Me.chkMale.AutoSize = True
        Me.chkMale.Location = New System.Drawing.Point(201, 115)
        Me.chkMale.Name = "chkMale"
        Me.chkMale.Size = New System.Drawing.Size(52, 24)
        Me.chkMale.TabIndex = 1
        Me.chkMale.Text = "ชาย"
        Me.chkMale.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 116)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "เพศ"
        '
        'chkFemale
        '
        Me.chkFemale.AutoSize = True
        Me.chkFemale.Location = New System.Drawing.Point(263, 115)
        Me.chkFemale.Name = "chkFemale"
        Me.chkFemale.Size = New System.Drawing.Size(56, 24)
        Me.chkFemale.TabIndex = 2
        Me.chkFemale.Text = "หญิง"
        Me.chkFemale.UseVisualStyleBackColor = True
        '
        'ctrEmployeeKids
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkFemale)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkMale)
        Me.Controls.Add(Me.txtKidName)
        Me.Controls.Add(Me.chkInschool)
        Me.Controls.Add(Me.grdEmpPosHistory)
        Me.Controls.Add(Me.dtKidDOB)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gbSavingMode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ctrEmployeeKids"
        Me.Size = New System.Drawing.Size(814, 391)
        CType(Me.grdEmpPosHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtKidName As System.Windows.Forms.TextBox
    Friend WithEvents chkInschool As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents grdEmpPosHistory As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtKidDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents chkMale As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFemale As System.Windows.Forms.CheckBox

End Class
