namespace Day2.Test;

public class UnitTest
{
    [Fact]
    public void PredictStrategyScoreTest()
    {
        var score = Rps.PredictStrategyScore("strategy.txt");
        Assert.Equal(15, score);
    }
    
    [Fact]
    public void PredictStrategyScoreCorrectTest()
    {
        var score = Rps.PredictStrategyScoreCorrect("strategy.txt");
        Assert.Equal(12, score);
    }
}