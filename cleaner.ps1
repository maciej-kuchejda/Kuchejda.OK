Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

$zipName = 'Maciej Kuchejda-exercise4-wariant4'
Compress-Archive -Path * $zipName