<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrPersonalWorkLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrPersonalWorkLog))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdWorkLog = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grbLogType = New System.Windows.Forms.GroupBox()
        Me.rblOffWork = New System.Windows.Forms.RadioButton()
        Me.rblOT = New System.Windows.Forms.RadioButton()
        Me.cmdSearch = New Infragistics.Win.Misc.UltraButton()
        Me.pnlGridFunction = New System.Windows.Forms.Panel()
        Me.chkCheckAll = New System.Windows.Forms.CheckBox()
        Me.cmdAddNewEmployee = New System.Windows.Forms.Button()
        Me.cmdAddWorkLog = New Infragistics.Win.Misc.UltraButton()
        CType(Me.grdWorkLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLogType.SuspendLayout()
        Me.pnlGridFunction.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Actions-list-remove-user-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Button-Close-icon.png")
        '
        'grdWorkLog
        '
        Me.grdWorkLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdWorkLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdWorkLog.Location = New System.Drawing.Point(24, 232)
        Me.grdWorkLog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdWorkLog.Name = "grdWorkLog"
        Me.grdWorkLog.Size = New System.Drawing.Size(539, 134)
        Me.grdWorkLog.TabIndex = 114
        '
        'dtToDate
        '
        Me.dtToDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtToDate.Location = New System.Drawing.Point(302, 38)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(169, 26)
        Me.dtToDate.TabIndex = 128
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(277, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 20)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "ถึง"
        '
        'dtFromDate
        '
        Me.dtFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtFromDate.Location = New System.Drawing.Point(102, 38)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(169, 26)
        Me.dtFromDate.TabIndex = 126
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 20)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "วันที่"
        '
        'grbLogType
        '
        Me.grbLogType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grbLogType.Controls.Add(Me.rblOffWork)
        Me.grbLogType.Controls.Add(Me.rblOT)
        Me.grbLogType.Location = New System.Drawing.Point(60, 60)
        Me.grbLogType.Name = "grbLogType"
        Me.grbLogType.Size = New System.Drawing.Size(411, 62)
        Me.grbLogType.TabIndex = 131
        Me.grbLogType.TabStop = False
        '
        'rblOffWork
        '
        Me.rblOffWork.AutoSize = True
        Me.rblOffWork.Location = New System.Drawing.Point(253, 25)
        Me.rblOffWork.Name = "rblOffWork"
        Me.rblOffWork.Size = New System.Drawing.Size(90, 17)
        Me.rblOffWork.TabIndex = 134
        Me.rblOffWork.TabStop = True
        Me.rblOffWork.Text = "ขาด-ลา-มาสาย"
        Me.rblOffWork.UseVisualStyleBackColor = True
        '
        'rblOT
        '
        Me.rblOT.AutoSize = True
        Me.rblOT.Checked = True
        Me.rblOT.Location = New System.Drawing.Point(42, 25)
        Me.rblOT.Name = "rblOT"
        Me.rblOT.Size = New System.Drawing.Size(132, 17)
        Me.rblOT.TabIndex = 133
        Me.rblOT.TabStop = True
        Me.rblOT.Text = "ทำงานวันหยุด-ล่วงเวลา"
        Me.rblOT.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Appearance1.BackColor = System.Drawing.Color.Chartreuse
        Appearance1.BackColor2 = System.Drawing.Color.Green
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.White
        Me.cmdSearch.Appearance = Appearance1
        Me.cmdSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(477, 38)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(77, 84)
        Me.cmdSearch.SupportThemes = False
        Me.cmdSearch.TabIndex = 132
        Me.cmdSearch.Text = "ค้นหา"
        '
        'pnlGridFunction
        '
        Me.pnlGridFunction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlGridFunction.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlGridFunction.Controls.Add(Me.chkCheckAll)
        Me.pnlGridFunction.Controls.Add(Me.cmdAddNewEmployee)
        Me.pnlGridFunction.ForeColor = System.Drawing.Color.White
        Me.pnlGridFunction.Location = New System.Drawing.Point(24, 181)
        Me.pnlGridFunction.Name = "pnlGridFunction"
        Me.pnlGridFunction.Size = New System.Drawing.Size(539, 43)
        Me.pnlGridFunction.TabIndex = 133
        Me.pnlGridFunction.Visible = False
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkCheckAll.Location = New System.Drawing.Point(16, 13)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(66, 21)
        Me.chkCheckAll.TabIndex = 89
        Me.chkCheckAll.Text = "ทั้งหมด"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'cmdAddNewEmployee
        '
        Me.cmdAddNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNewEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAddNewEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddNewEmployee.ImageIndex = 2
        Me.cmdAddNewEmployee.ImageList = Me.ImageList2
        Me.cmdAddNewEmployee.Location = New System.Drawing.Point(89, 7)
        Me.cmdAddNewEmployee.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddNewEmployee.Name = "cmdAddNewEmployee"
        Me.cmdAddNewEmployee.Size = New System.Drawing.Size(172, 31)
        Me.cmdAddNewEmployee.TabIndex = 57
        Me.cmdAddNewEmployee.Text = "ลบบันทึกการทำงาน"
        Me.cmdAddNewEmployee.UseVisualStyleBackColor = False
        '
        'cmdAddWorkLog
        '
        Me.cmdAddWorkLog.Anchor = System.Windows.Forms.AnchorStyles.Top
        Appearance2.BackColor = System.Drawing.Color.DeepSkyBlue
        Appearance2.BackColor2 = System.Drawing.Color.DodgerBlue
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.ForeColor = System.Drawing.Color.White
        Me.cmdAddWorkLog.Appearance = Appearance2
        Me.cmdAddWorkLog.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdAddWorkLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAddWorkLog.Location = New System.Drawing.Point(193, 128)
        Me.cmdAddWorkLog.Name = "cmdAddWorkLog"
        Me.cmdAddWorkLog.Size = New System.Drawing.Size(169, 33)
        Me.cmdAddWorkLog.SupportThemes = False
        Me.cmdAddWorkLog.TabIndex = 134
        Me.cmdAddWorkLog.Text = "ลงบันทึกการทำงาน"
        '
        'ctrPersonalWorkLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdAddWorkLog)
        Me.Controls.Add(Me.pnlGridFunction)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.dtToDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtFromDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grdWorkLog)
        Me.Controls.Add(Me.grbLogType)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ctrPersonalWorkLog"
        Me.Size = New System.Drawing.Size(588, 387)
        CType(Me.grdWorkLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLogType.ResumeLayout(False)
        Me.grbLogType.PerformLayout()
        Me.pnlGridFunction.ResumeLayout(False)
        Me.pnlGridFunction.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents grdWorkLog As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grbLogType As System.Windows.Forms.GroupBox
    Friend WithEvents rblOffWork As System.Windows.Forms.RadioButton
    Friend WithEvents rblOT As System.Windows.Forms.RadioButton
    Friend WithEvents cmdSearch As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlGridFunction As System.Windows.Forms.Panel
    Friend WithEvents chkCheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAddNewEmployee As System.Windows.Forms.Button
    Friend WithEvents cmdAddWorkLog As Infragistics.Win.Misc.UltraButton

End Class
