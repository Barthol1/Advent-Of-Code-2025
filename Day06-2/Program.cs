// Group of numbers either added or multiplied
// Problems are seperated by spaces
// At the bottom of the problem the symbol for the operation is located
// Columns are read from right to left, numbers bottom to top
// We need to return the total of the results to the problems

// quick reminders
// A number doesn't have to begin on the first index
// Operation symbol is always located on the first index of row 5 for each column

var lines = File.ReadAllLines("input.txt").ToArray();

List<(int symbolLocation, char symbol)> parseProblems(string[] lines)
{
    List<(int symbolLocation, char symbol)> problems = [];

    // We now parse based on the location of the symbol, since it's consistent
    for (int i = 0; i < lines.Last().Length; i++)
    {
        if(lines.Last()[i] != ' ')
        {
            problems.Add((i, lines.Last()[i]));
        }
    }

    return problems;
}

var problems = parseProblems(lines);
long totalResult = 0;
for(int i = 0; i < problems.Count; i++)
{
    // Determine base result based on symbol
    long problemResult = (problems[i].symbol == '*') ? 1 : 0;

    int boundary;

    // if theres a next problem to get the location for, thats the boundary minus one to account for whitespace
    if(i < problems.Count - 1)
    {
        boundary = problems[i + 1].symbolLocation - 1;
    }
    // else the boundary is the length of the longest line
    else
    {
        boundary = lines[0].Length;
    }

    for (int j = problems[i].symbolLocation; j < boundary; j++)
    {
        string number = string.Empty;

        for(int k = 0; k < lines.Length - 1; k++)
        {
            number+=lines[k][j];
        }

        // Perform operation
        switch(problems[i].symbol)
        {
            case '+':
                problemResult+=int.Parse(number.Trim());
                break;
            case '*':
                problemResult*=int.Parse(number.Trim());
                break;
        }
    }
    totalResult+=problemResult;
}

Console.WriteLine(totalResult);