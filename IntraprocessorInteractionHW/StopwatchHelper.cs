﻿using System.Diagnostics;

namespace IntraprocessorInteractionHW;

public class StopwatchHelper
{
    private readonly Stopwatch _stopwatch;

    public StopwatchHelper()
    {
        _stopwatch = new Stopwatch();
    }

    public void MeasureAndLog(Action action, string description)
    {
        Console.WriteLine($"Начинаю измерение времени для: {description}");
        _stopwatch.Reset();
        _stopwatch.Start();

        action.Invoke();

        _stopwatch.Stop();

        Console.WriteLine($"Время выполнения {description}: {GetElapsedTimeFormatted()} ({GetElapsedTimeMilliseconds()} мс)");
    }

    private long GetElapsedTimeMilliseconds()
    {
        return _stopwatch.ElapsedMilliseconds;
    }

    private string GetElapsedTimeFormatted()
    {
        return string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            _stopwatch.Elapsed.Hours,
            _stopwatch.Elapsed.Minutes,
            _stopwatch.Elapsed.Seconds,
            _stopwatch.Elapsed.Milliseconds);
    }
}
