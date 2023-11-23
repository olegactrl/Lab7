namespace Lab7_3_
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FunctionCache<string, int> cache = new FunctionCache<string, int>();

            FunctionCache<string, int>.FuncDelegate getStringLength = s => s.Length;

            int length1 = cache.GetOrAdd("abcd", getStringLength);
            int length2 = cache.GetOrAdd("abcdefg", getStringLength);

            Console.WriteLine($"abcd: {length1}");
            Console.WriteLine($"abcdefg: {length2}");
        }
    }
}