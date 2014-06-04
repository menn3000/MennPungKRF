Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography


Public Class clsUtility

    'Friend Shared TempLocalCNS As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Workaround7StartUpPathProblem() & "\TempDB.mdb"

    Friend Shared LiveCNS As String ' set at runtime


    Friend Shared PositionRecordsLatestTime As DateTime = Now

    Private Shared bolInitiated As Boolean = False

    Public Const MainCategoryMaxLevel As Int16 = 6

    'Public Enum InvoiceStatus
    '    unSentToCustomer = 0
    '    Unpaid = 1
    '    PartialPayment = 2
    '    UnPaidReceiptPrinted = 4
    '    Paid = 3
    '    BankDeposited = 5
    'End Enum
    'Public Const strUnsentToCustomerInvoice = "UnSent"
    'Public Const strUnpaidInvoice = "Unpaid"
    'Public Const strPartialPaymentInvoice = "PartialPayment"
    'Public Const strPaidInvoice = "Paid"
    'Public Const strUnPaidReceiptPrinted = "UnPaidReceiptPrinted"
    'Public Const strBankDeposited = "BankDeposited"

    Public Const BOSStatus_Open As String = "Open"
    Public Const BOSStatus_Approved As String = "Approved"
    Public Const BOSStatus_Void As String = "Void"
   

    Public Const BOPStatus_Open As String = "Open"
    Public Const BOPStatus_Void As String = "Void"
    Public Const BOPStatus_Approved As String = "Approved"


    Friend Const EncrptyFileExtention As String = ".rtk"
    Protected Friend Const carType As String = "ddgr4WFbj8-61da-0000-87e6-hjdivgkdm"



    'Public Const TransStatus_Normal As String = "Normal"
    'Public Const TransStatus_Void As String = "Void"

    Public Const strDBProfileDeveloping As String = "Developing"
    Public Const strDBProfileProduction As String = "Production"
    Public Const strDBProfileTesting As String = "Testing"
    Public Const strDBProfileTraining As String = "Training"



    Friend Shared strComputerName As String = Environment.MachineName.ToString

    'Private Shared Function Workaround7StartUpPathProblem() As String
    '    'get connection string from .config file
    '    Dim strDBProfile As String
    '    Dim bolDeveloping As Boolean = True
    '    Try
    '        strDBProfile = System.Configuration.ConfigurationManager.AppSettings("NetDBFilePathProfile")

    '    Catch
    '        strDBProfile = ""
    '    End Try


    '    Select Case strDBProfile
    '        Case clsUtility.strDBProfileDeveloping
    '            bolDeveloping = True
    '        Case Else
    '            bolDeveloping = False
    '    End Select

    '    If bolDeveloping = False Then
    '        If System.Environment.OSVersion.Version.Build >= 7600 _
    '              And System.Environment.OSVersion.Version.Major >= 6 _
    '              And System.Environment.OSVersion.Version.Minor >= 1 Then
    '            'Windows 7 specific code here
    '            Return "C:\Program Files\Iberla\RTK2012"
    '        Else
    '            Return Application.StartupPath
    '        End If
    '    End If


    '    Return Application.StartupPath



    'End Function
    'Public Shared Function GetInvoiceStatusCode(ByVal Status As InvoiceStatus) As String
    '    Select Case Status
    '        Case InvoiceStatus.unSentToCustomer
    '            Return strUnsentToCustomerInvoice
    '        Case InvoiceStatus.Unpaid
    '            Return strUnpaidInvoice
    '        Case InvoiceStatus.PartialPayment
    '            Return strPartialPaymentInvoice
    '        Case InvoiceStatus.Paid
    '            Return strPaidInvoice
    '        Case InvoiceStatus.UnPaidReceiptPrinted
    '            Return strUnPaidReceiptPrinted
    '        Case InvoiceStatus.BankDeposited
    '            Return strBankDeposited
    '    End Select
    'End Function

    Public Sub New(ByVal IsinitialPreference As Boolean)
        If IsinitialPreference = True Then
            'getPreference()
        End If

    End Sub
    Public Sub New()
        If bolInitiated = False Then
            'getPreference()
        End If

    End Sub

    Public Shared Function MsgComfirm(Optional ByVal strMessage As String = "ต้องการทำรายการหรือไม่ ?") As Boolean
        If MessageBox.Show(strMessage, "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            MsgComfirm = True
        Else
            MsgComfirm = False
        End If
    End Function


#Region " shared Property"

    Private Shared intUserID, intPositionID, intUserMainCategory, intUserLevel2Category As Integer

    Private Shared intDefaultAirModuleLevel, intDefaultAdminModuleLevel As Integer
    Private Shared intDefaultInvModuleLevel, intDefaultFieldWorkModuleLevel As Integer

    Private Shared strEmployeeID, strUserFName, strUserLName, strEmail, strPositionName, strUserLevel2CategoryName As String

    Private Shared strPositionAbv As String

    'Public Enum enuModulePermission
    '    Director = 999
    '    Programmer = 10
    '    ExcecutiveViewer = 6
    '    Approval = 5
    '    Officer = 1
    '    Deny = 0

    'End Enum
   
    Public Shared Property UserMainCategory() As Integer
        Get
            UserMainCategory = intUserMainCategory
        End Get
        Set(ByVal Value As Integer)
            intUserMainCategory = Value

        End Set
    End Property
    Public Shared Property UserLevel2Category() As Integer
        Get
            UserLevel2Category = intUserLevel2Category
        End Get
        Set(ByVal Value As Integer)
            intUserLevel2Category = Value

        End Set
    End Property
    Public Shared Property UserLevel2CategoryName() As String
        Get
            UserLevel2CategoryName = strUserLevel2CategoryName
        End Get
        Set(ByVal Value As String)
            strUserLevel2CategoryName = Value

        End Set
    End Property


    Public Shared Property UserID() As Integer
        Get
            UserID = intUserID
        End Get
        Set(ByVal Value As Integer)
            intUserID = Value

        End Set
    End Property
    Public Shared Property EmployeeID() As String
        Get
            EmployeeID = strEmployeeID
        End Get
        Set(ByVal Value As String)
            strEmployeeID = Value
            UpdateAppConfig("UserName", EmployeeID)
        End Set
    End Property

    Public Shared Property UserFName() As String
        Get
            UserFName = strUserFName
        End Get
        Set(ByVal Value As String)
            strUserFName = Value

        End Set
    End Property
    Public Shared Property UserLName() As String
        Get
            UserLName = strUserLName
        End Get
        Set(ByVal Value As String)
            strUserLName = Value

        End Set
    End Property
    Public Shared Property Email() As String
        Get
            Email = strEmail
        End Get
        Set(ByVal Value As String)
            strEmail = Value

        End Set
    End Property


    Public Shared Property PositionName() As String
        Get
            PositionName = strPositionName
        End Get
        Set(ByVal Value As String)
            strPositionName = Value

        End Set
    End Property
    Public Shared Property PositionAbv() As String
        Get
            PositionAbv = strPositionAbv
        End Get
        Set(ByVal Value As String)
            strPositionAbv = Value

        End Set
    End Property

    Public Shared Function GetUserFullName() As String
        Return String.Format("{0} {1} {2}", PositionAbv, UserFName, UserLName)
    End Function
    


    Public Shared Property PositionID() As Integer
        Get
            PositionID = intPositionID
        End Get
        Set(ByVal Value As Integer)
            intPositionID = Value
        End Set
    End Property

    Public Shared Property DefaultAirModuleLevel() As Integer
        Get
            DefaultAirModuleLevel = intDefaultAirModuleLevel
        End Get
        Set(ByVal Value As Integer)
            intDefaultAirModuleLevel = Value
        End Set
    End Property


    Public Shared Property DefaultInvModuleLevel() As Integer
        Get
            DefaultInvModuleLevel = intDefaultInvModuleLevel
        End Get
        Set(ByVal Value As Integer)
            intDefaultInvModuleLevel = Value
        End Set
    End Property

    Public Shared Property DefaultFieldWorkModuleLevel() As Integer
        Get
            DefaultFieldWorkModuleLevel = intDefaultFieldWorkModuleLevel
        End Get
        Set(ByVal Value As Integer)
            intDefaultFieldWorkModuleLevel = Value
        End Set
    End Property

    Public Shared Property DefaultAdminModuleLevel() As Integer
        Get
            DefaultAdminModuleLevel = intDefaultAdminModuleLevel
        End Get
        Set(ByVal Value As Integer)
            intDefaultAdminModuleLevel = Value
        End Set
    End Property


#End Region
    
    Friend Shared Function GenUniqueString() As String
        Dim maxSize As Integer = 8
        Dim minSize As Integer = 5

        Dim chars As Char() = New Char(61) {}
        Dim a As String
        a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        chars = a.ToCharArray()
        Dim size As Integer = maxSize
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        size = maxSize
        data = New Byte(size - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(size)
        Dim b As Byte
        For Each b In data
            result.Append(chars(b Mod (chars.Length - 1)))
        Next

        Return result.ToString

    End Function

    Friend Shared Sub UpdateAppConfig(ByVal strKey As String, ByVal objValue As Object)

        '''' Use reflection to find the location of the config file. 
        '''Dim Asm As System.Reflection.Assembly = _
        '''   System.Reflection.Assembly.GetExecutingAssembly
        '''Dim strConfigLoc As String
        '''strConfigLoc = Asm.Location

        '''' The config file is located in the application's bin directory, so
        '''' you need to remove the file name.
        Dim strTemp As String
        '''strTemp = strConfigLoc
        '''strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)

        strTemp = Directory.GetParent(Application.ExecutablePath).ToString



        ' Declare a FileInfo object for the config file.
        Dim FileInfo As System.IO.FileInfo = New  _
     System.IO.FileInfo(strTemp & "\STAir.exe.config")

        ' Load the config file into the XML DOM.
        Dim XmlDocument As New System.Xml.XmlDocument
        XmlDocument.Load(FileInfo.FullName)

        ' Find the right node and change it to the new value.
        Dim Node As System.Xml.XmlNode
        For Each Node In XmlDocument.Item("configuration").Item("appSettings")
            ' Skip any comments.
            If Node.Name = "add" Then
                If Node.Attributes.GetNamedItem("key").Value = _
                   strKey Then
                    Node.Attributes.GetNamedItem("value").Value _
                       = CType(objValue, String)
                End If
            End If
        Next Node

        ' Save the modified config file.
        XmlDocument.Save(FileInfo.FullName)
    End Sub
    Friend Function SQLDate(ByVal dtDate As Date) As String
        ' to convert month to MMM format, so access won't get confuse (thai date and eng date)
        ' if you just use dtDate.tostring("dd/MMM/yyyy") in will return month in Thai 
        ' because of the region setting that must be Thai

        ' but access will not recoqnize that month in thai ie (ก.ค.)
        Dim strReturn, strMonth As String

        Select Case dtDate.Month
            Case 1
                strMonth = "JAN"
            Case 2
                strMonth = "FEB"
            Case 3
                strMonth = "MAR"
            Case 4
                strMonth = "APR"
            Case 5
                strMonth = "MAY"
            Case 6
                strMonth = "JUN"
            Case 7
                strMonth = "JUL"
            Case 8
                strMonth = "AUG"
            Case 9
                strMonth = "SEP"
            Case 10
                strMonth = "OCT"
            Case 11
                strMonth = "NOV"
            Case 12
                strMonth = "DEC"
        End Select

        strReturn = dtDate.Day.ToString & "/" & strMonth & "/" & dtDate.Year.ToString
        Return strReturn

    End Function
    Friend Shared Function GetPeakDayFromXMLFile(ByVal DayNo As Integer, ByVal MonthNo As Integer, ByVal yearNo As Integer) As String
        Dim strDayNo As String = DayNo.ToString
        Dim strMonthNo As String = MonthNo.ToString

        Dim strTemp As String

        strTemp = Directory.GetParent(Application.ExecutablePath).ToString
        Dim strXmlFileName As String = ""
        Select Case yearNo
            Case 2008, 2551
                strXmlFileName = "Holiday2008.xml"
            Case 2009, 2552
                strXmlFileName = "Holiday2009.xml"
            Case 2010, 2553
                strXmlFileName = "Holiday2010.xml"

        End Select

        ' Declare a FileInfo object for the  file.
        Dim FileInfo As System.IO.FileInfo = New  _
     System.IO.FileInfo(strTemp & "\" & strXmlFileName)

        ' Load the config file into the XML DOM.
        Dim XmlDocument As New System.Xml.XmlDocument
        XmlDocument.Load(FileInfo.FullName)

        ' Find the right node and change it to the new value.
        Dim Node As System.Xml.XmlNode
        For Each Node In XmlDocument.Item("PeakDays").Item("PeakDetail")

            If Node.Name = "PeakDay" Then
                If Node.Attributes.GetNamedItem("day").Value = strDayNo And Node.Attributes.GetNamedItem("month").Value = strMonthNo Then
                    Return Node.Attributes.GetNamedItem("Name").Value
                End If
            End If
        Next Node


        XmlDocument = Nothing
        ' if notthing found matched then return ""
        Return ""

    End Function
    Public Function GetHolidDayName(ByVal dtDate As Date) As String
        Select Case dtDate
            Case "##"

        End Select
    End Function

    'Public Shared Function WhatCanCurrentUserDo(ByVal ForModule As ProgramModule)

    '    Select Case ForModule
    '        Case ProgramModule.Admin

    '        Case ProgramModule.Inventory
    '        Case ProgramModule.AirCon
    '        Case ProgramModule.FieldWork
    '    End Select

    'End Function
    'Public Enum UserFunctionList
    '    viewOnlyOfficeAdmin = 0
    '    editOfficeAdmin = 1
    'End Enum

    'Public Enum ProgramModule
    '    Admin ' สารบรรณ
    '    Inventory
    '    AirCon
    '    FieldWork 'งาน สารวัตร นตส ช่าง workflow 
    'End Enum

#Region "Encryption"
    ' Encrypt the text
    Public Shared Function EncryptText(ByVal strText As String) As String
        Return Encrypt(strText, "%*N#60*!")

    End Function

    'Decrypt the text 
    Public Shared Function DecryptText(ByVal strText As String) As String
        Return Decrypt(strText, "%*N#60*!")
    End Function

    'The function used to encrypt the text
    Private Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey _
             As String) As String ' strEncrKey Must be 8 digit code
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))

            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    'The function used to decrypt the text
    Private Shared Function Decrypt(ByVal strText As String, ByVal sDecrKey _
               As String) As String
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(strText.Length) As Byte

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

            Return encoding.GetString(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
#End Region
    

End Class
