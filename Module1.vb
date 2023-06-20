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

    Sub EnterError()
        MsgBox("入力された文字列が不正です")
        Environment.Exit(1)
    End Sub

    Sub Main()

        Dim ConfigFile, Uwagaki, Kadai, Desktop, JsonString, ID, Name As String
        Dim jObject As JObject
        Dim Overwrite As Boolean

        Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Try
            ConfigFile = My.Application.Info.DirectoryPath & "\Config.json"
            If File.Exists(ConfigFile) Then
                JsonString = File.ReadAllText(ConfigFile)
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
        Else
            Uwagaki = "無効"
        End If

        WriteLine("宿題課題の時は先頭に「s」を入力してください。")
        WriteLine(vbCrLf & "上書き警告：" & Uwagaki)
        WriteLine()

        Write("課題番号 >> ") : Kadai = ReadLine()

        If String.IsNullOrWhiteSpace(Kadai) Then
            EnterError()
        Else
        End If

        If Kadai.Contains("s") Then
            Kadai = Kadai.Remove(0, 1)

            If String.IsNullOrWhiteSpace(Kadai) Then
                EnterError()
            End If

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
