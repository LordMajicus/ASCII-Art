

Public Class Form1

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" _
            (ByVal SectionName As String, ByVal KeyName As String, ByVal DefaultVal As String, ByVal ReturnedString As String, _
            ByVal StringSize As Integer, ByVal FileName As String) As Integer

    'Note - This value is now set from the config.ini file!
    'Set CHARSCALE equal to the darkest character used to the lightest character used
    'Const CHARSCALE As String = "@%#*+=-:."
    'Const CHARSCALE As String = "MNFV$I*:."
    'Const CHARSCALE As String = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\|()1{}[]?-_+~<>i!lI;:,^`'. "

    Dim CHARSCALE As String = ""

    Private Sub Btn_Gray_Click(sender As Object, e As EventArgs) Handles Btn_Gray.Click

        Dim lpAppName, lpKeyName, lpDefault, lpReturnString, lpFileName As String
        Dim Size, Valid As Integer

        Dim FILE_PATH As String = AppDomain.CurrentDomain.BaseDirectory & "ASCII_Image.txt"
        Dim file As System.IO.StreamWriter
        Dim strTemp As String
        Dim hblocks As Double
        Dim vblocks As Double
        Dim numBlocks As Integer
        Dim bm As Bitmap
        Dim pixelColor As Color
        Dim gray As Integer
        Dim totGray As Double
        Dim cntGray As Double
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer
        Dim j As Integer


        'Load config.ini values
        'lpReturnString = value returned from ini
        'Valid = # of characters red into lpReturnString
        lpAppName = "ProgramData"
        lpDefault = ""
        lpReturnString = Space$(128)
        Size = Len(lpReturnString)
        lpFileName = Application.StartupPath & "\config.ini"

        lpKeyName = "CharsWide"
        Valid = GetPrivateProfileString(lpAppName, lpKeyName, lpDefault, lpReturnString, Size, lpFileName)
        numBlocks = Microsoft.VisualBasic.Left(lpReturnString, Valid)

        lpKeyName = "CharScale"
        Valid = GetPrivateProfileString(lpAppName, lpKeyName, lpDefault, lpReturnString, Size, lpFileName)
        CHARSCALE = Microsoft.VisualBasic.Left(lpReturnString, Valid)


        file = My.Computer.FileSystem.OpenTextFileWriter(FILE_PATH, False)
        bm = Me.Pbx_Image.Image

        'Set block size to always be [numBlocks] wide; height is dependent on how big block width is (blocks are X by 0.5 X)
        'Because the fonts are rectangular in nature, the block height needs to be halved to preserve aspect ratio.
        hblocks = numBlocks
        vblocks = 0.5 * bm.Height * numBlocks / bm.Width


        For j = 0 To vblocks

            strTemp = ""

            For i = 0 To hblocks

                totGray = 0
                cntGray = 0.0001

                'Get the pixel color
                x = (bm.Width / hblocks) * i
                Do While x < ((bm.Width / hblocks) * (i + 1)) And x < bm.Width

                    y = (bm.Height / vblocks) * j
                    Do While y < ((bm.Height / vblocks) * (j + 1)) And y < bm.Height

                        pixelColor = bm.GetPixel(x, y)
                        totGray = totGray + CalcGrayscale(pixelColor.R, pixelColor.G, pixelColor.B)
                        cntGray = cntGray + 1

                        y = y + 1

                    Loop

                    x = x + 1

                Loop

                gray = totGray / cntGray

                'Set all pixels in block equal to average gray color
                If True Then

                    x = (bm.Width / hblocks) * i
                    Do While x < ((bm.Width / hblocks) * (i + 1)) And x < bm.Width

                        y = (bm.Height / vblocks) * j
                        Do While y < ((bm.Height / vblocks) * (j + 1)) And y < bm.Height

                            bm.SetPixel(x, y, Color.FromArgb(gray, gray, gray))
                            y = y + 1

                        Loop

                        x = x + 1

                    Loop

                End If

                strTemp = strTemp & CalcGrayscaleChar(gray / 255)

            Next

            file.WriteLine(strTemp)

        Next

        file.Close()
        Me.Pbx_Image.Image = bm

    End Sub


    Private Sub Btn_Load_Click(sender As Object, e As EventArgs) Handles Btn_Load.Click

        Dim ofd As New OpenFileDialog

        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                Me.Pbx_Image.Image = Bitmap.FromFile(ofd.FileName)
            End If
        End If

    End Sub


    Function CalcGrayscaleChar(argGray As Double) As String

        Dim i As Integer
        Dim strChar As String

        strChar = " "

        For i = 0 To Len(CHARSCALE) - 1
            If argGray >= (i / Len(CHARSCALE)) And argGray < ((i + 1) / Len(CHARSCALE)) Then
                strChar = Mid(CHARSCALE, i + 1, 1)
                i = Len(CHARSCALE)
            End If
        Next i

        CalcGrayscaleChar = strChar

    End Function


    Function CalcGrayscaleRGBChar(argRed As Double, argGreen As Double, argBlue As Double) As String

        Dim grayAmt As Double
        Dim i As Integer
        Dim strChar As String

        strChar = " "
        grayAmt = CalcGrayscale(argRed, argGreen, argBlue)

        For i = 0 To Len(CHARSCALE) - 1
            If grayAmt >= (i / Len(CHARSCALE)) And grayAmt < (i + 1 / Len(CHARSCALE)) Then
                strChar = Mid(CHARSCALE, i)
                i = Len(CHARSCALE)
            End If
        Next i

        CalcGrayscaleRGBChar = strChar

    End Function


    Function CalcGrayscale(argRed As Double, argGreen As Double, argBlue As Double) As Integer
        'Feel free to adjust values to get better looking images

        Const R As Double = 0.2989
        Const G As Double = 0.587
        Const B As Double = 0.114

        CalcGrayscale = ((argRed * R) + (argGreen * G) + (argBlue * B))

    End Function


End Class
