:: set folder path
set dump_path=C:\Users\VERAS\AppData\Local\TempB
 
:: set min age of files and folders to delete
set max_days=0
 
:: remove files from %dump_path%
forfiles -p %dump_path% -m rust_* -d -%max_days% -c "cmd  /c del /q @path"
 
:: remove sub directories from %dump_path%
forfiles -p %dump_path% -m "rust_*" -d -%max_days% /c "cmd /c if @isdir == TRUE rd /s /q @path"