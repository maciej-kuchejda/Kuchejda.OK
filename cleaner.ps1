Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

$zipName = 'Maciej Kuchejda-exercise5-wariant4b'
Compress-Archive -Path * $zipName