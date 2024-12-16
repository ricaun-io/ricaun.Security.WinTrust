# ricaun.Security.WinTrust

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/ricaun.Security.WinTrust)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/ricaun.Security.WinTrust/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/ricaun.Security.WinTrust/actions)
[![nuget](https://img.shields.io/nuget/v/ricaun.Security.WinTrust?logo=nuget&label=nuget&color=blue)](https://www.nuget.org/packages/ricaun.Security.WinTrust)

## Description

Simple package with the purpose of validating the signature of a file using the WinTrust API.

## Usage
### WinTrust
Utility class to validate the signature of a file is trusted using the WinTrust API.

```csharp
bool result = WinTrust.VerifyEmbeddedSignature(@"C:\Windows\explorer.exe");
```

### Certificate
Utility class to check the `Certificate` file is signed, subject and issuer. 

```csharp
bool result = Certificate.IsSignedFile(@"C:\Windows\explorer.exe");
```

If you want to get the subject or issuer of the file, you can use the following methods:
 
``` csharp
string subject = Certificate.GetSignedFileSubject(@"C:\Windows\explorer.exe");
string issuer = Certificate.GetSignedFileIssuer(@"C:\Windows\explorer.exe");
```

If you want to get a specific field of the subject or issuer, you can use the following methods:

``` csharp
string communName = Certificate.GetSignedFileSubject(@"C:\Windows\explorer.exe", "cn"); // "Microsoft Windows"
string organization = Certificate.GetSignedFileIssuer(@"C:\Windows\explorer.exe", "o"); // "Microsoft Corporation"
```

Some of the most common [RDNs](https://docs.oracle.com/cd/E24191_01/common/tutorials/authz_cert_attributes.html) and their explanations are as follows: 

```
CN: CommonName
O: Organization
L: Locality
S: StateOrProvinceName
C: CountryName
```

## Dummy Certificate

The [signfile.pfx](ricaun.Security.WinTrust.Tests/signfile) is a dummy certificate created to sign the `ConsoleAppSignedNotTrusted.exe` file and test the `WinTrust.VerifyEmbeddedSignature` method.

## Release

* [Latest release](https://github.com/ricaun-io/ricaun.Security.WinTrust/releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/ricaun.Security.WinTrust/stargazers)!