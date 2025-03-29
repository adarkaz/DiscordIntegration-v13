namespace DiscordIntegration.Bot.Services;

using Discord;

public class Log
{
    public static Task Send(ushort port, LogMessage msg, bool skipLog = false)
    {
        Console.WriteLine($"{DateTime.Now.Date.ToString("MM/dd/yyyy")} {msg}");

        return Task.CompletedTask;
    }

    public static void Info(ushort port, string source, object msg, bool skipLog = false) =>
        Send(port, new LogMessage(LogSeverity.Info, source, $"[INFO] {msg}"), skipLog);

    public static void Debug(ushort port, string source, object msg, bool skipLog = false)
    {
        if (Program.Config.Debug)
            Send(port, new LogMessage(LogSeverity.Debug, source, $"[DEBUG] {msg}"), skipLog);
    }
        
    public static void Error(ushort port, string source, object msg, bool skipLog = false) =>
        Send(port, new LogMessage(LogSeverity.Error, source, $"[ERROR] {msg}"), skipLog);

    public static void Warn(ushort port, string source, object msg, bool skipLog = false) =>
        Send(port, new LogMessage(LogSeverity.Warning, source, $"[WARN] {msg}"), skipLog);
}