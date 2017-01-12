using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumProducItemGroupClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace SumProducItemGroupClassLibrary.Tests
{
    [TestClass()]
    public class SumProductUtilityTests
    {
        private List<ProductItem> _productItems = new List<ProductItem>();

        [TestInitialize()]
        public void MyTestInitialize()
        {
            //初始化測試資料
            _productItems.Add(new ProductItem { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            _productItems.Add(new ProductItem { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            _productItems.Add(new ProductItem { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            _productItems.Add(new ProductItem { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            _productItems.Add(new ProductItem { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            _productItems.Add(new ProductItem { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            _productItems.Add(new ProductItem { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            _productItems.Add(new ProductItem { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            _productItems.Add(new ProductItem { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            _productItems.Add(new ProductItem { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            _productItems.Add(new ProductItem { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            //回收測試資料
            _productItems.Clear();
        }

        [TestMethod()]
        public void Sum_Cost_GroupCount_3_Should_Be_6_15_24_21()
        {
            var expected = new List<int> { 6, 15, 24, 21 };

            var actual = _productItems.SumByGroupWithFunc(3, p => p.Cost).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void Sum_Revenue_GroupCount_4_Should_Be_50_66_60() {
            var expected = new List<int> { 50,66,60 };

            var actual = _productItems.SumByGroupWithFunc(4, p => p.Revenue).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void Sum_SellPrice_GroupCount_5_Should_Be_115_140_31()
        {
            var expected = new List<int> { 115, 140, 31 };

            var actual = _productItems.SumByGroupWithFunc(5, p => p.SellPrice).ToList();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void Sum_Cost_GroupCount_GreatThan_ItemsCount_Shuld_Be_SumAll()
        {
            var excepted = new List<int> { _productItems.Sum(p => p.Cost) };
            int groupCount = _productItems.Count() + 1;

            var actual = _productItems.SumByGroupWithFunc(groupCount, p => p.Cost).ToList();

            actual.ShouldAllBeEquivalentTo(excepted);
        }

        [TestMethod()]
        public void Sum_Cost_Negative_GroupCount_Should_Throw_ArgumentOutOfRangeException()
        {
            Action act = () => _productItems.SumByGroupWithFunc(-5, p => p.Cost).ToList();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }


        class ProductItem {
            public int Id { get; set; }
            public int Cost { get; set; }
            public int Revenue { get; set; }
            public int SellPrice { get; set; }

        }
    }
}