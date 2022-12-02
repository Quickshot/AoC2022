namespace Day2;

public static class Rps
{
    public static int PredictStrategyScore(string path)
    {
        return ParseInput(path).Score().Sum();
    }
    
    public static int PredictStrategyScoreCorrect(string path)
    {
        return ParseInputCorrect(path).Score().Sum();
    }

    private static StrategyPair[] ParseInput(string path)
    {
        var lines = File.ReadAllLines(path);
        var pairs = new List<StrategyPair>();

        foreach (var line in lines)
        {
            var trimmedLines = line.Trim();
            if (string.IsNullOrEmpty(trimmedLines))
            {
                // Skip line if empty
                continue;
            }

            var split = trimmedLines.Split(" ");
            pairs.Add(new StrategyPair(MapLetterToShape(split[0]), MapLetterToShape(split[1])));
        }

        return pairs.ToArray();
    }
    
    private static StrategyPair[] ParseInputCorrect(string path)
    {
        var lines = File.ReadAllLines(path);
        var pairs = new List<StrategyPair>();

        foreach (var line in lines)
        {
            var trimmedLines = line.Trim();
            if (string.IsNullOrEmpty(trimmedLines))
            {
                // Skip line if empty
                continue;
            }

            var split = trimmedLines.Split(" ");
            var opponentShape = MapLetterToShape(split[0]);
            var playerShape = MapConditionToShape(split[1], opponentShape);
            pairs.Add(new StrategyPair(opponentShape, playerShape));
        }

        return pairs.ToArray();
    }

    private static Shape MapLetterToShape(string letter)
    {
        switch (letter)
        {
            case "A":
            case "X":
                return Shape.Rock;
            case "B":
            case "Y":
                return Shape.Paper;
            case "C":
            case "Z":
                return Shape.Scissors;
            default:
                return Shape.Unknown;
        }
    }

    private static Shape MapConditionToShape(string letter, Shape opponentShape)
    {
        switch (opponentShape)
        {
            case Shape.Rock:
                return letter switch
                {
                    "X" => Shape.Scissors,
                    "Y" => Shape.Rock,
                    "Z" => Shape.Paper,
                    _ => Shape.Unknown
                };
            case Shape.Paper:
                return letter switch
                {
                    "X" => Shape.Rock,
                    "Y" => Shape.Paper,
                    "Z" => Shape.Scissors,
                    _ => Shape.Unknown
                };
            case Shape.Scissors:
                return letter switch
                {
                    "X" => Shape.Paper,
                    "Y" => Shape.Scissors,
                    "Z" => Shape.Rock,
                    _ => Shape.Unknown
                };
            case Shape.Unknown:
                return Shape.Unknown;
            default:
                throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null);
        }
    }

    private static IEnumerable<int> Score(this IEnumerable<StrategyPair> pairs)
    {
        foreach (var pair in pairs)
        {
            var scoreShape = ScoreShape(pair.Player);
            var scoreWin = ScoreWin(pair);
            yield return scoreShape + scoreWin;
        }
    }

    private static int ScoreShape(Shape shape)
    {
        return shape switch
        {
            Shape.Paper => 2,
            Shape.Rock => 1,
            Shape.Scissors => 3,
            Shape.Unknown => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };
    }

    private static int ScoreWin(StrategyPair pair)
    {
        switch (pair.Opponent)
        {
            case Shape.Rock:
                return pair.Player switch
                {
                    Shape.Rock => 3,
                    Shape.Paper => 6,
                    Shape.Scissors => 0,
                    Shape.Unknown => 0,
                    _ => throw new ArgumentOutOfRangeException()
                };
            case Shape.Paper:
                return pair.Player switch
                {
                    Shape.Rock => 0,
                    Shape.Paper => 3,
                    Shape.Scissors => 6,
                    Shape.Unknown => 0,
                    _ => throw new ArgumentOutOfRangeException()
                };
            case Shape.Scissors:
                return pair.Player switch
                {
                    Shape.Rock => 6,
                    Shape.Paper => 0,
                    Shape.Scissors => 3,
                    Shape.Unknown => 0,
                    _ => throw new ArgumentOutOfRangeException()
                };
            case Shape.Unknown:
                return 0;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}