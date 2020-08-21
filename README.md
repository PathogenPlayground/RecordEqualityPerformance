# Record equality performance benchmark

This benchmark compares the performance of the overloaded `==` operator and the `Equals` method on C# 9 records.

Here's the current benchmark results from my machine as built with Roslyn 3.8.0-3.20420.3 (f2e2f2a2) and running on .NET 5 preview 7:

|         Method |       Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------- |-----------:|----------:|----------:|------:|--------:|
|  `x.Equals(x)` | 27.0569 ns | 0.2132 ns | 0.1890 ns | 84.25 |    8.87 |
|     '`x == x`' |  0.3225 ns | 0.0378 ns | 0.0354 ns |  1.00 |    0.00 |
| `x.Equals(x2)` | 26.4226 ns | 0.1043 ns | 0.0925 ns | 82.30 |    8.88 |
|    '`x == x2`' | 26.4400 ns | 0.3351 ns | 0.2616 ns | 81.22 |    9.44 |
|  `x.Equals(y)` | 10.2818 ns | 0.1136 ns | 0.1063 ns | 32.22 |    3.36 |
|     '`x == y`' |  9.7670 ns | 0.0641 ns | 0.0568 ns | 30.42 |    3.23 |

(`x2` is a record with the same values as `x`, but a different reference.)

**Legend**:

* Mean    : Arithmetic mean of all measurements
* Error   : Half of 99.9% confidence interval
* StdDev  : Standard deviation of all measurements
* Ratio   : Mean of the ratio distribution ([Current]/[Baseline])
* RatioSD : Standard deviation of the ratio distribution ([Current]/[Baseline])
* 1 ns    : 1 Nanosecond (0.000000001 sec)
