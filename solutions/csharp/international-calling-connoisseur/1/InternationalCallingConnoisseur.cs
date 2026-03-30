using System.Net.Mail;

public static class DialingCodes
{
    private static Dictionary<int, string> mp = new();
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return mp = new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        mp = new Dictionary<int, string>
        {
              {1, "United States of America"},
              {55, "Brazil"},
              {91, "India"}
        };

        return mp;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        mp = new Dictionary<int, string>
        {
            {countryCode, countryName}
        };

        return mp;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);

        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
            return existingDictionary[countryCode];
        else 
            return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
            existingDictionary[countryCode] = countryName;

            
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string lngName = string.Empty;
        foreach(var country in existingDictionary) {
            // lngName = Math.Max(country, lngName);
            if (country.Value.Length >= lngName.Length)
                lngName = country.Value;
        }
        return lngName;
    }
}