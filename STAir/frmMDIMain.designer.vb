<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDIMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDIMain))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOfficeAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPositions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMainCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAddEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearchEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHoliday = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInventoryItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPersonal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalaryLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.tsStatusLabel, Me.tsProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(755, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel.Text = "Status :"
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.Name = "tsStatusLabel"
        Me.tsStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.tsStatusLabel.Text = "Ready"
        '
        'tsProgressBar
        '
        Me.tsProgressBar.Name = "tsProgressBar"
        Me.tsProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.mnuOfficeAdmin, Me.mnuMainInventory, Me.mnuPersonal})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(755, 24)
        Me.MenuStrip1.TabIndex = 45
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(154, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(157, 22)
        Me.mnuExit.Text = "ออกจากโปรแกรม"
        '
        'mnuOfficeAdmin
        '
        Me.mnuOfficeAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmployee, Me.ToolStripMenuItem2, Me.mnuHoliday})
        Me.mnuOfficeAdmin.Name = "mnuOfficeAdmin"
        Me.mnuOfficeAdmin.Size = New System.Drawing.Size(64, 20)
        Me.mnuOfficeAdmin.Text = "สารบรรณ"
        '
        'mnuEmployee
        '
        Me.mnuEmployee.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPositions, Me.mnuSalaryLevel, Me.ToolStripMenuItem3, Me.mnuMainCategory, Me.ToolStripMenuItem4, Me.mnuAddEmployee, Me.mnuSearchEmp})
        Me.mnuEmployee.Name = "mnuEmployee"
        Me.mnuEmployee.Size = New System.Drawing.Size(152, 22)
        Me.mnuEmployee.Text = "พนักงาน"
        '
        'mnuPositions
        '
        Me.mnuPositions.Name = "mnuPositions"
        Me.mnuPositions.Size = New System.Drawing.Size(152, 22)
        Me.mnuPositions.Text = "ตำแหน่งงาน"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(149, 6)
        '
        'mnuMainCategory
        '
        Me.mnuMainCategory.Name = "mnuMainCategory"
        Me.mnuMainCategory.Size = New System.Drawing.Size(152, 22)
        Me.mnuMainCategory.Text = "สังกัดการทำงาน"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(149, 6)
        '
        'mnuAddEmployee
        '
        Me.mnuAddEmployee.Name = "mnuAddEmployee"
        Me.mnuAddEmployee.Size = New System.Drawing.Size(152, 22)
        Me.mnuAddEmployee.Text = "เพิ่มพนักงาน"
        '
        'mnuSearchEmp
        '
        Me.mnuSearchEmp.Name = "mnuSearchEmp"
        Me.mnuSearchEmp.Size = New System.Drawing.Size(152, 22)
        Me.mnuSearchEmp.Text = "ค้นหาพนักงาน"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'mnuHoliday
        '
        Me.mnuHoliday.Name = "mnuHoliday"
        Me.mnuHoliday.Size = New System.Drawing.Size(152, 22)
        Me.mnuHoliday.Text = "วันหยุดประจำปี"
        '
        'mnuMainInventory
        '
        Me.mnuMainInventory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInventoryItems})
        Me.mnuMainInventory.Name = "mnuMainInventory"
        Me.mnuMainInventory.Size = New System.Drawing.Size(38, 20)
        Me.mnuMainInventory.Text = "วัสดุ"
        '
        'mnuInventoryItems
        '
        Me.mnuInventoryItems.Name = "mnuInventoryItems"
        Me.mnuInventoryItems.Size = New System.Drawing.Size(129, 22)
        Me.mnuInventoryItems.Text = "รายการวัสดุ"
        '
        'mnuPersonal
        '
        Me.mnuPersonal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMyData})
        Me.mnuPersonal.Name = "mnuPersonal"
        Me.mnuPersonal.Size = New System.Drawing.Size(52, 20)
        Me.mnuPersonal.Text = "ส่วนตัว"
        '
        'mnuMyData
        '
        Me.mnuMyData.Name = "mnuMyData"
        Me.mnuMyData.Size = New System.Drawing.Size(133, 22)
        Me.mnuMyData.Text = "ข้อมูลส่วนตัว"
        '
        'mnuSalaryLevel
        '
        Me.mnuSalaryLevel.Name = "mnuSalaryLevel"
        Me.mnuSalaryLevel.Size = New System.Drawing.Size(152, 22)
        Me.mnuSalaryLevel.Text = "ระดับเงินเดือน"
        '
        'frmMDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 453)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMDIMain"
        Me.Text = "Signaling and Telecommunication"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOfficeAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInventoryItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPersonal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuHoliday As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPositions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAddEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearchEmp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMainCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMyData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalaryLevel As System.Windows.Forms.ToolStripMenuItem

End Class
