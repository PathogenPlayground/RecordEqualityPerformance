# Record equality performance benchmark

This benchmark compares the performance of the overloaded `==` operator and the `Equals` method on C# 9 records.

Here's the current benchmark results from my machine:

|                  Method |       Mean |     Error |    StdDev |
|------------------------ |-----------:|----------:|----------:|
|        EqualsMethodSame | 27.0407 ns | 0.3633 ns | 0.3398 ns |
|      EqualsOperatorSame |  0.3419 ns | 0.0384 ns | 0.0395 ns |
|   EqualsMethodDifferent |  9.9067 ns | 0.1500 ns | 0.1403 ns |
| EqualsOperatorDifferent | 10.3294 ns | 0.0801 ns | 0.0710 ns |
