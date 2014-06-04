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
'''DAO Class for table Tblempeducationhistory
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblempeducationhistory
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblempeducationhistory
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblempeducationhistory)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblempeducationhistory)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(TblempeducationhistoryDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblempeducationhistory))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblempeducationhistory.ID
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
Public Overridable Property EmpID() as integer  Implements _ITblempeducationhistory.EmpID
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

Protected _DegreeName as string  = "" 
Public Overridable Property DegreeName() as string  Implements _ITblempeducationhistory.DegreeName
    Get
	    Return _DegreeName
    End Get
    Set (byval value as string)
	    If _DegreeName <> value Then
	        IsChanged = True
	        _DegreeName= value
	    End If
    End Set
End property 

Protected _Major as string  = "" 
Public Overridable Property Major() as string  Implements _ITblempeducationhistory.Major
    Get
	    Return _Major
    End Get
    Set (byval value as string)
	    If _Major <> value Then
	        IsChanged = True
	        _Major= value
	    End If
    End Set
End property 

Protected _YearGrad as integer  = 0 
Public Overridable Property YearGrad() as integer  Implements _ITblempeducationhistory.YearGrad
    Get
	    Return _YearGrad
    End Get
    Set (byval value as integer)
	    If _YearGrad <> value Then
	        IsChanged = True
	        _YearGrad= value
	    End If
    End Set
End property 

Protected _SchoolName as string  = "" 
Public Overridable Property SchoolName() as string  Implements _ITblempeducationhistory.SchoolName
    Get
	    Return _SchoolName
    End Get
    Set (byval value as string)
	    If _SchoolName <> value Then
	        IsChanged = True
	        _SchoolName= value
	    End If
    End Set
End property 

Protected _EduHisNote as string  = "" 
Public Overridable Property EduHisNote() as string  Implements _ITblempeducationhistory.EduHisNote
    Get
	    Return _EduHisNote
    End Get
    Set (byval value as string)
	    If _EduHisNote <> value Then
	        IsChanged = True
	        _EduHisNote= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblempeducationhistory from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblempeducationhistory = Manager.Read(Id)
                    _ID = int.ID
                    _EmpID = int.EmpID
                    _DegreeName = int.DegreeName
                    _Major = int.Major
                    _YearGrad = int.YearGrad
                    _SchoolName = int.SchoolName
                    _EduHisNote = int.EduHisNote
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblempeducationhistory on DB.
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
	  if _DegreeName.Length = 0 then Ris = False
  if _DegreeName.Length > 512 then Ris = False
  if _Major.Length = 0 then Ris = False
  if _Major.Length > 512 then Ris = False
  if _SchoolName.Length = 0 then Ris = False
  if _SchoolName.Length > 512 then Ris = False
  if _EduHisNote.Length > 2147483647 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblempeducationhistory
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblempeducationhistory

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property EmpID() as integer

    
    Property DegreeName() as string

    
    Property Major() as string

    
    Property YearGrad() as integer

    
    Property SchoolName() as string

    
    Property EduHisNote() as string

    
#End Region

End Interface