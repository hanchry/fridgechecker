using System.Text;

namespace fridgechecker.Utilities;

public static class ViewHelpers
{
    public static int GetDaysTillExpiration(DateTime? expirationDate)
    {
        var daysTillExpiration = -360;
        if (expirationDate != null)
        {
            var today = DateTime.Today.Date;
            var expiration = expirationDate.Value.Date;
            var difference = expiration - today;
            daysTillExpiration = difference.Days;
        }
        return daysTillExpiration;
    }
    
    public static string GetColorForExpiration(DateTime? expirationDate)
    {
        int daysTillExpiration = GetDaysTillExpiration(expirationDate);
        var color = "black";
        if (daysTillExpiration < 0)
        {
            color = "#ff1a05";
        }
        else if (daysTillExpiration < 3)
        {
            color = "#ff8205";
        }
        else
        {
            color = "#228c57";
        }
        return color;
    }
    
    public static string EmojiToUnicode(string emoji)
    {
        var result = string.Join("-", emoji.Select(c => ((int)c).ToString("X4")));
        return result;
    }
    public static string UnicodeToEmoji(string unicode)
    {
        string[] unicodeParts = unicode.Split('-');
        var result = new string(unicodeParts.Select(part => (char)int.Parse(part, System.Globalization.NumberStyles.HexNumber)).ToArray());
        return result;
    }
}