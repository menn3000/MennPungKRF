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
Imports System.Data.SqlClient
Imports STAir.LUNA

''' <summary>
'''Entity Class for table Tblemplevelhistory
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Tblemplevelhistory
    Inherits _Tblemplevelhistory
    Implements ITblemplevelhistory


    Private cls As New clsDataSQL

#Region "Logic Field"


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITblemplevelhistory.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function


    Public Function Delete(ByVal id As Integer) As Boolean

        Dim strSQL As String
        strSQL = "delete from tblEmpLevelHistory where ID = " & id.ToString

        Return cls.ExcuteData(strSQL)


    End Function


    Public Overrides Function Read(ByVal Id As Integer) As Integer Implements ITblemplevelhistory.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ITblemplevelhistory.Save


        Dim bolReturn As Boolean = False
        Dim Ris As Integer

        Try

            Dim Cn As New SqlClient.SqlConnection(clsUtility.LiveCNS)
            Dim cmd As SqlCommand
            LUNA.LunaContext.Connection = Cn
            LunaContext.Connection.Open()
            LunaContext.Transaction = LunaContext.Connection.BeginTransaction(IsolationLevel.ReadCommitted)
            LunaContext.TransactionBegin()
            cmd = LunaContext.Connection.CreateCommand
            cmd.Transaction = LunaContext.Transaction
            'LunaContext.Connection.CreateCommand.Transaction = LunaContext.Transaction


            Ris = MyBase.Save()

            Dim strSQL As String = ""

            If Me.IsCurrent And Ris > 0 Then
                strSQL = "Update tblEmpLevelHistory set IsCurrent = 0 "
                strSQL += " , DateResign =  '" & cls.CtypeDateToEng(Me.DateAssigned.AddDays(-1), 99) & "'"
                strSQL += " , ResignNote =  'ปรับ อัตโนมัติโดยระบบ'"
                strSQL += " where EmpID = " & Me.EmpID.ToString & " and IsCurrent = 1 "
                strSQL += " and ID <> " & Ris.ToString
                cmd.CommandText = strSQL
                cmd.ExecuteNonQuery()

            End If



            LunaContext.TransactionCommit()
            bolReturn = True

        Catch ex As ApplicationException
            If ex.Message = "Saving New Employee level history error!" Then
                LunaContext.TransactionRollback()
            End If
        Finally

            LunaContext.Connection.Close()
        End Try



        Return Ris


    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Tblemplevelhistory
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITblemplevelhistory
    Inherits _ITblemplevelhistory

#Region "Method"

    Function Read(ByVal Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface