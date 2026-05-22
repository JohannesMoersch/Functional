using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class CreationBenchmarks
{
    [Benchmark(Description = "Legacy.Create [string]", Baseline = true)]
    public Union<string, int> Legacy_Create_String() => "hello benchmark";

    [Benchmark(Description = "Legacy.Create [int]")]
    public Union<string, int> Legacy_Create_Int() => 42;

    [Benchmark(Description = "Native.Create [string]")]
    public Functional.Native.Union<string, int> Native_Create_String() => "hello benchmark";

    [Benchmark(Description = "Native.Create [int]")]
    public Functional.Native.Union<string, int> Native_Create_Int() => 42;
}
