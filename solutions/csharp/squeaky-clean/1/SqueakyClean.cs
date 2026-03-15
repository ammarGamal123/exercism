using System.Text;
using System.Globalization;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
            return string.Empty;

        // Step 0: Replace control characters
        identifier = identifier.Replace("\0", "CTRL");

        StringBuilder result = new();
        bool capitalizeNext = false;

        foreach (char c in identifier)
        {
            // Task 1: replace spaces with underscore
            if (c == ' ')
            {
                result.Append('_');
                continue;
            }

            // Task 2: kebab-case -> camelCase
            if (c == '-')
            {
                capitalizeNext = true;
                continue;
            }

            // Task 5: Skip Greek lowercase letters α–ω BEFORE appending
            if (Char.GetUnicodeCategory(c) == UnicodeCategory.LowercaseLetter &&
                c >= 'α' && c <= 'ω')
            {
                continue;
            }

            // Task 4: Skip non-letter characters
            if (!char.IsLetter(c))
                continue;

            // Task 2: Apply camelCase capitalization
            if (capitalizeNext)
            {
                result.Append(char.ToUpper(c));
                capitalizeNext = false;
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}