// Group of numbers either added or multiplied
// Problems are seperated by spaces
// At the bottom of the problem the symbol for the operation is located
// We need to return the total of the results to the problems

// quick reminders
// A number doesn't have to begin on the first index
// Operation symbol is always located on the first index of row 5 for each column

var lines = File.ReadLines("input.txt").ToArray();

string[][] parseProblems(string[] lines)
{
    int columnCount = lines.First().Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length;
    string[][] problems = new string[columnCount][];

    // Initialize all column arrays
    for (int i = 0; i < columnCount; i++)
    {
        problems[i] = Array.Empty<string>();
    }

    foreach(var line in lines)
    {
        // get each value for a row
        var row = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        for (int i = 0; i < row.Length; i++)
        {
            problems[i] = problems[i].Append(row[i]).ToArray();
        }
    }

    return problems;
}

var problems = parseProblems(lines);
long totalResult = 0;
foreach(var problem in problems)
{
    // Last value is always the symbol
    var symbol = problem.Last();

    // Determine base result based on symbol
    long problemResult = (symbol == "*") ? 1 : 0;

    for (int i = 0; i < problem.Length - 1; i++)
    {
        // Perform operation
        switch(symbol)
        {
            case "+":
                problemResult+=int.Parse(problem[i]);
                break;
            case "*":
                problemResult*=int.Parse(problem[i]);
                break;
        }
    }
    totalResult+=problemResult;
}

Console.WriteLine(totalResult);