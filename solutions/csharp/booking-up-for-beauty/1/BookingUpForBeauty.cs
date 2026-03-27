static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime.TryParse(appointmentDateDescription, out DateTime parsedDateTime);
        // Console.WriteLine("****************\n" + parsedDateTime + "\n**************\n");
        var dateTime = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, parsedDateTime.Hour, parsedDateTime.Minute, parsedDateTime.Second);

        return dateTime;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate <= DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        string description = $"You have an appointment on {appointmentDate.GetDateTimeFormats('G')[0]}.";

        return description;
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(year:DateTime.Now.Year, month: 9, day:15, hour:0, minute:0, second:0);
    }
}
