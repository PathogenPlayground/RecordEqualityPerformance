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
    public readonly FatRecord X = new();
    /// <summary>Same reference and value as <see cref="X"/></summary>
    /// <remarks>This doesn't really need to be separate, it's really only here to suppress the warning you get when comparing a reference to its self.</remarks>
    public readonly FatRecord AlsoX;
    public readonly FatRecord Y = new();
    /// <summary>Same value as <see cref="X"/>, but different reference</summary>
    public readonly FatRecord X2;

    public Benchmark()
    {
        AlsoX = X;

        // Clone X withoutout changing anything
        X2 = X with { G = X.G };

        if (ReferenceEquals(X, X2))
        { throw new InvalidOperationException(); }
    }

    [Benchmark(Description = "`x.Equals(x)`")]
    public bool EqualsMethodSame() => X.Equals(AlsoX);

    [Benchmark(Description = "`x == x`", Baseline = true)]
    public bool EqualsOperatorSame() => X == AlsoX;

    [Benchmark(Description = "`x.Equals(x2)`")]
    public bool EqualsMethodEquivalent() => X.Equals(X2);

    [Benchmark(Description = "`x == x2`")]
    public bool EqualsOperatorEquivalent() => X == X2;

    [Benchmark(Description = "`x.Equals(y)`")]
    public bool EqualsMethodDifferent() => X.Equals(Y);

    [Benchmark(Description = "`x == y`")]
    public bool EqualsOperatorDifferent() => X == Y;
}
