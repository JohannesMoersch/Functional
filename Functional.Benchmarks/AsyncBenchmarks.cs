using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class AsyncBenchmarks
{
    private readonly Functional.Native.Union<string, int> _nativeStr = "hello";
    private readonly Functional.Native.Union<string, int> _nativeInt = 42;
    private readonly Union<string, int> _legacyStr = "hello";
    private readonly Union<string, int> _legacyInt = 42;

    [Benchmark(Description = "Native.MatchAsync [string]", Baseline = true)]
    public Task<int> Native_MatchAsync_String()
        => _nativeStr.MatchAsync(
            s => Task.FromResult(s.Length),
            i => Task.FromResult(i));

    [Benchmark(Description = "Native.MatchAsync [int]")]
    public Task<int> Native_MatchAsync_Int()
        => _nativeInt.MatchAsync(
            s => Task.FromResult(s.Length),
            i => Task.FromResult(i));

    [Benchmark(Description = "Legacy.MatchAsync [string]")]
    public Task<int> Legacy_MatchAsync_String()
        => _legacyStr.Value().Match(
            s => Task.FromResult(s.Length),
            i => Task.FromResult(i));

    [Benchmark(Description = "Legacy.MatchAsync [int]")]
    public Task<int> Legacy_MatchAsync_Int()
        => _legacyInt.Value().Match(
            s => Task.FromResult(s.Length),
            i => Task.FromResult(i));
}
