$date = Get-Date
$cutoffDate = $date.AddDays(-2)
$path = "C:\Pastas de Trabalho\Projetos\Processos\Processamento\0EA862919085"

Get-ChildItem -Path C:\Users\Administrator\appdata\local\temp\rust_* -Directory | Where-Object LastWriteTime -LT $cutoffDate | Remove-Item -recurse

Get-ChildItem -Recurse | ?{ $_.PSIsContainer } |  Where-Object LastWriteTime -LT $cutoffDate | Remove-Item -recurse
