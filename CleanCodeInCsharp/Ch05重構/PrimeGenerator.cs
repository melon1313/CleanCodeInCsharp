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
    public class PrimeGenerator
    {
        private static int s;
        private static bool[] f;
        private static int[] primes;

        /// <summary>
        /// 產生一個包含質數的陣列
        /// </summary>
        /// <param name="maxValue">產生的最大值</param>
        /// <returns></returns>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];
            else
            {
                InitailizeSieve(maxValue);
                Sieve();
                LoadPrimes();
                return primes;
            }
        }

        //將過濾後的結果存至另一整數列
        private static void LoadPrimes()
        {
            int count = 0;
            int i, j;

            //有多少個質數?
            for(i = 0; i < s; i++)
            {
                if (f[i]) count++;
            }

            //把質數轉移至結果陣列中
            primes = new int[count];
            for(j = 0,i = 0; i < s; i++)
            {
                if (f[i])
                   primes[j++] = i;
            }
            
        }

        /// <summary>
        /// 執行質數過濾工作
        /// </summary>
        private static void Sieve()
        {
            int i, j;

            for(i = 2; i < Math.Sqrt(s) + 1 ; i++)
            {
                if (f[i]) //如果未被劃掉，則劃掉其倍數
                {
                    for (j = 2 * i; j < s; j += i)
                    {
                        f[j] = false;
                    }
                }
            }
        }

        /// <summary>
        /// 對所有變數進行初始化
        /// </summary>
        /// <param name="maxValue">產生的最大值</param>
        private static void InitailizeSieve(int maxValue)
        {
            s = maxValue + 1; //陣列大小
            f = new bool[s];
            int i;

            //將陣列初始化為true
            for(i = 0; i < s; i++)
            {
                f[i] = true;
            }

            //去掉已知的非質數
            f[0] = f[1] = false;
        }
    }
}