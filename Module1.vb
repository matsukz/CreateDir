Imports System.Console
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()

        Dim Kadai, Path, Desktop, JsonString As String
        Dim jObject As JObject

        Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        JsonString = IO.File.ReadAllText("Config.json")
        jObject = JObject.Parse(JsonString)

        WriteLine("警告：同じフォルダ名が存在するときは上書きされます。")
        Write("課題番号：") : Kadai = "課題" & ReadLine()

        Path = Desktop & "\" & jObject("ID").ToString() & " " & jObject("Name").ToString() & " " & Kadai
        IO.Directory.CreateDirectory(Path)

        IO.File.Create(Path & "\取り組んで感じたこと.txt")

        Diagnostics.Process.Start(Path)
        Diagnostics.Process.Start(Path & "\取り組んで感じたこと.txt")

    End Sub

End Module
