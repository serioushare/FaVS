Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection

Public Module FaInstaller

    Public Const HWND_BROADCAST As Integer = &HFFFF
    Public Const WM_FONTCHANGE As Integer = &H1D

    <DllImport("gdi32.dll")> _
    Public Function AddFontResource(ByVal lpszFilename As String) As Integer
    End Function

    <DllImport("gdi32.dll")> _
    Public Function RemoveFontResource(ByVal lpszFilename As String) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function

    Public Sub Install(Optional ByVal InstallPermanent As Boolean = True)
        Dim fontpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) & "\fontawesome_webfont.ttf"
        Dim regpath As String = Assembly.GetExecutingAssembly().Location.Replace("FontAwesomeVS.dll", "") & "fa.reg"

        File.Create(fontpath).Dispose()
        File.WriteAllBytes(fontpath, My.Resources.fa_wf)
        AddFontResource(fontpath)

        File.Create(regpath).Dispose()
        Using outfile As New StreamWriter(regpath)
            outfile.Write(My.Resources.fa.ToString())
        End Using
        Shell("regedit.exe /s """ & regpath & "")
        My.Settings.InstalledPermanent = True
        File.Delete(regpath)

        SendMessage(New IntPtr(HWND_BROADCAST), WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)
    End Sub

    Public Sub UnInstall()
        Dim fontpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) & "\fontawesome_webfont.ttf"
        Dim regpath As String = Assembly.GetExecutingAssembly().Location.Replace("FontAwesomeVS.dll", "") & "fa_u.reg"

        File.Create(regpath).Dispose()
        Using outfile As New StreamWriter(regpath)
            outfile.Write(My.Resources.fa_u.ToString())
        End Using
        Shell("regedit.exe /s """ & regpath & "")
        File.Delete(regpath)

        RemoveFontResource(fontpath)
        File.Delete(fontpath)

        SendMessage(New IntPtr(HWND_BROADCAST), WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)

        My.Settings.InstalledPermanent = False
    End Sub

End Module
