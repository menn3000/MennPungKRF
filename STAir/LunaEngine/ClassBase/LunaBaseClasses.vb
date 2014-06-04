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
Imports System.Configuration
Imports System.Data.Common

Namespace LUNA

    Public Enum enLogicOperator
        enAND = 0
        enOR
    End Enum

    Partial Public Class LunaContext
        Private Shared _ConnectionString As String = String.Empty
        Shared Sub New()


            If Not clsUtility.LiveCNS.Length = 0 Then
                _ConnectionString = clsUtility.LiveCNS

            ElseIf Not ConfigurationManager.ConnectionStrings(ProjectId & ".ConnectionString") Is Nothing Then
                _ConnectionString = ConfigurationManager.ConnectionStrings(ProjectId & ".ConnectionString").ConnectionString
            ElseIf Not ConfigurationManager.ConnectionStrings("ConnectionString") Is Nothing Then
                _ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            Else
                Throw New Exception("Luna Engine Exception: Connection String not configured!")
            End If

            Dim ParamValue As String = ConfigurationManager.AppSettings(ProjectId & ".LUNA.ShareConnection")

            ' Dim ParamValue As String = System.Configuration.ConfigurationManager.AppSettings(ProjectId & ".LUNA.ShareConnection")
            If Not ParamValue Is Nothing Then
                _ShareConnection = Convert.ToBoolean(ParamValue)
            End If

            ParamValue = ConfigurationManager.AppSettings(ProjectId & ".LUNA.DisableLazyLoading")
            If Not ParamValue Is Nothing Then
                _DisableLazyLoading = Convert.ToBoolean(ParamValue)
            End If

        End Sub

        Private Shared DbConnection As Data.IDbConnection
        Private Shared DbTransaction As Data.IDbTransaction
        Public Shared Property Connection As Data.IDbConnection
            Get
                Return DbConnection
            End Get
            Set(ByVal value As Data.IDbConnection)
                DbConnection = value
            End Set
        End Property
        Public Shared Property Transaction As Data.IDbTransaction
            Get
                Return DbTransaction
            End Get
            Set(ByVal value As Data.IDbTransaction)
                DbTransaction = value
            End Set
        End Property
        Public Shared Sub TransactionBegin()
            If DbTransaction Is Nothing Then
                DbTransaction = DbConnection.BeginTransaction
            End If
        End Sub
        Public Shared Sub TransactionCommit()
            If Not DbTransaction Is Nothing Then
                DbTransaction.Commit()
                DbTransaction.Dispose()
                DbTransaction = Nothing
            End If
        End Sub
        Public Shared Sub TransactionRollback()
            If Not DbTransaction Is Nothing Then
                DbTransaction.Rollback()
                DbTransaction.Dispose()
                DbTransaction = Nothing
            End If
        End Sub
        Private Shared Sub CloseConn(ByRef Conn As IDbConnection)
            If _TotConnAttive > 0 Then _TotConnAttive -= 1
            If Conn.State <> ConnectionState.Closed Then Conn.Close()
            Conn.Dispose()
            Conn = Nothing
        End Sub
        Public Shared Sub CloseDbConnection(Optional ByRef Conn As IDbConnection = Nothing)
            Try
                If Not Conn Is Nothing Then
                    If ShareConnection = False Then
                        CloseConn(Conn)
                    End If
                Else
                    CloseConn(DbConnection)
                End If

            Catch ex As Exception
            End Try
        End Sub
        Public Shared Function GetDbConnection(Optional ByVal ConnString As String = "") As IDbConnection
            Dim ris As IDbConnection = Nothing
            Try
                Dim ConnectionString As String = _ConnectionString
                If ConnString.Length Then
                    ConnectionString = ConnString
                End If
                ris = OpenConn(Connectionstring)
            Catch ex As Exception
                Throw New ApplicationException("Luna Engine Exception: Error Opening DB", ex)
            End Try
            Return ris
        End Function
        Protected Shared Function OpenConn(ByVal ConnString As String) As IDbConnection
            Dim Ris As IDbConnection
            Try
                If ShareConnection = False Then
                    Dim LunaFactory As DbProviderFactory
                    LunaFactory = DbProviderFactories.GetFactory(GetProviderFactory)
                    Ris = LunaFactory.CreateConnection
                    Ris.ConnectionString = ConnString
                    Ris.Open()
                    _TotConnAttive += 1
                Else
                    If DbConnection Is Nothing Then
                        Dim LunaFactory As DbProviderFactory
                        LunaFactory = DbProviderFactories.GetFactory(GetProviderFactory)
                        DbConnection = LunaFactory.CreateConnection
                        DbConnection.ConnectionString = ConnString
                        _TotConnAttive += 1
                    End If
                    If DbConnection.State <> Data.ConnectionState.Open Then DbConnection.Open()
                    Ris = DbConnection
                End If
            Catch ex As Exception
                Throw New ApplicationException("Luna Engine Exception: Error Opening DB", ex)
            End Try
            Return Ris
        End Function

        Private Shared _ShareConnection As Boolean = False
        Public Shared ReadOnly Property ShareConnection As Boolean
            Get
                Return _ShareConnection
            End Get
        End Property

        Private Shared _DisableLazyLoading As Boolean = False
        Public Shared ReadOnly Property DisableLazyLoading As Boolean
            Get
                Return _DisableLazyLoading
            End Get
        End Property

        Private Shared _ProviderFactory As String = String.Empty
        Friend Shared Function GetProviderFactory() As String
            If _ProviderFactory = String.Empty Then
                Dim ParamName As String = ProjectId & ".LUNA.Ioc.ProviderFactory"
                Dim ParamValue As String = ConfigurationManager.AppSettings(ParamName)
                If Not ParamValue Is Nothing Then
                    _ProviderFactory = ParamValue
                Else
                    _ProviderFactory = "System.Data.SqlClient"
                End If
            End If
            Return _ProviderFactory
        End Function

        Private Shared _MgrTypeForEntity As System.Type = Nothing
        Friend Shared Function GetMgrTypeForEntity(ByVal EntityName As System.Type) As System.Type
            If _MgrTypeForEntity Is Nothing Then
                Dim ParamName As String = ProjectId & ".LUNA.Ioc." & EntityName.Name
                Dim ParamValue As String = ConfigurationManager.AppSettings(ParamName)
                If Not ParamValue Is Nothing Then
                    _MgrTypeForEntity = Type.GetType(ParamValue, False, True)
                End If
            End If
            Return _MgrTypeForEntity
        End Function
        Private Shared _TotConnAttive As Integer = 0
        Public Shared ReadOnly Property TotConnAttive As Integer
            Get
                Return _TotConnAttive
            End Get
        End Property

    End Class

    Public MustInherit Class LunaBaseClass

        Public Sub ManageError(ByVal ex As Exception)
            Throw New ApplicationException("Luna Engine Exception: " & ex.Message, ex)
        End Sub

    End Class

    Public MustInherit Class LunaBaseClassEntity

        Inherits LunaBaseClass

        Private _IsChanged As Boolean = False
        Public Property IsChanged As Boolean
            Get
                Return _IsChanged
            End Get
            Set(ByVal value As Boolean)
                _IsChanged = value
            End Set
        End Property

        Public Overridable Function IsValid() As Boolean
            Return True
        End Function

    End Class

    Public Interface ILunaBaseClassDAO(Of T)
        Inherits IDisposable
        Function Read(ByVal Id As Integer) As T
        Function Save(ByRef obj As T) As Integer
        Sub Delete(ByVal Id As Integer)
        Sub Delete(ByRef obj As T, Optional ByRef ListaObj As List(Of T) = Nothing)
        Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of T)
        Function GetAll(Optional ByVal OrderByField As String = "", Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of T)
    End Interface

    Public MustInherit Class LunaBaseClassDAO(Of T)
        Inherits LunaBaseClass
        Implements IDisposable
        Implements ILunaBaseClassDAO(Of T)

        Protected _cn As IDbConnection

        Protected _ConnectionString As String = String.Empty
        Private _ConnAdHoc As Boolean = False

        Public Sub New()
            _cn = LUNA.LunaContext.GetDbConnection
        End Sub

        Public Sub New(ByVal Connection As IDbConnection)
            'Require a valid and OPEN DBconnection
            _cn = Connection
        End Sub

        Public MustOverride Function Read(ByVal Id As Integer) As T Implements ILunaBaseClassDAO(Of T).Read
        Public MustOverride Function Save(ByRef obj As T) As Integer Implements ILunaBaseClassDAO(Of T).Save
        Public MustOverride Sub Delete(ByVal Id As Integer) Implements ILunaBaseClassDAO(Of T).Delete
        Public MustOverride Sub Delete(ByRef obj As T, Optional ByRef ListaObj As List(Of T) = Nothing) Implements ILunaBaseClassDAO(Of T).Delete
        Public MustOverride Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of T) Implements ILunaBaseClassDAO(Of T).Find
        Public MustOverride Function GetAll(Optional ByVal OrderByField As String = "", Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of T) Implements ILunaBaseClassDAO(Of T).GetAll

        Public Function Ap(ByVal Valore) As String
            Dim str As String = String.Empty
            If TypeOf Valore Is String Then
                Str = Valore.ToString
                Str = Str.Replace("'", "''")
                Str = " '" & Str & "'"
            ElseIf TypeOf Valore Is Date Then
                str = "  convert(datetime,'" & DirectCast(Valore, Date).ToLongDateString & "')"

            ElseIf TypeOf Valore Is [Enum] Then
                str = " " & Valore
            Else
                Str = " " & Valore.ToString
            End If
            Return Str
        End Function

        Public Function ApN(ByVal Testo) As String
            Dim str As String = String.Empty
            str = Testo.ToString
            str = str.Replace(",", ".")
            Return str
        End Function

        Public Function ApLike(ByVal testo)
            Dim str As String
            str = testo.ToString
            str = str.Replace(" '", "''")
            str = "like '%" & str & "%'"
            Return str
        End Function

        Public Function ApLikeRight(ByVal testo)
            Dim str As String
            str = testo.ToString
            str = str.Replace(" '", "''")
            str = "like '" & str & "%'"
            Return str
        End Function

        Protected Function ApIn(ByVal Valore) As String
            Dim str As String = String.Empty
            str = Valore.ToString
            str = str.Replace("'", "''")
            Return str
        End Function

