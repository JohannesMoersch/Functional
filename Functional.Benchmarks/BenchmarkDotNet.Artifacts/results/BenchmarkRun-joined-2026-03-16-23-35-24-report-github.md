```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.7840)
13th Gen Intel Core i7-13705H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 11.0.100-preview.2.26159.112
  [Host]     : .NET 11.0.0 (11.0.26.16012), X64 RyuJIT AVX2
  Job-RCHZZN : .NET 11.0.0 (11.0.26.16012), X64 RyuJIT AVX2

IterationCount=7  LaunchCount=1  WarmupCount=5  

```
| Type                        | Method                                                            | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------------------------------------------------------------------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| AsyncBenchmarks             | &#39;Native.MatchAsync [string]&#39;                                      |  3.0783 ns | 0.2012 ns | 0.0893 ns |  3.0486 ns |  1.00 |    0.04 |      - |         - |          NA |
| CreationBenchmarks          | &#39;Legacy.Create [string]&#39;                                          |  6.7661 ns | 0.6564 ns | 0.2914 ns |  6.6525 ns |  2.20 |    0.11 | 0.0025 |      32 B |          NA |
| LinqBenchmarks              | &#39;Native Union — from x in u select x.ToUpper (string case)&#39;       | 32.8741 ns | 3.1271 ns | 1.3885 ns | 33.2938 ns | 10.69 |    0.51 | 0.0076 |      96 B |          NA |
| MatchBenchmarks             | &#39;Legacy.Match [string]&#39;                                           |  2.9761 ns | 0.5892 ns | 0.2101 ns |  3.0373 ns |  0.97 |    0.07 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Create [string]&#39;                                                 |  0.0238 ns | 0.1164 ns | 0.0415 ns |  0.0065 ns |  0.01 |    0.01 |      - |         - |          NA |
| OptionBenchmarks            | &#39;Option.Match [some]&#39;                                             |  3.8624 ns | 0.6966 ns | 0.3093 ns |  4.0044 ns |  1.26 |    0.10 |      - |         - |          NA |
| AsyncBenchmarks             | &#39;Native.MatchAsync [int]&#39;                                         | 10.2733 ns | 0.8453 ns | 0.3753 ns | 10.4222 ns |  3.34 |    0.14 | 0.0057 |      72 B |          NA |
| CreationBenchmarks          | &#39;Legacy.Create [int]&#39;                                             |  6.6234 ns | 0.4935 ns | 0.1760 ns |  6.6248 ns |  2.15 |    0.08 | 0.0025 |      32 B |          NA |
| LinqBenchmarks              | &#39;Native Union — from x in u select x.ToUpper (error case)&#39;        | 17.9955 ns | 1.0173 ns | 0.3628 ns | 17.9919 ns |  5.85 |    0.19 | 0.0051 |      64 B |          NA |
| MatchBenchmarks             | &#39;Legacy.Match [int]&#39;                                              |  3.1567 ns | 0.4780 ns | 0.2122 ns |  3.1092 ns |  1.03 |    0.07 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Create [int]&#39;                                                    |  4.5910 ns | 0.5714 ns | 0.2537 ns |  4.5774 ns |  1.49 |    0.09 | 0.0019 |      24 B |          NA |
| OptionBenchmarks            | &#39;Option.Match [none]&#39;                                             |  3.6764 ns | 0.4950 ns | 0.1765 ns |  3.7436 ns |  1.20 |    0.06 |      - |         - |          NA |
| AsyncBenchmarks             | &#39;Legacy.MatchAsync [string]&#39;                                      |  4.7692 ns | 0.6322 ns | 0.2807 ns |  4.7586 ns |  1.55 |    0.09 |      - |         - |          NA |
| CreationBenchmarks          | &#39;Native.Create [string]&#39;                                          |  0.0892 ns | 0.2955 ns | 0.1312 ns |  0.0000 ns |  0.03 |    0.04 |      - |         - |          NA |
| LinqBenchmarks              | &#39;Legacy Union — Match equivalent (no LINQ support) (string case)&#39; | 22.9449 ns | 0.7131 ns | 0.3166 ns | 22.8196 ns |  7.46 |    0.22 | 0.0025 |      32 B |          NA |
| MatchBenchmarks             | &#39;Native.Match [string]&#39;                                           |  1.5690 ns | 0.1319 ns | 0.0470 ns |  1.5724 ns |  0.51 |    0.02 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Match() [string]&#39;                                                |  1.4768 ns | 0.4171 ns | 0.1488 ns |  1.4285 ns |  0.48 |    0.05 |      - |         - |          NA |
| OptionBenchmarks            | &#39;Option.ValueOrDefault [some]&#39;                                    |  2.1125 ns | 0.4179 ns | 0.1855 ns |  2.0471 ns |  0.69 |    0.06 |      - |         - |          NA |
| AsyncBenchmarks             | &#39;Legacy.MatchAsync [int]&#39;                                         | 11.6231 ns | 1.0973 ns | 0.3913 ns | 11.6379 ns |  3.78 |    0.15 | 0.0057 |      72 B |          NA |
| CreationBenchmarks          | &#39;Native.Create [int]&#39;                                             |  4.7602 ns | 0.2160 ns | 0.0770 ns |  4.7567 ns |  1.55 |    0.05 | 0.0019 |      24 B |          NA |
| LinqBenchmarks              | &#39;Legacy Union — Match equivalent (no LINQ support) (error case)&#39;  |  3.4866 ns | 1.0726 ns | 0.4762 ns |  3.2322 ns |  1.13 |    0.15 |      - |         - |          NA |
| MatchBenchmarks             | &#39;Native.Match [int]&#39;                                              |  2.4448 ns | 0.7248 ns | 0.3218 ns |  2.2731 ns |  0.79 |    0.10 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Match() [int]&#39;                                                   |  2.2725 ns | 0.1305 ns | 0.0579 ns |  2.2688 ns |  0.74 |    0.03 |      - |         - |          NA |
| OptionBenchmarks            | &#39;Option.ValueOrDefault [none]&#39;                                    |  1.5607 ns | 0.6058 ns | 0.2690 ns |  1.5029 ns |  0.51 |    0.08 |      - |         - |          NA |
| LinqBenchmarks              | &#39;Option — from x in some select x.ToUpper&#39;                        | 23.8380 ns | 1.1417 ns | 0.5069 ns | 23.8439 ns |  7.75 |    0.26 | 0.0025 |      32 B |          NA |
| NativeUnionSwitchBenchmarks | &#39;switch [string]&#39;                                                 |  0.7198 ns | 0.1285 ns | 0.0571 ns |  0.6885 ns |  0.23 |    0.02 |      - |         - |          NA |
| LinqBenchmarks              | &#39;Option — from x in none select x.ToUpper&#39;                        |  4.1444 ns | 0.7223 ns | 0.3207 ns |  4.1965 ns |  1.35 |    0.10 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;switch [int]&#39;                                                    |  1.3463 ns | 0.3076 ns | 0.1366 ns |  1.3756 ns |  0.44 |    0.04 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Legacy.Match [string]&#39;                                           |  3.1056 ns | 0.2768 ns | 0.1229 ns |  3.1283 ns |  1.01 |    0.05 |      - |         - |          NA |
| NativeUnionSwitchBenchmarks | &#39;Legacy.Match [int]&#39;                                              |  3.4623 ns | 0.6811 ns | 0.3024 ns |  3.4941 ns |  1.13 |    0.10 |      - |         - |          NA |
