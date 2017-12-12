using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.PLCActionPattern
{
    public static class CCommonUtil
    {
        /// <summary>
        /// Levenshtein Distance : The minimum number of single-character edits required to change one word into the other. Strings do not have to be the same length
        /// https://en.wikipedia.org/wiki/Levenshtein_distance
        /// </summary>
        /// <param name="srcString"></param>
        /// <param name="targetString"></param>
        /// <returns></returns>
        public static int GetStringCompareDistance(String srcString, String targetString)
        {
            int longStrLen = srcString.Length + 1;
            int shortStrLen = targetString.Length + 1;

            int[] cost = new int[longStrLen];
            int[] newcost = new int[longStrLen];

            for (int i = 0; i < longStrLen; i++)
            {
                cost[i] = i;
            }

            for (int j = 1; j < shortStrLen; j++)
            {
                newcost[0] = j;

                for (int i = 1; i < longStrLen; i++)
                {
                    int match = 0;
                    if (srcString.Substring(i-1,1) != targetString.Substring(j-1,1)) // if(s1.charAt(i - 1) != s2.charAt(j - 1))
                    {
                        match = 1;
                    }

                    int replace = cost[i - 1] + match;
                    int insert = cost[i] + 1;
                    int delete = newcost[i - 1] + 1;

                    newcost[i] = Math.Min(Math.Min(insert, delete), replace);
                }

                int[] temp = cost;
                cost = newcost;
                newcost = temp;
            }

            return cost[longStrLen - 1];
        }
    }
}