#Region "Serialization Method"
        Public Function ReadSerialize(ByVal PathXMLSerial As String) As T

            Dim cls As T
            Try
                Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
                Dim deSerialize As IO.FileStream = New IO.FileStream(PathXMLSerial, IO.FileMode.Open)
                cls = serialize.Deserialize(deSerialize)
            Catch ex As Exception
                ManageError(ex)
            End Try

            Return cls
        End Function
        Public Sub SaveSerialize(ByVal Obj As T, ByVal PathXML As String)

            Try
                Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
                Dim Writer As New System.IO.StreamWriter(PathXML)
                serialize.Serialize(Writer, Obj)
                Writer.Close()
            Catch ex As Exception
                ManageError(ex)
            End Try

        End Sub
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            LUNA.LunaContext.CloseDbConnection(_cn)
            Me.disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
#End Region

    End Class

    Public Class LunaSearchOption
        Public Property Top As Integer = 0
        Public Property OrderBy As String = ""
    End Class

    Public Class LunaSearchParameter

        Public Sub New()

        End Sub

        Public Sub New(ByVal FieldName As String, ByVal Value As Object, Optional ByVal SqlOperator As String = "", Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            _FieldName = FieldName
            _Value = Value
            If SqlOperator.Length Then _SqlOperator = SqlOperator
            _LogicOperator = LogicOperator
        End Sub

        Private _SqlOperator As String = " = "
        Public Property SqlOperator As String
            Get
                Return _SqlOperator
            End Get
            Set(ByVal value As String)
                _SqlOperator = value
            End Set
        End Property

        Private _LogicOperator As enLogicOperator = enLogicOperator.enAND
        Public Property LogicOperator As enLogicOperator
            Get
                Return _LogicOperator
            End Get
            Set(ByVal value As enLogicOperator)
                _LogicOperator = value
            End Set
        End Property

        Public ReadOnly Property LogicOperatorStr As String
            Get
                If _LogicOperator = enLogicOperator.enAND Then
                    Return " And "
                Else
                    Return " Or "
                End If
            End Get
        End Property

        Private _FieldName As String
        Public Property FieldName As String
            Get
                Return _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property

        Private _Value
        Public Property Value
            Get
                Return _Value
            End Get
            Set(ByVal value)
                _Value = value
            End Set
        End Property

    End Class

End Namespace

