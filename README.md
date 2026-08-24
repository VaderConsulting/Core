# Core

VB.NET class-library suite (Vader Consulting Core/Infrastructure) covering config, logging, SQL, encryption, security, networking, compression, zip, email, licensing, scheduling, directory, XML, math, install helpers, FleetManager, and serial/PABX. The tree keeps several Visual Studio solutions: `Infrastructure.sln` at the root, `Core/Core.sln`, `1.1/Core.sln`, `3.5/Infrastructure.sln`, and `Serial/Serial.sln` (with 3.5 and Backup copies). Root assemblies identify Vader Consulting 2013 (Common is Core.Common 1.2.9.25); the 3.5 copies still record Stratatel Ltd 2011.

**Source last updated:** 2013-09-09  
**Language:** VB.NET  
**Target:** v3.5  
**Output:** Library, WinExe

## What it is

VB.NET class-library suite (Vader Consulting Core/Infrastructure) covering config, logging, SQL, encryption, security, networking, compression, zip, email, licensing, scheduling, directory, XML, math, install helpers, FleetManager, and serial/PABX. The tree keeps several Visual Studio solutions: `Infrastructure.sln` at the root, `Core/Core.sln`, `1.1/Core.sln`, `3.5/Infrastructure.sln`, and `Serial/Serial.sln` (with 3.5 and Backup copies). Root assemblies identify Vader Consulting 2013 (Common is Core.Common 1.2.9.25); the 3.5 copies still record Stratatel Ltd 2011.

## Solution structure

