Imports System.Windows.Forms

Public Class dgMainCategory

    Private clsBCate As New clsBCategory
    Private Const intMaxLevel As Integer = clsUtility.MainCategoryMaxLevel
    Private Const intDummyCategoryIDFirstInsert As Integer = 0 ' will not be used with "Added" rowstat

    Private bolPendingClearSubList As Boolean = False


    Private intSelectedCategoryID As Integer
    Public Property SelectedCategoryID() As Integer
        Get
            Return intSelectedCategoryID
        End Get
        Set(ByVal value As Integer)
            intSelectedCategoryID = value
        End Set
    End Property
    Private strBreadCum As String
    Public Property BreadCum() As String
        Get
            Return strBreadCum
        End Get
        Set(ByVal value As String)
            strBreadCum = value
        End Set
    End Property
    Private strSelectedCategoryName As String
    Public Property SelectedCategoryName() As String
        Get
            Return strSelectedCategoryName
        End Get
        Set(ByVal value As String)
            strSelectedCategoryName = value
        End Set
    End Property





    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        GetSelectedCategoryID()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.SelectedCategoryID = 0

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' Private strExistedBreadCrumb As String
    Private strExistedBreadCrumb As String()
    Friend Overloads Function ShowDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal strBreadCrumb As String) As System.Windows.Forms.DialogResult

        'If strBreadCrumb Is Nothing Then
        '    strBreadCrumb = ""
        'End If
        strExistedBreadCrumb = strBreadCrumb.Split("/")
        Return ShowDialog(owner)

    End Function


    Private Sub dgMainCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindList(1, 0)


        SelectMyParentCategory()


    End Sub

    Private Sub SelectMyParentCategory()

        ListBox1.Enabled = True
        ListBox2.Enabled = True
        ListBox3.Enabled = True
        ListBox4.Enabled = True
        ListBox5.Enabled = True
        ListBox6.Enabled = True


        Dim ds As DataSet
        ds = clsBCate.RetriveCategoryParent(clsUtility.UserMainCategory, True)
        Dim ListDummy As ComboBox

        Dim dtb As DataTable = ds.Tables(0)
        Dim BolFoundTopLevelAllow As Boolean = False
        For Each tr As DataRow In dtb.Rows
            ListDummy = CType(GetControl("ListBox" & tr("CategoryLevel")), ComboBox)
            ListDummy.SelectedValue = tr("CategoryID")
            If clsPermission.CheckWhatUserCanDO(clsUtility.DefaultAdminModuleLevel) < clsPermission.WhatUserCanDo.CanDoAnything Then
                ListDummy.Enabled = False
            End If

            If clsPermission.CheckWhatUserCanDO(clsUtility.DefaultAdminModuleLevel) >= clsPermission.WhatUserCanDo.CanRead Then
                If tr("CategoryID") = clsUtility.UserLevel2Category Then
                    BolFoundTopLevelAllow = True
                    GoTo NextLevel
                End If
                If BolFoundTopLevelAllow = True Then
                    ListDummy.Enabled = True
                End If
            End If
NextLevel:
            Application.DoEvents()
        Next
    End Sub

    Private Sub BindList(ByVal intLevel As Integer, ByVal intParentID As Integer)
        If intLevel > intMaxLevel Then
            Exit Sub
        End If



        Dim ds As DataSet
        ds = clsBCate.RetriveCategoryLevel(intLevel, intParentID)

        Dim ListDummy As ComboBox

        ListDummy = CType(GetControl("ListBox" & intLevel), ComboBox)


        ListDummy.ValueMember = "CategoryID"
        ListDummy.DisplayMember = "DisplayCategoryName"

        ListDummy.DataSource = ds.Tables(0)
        ListDummy.SelectedIndex = -1

        Try
            ListDummy.SelectedIndex = ListDummy.FindString(Trim(strExistedBreadCrumb(intLevel - 1)))

        Catch ex As Exception

        End Try




       
    End Sub
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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ListBox1.SelectedIndexChanged, ListBox2.SelectedIndexChanged _
        , ListBox3.SelectedIndexChanged, ListBox4.SelectedIndexChanged _
        , ListBox5.SelectedIndexChanged, ListBox6.SelectedIndexChanged


        If bolPendingClearSubList = True Then
            Exit Sub
        End If

        Dim ListDummy As ComboBox
        ListDummy = DirectCast(sender, ComboBox)

        If ListDummy.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim intCurrentLevel As Integer = CInt(ListDummy.Tag)
        ClearSubList(intCurrentLevel)

        If ListDummy.Items.Count > 0 Then
            If Not ListDummy.SelectedItem Is Nothing Then
                BindList(intCurrentLevel + 1, ListDummy.SelectedItem("CategoryID"))
            End If
        End If

    End Sub
    Private Sub ClearSubList(ByVal intParentLevel As Integer)

        If intParentLevel + 1 = intMaxLevel Then
            Exit Sub
        End If
        bolPendingClearSubList = True

        Dim intStartLevel As Integer
        Dim icounter As Int16
        intStartLevel = intParentLevel + 1
        For icounter = intMaxLevel To intStartLevel Step -1
            Dim ListDummy As ComboBox
            ListDummy = CType(GetControl("ListBox" & icounter), ComboBox)
            ListDummy.DataSource = Nothing
            '  intStartLevel += 1
        Next

        bolPendingClearSubList = False

    End Sub


    Private Sub GetSelectedCategoryID()
        Dim bolFoundSelectedID As Boolean = False

        Dim icounter As Int16

        For icounter = intMaxLevel To 1 Step -1
            Dim ListDummy As ComboBox
            ListDummy = CType(GetControl("ListBox" & icounter), ComboBox)

            If Not ListDummy.SelectedItem Is Nothing Then
                If bolFoundSelectedID = False Then
                    Me.SelectedCategoryID = ListDummy.SelectedItem("CategoryID")
                    Me.BreadCum = ListDummy.SelectedItem("CategoryName")
                    Me.SelectedCategoryName = ListDummy.SelectedItem("DisplayCategoryName")
                    bolFoundSelectedID = True
                Else
                    Me.BreadCum = ListDummy.SelectedItem("CategoryName") & " \ " & BreadCum
                End If
            End If

        Next

    End Sub

End Class
