Param(
	[parameter(Position=1)]
	[string]
	$Target = "Dlls",
	
	[string]
	$Configuration = "Release",
	
	[string]
	$BuildMode = "Build",
	
	[string]
	$Verbosity = "minimal",

	[switch]
	$NoProcessReuse
)

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition

$msbuild = & "$scriptPath\GetMSBuild.ps1"
if ($LastExitCode -ne 0) {
	exit $LastExitCode
}

$NrFlag = ""
if ($NoProcessReuse) {
	$NrFlag = "/nr:false"
}
$NrFlag

& $msbuild $scriptPath\build.proj /Target:$Target "/p:Configuration=$Configuration;BuildTarget=$BuildMode" /verbosity:$Verbosity /m $NrFlag

if ($LastExitCode -ne 0) {
	exit $LastExitCode
}