| Project | Language | Path |
|---------|----------|------|
| `FleetManager` | VB.NET | `FleetManager/FleetManager.vbproj` |
| `Test` | VB.NET | `Test/Test.vbproj` |
| `Compression` | VB.NET | `Compression/Compression.vbproj` |
| `Config` | VB.NET | `Config/Config.vbproj` |
| `FileTransfer` | VB.NET | `FileTransfer/FileTransfer.vbproj` |
| `FleetManager` | VB.NET | `1.1/FleetManager/FleetManager.vbproj` |
| `Test` | VB.NET | `1.1/Test/Test.vbproj` |
| `StatusEmail` | VB.NET | `1.1/StatusEmail/StatusEmail.vbproj` |
| `Common` | VB.NET | `1.1/Common/Common.vbproj` |
| `FMWeb` | VB.NET | `1.1/FMWeb/FMWeb.vbproj` |
| `My` | VB.NET | `1.1/My/My.vbproj` |
| `SQL` | VB.NET | `1.1/SQL/SQL.vbproj` |
| `Logging` | VB.NET | `1.1/Logging/Logging.vbproj` |
| `Email` | VB.NET | `1.1/Email/Email.vbproj` |
| `Scheduling` | VB.NET | `Scheduling/Scheduling.vbproj` |
| `StatusEmail` | VB.NET | `StatusEmail/StatusEmail.vbproj` |
| `Directory` | VB.NET | `Directory/Directory.vbproj` |
| `Tracing` | VB.NET | `Tracing/Tracing.vbproj` |
| `TaskScheduler` | VB.NET | `TaskScheduler/TaskScheduler.vbproj` |
| `Licensing` | VB.NET | `Licensing/Licensing.vbproj` |
| `Common` | VB.NET | `Common/Common.vbproj` |
| `Math` | VB.NET | `Math/Math.vbproj` |
| `InstallHelper` | VB.NET | `InstallHelper/InstallHelper.vbproj` |
| `FleetManager` | VB.NET | `3.5/FleetManager/FleetManager.vbproj` |
| `Test` | VB.NET | `3.5/Test/Test.vbproj` |
| `Compression` | VB.NET | `3.5/Compression/Compression.vbproj` |
| `Config` | VB.NET | `3.5/Config/Config.vbproj` |
| `FileTransfer` | VB.NET | `3.5/FileTransfer/FileTransfer.vbproj` |
| `Scheduling` | VB.NET | `3.5/Scheduling/Scheduling.vbproj` |
| `StatusEmail` | VB.NET | `3.5/StatusEmail/StatusEmail.vbproj` |
| `Directory` | VB.NET | `3.5/Directory/Directory.vbproj` |
| `Tracing` | VB.NET | `3.5/Tracing/Tracing.vbproj` |
| `TaskScheduler` | VB.NET | `3.5/TaskScheduler/TaskScheduler.vbproj` |
| `Licensing` | VB.NET | `3.5/Licensing/Licensing.vbproj` |
| `Common` | VB.NET | `3.5/Common/Common.vbproj` |
| `Math` | VB.NET | `3.5/Math/Math.vbproj` |
| `InstallHelper` | VB.NET | `3.5/InstallHelper/InstallHelper.vbproj` |
| `ResetPassword` | VB.NET | `3.5/ResetPassword/ResetPassword.vbproj` |
| `XML` | VB.NET | `3.5/XML/XML.vbproj` |
| `Network` | VB.NET | `3.5/Network/Network.vbproj` |
| `Encryption` | VB.NET | `3.5/Encryption/Encryption.vbproj` |
| `Security` | VB.NET | `3.5/Security/Security.vbproj` |
| `ZipFile` | VB.NET | `3.5/ZipFile/ZipFile.vbproj` |
| `Setup` | VB.NET | `3.5/Setup/Setup.vbproj` |
| `Test` | VB.NET | `3.5/Serial/Test/Test.vbproj` |
| `PABX` | VB.NET | `3.5/Serial/PABX/PABX.vbproj` |
| `PABX` | VB.NET | `3.5/Serial/Tx/PABX.vbproj` |
| `Serial` | VB.NET | `3.5/Serial/Serial/Serial.vbproj` |
| `Test` | VB.NET | `3.5/Serial/Backup/Test/Test.vbproj` |
| `PABX` | VB.NET | `3.5/Serial/Backup/PABX/PABX.vbproj` |
| `Serial` | VB.NET | `3.5/Serial/Backup/Serial/Serial.vbproj` |
| `SQL` | VB.NET | `3.5/SQL/SQL.vbproj` |
| `Logging` | VB.NET | `3.5/Logging/Logging.vbproj` |
| `Email` | VB.NET | `3.5/Email/Email.vbproj` |
| `ResetPassword` | VB.NET | `ResetPassword/ResetPassword.vbproj` |
| `XML` | VB.NET | `XML/XML.vbproj` |
| `Network` | VB.NET | `Network/Network.vbproj` |
| `Encryption` | VB.NET | `Encryption/Encryption.vbproj` |
| `Security` | VB.NET | `Security/Security.vbproj` |
| `Test` | VB.NET | `Core/Test/Test.vbproj` |
| `Common` | VB.NET | `Core/Common/Common.vbproj` |
| `My` | VB.NET | `Core/My/My.vbproj` |
| `Logging` | VB.NET | `Core/Logging/Logging.vbproj` |
| `ZipFile` | VB.NET | `ZipFile/ZipFile.vbproj` |
| `Setup` | VB.NET | `Setup/Setup.vbproj` |
| `Test` | VB.NET | `Serial/Test/Test.vbproj` |
| `PABX` | VB.NET | `Serial/PABX/PABX.vbproj` |
| `PABX` | VB.NET | `Serial/Tx/PABX.vbproj` |
| `Serial` | VB.NET | `Serial/Serial/Serial.vbproj` |
| `Test` | VB.NET | `Serial/Backup/Test/Test.vbproj` |
| `PABX` | VB.NET | `Serial/Backup/PABX/PABX.vbproj` |
| `Serial` | VB.NET | `Serial/Backup/Serial/Serial.vbproj` |
| `SQL` | VB.NET | `SQL/SQL.vbproj` |
| `Logging` | VB.NET | `Logging/Logging.vbproj` |
| `Email` | VB.NET | `Email/Email.vbproj` |

## How to open

Open `Infrastructure.sln` in Visual Studio.

## Attribution and provenance

- **Assembly company:** Microsoft, Stratatel, Stratatel 2011, Stratatel Ltd, Vader Consulting, stratatel
- **Assembly copyright:** 2010, Copyright © Microsoft 2009, Copyright © Microsoft 2010, Copyright © Stratatel 2011, Copyright © Stratatel Ltd 2009, Copyright © Stratatel Ltd 2010, Copyright © Stratatel Ltd 2011, Copyright © Vader Consulting 2013, Copyright © stratatel 2008, Copyright � Stratatel Ltd 2011

## License

MIT. See `LICENSE`.
