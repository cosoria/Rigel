rem /d means only copy files with a newer date then whats there
xcopy source\Rigel.Batch\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Container.StructureMap\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Core\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Data\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Data.EntityFramework\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Logging\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Mapping\bin\Debug\Rigel.* binaries /d /y
xcopy source\Rigel.Web\bin\Debug\Rigel.* binaries /d /y
pause