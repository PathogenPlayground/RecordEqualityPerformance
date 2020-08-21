using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmark>();

public record FatRecord
{
    public Guid A = Guid.NewGuid();
    public Guid B = Guid.NewGuid();
    public Guid C = Guid.NewGuid();
    public Guid D = Guid.NewGuid();
    public Guid E = Guid.NewGuid();
    public Guid F = Guid.NewGuid();
    public Guid G = Guid.NewGuid();
}

public class Benchmark
{
    public readonly FatRecord A = new();
    public readonly FatRecord AlsoA;
    public readonly FatRecord B = new();

    public Benchmark()
        => AlsoA = A;

    [Benchmark]
    public bool EqualsMethodSame() => A.Equals(AlsoA);

    [Benchmark]
    public bool EqualsOperatorSame() => A == AlsoA;

    [Benchmark]
    public bool EqualsMethodDifferent() => A.Equals(B);

    [Benchmark]
    public bool EqualsOperatorDifferent() => A == B;
}
