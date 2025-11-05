<#
PowerShell script para descargar y extraer los DLL nativos de Microsoft.SqlServer.Types
- Descarga nuget.exe (si no existe)
- Instala el paquete Microsoft.SqlServer.Types localmente
- Busca SqlServerSpatial140.dll y msvcr120.dll y los copia a SqlServerTypes\x64 y SqlServerTypes\x86

Uso:
  1. Abrir PowerShell en la raíz del repositorio (donde está la solución)
  2. Ejecutar: .\scripts\get-sqlservertypes.ps1
#>

param(
    [string]$PackageId = "Microsoft.SqlServer.Types",
    [string]$PackageVersion = "",
    [string]$OutputPackagesDir = "packages_tmp",
    [string]$DestDir = "SqlServerTypes"
)

Set-StrictMode -Version Latest
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
Push-Location $scriptDir

try {
    # Crear dirs
    if (-not (Test-Path $OutputPackagesDir)) { New-Item -ItemType Directory -Path $OutputPackagesDir | Out-Null }
    if (-not (Test-Path $DestDir)) {
        New-Item -ItemType Directory -Path (Join-Path $DestDir "x64") -Force | Out-Null
        New-Item -ItemType Directory -Path (Join-Path $DestDir "x86") -Force | Out-Null
    } else {
        if (-not (Test-Path (Join-Path $DestDir "x64"))) { New-Item -ItemType Directory -Path (Join-Path $DestDir "x64") -Force | Out-Null }
        if (-not (Test-Path (Join-Path $DestDir "x86"))) { New-Item -ItemType Directory -Path (Join-Path $DestDir "x86") -Force | Out-Null }
    }

    # Descargar nuget.exe si falta
    $nugetExe = Join-Path $scriptDir "nuget.exe"
    if (-not (Test-Path $nugetExe)) {
        Write-Host "Descargando nuget.exe..."
        $nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
        Invoke-WebRequest -Uri $nugetUrl -OutFile $nugetExe
    }

    # Preparar comando nuget install
    $nugetCmd = "& `"$nugetExe`" install $PackageId -OutputDirectory `"$OutputPackagesDir`" -Source https://api.nuget.org/v3/index.json -NonInteractive -DirectDownload"
    if ($PackageVersion -ne "") {
        $nugetCmd = $nugetCmd + " -Version $PackageVersion"
    }

    Write-Host "Instalando paquete $PackageId..."
    Invoke-Expression $nugetCmd

    # Buscar archivos nativos en el paquete instalado
    $foundSpatial = Get-ChildItem -Path $OutputPackagesDir -Filter "SqlServerSpatial140.dll" -Recurse -ErrorAction SilentlyContinue
    $foundMsvcr = Get-ChildItem -Path $OutputPackagesDir -Filter "msvcr120.dll" -Recurse -ErrorAction SilentlyContinue

    if (($foundSpatial -eq $null -or $foundSpatial.Count -eq 0) -and ($foundMsvcr -eq $null -or $foundMsvcr.Count -eq 0)) {
        Write-Host "No se encontraron los DLL nativos dentro del paquete descargado. Comprueba la versión del paquete o instala Microsoft.SqlServer.Types desde NuGet en Visual Studio." -ForegroundColor Yellow
        return
    }

    # Copiar archivos encontrados a SqlServerTypes\x64 o x86 según ruta
    foreach ($file in $foundSpatial) {
        $lower = $file.DirectoryName.ToLower()
        if ($lower -match "x64" -or $lower -match "win-x64" -or $lower -match "native\\x64" -or $lower -match "runtimes") {
            $dest = Join-Path $DestDir "x64"
        } else {
            $dest = Join-Path $DestDir "x86"
        }
        Copy-Item -Path $file.FullName -Destination $dest -Force
        Write-Host "Copiado: $($file.Name) -> $dest"
    }

    foreach ($file in $foundMsvcr) {
        $lower = $file.DirectoryName.ToLower()
        if ($lower -match "x64" -or $lower -match "win-x64" -or $lower -match "native\\x64" -or $lower -match "runtimes") {
            $dest = Join-Path $DestDir "x64"
        } else {
            $dest = Join-Path $DestDir "x86"
        }
        Copy-Item -Path $file.FullName -Destination $dest -Force
        Write-Host "Copiado: $($file.Name) -> $dest"
    }

    Write-Host ""
    Write-Host "Operación completada."
    Write-Host "Siguientes pasos:"
    Write-Host "1) En Visual Studio: Solution Explorer -> Add -> Existing Item... -> agrega los DLL desde $DestDir\x64 y $DestDir\x86."
    Write-Host "2) Para cada DLL: Properties -> Copy to Output Directory = 'Copy if newer'."
    Write-Host "3) Ejecuta la aplicación. Si falta msvcr120.dll en la máquina destino, instala el Visual C++ 2013 Redistributable."
}
catch {
    Write-Error "Error: $($_.Exception.Message)"
}
finally {
    Pop-Location
}
