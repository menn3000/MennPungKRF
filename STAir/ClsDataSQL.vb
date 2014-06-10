Imports System.Text
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Collections
'Imports System.Web.Mail
Imports System.Net.Mail




Public Class clsDataSQL

    Friend CNS As String
    Public objConn As SqlConnection
    Private objComm As SqlCommand
    Private objAdapter As SqlDataAdapter
    Friend Shared dtbItems As DataTable
    Friend strDatabaseProfile As String



    Public Sub New()
        'get connection string from .config file


        Try
            strDatabaseProfile = System.Configuration.ConfigurationManager.AppSettings("NetDBFilePathProfile")
        Catch
            strDatabaseProfile = clsUtility.strDBProfileTesting
        End Try


        Select Case strDatabaseProfile
            Case clsUtility.strDBProfileDeveloping
                CNS = "Data Source=(local);Initial Catalog=STAir;User Id=FastkeyUser;Password=voa12345;Connect Timeout=300;"

            Case clsUtility.strDBProfileTesting
                CNS = "Server=Admin01;Database=STAir;User Id=sa;Password=0812587733;Connect Timeout=300;"
            Case clsUtility.strDBProfileProduction
                CNS = "Data Source=(local);Initial Catalog=STAir;User Id=FastkeyUser;Password=voa12345;Connect Timeout=300;"
            Case clsUtility.strDBProfileTraining
                CNS = "Data Source=(local);Initial Catalog=STAir;User Id=FastkeyUser;Password=voa12345;Connect Timeout=300;"

            Case Else
                CNS = "Data Source=(local);Initial Catalog=STAir;User Id=FastkeyUser;Password=voa12345;Connect Timeout=300;"
        End Select


        'OverWriteNetDBFilepathString for Debuging purpose
        Dim strOverWriteNetDBFilepathString As String = System.Configuration.ConfigurationManager.AppSettings("OverWriteNetDBFilepathString")
        If strOverWriteNetDBFilepathString <> "" Then
            CNS = strOverWriteNetDBFilepathString
        End If


        clsUtility.LiveCNS = CNS

        objConn = New SqlConnection(CNS)

    End Sub


    Public Sub DB_Connect()
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
    End Sub

    Public Sub DB_Disconnect()
        If Not objConn.State = ConnectionState.Closed Then objConn.Close()
    End Sub

    Public Function DB_GetDataReader(ByVal strStmt As String) As SqlDataReader
        Call DB_Connect()

        objComm = New SqlCommand(strStmt, objConn)
        DB_GetDataReader = objComm.ExecuteReader(CommandBehavior.CloseConnection)
        objComm = Nothing

    End Function
    Public Function DB_GetDataReader(ByVal cmd As SqlCommand) As SqlDataReader

        Dim objConn As New SqlConnection(CNS)
        Dim dr As SqlDataReader

        cmd.Connection = objConn
        objConn.Open()
        dr = cmd.ExecuteReader
        Return dr
    End Function

    Public Function DB_GetDataSet(ByVal cmd As SqlCommand, ByVal strTableName As String, Optional ByVal bolFillSchema As Boolean = False) As DataSet
        Call DB_Connect()
        DB_GetDataSet = New DataSet
        objAdapter = New SqlDataAdapter(cmd)
        If bolFillSchema = True Then
            objAdapter.FillSchema(DB_GetDataSet, SchemaType.Mapped, strTableName)
        End If
        objAdapter.Fill(DB_GetDataSet, strTableName)
        objAdapter = Nothing
        Call DB_Disconnect()

    End Function

    Public Function DB_GetDataSet(ByVal strStmt As String, ByVal strTableName As String) As DataSet
        Call DB_Connect()
        DB_GetDataSet = New DataSet
        objAdapter = New SqlDataAdapter(strStmt, objConn)
        objAdapter.FillSchema(DB_GetDataSet, SchemaType.Mapped, strTableName)
        objAdapter.Fill(DB_GetDataSet, strTableName)
        objAdapter = Nothing
        Call DB_Disconnect()
    End Function




    Public Function DB_GetDataSet(ByVal strStmt As String, ByVal strTableName As String, ByVal bolFillSchema As Boolean) As DataSet

        Call DB_Connect()
        DB_GetDataSet = New DataSet()
        objAdapter = New SqlDataAdapter(strStmt, objConn)
        If bolFillSchema = True Then
            objAdapter.FillSchema(DB_GetDataSet, SchemaType.Mapped, strTableName)
        End If
        objAdapter.Fill(DB_GetDataSet, strTableName)
        objAdapter = Nothing
        Call DB_Disconnect()
    End Function

    'Public Function DB_GetDataSetFromTurboLister(ByVal strStmt As String, ByVal strTableName As String) As DataSet
    '    Dim objConnTL As SQLConnection = New SQLConnection(cnsTL)
    '    objConnTL.Open()
    '    DB_GetDataSetFromTurboLister = New DataSet()
    '    objAdapter = New SQLDataAdapter(strStmt, objConnTL)
    '    objAdapter.FillSchema(DB_GetDataSetFromTurboLister, SchemaType.Mapped, strTableName)
    '    objAdapter.Fill(DB_GetDataSetFromTurboLister, strTableName)
    '    objAdapter = Nothing
    '    objConnTL.Close()
    'End Function

    Public Function DB_GetDataSet_MultiTable(ByVal arrStmt() As String, ByVal arrTableName() As String, Optional ByVal bolFillSchema As Boolean = True) As DataSet
        ' DESCRIPTION: 
        '                                Data accessing function for multiple Tables 
        ' INPUT: 
        '                                Array of  SQL Statement and Array of  table name
        ' OUTPUT:
        '                                DataSet
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
        Call DB_Connect()
        Dim i As Int16

        DB_GetDataSet_MultiTable = New DataSet
        DB_GetDataSet_MultiTable.EnforceConstraints = False

        Dim cmd As New SqlCommand()


        cmd.Connection = objConn
        cmd.CommandTimeout = 200

        For i = 0 To UBound(arrStmt)
            If Not arrStmt(i) = "" And Not arrTableName(i) = "" Then
                cmd.CommandText = arrStmt(i)
                objAdapter = New SqlDataAdapter(cmd)

                If bolFillSchema = True Then
                    objAdapter.FillSchema(DB_GetDataSet_MultiTable, SchemaType.Source, arrTableName(i))
                End If

                objAdapter.Fill(DB_GetDataSet_MultiTable, arrTableName(i))
            End If
            Application.DoEvents()
        Next

        objAdapter = Nothing
        cmd = Nothing

        Call DB_Disconnect()
    End Function
    Public Function DB_GetDataSet_MultiTableWithParams(ByVal aryCMD As List(Of SqlCommand), ByVal arrTableName() As String, Optional ByVal bolFillSchema As Boolean = True) As DataSet
        ' DESCRIPTION: 
        '                                Data accessing function for multiple Tables 
        ' INPUT: 
        '                                Array of  SQL Statement and Array of  table name
        ' OUTPUT:
        '                                DataSet
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
        Call DB_Connect()
        Dim i As Int16

        DB_GetDataSet_MultiTableWithParams = New DataSet
        DB_GetDataSet_MultiTableWithParams.EnforceConstraints = False

        Dim cmd As SqlCommand



        For i = 0 To aryCMD.Count - 1
            cmd = aryCMD(i)
            objAdapter = New SqlDataAdapter(cmd)
            cmd.Connection = objConn
            cmd.CommandTimeout = 200
            If bolFillSchema = True Then
                objAdapter.FillSchema(DB_GetDataSet_MultiTableWithParams, SchemaType.Source, arrTableName(i))
            End If
            objAdapter.Fill(DB_GetDataSet_MultiTableWithParams, arrTableName(i))
        Next

        objAdapter = Nothing
        cmd = Nothing

        Call DB_Disconnect()
    End Function
    Public Function ExcuteData(ByVal strSQL As String, Optional ByRef intRowEffected As Integer = 0) As Boolean
        ' DESCRIPTION: 
        '                                Data Excuting function
        ' INPUT: 
        '                                 SQL Statement
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '  
        Dim ran As New Random


        Dim bolReturn As Boolean
        Dim objConn As New SqlConnection(CNS)
        Dim cmd As SqlCommand
        cmd = New SqlCommand(strSQL, objConn)
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        Try
            intRowEffected = cmd.ExecuteNonQuery()
            bolReturn = True

        Catch ex As Exception
            WriteLog(strSQL, ex.Message)
            bolReturn = False
        Finally
            objConn.Close()
            objConn = Nothing
        End Try
        Return bolReturn
    End Function

    Private Function GetDBLogSQL(ByVal intUserID As Integer, ByVal intExcuteGroup As Integer) As String


        Dim strDBLog As String = "Insert into tblDBModifyLog (UserId,SQLStatement,DateTimeExcute,DBDateTime,ExcuteGroup) Values ( "
        strDBLog += intUserID & ", "
        strDBLog += "@OriginalSQL, "
        strDBLog += "'" & Now & "' , "
        strDBLog += "CURRENT_TIMESTAMP ,"
        strDBLog += intExcuteGroup & " )"

        Return strDBLog
    End Function

    Public Function InsertData(ByVal strSQL As String) As Int64
        ' DESCRIPTION: 
        '                                Data Excuting function
        ' INPUT: 
        '                                 SQL Statement
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
        Dim objConn As New SqlConnection(CNS)
        Dim cmd As SqlCommand
        Try
            cmd = New SqlCommand(strSQL, objConn)
            objConn.Open()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select @@Identity"
            Dim intID As Int64
            intID = Int64.Parse(cmd.ExecuteScalar())
            Return intID
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function InsertData(ByVal cmd As SqlCommand) As Int64
        ' DESCRIPTION: 
        '                                Data Excuting function
        ' INPUT: 
        '                                 SQL Statement
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '    
        '                      REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
        Try
            Dim objConn As New SqlConnection(CNS)
            cmd.Connection = objConn
            objConn.Open()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select @@Identity"
            Dim intID As Int64
            intID = Int64.Parse(cmd.ExecuteScalar())
            Return intID
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ExcuteData(ByVal cmd As SqlCommand) As Int64
        ' DESCRIPTION: 
        '                                Data Excuting function
        ' INPUT: 
        '                                 SQL Statement
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '    
        '                      REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
        Try
            Dim objConn As New SqlConnection(CNS)
            Dim intID As Int64
            cmd.Connection = objConn
            objConn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select @@Identity"
            intID = Int16.Parse(cmd.ExecuteScalar())

            Return intID
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ExcuteWithParams(ByVal strSql As String, ByVal Params As Hashtable) As Integer
        ' this excute 1 sql with 1 hashtable of Parameters

        Dim intReturn As Integer = -1
        ' Initialize SPROC 
        ' Try

        Dim cmd As New SqlCommand(strSql, objConn)
        cmd.CommandType = CommandType.Text
        ' Add Parameters 
        For Each key As String In Params.Keys
            cmd.Parameters.AddWithValue(key, Params.Item(key))
        Next

        Me.DB_Connect()
        intReturn = cmd.ExecuteNonQuery()
        Me.DB_Disconnect()
        ' Catch ex As Exception

        ' End Try
        Return intReturn
    End Function
    Public Function Excute1SQLWithMultiItemsParams(ByVal strSql As String, ByVal AryOFHashTableParams As ArrayList) As Integer
        ' this excute 1 sql with multiple hashtables of Parameters

        Dim intRowEffected As Integer = 0
        ' Initialize SPROC 
        ' Try


        'create command (this case strSQL and connection will never be change, ONLY params changed later)
        Dim cmd As New SqlCommand(strSql, objConn)

        Me.DB_Connect()

        Dim Params As Hashtable

        For i As Integer = 0 To AryOFHashTableParams.Count - 1
            'Clear previous Params
            cmd.Parameters.Clear()
            'Get param hashtable from arraylist
            Params = AryOFHashTableParams.Item(i)
            ' Add Parameters 
            For Each key As String In Params.Keys
                cmd.Parameters.AddWithValue(key, Params.Item(key))
            Next
            intRowEffected += cmd.ExecuteNonQuery()
        Next


        Me.DB_Disconnect()
        ' Catch ex As Exception

        ' End Try
        Return intRowEffected
    End Function

    Public Function ExcuteDataWithRollBack(ByVal aryLstSQL As ArrayList) As Boolean
        ' DESCRIPTION: 
        '                                Data Excuting function
        '                             excute multiple statements using same connection , in order to make it fast 
        ' INPUT: 
        '                                 ArrayList of SQL Statements
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK


        ' if error then Log and go to next statement

        Dim bolReturn As Boolean = False
        Dim strErrMessage As String
        DB_Connect()
        Dim trans As SqlTransaction = _
          objConn.BeginTransaction(IsolationLevel.ReadCommitted)


        Dim cmd As New SqlCommand
        cmd.Connection = objConn
        cmd.Transaction = trans
        cmd.CommandTimeout = 0

        Me.DB_Connect()
        Dim i As Integer
        Try
            For i = 0 To aryLstSQL.Count - 1
                If Not Trim(aryLstSQL(i)) = "" Then
                    cmd.CommandText = aryLstSQL(i)
                    cmd.ExecuteNonQuery()
                End If
            Next

            'Commit 
            trans.Commit()
            bolReturn = True
        Catch ex As Exception
            trans.Rollback()
            strErrMessage = ex.Message
            WriteLog("SQL = " & aryLstSQL(i), "Error (rollBacked) = " & strErrMessage)
            MsgBox("มีความผิดพลาดเกิดขึ้น การอัฟเดตฐานข้อมูลไม่สำเร็จ แจ้งพี่เม่นด้วย" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            bolReturn = False
        Finally
            Me.DB_Disconnect()
        End Try
        Return bolReturn
    End Function
    Public Function ExcuteData(ByVal aryLstSQL As ArrayList, ByVal intUserID As Integer) As Boolean
        ' DESCRIPTION: 
        '                                Data Excuting function
        '                             excute multiple statements using same connection , in order to make it fast 
        ' INPUT: 
        '                                 ArrayList of SQL Statements
        ' OUTPUT:
        '                                boolean Complete or incomplete
        'REVISION HISTORY 
        '                                   Created on 13 AUG 2004
        '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK


        ' if error then Log and go to next statement


        Dim ran As New Random
        Dim intExcuteGroup As Integer = ran.Next

        Dim objConn As New SqlConnection(CNS)
        Dim cmd As SqlCommand
        Dim hasError As Boolean = False
        Dim strErrMessage As String : Dim intErrorCounter As Integer
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        Dim i As Integer
        For i = 0 To aryLstSQL.Count - 1
            If Not Trim(aryLstSQL(i)) = "" Then
                cmd = New SqlCommand(aryLstSQL(i), objConn)
                Try
                    cmd.ExecuteNonQuery()
                    hasError = False

                Catch e As Exception
                    hasError = True
                    strErrMessage = e.Message
                End Try
            End If
            If hasError = True Then
                WriteLog("SQL = " & aryLstSQL(i), "Error = " & strErrMessage)
                intErrorCounter += 1
            End If
        Next
        If intErrorCounter > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Function InsertBatchData(ByVal aryLstSQLAndID As ArrayList, ByRef arySuccessID As ArrayList, ByRef aryFailId As ArrayList) As Boolean


        ' if error then Log and go to next statement
        Dim objConn As New SqlConnection(CNS)
        Dim cmd As SqlCommand
        Dim hasError As Boolean = False
        Dim strErrMessage As String : Dim intErrorCounter As Integer
        If Not objConn.State = ConnectionState.Open Then objConn.Open()
        Dim i As Integer
        Dim strSQLAndIDAndVerifyStr(3) As String
        Dim drVerify As SqlDataReader

        For i = 0 To aryLstSQLAndID.Count - 1
            strSQLAndIDAndVerifyStr = aryLstSQLAndID(i)

            If Not Trim(strSQLAndIDAndVerifyStr(0)) = "" Then

                'RunVerifyStr first -------------------
                If Not Trim(strSQLAndIDAndVerifyStr(2)) = "" Then
                    cmd = New SqlCommand(strSQLAndIDAndVerifyStr(2), objConn)

                    drVerify = cmd.ExecuteReader(CommandBehavior.Default)
                    If drVerify.Read Then

                        WriteLog("DUPLICATE TXN_ID - " & strSQLAndIDAndVerifyStr(2), "SQL = " & strSQLAndIDAndVerifyStr(0))
                        'EmailAdmin("Duplicate txn id", "DUPLICATE TXN_ID - " & strSQLAndIDAndVerifyStr(2) & vbCrLf & vbCrLf & "SQL = " & strSQLAndIDAndVerifyStr(0))
                        GoTo NextLoop
                    End If
                    drVerify.Close()
                End If
                '/RunVerifyStr -------------------

                cmd = New SqlCommand(strSQLAndIDAndVerifyStr(0), objConn)
                Try
                    cmd.ExecuteNonQuery()
                    arySuccessID.Add(CInt(strSQLAndIDAndVerifyStr(1)))
                    hasError = False
                Catch e As Exception
                    aryFailId.Add(CInt(strSQLAndIDAndVerifyStr(1)))
                    hasError = True
                    strErrMessage = e.Message
                End Try
            End If
            If hasError = True Then
                WriteLog("SQL = " & strSQLAndIDAndVerifyStr(0), "Error = " & strErrMessage)
                intErrorCounter += 1
            End If

NextLoop:
            If drVerify.IsClosed = False Then
                drVerify.Close()
            End If
        Next
        If intErrorCounter > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub GetItems()
        Dim strSQL As String
        strSQL = "Select * from tblItem order by Name, MyCategory"
        dtbItems = New DataTable("Items")
        Dim ds As New DataSet
        ds.Tables.Add(dtbItems)
        ds = Me.DB_GetDataSet(strSQL, "Items")
        'Me.dtbItems = ds.Tables("Items")
        clsDataSQL.dtbItems = ds.Tables("Items")
    End Sub
    Friend Sub CreateItemsTableColumn(ByRef dtbTable As DataTable)
        dtbTable.Columns.Add("ID", Type.GetType("System.Int32"))
        dtbTable.Columns.Add("Name", Type.GetType("System.String"))
    End Sub

    'Public Function ExcuteData(ByVal aryLstSQL As ArrayList) As Boolean
    '    ' DESCRIPTION: 
    '    '                                Data Excuting function
    '    '                             excute multiple statements using same connection , in order to make it fast 
    '    ' INPUT: 
    '    '                                 ArrayList of SQL Statements
    '    ' OUTPUT:
    '    '                                boolean Complete or incomplete
    '    'REVISION HISTORY 
    '    '                                   Created on 13 AUG 2004
    '    '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK


    '    ' if error then Log and go to next statement
    '    Dim objConn As New SQLConnection(CNS)
    '    Dim cmd As SQLCommand
    '    Dim hasError As Boolean = False
    '    Dim strErrMessage, strSQLError As String : Dim intErrorCounter As Integer
    '    objConn.Open()
    '    Dim i As Integer
    '    For i = 0 To aryLstSQL.Count - 1
    '        If Not Trim(aryLstSQL(i)) = "" Then
    '            cmd = New SQLCommand(aryLstSQL(i), objConn)
    '            Try
    '                cmd.ExecuteNonQuery()
    '                hasError = False
    '            Catch e As Exception
    '                hasError = True
    '                strSQLError += aryLstSQL(i) & vbCrLf
    '                strErrMessage += e.Message & vbCrLf
    '            End Try
    '        End If
    '        If hasError = True Then
    '            WriteLog"SQL = " & strSQLError, "Error = " & strErrMessage)
    '            intErrorCounter += 1
    '        End If
    '    Next
    '    If intErrorCounter > 0 Then
    '        Return False
    '    End If
    '    Return True
    'End Function





#Region "Write Log File"


    Friend Shared Sub WriteLog(ByVal strTopic As String, ByVal strDetail As String)
        Dim ColText As New Collection
        ColText.Add(strTopic)
        ColText.Add(strDetail)
        WriteErrorLog(ColText)
    End Sub

    Private Shared Sub WriteErrorLog(ByVal colLogLines As Collection)
        Dim w As StreamWriter = File.AppendText("Log.txt")
        Log(colLogLines, w)
        ' Close the writer and underlying file.
        w.Close()
        ' Open and read the file.
        Dim r As StreamReader = File.OpenText("Log.txt")
        DumpLog(r)



    End Sub

    Private Shared Sub Log(ByVal colText As Collection, ByVal w As TextWriter)
        w.Write(ControlChars.CrLf & "Log Entry : ")
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
        w.WriteLine("  :")
        '   w.WriteLine("  :{0}", logMessage)
        Dim i As Integer
        For i = 1 To colText.Count
            w.WriteLine("  :{0}", colText.Item(i))
        Next
        w.WriteLine("-------------------------------")
        ' Update the underlying file.
        w.Flush()
    End Sub
    Private Shared Sub DumpLog(ByVal r As StreamReader)
        ' While not at the end of the file, read and write lines.
        Dim line As String
        line = r.ReadLine()
        While Not line Is Nothing
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
        r.Close()
    End Sub
#End Region


    'Public Function UpdateMoveDone(ByVal strProject As String)
    '    Dim cmd As SQLCommand = New SQLCommand("Accountant_Update_MoveDone", objConn)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.Add("@ProjectID", strProject)
    '    objConn.Open()
    '    cmd.ExecuteNonQuery()
    '    objConn.Close()
    '    Return True
    'End Function

    'Public Function CtypeDateToEng2(ByVal dtDate As Date, ByVal intTimeMode As Integer) As String
    '    'intTimeMode
    '    '1 = add time 00:00:00
    '    '2 = add time 23:59:59
    '    '3 = now time
    '    '99 = no time

    '    Dim hh, mm, ss As Integer

    '    Dim strReturn As String
    '    Dim strTime As String = ""
    '    Select Case intTimeMode
    '        Case 1
    '            strTime = "00:00:00"
    '            hh = 0
    '            mm = 0
    '            ss = 0

    '        Case 2
    '            strTime = "23:59:59"
    '            hh = 23
    '            mm = 59
    '            ss = 59
    '        Case 3
    '            strTime = Now.Hour & ":" & Now.Minute & ":" & Now.Second
    '            hh = Now.Hour
    '            mm = Now.Minute
    '            ss = Now.Second
    '        Case 99
    '            strTime = ""
    '        Case Else
    '            strTime = ""
    '    End Select

    '    strReturn = dtDate.Day.ToString & "/" & MonthMMM(dtDate.Month) & "/" & dtDate.Year.ToString & " " & strTime

    '    'Dim dt As New Date(dtDate.Year, dtDate.Month, dtDate.Day, hh, mm, ss)

    '    'If intTimeMode = 99 Then
    '    '    Dim dt2 As New Date(dtDate.Year, dtDate.Month, dtDate.Day)
    '    '    Return dt2.ToString
    '    'End If

    '    'Return dt.ToString()

    '    'Return strReturn
    'End Function
    Public Function CtypeDateToEng(ByVal dtDate As Date, ByVal intTimeMode As Integer) As String
        'intTimeMode
        '1 = add time 00:00:00
        '2 = add time 23:59:59
        '3 = now time
        '99 = no time

        Dim hh, mm, ss As Integer

        Dim strReturn As String = ""
        Dim strTime As String = ""
        Select Case intTimeMode
            Case 1
                strTime = "00:00:00"
                hh = 0
                mm = 0
                ss = 0

            Case 2
                strTime = "23:59:59"
                hh = 23
                mm = 59
                ss = 59
            Case 3
                strTime = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                hh = Now.Hour
                mm = Now.Minute
                ss = Now.Second
            Case 99
                strTime = ""
            Case Else
                strTime = ""
        End Select

        ' strReturn = dtDate.Day.ToString & "/" & MonthMMM(dtDate.Month) & "/" & dtDate.Year.ToString & " " & strTime

        Dim dt As New Date(dtDate.Year, dtDate.Month, dtDate.Day, hh, mm, ss)

        If intTimeMode = 99 Then
            Dim dt2 As New Date(dtDate.Year, dtDate.Month, dtDate.Day)
            Return dt2.ToString("s")
        End If

        Return dt.ToString("s")

        'Return strReturn
    End Function
    Public Function MonthMMM(ByVal month As Int16) As String
        Select Case month
            Case 1
                Return "Jan"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Apr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Aug"
            Case 9
                Return "Sep"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dec"

        End Select
    End Function

    'Private Sub EmailAdmin(ByVal strSubject As String, ByVal strMsg As String)
    '    ' On Error Resume Next


    '    Dim msg As New System.Net.Mail.MailMessage

    '    msg.BodyFormat = MailFormat.Text

    '    msg.To = "menn3000@hotmail.com"

    '    msg.From = "IPN_Windows@IpnManagement.com"
    '    msg.Subject = strSubject

    '    msg.Body = "Computer name " & clsUtility.strComputerName & vbCrLf
    '    msg.Body += "User name " & clsUtility.UserName & " UserID " & clsUtility.UserID & vbCrLf
    '    msg.Body += "BusinessGroup: " & clsUtility.BusinessGroupID & " : " & clsUtility.BusinessGroupName & vbCrLf
    '    msg.Body += "Time:" & Now.ToString & vbCrLf
    '    msg.Body += "OS version " & Environment.OSVersion.ToString & vbCrLf
    '    msg.Body += "Stack Trace " & Environment.StackTrace.ToString & vbCrLf & vbCrLf

    '    msg.Body += "---------------------------------------------------------------------" & vbCrLf

    '    msg.Body += strMsg & vbCrLf



    '    SmtpMail.SmtpServer = "mail.IpnManagement.com"

    '    SmtpMail.Send(msg)

    'End Sub
#Region "Texting Amount of Money"


    Friend Function WriteMoneyInText(ByVal Amount As Double) As String
        Amount = Math.Round(Amount, 2)
        Dim strAmount As String = Amount.ToString
        Dim beforeDot, afterDot As String
        If (Amount Mod 1) = 0 Then
            beforeDot = strAmount
        Else
            beforeDot = strAmount.Substring(0, strAmount.Length - (strAmount.Length - strAmount.IndexOf(".")))
        End If


        Dim strReturn As String = ""

        ' do the number before " . " first 

        Dim LenghtBeforeDot As Integer = beforeDot.Length
        Dim nLocation As Integer
        Dim bPreviousNum As String = ""
        For nLocation = 1 To LenghtBeforeDot
            Dim num As Integer = beforeDot.Substring(nLocation - 1, 1)
            Dim intPositon As Integer = LenghtBeforeDot - (nLocation - 1)
            strReturn += TextNum(num, intPositon, LenghtBeforeDot, True, bPreviousNum)
            strReturn += UnitAmountByPosition(intPositon, True, num, LenghtBeforeDot)
            bPreviousNum = num.ToString
        Next

        ' then after " . "
        If (Amount Mod 1) > 0 Then
            afterDot = strAmount.Substring(strAmount.IndexOf(".") + 1)
            If afterDot.Length = 1 Then ' add 0 to string if it is only .# ie .1 must became .10
                'this will effect in TextNum case 0
                afterDot = afterDot + "0"
            End If

            Dim LenghtafterDot As Integer = afterDot.Length

            Dim dLocation As Integer
            Dim aPreviousNum As String = ""
            For dLocation = 1 To LenghtafterDot
                Dim num As Integer = afterDot.Substring(dLocation - 1, 1)
                Dim intPositon As Integer = LenghtafterDot - (dLocation - 1)

                strReturn += TextNum(num, intPositon, LenghtafterDot, False, aPreviousNum)

                strReturn += UnitAmountByPosition(intPositon, False, num, LenghtafterDot)

                aPreviousNum = num.ToString
            Next
        End If


        Return strReturn

    End Function
    Private Function UnitAmountByPosition(ByVal position As Integer, ByVal IsBeforeDot As Boolean, ByVal Num As String, ByVal ilenght As Integer) As String
        Select Case position
            Case 1 'หน่วย               
                If IsBeforeDot = True Then
                    Return "บาท"
                Else
                    Return "สตางค์"

                End If
            Case 2 'สิบ
                If Num = 0 Then
                    Return ""
                Else
                    Return "สิบ"
                End If

            Case 3 'ร้อย
                If Num = 0 Then
                    Return ""
                Else
                    Return "ร้อย"
                End If

            Case 4 'พัน
                If Num = 0 Then
                    Return ""
                Else
                    Return "พัน"
                End If

            Case 5 'หมื่น
                If Num = 0 Then
                    Return ""
                Else
                    Return "หมื่น"
                End If

            Case 6 'แสน
                If Num = 0 Then
                    Return ""
                Else
                    Return "แสน"
                End If

            Case 7 'ล้าน
                If Num = 0 Then
                    Return ""
                Else
                    Return "ล้าน"
                End If

        End Select
    End Function
    Private Function TextNum(ByVal n As String, ByVal position As Integer, ByVal iLenght As Integer, ByVal isBeforeDot As Boolean, ByVal previousNum As String) As String
        Select Case n
            Case 0
                If isBeforeDot = False Then
                    'If position = 1 Then
                    '    Return "สิบ"
                    'End If
                Else
                    Return ""
                End If

            Case 1
                If previousNum = "0" And position = 1 And iLenght > 1 Then ' incase of 101 ไม่ใช่ หนึ่งร้อยเอ็ด
                    Return "หนึ่ง"
                ElseIf position = 1 And iLenght > 1 Then
                    Return "เอ็ด"
                ElseIf position = 2 And iLenght > 1 Then ' สิบเอ็ด ไม้ต้องพิมพ์ หนึ่งก่อน
                    Return ""
                Else
                    Return "หนึ่ง"
                End If
            Case 2
                If position = 2 And iLenght > 1 Then
                    Return "ยี่"
                Else
                    Return "สอง"
                End If
            Case 3
                Return "สาม"
            Case 4
                Return "สี่"
            Case 5
                Return "ห้า"
            Case 6
                Return "หก"
            Case 7
                Return "เจ็ด"
            Case 8
                Return "แปด"
            Case 9
                Return "เก้า"
        End Select
    End Function
#End Region




    Private Sub btnTransactionRollback_Click()
        ' Make a transaction containing two actions and roll it
        ' back.

        objConn.Open()

        ' Make the transaction.
        Dim trans As SqlTransaction = _
            objConn.BeginTransaction(IsolationLevel.ReadCommitted)

        ' Make a Command for this connection
        ' and this transaction.
        Dim cmd As New SqlCommand( _
            "UPDATE People SET FirstName='?' WHERE " & _
                "LastName='?'", _
            objConn, _
            trans)

        ' Create parameters for the first command.
        cmd.Parameters.Add(New  _
            SqlParameter("FirstName", _
           "DataHere"))
        cmd.Parameters.Add(New SqlParameter("LastName", _
             "DataHere"))

        ' Execute the second command.
        cmd.ExecuteNonQuery()

        ' Create parameters for the second command.
        cmd.Parameters.Clear()
        cmd.Parameters.Add(New  _
            SqlParameter("FirstName", _
             "DataHere"))
        cmd.Parameters.Add(New SqlParameter("LastName", _
             "DataHere"))

        ' Execute the second command.
        cmd.ExecuteNonQuery()
        '---------------------------------------------

        ' Roll the transaction back.
        trans.Rollback()

        '''' or commit transaction
        '' trans.Commit()
        '---------------------------------------------

        ' Close the connection.
        objConn.Close()


    End Sub
    Public Function Update_DS_Changed(ByVal arrStmt() As String, ByVal arrTableName() As String, ByVal UpdatedDS As DataSet) As Integer
        '*****************
        'BEGIN SEND CHANGES TO SQL SERVER 
        Call DB_Connect()
        Dim i As Int16
        Dim objAdapter As New SqlDataAdapter
        Dim DS As New DataSet
        Dim intRowsUpdated As Integer = 0

        For i = 0 To UBound(arrStmt)
            If Not arrStmt(i) = "" And Not arrTableName(i) = "" Then
                If Not UpdatedDS.Tables("arrTableName(i)") Is Nothing Then
                    Dim da As New SqlDataAdapter(arrStmt(i), objConn)
                    Dim objCommandBuilder As New SqlCommandBuilder(da)
                    intRowsUpdated += da.Update(UpdatedDS, arrTableName(i))
                End If
            End If
        Next

        Call DB_Disconnect()

        Return intRowsUpdated

        ' END SEND CHANGES TO SQL SERVER
    End Function
    ' ''Public Function Update_DS_Changed_localDB(ByVal arrStmt() As String, ByVal arrTableName() As String, ByVal UpdatedDS As DataSet) As Boolean
    ' ''    '*****************
    ' ''    'BEGIN SEND CHANGES TO SQL SERVER 
    ' ''    Dim objLocalConn As New SQLConnection(clsUtility.TempLocalCNS)

    ' ''    If Not objLocalConn.State = ConnectionState.Open Then objLocalConn.Open()
    ' ''    Dim i As Int16
    ' ''    Dim objAdapter As New SQLDataAdapter
    ' ''    Dim DS As New DataSet

    ' ''    For i = 0 To UBound(arrStmt)
    ' ''        If Not arrStmt(i) = "" And Not arrTableName(i) = "" Then
    ' ''            Dim da As New SQLDataAdapter(arrStmt(i), objLocalConn)
    ' ''            Dim objCommandBuilder As New SQLCommandBuilder(da)
    ' ''            da.Update(UpdatedDS, arrTableName(i))
    ' ''        End If
    ' ''    Next
    ' ''    If Not objLocalConn.State = ConnectionState.Closed Then objLocalConn.Close()
    ' ''    ' END SEND CHANGES TO SQL SERVER
    ' ''End Function
    ' ''Public Function DB_GetDataSet_MultiTable_FromLocalDB(ByVal arrStmt() As String, ByVal arrTableName() As String) As DataSet
    ' ''    Dim objLocalConn As New SQLConnection(clsUtility.TempLocalCNS)
    ' ''    If Not objLocalConn.State = ConnectionState.Open Then objLocalConn.Open()
    ' ''    Dim i As Int16
    ' ''    Dim objAdapter As New SQLDataAdapter
    ' ''    Dim DS As New DataSet

    ' ''    For i = 0 To UBound(arrStmt)
    ' ''        If Not arrStmt(i) = "" And Not arrTableName(i) = "" Then

    ' ''            objAdapter.SelectCommand = New SQLCommand(arrStmt(i), objLocalConn)
    ' ''            objAdapter.FillSchema(DS, SchemaType.Source, arrTableName(i))
    ' ''            objAdapter.Fill(DS, arrTableName(i))
    ' ''        End If

    ' ''    Next
    ' ''    If Not objLocalConn.State = ConnectionState.Closed Then objLocalConn.Close()

    ' ''    Return DS
    ' ''End Function
    ' ''Public Function ExcuteDataWithRollBack_FromLocalDB(ByVal aryLstSQL As ArrayList) As Boolean


    ' ''    Dim objLocalConn As New SQLConnection(clsUtility.TempLocalCNS)


    ' ''    If Not objLocalConn.State = ConnectionState.Open Then objLocalConn.Open()

    ' ''    Dim objAdapter As New SQLDataAdapter
    ' ''    Dim DS As New DataSet

    ' ''    Dim bolReturn As Boolean = False
    ' ''    Dim strErrMessage As String

    ' ''    Dim trans As SqlTransaction = _
    ' ''      objLocalConn.BeginTransaction(IsolationLevel.ReadCommitted)


    ' ''    Dim cmd As New SqlCommand
    ' ''    cmd.Connection = objLocalConn
    ' ''    cmd.Transaction = trans
    '''   cmd.CommandTimeout = 0

    ' ''    Dim i As Integer
    ' ''    Try
    ' ''        For i = 0 To aryLstSQL.Count - 1
    ' ''            If Not Trim(aryLstSQL(i)) = "" Then
    ' ''                cmd.CommandText = aryLstSQL(i)
    ' ''                cmd.ExecuteNonQuery()
    ' ''            End If
    ' ''        Next

    ' ''        'Commit 
    ' ''        trans.Commit()
    ' ''        bolReturn = True
    ' ''    Catch ex As Exception
    ' ''        trans.Rollback()
    ' ''        strErrMessage = ex.Message
    ' ''        WriteLog("Temp SQL = " & aryLstSQL(i), "Error (rollBacked) = " & strErrMessage)
    ' ''        MsgBox("มีความผิดพลาดเกิดขึ้น การลบข้อมูลที่ตรวจแล้วไม่สำเร็จ แจ้งพี่เม่นด้วย" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
    ' ''        bolReturn = False
    ' ''    Finally
    ' ''        If Not objLocalConn.State = ConnectionState.Closed Then objLocalConn.Close()
    ' ''    End Try

    ' ''    Return bolReturn
    ' ''End Function

    'Public Function RetriveData(ByVal cmd As SQLCommand) As SQLDataReader
    '    ' DESCRIPTION: 
    '    '                                Data accessing function
    '    ' INPUT: 
    '    '                                 SQL Statement
    '    ' OUTPUT:
    '    '                                   Data Reader 
    '    'REVISION HISTORY 
    '    '                                   Created on 13 AUG 2004
    '    '                                   REV	Date	REV BY Surakit H.	REASON	CHECK BY 	CHECK DATE	REMARK
    '    Dim objConn As New SQLConnection(CNS)
    '    Dim dr As SQLDataReader

    '    cmd.Connection = objConn
    '    objConn.Open()
    '    dr = cmd.ExecuteReader
    '    RetriveData = dr
    'End Function

End Class