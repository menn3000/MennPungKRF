Imports System.Windows.Forms
Imports System.IO
Imports STAir.LUNA
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading


Public Class frmMDIMain



    Private m_ChildFormNumber As Integer
    Friend Shared cls As New clsDataSQL


    Friend fSearchEmp As frmSearchEmployee
    Friend fEmployee As frmAddUser
    Friend fPosition As frmPosition
    Friend fInv As frmInventory
    Friend fMainCategory As Category
    Private fHoliday As frmHoliday
    Private fSalaryLevel As frmSalayLevel


    'Friend Shared Function ShowCountDownDialog(ByVal Message As String, ByVal defaultResult As Windows.Forms.DialogResult, Optional ByVal intSecToCountDown As Integer = 30) As System.Windows.Forms.DialogResult
    '    If CountdgDownMsg Is Nothing Then
    '        CountdgDownMsg = New dgCountDown
    '    End If

    '    Dim dgResult As System.Windows.Forms.DialogResult
    '    dgResult = frmMDIMain.CountdgDownMsg.ShowMessage(Message, defaultResult, intSecToCountDown)
    '    Return dgResult
    'End Function




    ' '' ''    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
    ' '' ''        ' Create a new instance of the child form.
    ' '' ''        Dim ChildForm As New System.Windows.Forms.Form
    ' '' ''        ' Make it a child of this MDI form before showing it.
    ' '' ''        ChildForm.MdiParent = Me

    ' '' ''        m_ChildFormNumber += 1
    ' '' ''        ChildForm.Text = "Window " & m_ChildFormNumber

    ' '' ''        ChildForm.Show()
    ' '' ''    End Sub



    Private Sub frmMDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If e.CloseReason = CloseReason.ApplicationExitCall Or e.CloseReason = CloseReason.UserClosing Then
        '    ' Close all child forms of the parent.
        '    For Each ChildForm As Form In Me.MdiChildren
        '        ChildForm.Hide()
        '    Next
        '    e.Cancel = False


        'End If
    End Sub



    Private Sub frmMDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Put the following code before InitializeComponent()
        ' Sets the culture to French (France)
        Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
        ' Sets the UI culture to French (France)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("th-TH")

        'MsgBox("InvariantCulture " & Now.ToString("D", CultureInfo.InvariantCulture))
        'MsgBox("nothing " & Now.ToString("D"))
        'MsgBox("InstalledUICulture " & Now.ToString("D", CultureInfo.InstalledUICulture))


        Dim fileinfo As New FileInfo(Application.ExecutablePath)
        Me.Text = " SRT (Built date" & fileinfo.LastWriteTime.ToString() & ") : " & cls.strDatabaseProfile


        Me.MenuStrip1.Enabled = False

        Dim fLogin As New frmLogin
        fLogin.MdiParent = Me
        m_ChildFormNumber += 1
        fLogin.Text = "กรุณาเข้าระบบ" & m_ChildFormNumber
        fLogin.WindowState = FormWindowState.Normal
        fLogin.Show()

    End Sub
    Friend Sub CheckPermission() ' this have to be run after login because we do not have user data when it's loaded
        'Hide all child forms
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Hide()
        Next
        Select Case clsUtility.DefaultAirModuleLevel


        End Select

        Select Case clsUtility.DefaultAdminModuleLevel
            Case clsPermission.enuPerMission.NoAccess
                mnuOfficeAdmin.Enabled = False

        End Select

        Me.MenuStrip1.Enabled = True

    End Sub



    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        If MsgBox("คุณกำลังจะปิดโปรแกรม ดำเนินการต่อหรือไม่?", vbYesNo) = MsgBoxResult.Yes Then
            End
        End If
    End Sub




    Friend Sub ShowSearchEmpForm()
        If fSearchEmp Is Nothing Then
            fSearchEmp = New frmSearchEmployee
            m_ChildFormNumber += 1
        End If
        fSearchEmp.MdiParent = Me
        fSearchEmp.Show()
        fSearchEmp.WindowState = FormWindowState.Maximized
    End Sub

    Friend Sub ShowEmployeeForm()
        If fEmployee Is Nothing Then
            fEmployee = New frmAddUser
            m_ChildFormNumber += 1
        End If
        fEmployee.MdiParent = Me
        fEmployee.Show()
        fEmployee.WindowState = FormWindowState.Maximized
    End Sub

    Friend Sub ShowEmployeeForm(ByVal intEmpID As Integer)
        If fEmployee Is Nothing Then
            fEmployee = New frmAddUser
            m_ChildFormNumber += 1
        End If
        fEmployee.MdiParent = Me
        fEmployee.Show(intEmpID)
        fEmployee.WindowState = FormWindowState.Maximized
    End Sub

    Friend Sub ShowPositionsForm()
        If fPosition Is Nothing Then
            fPosition = New frmPosition
            m_ChildFormNumber += 1
        End If
        fPosition.MdiParent = Me
        fPosition.Show()
        fPosition.WindowState = FormWindowState.Maximized
    End Sub




    Private Sub mnuInventoryItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInventoryItems.Click
        ShowInventoryForm()
    End Sub
    Friend Sub ShowInventoryForm()
        If fInv Is Nothing Then
            fInv = New frmInventory
            m_ChildFormNumber += 1
        End If
        fInv.MdiParent = Me
        fInv.Show()
        fInv.WindowState = FormWindowState.Maximized
    End Sub



    Friend Sub ShowCategoryForm()
        If fMainCategory Is Nothing Then
            fMainCategory = New Category
            m_ChildFormNumber += 1
        End If
        fMainCategory.MdiParent = Me
        fMainCategory.Show()
        fMainCategory.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub mnuHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHoliday.Click
        ShowHolidayForm()
    End Sub

    Friend Sub ShowHolidayForm()
        If fHoliday Is Nothing Then
            fHoliday = New frmHoliday
            m_ChildFormNumber += 1
        End If
        fHoliday.MdiParent = Me
        fHoliday.Show()
        fHoliday.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub mnuPositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPositions.Click
        ShowPositionsForm()
    End Sub

    Private Sub mnuSearchEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchEmp.Click
        ShowSearchEmpForm()
    End Sub

    Private Sub mnuAddEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddEmployee.Click
        ShowEmployeeForm(0)
    End Sub

    Private Sub mnuMainCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainCategory.Click
        ShowCategoryForm()
    End Sub

    Private Sub mnuMyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMyData.Click
        ShowEmployeeForm(clsUtility.UserID)
    End Sub

    Private Sub mnuSalaryLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalaryLevel.Click
        ShowSalaryForm()
    End Sub


    Friend Sub ShowSalaryForm()
        If fSalaryLevel Is Nothing Then
            fSalaryLevel = New frmSalayLevel
            m_ChildFormNumber += 1
        End If
        fSalaryLevel.MdiParent = Me
        fSalaryLevel.Show()
        fSalaryLevel.WindowState = FormWindowState.Maximized
    End Sub

    'Test new MDIMain from
    Private Sub mnuTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNewMDIMain.Show()
    End Sub
End Class
