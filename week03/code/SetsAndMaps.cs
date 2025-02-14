using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>(words.Length, StringComparer.Ordinal);
        var pairs = new HashSet<string>(StringComparer.Ordinal);

        foreach (var word in words)
        {
            if (word.Length != 2) continue;

            var reversed = $"{word[1]}{word[0]}";
            if (seen.Contains(reversed) && word != reversed)
            {
                var orderedPair = string.Compare(word, reversed, StringComparison.Ordinal) < 0 
                    ? $"{word} & {reversed}" 
                    : $"{reversed} & {word}";
                pairs.Add(orderedPair);
            }
            seen.Add(word);
        }

        return pairs.OrderBy(p => p, StringComparer.Ordinal).ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();
            if (degree.Length > 0)
            {
                degrees[degree] = degrees.TryGetValue(degree, out int count) ? count + 1 : 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null) return false;

        ReadOnlySpan<char> span1 = word1.AsSpan();
        ReadOnlySpan<char> span2 = word2.AsSpan();
        
        Span<int> counts = stackalloc int[26];
        int lettersProcessed = 0;

        // Process first string directly with bitwise operations
        foreach (char c in span1)
        {
            if ((uint)((c | 0x20) - 'a') <= (uint)('z' - 'a'))
            {
                counts[(c | 0x20) - 'a']++;
                lettersProcessed++;
            }
        }

        // Process second string with same optimizations
        foreach (char c in span2)
        {
            if ((uint)((c | 0x20) - 'a') <= (uint)('z' - 'a'))
            {
                int idx = (c | 0x20) - 'a';
                if (--counts[idx] < 0) return false;
                lettersProcessed--;
            }
        }

        return lettersProcessed == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        try
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            
            var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            
            using var jsonStream = response.Content.ReadAsStream();
            var options = new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true 
            };

            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);
            
            return featureCollection?.Features?
                .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray() ?? Array.Empty<string>();
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }
}
