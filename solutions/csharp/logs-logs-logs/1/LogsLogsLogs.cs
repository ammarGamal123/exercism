// TODO: define the 'LogLevel' enum

     public enum LogLevel
{
    Trace = 1,  
    Debug = 2,  
    Info = 4,  
    Warning = 5,   
    Error = 6,  
    Fatal = 42,  
    Unknown = 0  
}

static class LogLine
{

    public static LogLevel ParseLogLevel(string logLine)
    {
        string level = logLine.Substring(1,3);

        switch (level)
        {
            case "INF":
                return LogLevel.Info;
            case "ERR":
                return LogLevel.Error;
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "WRN":
                return LogLevel.Warning;
            case "FTL":
                return LogLevel.Fatal;
            default :
                return LogLevel.Unknown;
                break;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}
