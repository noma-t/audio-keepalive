# audio-keepalive

Bluetoothオーディオデバイスがスタンバイに入るのを防ぐため、無音オーディオをバックグラウンドで常時再生するツール。

## 背景

一部のBluetoothスピーカー・サウンドバーは数秒間の無音状態で省電力モードへ移行する。
その結果、次に音が鳴った際に最初の数秒が欠けるという問題が発生する。
本ツールは無音のオーディオストリームを維持し続けることでこの問題を解消する。

## 使い方

[Releases](../../releases/latest) から `silent-audio.exe` をダウンロードして実行する。

スタートアップに登録する場合はタスクスケジューラーを使用する：

- **プログラム：** `C:\path\to\silent-audio.exe`
- **トリガー：** ログオン時
- **引数：** 不要

## リソース使用量

| | |
|---|---|
| RAM | 3〜5 MB 程度 |
| CPU | 0% 程度 |

## 動作環境

- Windows 10 / 11
- .NET Framework 4.8（Windows標準搭載）

## ビルド

```cmd
dotnet publish -c Release
```

バージョンタグをプッシュするとリリースワークフローが自動実行される：

```bash
git tag v1.0.0
git push origin v1.0.0
```

## 動作確認済みデバイス

- Yamaha SR-C20A
