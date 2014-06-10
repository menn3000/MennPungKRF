Public Class clsPermission



    Friend Enum enuPerMission
        NoAccess = 0
        UseDefaultFromPosition = 1
        ReadWrite = 2
        ReadWriteApproved = 5
        ExecutiveViewer = 6
        Programmer = 999
    End Enum

    Friend Enum WhatUserCanDo
        'this number must be in sequencial
        CanNotView = 0
        CanRead = 1
        CanWrite = 2
        CanApprove = 3
        CanDoAnything = 999
    End Enum

    Friend Shared Function CheckWhatUserCanDO(ByVal permission As enuPerMission) As WhatUserCanDo
        Select Case permission
            Case enuPerMission.NoAccess
                Return WhatUserCanDo.CanNotView
            Case enuPerMission.ReadWrite
                Return WhatUserCanDo.CanWrite
            Case enuPerMission.ReadWriteApproved
                Return WhatUserCanDo.CanApprove
            Case enuPerMission.ExecutiveViewer
                Return WhatUserCanDo.CanRead
            Case enuPerMission.Programmer
                Return WhatUserCanDo.CanDoAnything
            Case Else
                Return WhatUserCanDo.CanNotView
        End Select

    End Function

    Friend Shared Sub EnableDisableControlByPermission(ByRef targetControl() As Control, ByVal userCurrentPermission As enuPerMission, ByVal minimumWhatUserCanDo As WhatUserCanDo)

        If clsPermission.CheckWhatUserCanDO(userCurrentPermission) < minimumWhatUserCanDo Then
            For Each ctr As Control In targetControl
                ctr.Enabled = False
            Next
        Else
            For Each ctr As Control In targetControl
                ctr.Enabled = True
            Next
        End If

    End Sub
   



    Sub New()


    End Sub


    Friend Function GetPermissionName(ByVal permissionLevel As enuPerMission) As String

        Select Case permissionLevel

            Case 0
                Return "ไม่อนุญาติ"
            Case 1
                Return "อนุญาติตามตำแหน่ง"
            Case 2
                Return "ดูและแก้ไข"
            Case 5
                Return "ดู แก้ไข และ ตรวจสอบ"
            Case 6
                Return "ผู้บริหาร"
            Case Else ' premissionLevel = 999
                Return "ผู้จัดการระบบ"
        End Select
    End Function

    

   


    Friend Sub CreatePermissionLevelTable(ByRef dtb As DataTable, Optional ByVal bolSkip_UseDefaultFromPosition As Boolean = False)


        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.Int32")
        myDataColumn.ColumnName = "ID"
        myDataColumn.Caption = "ID"
        myDataColumn.ReadOnly = True
        dtb.Columns.Add(myDataColumn)
        ' Create second column.
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "LevelName"
        myDataColumn.Caption = "LevelName"
        myDataColumn.ReadOnly = True
        myDataColumn.Unique = False
        myDataColumn.AllowDBNull = False
        dtb.Columns.Add(myDataColumn)


        Dim TR As DataRow
        Dim enumValues As Array = System.[Enum].GetValues(GetType(enuPerMission))

        For Each resource As enuPerMission In enumValues
            If resource = enuPerMission.UseDefaultFromPosition Then
                If bolSkip_UseDefaultFromPosition = True Then
                    GoTo NextResource
                End If
            End If

            TR = dtb.NewRow
            TR("ID") = resource
            TR("LevelName") = GetPermissionName(resource)
            dtb.Rows.Add(TR)

NextResource:
        Next


    End Sub

    Private Sub InsertPermissionToTable()
        Dim enumValues As Array = System.[Enum].GetValues(GetType(enuPerMission))

        For Each resource As enuPerMission In enumValues

        Next
    End Sub

   
End Class
