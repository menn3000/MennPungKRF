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
'''DAO Class for table Tblemployee_kids
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblemployee_kids
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblemployee_kids
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblemployee_kids)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblemployee_kids)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(Tblemployee_kidsDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblemployee_kids))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblemployee_kids.ID
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

Protected _EmpID as integer  = 0 
Public Overridable Property EmpID() as integer  Implements _ITblemployee_kids.EmpID
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

Protected _FullName as string  = "" 
Public Overridable Property FullName() as string  Implements _ITblemployee_kids.FullName
    Get
	    Return _FullName
    End Get
    Set (byval value as string)
	    If _FullName <> value Then
	        IsChanged = True
	        _FullName= value
	    End If
    End Set
End property 

Protected _Sex as string  = "" 
Public Overridable Property Sex() as string  Implements _ITblemployee_kids.Sex
    Get
	    Return _Sex
    End Get
    Set (byval value as string)
	    If _Sex <> value Then
	        IsChanged = True
	        _Sex= value
	    End If
    End Set
End property 

Protected _DOB as DateTime  = Nothing 
Public Overridable Property DOB() as DateTime  Implements _ITblemployee_kids.DOB
    Get
	    Return _DOB
    End Get
    Set (byval value as DateTime)
	    If _DOB <> value Then
	        IsChanged = True
	        _DOB= value
	    End If
    End Set
End property 

Protected _InSchool as Boolean  = False 
Public Overridable Property InSchool() as Boolean  Implements _ITblemployee_kids.InSchool
    Get
	    Return _InSchool
    End Get
    Set (byval value as Boolean)
	    If _InSchool <> value Then
	        IsChanged = True
	        _InSchool= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblemployee_kids from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblemployee_kids = Manager.Read(Id)
                    _ID = int.ID
                    _EmpID = int.EmpID
                    _FullName = int.FullName
                    _Sex = int.Sex
                    _DOB = int.DOB
                    _InSchool = int.InSchool
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblemployee_kids on DB.
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
	  if _FullName.Length = 0 then Ris = False
  if _FullName.Length > 100 then Ris = False
  if _Sex.Length = 0 then Ris = False
  if _Sex.Length > 50 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblemployee_kids
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblemployee_kids

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property EmpID() as integer

    
    Property FullName() as string

    
    Property Sex() as string

    
    Property DOB() as DateTime

    
    Property InSchool() as Boolean

    
#End Region

End Interface