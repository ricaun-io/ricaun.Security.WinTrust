# Create `signfile` files

## Location

The `MakeCert.exe`, `pvk2pfx.exe` and `signtool.exe` are located in the Windows SDK folder. For example:
```
C:\Program Files (x86)\Windows Kits\10\bin\x64\
```

## Make cert and sign file

```
"MakeCert.exe" -r -sv signfile.pvk -n "CN=signfile" signfile.cer -b 01/01/2020 -e 12/31/2050
"pvk2pfx.exe" -pvk signfile.pvk -pi signfile -spc signfile.cer -pfx signfile.pfx -po signfile
```

## Sign file

```
"signtool.exe" sign /f "signfile.pfx" /t http://timestamp.digicert.com /p "signfile" /fd sha1 "ConsoleApp.exe"
```