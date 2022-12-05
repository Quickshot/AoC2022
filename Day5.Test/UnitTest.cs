namespace Day5.Test;

public class UnitTest1
{
    [Fact]
    public void PlayInstructionsTest()
    {
        var result = Stacks.PlayInstructions("instructions.txt");
        Assert.Equal("CMZ", result);
    }
    
    [Fact]
    public void PlayInstructionsTestOrdered()
    {
        var result = Stacks.PlayInstructionsOrdered("instructions.txt");
        Assert.Equal("MCD", result);
    }
}