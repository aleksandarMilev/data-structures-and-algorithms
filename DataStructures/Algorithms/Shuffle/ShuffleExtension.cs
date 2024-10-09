namespace DataStructures.Algorithms.Shuffle
{
    public static class ShuffleExtension
    {
        public static void Shuffle(this int[] arr) 
        {
            var random = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                var randomIndex = random.Next(0, i + 1);
                (arr[i], arr[randomIndex]) = (arr[randomIndex], arr[i]);
            }
        }
    }
}
