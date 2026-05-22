using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class LinqBenchmarks
{
    private readonly Functional.Native.Union<string, Exception> _nativeStr = "hello";
    private readonly Functional.Native.Union<string, Exception> _nativeErr = new Exception("fail");
    private readonly Union<string, Exception> _legacyStr = "hello";
    private readonly Union<string, Exception> _legacyErr = new Exception("fail");
    private readonly Option<string> _some = Option.Some("hello");
    private readonly Option<string> _none = Option.None<string>();

    [Benchmark(Description = "Native Union — from x in u select x.ToUpper (string case)", Baseline = true)]
    public Functional.Native.Union<string, Exception> Native_Select_String()
        => from s in _nativeStr select s.ToUpper();

    [Benchmark(Description = "Native Union — from x in u select x.ToUpper (error case)")]
    public Functional.Native.Union<string, Exception> Native_Select_Error()
        => from s in _nativeErr select s.ToUpper();

    [Benchmark(Description = "Legacy Union — Match equivalent (no LINQ support) (string case)")]
    public string Legacy_Match_String()
        => _legacyStr.Value().Match(s => s.ToUpper(), e => e.Message);

    [Benchmark(Description = "Legacy Union — Match equivalent (no LINQ support) (error case)")]
    public string Legacy_Match_Error()
        => _legacyErr.Value().Match(s => s.ToUpper(), e => e.Message);

    [Benchmark(Description = "Option — from x in some select x.ToUpper")]
    public Option<string> Option_Select_Some()
        => from s in _some select s.ToUpper();

    [Benchmark(Description = "Option — from x in none select x.ToUpper")]
    public Option<string> Option_Select_None()
        => from s in _none select s.ToUpper();
}
