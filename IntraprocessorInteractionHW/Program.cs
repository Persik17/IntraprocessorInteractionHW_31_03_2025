using IntraprocessorInteractionHW;

var arrayLengths = new List<int>() { 100000, 1000000, 10000000 };
StopwatchHelper _stopwatchHelper = new();

foreach (var length in arrayLengths)
{
    ArrayBuilder builder = new(length: length, minValue: 5000, maxValue: 10000);
    int[] generatedArray = builder.GenerateIntArray();

    _stopwatchHelper.MeasureAndLog(() =>
    {
        try
        {
            var arraySum = generatedArray.GetIntArraySum();
            Console.WriteLine($"arraySum - {arraySum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке arraySum: {ex.Message}");
        }
    }, "GetIntArraySum");
    Console.WriteLine();

    _stopwatchHelper.MeasureAndLog(() =>
    {
        try
        {
            var arraySum = generatedArray.GetIntArraySumThread();
            Console.WriteLine($"arraySum - {arraySum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке arraySum: {ex.Message}");
        }
    }, "GetIntArraySumThread");
    Console.WriteLine();

    _stopwatchHelper.MeasureAndLog(() =>
    {
        try
        {
            var arraySum = generatedArray.GetIntArraySumParallelLINQ();
            Console.WriteLine($"arraySum - {arraySum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке arraySum: {ex.Message}");
        }
    }, "GetIntArraySumParallelLINQ");
    Console.WriteLine("----------------------------------------------------");
}

Console.ReadLine();
