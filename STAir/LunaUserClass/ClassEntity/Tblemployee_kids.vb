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
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Tblemployee_kids
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Tblemployee_kids
	Inherits _Tblemployee_kids
    Implements ITblemployee_kids

    Private cls As New clsDataSQL

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITblemployee_kids.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
    End Function

    Public Function Delete(ByVal id As Integer) As Boolean

        Dim strSQL As String
        strSQL = "delete from tblEmployee_Kids where ID = " & id.ToString

        Return cls.ExcuteData(strSQL)


    End Function


Public Overrides Function Read(Id As Integer) As Integer Implements ITblemployee_kids.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITblemployee_kids.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tblemployee_kids
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITblemployee_kids
        Inherits _ITblemployee_kids

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface