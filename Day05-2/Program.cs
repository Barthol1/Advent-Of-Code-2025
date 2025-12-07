// We want to know how many fresh ID's are available
// An ID is fresh if it is contained in any range
// The ranges are inclusive

var input = File.ReadAllLines("input.txt").ToArray();
int seperatorIndex = Array.IndexOf(input, "");

var ranges = input.Take(seperatorIndex).ToArray();

// Convert the ranges to start/end objects
List<(long start, long end)> rangeList = [];
foreach (var range in ranges)
{
    rangeList.Add((long.Parse(range.Split('-')[0]), long.Parse(range.Split('-')[1])));
}

// Sort them by ascending start value
rangeList = rangeList.OrderBy(s => s.start).ToList();

// Take the first interval as current
// Loop through each interval, if the current end is bigger than the next start, than the next end = current end
// The base range at the end of this loop should be all fresh ID's

long totalCount = 0;
var currentInterval = rangeList[0];

for (int i = 1; i < rangeList.Count; i++)
{
    var next = rangeList[i];

    // If the current current end is bigger or equal to next start, merge the next end into the current
    if(currentInterval.end >= next.start)
    {
        currentInterval.end = Math.Max(currentInterval.end, next.end);
    } 

    // Else move on to the next range and append the amount of possible id's to the result
    else 
    {
        // add 1 to the end since the ranges are inclusive
        totalCount += currentInterval.end + 1 - currentInterval.start;
        currentInterval = next;
    }
}

//Add last range
totalCount += currentInterval.end + 1 - currentInterval.start;
Console.WriteLine(totalCount);