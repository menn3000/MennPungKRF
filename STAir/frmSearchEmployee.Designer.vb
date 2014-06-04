<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchEmployee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchEmployee))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkCheckAll = New System.Windows.Forms.CheckBox()
        Me.cmdAddWorkLog = New System.Windows.Forms.Button()
        Me.cmdAddNewEmployee = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdBatchPrint = New System.Windows.Forms.Button()
        Me.cmdCollabGrid = New System.Windows.Forms.Button()
        Me.cmdExpandGrid = New System.Windows.Forms.Button()
        Me.cmdViewEmpDetail = New System.Windows.Forms.Button()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSearch = New Infragistics.Win.Misc.UltraButton()
        Me.cmdCancel = New Infragistics.Win.Misc.UltraButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdEmployees = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmdBreadCrumb = New Infragistics.Win.Misc.UltraButton()
        Me.lblBreadCrumb = New System.Windows.Forms.Label()
        Me.pnlHidden = New System.Windows.Forms.Panel()
        Me.txtMainCategoryID = New System.Windows.Forms.TextBox()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHidden.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboPosition
        '
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Location = New System.Drawing.Point(13, 81)
        Me.cboPosition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(163, 28)
        Me.cboPosition.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 26)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "ตำแหน่งงาน"
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(355, 81)
        Me.txtFName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(163, 26)
        Me.txtFName.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(355, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 26)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "ชื่อ"
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(526, 81)
        Me.txtLName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(163, 26)
        Me.txtLName.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(526, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 26)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "นามสกุล"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.chkCheckAll)
        Me.GroupBox5.Controls.Add(Me.cmdAddWorkLog)
        Me.GroupBox5.Controls.Add(Me.cmdAddNewEmployee)
        Me.GroupBox5.Controls.Add(Me.cmdBatchPrint)
        Me.GroupBox5.Controls.Add(Me.cmdCollabGrid)
        Me.GroupBox5.Controls.Add(Me.cmdExpandGrid)
        Me.GroupBox5.Controls.Add(Me.cmdViewEmpDetail)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox5.Location = New System.Drawing.Point(4, -4)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Size = New System.Drawing.Size(886, 54)
        Me.GroupBox5.TabIndex = 58
        Me.GroupBox5.TabStop = False
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkCheckAll.Location = New System.Drawing.Point(27, 23)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(66, 21)
        Me.chkCheckAll.TabIndex = 89
        Me.chkCheckAll.Text = "ทั้งหมด"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'cmdAddWorkLog
        '
        Me.cmdAddWorkLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddWorkLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAddWorkLog.Image = Global.STAir.My.Resources.Resources.Journal_Sm1
        Me.cmdAddWorkLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddWorkLog.Location = New System.Drawing.Point(292, 17)
        Me.cmdAddWorkLog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddWorkLog.Name = "cmdAddWorkLog"
        Me.cmdAddWorkLog.Size = New System.Drawing.Size(137, 31)
        Me.cmdAddWorkLog.TabIndex = 88
        Me.cmdAddWorkLog.Text = "บันทึกการทำงาน"
        Me.cmdAddWorkLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddWorkLog.UseVisualStyleBackColor = False
        '
        'cmdAddNewEmployee
        '
        Me.cmdAddNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNewEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAddNewEmployee.ImageIndex = 3
        Me.cmdAddNewEmployee.ImageList = Me.ImageList1
        Me.cmdAddNewEmployee.Location = New System.Drawing.Point(112, 17)
        Me.cmdAddNewEmployee.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddNewEmployee.Name = "cmdAddNewEmployee"
        Me.cmdAddNewEmployee.Size = New System.Drawing.Size(57, 31)
        Me.cmdAddNewEmployee.TabIndex = 57
        Me.cmdAddNewEmployee.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList1.Images.SetKeyName(1, "Journal_Sm.jpg")
        Me.ImageList1.Images.SetKeyName(2, "Actions-user-properties-icon.png")
        Me.ImageList1.Images.SetKeyName(3, "Actions-list-add-user-icon.png")
        Me.ImageList1.Images.SetKeyName(4, "PRINT8.ICO")
        Me.ImageList1.Images.SetKeyName(5, "PRINT6.ICO")
        Me.ImageList1.Images.SetKeyName(6, "Trash.png")
        Me.ImageList1.Images.SetKeyName(7, "Windows Explorer.png")
        Me.ImageList1.Images.SetKeyName(8, "Money.png")
        Me.ImageList1.Images.SetKeyName(9, "People_024.gif")
        Me.ImageList1.Images.SetKeyName(10, "Computer_File_106.gif")
        '
        'cmdBatchPrint
        '
        Me.cmdBatchPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBatchPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdBatchPrint.ForeColor = System.Drawing.Color.White
        Me.cmdBatchPrint.ImageIndex = 4
        Me.cmdBatchPrint.ImageList = Me.ImageList1
        Me.cmdBatchPrint.Location = New System.Drawing.Point(567, 17)
        Me.cmdBatchPrint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBatchPrint.Name = "cmdBatchPrint"
        Me.cmdBatchPrint.Size = New System.Drawing.Size(54, 31)
        Me.cmdBatchPrint.TabIndex = 61
        Me.cmdBatchPrint.UseVisualStyleBackColor = False
        Me.cmdBatchPrint.Visible = False
        '
        'cmdCollabGrid
        '
        Me.cmdCollabGrid.BackColor = System.Drawing.Color.Transparent
        Me.cmdCollabGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCollabGrid.ForeColor = System.Drawing.Color.White
        Me.cmdCollabGrid.Location = New System.Drawing.Point(675, 17)
        Me.cmdCollabGrid.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCollabGrid.Name = "cmdCollabGrid"
        Me.cmdCollabGrid.Size = New System.Drawing.Size(36, 31)
        Me.cmdCollabGrid.TabIndex = 60
        Me.cmdCollabGrid.Text = "-"
        Me.cmdCollabGrid.UseVisualStyleBackColor = False
        Me.cmdCollabGrid.Visible = False
        '
        'cmdExpandGrid
        '
        Me.cmdExpandGrid.BackColor = System.Drawing.Color.Transparent
        Me.cmdExpandGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExpandGrid.ForeColor = System.Drawing.Color.White
        Me.cmdExpandGrid.Location = New System.Drawing.Point(631, 17)
        Me.cmdExpandGrid.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdExpandGrid.Name = "cmdExpandGrid"
        Me.cmdExpandGrid.Size = New System.Drawing.Size(36, 31)
        Me.cmdExpandGrid.TabIndex = 59
        Me.cmdExpandGrid.Text = "+"
        Me.cmdExpandGrid.UseVisualStyleBackColor = False
        Me.cmdExpandGrid.Visible = False
        '
        'cmdViewEmpDetail
        '
        Me.cmdViewEmpDetail.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cmdViewEmpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdViewEmpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdViewEmpDetail.ForeColor = System.Drawing.Color.White
        Me.cmdViewEmpDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdViewEmpDetail.ImageIndex = 2
        Me.cmdViewEmpDetail.ImageList = Me.ImageList1
        Me.cmdViewEmpDetail.Location = New System.Drawing.Point(178, 17)
        Me.cmdViewEmpDetail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdViewEmpDetail.Name = "cmdViewEmpDetail"
        Me.cmdViewEmpDetail.Size = New System.Drawing.Size(104, 31)
        Me.cmdViewEmpDetail.TabIndex = 58
        Me.cmdViewEmpDetail.Text = "ดูรายละเอียด"
        Me.cmdViewEmpDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdViewEmpDetail.UseVisualStyleBackColor = False
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(184, 81)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(163, 26)
        Me.txtEmployeeID.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(184, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 26)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "รหัสพนักงาน"
        '
        'cmdSearch
        '
        Appearance1.BackColor = System.Drawing.Color.DeepSkyBlue
        Appearance1.BackColor2 = System.Drawing.Color.RoyalBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.ForeColor = System.Drawing.Color.White
        Me.cmdSearch.Appearance = Appearance1
        Me.cmdSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(243, 139)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(134, 35)
        Me.cmdSearch.SupportThemes = False
        Me.cmdSearch.TabIndex = 61
        Me.cmdSearch.Text = "ค้นหา"
        '
        'cmdCancel
        '
        Appearance2.BackColor = System.Drawing.Color.DeepPink
        Appearance2.BackColor2 = System.Drawing.Color.Red
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Appearance = Appearance2
        Me.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(387, 139)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(134, 35)
        Me.cmdCancel.SupportThemes = False
        Me.cmdCancel.TabIndex = 62
        Me.cmdCancel.Text = "ยกเลิก"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(3, 295)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 57)
        Me.Panel1.TabIndex = 63
        '
        'grdEmployees
        '
        Me.grdEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmployees.Location = New System.Drawing.Point(3, 358)
        Me.grdEmployees.Name = "grdEmployees"
        Me.grdEmployees.Size = New System.Drawing.Size(897, 202)
        Me.grdEmployees.TabIndex = 64
        '
        'cmdBreadCrumb
        '
        Appearance3.AlphaLevel = CType(200, Short)
        Appearance3.BackColor = System.Drawing.Color.DarkOrange
        Appearance3.BackColor2 = System.Drawing.Color.Orange
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.ForeColor = System.Drawing.Color.White
        Me.cmdBreadCrumb.Appearance = Appearance3
        Me.cmdBreadCrumb.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.cmdBreadCrumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdBreadCrumb.Location = New System.Drawing.Point(13, 21)
        Me.cmdBreadCrumb.Name = "cmdBreadCrumb"
        Me.cmdBreadCrumb.Size = New System.Drawing.Size(163, 26)
        Me.cmdBreadCrumb.SupportThemes = False
        Me.cmdBreadCrumb.TabIndex = 105
        Me.cmdBreadCrumb.Text = "สายงาน"
        '
        'lblBreadCrumb
        '
        Me.lblBreadCrumb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBreadCrumb.BackColor = System.Drawing.Color.SteelBlue
        Me.lblBreadCrumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBreadCrumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBreadCrumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblBreadCrumb.ForeColor = System.Drawing.Color.White
        Me.lblBreadCrumb.Location = New System.Drawing.Point(184, 21)
        Me.lblBreadCrumb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBreadCrumb.Name = "lblBreadCrumb"
        Me.lblBreadCrumb.Size = New System.Drawing.Size(709, 26)
        Me.lblBreadCrumb.TabIndex = 106
        Me.lblBreadCrumb.Text = "ทุกสายงานของฉัน"
        '
        'pnlHidden
        '
        Me.pnlHidden.Controls.Add(Me.txtMainCategoryID)
        Me.pnlHidden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.pnlHidden.Location = New System.Drawing.Point(787, 50)
        Me.pnlHidden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlHidden.Name = "pnlHidden"
        Me.pnlHidden.Size = New System.Drawing.Size(106, 39)
        Me.pnlHidden.TabIndex = 107
        Me.pnlHidden.Visible = False
        '
        'txtMainCategoryID
        '
        Me.txtMainCategoryID.Enabled = False
        Me.txtMainCategoryID.Location = New System.Drawing.Point(4, 11)
        Me.txtMainCategoryID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMainCategoryID.Name = "txtMainCategoryID"
        Me.txtMainCategoryID.Size = New System.Drawing.Size(85, 20)
        Me.txtMainCategoryID.TabIndex = 102
        '
        'frmSearchEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 572)
        Me.Controls.Add(Me.pnlHidden)
        Me.Controls.Add(Me.lblBreadCrumb)
        Me.Controls.Add(Me.cmdBreadCrumb)
        Me.Controls.Add(Me.grdEmployees)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmSearchEmployee"
        Me.Text = "ค้นหาพนักงาน"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHidden.ResumeLayout(False)
        Me.pnlHidden.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddWorkLog As System.Windows.Forms.Button
    Friend WithEvents cmdAddNewEmployee As System.Windows.Forms.Button
    Friend WithEvents cmdBatchPrint As System.Windows.Forms.Button
    Friend WithEvents cmdCollabGrid As System.Windows.Forms.Button
    Friend WithEvents cmdExpandGrid As System.Windows.Forms.Button
    Friend WithEvents cmdViewEmpDetail As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmdCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdEmployees As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdBreadCrumb As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblBreadCrumb As System.Windows.Forms.Label
    Friend WithEvents pnlHidden As System.Windows.Forms.Panel
    Friend WithEvents txtMainCategoryID As System.Windows.Forms.TextBox
    Friend WithEvents chkCheckAll As System.Windows.Forms.CheckBox
End Class
