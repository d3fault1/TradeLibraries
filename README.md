# Trade Libraries

C# libraries and sample apps for a MetaTrader 4, MetaTrader 5, or cTrader account. The trading terminal stays logged in. These programs talk to an expert advisor or a cTrader robot on a chart.

---

## Overview

- `MT4Wrapper`, `MT5Wrapper`, and `CTWrapper` are the account libraries.
- `DemoConsoleApp` is a command prompt for balance, positions, history, and closing trades.
- `TradeLoggerMini` records one account.
- `TradeViewer` shows stored accounts.

---

## Tech Stack

| Component | Technology |
| --- | --- |
| **Language** | C# |
| **Runtime** | .NET Framework 4.7.2 |
| **Terminals** | MetaTrader 4, MetaTrader 5, cTrader |

---

## Project Structure

```
TradeLibraries/
├── DemoConsoleApp.sln
├── DemoConsoleApp/
├── MT4Wrapper/
├── MT5Wrapper/
├── CTWrapper/
├── TradeLoggerMini/
└── TradeViewer/
```

---

## Prerequisites

- Visual Studio with the .NET desktop workload (.NET Framework 4.7.2)
- MetaTrader 4 or 5, or cTrader
- `MtApi.dll` and `MtApi5.dll` for the MetaTrader wrappers
- `MTConnector.dll` and `MT5Connector.dll` for the expert advisors
- A built `CtApi.dll` from [CtraderAPI](https://github.com/d3fault1/CtraderAPI), for `CTWrapper`

---

## Setup

Place `MtApi.dll` and `MtApi5.dll` in `3rdPartyLibs`.

Point `CTWrapper` at your `CtApi.dll`.

Open `DemoConsoleApp.sln`, restore the NuGet packages, and build. Build the wrappers in Release before `TradeLoggerMini` and `TradeViewer`.

---

## Run

Compile `MT5Wrapper/MQL5/MtApi5.mq5` or `MT4Wrapper/MQL4/MtApi.mq4` in MetaEditor, allow DLL imports, and attach it to a chart. For cTrader, start the Ctrader API robot.

Default ports are `8222` for MetaTrader 4, `8228` for MetaTrader 5, and `2529` for cTrader.

Log in on the terminal, then start `DemoConsoleApp`. At the `>` prompt:

```text
connect
getaccinfo
getservertime
getbalance
getequity
pollequity
getpositions
gethistory --start="2021-05-02 00:00:00" --end="2021-05-02 23:59:59"
closepositions --all
disconnect
exit
```

`closepositions` also accepts `--winners` and `--losers`. `DemoConsoleApp.exe -x connect` runs one command and exits.
