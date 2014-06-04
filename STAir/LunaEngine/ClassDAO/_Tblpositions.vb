#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 07/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
                
''' <summary>
'''DAO Class for table Tblpositions
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblpositions
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblpositions
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblpositions)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblpositions)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(TblpositionsDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblpositions))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblpositions.ID
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

Protected _PositionName as string  = "" 
Public Overridable Property PositionName() as string  Implements _ITblpositions.PositionName
    Get
	    Return _PositionName
    End Get
    Set (byval value as string)
	    If _PositionName <> value Then
	        IsChanged = True
	        _PositionName= value
	    End If
    End Set
End property 

Protected _PositionAbv as string  = "" 
Public Overridable Property PositionAbv() as string  Implements _ITblpositions.PositionAbv
    Get
	    Return _PositionAbv
    End Get
    Set (byval value as string)
	    If _PositionAbv <> value Then
	        IsChanged = True
	        _PositionAbv= value
	    End If
    End Set
End property 

Protected _DefaultAirModuleLevel as integer  = 0 
Public Overridable Property DefaultAirModuleLevel() as integer  Implements _ITblpositions.DefaultAirModuleLevel
    Get
	    Return _DefaultAirModuleLevel
    End Get
    Set (byval value as integer)
	    If _DefaultAirModuleLevel <> value Then
	        IsChanged = True
	        _DefaultAirModuleLevel= value
	    End If
    End Set
End property 

Protected _DefaultAdminModuleLevel as integer  = 0 
Public Overridable Property DefaultAdminModuleLevel() as integer  Implements _ITblpositions.DefaultAdminModuleLevel
    Get
	    Return _DefaultAdminModuleLevel
    End Get
    Set (byval value as integer)
	    If _DefaultAdminModuleLevel <> value Then
	        IsChanged = True
	        _DefaultAdminModuleLevel= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblpositions from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblpositions = Manager.Read(Id)
                    _ID = int.ID
                    _PositionName = int.PositionName
                    _PositionAbv = int.PositionAbv
                    _DefaultAirModuleLevel = int.DefaultAirModuleLevel
                    _DefaultAdminModuleLevel = int.DefaultAdminModuleLevel
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblpositions on DB.
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
	  if _PositionName.Length = 0 then Ris = False
  if _PositionName.Length > 100 then Ris = False
  if _PositionAbv.Length = 0 then Ris = False
  if _PositionAbv.Length > 20 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblpositions
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblpositions

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property PositionName() as string

    
    Property PositionAbv() as string

    
    Property DefaultAirModuleLevel() as integer

    
    Property DefaultAdminModuleLevel() as integer

    
#End Region

End Interface