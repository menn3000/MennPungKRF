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
'''DAO Class for table Tblemplevelhistory
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblemplevelhistory
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblemplevelhistory
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblemplevelhistory)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblemplevelhistory)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(TblemplevelhistoryDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblemplevelhistory))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblemplevelhistory.ID
    Get
	    Return _ID
    End Get
    Set (byval value as integer)
	    If _ID <> value Then
	        IsChanged = True
	        _ID= value
	    End If
    End Set
End property 

Protected _LevelNumber as Decimal  = 0 
Public Overridable Property LevelNumber() as Decimal  Implements _ITblemplevelhistory.LevelNumber
    Get
	    Return _LevelNumber
    End Get
    Set (byval value as Decimal)
	    If _LevelNumber <> value Then
	        IsChanged = True
	        _LevelNumber= value
	    End If
    End Set
End property 

Protected _EmpID as integer  = 0 
Public Overridable Property EmpID() as integer  Implements _ITblemplevelhistory.EmpID
    Get
	    Return _EmpID
    End Get
    Set (byval value as integer)
	    If _EmpID <> value Then
	        IsChanged = True
	        _EmpID= value
	    End If
    End Set
End property 

Protected _IsCurrent as Boolean  = False 
Public Overridable Property IsCurrent() as Boolean  Implements _ITblemplevelhistory.IsCurrent
    Get
	    Return _IsCurrent
    End Get
    Set (byval value as Boolean)
	    If _IsCurrent <> value Then
	        IsChanged = True
	        _IsCurrent= value
	    End If
    End Set
End property 

Protected _DateAssigned as DateTime  = Nothing 
Public Overridable Property DateAssigned() as DateTime  Implements _ITblemplevelhistory.DateAssigned
    Get
	    Return _DateAssigned
    End Get
    Set (byval value as DateTime)
	    If _DateAssigned <> value Then
	        IsChanged = True
	        _DateAssigned= value
	    End If
    End Set
End property 

Protected _AssignNote as string  = "" 
Public Overridable Property AssignNote() as string  Implements _ITblemplevelhistory.AssignNote
    Get
	    Return _AssignNote
    End Get
    Set (byval value as string)
	    If _AssignNote <> value Then
	        IsChanged = True
	        _AssignNote= value
	    End If
    End Set
End property 

Protected _AssignProcessedBy as string  = "" 
Public Overridable Property AssignProcessedBy() as string  Implements _ITblemplevelhistory.AssignProcessedBy
    Get
	    Return _AssignProcessedBy
    End Get
    Set (byval value as string)
	    If _AssignProcessedBy <> value Then
	        IsChanged = True
	        _AssignProcessedBy= value
	    End If
    End Set
End property 

Protected _ResignProcessedBy as string  = "" 
Public Overridable Property ResignProcessedBy() as string  Implements _ITblemplevelhistory.ResignProcessedBy
    Get
	    Return _ResignProcessedBy
    End Get
    Set (byval value as string)
	    If _ResignProcessedBy <> value Then
	        IsChanged = True
	        _ResignProcessedBy= value
	    End If
    End Set
End property 

Protected _DateResign as DateTime  = Nothing 
Public Overridable Property DateResign() as DateTime  Implements _ITblemplevelhistory.DateResign
    Get
	    Return _DateResign
    End Get
    Set (byval value as DateTime)
	    If _DateResign <> value Then
	        IsChanged = True
	        _DateResign= value
	    End If
    End Set
End property 

Protected _ResignNote as string  = "" 
Public Overridable Property ResignNote() as string  Implements _ITblemplevelhistory.ResignNote
    Get
	    Return _ResignNote
    End Get
    Set (byval value as string)
	    If _ResignNote <> value Then
	        IsChanged = True
	        _ResignNote= value
	    End If
    End Set
End property 

Protected _Salary as Decimal  = 0 
Public Overridable Property Salary() as Decimal  Implements _ITblemplevelhistory.Salary
    Get
	    Return _Salary
    End Get
    Set (byval value as Decimal)
	    If _Salary <> value Then
	        IsChanged = True
	        _Salary= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblemplevelhistory from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblemplevelhistory = Manager.Read(Id)
                    _ID = int.ID
                    _LevelNumber = int.LevelNumber
                    _EmpID = int.EmpID
                    _IsCurrent = int.IsCurrent
                    _DateAssigned = int.DateAssigned
                    _AssignNote = int.AssignNote
                    _AssignProcessedBy = int.AssignProcessedBy
                    _ResignProcessedBy = int.ResignProcessedBy
                    _DateResign = int.DateResign
                    _ResignNote = int.ResignNote
                    _Salary = int.Salary
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblemplevelhistory on DB.
''' </summary>
''' <returns>
'''Return Id insert in DB if all ok, 0 if error
''' </returns>
Public Overridable Function Save() As Integer
    'Return the id Inserted
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Ris = Manager.Save(Me)
	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
    End Try
    Return Ris
End Function

Protected Function InternalIsValid() As Boolean
	Dim Ris As Boolean = True
	  if _AssignNote.Length > 2147483647 then Ris = False
  if _AssignProcessedBy.Length > 255 then Ris = False
  if _ResignProcessedBy.Length > 255 then Ris = False
  if _ResignNote.Length > 2147483647 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblemplevelhistory
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblemplevelhistory

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property LevelNumber() as Decimal

    
    Property EmpID() as integer

    
    Property IsCurrent() as Boolean

    
    Property DateAssigned() as DateTime

    
    Property AssignNote() as string

    
    Property AssignProcessedBy() as string

    
    Property ResignProcessedBy() as string

    
    Property DateResign() as DateTime

    
    Property ResignNote() as string

    
    Property Salary() as Decimal

    
#End Region

End Interface