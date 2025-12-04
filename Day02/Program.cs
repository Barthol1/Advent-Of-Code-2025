string[] input = File.ReadAllText("input.txt").Split(',');

long result = 0;

bool isInvalid(string x)
{
    // The string needs to be dividable by 2 since we need to compare 2 halves
    if(x.Length % 2 != 0) return false;

    // Check if the first half equals the second
    return x[0..(x.Length / 2)] == x[(x.Length / 2)..x.Length];
}
foreach(string i in input)
{
    string a = i.Split('-').First();
    string b = i.Split('-').Last();

    for (long j = long.Parse(a); j < long.Parse(b); j++)
    {
        string x = j.ToString();
        if(isInvalid(x))
        {
            result += j;
        }
    }
}

Console.WriteLine(result);



