// Start location = S
// Beams always moves downward
// When encountering "^", the line gets split to the sides of the symbol
// Check for overlap, no more than 1 beam can exist at a given location
// All splitters are spaced evenly

// RESULT
// The amount of possible paths

char[][] input = File.ReadAllLines("input.txt").Select(s => s.ToCharArray()).ToArray();
var startLocation = Array.IndexOf(input[0], 'S');

var beams = new long[input.Length + 1, input[0].Length];
// There is only one way to the start
beams[0, Array.IndexOf(input[0], 'S')] = 1;

// Loop through the entire grid except for the last bit
for (int y = 0; y < input.Length; y+=2)
{
    for(int x = 0; x < input[y].Length; x++)
    {
        if(input[y][x] == '^')
        {
            // The beam splits
            beams[y + 2, x + 1]+=beams[y, x];
            beams[y + 2, x - 1]+=beams[y, x];
        }
        else
        {
            beams[y + 2, x]+=beams[y, x];
        }
    }
}

long finalCount = 0;
for(int i = 0; i < input[0].Length; i++)
{
    finalCount+=beams[input.Length, i];
}

Console.WriteLine(finalCount);


