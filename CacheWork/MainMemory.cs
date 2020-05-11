using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CacheWork
{
    class MainMemory
    {
        string filename;
        public int CountPages,
            CountLines,
            CountElements;

        public MainMemory(string filename, int i, int j, int k)
        {
            this.filename = filename;
            CountPages = i;
            CountLines = j;
            CountElements = k;
        }

        public void RandomArray(int [,,] arr, int page, int n, int m)
        {
            //List<List<List<int>>> arr = new List<List<List<int>>>();
            Random rnd = new Random();

            for (int i = 0; i < page; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        arr[i,j,k] = (rnd.Next(1000, 9999));
                    }
                }
            }
        }

        public void writeArray(int[,,] arr, int page, int n, int m)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Unicode))
            {
                for (int i = 0; i < page; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            sw.Write(arr[i, j, k] + " ");
                        }
                        sw.Write("\n");
                    }
                    sw.Write("\n");
                }
                sw.Flush();
            }
        }

        public void readLineInArray()
        {
            //string str;
            //String[] dataFromFile;
            //using (StreamReader sw = new StreamReader(filename))
            //{
            //    while (!sw.EndOfStream)
            //    {
            //        str = sw.ReadLine();
            //        dataFromFile = str.Split(new String[] { " " },
            //            StringSplitOptions.RemoveEmptyEntries);

            //    }
            //}

        }
    }
}
