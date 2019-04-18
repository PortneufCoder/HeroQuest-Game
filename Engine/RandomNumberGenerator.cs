using System;

namespace Engine
{
    public class RandomNumberGenerator
    {
        private static readonly Random _simpleGenerator = new Random();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1); // + 1 because the maximumvalue will not be whole.
        }
    }
}
