namespace IntraprocessorInteractionHW
{
    public static class ArrayExtension
    {
        public static int GetIntArraySum(this int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int GetIntArraySumThread(this int[] array)
        {
            int sum = 0;

            int processorCount = Environment.ProcessorCount;
            var aaraySizeInThread= array.Length / processorCount;
            Task[] tasks = new Task[processorCount];

            for (int iThread = 0; iThread < processorCount; iThread++)
            {
                var localThread = iThread;
                tasks[localThread] = Task.Run(() =>
                {
                    for (int j = localThread * aaraySizeInThread; j < (localThread + 1) * aaraySizeInThread; j++)
                    {
                        Interlocked.Add(ref sum, array[j]);
                    }
                });
            }

            Task.WaitAll(tasks);
            return sum;
        }

        public static int GetIntArraySumParallelLINQ(this int[] array)
        {
            int sum = 0;

            int processorCount = Environment.ProcessorCount;
            var aaraySizeInThread = array.Length / processorCount;
            int[] partialSums = new int[processorCount];

            Parallel.For(0, processorCount, (counter) =>
            {
                int sum = 0;
                for (int i = counter * aaraySizeInThread; i < (counter + 1) * aaraySizeInThread; i++)
                    sum += array[i];
                partialSums[counter] = sum;
            });

            foreach (var partSum in partialSums)
                sum += partSum;

            return sum;
        }
    }
}
