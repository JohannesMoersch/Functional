using Functional.Tests;

[assembly: RegisterXunitSerializer(typeof(TestInput.XunitSerializer), typeof(TestInput.OneEnumerable<int>), typeof(TestInput.TwoEnumerables<int, int>))]
