Imports System.Console
Imports System.IO
Imports Newtonsoft.Json.Linq

Module Module1
    Dim Path As String
    Sub CreDir()
        Directory.CreateDirectory(Path)
        File.Create(Path & "\取り組んで感じたこと.txt")
        Diagnostics.Process.Start(Path)
        Diagnostics.Process.Start("notepad.exe", Path & "\取り組んで感じたこと.txt")
    End Sub

    Sub Main()

        Dim Uwagaki, Kadai, Desktop, JsonString, ID, Name As String
        Dim jObject As JObject
        Dim Overwrite As Boolean

        Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Try
            If File.Exists("Config.json") Then
                JsonString = File.ReadAllText("Config.json")
            Else
                MsgBox("Config.jsonが存在しません")
            End If
        Catch ex As FileNotFoundException
            WriteLine(ex.Message)
            Read()
            Environment.Exit(1)
        Catch ex As Exception
            WriteLine(ex.Message)
            Read()
            Environment.Exit(1)
        End Try

        jObject = JObject.Parse(JsonString)

        Try
            Overwrite = jObject("Overwrite_Warning").ToString()
            ID = jObject("ID").ToString()
            Name = jObject("Name").ToString()
        Catch ex As NullReferenceException
            MsgBox("json構文エラー")
            WriteLine(ex.Message)
            Read()
            Environment.Exit(1)
        Catch ex As Exception
            MsgBox("予期しないエラー")
            WriteLine(ex.Message)
            Read()
            Environment.Exit(1)
        End Try

        If Overwrite = True Then
            Uwagaki = "有効"
        ElseIf Overwrite = False Then
            Uwagaki = "無効"
        Else
            Uwagaki = "不明"
        End If

        WriteLine("宿題課題の時は先頭に「s」を入力してください。")
        WriteLine(vbCrLf & "上書き警告：" & Uwagaki)
        WriteLine()

        Write("課題番号：") : Kadai = ReadLine()

        If String.IsNullOrWhiteSpace(Kadai) Then
            MsgBox("入力された文字列が不正です")
            Read()
            Environment.Exit(1)
        Else

        End If

        If Kadai.Contains("s") Then
            Kadai = Kadai.Remove(0, 1)
            Kadai = "宿題課題 " & Kadai
        Else
            Kadai = "課題 " & Kadai
        End If

        Path = Desktop & "\" & ID & " " & Name & " " & Kadai

        Select Case Overwrite
            Case True
                If Directory.Exists(Path) Then
                    WriteLine(vbCrLf & "既にフォルダが存在しているためキャンセルされました。" & vbCrLf)
                    Read()
                Else
                    CreDir()
                End If
            Case False
                CreDir()
        End Select
        End
    End Sub
End Module
