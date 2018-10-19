using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxValue
{
    public enum NumberType
    {
        Even = 0,
        Odd = 1
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string value = maxValue.Properties.Resources.inputFile.Replace("\r\n", ",");
                var lines = value.Split(',');
                int level = 0;
                Operations op = new Operations();
                PrintReuslt(op.FindThebiggestPath(level, lines));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Helper functiton to preint a comma separated string from a list 
        /// </summary>
        /// <param name="result"></param>
        public static void PrintReuslt(List<int> result) {
            try
            {
                if (result != null)
                {
                    Console.WriteLine(string.Format("Max Sum :{0}",result.Sum().ToString()));
                    Console.Write("Path :");
                    for (int i = 0; i < result.Count; i++)
                    {
                        Console.Write(result[i].ToString());
                        if (i!= result.Count-1)
                            Console.Write(",");
                    }
                    Console.ReadKey();
                }
                else 
                    throw new Exception("No valid path available!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
