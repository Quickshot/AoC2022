namespace Day6;

public static class Tuning
{
    public static int FindFirstMarker(string data)
    {
        return FindMarkers(data, 4).First();
    }
    
    public static int FindFirstMessageMarker(string data)
    {
        return FindMarkers(data, 14).First();
    }

    private static List<int> FindMarkers(string data, int markerSize)
    {
        var markers = new List<int>();
        
        for (var i = markerSize - 1; i < data.Length; i++)
        {
            var packetStart = new char[markerSize];
            for (var j = 0; j < markerSize; j++)
            {
                packetStart[j] = data[i - j];
            }

            var isUnique = packetStart.GroupBy(p => p).All(g => g.Count() == 1);
            if (isUnique)
            {
                markers.Add(i+1);
            }
        }

        return markers;
    }
}