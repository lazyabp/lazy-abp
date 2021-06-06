@ECHO off
cls

ECHO Deleting all special folders...
ECHO.

FOR /d /r . %%d in (bin,obj,LocalNuget) DO (
	IF EXIST "%%d" (		 	 
		ECHO %%d | FIND /I "\node_modules\" > Nul && ( 
			ECHO.Skipping: %%d
		) || (
			ECHO.Deleting: %%d
			rd /s/q "%%d"
		)
	)
)

ECHO.
ECHO.Special folders have been successfully deleted. Press any key to exit.
pause > nul