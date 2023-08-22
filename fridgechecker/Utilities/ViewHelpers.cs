namespace fridgechecker.Utilities;

public static class ViewHelpers
{
    public static int GetDaysTillExpiration(DateTime? expirationDate)
    {
        var daysTillExpiration = -360;
        if (expirationDate != null)
        {
            var today = DateTime.Today;
            var expiration = expirationDate.Value;
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
}