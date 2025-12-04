using System.Text;

var lines = File.ReadLines("input.txt");

long getHighestNumbers(string a, int k = 12)
{
    return long.Parse(getHighestNumbersRecursive(a, k));
}

string getHighestNumbersRecursive(string a, int k)
{    
    if (k == 0)
        return "";
    
    //if k is equal to the amount of characters, we must return it since all would be included anyway
    if (a.Length == k)
        return a;


    // We need k digits as a minimal, therefor we need to limit the search window
    int searchEnd = a.Length - k; 

    char best = '0';
    int bestIndex = 0;

    for (int i = 0; i <= searchEnd; i++)
    {
        if (a[i] > best)
        {
            best = a[i];
            bestIndex = i;

            // 9 is the highest anyway
            if (best == '9') 
                break;
        }
    }

    // We include the highest digit and recurse further
    return best + getHighestNumbersRecursive(a[(bestIndex + 1)..], k - 1);
}

long result = 0;
foreach (var line in lines)
{
    result+=getHighestNumbers(line);
}

Console.WriteLine(result);