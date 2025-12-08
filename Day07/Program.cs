// Start location = S
// Beams always moves downward
// When encountering "^", the line gets split to the sides of the symbol
// Check for overlap, no more than 1 beam can exist at a given location

// RESULT
// Count of the amount of times the beam has been split

char[][] input = File.ReadAllLines("input.txt").Select(s => s.ToCharArray()).ToArray();
var startLocation = Array.IndexOf(input[0], 'S');

// First beam can already be initialized under start
var beams = new HashSet<int>() { startLocation };
int splitterCount = 0;
for (int i = 0; i < input.Length; i++)
{
    for(int j = 0; j < input[i].Length; j++)
    {
        if(input[i][j] == '^' && beams.Contains(j))
        {
            beams.Remove(j);
            beams.Add(j + 1);
            beams.Add(j - 1);
            splitterCount+=1;
        }
    }
}

Console.WriteLine(splitterCount);


