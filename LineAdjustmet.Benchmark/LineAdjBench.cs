using BenchmarkDotNet.Attributes;
using LineAdjustment;

namespace LineAdjustmet.Benchmark;

[MemoryDiagnoser]
public class LineAdjBench
{
    private string s = string.Concat(
        Enumerable.Repeat(
            "Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua ",
            1000000));
    [Benchmark]
    public void TestWithConcat()
    {
        var algorithm = new LineAdjustmentAlgorithm();
        var output = algorithm.Transform(s, 12);
    }
    
    [Benchmark]
    public void TestWithStringBuilder()
    {
        var algorithm = new LineAdjustmentAlgorithmStringBuilder(new AddSpacesAlgorithm());
        var output = algorithm.Transform(s, 12);
    }
}