using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class OptionBenchmarks
{
    private readonly Option<string> _some = Option.Some("hello benchmark");
    private readonly Option<string> _none = Option.None<string>();

    [Benchmark(Description = "Option.Match [some]", Baseline = true)]
    public int Option_Match_Some()
        => _some.Match(s => s.Length, () => 0);

    [Benchmark(Description = "Option.Match [none]")]
    public int Option_Match_None()
        => _none.Match(s => s.Length, () => 0);

    [Benchmark(Description = "Option.ValueOrDefault [some]")]
    public string? Option_ValueOrDefault_Some()
        => _some.ValueOrDefault();

    [Benchmark(Description = "Option.ValueOrDefault [none]")]
    public string? Option_ValueOrDefault_None()
        => _none.ValueOrDefault();
}
