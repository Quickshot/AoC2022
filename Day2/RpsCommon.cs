namespace Day2;

public record StrategyPair(Shape Opponent, Shape Player);

public enum Shape {Rock, Paper, Scissors, Unknown}