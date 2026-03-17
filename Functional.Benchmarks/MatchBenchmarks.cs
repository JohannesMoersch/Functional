using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class MatchBenchmarks
{
    private readonly Union<string, int> _legacyStr = "hello benchmark";
    private readonly Union<string, int> _legacyInt = 42;
    private readonly Functional.Native.Union<string, int> _nativeStr = "hello benchmark";
    private readonly Functional.Native.Union<string, int> _nativeInt = 42;

    [Benchmark(Description = "Legacy.Match [string]", Baseline = true)]
    public int Legacy_Match_String() => _legacyStr.Value().Match(s => s.Length, i => i);

    [Benchmark(Description = "Legacy.Match [int]")]
    public int Legacy_Match_Int() => _legacyInt.Value().Match(s => s.Length, i => i);

    [Benchmark(Description = "Native.Match [string]")]
    public int Native_Match_String() => _nativeStr.Match(s => s.Length, i => i);

    [Benchmark(Description = "Native.Match [int]")]
    public int Native_Match_Int() => _nativeInt.Match(s => s.Length, i => i);
}
