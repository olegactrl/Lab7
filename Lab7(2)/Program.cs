using System;

namespace Lab7_2_
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Repository<string> stringRepository = new Repository<string>();
            stringRepository.Add("ab");
            stringRepository.Add("bc");
            stringRepository.Add("cd");
            stringRepository.Add("de");
            stringRepository.Add("ef");

            Repository<string>.Criteria<string> startsWithACriteria = s => s.StartsWith("c");

            List<string> resultStrings = stringRepository.Find(startsWithACriteria);

            Console.WriteLine("Strings starting with 'c':");
            foreach (string str in resultStrings)
            {
                Console.WriteLine(str);
            }
        }
    }
}