string[] input = File.ReadAllText("input.txt").Split(',');

long result = 0;

bool isInvalid(string x)
{
    //when duplicating the string and removing the first and last character, the resulting string should still contain the original if its a purely repeating one.
    return (x + x).IndexOf(x, 1) < x.Length;
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


