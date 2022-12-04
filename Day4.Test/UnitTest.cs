namespace Day4.Test;

public class UnitTest
{
    [Fact]
    public void AssignmentFullyContainsTest()
    {
        var result = Cleanup.AssignmentFullyContains("assignment.txt");
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void AssignmentOverlapsTest()
    {
        var result = Cleanup.AssignmentOverlaps("assignment.txt");
        Assert.Equal(4, result);
    }
}