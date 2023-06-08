Imports System.Console
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()

        Dim Uwagaki, Kadai, Path, Desktop, JsonString As String

        Dim jObject As JObject

        Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        JsonString = IO.File.ReadAllText("Config.json")
        jObject = JObject.Parse(JsonString)

        Dim Overwrite As Boolean = jObject("Overwrite_Warning").ToString()

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

        If Kadai.Contains("s") Then
            Kadai = Kadai.Remove(0, 1)
            Kadai = "宿題課題 " & Kadai
        Else
            Kadai = "課題 " & Kadai
        End If

        Path = Desktop & "\" & jObject("ID").ToString() & " " & jObject("Name").ToString() & " " & Kadai

        Select Case Overwrite

            Case True

                If IO.Directory.Exists(Path) Then
                    WriteLine(vbCrLf & "既にフォルダが存在しているためキャンセルされました。" & vbCrLf)
                    Read()
                Else
                    IO.Directory.CreateDirectory(Path)
                    IO.File.Create(Path & "\取り組んで感じたこと.txt")

                    Diagnostics.Process.Start(Path)
                    Diagnostics.Process.Start("notepad.exe", Path & "\取り組んで感じたこと.txt")
                End If

            Case False

                IO.Directory.CreateDirectory(Path)
                IO.File.Create(Path & "\取り組んで感じたこと.txt")

                Diagnostics.Process.Start(Path)
                Diagnostics.Process.Start("notepad.exe", Path & "\取り組んで感じたこと.txt")

        End Select

        End

    End Sub

End Module
