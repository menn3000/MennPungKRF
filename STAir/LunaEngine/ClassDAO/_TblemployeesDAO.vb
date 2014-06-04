#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 07/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
                
''' <summary>
'''This class manage persistency on db of Tblemployees object
''' </summary>
''' <remarks>
'''
''' </remarks>
Public MustInherit Class _TblemployeesDAO
Inherits LUNA.LunaBaseClassDAO(Of Tblemployees)

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
'''Read from DB table Tblemployees
''' </summary>
''' <returns>
'''Return a Tblemployees object
''' </returns>
Public Overrides Function Read(Id as integer) as Tblemployees
    Dim cls as new Tblemployees

    Try
        Using myCommand As SqlCommand = _cn.CreateCommand
        
            myCommand.CommandText = "SELECT * FROM Tblemployees where ID = " & Id
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader

                myReader.Read()
                if myReader.HasRows then
                    cls.ID = myReader("ID")
                cls.MainCategory = myReader("MainCategory")
                cls.EmployeeID = myReader("EmployeeID")
                cls.Password = myReader("Password")
                                if not myReader("prefix") is DBNull.Value then cls.prefix = myReader("prefix")
                cls.FName = myReader("FName")
                cls.LName = myReader("LName")
                                if not myReader("FNameEn") is DBNull.Value then cls.FNameEn = myReader("FNameEn")
                                if not myReader("LNameEn") is DBNull.Value then cls.LNameEn = myReader("LNameEn")
                                if not myReader("NationalID") is DBNull.Value then cls.NationalID = myReader("NationalID")
                                if not myReader("NickName") is DBNull.Value then cls.NickName = myReader("NickName")
                cls.DOB = myReader("DOB")
                                if not myReader("Address") is DBNull.Value then cls.Address = myReader("Address")
                cls.CurrentPositionID = myReader("CurrentPositionID")
                                if not myReader("WorkLine") is DBNull.Value then cls.WorkLine = myReader("WorkLine")
                                if not myReader("Email") is DBNull.Value then cls.Email = myReader("Email")
                                if not myReader("MobilePhone") is DBNull.Value then cls.MobilePhone = myReader("MobilePhone")
                cls.DateTimeStamp = myReader("DateTimeStamp")
                cls.UpdatedBy = myReader("UpdatedBy")
                                if not myReader("OverWriteAirModuleLevel") is DBNull.Value then cls.OverWriteAirModuleLevel = myReader("OverWriteAirModuleLevel")
                                if not myReader("OverWriteAdminModuleLevel") is DBNull.Value then cls.OverWriteAdminModuleLevel = myReader("OverWriteAdminModuleLevel")
                                if not myReader("OverWriteInvModuleLevel") is DBNull.Value then cls.OverWriteInvModuleLevel = myReader("OverWriteInvModuleLevel")
                                if not myReader("OverWriteFieldWorkModuleLevel") is DBNull.Value then cls.OverWriteFieldWorkModuleLevel = myReader("OverWriteFieldWorkModuleLevel")
                                if not myReader("MariageStatus") is DBNull.Value then cls.MariageStatus = myReader("MariageStatus")
                                if not myReader("FatherName") is DBNull.Value then cls.FatherName = myReader("FatherName")
                                if not myReader("FatherAlive") is DBNull.Value then cls.FatherAlive = myReader("FatherAlive")
                                if not myReader("MotherName") is DBNull.Value then cls.MotherName = myReader("MotherName")
                                if not myReader("MotherAlive") is DBNull.Value then cls.MotherAlive = myReader("MotherAlive")
                                if not myReader("SpouseName") is DBNull.Value then cls.SpouseName = myReader("SpouseName")
                                if not myReader("SpouseAlive") is DBNull.Value then cls.SpouseAlive = myReader("SpouseAlive")
                                if not myReader("EmpImageFilePath") is DBNull.Value then cls.EmpImageFilePath = myReader("EmpImageFilePath")
                	   
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
'''Save on DB table Tblemployees
''' </summary>
''' <returns>
'''Return ID insert in DB
''' </returns>
Public Overrides Function Save(byRef cls as Tblemployees) as Integer

    Dim Ris as integer=0 'in Ris return Insert Id

    If cls.IsValid Then
        If cls.IsChanged Then
            Using DbCommand As SqlCommand = New SqlCommand()
	            Try
		            Dim sql As String = String.Empty
		            DbCommand.Connection = _cn
		            If Not Luna.LunaContext.Transaction Is Nothing Then DbCommand.Transaction = Luna.LunaContext.Transaction
		            If cls.ID = 0 Then
                                    sql = "INSERT INTO Tblemployees ("
                                            sql &= " MainCategory,"
                                            sql &= " EmployeeID,"
                                            sql &= " Password,"
                                            sql &= " prefix,"
                                            sql &= " FName,"
                                            sql &= " LName,"
                                            sql &= " FNameEn,"
                                            sql &= " LNameEn,"
                                            sql &= " NationalID,"
                                            sql &= " NickName,"
                                            sql &= " DOB,"
                                            sql &= " Address,"
                                            sql &= " CurrentPositionID,"
                                            sql &= " WorkLine,"
                                            sql &= " Email,"
                                            sql &= " MobilePhone,"
                                            sql &= " DateTimeStamp,"
                                            sql &= " UpdatedBy,"
                                            sql &= " OverWriteAirModuleLevel,"
                                            sql &= " OverWriteAdminModuleLevel,"
                                            sql &= " OverWriteInvModuleLevel,"
                                            sql &= " OverWriteFieldWorkModuleLevel,"
                                            sql &= " MariageStatus,"
                                            sql &= " FatherName,"
                                            sql &= " FatherAlive,"
                                            sql &= " MotherName,"
                                            sql &= " MotherAlive,"
                                            sql &= " SpouseName,"
                                            sql &= " SpouseAlive,"
                                            sql &= " EmpImageFilePath"
                                      sql &= ") VALUES ("
                          sql &= " @MainCategory,"
                          sql &= " @EmployeeID,"
                          sql &= " @Password,"
                          sql &= " @prefix,"
                          sql &= " @FName,"
                          sql &= " @LName,"
                          sql &= " @FNameEn,"
                          sql &= " @LNameEn,"
                          sql &= " @NationalID,"
                          sql &= " @NickName,"
                          sql &= " @DOB,"
                          sql &= " @Address,"
                          sql &= " @CurrentPositionID,"
                          sql &= " @WorkLine,"
                          sql &= " @Email,"
                          sql &= " @MobilePhone,"
                          sql &= " @DateTimeStamp,"
                          sql &= " @UpdatedBy,"
                          sql &= " @OverWriteAirModuleLevel,"
                          sql &= " @OverWriteAdminModuleLevel,"
                          sql &= " @OverWriteInvModuleLevel,"
                          sql &= " @OverWriteFieldWorkModuleLevel,"
                          sql &= " @MariageStatus,"
                          sql &= " @FatherName,"
                          sql &= " @FatherAlive,"
                          sql &= " @MotherName,"
                          sql &= " @MotherAlive,"
                          sql &= " @SpouseName,"
                          sql &= " @SpouseAlive,"
                          sql &= " @EmpImageFilePath"
                          sql &= ")"
		            Else
			            sql = "UPDATE Tblemployees SET "
                      sql &= "MainCategory = @MainCategory,"
                      sql &= "EmployeeID = @EmployeeID,"
                      sql &= "Password = @Password,"
                      sql &= "prefix = @prefix,"
                      sql &= "FName = @FName,"
                      sql &= "LName = @LName,"
                      sql &= "FNameEn = @FNameEn,"
                      sql &= "LNameEn = @LNameEn,"
                      sql &= "NationalID = @NationalID,"
                      sql &= "NickName = @NickName,"
                      sql &= "DOB = @DOB,"
                      sql &= "Address = @Address,"
                      sql &= "CurrentPositionID = @CurrentPositionID,"
                      sql &= "WorkLine = @WorkLine,"
                      sql &= "Email = @Email,"
                      sql &= "MobilePhone = @MobilePhone,"
                      sql &= "DateTimeStamp = @DateTimeStamp,"
                      sql &= "UpdatedBy = @UpdatedBy,"
                      sql &= "OverWriteAirModuleLevel = @OverWriteAirModuleLevel,"
                      sql &= "OverWriteAdminModuleLevel = @OverWriteAdminModuleLevel,"
                      sql &= "OverWriteInvModuleLevel = @OverWriteInvModuleLevel,"
                      sql &= "OverWriteFieldWorkModuleLevel = @OverWriteFieldWorkModuleLevel,"
                      sql &= "MariageStatus = @MariageStatus,"
                      sql &= "FatherName = @FatherName,"
                      sql &= "FatherAlive = @FatherAlive,"
                      sql &= "MotherName = @MotherName,"
                      sql &= "MotherAlive = @MotherAlive,"
                      sql &= "SpouseName = @SpouseName,"
                      sql &= "SpouseAlive = @SpouseAlive,"
                      sql &= "EmpImageFilePath = @EmpImageFilePath"
    			            sql &= " WHERE ID= " & cls.ID
		            End if

                     DbCommand.Parameters.Add(New SqlParameter("@MainCategory", cls.MainCategory))
                    DbCommand.Parameters.Add(New SqlParameter("@EmployeeID", cls.EmployeeID))
                    DbCommand.Parameters.Add(New SqlParameter("@Password", cls.Password))
                    DbCommand.Parameters.Add(New SqlParameter("@prefix", cls.prefix))
                    DbCommand.Parameters.Add(New SqlParameter("@FName", cls.FName))
                    DbCommand.Parameters.Add(New SqlParameter("@LName", cls.LName))
                    DbCommand.Parameters.Add(New SqlParameter("@FNameEn", cls.FNameEn))
                    DbCommand.Parameters.Add(New SqlParameter("@LNameEn", cls.LNameEn))
                    DbCommand.Parameters.Add(New SqlParameter("@NationalID", cls.NationalID))
                    DbCommand.Parameters.Add(New SqlParameter("@NickName", cls.NickName))
                                  if cls.DOB <> Date.MinValue then
                        Dim DataPar As New SqlParameter("@DOB", SqlDbType.DateTime)
			            DataPar.Value = cls.DOB
			            DbCommand.Parameters.Add(DataPar)
                    else
                        DbCommand.Parameters.Add(New SqlParameter("@DOB", DBNull.Value))
                    end if  
                    DbCommand.Parameters.Add(New SqlParameter("@Address", cls.Address))
                    DbCommand.Parameters.Add(New SqlParameter("@CurrentPositionID", cls.CurrentPositionID))
                    DbCommand.Parameters.Add(New SqlParameter("@WorkLine", cls.WorkLine))
                    DbCommand.Parameters.Add(New SqlParameter("@Email", cls.Email))
                    DbCommand.Parameters.Add(New SqlParameter("@MobilePhone", cls.MobilePhone))
                                  if cls.DateTimeStamp <> Date.MinValue then
                        Dim DataPar As New SqlParameter("@DateTimeStamp", SqlDbType.DateTime)
			            DataPar.Value = cls.DateTimeStamp
			            DbCommand.Parameters.Add(DataPar)
                    else
                        DbCommand.Parameters.Add(New SqlParameter("@DateTimeStamp", DBNull.Value))
                    end if  
                    DbCommand.Parameters.Add(New SqlParameter("@UpdatedBy", cls.UpdatedBy))
                    DbCommand.Parameters.Add(New SqlParameter("@OverWriteAirModuleLevel", cls.OverWriteAirModuleLevel))
                    DbCommand.Parameters.Add(New SqlParameter("@OverWriteAdminModuleLevel", cls.OverWriteAdminModuleLevel))
                    DbCommand.Parameters.Add(New SqlParameter("@OverWriteInvModuleLevel", cls.OverWriteInvModuleLevel))
                    DbCommand.Parameters.Add(New SqlParameter("@OverWriteFieldWorkModuleLevel", cls.OverWriteFieldWorkModuleLevel))
                    DbCommand.Parameters.Add(New SqlParameter("@MariageStatus", cls.MariageStatus))
                    DbCommand.Parameters.Add(New SqlParameter("@FatherName", cls.FatherName))
                    DbCommand.Parameters.Add(New SqlParameter("@FatherAlive", cls.FatherAlive))
                    DbCommand.Parameters.Add(New SqlParameter("@MotherName", cls.MotherName))
                    DbCommand.Parameters.Add(New SqlParameter("@MotherAlive", cls.MotherAlive))
                    DbCommand.Parameters.Add(New SqlParameter("@SpouseName", cls.SpouseName))
                    DbCommand.Parameters.Add(New SqlParameter("@SpouseAlive", cls.SpouseAlive))
                    DbCommand.Parameters.Add(New SqlParameter("@EmpImageFilePath", cls.EmpImageFilePath))
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
        'Dim Sql As String = "UPDATE Tblemployees SET DELETED=True "
        Dim Sql As String = "DELETE FROM Tblemployees"
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
'''Delete from DB table Tblemployees. Accept id of object to delete.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(Id as integer) 
        DestroyPermanently (Id)
    End Sub

''' <summary>
'''Delete from DB table Tblemployees. Accept object to delete and optional a List to remove the object from.
''' </summary>
''' <returns>
'''
''' </returns>
Public Overrides Sub Delete(byref obj as Tblemployees, Optional ByRef ListaObj as List (of Tblemployees) = Nothing)
        DestroyPermanently (obj.ID)
    If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
     
End Sub

Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemployees)
    Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemployees)
    Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
    Return FindReal(So, Parameter)
End Function

Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemployees)
    Dim So As New Luna.LunaSearchOption
    Return FindReal(So, Parameter)
End Function

Public Overloads Function Find(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Tblemployees)
    Return FindReal(SearchOption, Parameter)
End Function

Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Tblemployees)
    Dim Ls As New List(Of Tblemployees)
    Try

    Dim sql As String = ""
    sql ="SELECT "   & IIf(SearchOption.Top, " TOP " & SearchOption.Top, "") & " * "
    sql &=" from Tblemployees" 
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

Public Overrides Function GetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblemployees)
    Dim Ls As New List(Of Tblemployees)
    Try

    Dim sql As String = ""
    sql ="SELECT * from Tblemployees" 
    If OrderByField.Length Then
	    Sql &= " ORDER BY " & OrderByField
    End If

    Ls = GetData(Sql,AddEmptyItem)

    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ls
End Function

Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Tblemployees)
    Dim Ls As New List(Of Tblemployees)
    Try
        Using myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction = Luna.LunaContext.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader()
                If AddEmptyItem Then Ls.Add(New  Tblemployees() With {.ID = 0 ,.MainCategory = 0 ,.EmployeeID = "" ,.Password = "" ,.prefix = "" ,.FName = "" ,.LName = "" ,.FNameEn = "" ,.LNameEn = "" ,.NationalID = "" ,.NickName = "" ,.DOB = Nothing ,.Address = "" ,.CurrentPositionID = 0 ,.WorkLine = "" ,.Email = "" ,.MobilePhone = "" ,.DateTimeStamp = Nothing ,.UpdatedBy = 0 ,.OverWriteAirModuleLevel = 0 ,.OverWriteAdminModuleLevel = 0 ,.OverWriteInvModuleLevel = 0 ,.OverWriteFieldWorkModuleLevel = 0 ,.MariageStatus = "" ,.FatherName = "" ,.FatherAlive = False ,.MotherName = "" ,.MotherAlive = False ,.SpouseName = "" ,.SpouseAlive = False ,.EmpImageFilePath = ""  })
                while myReader.Read
	                Dim classe as new Tblemployees
	                classe.ID = myReader("ID")
                    classe.MainCategory = myReader("MainCategory")
                    classe.EmployeeID = myReader("EmployeeID")
                    classe.Password = myReader("Password")
                                            if not myReader("prefix") is DBNull.Value then classe.prefix = myReader("prefix")
                    classe.FName = myReader("FName")
                    classe.LName = myReader("LName")
                                            if not myReader("FNameEn") is DBNull.Value then classe.FNameEn = myReader("FNameEn")
                                            if not myReader("LNameEn") is DBNull.Value then classe.LNameEn = myReader("LNameEn")
                                            if not myReader("NationalID") is DBNull.Value then classe.NationalID = myReader("NationalID")
                                            if not myReader("NickName") is DBNull.Value then classe.NickName = myReader("NickName")
                    classe.DOB = myReader("DOB")
                                            if not myReader("Address") is DBNull.Value then classe.Address = myReader("Address")
                    classe.CurrentPositionID = myReader("CurrentPositionID")
                                            if not myReader("WorkLine") is DBNull.Value then classe.WorkLine = myReader("WorkLine")
                                            if not myReader("Email") is DBNull.Value then classe.Email = myReader("Email")
                                            if not myReader("MobilePhone") is DBNull.Value then classe.MobilePhone = myReader("MobilePhone")
                    classe.DateTimeStamp = myReader("DateTimeStamp")
                    classe.UpdatedBy = myReader("UpdatedBy")
                                            if not myReader("OverWriteAirModuleLevel") is DBNull.Value then classe.OverWriteAirModuleLevel = myReader("OverWriteAirModuleLevel")
                                            if not myReader("OverWriteAdminModuleLevel") is DBNull.Value then classe.OverWriteAdminModuleLevel = myReader("OverWriteAdminModuleLevel")
                                            if not myReader("OverWriteInvModuleLevel") is DBNull.Value then classe.OverWriteInvModuleLevel = myReader("OverWriteInvModuleLevel")
                                            if not myReader("OverWriteFieldWorkModuleLevel") is DBNull.Value then classe.OverWriteFieldWorkModuleLevel = myReader("OverWriteFieldWorkModuleLevel")
                                            if not myReader("MariageStatus") is DBNull.Value then classe.MariageStatus = myReader("MariageStatus")
                                            if not myReader("FatherName") is DBNull.Value then classe.FatherName = myReader("FatherName")
                                            if not myReader("FatherAlive") is DBNull.Value then classe.FatherAlive = myReader("FatherAlive")
                                            if not myReader("MotherName") is DBNull.Value then classe.MotherName = myReader("MotherName")
                                            if not myReader("MotherAlive") is DBNull.Value then classe.MotherAlive = myReader("MotherAlive")
                                            if not myReader("SpouseName") is DBNull.Value then classe.SpouseName = myReader("SpouseName")
                                            if not myReader("SpouseAlive") is DBNull.Value then classe.SpouseAlive = myReader("SpouseAlive")
                                            if not myReader("EmpImageFilePath") is DBNull.Value then classe.EmpImageFilePath = myReader("EmpImageFilePath")
                    	   
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
