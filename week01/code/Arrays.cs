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
        // PLAN:
        // 1. Create a new array to store our multiples
        //    - Size will be equal to the 'length' parameter
        //    - Will store double values since input is double
        //
        // 2. Fill the array with multiples:
        //    - First position (index 0) will be 1 * number
        //    - Second position (index 1) will be 2 * number
        //    - Continue pattern until array is filled
        //    - Use a loop where i goes from 0 to length-1
        //    - Each element will be number * (i + 1)
        //
        // 3. Return the completed array
        
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Calculate the split point:
        //    - Split point will be (data.Count - amount)
        //    - This tells us where to divide the list
        //    - Example: list of 9 items, rotating 3 positions
        //      Split point would be 6 (9-3)
        //
        // 2. Split the list into two parts:
        //    - First part: from index 0 to split point
        //    - Second part: from split point to end
        //    - Use GetRange() to extract these portions
        //
        // 3. Reconstruct the rotated list:
        //    - Clear the original list
        //    - Add the second part first (becomes the front)
        //    - Add the first part second (becomes the back)
        //    - Use AddRange() to efficiently add multiple items
        
        int splitPoint = data.Count - amount;
        var firstPart = data.GetRange(0, splitPoint);
        var secondPart = data.GetRange(splitPoint, amount);
        
        data.Clear();
        data.AddRange(secondPart);
        data.AddRange(firstPart);
    }
}
