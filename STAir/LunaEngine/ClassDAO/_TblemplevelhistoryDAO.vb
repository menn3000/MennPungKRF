#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 02/12/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
                
''' <summary>
'''This class manage persistency on db of Tblemplevelhistory object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _TblemplevelhistoryDAO
Inherits LUNA.LunaBaseClassDAO(Of Tblemplevelhistory)

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
'''Read from DB table Tblemplevelhistory
''' </summary>
''' <returns>
'''Return a Tblemplevelhistory object
''' </returns>
Public Overrides Function Read(Id as integer) as Tblemplevelhistory
    Dim cls as new Tblemplevelhistory

    Try
        Using myCommand As SqlCommand = _cn.CreateCommand
        
            myCommand.CommandText = "SELECT * FROM Tblemplevelhistory where ID = " & Id
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader

                myReader.Read()
                if myReader.HasRows then
                    cls.ID = myReader("ID")
                cls.LevelNumber = myReader("LevelNumber")
                cls.EmpID = myReader("EmpID")
                cls.IsCurrent = myReader("IsCurrent")
                cls.DateAssigned = myReader("DateAssigned")
                                if not myReader("AssignNote") is DBNull.Value then cls.AssignNote = myReader("AssignNote")
                                if not myReader("AssignProcessedBy") is DBNull.Value then cls.AssignProcessedBy = myReader("AssignProcessedBy")
                                if not myReader("ResignProcessedBy") is DBNull.Value then cls.ResignProcessedBy = myReader("ResignProcessedBy")
                                if not myReader("DateResign") is DBNull.Value then cls.DateResign = myReader("DateResign")
                                if not myReader("ResignNote") is DBNull.Value then cls.ResignNote = myReader("ResignNote")
                cls.Salary = myReader("Salary")
                	   
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
'''Save on DB table Tblemplevelhistory
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Tblemplevelhistory) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Using DbCommand As SqlCommand = New SqlCommand()
	            Try
		            Dim sql As String = String.Empty
		            DbCommand.Connection = _cn
		            If Not Luna.LunaContext.Transaction Is Nothing Then DbCommand.Transaction = Luna.LunaContext.Transaction
		            If cls.ID = 0 Then
                                    sql = "INSERT INTO Tblemplevelhistory ("
                                            sql &= " LevelNumber,"
                                            sql &= " EmpID,"
                                            sql &= " IsCurrent,"
                                            sql &= " DateAssigned,"
                                            sql &= " AssignNote,"
                                            sql &= " AssignProcessedBy,"
                                            sql &= " ResignProcessedBy,"
                                            sql &= " DateResign,"
                                            sql &= " ResignNote,"
                                            sql &= " Salary"
                                      sql &= ") VALUES ("
                          sql &= " @LevelNumber,"
                          sql &= " @EmpID,"
                          sql &= " @IsCurrent,"
                          sql &= " @DateAssigned,"
                          sql &= " @AssignNote,"
                          sql &= " @AssignProcessedBy,"
                          sql &= " @ResignProcessedBy,"
                          sql &= " @DateResign,"
                          sql &= " @ResignNote,"
                          sql &= " @Salary"
                          sql &= ")"
		            Else
			            sql = "UPDATE Tblemplevelhistory SET "
                      sql &= "LevelNumber = @LevelNumber,"
                      sql &= "EmpID = @EmpID,"
                      sql &= "IsCurrent = @IsCurrent,"
                      sql &= "DateAssigned = @DateAssigned,"
                      sql &= "AssignNote = @AssignNote,"
                      sql &= "AssignProcessedBy = @AssignProcessedBy,"
                      sql &= "ResignProcessedBy = @ResignProcessedBy,"
                      sql &= "DateResign = @DateResign,"
                      sql &= "ResignNote = @ResignNote,"
                      sql &= "Salary = @Salary"
    			            sql &= " WHERE ID= " & cls.ID
		            End if

                     DbCommand.Parameters.Add(New SqlParameter("@LevelNumber", cls.LevelNumber))
                    DbCommand.Parameters.Add(New SqlParameter("@EmpID", cls.EmpID))
                    DbCommand.Parameters.Add(New SqlParameter("@IsCurrent", cls.IsCurrent))
                                  if cls.DateAssigned <> Date.MinValue then
                        Dim DataPar As New SqlParameter("@DateAssigned", SqlDbType.DateTime)
			            DataPar.Value = cls.DateAssigned
			            DbCommand.Parameters.Add(DataPar)
                    else
                        DbCommand.Parameters.Add(New SqlParameter("@DateAssigned", DBNull.Value))
                    end if  
                    DbCommand.Parameters.Add(New SqlParameter("@AssignNote", cls.AssignNote))
                    DbCommand.Parameters.Add(New SqlParameter("@AssignProcessedBy", cls.AssignProcessedBy))
                    DbCommand.Parameters.Add(New SqlParameter("@ResignProcessedBy", cls.ResignProcessedBy))
                                  if cls.DateResign <> Date.MinValue then
                        Dim DataPar As New SqlParameter("@DateResign", SqlDbType.DateTime)
			            DataPar.Value = cls.DateResign
			            DbCommand.Parameters.Add(DataPar)
                    else
                        DbCommand.Parameters.Add(New SqlParameter("@DateResign", DBNull.Value))
                    end if  
                    DbCommand.Parameters.Add(New SqlParameter("@ResignNote", cls.ResignNote))
                    DbCommand.Parameters.Add(New SqlParameter("@Salary", cls.Salary))
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
        'Dim Sql As String = "UPDATE Tblemplevelhistory SET DELETED=True "
        Dim Sql As String = "DELETE FROM Tblemplevelhistory"
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
'''Delete from DB table Tblemplevelhistory. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Tblemplevelhistory. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Tblemplevelhistory, Optional ByRef ListaObj as List (of Tblemplevelhistory) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemplevelhistory)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemplevelhistory)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemplevelhistory)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Tblemplevelhistory)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemplevelhistory)
    Dim Ls As New List(Of Tblemplevelhistory)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Tblemplevelhistory" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblemplevelhistory)
    Dim Ls As New List(Of Tblemplevelhistory)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Tblemplevelhistory" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblemplevelhistory)
    Dim Ls As New List(Of Tblemplevelhistory)
    Try
        Using myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader()
                If AddEmptyItem Then Ls.Add(New  Tblemplevelhistory() With {.ID = 0 ,.LevelNumber = 0 ,.EmpID = 0 ,.IsCurrent = False ,.DateAssigned = Nothing ,.AssignNote = "" ,.AssignProcessedBy = "" ,.ResignProcessedBy = "" ,.DateResign = Nothing ,.ResignNote = "" ,.Salary = 0  })
                while myReader.Read
	                Dim classe as new Tblemplevelhistory
	                classe.ID = myReader("ID")
                    classe.LevelNumber = myReader("LevelNumber")
                    classe.EmpID = myReader("EmpID")
                    classe.IsCurrent = myReader("IsCurrent")
                    classe.DateAssigned = myReader("DateAssigned")
                                            if not myReader("AssignNote") is DBNull.Value then classe.AssignNote = myReader("AssignNote")
                                            if not myReader("AssignProcessedBy") is DBNull.Value then classe.AssignProcessedBy = myReader("AssignProcessedBy")
                                            if not myReader("ResignProcessedBy") is DBNull.Value then classe.ResignProcessedBy = myReader("ResignProcessedBy")
                                            if not myReader("DateResign") is DBNull.Value then classe.DateResign = myReader("DateResign")
                                            if not myReader("ResignNote") is DBNull.Value then classe.ResignNote = myReader("ResignNote")
                    classe.Salary = myReader("Salary")
                    	   
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
