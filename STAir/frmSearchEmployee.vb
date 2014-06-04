Imports System.Data.SqlClient

Public Class frmSearchEmployee
    Private cls As New clsDataSQL

    Private fMain As frmMDIMain
    Private EmpPositionRecordsLatestTime As DateTime = Now
    Private clsCate As New clsBCategory

    Private Sub LoadPositions()
        'ok
        Dim strSQL As String = ""

        strSQL = "Select * "
        strSQL += " from tblPositions "
        strSQL += " where (L2CategoryID = " & clsUtility.UserLevel2Category.ToString
        strSQL += " Or L2CategoryID = 0 "
        strSQL += " Or DefaultAdminModuleLevel = " & clsPermission.enuPerMission.ExecutiveViewer & ")"
        strSQL += " order by PositionName"



        Dim dtbCategory As New System.Data.DataTable("tblPositions")
        Dim dsCate As New DataSet

        dsCate = cls.DB_GetDataSet(strSQL, "tblPositions", False)
        AddSelectAllOnTop(dsCate.Tables("tblPositions"), "PositionAbv")


        Me.cboPosition.DisplayMember = "PositionAbv"
        cboPosition.ValueMember = "ID"
        Me.cboPosition.DataSource = dsCate.Tables("tblPositions")

        cboPosition.SelectedIndex = 0

        EmpPositionRecordsLatestTime = Now

    End Sub

    Private Sub AddSelectAllOnTop(ByRef dtb As DataTable, ByVal txtColumnName As String)
        Dim tr As DataRow
        tr = dtb.NewRow
        tr("ID") = 0
        tr(txtColumnName) = "ทั้งหมด"
        dtb.Rows.InsertAt(tr, 0)


    End Sub

    Private Sub frmSearchEmployee_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If EmpPositionRecordsLatestTime < clsUtility.PositionRecordsLatestTime Then
            LoadPositions()
        End If
    End Sub

    Private Sub frmSearchEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fMain = Me.ParentForm
        LoadPositions()

        txtMainCategoryID.Text = clsUtility.UserMainCategory.ToString
        lblBreadCrumb.Text = clsCate.RetriveCategoryBreadCrumb(clsUtility.UserMainCategory, True)
    End Sub

    Private Sub cboPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosition.SelectedIndexChanged
        If cboPosition.SelectedIndex = 0 Then
            Exit Sub
        End If
    End Sub



    Private Sub SearchEmployee()

        Me.Cursor = Cursors.WaitCursor

        Dim aryCMD As New List(Of SqlCommand)
        Dim strSQL As String = ""

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text



        strSQL += "Select  e.EmployeeID, c.CategoryName , p.PositionAbv + ' ' + e.FName + ' ' + e.LName as FullName  "
        strSQL += " ,e.Email, e.MobilePhone , e.ID, e.CurrentPositionID as PID"
        strSQL += " from tblEmployees e, tblPositions p, Category c "

        strSQL += " where e.[CurrentPositionID] = p.[ID] "
        strSQL += " and c.CategoryID  = e.MainCategory "

        If IsNumeric(txtMainCategoryID.Text) Then
            strSQL += " and e.MainCategory in (Select CategoryID from fnGetChildsCategoryIDs_All_Subs(@CategoryID) "
            If clsPermission.CheckWhatUserCanDO(clsUtility.DefaultAdminModuleLevel) >= clsPermission.WhatUserCanDo.CanWrite Then
                strSQL += " union Select CategoryID from fnGetParentsCategory(0,@CategoryID) "
            End If
            strSQL += ") "
            cmd.Parameters.AddWithValue("@CategoryID", CInt(txtMainCategoryID.Text))
        End If

        If cboPosition.SelectedIndex > 0 Then
            strSQL += " and e.[CurrentPositionID] = @CurrentPositionID"
            cmd.Parameters.AddWithValue("@CurrentPositionID", cboPosition.SelectedValue)
        End If

        If txtEmployeeID.Text.Length > 0 Then
            strSQL += " and e.[EmployeeID] like '%' + @EmployeeID + '%' "
            cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text)
        End If

        If txtFName.Text.Length > 0 Then
            strSQL += " and e.[fName] like '%' + @FName + '%' "
            cmd.Parameters.AddWithValue("@FName", txtFName.Text)
        End If

        If txtLName.Text.Length > 0 Then
            strSQL += " and e.[LName] like '%' + @LName + '%' "
            cmd.Parameters.AddWithValue("@LName", txtLName.Text)
        End If

        strSQL += " order by c.CategoryLevel, p.positionAbv, e.Fname"

        cmd.CommandText = strSQL

        aryCMD.Add(cmd)
    


        Dim tbl(1) As String


        tbl(0) = "tblEmployees"


        Dim dsGrid As New DataSet
        dsGrid = cls.DB_GetDataSet_MultiTableWithParams(aryCMD, tbl)

        ' ''Dim Keys(0) As DataColumn

        ' ''Keys(0) = dsGrid.Tables("tblInvoices").Columns("ID")
        ' ''dsGrid.Tables("tblInvoices").PrimaryKey = Keys

        ' ''Dim Keys2(1) As DataColumn
        ' ''Keys2(0) = dsGrid.Tables("tblInvoicePayments").Columns("ID")
        ' ''Keys2(1) = dsGrid.Tables("tblInvoicePayments").Columns("InvoiceID")
        ' ''dsGrid.Tables("tblInvoicePayments").PrimaryKey = Keys2



        ' ''Dim relInvPayments As New DataRelation("Rel1" _
        ' '', dsGrid.Tables("tblInvoices").Columns("ID") _
        ' '', dsGrid.Tables("tblInvoicePayments").Columns("InvoiceID"))
        ' ''dsGrid.Relations.Add(relInvPayments)



        If dsGrid.Tables("tblEmployees").Rows.Count = 0 Then

            Me.grdEmployees.DataSource = Nothing
            MsgBox("สิ้นสุดการค้นหา ไม่พบพนักงาน ตรงตามข้อมูลที่คุณหา", MsgBoxStyle.Information)
            Me.grdEmployees.Visible = False
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If


        Me.grdEmployees.DataSource = dsGrid
        Me.grdEmployees.Visible = True



        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub grdEmployees_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdEmployees.BeforeCellActivate
        If Not e.Cell.Column.Key = "Select" Then
            e.Cell.Column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Else
            e.Cell.Column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
    End Sub



    Private Sub grdEmployees_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdEmployees.BeforeCellUpdate
        'If Not e.Cell.Column.Key = "Select" Then
        '    e.Cancel = True
        'End If

    End Sub

    Private Sub grdEmployees_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEmployees.InitializeLayout

        Try
            grdEmployees.DisplayLayout.Bands(0).Columns.Add("Select").DataType = GetType(Boolean)
            grdEmployees.DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            grdEmployees.DisplayLayout.Bands(0).Columns("Select").Header.VisiblePosition = 0
        Catch ex As Exception
        End Try


        grdEmployees.DisplayLayout.AutoFitColumns = True

        grdEmployees.DisplayLayout.Bands(0).Columns("EmployeeID").Header.Caption = "รหัสพนักงาน"
        grdEmployees.DisplayLayout.Bands(0).Columns("FullName").Header.Caption = "ชื่อ"
        grdEmployees.DisplayLayout.Bands(0).Columns("Email").Header.Caption = "อีเมล์"
        grdEmployees.DisplayLayout.Bands(0).Columns("MobilePhone").Header.Caption = "มือถือ"
        grdEmployees.DisplayLayout.Bands(0).Columns("CategoryName").Header.Caption = "สังกัด"



        'grdEmployees.DisplayLayout.Bands(0).Columns("Select").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit


        With Me.grdEmployees.DisplayLayout


            .Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free

            Dim col As Infragistics.Win.UltraWinGrid.UltraGridColumn
            For Each col In Me.grdEmployees.DisplayLayout.Bands(0).Columns
                If col.Key = "FullName" Then
                    col.Width = (grdEmployees.Width * 0.25)
                End If
            Next

            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("PID").Hidden = True

            '.Bands(0).Columns("EmployeeID").Width = (grdEmployees.Width * 15) / 100
            '.Bands(0).Columns("FullName").Width = (grdEmployees.Width * 25) / 100
            '.Bands(0).Columns("email").Width = (grdEmployees.Width * 25) / 100
            '.Bands(0).Columns("MobilePhone").Width = (grdEmployees.Width * 35) / 100


            .Bands(0).Override.DefaultRowHeight = 30

        End With

        'Me.grdEmployees.DisplayLayout.Bands(0).Columns("FullName").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
        'Me.grdEmployees.DisplayLayout.Bands(0).Columns("FullName").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

        Dim oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn
        For Each oColumn In Me.grdEmployees.DisplayLayout.Bands(0).Columns
            oColumn.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Next



        ' ''Try
        ' ''    grdEmployees.DisplayLayout.Bands(0).Columns.Add("Select").DataType = GetType(Boolean)
        ' ''    grdEmployees.DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        ' ''    grdEmployees.DisplayLayout.Bands(0).Columns("Select").Header.VisiblePosition = 0
        ' ''Catch ex As Exception

        ' ''End Try
        'e.Layout.Bands(0).Columns("Amount").Format = "฿#,##0.00"
    End Sub

    Private Sub grdEmployees_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdEmployees.InitializeRow
        'Select Case e.Row.Band.Index
        '    Case 0
        '        e.Row.Expanded = False
        '    Case 1
        '        e.Row.Expanded = True
        '        e.Row.Appearance.BackColor = Color.PaleVioletRed
        '        e.Row.Appearance.ForeColor = Color.White

        'End Select
    End Sub

    Private Sub cmdAddNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewEmployee.Click
        fMain.ShowEmployeeForm(0)
    End Sub

    Private Sub cmdViewEmpDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewEmpDetail.Click

        Dim i As Integer
        Dim counter As Integer = 0
        For i = grdEmployees.Rows.Count - 1 To 0 Step -1

            If grdEmployees.Rows(i).Cells("Select").Value = True Then
                counter += 1
                'set active row to the first row that is checked
                ' we step -1 so it is the last one in the loop
                grdEmployees.ActiveRow = grdEmployees.Rows(i)
            End If
        Next

        If counter > 1 Then
            MsgBox("คุณกาถูกเลือกพนักงานมากกว่า 1 คน ระบบจะแสดงรายละเอียดของพนักงานคนแรกที่คุณเลือกเท่านั้น", vbInformation)
        End If

        If Not grdEmployees.ActiveRow Is Nothing Then
            fMain.ShowEmployeeForm(grdEmployees.ActiveRow.Cells("ID").Value)
        Else
            MsgBox("คุณต้องเลือกพนักงานจากผลการค้าหาก่อน ถึงจะสามารถดูรายละเอียดพนักงานได้", vbInformation)
            Exit Sub
        End If

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        SearchEmployee()
    End Sub


    Private Sub cmdBreadCrumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBreadCrumb.Click


        If Not dgMainCategory.ShowDialog(Me, "") = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtMainCategoryID.Text = dgMainCategory.SelectedCategoryID
        lblBreadCrumb.Text = dgMainCategory.BreadCum
    End Sub


    Private Sub BatchAddWorkLog()
        Me.Cursor = Cursors.WaitCursor


        Dim i, counter As Integer
        Dim ary As New ArrayList


        For i = 0 To grdEmployees.Rows.Count - 1
            If grdEmployees.Rows(i).Cells("Select").Value = True Then
                counter += 1
                Dim intEmpID As Integer = grdEmployees.Rows(i).Cells("ID").Value
                ary.Add(intEmpID)
            End If
        Next

        If counter = 0 Then
            If Not grdEmployees.ActiveRow Is Nothing Then
                ary.Add(grdEmployees.ActiveRow.Cells("ID").Value)
            Else
                Me.Cursor = Cursors.Arrow
                MsgBox("คุณต้องเลือกพนักงานจากผลการค้าหาก่อน ถึงจะสามารถทำรายการนี้ได้", vbInformation)
                Exit Sub
            End If
        End If

        Me.Cursor = Cursors.Arrow

        If Not dgEmpWorkLog.ShowDialog(Me, ary) = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        'txtMainCategoryID.Text = dgMainCategory.SelectedCategoryID
        'lblBreadCrumb.Text = dgMainCategory.BreadCum

    End Sub

    Private Sub cmdAddWorkLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddWorkLog.Click
        BatchAddWorkLog()
    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        Dim i As Integer
        For i = grdEmployees.Rows.Count - 1 To 0 Step -1
            grdEmployees.ActiveRow = grdEmployees.Rows(i)
            grdEmployees.Rows(i).Cells("Select").Value = chkCheckAll.Checked

        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub
End Class