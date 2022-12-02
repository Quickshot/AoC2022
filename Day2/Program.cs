// See https://aka.ms/new-console-template for more information

using Day2;

Console.WriteLine("Day 2: Rock Paper Scissors");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
}

var score = Rps.PredictStrategyScore("strategy.txt");

Console.WriteLine($"Total score for the faulty strategy approach is {score}");

score = Rps.PredictStrategyScoreCorrect("strategy.txt");

Console.WriteLine($"Correct score is {score}");