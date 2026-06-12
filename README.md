# audio-keepalive

Prevents Bluetooth audio devices from entering standby by continuously playing silent audio.

## Background

Some Bluetooth speakers and soundbars automatically enter a power-saving state
after a few seconds of silence, causing the first few seconds of audio to be lost
on resume. This tool solves that by keeping a silent audio stream alive at all times.

## Usage

Download `silent-audio.exe` from [Releases](../../releases/latest) and run it.

To run on startup, register it with Task Scheduler:

- **Program:** `C:\path\to\silent-audio.exe`
- **Trigger:** At log on
- **Run in background:** Action → `Start a program` only, no arguments needed

## Resource usage

| | |
|---|---|
| RAM | ~3–5 MB |
| CPU | ~0% |

## Requirements

- Windows 10 / 11
- .NET Framework 4.8 (included in Windows by default)

## Build

```cmd
dotnet publish -c Release
```

Or push a version tag to trigger the release workflow:

```bash
git tag v1.0.0
git push origin v1.0.0
```

## Tested devices

- Yamaha SR-C20A
