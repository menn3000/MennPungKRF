Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading



Public Class frmLogin
    Inherits System.Windows.Forms.Form
    Private cls As New clsDataSQL


    Private isLocalDB As Boolean
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private strDB As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        '
        'txtUserID
        '
        Me.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserID.Location = New System.Drawing.Point(208, 47)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(200, 20)
        Me.txtUserID.TabIndex = 1
        '
        'cmdLogin
        '
        Me.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogin.Location = New System.Drawing.Point(192, 125)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(104, 32)
        Me.cmdLogin.TabIndex = 3
        Me.cmdLogin.Text = "Login"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(113, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Your user ID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(113, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(208, 81)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(126)
        Me.txtPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtPassword.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Location = New System.Drawing.Point(304, 125)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 32)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "cancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdLogin)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.txtUserID)
        Me.Panel1.Location = New System.Drawing.Point(348, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 175)
        Me.Panel1.TabIndex = 69
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(98, 148)
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.cmdLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.STAir.My.Resources.Resources.TrainSide
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(798, 526)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "การรถไฟแห่งประเทศไทย"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' TODo  -----  Not working code
        'If Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = System.Globalization.ThaiBuddhistCalendar Then

        'End If
        'If Thread.CurrentThread.CurrentCulture.Calendar.ToFourDigitYear(Today.Year) > 2100 Then
        '    MsgBox("คุณต้องตั้งค่าปีให้เป็น ค.ศ. เท่านั้น กรุณาปิดโปรแกรมแล้วตั้งค่าปีใหม่", MsgBoxStyle.Critical)
        '    Me.cmdLogin.Enabled = False
        '    Exit Sub

        'End If
        'If Today.Year > 2100 Then
        '    MsgBox("คุณต้องตั้งค่าปีให้เป็น ค.ศ. เท่านั้น กรุณาปิดโปรแกรมแล้วตั้งค่าปีใหม่", MsgBoxStyle.Critical)
        '    Me.cmdLogin.Enabled = False
        '    Exit Sub
        'End If

      

        Me.txtUserID.Text = System.Configuration.ConfigurationManager.AppSettings("UserName")

        'check isLocal Database from app.config


        ' ''strDB = System.Configuration.ConfigurationManager.AppSettings(clsUtility.strDBProfile2010)

        ' ''If strDB.Length = 0 Then
        ' ''    Me.isLocalDB = True
        ' ''Else
        ' ''    If strDB.Substring(0, 2) = "\\" Then
        ' ''        Me.isLocalDB = False
        ' ''    Else
        ' ''        Me.isLocalDB = True
        ' ''    End If
        ' ''End If

        Me.txtPassword.Focus()
        DeleteOldReportFile()
       
    End Sub


    Private Sub DeleteOldReportFile()
        Dim FilePath As String = Application.StartupPath & "\Reports"
        Try
            If Directory.Exists(FilePath) Then
                Directory.Delete(FilePath, True)
            End If
        Catch ex As Exception
        End Try
      
    End Sub
  

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        login()
    End Sub
    Private Sub login()
        Cursor.Current = Cursors.WaitCursor
        If Me.verify = True Then

            frmMDIMain.CheckPermission()
            frmMDIMain.Text = clsUtility.UserLevel2CategoryName & " " & clsUtility.GetUserFullName & " " & frmMDIMain.Text
            Me.txtPassword.Text = ""
            Me.Hide()
        End If
        Cursor.Current = Cursors.Arrow
    End Sub
    Private Function verify() As Boolean
        
        If Me.txtUserID.Text.Length = 0 Then
            MsgBox("กรุณาใส่รหัสพนักงานของคุณ")
            Return False
        End If
        If Me.txtPassword.Text.Length = 0 Then
            MsgBox("กรุณาใส่ พาสเวิร์ด")
            Return False
        End If
        Me.txtUserID.Text = Trim(Replace(txtUserID.Text, Chr(39), Chr(146)))
        Me.txtPassword.Text = Trim(Replace(txtPassword.Text, Chr(39), Chr(146)))
        Dim strSQL As String

        Dim strEncryptedPass As String = clsUtility.EncryptText(txtPassword.Text)

        strSQL = "Select e.* ,p.ID as PID, p.PositionName, p.PositionAbv, p.DefaultAirModuleLevel, p.DefaultAdminModuleLevel, p.DefaultInvModuleLevel, p.DefaultFieldWorkModuleLevel "
        strSQL += " from tblEmployees e, tblPositions p "
        strSQL += " where e.[EmployeeID] = "
        strSQL += "'" & Me.txtUserID.Text & "'  "
        strSQL += " and e.[password] = '" & strEncryptedPass & "' "
        strSQL += " and e.[CurrentPositionID] = p.[ID] "

        Dim ds As New DataSet
        Dim dtbTable As New DataTable("login")
        ds.Tables.Add(dtbTable)
        ds = cls.DB_GetDataSet(strSQL, "login")

        If ds.Tables("login").Rows.Count = 0 Then
            MsgBox("รหัสพนักงานและพาสเวิร์ดไม่ถูกต้อง", MsgBoxStyle.Critical)
            Return False
        End If

        With ds.Tables("login")
            

            clsUtility.UserID = .Rows(0)("ID")
            clsUtility.EmployeeID = .Rows(0)("EmployeeID")
            clsUtility.PositionID = .Rows(0)("PID")
            clsUtility.PositionName = .Rows(0)("PositionName")
            clsUtility.PositionAbv = .Rows(0)("PositionAbv")
            clsUtility.UserFName = .Rows(0)("FName")
            clsUtility.UserLName = .Rows(0)("LName")
            clsUtility.UserMainCategory = .Rows(0)("MainCategory")

            If .Rows(0)("OverWriteAirModuleLevel") = clsPermission.enuPerMission.UseDefaultFromPosition Then
                clsUtility.DefaultAirModuleLevel = .Rows(0)("DefaultAirModuleLevel")
            Else
                clsUtility.DefaultAirModuleLevel = .Rows(0)("OverWriteAirModuleLevel")
            End If

            If .Rows(0)("OverWriteAdminModuleLevel") = clsPermission.enuPerMission.UseDefaultFromPosition Then
                clsUtility.DefaultAdminModuleLevel = .Rows(0)("DefaultAdminModuleLevel")
            Else
                clsUtility.DefaultAdminModuleLevel = .Rows(0)("OverWriteAdminModuleLevel")
            End If

            If .Rows(0)("OverWriteInvModuleLevel") = clsPermission.enuPerMission.UseDefaultFromPosition Then
                clsUtility.DefaultInvModuleLevel = .Rows(0)("DefaultInvModuleLevel")
            Else
                clsUtility.DefaultInvModuleLevel = .Rows(0)("OverWriteInvModuleLevel")
            End If

            If .Rows(0)("OverWriteFieldWorkModuleLevel") = clsPermission.enuPerMission.UseDefaultFromPosition Then
                clsUtility.DefaultFieldWorkModuleLevel = .Rows(0)("DefaultFieldWorkModuleLevel")
            Else
                clsUtility.DefaultFieldWorkModuleLevel = .Rows(0)("OverWriteFieldWorkModuleLevel")
            End If

        End With


        'Find Level 2 Category for Position Processing in the future
        Dim ds2 As DataSet
        ds2 = clsBCate.RetriveCategoryParent(clsUtility.UserMainCategory, True)
        Dim dtb As DataTable = ds2.Tables(0)
        For Each tr As DataRow In dtb.Rows
            If tr("CategoryLevel") = 3 Then
                clsUtility.UserLevel2Category = tr("CategoryID")
                clsUtility.UserLevel2CategoryName = tr("CategoryName")
            End If
        Next
        If clsUtility.UserLevel2Category = 0 Then
            MsgBox("คุณยังไม่ได้ตั้งค่าข้อมูล ศูนย์ ในสายงานของคุณ กรุณาติดต่อ แอดมิน เพื่อตั้งค่าดังกล่าว ก่อน คุณจึงสามารถเข้าใช้งานระบบได้", vbCritical)
            Return False
        End If
        Return True

    End Function
    Private clsBCate As New clsBCategory

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Application.Exit()
    End Sub


    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            login()
        End If
    End Sub

   
End Class
