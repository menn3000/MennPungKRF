Imports System.Data.SqlClient
Imports System.Array

Public Class clsBCategory

    Private clsSQL As New ClsDataSQL

    Public Const Cate_rowState_Added As String = "Added"
    Public Const Cate_rowState_Modified As String = "Modified"
    Public Const Cate_rowState_Deleted As String = "Deleted"

    Public Const Cate_Status_Active As String = "A"




    Public Enum enuReturnErrorCode
        ExcuteDataBaseError = -9999
        PreparingDataBeforeExcuteDBError = -9998
        NoRowUpdated = -22222 '  match with the return from SP CategorySave_sp
    End Enum
    Public Function GetErrorDesc(ByVal intEnuReturnErrorCode As Integer) As String
        Select Case intEnuReturnErrorCode
            Case enuReturnErrorCode.ExcuteDataBaseError
                Return "There is an error occured in clsBCategory.SaveCategory"
            Case enuReturnErrorCode.PreparingDataBeforeExcuteDBError
                Return "Error preparing data in presentation layer"
            Case Else
                Return "UnConfiged error"
        End Select
    End Function
   


    Public Enum enuCateIsExpired
        notExpire = 0
        Expire = 1
    End Enum

    Public Enum enuCateIsVirtual
        NotVirtual = 0
        virtual = 1
    End Enum
    Public Enum enuLeafCategory
        Yes = 1
        No = 0
    End Enum





  
    Public Function SaveCategory(ByVal aryCategoryParams As Dictionary(Of String, Object)) As Integer

        ' The StoreProcedures CategorySave_sp will return different values 
        '   base on @rowState param
        '   Added  will return the newly added CategoryID
        '   Modified will return the # of row effected or -22222 if no row effected
        '   deleted will return the # of row deleted

        'Try

        Dim dr As SqlDataReader
        Dim intRetValue As Integer

        '   Dim objConn As SqlConnection = New SqlConnection(clsSQL.CNS)
        '   Dim cmd As SqlCommand = New SqlCommand(strSQL, objConn)
        Dim cmd As New SqlCommand()
        cmd.CommandText = "CategorySave_sp"

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
        '       @OptionSpecificGroup int = null  	
        '       @DisplayIndex 	= int

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CategoryID", aryCategoryParams.Item("CategoryID"))
        cmd.Parameters.AddWithValue("@CategoryLevel", aryCategoryParams.Item("CategoryLevel"))
        cmd.Parameters.AddWithValue("@CategoryName", aryCategoryParams.Item("CategoryName"))
        cmd.Parameters.AddWithValue("@CategoryNameEng", aryCategoryParams.Item("CategoryNameEng"))
        cmd.Parameters.AddWithValue("@CategoryParentID", aryCategoryParams.Item("CategoryParentID"))
        cmd.Parameters.AddWithValue("@LeafCategory", aryCategoryParams.Item("LeafCategory"))
        cmd.Parameters.AddWithValue("@IsExpired", aryCategoryParams.Item("IsExpired"))
        cmd.Parameters.AddWithValue("@IsVirtual", aryCategoryParams.Item("IsVirtual"))
        cmd.Parameters.AddWithValue("@Status", aryCategoryParams.Item("Status"))
        cmd.Parameters.AddWithValue("@CategoryNote", aryCategoryParams.Item("CategoryNote"))
        cmd.Parameters.AddWithValue("@RowState", aryCategoryParams.Item("RowState"))
        cmd.Parameters.AddWithValue("@DisplayIndex", 10) ' 10 is default value


        'objConn.Open()
        dr = clsSQL.DB_GetDataReader(cmd)
        If dr.Read Then
            intRetValue = dr(0)
        End If
        dr.Close()
        'objConn.Close()
        Return intRetValue
        Exit Function
        'Catch ex As Exception
        '    'clsSQL.WriteLog("Database excution error", ex.Message)
        '    Return enuReturnErrorCode.ExcuteDataBaseError
        'End Try


    End Function

    Public Function RetriveCategoryLevel(ByVal intLevel As Integer, ByVal intParentID As Integer) As DataSet
        Dim strSQL As String
        If intLevel = 1 Then
            strSQL = "ActiveDisplayCategoryRetrieveTopLevel " & intLevel
        Else
            strSQL = "ActiveDisplayCategoryRetrieveByLevel " & intLevel & "," & intParentID
        End If

        Dim dtb As New DataTable("Category")
        Dim ds As New DataSet
        ds.Tables.Add(dtb)
        ds = clsSQL.DB_GetDataSet(strSQL, "Category", False)
        Return ds
    End Function

    Public Function RetriveCategoryParent(ByVal intCategoryID As Integer, ByVal IsIncludeSelf As Boolean) As DataSet
        Dim strSQL As String
        If IsIncludeSelf = True Then
            strSQL = "nb_Category_get_Parents " & intCategoryID & ",1"
        Else
            strSQL = "nb_Category_get_Parents " & intCategoryID & ",0"
        End If

        Dim dtb As New DataTable("ParentCategory")
        Dim ds As New DataSet
        ds.Tables.Add(dtb)
        ds = clsSQL.DB_GetDataSet(strSQL, "ParentCategory", False)
        Return ds
    End Function
    Public Function RetriveCategoryBreadCrumb(ByVal intCategoryID As Integer, ByVal IncludeSelf As Boolean) As String
        Dim strSQL As String = ""
        If IncludeSelf = True Then
            strSQL = "Cate_GetBreadCrumb " & intCategoryID.ToString & ",1"
        Else
            strSQL = "Cate_GetBreadCrumb " & intCategoryID.ToString & ",0"
        End If
        Dim strReturn As String
        Dim dr As SqlDataReader
        dr = clsSQL.DB_GetDataReader(strSQL)
        If dr.Read Then
            strReturn = dr("BreadCrumb")
        End If
        dr.Close()

        Return strReturn
    End Function

End Class
