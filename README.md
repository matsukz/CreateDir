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
    * `""`の中に記述すること
    * 文字コードが`UTF-8`になっていることを確認する
      * 名前が文字化けするため

2. ショートカットの作成
    * 実行ファイル単体では動作しないため、デスクトップなどに設置したいときはショートカットを作成する。

## ２回目以降
1. アプリ起動
   * アプリを実行するとコンソールが表示されます。
2. フォルダ作成
   * 課題番号を入力します。
     * 全角半角対応
     * 数字以外にも対応
* 注意
  * フォルダは上書きされます。警告もありません 

# 引用
## 画像利用
* [TXTファイルのシルエットアイコンイラスト](https://www.silhouette-illust.com/illust/15372)（Silhouette Illust様）
* [フォルダのアイコンのイラスト【フリー素材あそび】](https://commons.nicovideo.jp/material/nc269594)（ニコニ・コモンズ様）

## 参考サイト
* [Json.NET - Newtonsonft](https://www.newtonsoft.com/json)
* [特殊ディレクトリのパスを取得する - dobon.net](https://dobon.net/vb/dotnet/file/getfolderpath.html)
