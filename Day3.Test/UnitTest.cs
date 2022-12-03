namespace Day3.Test;

public class UnitTest
{
    [Fact]
    public void FindCommonPriorityTest()
    {
        var score = RucksackSorter.FindCommonPriority("rucksacks.txt");
        Assert.Equal(157, score);
    }
    
    [Fact]
    public void FindGroupPriority()
    {
        var score = RucksackSorter.FindGroupPriority("rucksacks.txt");
        Assert.Equal(70, score);
    }
}