nuget restore
Get-ChildItem *.csproj -Recurse -Exclude *[Tt]est* | %{
	nuget pack $_ -Build -Properties Configuration=Release
}