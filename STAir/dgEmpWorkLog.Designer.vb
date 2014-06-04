<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dgEmpWorkLog
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.dtForDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboWorkLogType = New System.Windows.Forms.ComboBox()
        Me.grdEmployees = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDayAmount = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHours = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rtxtStatus = New System.Windows.Forms.RichTextBox()
        Me.cmdSave = New Infragistics.Win.Misc.UltraButton()
        Me.cmdCancel = New Infragistics.Win.Misc.UltraButton()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.grdEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDayAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtForDate
        '
        Me.dtForDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtForDate.Location = New System.Drawing.Point(298, 119)
        Me.dtForDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtForDate.Name = "dtForDate"
        Me.dtForDate.Size = New System.Drawing.Size(300, 23)
        Me.dtForDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(258, 125)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "วันที่"
        '
        'cboWorkLogType
        '
        Me.cboWorkLogType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboWorkLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWorkLogType.FormattingEnabled = True
        Me.cboWorkLogType.Location = New System.Drawing.Point(298, 147)
        Me.cboWorkLogType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboWorkLogType.Name = "cboWorkLogType"
        Me.cboWorkLogType.Size = New System.Drawing.Size(300, 24)
        Me.cboWorkLogType.TabIndex = 3
        '
        'grdEmployees
        '
        Me.grdEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmployees.Location = New System.Drawing.Point(19, 13)
        Me.grdEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.grdEmployees.Name = "grdEmployees"
        Me.grdEmployees.Size = New System.Drawing.Size(799, 85)
        Me.grdEmployees.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 154)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "บันทึกการทำงาน"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(395, 183)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 17)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "วัน"
        '
        'txtDayAmount
        '
        Me.txtDayAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDayAmount.Location = New System.Drawing.Point(298, 176)
        Me.txtDayAmount.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtDayAmount.MaxValue = 120
        Me.txtDayAmount.MinValue = 0
        Me.txtDayAmount.Name = "txtDayAmount"
        Me.txtDayAmount.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDayAmount.Size = New System.Drawing.Size(93, 24)
        Me.txtDayAmount.TabIndex = 139
        Me.txtDayAmount.Value = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(555, 183)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "ชั่วโมง"
        '
        'txtHours
        '
        Me.txtHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtHours.Location = New System.Drawing.Point(467, 176)
        Me.txtHours.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtHours.MaxValue = 23
        Me.txtHours.MinValue = 0
        Me.txtHours.Name = "txtHours"
        Me.txtHours.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHours.Size = New System.Drawing.Size(79, 24)
        Me.txtHours.TabIndex = 141
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 183)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 17)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "จำนวน"
        '
        'rtxtStatus
        '
        Me.rtxtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxtStatus.Location = New System.Drawing.Point(35, 278)
        Me.rtxtStatus.Name = "rtxtStatus"
        Me.rtxtStatus.Size = New System.Drawing.Size(783, 189)
        Me.rtxtStatus.TabIndex = 144
        Me.rtxtStatus.Text = ""
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.DeepSkyBlue
        Appearance1.BackColor2 = System.Drawing.Color.RoyalBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Appearance = Appearance1
        Me.cmdSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(257, 218)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(134, 35)
        Me.cmdSave.SupportThemes = False
        Me.cmdSave.TabIndex = 145
        Me.cmdSave.Text = "บันทึก"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.DeepPink
        Appearance2.BackColor2 = System.Drawing.Color.Red
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Appearance = Appearance2
        Me.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(397, 218)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(134, 35)
        Me.cmdCancel.SupportThemes = False
        Me.cmdCancel.TabIndex = 146
        Me.cmdCancel.Text = "ปิดหน้านี้"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 258)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 17)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "สถานะ"
        '
        'dgEmpWorkLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 492)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.rtxtStatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDayAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grdEmployees)
        Me.Controls.Add(Me.cboWorkLogType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtForDate)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dgEmpWorkLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "บันทึก การทำงาน"
        CType(Me.grdEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDayAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtForDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboWorkLogType As System.Windows.Forms.ComboBox
    Friend WithEvents grdEmployees As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDayAmount As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHours As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rtxtStatus As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
