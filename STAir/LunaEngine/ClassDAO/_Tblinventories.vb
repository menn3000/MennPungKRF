#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 25/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
                
''' <summary>
'''DAO Class for table Tblinventories
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Tblinventories
	Inherits LUNA.LunaBaseClassEntity
    Implements _ITblinventories
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

Public Sub New()

End Sub

Private _Mgr As LUNA.ILunaBaseClassDAO(Of Tblinventories)
Private Property Manager As LUNA.ILunaBaseClassDAO(Of Tblinventories)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(TblinventoriesDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Tblinventories))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Protected _ID as integer  = 0 
Public Overridable Property ID() as integer  Implements _ITblinventories.ID
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

Protected _InvCode as string  = "" 
Public Overridable Property InvCode() as string  Implements _ITblinventories.InvCode
    Get
	    Return _InvCode
    End Get
    Set (byval value as string)
	    If _InvCode <> value Then
	        IsChanged = True
	        _InvCode= value
	    End If
    End Set
End property 

Protected _InvName as string  = "" 
Public Overridable Property InvName() as string  Implements _ITblinventories.InvName
    Get
	    Return _InvName
    End Get
    Set (byval value as string)
	    If _InvName <> value Then
	        IsChanged = True
	        _InvName= value
	    End If
    End Set
End property 

Protected _Brand as string  = "" 
Public Overridable Property Brand() as string  Implements _ITblinventories.Brand
    Get
	    Return _Brand
    End Get
    Set (byval value as string)
	    If _Brand <> value Then
	        IsChanged = True
	        _Brand= value
	    End If
    End Set
End property 

Protected _Model as string  = "" 
Public Overridable Property Model() as string  Implements _ITblinventories.Model
    Get
	    Return _Model
    End Get
    Set (byval value as string)
	    If _Model <> value Then
	        IsChanged = True
	        _Model= value
	    End If
    End Set
End property 

Protected _Size as string  = "" 
Public Overridable Property Size() as string  Implements _ITblinventories.Size
    Get
	    Return _Size
    End Get
    Set (byval value as string)
	    If _Size <> value Then
	        IsChanged = True
	        _Size= value
	    End If
    End Set
End property 

Protected _Description as string  = "" 
Public Overridable Property Description() as string  Implements _ITblinventories.Description
    Get
	    Return _Description
    End Get
    Set (byval value as string)
	    If _Description <> value Then
	        IsChanged = True
	        _Description= value
	    End If
    End Set
End property 

Protected _InvCategoryID as integer  = 0 
Public Overridable Property InvCategoryID() as integer  Implements _ITblinventories.InvCategoryID
    Get
	    Return _InvCategoryID
    End Get
    Set (byval value as integer)
	    If _InvCategoryID <> value Then
	        IsChanged = True
	        _InvCategoryID= value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Tblinventories from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Tblinventories = Manager.Read(Id)
                    _ID = int.ID
                    _InvCode = int.InvCode
                    _InvName = int.InvName
                    _Brand = int.Brand
                    _Model = int.Model
                    _Size = int.Size
                    _Description = int.Description
                    _InvCategoryID = int.InvCategoryID
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Tblinventories on DB.
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
	  if _InvCode.Length > 50 then Ris = False
  if _InvName.Length = 0 then Ris = False
  if _InvName.Length > 255 then Ris = False
  if _Brand.Length = 0 then Ris = False
  if _Brand.Length > 255 then Ris = False
  if _Model.Length = 0 then Ris = False
  if _Model.Length > 255 then Ris = False
  if _Size.Length = 0 then Ris = False
  if _Size.Length > 255 then Ris = False
  if _Description.Length > 2147483647 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Tblinventories
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITblinventories

#Region "Database Field Map"

    
    Property ID() as integer

    
    Property InvCode() as string

    
    Property InvName() as string

    
    Property Brand() as string

    
    Property Model() as string

    
    Property Size() as string

    
    Property Description() as string

    
    Property InvCategoryID() as integer

    
#End Region

End Interface