# 提出用フォルダテンプレート
提出時に作成するフォルダと感想テキストをデスクトップに自動で作るやつです。<br>
[Json.NET - Newtonsonft](https://www.newtonsoft.com/json)を利用しています。
# 使い方
## 初回起動時前
1. 同梱の`Config.json`の内容の適切な値に変更する
    |項目|内容|
    |:---:|:---:|
    |ID|学籍番号|
    |Name|名前|
    |Overwrite_Warning|上書き確認|
    * `""`の中に記述すること
    * 文字コードが`UTF-8`になっていることを確認する
      * 名前が文字化けするため

2. ショートカットの作成
    * `Shortcut.bat`を実行
        * 実行ファイル単体では動作しないため、デスクトップなどに設置したいときはショートカットを作成する。
        * ChatGPTを利用したので参考元が不明なことを謝罪します。

## ２回目以降
1. アプリ起動
   * アプリを実行するとコンソールが表示されます。
2. フォルダ作成
   * 課題番号を入力します。
     * 全角半角対応
     * 数字以外にも対応
   * 宿題課題の場合は「s」を入力します。
     * 宿題課題 07のとき
       ```
       s07
       ```
   * 上書き警告が必要なときは`Config.json`を以下のように変更してください。
    ```
    "Overwrite_Warning":true
    ```
     
* 注意
  * 'Module1.vb'のコピペでも動作しますが、`CreDir-vb.zip`を解凍して使うことをおすすめします。
    * 本プログラム実行におけるトラブルについて私は関知しません。
    * 解凍した場合は上記に同意したことになります。パスワードは`PassWord`です


# 引用
## 画像利用
* [TXTファイルのシルエットアイコンイラスト](https://www.silhouette-illust.com/illust/15372)（Silhouette Illust様）
* [フォルダのアイコンのイラスト【フリー素材あそび】](https://commons.nicovideo.jp/material/nc269594)（ニコニ・コモンズ様）

## 参考サイト
* [Json.NET - Newtonsonft](https://www.newtonsoft.com/json)
* [特殊ディレクトリのパスを取得する - dobon.net](https://dobon.net/vb/dotnet/file/getfolderpath.html)
* [エラー処理（例外処理）の基本](https://dobon.net/vb/dotnet/beginner/exceptionhandling.html)
* [自分のアプリケーションの実行ファイルのパスを取得する - dobon.net](https://dobon.net/vb/dotnet/vb6/apppath.html)
