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
'''DAO Class for table Tblemployees
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblemployees
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblemployees
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblemployees)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblemployees)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(TblemployeesDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblemployees))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblemployees.ID
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

Protected _MainCategory as integer  = 0 
Public Overridable Property MainCategory() as integer  Implements _ITblemployees.MainCategory
    Get
	    Return _MainCategory
    End Get
    Set (byval value as integer)
	    If _MainCategory <> value Then
	        IsChanged = True
	        _MainCategory= value
	    End If
    End Set
End property 

Protected _EmployeeID as string  = "" 
Public Overridable Property EmployeeID() as string  Implements _ITblemployees.EmployeeID
    Get
	    Return _EmployeeID
    End Get
    Set (byval value as string)
	    If _EmployeeID <> value Then
	        IsChanged = True
	        _EmployeeID= value
	    End If
    End Set
End property 

Protected _Password as string  = "" 
Public Overridable Property Password() as string  Implements _ITblemployees.Password
    Get
	    Return _Password
    End Get
    Set (byval value as string)
	    If _Password <> value Then
	        IsChanged = True
	        _Password= value
	    End If
    End Set
End property 

Protected _prefix as string  = "" 
Public Overridable Property prefix() as string  Implements _ITblemployees.prefix
    Get
	    Return _prefix
    End Get
    Set (byval value as string)
	    If _prefix <> value Then
	        IsChanged = True
	        _prefix= value
	    End If
    End Set
End property 

Protected _FName as string  = "" 
Public Overridable Property FName() as string  Implements _ITblemployees.FName
    Get
	    Return _FName
    End Get
    Set (byval value as string)
	    If _FName <> value Then
	        IsChanged = True
	        _FName= value
	    End If
    End Set
End property 

Protected _LName as string  = "" 
Public Overridable Property LName() as string  Implements _ITblemployees.LName
    Get
	    Return _LName
    End Get
    Set (byval value as string)
	    If _LName <> value Then
	        IsChanged = True
	        _LName= value
	    End If
    End Set
End property 

Protected _FNameEn as string  = "" 
Public Overridable Property FNameEn() as string  Implements _ITblemployees.FNameEn
    Get
	    Return _FNameEn
    End Get
    Set (byval value as string)
	    If _FNameEn <> value Then
	        IsChanged = True
	        _FNameEn= value
	    End If
    End Set
End property 

Protected _LNameEn as string  = "" 
Public Overridable Property LNameEn() as string  Implements _ITblemployees.LNameEn
    Get
	    Return _LNameEn
    End Get
    Set (byval value as string)
	    If _LNameEn <> value Then
	        IsChanged = True
	        _LNameEn= value
	    End If
    End Set
End property 

Protected _NationalID as string  = "" 
Public Overridable Property NationalID() as string  Implements _ITblemployees.NationalID
    Get
	    Return _NationalID
    End Get
    Set (byval value as string)
	    If _NationalID <> value Then
	        IsChanged = True
	        _NationalID= value
	    End If
    End Set
End property 

Protected _NickName as string  = "" 
Public Overridable Property NickName() as string  Implements _ITblemployees.NickName
    Get
	    Return _NickName
    End Get
    Set (byval value as string)
	    If _NickName <> value Then
	        IsChanged = True
	        _NickName= value
	    End If
    End Set
End property 

Protected _DOB as DateTime  = Nothing 
Public Overridable Property DOB() as DateTime  Implements _ITblemployees.DOB
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

Protected _Address as string  = "" 
Public Overridable Property Address() as string  Implements _ITblemployees.Address
    Get
	    Return _Address
    End Get
    Set (byval value as string)
	    If _Address <> value Then
	        IsChanged = True
	        _Address= value
	    End If
    End Set
End property 

Protected _CurrentPositionID as integer  = 0 
Public Overridable Property CurrentPositionID() as integer  Implements _ITblemployees.CurrentPositionID
    Get
	    Return _CurrentPositionID
    End Get
    Set (byval value as integer)
	    If _CurrentPositionID <> value Then
	        IsChanged = True
	        _CurrentPositionID= value
	    End If
    End Set
End property 

Protected _WorkLine as string  = "" 
Public Overridable Property WorkLine() as string  Implements _ITblemployees.WorkLine
    Get
	    Return _WorkLine
    End Get
    Set (byval value as string)
	    If _WorkLine <> value Then
	        IsChanged = True
	        _WorkLine= value
	    End If
    End Set
End property 

Protected _Email as string  = "" 
Public Overridable Property Email() as string  Implements _ITblemployees.Email
    Get
	    Return _Email
    End Get
    Set (byval value as string)
	    If _Email <> value Then
	        IsChanged = True
	        _Email= value
	    End If
    End Set
End property 

Protected _MobilePhone as string  = "" 
Public Overridable Property MobilePhone() as string  Implements _ITblemployees.MobilePhone
    Get
	    Return _MobilePhone
    End Get
    Set (byval value as string)
	    If _MobilePhone <> value Then
	        IsChanged = True
	        _MobilePhone= value
	    End If
    End Set
End property 

Protected _DateTimeStamp as DateTime  = Nothing 
Public Overridable Property DateTimeStamp() as DateTime  Implements _ITblemployees.DateTimeStamp
    Get
	    Return _DateTimeStamp
    End Get
    Set (byval value as DateTime)
	    If _DateTimeStamp <> value Then
	        IsChanged = True
	        _DateTimeStamp= value
	    End If
    End Set
End property 

Protected _UpdatedBy as integer  = 0 
Public Overridable Property UpdatedBy() as integer  Implements _ITblemployees.UpdatedBy
    Get
	    Return _UpdatedBy
    End Get
    Set (byval value as integer)
	    If _UpdatedBy <> value Then
	        IsChanged = True
	        _UpdatedBy= value
	    End If
    End Set
End property 

Protected _OverWriteAirModuleLevel as integer  = 0 
Public Overridable Property OverWriteAirModuleLevel() as integer  Implements _ITblemployees.OverWriteAirModuleLevel
    Get
	    Return _OverWriteAirModuleLevel
    End Get
    Set (byval value as integer)
	    If _OverWriteAirModuleLevel <> value Then
	        IsChanged = True
	        _OverWriteAirModuleLevel= value
	    End If
    End Set
End property 

Protected _OverWriteAdminModuleLevel as integer  = 0 
Public Overridable Property OverWriteAdminModuleLevel() as integer  Implements _ITblemployees.OverWriteAdminModuleLevel
    Get
	    Return _OverWriteAdminModuleLevel
    End Get
    Set (byval value as integer)
	    If _OverWriteAdminModuleLevel <> value Then
	        IsChanged = True
	        _OverWriteAdminModuleLevel= value
	    End If
    End Set
End property 

Protected _OverWriteInvModuleLevel as integer  = 0 
Public Overridable Property OverWriteInvModuleLevel() as integer  Implements _ITblemployees.OverWriteInvModuleLevel
    Get
	    Return _OverWriteInvModuleLevel
    End Get
    Set (byval value as integer)
	    If _OverWriteInvModuleLevel <> value Then
	        IsChanged = True
	        _OverWriteInvModuleLevel= value
	    End If
    End Set
End property 

Protected _OverWriteFieldWorkModuleLevel as integer  = 0 
Public Overridable Property OverWriteFieldWorkModuleLevel() as integer  Implements _ITblemployees.OverWriteFieldWorkModuleLevel
    Get
	    Return _OverWriteFieldWorkModuleLevel
    End Get
    Set (byval value as integer)
	    If _OverWriteFieldWorkModuleLevel <> value Then
	        IsChanged = True
	        _OverWriteFieldWorkModuleLevel= value
	    End If
    End Set
End property 

Protected _MariageStatus as string  = "" 
Public Overridable Property MariageStatus() as string  Implements _ITblemployees.MariageStatus
    Get
	    Return _MariageStatus
    End Get
    Set (byval value as string)
	    If _MariageStatus <> value Then
	        IsChanged = True
	        _MariageStatus= value
	    End If
    End Set
End property 

Protected _FatherName as string  = "" 
Public Overridable Property FatherName() as string  Implements _ITblemployees.FatherName
    Get
	    Return _FatherName
    End Get
    Set (byval value as string)
	    If _FatherName <> value Then
	        IsChanged = True
	        _FatherName= value
	    End If
    End Set
End property 

Protected _FatherAlive as Boolean  = False 
Public Overridable Property FatherAlive() as Boolean  Implements _ITblemployees.FatherAlive
    Get
	    Return _FatherAlive
    End Get
    Set (byval value as Boolean)
	    If _FatherAlive <> value Then
	        IsChanged = True
	        _FatherAlive= value
	    End If
    End Set
End property 

Protected _MotherName as string  = "" 
Public Overridable Property MotherName() as string  Implements _ITblemployees.MotherName
    Get
	    Return _MotherName
    End Get
    Set (byval value as string)
	    If _MotherName <> value Then
	        IsChanged = True
	        _MotherName= value
	    End If
    End Set
End property 

Protected _MotherAlive as Boolean  = False 
Public Overridable Property MotherAlive() as Boolean  Implements _ITblemployees.MotherAlive
    Get
	    Return _MotherAlive
    End Get
    Set (byval value as Boolean)
	    If _MotherAlive <> value Then
	        IsChanged = True
	        _MotherAlive= value
	    End If
    End Set
End property 

Protected _SpouseName as string  = "" 
Public Overridable Property SpouseName() as string  Implements _ITblemployees.SpouseName
    Get
	    Return _SpouseName
    End Get
    Set (byval value as string)
	    If _SpouseName <> value Then
	        IsChanged = True
	        _SpouseName= value
	    End If
    End Set
End property 

Protected _SpouseAlive as Boolean  = False 
Public Overridable Property SpouseAlive() as Boolean  Implements _ITblemployees.SpouseAlive
    Get
	    Return _SpouseAlive
    End Get
    Set (byval value as Boolean)
	    If _SpouseAlive <> value Then
	        IsChanged = True
	        _SpouseAlive= value
	    End If
    End Set
End property 

Protected _EmpImageFilePath as string  = "" 
Public Overridable Property EmpImageFilePath() as string  Implements _ITblemployees.EmpImageFilePath
    Get
	    Return _EmpImageFilePath
    End Get
    Set (byval value as string)
	    If _EmpImageFilePath <> value Then
	        IsChanged = True
	        _EmpImageFilePath= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblemployees from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblemployees = Manager.Read(Id)
                    _ID = int.ID
                    _MainCategory = int.MainCategory
                    _EmployeeID = int.EmployeeID
                    _Password = int.Password
                    _prefix = int.prefix
                    _FName = int.FName
                    _LName = int.LName
                    _FNameEn = int.FNameEn
                    _LNameEn = int.LNameEn
                    _NationalID = int.NationalID
                    _NickName = int.NickName
                    _DOB = int.DOB
                    _Address = int.Address
                    _CurrentPositionID = int.CurrentPositionID
                    _WorkLine = int.WorkLine
                    _Email = int.Email
                    _MobilePhone = int.MobilePhone
                    _DateTimeStamp = int.DateTimeStamp
                    _UpdatedBy = int.UpdatedBy
                    _OverWriteAirModuleLevel = int.OverWriteAirModuleLevel
                    _OverWriteAdminModuleLevel = int.OverWriteAdminModuleLevel
                    _OverWriteInvModuleLevel = int.OverWriteInvModuleLevel
                    _OverWriteFieldWorkModuleLevel = int.OverWriteFieldWorkModuleLevel
                    _MariageStatus = int.MariageStatus
                    _FatherName = int.FatherName
                    _FatherAlive = int.FatherAlive
                    _MotherName = int.MotherName
                    _MotherAlive = int.MotherAlive
                    _SpouseName = int.SpouseName
                    _SpouseAlive = int.SpouseAlive
                    _EmpImageFilePath = int.EmpImageFilePath
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblemployees on DB.
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
	  if _EmployeeID.Length = 0 then Ris = False
  if _EmployeeID.Length > 50 then Ris = False
  if _Password.Length = 0 then Ris = False
  if _Password.Length > 200 then Ris = False
  if _prefix.Length > 25 then Ris = False
  if _FName.Length = 0 then Ris = False
  if _FName.Length > 100 then Ris = False
  if _LName.Length = 0 then Ris = False
  if _LName.Length > 100 then Ris = False
  if _FNameEn.Length > 100 then Ris = False
  if _LNameEn.Length > 100 then Ris = False
  if _NationalID.Length > 20 then Ris = False
  if _NickName.Length > 100 then Ris = False
  if _Address.Length > 512 then Ris = False
  if _WorkLine.Length > 100 then Ris = False
  if _Email.Length > 100 then Ris = False
  if _MobilePhone.Length > 100 then Ris = False
  if _MariageStatus.Length > 100 then Ris = False
  if _FatherName.Length > 512 then Ris = False
  if _MotherName.Length > 512 then Ris = False
  if _SpouseName.Length > 512 then Ris = False
  if _EmpImageFilePath.Length > 100 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblemployees
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblemployees

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property MainCategory() as integer

    
    Property EmployeeID() as string

    
    Property Password() as string

    
    Property prefix() as string

    
    Property FName() as string

    
    Property LName() as string

    
    Property FNameEn() as string

    
    Property LNameEn() as string

    
    Property NationalID() as string

    
    Property NickName() as string

    
    Property DOB() as DateTime

    
    Property Address() as string

    
    Property CurrentPositionID() as integer

    
    Property WorkLine() as string

    
    Property Email() as string

    
    Property MobilePhone() as string

    
    Property DateTimeStamp() as DateTime

    
    Property UpdatedBy() as integer

    
    Property OverWriteAirModuleLevel() as integer

    
    Property OverWriteAdminModuleLevel() as integer

    
    Property OverWriteInvModuleLevel() as integer

    
    Property OverWriteFieldWorkModuleLevel() as integer

    
    Property MariageStatus() as string

    
    Property FatherName() as string

    
    Property FatherAlive() as Boolean

    
    Property MotherName() as string

    
    Property MotherAlive() as Boolean

    
    Property SpouseName() as string

    
    Property SpouseAlive() as Boolean

    
    Property EmpImageFilePath() as string

    
#End Region

End Interface