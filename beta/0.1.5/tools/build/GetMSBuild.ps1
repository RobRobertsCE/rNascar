$msbuildPath = @(& "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -requires Microsoft.Component.MSBuild -version "[15.0,16.0)" -find MSBuild\**\Bin\MSBuild.exe)
if ($msbuildPath.Length -lt 1) {
	Write-Host "Visual Studio not found, trying to find Build Tools..."
	
	$msbuildPath = @(& "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -products * -requires Microsoft.Component.MSBuild -version "[15.0,16.0)" -find MSBuild\**\Bin\MSBuild.exe)

	if ($msbuildPath.Length -lt 1) {
		Write-Error "Visual Studio Could Not Be Found"
		exit 1
	}
}

$msbuildPath = @($msbuildPath | select -first 1)

if (-not (Test-Path $msbuildPath)) {
	Write-Error "MSBuild not found at $msbuildPath"
	exit 1
}

return $msbuildPath