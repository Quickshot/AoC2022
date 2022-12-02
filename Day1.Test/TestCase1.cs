namespace Day1.Test;

public class TestCase1
{
    [Fact]
    public void CaloriesTest()
    {
        var result = ElfCalories.Run("Test.txt");
        Assert.Equal(24000, result);
    }
    
    [Fact]
    public void Top3CaloriesTest()
    {
        var result = ElfCalories.Top3TotalCalories("Test.txt");
        Assert.Equal(45000, result);
    }
}