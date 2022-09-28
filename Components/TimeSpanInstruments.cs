using System;

namespace ToDoList.Components
{
    public static class TimeSpanInstruments
    {
        public static string ConverteTimeSpanToClockStringFormat(TimeSpan time)
        {
            string minutes = (time.Minutes.ToString().Length == 1) ? "0" + time.Minutes.ToString() : time.Minutes.ToString();
            string seconds = (time.Seconds.ToString().Length == 1) ? "0" + time.Seconds.ToString() : time.Seconds.ToString();

            return $"{minutes}:{seconds}";
        }
    }
}
