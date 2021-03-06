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
        private static bool[] crossedOut;
        private static int[] result;

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
                UncrossIntegersUpTo(maxValue);
                CrossOutMultiples();
                PutUncrossedIntegersIntoResult();
                return result;
            }
        }

        private static void PutUncrossedIntegersIntoResult()
        {
            result = new int[NumberOfUncrossedIntegers()];
            for(int j = 0, i = 2; i < crossedOut.Length; i++)
            {
                if(NotCrossed(i))
                    result[j++] = i;
            }
        }

        private static int NumberOfUncrossedIntegers()
        {
            int count = 0;

            for(int i = 2; i < crossedOut.Length; i++)
            {
                if (NotCrossed(i)) count++;
            }

            return count;
        }

        /// <summary>
        /// 執行質數過濾工作
        /// </summary>
        private static void CrossOutMultiples()
        {
            int limit = DetermineIterationLimit();

            for(int i = 2; i <= limit; i++)
            {
                if (NotCrossed(i))
                    CrossOutputMultiplesOf(i);
            }
        }

        private static void CrossOutputMultiplesOf(int i)
        {
            for( int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
            {
                crossedOut[multiple] = true;
            }
        }

        private static bool NotCrossed(int i)
        {
            return crossedOut[i] == false;
        }

        private static int DetermineIterationLimit()
        {
            double iterationLimit = Math.Sqrt(crossedOut.Length);
            return (int)iterationLimit;
        }

        /// <summary>
        /// 對所有變數進行初始化
        /// </summary>
        /// <param name="maxValue">產生的最大值</param>
        private static void UncrossIntegersUpTo(int maxValue)
        {
            crossedOut = new bool[maxValue + 1];

            for (int i = 2; i < crossedOut.Length; i++)
                crossedOut[i] = false;
        }
    }
}