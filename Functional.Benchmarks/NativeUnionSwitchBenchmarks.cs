using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Functional;
using Functional.Native;

namespace Functional.Benchmarks;

/// <summary>
/// Compares the three ways to work with a native Union&lt;,&gt;:
///
///   1. Implicit creation  (value assignment — what the compiler lowers to)
///   2. .Match()           (the extension method that calls the compiler switch internally)
///   3. Direct switch      (inline `u switch { T v => ... }` written by hand)
///
/// Expectation: Match and direct switch should be identical once the JIT inlines
/// the Match method body, since Match is itself a one-line switch expression.
/// Any delta reveals the cost of the extra indirection (Func&lt;&gt; delegate invocations).
/// </summary>
[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, iterationCount: 7)]
public class NativeUnionSwitchBenchmarks
{
    // ── Pre-built values ─────────────────────────────────────────────────

    private readonly Functional.Native.Union<string, int> _str = "hello benchmark";
    private readonly Functional.Native.Union<string, int> _int = 42;

    // ── Creation: one-liner implicit assignment ───────────────────────────

    [Benchmark(Description = "Create [string]", Baseline = true)]
    public Functional.Native.Union<string, int> Create_String()
        => "hello benchmark";

    [Benchmark(Description = "Create [int]")]
    public Functional.Native.Union<string, int> Create_Int()
        => 42;

    // ── Match via .Match() method ─────────────────────────────────────────

    [Benchmark(Description = "Match() [string]")]
    public int Method_Match_String()
        => _str.Match(s => s.Length, i => i);

    [Benchmark(Description = "Match() [int]")]
    public int Method_Match_Int()
        => _int.Match(s => s.Length, i => i);

    // ── Match via inline switch expression ────────────────────────────────

    [Benchmark(Description = "switch [string]")]
    public int Switch_String()
        => _str switch { string s => s.Length, int i => i };

    [Benchmark(Description = "switch [int]")]
    public int Switch_Int()
        => _int switch { string s => s.Length, int i => i };

    // ── Legacy equivalent (virtual dispatch baseline) ─────────────────────

    private readonly Union<string, int> _legacyStr = "hello benchmark";
    private readonly Union<string, int> _legacyInt = 42;

    [Benchmark(Description = "Legacy.Match [string]")]
    public int Legacy_Match_String()
        => _legacyStr.Value().Match(s => s.Length, i => i);

    [Benchmark(Description = "Legacy.Match [int]")]
    public int Legacy_Match_Int()
        => _legacyInt.Value().Match(s => s.Length, i => i);
}
