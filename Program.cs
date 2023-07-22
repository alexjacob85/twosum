using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApptwosum
{
    internal class Program
    {
        public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
        {
            int first_i = 0, global_sum = 0, second_i = 1;

            if (list.Count == 0 || sum == 0)
            {
                return null;
            }
            ArrayList arlist = new ArrayList();

            for (int i = first_i; i < list.Count; i++)
            {
                for (int j = second_i; j < list.Count; j++)
                {
                    if (i != list.Count)
                    {
                        global_sum += list[i] + list[j];

                        if (global_sum == sum)
                        {
                            var tuple1 = Tuple.Create(i, j);
                            return tuple1;
                        }
                        global_sum = 0;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            return null;

            throw new NotImplementedException("Waiting to be implemented.");
        }

        public static Tuple<int, int> FindTwoSums(IList<int> list, int sum)
        {
            var result = from n1 in list
                         from n2 in list
                         where n1 + n2 == sum
                         select new Tuple<int, int>(list.IndexOf(n1), list.IndexOf(n2));
            return result.FirstOrDefault();
        }

        public static Tuple<int, int> FindTwoSumhash(IList<int> list, int sum)
        {
           HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                var needed = sum - list[i];
                if (hs.Contains(needed))
                {
                    return Tuple.Create(list.IndexOf(needed), i);
                }
                hs.Add(list[i]);
            }
            return null;
        }

        static void Main(string[] args)
        {

            Tuple<int, int> indices = FindTwoSumhash(new List<int>() { 4, 1, 5, 2, 5, 9,4}, 10);
            if (indices != null)
            {
                Console.WriteLine(indices.Item1 + " " + indices.Item2);
                Console.ReadLine();
            }
        }
    }
}
