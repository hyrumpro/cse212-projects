public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
<<<<<<< HEAD
        // Step 1: Create a new array of size 'length' to store the multiples
        // Step 2: Initialize the first element with the starting number
        // Step 3: Use a loop to fill the array with multiples
        // Step 4: Return the completed array
        
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
=======
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return []; // replace this return statement with your own
>>>>>>> 6b85fbcfade0aba95c7e3800b7117b8632df44f6
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
<<<<<<< HEAD
        // Step 1: Get the portion of the list that needs to move to the front
        // Step 2: Get the portion of the list that needs to move to the back
        // Step 3: Clear the original list
        // Step 4: Add the rotated portions in the correct order
        
        int splitPoint = data.Count - amount;
        var firstPart = data.GetRange(0, splitPoint);
        var secondPart = data.GetRange(splitPoint, amount);
        
        data.Clear();
        data.AddRange(secondPart);
        data.AddRange(firstPart);
=======
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
>>>>>>> 6b85fbcfade0aba95c7e3800b7117b8632df44f6
    }
}
