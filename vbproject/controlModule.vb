Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.IO
Module controlModule
    'for watermark text
    Private Declare Function getwindow Lib "user32.dll" (ByVal hwnd As Integer, ByVal wcmd As Integer) As Integer
    Private Declare Auto Function SendMessageString Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByValwParam As Integer, ByVal lparam As String) As Integer

    Const GW_CHILD = 5
    Const EM_SETUEBANNER = &H1501

    Sub SetWatermark(ByVal Ctl As TextBox, ByVal Txt As String)
        SendMessageString(Ctl.Handle, EM_SETUEBANNER, 1, Txt)
    End Sub

    Sub SetWatermark(ByVal Ctl As ComboBox, ByVal Txt As String)
        Dim i As Integer
        i = getwindow(Ctl.Handle, GW_CHILD)
        SendMessageString(i, EM_SETUEBANNER, 1, Txt)
    End Sub
    'end of watermark text

    'connect to database files
    Public strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\mydatabase.mdb;Jet OLEDB:Database Password=login1234"
    Public connection As OleDb.OleDbConnection
    Public cmd As OleDb.OleDbCommand
    Public datast As DataSet
    Public adapter As OleDbDataAdapter
    Public bindingsrc As BindingSource
    Public reader As OleDbDataReader
    Public sql As String

    'Public dt As DateTime = DateTime.Now
    'Public dtfInfo As DateTimeFormatInfo = DateTimeFormatInfo.InvariantInfo
    'Public myDay As String = "dd"
    'Public myMonth As String = "MMM"
    'Public myYear As String = "yyyy"

    'Public dtID As String
    'Public accType As Integer
    'Public IsFind As Boolean = False
    

    Public Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

End Module
