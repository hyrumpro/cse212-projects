public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // Create a HashSet to store seen characters
        var seen = new HashSet<char>();
        
        // Iterate through each character in the text
        foreach (char c in text) {
            // If the character is already in the set, we found a duplicate
            if (!seen.Add(c)) {
                return false;
            }
        }
        
        // If we made it through the loop, all characters are unique
        return true;
    }
}
