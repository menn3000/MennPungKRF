Imports System.Data.SqlClient

Public Class frmInventory

    Private cls As New clsDataSQL
    Private clsCustomPemission As New clsPermission
    Dim DS As New DataSet


    Private Sub frmPosition_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMainData()
        GetAllInventories()
    End Sub

    Private Sub GetAllInventories()
        Dim strSQL As String

        strSQL = "Select * from tblInventories order by InvCode, InvName, Brand, Model, size"

        Dim dtb As New DataSet

        dtb = cls.DB_GetDataSet(strSQL, "tblInventories")
        grdInv.DataSource = dtb

        If grdInv.Rows.Count > 0 Then
            rblUpdateMode.Checked = True
            grdInv.ActiveRow = grdInv.Rows(0)
        End If

    End Sub
    Private Sub LoadMainData()

        Dim sql(6) As String
        Dim tbl(6) As String
        Dim strSQL As String = ""

        sql(0) = "Select  * "
        sql(0) += " from  tblInvCategory "
        sql(0) += " order by InvCategoryName"

        tbl(0) = "tblInvCategory"

        '----------------AUTO COMPLETE SOURCES--------------------------------

        sql(1) = "Select distinct InvCode as data from tblInventories  "
        tbl(1) = "InvCode"


        strSQL = "Select distinct InvName as data  from tblInventories "
        sql(2) = strSQL
        tbl(2) = "InvName"

        strSQL = "Select distinct Brand as data  from tblInventories  "
        sql(3) = strSQL
        tbl(3) = "Brand"

        strSQL = "Select distinct Model as data from tblInventories "
        sql(4) = strSQL
        tbl(4) = "Model"

        strSQL = "Select distinct Size as data from tblInventories "
        sql(5) = strSQL
        tbl(5) = "Size"


      
        '----------------------------------------


        DS = cls.DB_GetDataSet_MultiTable(sql, tbl, False)

        sql = Nothing
        tbl = Nothing


        Me.cboInvCategory.DisplayMember = "InvCategoryName"
        cboInvCategory.ValueMember = "ID"
        Me.cboInvCategory.DataSource = DS.Tables("tblInvCategory")
        cboInvCategory.SelectedIndex = -1


        If DS.Tables("tblInvCategory").Rows.Count = 0 Then
            MsgBox("ยังไม่มีหมวดหมู่ของวัสดุอยู่ในระบบ กรุณาสร้างอย่างน้อย 1 หมวดหมู่ ", MsgBoxStyle.Information)
        End If



        SetAutoCompleteSource(txtInvCode, DS.Tables("InvCode"))
        SetAutoCompleteSource(txtInvName, DS.Tables("InvName"))
        SetAutoCompleteSource(txtInvBrand, DS.Tables("Brand"))
        SetAutoCompleteSource(txtInvModel, DS.Tables("Model"))
        SetAutoCompleteSource(txtInvSize, DS.Tables("Size"))
      

    End Sub
    Private Sub SetAutoCompleteSource(ByVal txt As TextBox, ByVal dtbData As DataTable)

        Dim source As New AutoCompleteStringCollection()

        Dim tr As DataRow
        Dim lstTemp As New List(Of String)
        For Each tr In dtbData.Rows
            If Not IsDBNull(tr("data")) Then
                lstTemp.Add(tr("data"))
            End If
        Next

        source.AddRange(lstTemp.ToArray)
        txt.AutoCompleteCustomSource = source
        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub

    Private Sub grdInv_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInv.AfterRowActivate

        If rblUpdateMode.Checked = True Then
            DisPlayInventoryInfoForEdit()
        End If


    End Sub
    Private Sub grdInv_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdInv.BeforeCellUpdate
        e.Cancel = True
    End Sub

    Private Sub grdInv_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdInv.InitializeLayout
        grdInv.DisplayLayout.AutoFitColumns = True


        grdInv.DisplayLayout.Bands(0).Columns("InvCode").Header.Caption = "รหัสวัสดุ"
        grdInv.DisplayLayout.Bands(0).Columns("InvName").Header.Caption = "ชื่อวัสดุ"
        'grdInv.DisplayLayout.Bands(0).Columns("Brand").Header.Caption = "ยี่ห้อ"
        'grdInv.DisplayLayout.Bands(0).Columns("Model").Header.Caption = "รุ่น"


        grdInv.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grdInv.DisplayLayout.Bands(0).Columns("InvCategoryID").Hidden = True
        grdInv.DisplayLayout.Bands(0).Columns("Description").Hidden = True
        grdInv.DisplayLayout.Bands(0).Columns("Size").Hidden = True
        grdInv.DisplayLayout.Bands(0).Columns("Model").Hidden = True
        grdInv.DisplayLayout.Bands(0).Columns("Brand").Hidden = True



    End Sub

    Private Sub DisPlayInventoryInfoForEdit()

        txtInvCode.Text = CheckDBNull(Me.grdInv.ActiveRow.Cells("InvCode").Value)
        txtInvName.Text = Me.grdInv.ActiveRow.Cells("InvName").Value
        txtInvBrand.Text = Me.grdInv.ActiveRow.Cells("Brand").Value
        txtInvModel.Text = Me.grdInv.ActiveRow.Cells("Model").Value
        txtInvSize.Text = Me.grdInv.ActiveRow.Cells("Size").Value
        txtinvDesc.Text = CheckDBNull(Me.grdInv.ActiveRow.Cells("Description").Value)
        cboInvCategory.SelectedValue = Me.grdInv.ActiveRow.Cells("InvCategoryID").Value
        rblUpdateMode.Checked = True
    End Sub
   
    Private Function CheckDBNull(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            Return obj
        End If
    End Function
    Private Sub ClearForm()
        txtInvCode.Text = ""
        txtInvName.Text = ""
        txtInvBrand.Text = ""
        txtInvModel.Text = ""
        txtInvSize.Text = ""
        txtinvDesc.Text = ""
        cboInvCategory.SelectedIndex = -1


    End Sub
    Private Sub rblAddNewMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAddNewMode.CheckedChanged
        If rblAddNewMode.Checked = True Then
            grdInv.ActiveRow = Nothing
            ClearForm()
            txtInvCode.Select()

        End If
    End Sub


    Private Sub rblUpdateMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblUpdateMode.CheckedChanged
        If rblUpdateMode.Checked = True Then
            If grdInv.Rows.Count > 0 Then
                grdInv.ActiveRow = grdInv.Rows(0)
            Else
                MsgBox("ยังไม่มีวัสดุใดๆในระบบ กรุณาเพิ่มวัสดุในระบบก่อน", vbQuestion)
            End If

        End If
    End Sub

    Private Sub rblSearchMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSearchMode.CheckedChanged
        If rblSearchMode.Checked = True Then
            grdInv.ActiveRow = Nothing
            ClearForm()
            cmdSearch.Visible = True
        Else
            cmdSearch.Visible = False
        End If
    End Sub

    Private Sub grdInv_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdInv.InitializeRow
        e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveData()
    End Sub

  
    Private Sub SaveData()
        If grdInv.ActiveRow Is Nothing Then
            SaveNewInv()
        Else
            UpdatedRecord(Me.grdInv.ActiveRow.Cells("ID").Value)
        End If
    End Sub
    Private Sub UpdatedRecord(ByVal intInvID As Integer)
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedInv(txtInvName.Text, "InvName", intInvID) = True Then
            Exit Sub
        End If
        If checkISExistedInv(txtInvCode.Text, "InvCode", intInvID) = True Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            strSQL = "Update tblInventories Set  "
            strSQL += " InvName = '" & txtInvName.Text & "'"
            strSQL += " ,InvCode = '" & txtInvCode.Text & "'"
            strSQL += " ,InvCategoryID = " & cboInvCategory.SelectedValue.ToString
            strSQL += " ,Brand = '" & txtInvBrand.Text & "'"
            strSQL += " ,Model = '" & txtInvModel.Text & "'"
            strSQL += " ,Size = '" & txtInvSize.Text & "'"
            strSQL += " ,Description = '" & txtinvDesc.Text & "'"
            strSQL += " Where ID = " & intInvID.ToString

            If cls.ExcuteData(strSQL, clsUtility.UserID) = True Then
                MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
                LoadMainData()
                GetAllInventories()
            End If

        Catch ex As Exception
            MsgBox("มีความผิดพลาดเกิดขึ้น ตำแหน่งนี้ยังไม่ถูกแก้ไข " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        End Try



    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        SearchInventory()
    End Sub
    Private Function checkISExistedInv(ByVal strInvValue As String, ByVal FieldName As String, Optional ByVal intUpdatingInvID As Integer = 0) As Boolean

        Dim strSQL As String = "Select * from tblInventories "
        strSQL += "  where " & FieldName & " = '" & strInvValue & "'"

        If intUpdatingInvID > 0 Then
            strSQL += " and ID <> " & intUpdatingInvID.ToString
        End If

        Dim dr As SqlDataReader
        dr = cls.DB_GetDataReader(strSQL)
        If dr.Read Then
            Dim msg As String = "ชื่อวัสดุนี้ซ้ำกับ วัสดุที่มีอยู่แล้ว กรุณาตรวจสอบ" & vbCrLf & "ชื่อในระบบ คือ" & dr(FieldName)
            dr.Close()
            MsgBox(msg, MsgBoxStyle.Critical)
            Return True
        Else
            dr.Close()
        End If
        Return False
    End Function
    Private Sub SaveNewInv()
        If verifyInput() = False Then
            Exit Sub
        End If
        If checkISExistedInv(txtInvName.Text, "InvName") = True Then
            Exit Sub
        End If
        If checkISExistedInv(txtInvCode.Text, "InvCode") = True Then
            Exit Sub
        End If

        Dim objConn As New SqlConnection(clsUtility.LiveCNS)
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        ' Make the transaction.
        Dim trans As SqlTransaction = _
            objConn.BeginTransaction(IsolationLevel.ReadCommitted)


        Dim cmd As New SqlCommand
        cmd.Connection = objConn
        cmd.Transaction = trans
        cmd.CommandTimeout = 0

        Dim intNewInvID As Int64 = 0
        Dim strSQL As String = ""


        Try
            cmd.CommandText = GetInsertInvSQL()
            ' Execute the command.
            cmd.ExecuteNonQuery()
            'Get New ID just inserted
            cmd.CommandText = "Select @@Identity"
            intNewInvID = Int64.Parse(cmd.ExecuteScalar())
            trans.Commit()

        Catch ex As Exception
            trans.Rollback()
            MsgBox("มีความผิดพลาดเกิดขึ้น วัสดุนี้ยังไม่ถูกบันทึก " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            clsDataSQL.WriteLog("Error: " & vbCrLf & ex.StackTrace, ex.Message)
        Finally
            If Not objConn.State = ConnectionState.Closed Then objConn.Close()
        End Try

        If intNewInvID > 0 Then
            MsgBox("บันทึกข้อมูลเรียบร้อยแล้ว", vbInformation)
            LoadMainData()
            GetAllInventories()
        End If


    End Sub
    Private Function GetInsertInvSQL() As String
        Dim strSQL As String
        strSQL = "Insert into tblInventories (InvCode, InvName,Brand,Model,Size,Description,InvCategoryID"
        strSQL += ") values ("
        strSQL += "'" & txtInvCode.Text & "',"
        strSQL += "'" & txtInvName.Text & "',"
        strSQL += "'" & txtInvBrand.Text & "',"
        strSQL += "'" & txtInvModel.Text & "',"
        strSQL += "'" & txtInvSize.Text & "',"
        strSQL += "'" & txtinvDesc.Text & "',"
        strSQL += cboInvCategory.SelectedValue.ToString
        strSQL += ")"

        Return strSQL
    End Function
    Private Function verifyInput() As Boolean

        Me.txtInvName.Text = Trim(Replace(txtInvName.Text, Chr(39), Chr(146)))
        Me.txtInvCode.Text = Trim(Replace(txtInvCode.Text, Chr(39), Chr(146)))


        If txtInvName.Text.Length = 0 Then
            MsgBox("กรุณาใส่ชื่อวัสดุ", vbCritical)
            Return False
        End If

        If txtInvCode.Text.Length = 0 Then
            MsgBox("กรุณาใส่รหัสวัสดุ", vbCritical)
            Return False
        End If

        If cboInvCategory.SelectedIndex = -1 Then
            MsgBox("กรุณาเลือก หมวดหมู่", vbCritical)
            cboInvCategory.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub SearchInventory()

        Me.Cursor = Cursors.WaitCursor

        Dim aryCMD As New List(Of SqlCommand)
        Dim strSQL As String = ""
        Dim strWhere As String = ""
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text


        If txtInvCode.Text.Trim() <> "" Then
            strWhere = " i.InvCode like '%' + @InvCode + '%'"
            cmd.Parameters.AddWithValue("@InvCode", txtInvCode.Text.Trim())
        End If

        If txtInvName.Text.Trim() <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.InvName like '%' + @InvName + '%'"
            cmd.Parameters.AddWithValue("@InvName", txtInvName.Text.Trim())
        End If

        If cboInvCategory.Text <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.InvCategoryID =@InvCategoryID"
            cmd.Parameters.AddWithValue("@InvCategoryID", cboInvCategory.SelectedValue.ToString)
        End If
        ',,,,
        If txtInvBrand.Text.Trim() <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.Brand like '%' + @Brand + '%'"
            cmd.Parameters.AddWithValue("@Brand", txtInvBrand.Text.Trim())
        End If

        If txtInvModel.Text.Trim() <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.Model like '%' + @Model + '%'"
            cmd.Parameters.AddWithValue("@Model", txtInvModel.Text.Trim())
        End If

        If txtInvSize.Text.Trim() <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.Size like '%' + @Size + '%'"
            cmd.Parameters.AddWithValue("@Size", txtInvSize.Text.Trim())
        End If

        If txtinvDesc.Text.Trim() <> "" Then
            strWhere += IIf(strWhere <> "", " and ", "")
            strWhere += " i.Description like '%' + @Description + '%'"
            cmd.Parameters.AddWithValue("@Description", txtinvDesc.Text.Trim())
        End If
        strSQL = "Select * from tblInventories i"
        strSQL += IIf(strWhere.Length > 0, " where " & strWhere, "")
        strSQL += " order by i.InvCode"

        cmd.CommandText = strSQL

        aryCMD.Add(cmd)



        Dim tbl(1) As String


        tbl(0) = "tblInventories"


        Dim dsGrid As New DataSet
        dsGrid = cls.DB_GetDataSet_MultiTableWithParams(aryCMD, tbl)

        If dsGrid.Tables("tblInventories").Rows.Count = 0 Then

            Me.grdInv.DataSource = Nothing
            MsgBox("สิ้นสุดการค้นหา ไม่พบวัสดุ ตรงตามข้อมูลที่คุณหา", MsgBoxStyle.Information)
            Me.grdInv.Visible = False
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If


        Me.grdInv.DataSource = dsGrid
        Me.grdInv.Visible = True

        Me.grdInv.ActiveRow = Nothing

        Me.Cursor = Cursors.Arrow
    End Sub
End Class