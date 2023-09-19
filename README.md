# ricaun.Security.WinTrust

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)
[![.NET Framework 4.5](https://img.shields.io/badge/.NET%20Framework%204.5-blue.svg)](../..)
[![.NET Standard 2.0](https://img.shields.io/badge/.NET%20Standard%202.0-blue.svg)](../..)

## Description

Simple package with the purpose of validating the signature of a file using the WinTrust API.

## Usage
### WinTrust
Utility class to validate the signature of a file is trusted.

```csharp
var result = WinTrust.VerifyEmbeddedSignature(@"C:\Windows\explorer.exe");
```

### Certificate
Utility class to check if the file is signed.

```csharp
var result = Certificate.IsSignedFile(@"C:\Windows\explorer.exe");
```

## Release

* [Latest release](../../releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!