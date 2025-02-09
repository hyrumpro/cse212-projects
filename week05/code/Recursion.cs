using System.Collections;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, 
                letters.Remove(i, 1), 
                size, 
                word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();
        
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;
        
        if (remember.TryGetValue(s, out decimal cached))
            return cached;
            
        remember[s] = CountWaysToClimb(s - 1, remember) + 
                     CountWaysToClimb(s - 2, remember) + 
                     CountWaysToClimb(s - 3, remember);
                     
        return remember[s];
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        int index = pattern.IndexOf('*');
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        currPath ??= new List<ValueTuple<int, int>>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        currPath.RemoveAt(currPath.Count - 1);
    }
}

