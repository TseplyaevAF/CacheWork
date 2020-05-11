using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheWork
{
    class Controller
    {
        public static MainMemory memory;
        public static Cache cache;
        public static int[,,] arr;
        public static int[] tags;
        bool isCache = false; // данные загружены из Кэш памяти

        public Controller(int countPages, int countLines, int countElements, string filename)
        {
            memory = new MainMemory(filename + ".txt", countPages, countLines, countElements);
            arr = new int[countPages, countLines, countElements];
            memory.RandomArray(arr, countPages, countLines, countElements);
            memory.writeArray(arr, countPages, countLines, countElements);
            cache = new Cache(countLines, countElements);
        }

        public int this [int i, int j, int k]
        {
            get
            {
                return arr[i, j, k];
            }
        }

        public int this [int i, int j]
        {
            get
            {
                return cache[i, j];
            }
        }

        public int this[int i]
        {
            get
            {
                return cache[i];
            }
        }

        public bool IsCache
        {
            get
            {
                return isCache;
            }
        }

        public int[] SearchLine(int indexPage, int indexLine, int indexItem)
        {
            int[] buf = new int[memory.CountElements];

            // если 
            if (cache.isThereATag(indexPage, indexLine))
            {
                for (int i = 0; i < memory.CountElements; i++)
                {
                    buf[i] = cache[indexLine, i];
                }
                isCache = true;
                return buf;
            }
            isCache = false;

            for (int i = 0; i < memory.CountPages; i++)
            {
                for (int j = 0; j < memory.CountLines; j++)
                {
                    if ((indexPage == i) && (indexLine == j))
                    {
                        for (int k = 0; k < memory.CountElements; k++)
                        {
                            buf[k] = arr[i, j, k];
                        }
                        break;
                    }
                }
            }

            cache[indexLine] = indexPage;
            cache.WriteLine(buf, memory.CountElements, indexLine);

            return buf;
        }
    }
}
