namespace IntraprocessorInteractionHW
{
    public class ArrayBuilder
    {
        private readonly int _length;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly Random _random;

        public ArrayBuilder(int length, int minValue, int maxValue)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
            }

            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "Min value cannot be greater than max value.");
            }

            _length = length;
            _minValue = minValue;
            _maxValue = maxValue;
            _random = new Random();
        }

        public int[] GenerateIntArray()
        {
            int[] array = new int[_length];

            for (int i = 0; i < _length; i++)
            {
                array[i] = _random.Next(_minValue, _maxValue);
            }

            return array;
        }
    }
}
