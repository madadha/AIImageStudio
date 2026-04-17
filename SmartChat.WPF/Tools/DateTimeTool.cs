using System;

namespace SmartChat.WPF.Tools
{
    public static class DateTimeTool
    {
        public static string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}