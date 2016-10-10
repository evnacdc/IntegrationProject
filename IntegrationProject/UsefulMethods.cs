using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class UsefulMethods
    {

        private static Random r = new Random(System.DateTime.Now.Second);

        public static void InitUsefulMethods()
        {
            r = new Random(System.DateTime.Now.Second);
        }

        public static String GetRandomString(String[] arr)
        {
            return arr[r.Next(arr.Length)];
        }

        public static int GetRandomNumber(int low, int high)
        {
            return r.Next(low, high);
        }
    }
}
