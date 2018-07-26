:RunOpenCoverUnitTestMetrics
"%~dp0packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0BankTest\bin\Debug\BankTest.dll\" /resultsfile:\"%~dp0BankTest.trx\"" ^
-filter:"+[Bank*]* -[BankTest]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\BankTestReport.xml"


:RunReportGeneratorOutput
"%~dp0\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\BankTestReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGeneratorOutput"

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGeneratorOutput\index.htm"
