namespace DataStructures.Algorithms.Searching
{
    using System;
    using System.Collections.Generic;

    public static class Searching
    {
        public static bool SearchLinear<T>(this IEnumerable<T> collection, T element) 
            where T : IComparable
        {
            foreach (var item in collection)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
