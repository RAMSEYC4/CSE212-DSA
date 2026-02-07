using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base Case: If n <= 0, return 0
        if (n <= 0)
            return 0;
        
        // Recursive Case: n^2 + sum of all previous squares
        // Example: SumSquares(3) = 3^2 + SumSquares(2)
        //                        = 9 + (2^2 + SumSquares(1))
        //                        = 9 + (4 + (1^2 + SumSquares(0)))
        //                        = 9 + 4 + 1 + 0 = 14
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base Case: If we've built a word of the desired size, add it to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        // Recursive Case: Try adding each letter to the current word
        // Loop through all available letters
        for (int i = 0; i < letters.Length; i++)
        {
            // Pick the current letter
            char currentLetter = letters[i];
            
            // Create a new string with remaining letters (all except the one we just picked)
            string remainingLetters = letters.Remove(i, 1);
            
            // Recursively build the rest of the word with remaining letters
            // Add current letter to word and reduce size by 1
            PermutationsChoose(results, remainingLetters, size, word + currentLetter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize the memoization dictionary if it's the first call
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // MEMOIZATION: Check if we've already calculated this value
        // This prevents recalculating the same values millions of times
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Recursive Case: Calculate the number of ways
        // Ways to reach step s = ways to reach (s-1) + ways to reach (s-2) + ways to reach (s-3)
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
        
        // MEMOIZATION: Save the calculated value so we don't calculate it again
        remember[s] = ways;
        
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base Case: If there are no wildcards (*), add the pattern to results
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }
        
        // Find the index of the first wildcard
        int wildcardIndex = pattern.IndexOf('*');
        
        // Recursive Case: Replace the wildcard with '0' and '1' separately
        
        // Create a new pattern with '0' replacing the first '*'
        // pattern[..wildcardIndex] gets everything before the *
        // pattern[(wildcardIndex + 1)..] gets everything after the *
        string patternWith0 = pattern[..wildcardIndex] + '0' + pattern[(wildcardIndex + 1)..];
        
        // Create a new pattern with '1' replacing the first '*'
        string patternWith1 = pattern[..wildcardIndex] + '1' + pattern[(wildcardIndex + 1)..];
        
        // Recursively process both new patterns
        // This will continue until all wildcards are replaced
        WildcardBinary(patternWith0, results);
        WildcardBinary(patternWith1, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // Add current position to the path
        currPath.Add((x, y));
        
        // Base Case: Check if we've reached the end
        if (maze.IsEnd(x, y))
        {
            // We found a complete path! Add it to results
            results.Add(currPath.AsString());
            // Remove current position before returning (backtrack)
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        // Recursive Case: Try moving in all 4 directions
        // The order doesn't matter, but let's go: right, down, left, up
        
        // Try moving RIGHT (x+1, y)
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath);
        }
        
        // Try moving DOWN (x, y+1)
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath);
        }
        
        // Try moving LEFT (x-1, y)
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath);
        }
        
        // Try moving UP (x, y-1)
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath);
        }
        
        // BACKTRACKING: Remove current position from path
        // This allows other paths to use this square
        // Without this, we'd only find one path (if any)
        currPath.RemoveAt(currPath.Count - 1);
    }
}