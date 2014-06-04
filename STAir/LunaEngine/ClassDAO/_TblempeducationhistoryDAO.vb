#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 03/12/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
                
''' <summary>
'''This class manage persistency on db of Tblempeducationhistory object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _TblempeducationhistoryDAO
Inherits LUNA.LunaBaseClassDAO(Of Tblempeducationhistory)

''' <summary>
'''New() create an istance of this class. Use default DB Connection
''' </summary>
''' <returns>
'''
''' </returns>
Public Sub New()
	MyBase.New()
End Sub

''' <summary>
'''New() create an istance of this class and specify an OPENED DB connection
''' </summary>
''' <returns>
'''
''' </returns>
Public Sub New(ByVal Connection As SqlConnection)
	MyBase.New(Connection)
End Sub

''' <summary>
'''Read from DB table Tblempeducationhistory
''' </summary>
''' <returns>
'''Return a Tblempeducationhistory object
''' </returns>
Public Overrides Function Read(Id as integer) as Tblempeducationhistory
    Dim cls as new Tblempeducationhistory

    Try
        Using myCommand As SqlCommand = _cn.CreateCommand
        
            myCommand.CommandText = "SELECT * FROM Tblempeducationhistory where ID = " & Id
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader

                myReader.Read()
                if myReader.HasRows then
                    cls.ID = myReader("ID")
                cls.EmpID = myReader("EmpID")
                cls.DegreeName = myReader("DegreeName")
                cls.Major = myReader("Major")
                cls.YearGrad = myReader("YearGrad")
                cls.SchoolName = myReader("SchoolName")
                                if not myReader("EduHisNote") is DBNull.Value then cls.EduHisNote = myReader("EduHisNote")
                	   
                End If
                myReader.Close()
            End Using
        End Using
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return cls
End Function

''' <summary>
'''Save on DB table Tblempeducationhistory
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Tblempeducationhistory) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Using DbCommand As SqlCommand = New SqlCommand()
	            Try
		            Dim sql As String = String.Empty
		            DbCommand.Connection = _cn
		            If Not Luna.LunaContext.Transaction Is Nothing Then DbCommand.Transaction = Luna.LunaContext.Transaction
		            If cls.ID = 0 Then
                                    sql = "INSERT INTO Tblempeducationhistory ("
                                            sql &= " EmpID,"
                                            sql &= " DegreeName,"
                                            sql &= " Major,"
                                            sql &= " YearGrad,"
                                            sql &= " SchoolName,"
                                            sql &= " EduHisNote"
                                      sql &= ") VALUES ("
                          sql &= " @EmpID,"
                          sql &= " @DegreeName,"
                          sql &= " @Major,"
                          sql &= " @YearGrad,"
                          sql &= " @SchoolName,"
                          sql &= " @EduHisNote"
                          sql &= ")"
		            Else
			            sql = "UPDATE Tblempeducationhistory SET "
                      sql &= "EmpID = @EmpID,"
                      sql &= "DegreeName = @DegreeName,"
                      sql &= "Major = @Major,"
                      sql &= "YearGrad = @YearGrad,"
                      sql &= "SchoolName = @SchoolName,"
                      sql &= "EduHisNote = @EduHisNote"
    			            sql &= " WHERE ID= " & cls.ID
		            End if

                     DbCommand.Parameters.Add(New SqlParameter("@EmpID", cls.EmpID))
                    DbCommand.Parameters.Add(New SqlParameter("@DegreeName", cls.DegreeName))
                    DbCommand.Parameters.Add(New SqlParameter("@Major", cls.Major))
                    DbCommand.Parameters.Add(New SqlParameter("@YearGrad", cls.YearGrad))
                    DbCommand.Parameters.Add(New SqlParameter("@SchoolName", cls.SchoolName))
                    DbCommand.Parameters.Add(New SqlParameter("@EduHisNote", cls.EduHisNote))
                                        DbCommand.CommandType = CommandType.Text
		            DbCommand.CommandText = sql
		            DbCommand.ExecuteNonQuery()

                                  If cls.ID=0 Then
			            Dim IdInserito as integer = 0
			            Sql = "select @@identity"
			            DbCommand.CommandText = Sql
			            Idinserito = DbCommand.ExecuteScalar()
			            cls.ID = Idinserito
			            Ris = Idinserito
		            else
			            Ris  =  cls.ID
		            End If
                    		            

	            Catch ex As Exception
		            ManageError(ex)
	            End Try
            End Using
        else
	        Ris  =  cls.ID
        End If

    Else
	    throw new ApplicationException("Object data is not valid")
    End If
    Return Ris
End Function

Private Sub DestroyPermanently(Id as integer) 
    Try

    Using  UpdateCommand As SqlCommand = New SqlCommand()
        UpdateCommand.Connection = _cn

        '******IMPORTANT: You can use this commented instruction to make a logical delete .
        '******Replace DELETED Field with your logic deleted field name.
        'Dim Sql As String = "UPDATE Tblempeducationhistory SET DELETED=True "
        Dim Sql As String = "DELETE FROM Tblempeducationhistory"
        Sql &= " Where ID = " & Id 

        UpdateCommand.CommandText = Sql
        If Not Luna.LunaContext.Transaction Is Nothing Then UpdateCommand.Transaction = Luna.LunaContext.Transaction
        UpdateCommand.ExecuteNonQuery()
    
    End Using
    Catch ex As Exception
	    ManageError(ex)
    End Try
End Sub

''' <summary>
'''Delete from DB table Tblempeducationhistory. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Tblempeducationhistory. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Tblempeducationhistory, Optional ByRef ListaObj as List (of Tblempeducationhistory) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblempeducationhistory)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblempeducationhistory)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblempeducationhistory)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Tblempeducationhistory)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblempeducationhistory)
    Dim Ls As New List(Of Tblempeducationhistory)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Tblempeducationhistory" 
    For Each Par As LUNA.LunaSearchParameter In Parameter
	    If Not Par Is Nothing Then
		    If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
		        sql &= Par.FieldName & " " & Par.SqlOperator
                If Par.SqlOperator.IndexOf("IN") <> -1 Then
                    sql &= " " & ApIn(Par.Value)
                Else
                    sql &= " " & Ap(Par.Value)
                End If
	    End if
    Next

    If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

    Ls = GetData(Sql)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblempeducationhistory)
    Dim Ls As New List(Of Tblempeducationhistory)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Tblempeducationhistory" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblempeducationhistory)
    Dim Ls As New List(Of Tblempeducationhistory)
    Try
        Using myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader()
                If AddEmptyItem Then Ls.Add(New  Tblempeducationhistory() With {.ID = 0 ,.EmpID = 0 ,.DegreeName = "" ,.Major = "" ,.YearGrad = 0 ,.SchoolName = "" ,.EduHisNote = ""  })
                while myReader.Read
	                Dim classe as new Tblempeducationhistory
	                classe.ID = myReader("ID")
                    classe.EmpID = myReader("EmpID")
                    classe.DegreeName = myReader("DegreeName")
                    classe.Major = myReader("Major")
                    classe.YearGrad = myReader("YearGrad")
                    classe.SchoolName = myReader("SchoolName")
                                            if not myReader("EduHisNote") is DBNull.Value then classe.EduHisNote = myReader("EduHisNote")
                    	   
	                Ls.Add(classe)
                end while
                myReader.Close()
            End Using
        End Using

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function
End Class
