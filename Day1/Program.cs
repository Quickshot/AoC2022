// See https://aka.ms/new-console-template for more information

using Day1;

Console.WriteLine("Running elf calorie counting");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
}

var calories = ElfCalories.Run(args[0]);

Console.WriteLine($"Elf with the largest amount of calories has {calories} calories");

calories = ElfCalories.Top3TotalCalories(args[0]);

Console.WriteLine($"Top 3 elves are carrying total of {calories} calories");