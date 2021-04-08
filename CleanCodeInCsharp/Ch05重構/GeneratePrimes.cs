///<remark>
/// 產生使用者指定之最大值範圍內的質數
/// 使用的演算法是Eratosthenes篩選法
/// 給定一個整數陣列，由2開始遞增，先劃掉2的倍數
/// 找下一個尚未被劃掉的整數，去除它的所有倍數，反覆執行至傳入最大值的平方根為止
/// </remark>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanCodeInCsharp.Ch05重構
{
    public class GeneratePrimes
    {
        /// <summary>
        /// 產生一個包含質數的陣列
        /// </summary>
        /// <param name="maxValue">產生的最大值</param>
        /// <returns></returns>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue >=  2) //僅此時有意義
            {
                int s = maxValue + 1; //陣列大小
                bool[] f = new bool[s];
                int i;

                //將陣列元素初始為true
                for (i = 0; i < s; i++)
                    f[i] = true;

                //去除已知的非質數
                f[0] = f[1] = false;

                //sieve
                int j;
                for(i = 2; i < Math.Sqrt(s) + 1; i++)
                {
                    if (f[i]) //如果 i 未被劃掉，就劃掉其倍數
                    {
                        for (j = 2 * i; j < s; j += i)
                            f[j] = false; //倍數不是質數
                    }
                }

                //有多少個質數
                int count = 0;
                for (i = 0; i < s; i++)
                {
                    if(f[i]) count++;
                }

                //把質數轉移到結果陣列中
                int[] primes = new int[count];

                for(i = 0, j=0; i < s; i++)
                {
                    if (f[i]) primes[j++] = i;
                }

                return primes;
            }
            else //maxValue < 2
            {
                return new int[0]; //輸入不合理的值，則回傳空陣列
            }
        }
    }
}