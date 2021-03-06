﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumProducItemGroupClassLibrary
{
    public static class SumProductUtility
    {
        /// <summary>
        /// Sums the by group.
        /// </summary>
        /// <typeparam name="T">泛型型別</typeparam>
        /// <param name="collection">進行加總的集合</param>
        /// <param name="groupCount">加總的Item個數</param>
        /// <param name="sumFunc">要加總的方法</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">GroupCnt必須是大於零的整數</exception>
        public static IEnumerable<int> SumByGroupWithFunc<T>(this IEnumerable<T> collection, int groupCount, Func<T, int> sumFunc)
        {
            if (groupCount <= 0)
            {
                throw new ArgumentOutOfRangeException("GroupCnt必須是大於零的整數");
            }

            int totalCount = collection.Count();


            int index = 0;
            while (index < totalCount)
            {
                yield return collection.Skip(index).Take(groupCount).Sum(sumFunc);
                index += groupCount;
            }


        }
    }
}
