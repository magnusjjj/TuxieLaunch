set PATH=%PATH%;%CD%;%CD%\slamming;C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Source\bin\;
set VProject=C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Source\cstrike
withdll.exe --dll=liar.dll --exe="slamming/hammer.exe" --workdir="C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Source\bin"
rem withdll.exe --dll=DetoursLuaDLL.dll --exe="slamming/hammer.exe"