// See https://aka.ms/new-console-template for more information

using Day3;

Console.WriteLine("Day 3: Rucksack Reorganization");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
}

var score = RucksackSorter.FindCommonPriority(args[0]);

Console.WriteLine($"Sum of item priorities is {score}");

score = RucksackSorter.FindGroupPriority(args[0]);

Console.WriteLine($"Sum of group priorities is {score}");