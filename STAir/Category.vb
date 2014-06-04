Imports System.Array
Imports System.Data


Public Class Category
    Private clsBCate As New clsBCategory
    Private Const intMaxLevel As Integer = clsUtility.MainCategoryMaxLevel
    Private Const intDummyCategoryIDFirstInsert As Integer = 0 ' will not be used with "Added" rowstat

    'Private Function IsLeafCategory() As Boolean
    '    If MessageBox.Show("Is this the last level Category?", "LeafCategory Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    Private Function verifyName(ByVal strName As String) As Boolean
        If strName.Length <= 2 Then
            MessageBox.Show("ยังไม่ได้ใส่ชื่อสถานที่", "กรุณาใส่ชื่อสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End If
        Return True
    End Function



    Private Function SaveCategory(ByVal intCateID As Integer, ByVal intLevel As Integer, ByVal intParentID As Integer, ByVal strRowState As String, ByVal intLeafCategory As Integer) As Integer
        ' Try


        Dim aryCategoryparam As New Dictionary(Of String, Object)
        '       @CategoryID		int,
        '       @CategoryLevel		int,
        '       @CategoryName	varchar(100),
        '       @CategoryNameEng	varchar(100),
        '       @CategoryParentID	int,
        '       @LeafCategory		int,
        '       @IsExpired		int,
        '       @IsVirtual		int,
        '       @Status		char(10),		
        '       @CategoryNote		nvarchar(250),
        '       @RowState		varchar(10)



        Dim DummyCategoryID As Integer = intCateID ' this not going to be actually used for insert
        Dim intCategoryLevel As Integer = intLevel

        Dim txtTH, txtENG As TextBox
        txtTH = CType(GetControl("TextBox" & intLevel), TextBox)
        txtENG = CType(GetControl("txtEng" & intLevel), TextBox)

        If verifyName(txtTH.Text) = False Then
            Exit Function
        End If
        Dim strCategoryName As String = txtTH.Text

        Dim objCategoryNameEng As Object
        If txtENG.Text.Length = 0 Then
            objCategoryNameEng = System.DBNull.Value
        Else
            objCategoryNameEng = txtENG.Text
        End If




        aryCategoryparam.Add("CategoryID", DummyCategoryID)
        aryCategoryparam.Add("CategoryLevel", intCategoryLevel)
        aryCategoryparam.Add("CategoryName", strCategoryName)
        aryCategoryparam.Add("CategoryNameEng", objCategoryNameEng)
        aryCategoryparam.Add("CategoryParentID", intParentID)


        aryCategoryparam.Add("LeafCategory", intLeafCategory)

        aryCategoryparam.Add("IsExpired", clsBCategory.enuCateIsExpired.notExpire)
        aryCategoryparam.Add("IsVirtual", clsBCategory.enuCateIsVirtual.NotVirtual)
        aryCategoryparam.Add("Status", clsBCategory.Cate_Status_Active)
        aryCategoryparam.Add("CategoryNote", "")
        aryCategoryparam.Add("RowState", strRowState)

        Dim intResult As Integer
        intResult = clsBCate.SaveCategory(aryCategoryparam)

        Return intResult
        ' Catch ex As Exception

        'Return clsBCategory.enuReturnErrorCode.ExcuteDataBaseError
        'End Try
    End Function

    Private Function GetControl(ByVal strName As String) As Control
        strName = LCase(strName)

        For Each ctr As Control In Me.Controls
            Dim subControl As Control = Nothing
            If ctr.HasChildren Then
                subControl = getSubControl(ctr, strName)
            End If

            If subControl Is Nothing Then
                If LCase(ctr.Name) = strName Then
                    Return ctr
                End If
            Else
                Return subControl
            End If
        Next
        Return Nothing
    End Function
    Private Function getSubControl(ByVal ctr As Control, ByVal strName As String) As Control
        Dim subControl As Control = Nothing

        For Each subCtr As Control In ctr.Controls
            If subCtr.HasChildren Then
                subControl = getSubControl(ctr, strName)
            End If

            If subControl Is Nothing Then
                If LCase(subCtr.Name) = strName Then
                    Return subCtr
                End If
            Else
                Return subControl
            End If
        Next

        Return Nothing
    End Function

    Private Sub BindList(ByVal intLevel As Integer, ByVal intParentID As Integer)
        If intLevel > intMaxLevel Then
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsBCate.RetriveCategoryLevel(intLevel, intParentID)

        Dim ListDummy As ListBox

        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)




        ListDummy.ValueMember = "CategoryID"
        ListDummy.DisplayMember = "DisplayCategoryName"

        ListDummy.DataSource = ds.Tables(0)

        ListDummy.SelectedIndex = -1

        If ListDummy.Items.Count > 0 Then
            ListDummy.SelectedIndex = 0
        End If




    End Sub

    Private Sub Category_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindList(1, 0)
        Dim clsData As New ClsDataSQL
        Dim str As String = clsData.CNS

    End Sub
    Private Sub ClearSubList(ByVal intParentLevel As Integer)
        If intParentLevel + 1 = intMaxLevel Then
            Exit Sub
        End If

        Dim intStartLevel As Integer
        intStartLevel = intParentLevel + 1
        For intStartLevel = intStartLevel To intMaxLevel
            Dim ListDummy As ListBox
            ListDummy = CType(GetControl("ListBox" & intStartLevel), ListBox)
            ListDummy.DataSource = Nothing
            intStartLevel += 1
        Next
    End Sub




    Private Sub StartEditCategory(ByVal intLevel As Integer)
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)


        If ListDummy.SelectedIndex < 0 Then
            MessageBox.Show("คุณต้องเลือกรายการสถานที่ ที่คุณต้องการแก้ไขจากรายการด้านล่างก่อน", "กรุณาเลือกรายการที่ต้องการแก้ไข", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If


        Dim txtTH, txtENG As TextBox
        txtTH = CType(GetControl("TextBox" & intLevel), TextBox)
        txtENG = CType(GetControl("txtEng" & intLevel), TextBox)

        If Not IsDBNull(ListDummy.SelectedItem("CategoryName")) Then
            txtTH.Text = ListDummy.SelectedItem("CategoryName")
        Else
            txtTH.Text = ""
        End If

        If Not IsDBNull(ListDummy.SelectedItem("CategoryNameEng")) Then
            txtENG.Text = ListDummy.SelectedItem("CategoryNameEng")
        Else
            txtENG.Text = ""
        End If

    End Sub



    Private Sub EditCategory(ByVal intLevel As Integer, ByVal intCategoryParentID As Integer)

        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        If ListDummy.SelectedIndices.Count = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("คุณกำลังแก้ไขรายการสถารที่?", "ดำเนินการค่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If


        Dim intRowUpdated As Integer
        intRowUpdated = SaveCategory(ListDummy.SelectedItem("CategoryID"), intLevel, ListDummy.SelectedItem("CategoryParentID"), clsBCategory.Cate_rowState_Modified, ListDummy.SelectedItem("LeafCategory"))

        If intRowUpdated = clsBCategory.enuReturnErrorCode.NoRowUpdated Then
            MessageBox.Show("ไม่มีการแก้ไขใดๆเกิดขึ้น อาจมีความผิดพลาด กรุณาลองอีกครั้ง", "แก้ไขไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        'Bind ListBox1
        BindList(intLevel, intCategoryParentID)
    End Sub
    Private Sub DeleteCategory(ByVal intLevel As Integer, ByVal intCategoryParentID As Integer)

        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        Dim intRowDeleted As Integer
        intRowDeleted = SaveCategory(ListDummy.SelectedItem("CategoryID"), intLevel, ListDummy.SelectedItem("CategoryParentID"), clsBCategory.Cate_rowState_Deleted, ListDummy.SelectedItem("LeafCategory"))

        If intRowDeleted = clsBCategory.enuReturnErrorCode.NoRowUpdated Then
            MessageBox.Show("ยังไม่มีการลบรายการใดๆ! อาจมีความผิดพลาด กรุณาลองใหม่อีกครั้ง", "ยังไม่ได้ลบรายการใด", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If


        BindList(intLevel, intCategoryParentID)
    End Sub



#Region "Level 1"
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        If ListBox1.Items.Count > 0 Then
            If ListBox1.SelectedItems.Count > 0 Then
                ClearSubList(1)
                BindList(2, ListBox1.SelectedItem("CategoryID"))
                StartEditCategory(1)
            End If
        End If
    End Sub


    Private Sub cmdEdit1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit1.Click

        EditCategory(1, 0)
    End Sub
    Private Sub cmdAdd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd1.Click
        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(0, 1, 0, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            'Bind ListBox1
            BindList(1, 0)
        End If

    End Sub
    Private Sub cmdDelete1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete1.Click
        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ 1 และ สถานที่ย่อยภายใต้สถานที่นี้?", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(1, 0)
    End Sub
#End Region

#Region "Level 2"
    Private Sub cmdAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd2.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 2


        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(intDummyCategoryIDFirstInsert, intLevel, intCategoryParentID, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            BindList(intLevel, intCategoryParentID)
        End If
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 2
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        ClearSubList(intLevel)

        If ListDummy.Items.Count > 0 Then
            If ListDummy.SelectedItems.Count > 0 Then
                BindList(intLevel + 1, ListDummy.SelectedItem("CategoryID"))
                StartEditCategory(intLevel)
            End If

        End If
    End Sub
    Private Sub cmdEdit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit2.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 2
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("แก้ไขสถานที่ลำดับที่ " & intLevel & " ที่คุณเลือกไว้?", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        EditCategory(intLevel, intCategoryParentID)
    End Sub
    Private Sub cmdDelete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete2.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 2
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ " & intLevel & " และรายการอื่นๆภายใต้สถานที่นี้? ", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(intLevel, intCategoryParentID)
    End Sub
#End Region

#Region "Level 3"
    Private Sub cmdAdd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd3.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 3


        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(intDummyCategoryIDFirstInsert, intLevel, intCategoryParentID, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            BindList(intLevel, intCategoryParentID)
        End If
    End Sub
    Private Sub cmdEdit3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit3.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 3
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("แก้ไขสถานที่ลำดับที่ " & intLevel & " ที่คุณเลือกไว้?", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        EditCategory(intLevel, intCategoryParentID)
    End Sub


    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 3
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        ClearSubList(intLevel)

        If ListDummy.Items.Count > 0 Then
            If ListDummy.SelectedItems.Count > 0 Then
                BindList(intLevel + 1, ListDummy.SelectedItem("CategoryID"))
                StartEditCategory(intLevel)
            End If

        End If
    End Sub
    Private Sub cmdDelete3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete3.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 3
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่  " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ " & intLevel & " และรายการอื่นๆภายใต้สถานที่นี้? ", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(intLevel, intCategoryParentID)
    End Sub
#End Region

#Region "Level 4"
    Private Sub cmdAdd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd4.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 4


        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(intDummyCategoryIDFirstInsert, intLevel, intCategoryParentID, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            BindList(intLevel, intCategoryParentID)
        End If
    End Sub

    Private Sub cmdEdit4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit4.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 4
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("แก้ไขสถานที่ลำดับที่ " & intLevel & "  ที่คุณเลือกไว้", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        EditCategory(intLevel, intCategoryParentID)
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 4
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        ClearSubList(intLevel)

        If ListDummy.Items.Count > 0 Then
            If ListDummy.SelectedItems.Count > 0 Then
                BindList(intLevel + 1, ListDummy.SelectedItem("CategoryID"))
                StartEditCategory(intLevel)
            End If

        End If
    End Sub
    Private Sub cmdDelete4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete4.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 4
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ " & intLevel & " และรายการอื่นๆภายใต้สถานที่นี้? ", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(intLevel, intCategoryParentID)
    End Sub
#End Region

#Region "Level 5"
    Private Sub cmdAdd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd5.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 5


        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(intDummyCategoryIDFirstInsert, intLevel, intCategoryParentID, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            BindList(intLevel, intCategoryParentID)
        End If
    End Sub

    Private Sub cmdEdit5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit5.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 5
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("แก้ไขสถานที่ลำดับที่ " & intLevel & "  ที่คุณเลือกไว้", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        EditCategory(intLevel, intCategoryParentID)
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox5.SelectedIndexChanged
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 5
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        ClearSubList(intLevel)

        If ListDummy.Items.Count > 0 Then
            If ListDummy.SelectedItems.Count > 0 Then
                BindList(intLevel + 1, ListDummy.SelectedItem("CategoryID"))
                StartEditCategory(intLevel)
            End If

        End If
    End Sub
    Private Sub cmdDelete5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete5.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 5
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ " & intLevel & " และรายการอื่นๆภายใต้สถานที่นี้? ", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(intLevel, intCategoryParentID)
    End Sub
#End Region

#Region "Level 6"
    Private Sub cmdAdd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd6.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 6


        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        Dim intNewCateID As Integer
        intNewCateID = SaveCategory(intDummyCategoryIDFirstInsert, intLevel, intCategoryParentID, clsBCategory.Cate_rowState_Added, clsBCategory.enuLeafCategory.Yes)

        If intNewCateID > 0 Then
            BindList(intLevel, intCategoryParentID)
        End If
    End Sub

    Private Sub cmdEdit6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit6.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 6
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("แก้ไขสถานที่ลำดับที่ " & intLevel & "  ที่คุณเลือกไว้", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        EditCategory(intLevel, intCategoryParentID)
    End Sub

    Private Sub ListBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox6.SelectedIndexChanged
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 6
        Dim ListDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)

        ClearSubList(intLevel)

        If ListDummy.Items.Count > 0 Then
            If ListDummy.SelectedItems.Count > 0 Then
                BindList(intLevel + 1, ListDummy.SelectedItem("CategoryID"))
                StartEditCategory(intLevel)
            End If

        End If
    End Sub
    Private Sub cmdDelete6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete6.Click
        ' this sub work for all level , all you have to do is just change 
        ' intLevel to the level you are working on

        Dim intLevel As Integer = 6
        Dim ListDummy, listParentDummy As ListBox
        ListDummy = CType(GetControl("ListBox" & intLevel), ListBox)
        listParentDummy = CType(GetControl("ListBox" & intLevel - 1), ListBox)

        Dim intCategoryParentID As Integer
        If listParentDummy.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานที่ลำดับที่ " & intLevel - 1 & " ก่อน", "ยังไม่ได้เลือกสถานที่", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        intCategoryParentID = listParentDummy.SelectedItem("CategoryID")

        If MessageBox.Show("ลบรายการสถานที่ลำดับที่ " & intLevel & " และรายการอื่นๆภายใต้สถานที่นี้? ", "ดำเนินการต่อหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        DeleteCategory(intLevel, intCategoryParentID)
    End Sub
#End Region


#Region "KeyBoard Layout"

    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter, TextBox2.Enter, TextBox3.Enter, TextBox4.Enter, TextBox5.Enter, TextBox6.Enter
        If Me.chkIsAutoChangeKeyBoardLayout.Checked = True Then
            Me.SetCurrentLanguageAsThai()
        End If
    End Sub

    Private Sub txtEng_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEng1.Enter, txtEng2.Enter, txtEng3.Enter, txtEng4.Enter, txtEng5.Enter, txtEng6.Enter
        Me.SetCurrentLanguageAsEnglish()
    End Sub

    Private Sub SetCurrentLanguageAsThai()
        ' Dim lang As InputLanguage
        Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub
    Private Sub SetCurrentLanguageAsEnglish()
        ' Dim lang As InputLanguage
        Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        InputLanguage.CurrentInputLanguage = myDefaultLanguage
        'InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
    End Sub
#End Region




    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("คุณแน่ใจหรือไม่ว่าจะปิดโปรแกรม?", "ปิด?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Application.Exit()
    End Sub


End Class
