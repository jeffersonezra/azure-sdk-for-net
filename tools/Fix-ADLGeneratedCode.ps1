# This script must be run after generation of the C# SDK from AutoRest/Swagger 
# from its location in tools, specifying DataLakeStore, DataLakeAnalytics or both switches.
param (
	[switch] $DataLakeStore,
	[switch] $DataLakeAnalytics
)

# Helper Functions
function ExecuteActions
{
	param (
		[hashtable]$fileActionDictionary
	)
	
	foreach($file in $fileActionDictionary.Keys)
	{
		foreach($action in $fileActionDictionary[$file])
		{
			# execute each action on the file
			ExecuteAction -fileName $file -actionName $action
		}
	}
}

function ExecuteAction
{
	param (
		[string]$fileName,
		[string]$actionName
	)
	
	switch($actionName)
	{
		"StoreVariableReplacement"
		{
			$result = AccountAndUriVariableReplacement -filePath (Join-Path $dataLakeStorePath $fileName) -uriVariableName "datalakeserviceuri"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		"FileSystemUrlReplacement"
		{
			$result = UrlStringReplacement -filePath (Join-Path $dataLakeStorePath $fileName) -uriVariable "Datalakeserviceuri" -uriValue "azuredatalakestore.net"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		"CatalogUrlReplacement"
		{
			$result = UrlStringReplacement -filePath (Join-Path $dataLakeAnalyticsPath $fileName) -uriVariable "Catalogserviceuri" -uriValue "azuredatalakeanalytics.net"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		"JobUrlReplacement"
		{
			$result = UrlStringReplacement -filePath (Join-Path $dataLakeAnalyticsPath $fileName) -uriVariable "Jobserviceuri" -uriValue "azuredatalakeanalytics.net"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		"HttpClientHandlerReplacement"
		{
			$result = HttpClientHandlerReplacement -filePath (Join-Path $dataLakeStorePath $fileName)
			break
		}
		"JobVariableReplacement"
		{
			$result = AccountAndUriVariableReplacement -filePath (Join-Path $dataLakeAnalyticsPath $fileName) -uriVariableName "jobserviceuri"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		"CatalogVariableReplacement"
		{
			$result = AccountAndUriVariableReplacement -filePath (Join-Path $dataLakeAnalyticsPath $fileName) -uriVariableName "catalogserviceuri"
			LogStatus -result $result -fileName $fileName -actionName $actionName
			break
		}
		default
		{
			throw "Unknown action specified. Action name: $actionName"
		}
	}
}

function GetFileContent
{
	param (
		[string] $filePath
	)
	
	if($pathAndContentsPairs.ContainsKey($filePath))
	{
		return $pathAndContentsPairs[$filePath]
	}
	else
	{
		return Get-Content -Path $filePath -Encoding UTF8 -Raw
	}
}

function SaveAllFileContent
{
	foreach($file in $pathAndContentsPairs.Keys)
	{
		Out-File -FilePath $file -Encoding UTF8 -Force -Confirm:$false -InputObject $pathAndContentsPairs[$file]
	}
}

function AddOrUpdateFileList
{
	param (
		[string] $filePath,
		$content
	)
	
	if($pathAndContentsPairs.ContainsKey($filePath))
	{
		$pathAndContentsPairs[$filePath] = $content
	}
	else
	{
		$pathAndContentsPairs.Add($filePath, $content)
	}
}

function LogStatus
{
	param (
		[bool]$result,
		[string]$fileName,
		[string]$actionName
	)
	
	if($result)
	{
		Write-Host "Successfully Executed $actionName on file: $fileName"
	}
	else
	{
		Write-Warning "Action: $actionName resulted in no change to file: $fileName"
	}
}

function AccountAndUriVariableReplacement
{
	param (
		[string]$filePath,
		[string]$uriVariableName
	)
	
	$fileContent = GetFileContent $filePath
	[string]$newFile = $fileContent.Replace("Replace(`"{accountname}`"","Replace(`"accountname`"")
	[string]$newFile = $newFile.Replace("Replace(`"{$uriVariableName}`"","Replace(`"$uriVariableName`"")
	if($newFile -ine $fileContent)
	{
		AddOrUpdateFileList -filePath $filePath -content $newFile
		return $true
	}
	
	return $false
	
}

function UrlStringReplacement
{
	param (
		[string]$filePath,
		[string] $uriVariable,
		[string] $uriValue
	)
	
	$fileContent = GetFileContent $filePath
	[string]$newFile = $fileContent
	
		$stringToReplace = "this.$uriVariable = $uriValue;"
		$stringToUse = "this.$uriVariable = `"$uriValue`";"
		[string]$newFile = $newFile.Replace($stringToReplace, $stringToUse)
	
	if($newFile -ine $fileContent)
	{
		AddOrUpdateFileList -filePath $filePath -content $newFile
		return $true
	}
	
	return $false
}

function HttpClientHandlerReplacement
{
	param (
		[string]$filePath
	)
	
	$fileContent = GetFileContent $filePath
	[string]$newFile = $fileContent
	
	$oldNewPairs = @{"this(rootHandler" = @"
this(new HttpClientHandler
        {
            AllowAutoRedirect = false,
            ClientCertificateOptions = rootHandler.ClientCertificateOptions,
            AutomaticDecompression = rootHandler.AutomaticDecompression,
            CookieContainer = rootHandler.CookieContainer,
            Credentials = rootHandler.Credentials,
            MaxAutomaticRedirections = rootHandler.MaxAutomaticRedirections,
            MaxRequestContentBufferSize = rootHandler.MaxRequestContentBufferSize,
            PreAuthenticate = rootHandler.PreAuthenticate,
            Proxy = rootHandler.Proxy,
            UseCookies = rootHandler.UseCookies,
            UseDefaultCredentials = rootHandler.UseDefaultCredentials,
            UseProxy = rootHandler.UseProxy
        }
"@; "this(handlers" = @"
this(new HttpClientHandler
        {
            AllowAutoRedirect = false,
            ClientCertificateOptions = ClientCertificateOption.Automatic
        }, handlers
"@
	}
	
	foreach($original in $oldNewPairs.Keys)
	{
		[string]$newFile = $newFile.Replace($original, $oldNewPairs[$original])	
	}
	
	if($newFile -ine $fileContent)
	{
		AddOrUpdateFileList -filePath $filePath -content $newFile
		return $true
	}
	
	return $false
}

# define constants
$executingDir = Split-Path -parent $MyInvocation.MyCommand.Definition
$dataLakeStorePath = Join-Path $executingDir "..\src\ResourceManagement\DataLake.Store\Microsoft.Azure.Management.DataLake.Store\Generated"
$dataLakeAnalyticsPath = Join-Path $executingDir "..\src\ResourceManagement\DataLake.Analytics\Microsoft.Azure.Management.DataLake.Analytics\Generated"

# define file/action pairs
$dataLakeStoreActions = @{"FileSystemOperations.cs" = @("StoreVariableReplacement");
						  "DataLakeStoreFileSystemManagementClient.cs" = @("FileSystemUrlReplacement")}
$dataLakeAnalyticsActions = @{"JobOperations.cs" = @("JobVariableReplacement");
							  "CatalogOperations.cs" = @("CatalogVariableReplacement");
							  "DataLakeAnalyticsCatalogManagementClient.cs" = @("CatalogUrlReplacement");
							  "DataLakeAnalyticsJobManagementClient.cs" = @("JobUrlReplacement")}

# Define the list of filepaths and their contents that need to be set
$pathAndContentsPairs = @{}

if($DataLakeStore)
{
	# Iterate through actions for DataLake Store
	ExecuteActions -fileActionDictionary $dataLakeStoreActions
}

if($DataLakeAnalytics)
{
	# Iterate through actions for DataLake Analytics
	ExecuteActions -fileActionDictionary $dataLakeAnalyticsActions
}

SaveAllFileContent