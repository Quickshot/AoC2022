namespace Day6.Test;

public class UnitTest
{
    [Fact]
    public void FindFirstMarker1()
    {
        var result = Tuning.FindFirstMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        Assert.Equal(7, result);
    }
    
    [Fact]
    public void FindFirstMarker2()
    {
        var result = Tuning.FindFirstMarker("bvwbjplbgvbhsrlpgdmjqwftvncz");
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void FindFirstMarker3()
    {
        var result = Tuning.FindFirstMarker("nppdvjthqldpwncqszvftbrmjlhg");
        Assert.Equal(6, result);
    }
    
    [Fact]
    public void FindFirstMarker4()
    {
        var result = Tuning.FindFirstMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        Assert.Equal(10, result);
    }
    
    [Fact]
    public void FindFirstMarker5()
    {
        var result = Tuning.FindFirstMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        Assert.Equal(11, result);
    }
    
    [Fact]
    public void FindFirstMessageMarker1()
    {
        var result = Tuning.FindFirstMessageMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        Assert.Equal(19, result);
    }
    
    [Fact]
    public void FindFirstMessageMarker2()
    {
        var result = Tuning.FindFirstMessageMarker("bvwbjplbgvbhsrlpgdmjqwftvncz");
        Assert.Equal(23, result);
    }
    
    [Fact]
    public void FindFirstMessageMarker3()
    {
        var result = Tuning.FindFirstMessageMarker("nppdvjthqldpwncqszvftbrmjlhg");
        Assert.Equal(23, result);
    }
    
    [Fact]
    public void FindFirstMessageMarker4()
    {
        var result = Tuning.FindFirstMessageMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        Assert.Equal(29, result);
    }
    
    [Fact]
    public void FindFirstMessageMarker5()
    {
        var result = Tuning.FindFirstMessageMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        Assert.Equal(26, result);
    }
}