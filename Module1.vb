Imports System.Console
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()

        Dim Kadai, Path, Desktop, JsonString As String
        Dim jObject As JObject
        Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        JsonString = System.IO.File.ReadAllText("Config.json")
        jObject = JObject.Parse(JsonString)

        Write("課題番号：") : Kadai = "課題" & ReadLine()

        Path = Desktop & "\" & jObject("ID").ToString() & jObject("Name").ToString() & " " & Kadai
        System.IO.Directory.CreateDirectory(Path)

        System.IO.File.Create(Path & "\取り組んで感じたこと.txt")

        System.Diagnostics.Process.Start(Path)
        System.Diagnostics.Process.Start(Path & "\取り組んで感じたこと.txt")

    End Sub

End Module
