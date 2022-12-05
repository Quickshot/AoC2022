using System.Text.RegularExpressions;

namespace Day5;

public static partial class Stacks
{
    public static string PlayInstructions(string path)
    {
        var lines = File.ReadLines(path);
        var stateAndInstructions = File.ReadLines(path).SplitInput();
        var state = CreateInitialState(stateAndInstructions[0]);
        var instructions = stateAndInstructions[1].Select(i => ParseInstruction(i)).ToArray();
        var endState = RunInstructions(state, instructions);
        return PrintState(endState);
    }
    
    public static string PlayInstructionsOrdered(string path)
    {
        var lines = File.ReadLines(path);
        var stateAndInstructions = File.ReadLines(path).SplitInput();
        var state = CreateInitialState(stateAndInstructions[0]);
        var instructions = stateAndInstructions[1].Select(i => ParseInstruction(i)).ToArray();
        var endState = RunInstructionsOrdered(state, instructions);
        return PrintState(endState);
    }

    private static string PrintState(CrateState endState)
    {
        var result = "";
        foreach (var stack in endState.Stacks)
        {
            if (stack.Count != 0)
            {
                result += stack.Peek();
            }
            else
            {
                result += " ";
            }
        }

        return result;
    }

    private static CrateState RunInstructions(CrateState state, CrateInstruction[] instructions)
    {
        var currentState = state;
        foreach (var instruction in instructions)
        {
            var stacks = currentState.Stacks;
            for (var i = 0; i < instruction.amount; i++)
            {
                var crate = stacks[instruction.from].Pop();
                stacks[instruction.to].Push(crate);
            }

            currentState = new CrateState(stacks);
        }

        return currentState;
    }
    
    private static CrateState RunInstructionsOrdered(CrateState state, CrateInstruction[] instructions)
    {
        var currentState = state;
        foreach (var instruction in instructions)
        {
            var stacks = currentState.Stacks;
            var tmp = "";
            for (var i = 0; i < instruction.amount; i++)
            {
                tmp += stacks[instruction.from].Pop();
            }

            var tmpReversed = tmp.Reverse();

            foreach (var ch in tmpReversed)
            {
                stacks[instruction.to].Push(ch);
            }

            currentState = new CrateState(stacks);
        }

        return currentState;
    }

    private static string[][] SplitInput(this IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var splitIndex = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i].Trim()))
            {
                // Found the splitting row between start state and instructions
                splitIndex = i;
                break;
            }
        }

        var startState = lines[..splitIndex];
        var instructions = lines[(splitIndex + 1)..];
        var results = new string[2][];
        results[0] = startState;
        results[1] = instructions;
        return results;
    }

    private static CrateState CreateInitialState(string[] input)
    {
        // Find the number of stacks
        var maxStacks = int.Parse(input.Last().Trim().Last().ToString());
        var stacks = new Stack<char>[maxStacks];
        for (var i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<char>();
        }
        
        // Parse lines in reverse order without the last line
        var lines = input[..^1].Reverse().ToArray();
        foreach (var line in lines)
        {
            var crateOpeningIndexes = line.AllIndexesOf("[").ToArray();
            var positions = GetCratePositions(crateOpeningIndexes);
            var crateNames = GetCrateNames(crateOpeningIndexes, line);
            for (var i = 0; i < positions.Length; i++)
            {
                stacks[positions[i]].Push(crateNames[i]);
            }
        }

        return new CrateState(stacks);
    }

    private static int[] GetCratePositions(int[] indexes)
    {
        var positions = new int[indexes.Length];
        for (var i = 0; i < indexes.Length; i++)
        {
            var pos = indexes[i] / 4;
            positions[i] = pos;
        }

        return positions;
    }

    private static char[] GetCrateNames(int[] indexes, string line)
    {
        var crates = new char[indexes.Length];
        for (var i = 0; i < indexes.Length; i++)
        {
            var crate = line[indexes[i]+1];
            crates[i] = crate;
        }

        return crates;
    }

    private static CrateInstruction ParseInstruction(string line)
    {
        var regex = ParseInstructionRegex();
        var matches = regex.Match(line);
        var amount = int.Parse(matches.Groups["amount"].Value);
        var from = int.Parse(matches.Groups["from"].Value) - 1;
        var to = int.Parse(matches.Groups["to"].Value) - 1;
        return new CrateInstruction(from, to, amount);
    }
    
    private static IEnumerable<int> AllIndexesOf(this string str, string searchString)
    {
        var minIndex = str.IndexOf(searchString);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchString, minIndex + searchString.Length);
        }
    }

    [GeneratedRegex("move\\s+(?<amount>\\d+)\\s+from\\s+(?<from>\\d+)\\s+to\\s+(?<to>\\d+)", RegexOptions.Compiled)]
    private static partial Regex ParseInstructionRegex();
}