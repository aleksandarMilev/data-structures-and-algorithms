namespace DataStructures.Algorithms.Shuffle
{
    using System;
    using System.Collections.Generic;

    public static class Shuffle
    {
        public static void ShuffleCollection<T>(this IList<T> collection) 
        {
            var random = new Random();

            for (int i = collection.Count - 1; i > 0; i--)
            {
                var randomIndex = random.Next(0, i + 1);
                (collection[i], collection[randomIndex]) = (collection[randomIndex], collection[i]);
            }
        }
    }
}
