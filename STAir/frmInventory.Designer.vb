<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.MainTab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdInv = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtInvBrand = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInvCode = New System.Windows.Forms.TextBox()
        Me.cmdAddNewInvCategory = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cboInvCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtinvDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInvSize = New System.Windows.Forms.TextBox()
        Me.gbSavingMode = New System.Windows.Forms.GroupBox()
        Me.rblSearchMode = New System.Windows.Forms.RadioButton()
        Me.rblUpdateMode = New System.Windows.Forms.RadioButton()
        Me.rblAddNewMode = New System.Windows.Forms.RadioButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvModel = New System.Windows.Forms.TextBox()
        Me.txtInvName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.MainTab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbSavingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.TabPage1)
        Me.MainTab.Controls.Add(Me.TabPage2)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Location = New System.Drawing.Point(0, 0)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(934, 543)
        Me.MainTab.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdInv)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.cmdSave)
        Me.TabPage1.Controls.Add(Me.cmdCancel)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(926, 517)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdInv
        '
        Me.grdInv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdInv.Location = New System.Drawing.Point(8, 16)
        Me.grdInv.Name = "grdInv"
        Me.grdInv.Size = New System.Drawing.Size(358, 493)
        Me.grdInv.TabIndex = 28
        Me.grdInv.Text = "วัสดุในระบบ"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtInvBrand)
        Me.Panel1.Controls.Add(Me.cmdSearch)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtInvCode)
        Me.Panel1.Controls.Add(Me.cmdAddNewInvCategory)
        Me.Panel1.Controls.Add(Me.cboInvCategory)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtinvDesc)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtInvSize)
        Me.Panel1.Controls.Add(Me.gbSavingMode)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtInvModel)
        Me.Panel1.Controls.Add(Me.txtInvName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(372, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 377)
        Me.Panel1.TabIndex = 31
        '
        'txtInvBrand
        '
        Me.txtInvBrand.Location = New System.Drawing.Point(98, 165)
        Me.txtInvBrand.Name = "txtInvBrand"
        Me.txtInvBrand.Size = New System.Drawing.Size(352, 20)
        Me.txtInvBrand.TabIndex = 110
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSearch.Image = Global.STAir.My.Resources.Resources.Zoom_icon
        Me.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSearch.Location = New System.Drawing.Point(228, 288)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(63, 57)
        Me.cmdSearch.TabIndex = 109
        Me.cmdSearch.Text = "ค้นหา"
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSearch.UseVisualStyleBackColor = False
        Me.cmdSearch.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "รหัสวัสดุ"
        '
        'txtInvCode
        '
        Me.txtInvCode.Location = New System.Drawing.Point(98, 83)
        Me.txtInvCode.Name = "txtInvCode"
        Me.txtInvCode.Size = New System.Drawing.Size(352, 20)
        Me.txtInvCode.TabIndex = 107
        '
        'cmdAddNewInvCategory
        '
        Me.cmdAddNewInvCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNewInvCategory.ImageIndex = 0
        Me.cmdAddNewInvCategory.ImageList = Me.ImageList2
        Me.cmdAddNewInvCategory.Location = New System.Drawing.Point(425, 136)
        Me.cmdAddNewInvCategory.Name = "cmdAddNewInvCategory"
        Me.cmdAddNewInvCategory.Size = New System.Drawing.Size(25, 23)
        Me.cmdAddNewInvCategory.TabIndex = 106
        Me.cmdAddNewInvCategory.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "PAPER.ICO")
        Me.ImageList2.Images.SetKeyName(1, "Save-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "Actions-list-remove-user-icon.png")
        Me.ImageList2.Images.SetKeyName(3, "Zoom-icon.png")
        '
        'cboInvCategory
        '
        Me.cboInvCategory.FormattingEnabled = True
        Me.cboInvCategory.Location = New System.Drawing.Point(98, 138)
        Me.cboInvCategory.Name = "cboInvCategory"
        Me.cboInvCategory.Size = New System.Drawing.Size(317, 21)
        Me.cboInvCategory.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "หมวดหมู่"
        '
        'txtinvDesc
        '
        Me.txtinvDesc.Location = New System.Drawing.Point(98, 250)
        Me.txtinvDesc.Name = "txtinvDesc"
        Me.txtinvDesc.Size = New System.Drawing.Size(352, 20)
        Me.txtinvDesc.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 253)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "รายละเอียด"
        '
        'txtInvSize
        '
        Me.txtInvSize.Location = New System.Drawing.Point(98, 224)
        Me.txtInvSize.Name = "txtInvSize"
        Me.txtInvSize.Size = New System.Drawing.Size(352, 20)
        Me.txtInvSize.TabIndex = 24
        '
        'gbSavingMode
        '
        Me.gbSavingMode.Controls.Add(Me.rblSearchMode)
        Me.gbSavingMode.Controls.Add(Me.rblUpdateMode)
        Me.gbSavingMode.Controls.Add(Me.rblAddNewMode)
        Me.gbSavingMode.Location = New System.Drawing.Point(22, 16)
        Me.gbSavingMode.Name = "gbSavingMode"
        Me.gbSavingMode.Size = New System.Drawing.Size(428, 61)
        Me.gbSavingMode.TabIndex = 23
        Me.gbSavingMode.TabStop = False
        Me.gbSavingMode.Text = "โหมดการทำงาน"
        '
        'rblSearchMode
        '
        Me.rblSearchMode.AutoSize = True
        Me.rblSearchMode.Location = New System.Drawing.Point(288, 29)
        Me.rblSearchMode.Name = "rblSearchMode"
        Me.rblSearchMode.Size = New System.Drawing.Size(52, 17)
        Me.rblSearchMode.TabIndex = 2
        Me.rblSearchMode.Text = "ค้นหา"
        Me.rblSearchMode.UseVisualStyleBackColor = True
        '
        'rblUpdateMode
        '
        Me.rblUpdateMode.AutoSize = True
        Me.rblUpdateMode.Location = New System.Drawing.Point(76, 29)
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
        Me.rblAddNewMode.Location = New System.Drawing.Point(185, 29)
        Me.rblAddNewMode.Name = "rblAddNewMode"
        Me.rblAddNewMode.Size = New System.Drawing.Size(84, 17)
        Me.rblAddNewMode.TabIndex = 0
        Me.rblAddNewMode.TabStop = True
        Me.rblAddNewMode.Text = "เพิ่มวัสดุใหม่"
        Me.rblAddNewMode.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(53, 227)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 13)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "ขนาด"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(59, 168)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(27, 13)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "ยี่ห้อ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "ชื่อวัสดุ"
        '
        'txtInvModel
        '
        Me.txtInvModel.Location = New System.Drawing.Point(98, 192)
        Me.txtInvModel.Name = "txtInvModel"
        Me.txtInvModel.Size = New System.Drawing.Size(352, 20)
        Me.txtInvModel.TabIndex = 21
        '
        'txtInvName
        '
        Me.txtInvName.Location = New System.Drawing.Point(98, 112)
        Me.txtInvName.Name = "txtInvName"
        Me.txtInvName.Size = New System.Drawing.Size(352, 20)
        Me.txtInvName.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "รุ่น"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(594, 407)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(85, 23)
        Me.cmdSave.TabIndex = 30
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(511, 407)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(926, 517)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(98, 83)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(352, 20)
        Me.TextBox3.TabIndex = 107
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 543)
        Me.Controls.Add(Me.MainTab)
        Me.Name = "frmInventory"
        Me.Text = "frmInventory"
        Me.MainTab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbSavingMode.ResumeLayout(False)
        Me.gbSavingMode.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboInvCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtinvDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInvSize As System.Windows.Forms.TextBox
    Friend WithEvents gbSavingMode As System.Windows.Forms.GroupBox
    Friend WithEvents rblUpdateMode As System.Windows.Forms.RadioButton
    Friend WithEvents rblAddNewMode As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvModel As System.Windows.Forms.TextBox
    Friend WithEvents txtInvName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grdInv As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmdAddNewInvCategory As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtInvCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents rblSearchMode As System.Windows.Forms.RadioButton
    Friend WithEvents txtInvBrand As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
