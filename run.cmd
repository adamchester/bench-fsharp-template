@ECHO OFF

fsc -O bench.fsx -o:bin\Bench.exe

copy packages\BenchmarkDotNet\lib\net40\BenchmarkDotNet.dll bin
copy packages\BenchmarkDotNet.Diagnostics.Windows\lib\net40\BenchmarkDotNet.Diagnostics.Windows.dll bin
copy packages\Microsoft.Diagnostics.Tracing.TraceEvent\lib\net40\Microsoft.Diagnostics.Tracing.TraceEvent.dll bin

bin\bench.exe