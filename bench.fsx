// compile with "fsc -O bench.fsx"

#I __SOURCE_DIRECTORY__

#r "./packages/BenchmarkDotNet/lib/net45/BenchmarkDotNet.dll"
#r "./packages/BenchmarkDotNet.Diagnostics.Windows/lib/net40/BenchmarkDotNet.Diagnostics.Windows.dll"
#r "./packages/Microsoft.Diagnostics.Tracing.TraceEvent/lib/net40/Microsoft.Diagnostics.Tracing.TraceEvent.dll"

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Jobs
open BenchmarkDotNet.Diagnostics.Windows

type ConfigNet45MemoryDiag() as this =
  inherit BenchmarkDotNet.Configs.ManualConfig()
  do
    this.Add(MemoryDiagnoser())
    this.Add(Job.Default
              .WithIterationTime(Count 1000)
              .WithLaunchCount(Count 3)
              .WithWarmupCount(Count 3)
              .WithTargetCount(Count 3)
              .With(Framework.V45)
              .With(Platform.AnyCpu))

[<ConfigNet45MemoryDiag>]
type MyBenchmark() =
  
  [<Benchmark>]
  member this.AddInts () = 1+1

  [<Benchmark>]
  member this.AddFloats () = 1.0 + 1.0
