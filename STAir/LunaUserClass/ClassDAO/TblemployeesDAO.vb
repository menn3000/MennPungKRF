#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.26783 
'Author: Diego Lunadei
'Date: 04/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
'''DAO Class for table Tblemployees
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TblemployeesDAO
	Inherits _TblemployeesDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

  


End Class