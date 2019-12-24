using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiValuedQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using MultiValuedQuery.Models.Database;

namespace MultiValuedQuery.Tests
{
    [TestClass()]
    public class CookiesServiceTests
    {

        [TestMethod()]
        [TestCategory("GetProducts")]
        public void GetProductsWithLinqContainsTest()
        {
            // Arrange
            var expected = new List<ViewProduct>
            {   new ViewProduct() { ProductId = 7,  ProductName = "輕乳酪蛋糕(片)", CategoryId = 2, Price = 65, CategoryName = "蛋糕類"}
            ,   new ViewProduct() { ProductId = 8,  ProductName = "重乳酪蛋糕(片)", CategoryId = 2, Price = 70, CategoryName = "蛋糕類"}
            ,   new ViewProduct() { ProductId = 9,  ProductName = "抹茶奶酪", CategoryId = 3, Price = 90, CategoryName = "奶酪類"}
            ,   new ViewProduct() { ProductId = 10, ProductName = "草莓奶酪", CategoryId = 3, Price = 85, CategoryName = "奶酪類"}
            ,   new ViewProduct() { ProductId = 11, ProductName = "芒果奶酪", CategoryId = 3, Price = 85, CategoryName = "奶酪類"}
            ,   new ViewProduct() { ProductId = 12, ProductName = "紅豆奶酪", CategoryId = 3, Price = 80, CategoryName = "奶酪類"}
            }.ToExpectedObject();

            var categories = new List<int>() { 2, 3 };

            // Act
            var obj = new CookiesService();
            var actual = obj.GetProductsWithLinqContains(categories);

            // Assert
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        [TestCategory("GetProducts")]
        public void GetProductsWithSqlInTest()
        {
            // Arrange
            var expected = new List<ViewProduct>
            {   new ViewProduct() { ProductId = 7,  ProductName = "輕乳酪蛋糕(片)", CategoryId = 2, Price = 65, CategoryName = "蛋糕類"}
                ,   new ViewProduct() { ProductId = 8,  ProductName = "重乳酪蛋糕(片)", CategoryId = 2, Price = 70, CategoryName = "蛋糕類"}
                ,   new ViewProduct() { ProductId = 9,  ProductName = "抹茶奶酪", CategoryId = 3, Price = 90, CategoryName = "奶酪類"}
                ,   new ViewProduct() { ProductId = 10, ProductName = "草莓奶酪", CategoryId = 3, Price = 85, CategoryName = "奶酪類"}
                ,   new ViewProduct() { ProductId = 11, ProductName = "芒果奶酪", CategoryId = 3, Price = 85, CategoryName = "奶酪類"}
                ,   new ViewProduct() { ProductId = 12, ProductName = "紅豆奶酪", CategoryId = 3, Price = 80, CategoryName = "奶酪類"}
            }.ToExpectedObject();

            var categories = new List<int>() { 2, 3 };

            // Act
            var obj = new CookiesService();
            var actual = obj.GetProductsWithSqlIn(categories);

            // Assert
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        [TestCategory("GetProducts")]
        public void GetProductsWithSpByEfTest()
        {
            // Arrange
            var expected = new List<ViewProduct>
            {   new ViewProduct() { ProductId = 5,  ProductName = "紅豆塔", CategoryId = 1, Price = 60, CategoryName = "餅乾類"}
            ,   new ViewProduct() { ProductId = 12, ProductName = "紅豆奶酪", CategoryId = 3, Price = 80, CategoryName = "奶酪類"}
            }.ToExpectedObject();

            var categories = new List<int>() { 1, 2, 3 };
            var productName = "紅豆";

            // Act
            var obj = new CookiesService();
            var actual = obj.GetProductsWithSpByEf(categories, productName);

            // Assert
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        [TestCategory("GetProducts")]
        public void GetProductsWithSpByEfExtrasTest()
        {
            // Arrange
            var expected = new List<ViewProduct>
            {   new ViewProduct() { ProductId = 5,  ProductName = "紅豆塔", CategoryId = 1, Price = 60, CategoryName = "餅乾類"}
            ,   new ViewProduct() { ProductId = 12, ProductName = "紅豆奶酪", CategoryId = 3, Price = 80, CategoryName = "奶酪類"}
            }.ToExpectedObject();

            var categories = new List<int>() { 1, 2, 3 };
            var productName = "紅豆";

            // Act
            var obj = new CookiesService();
            var actual = obj.GetProductsWithSpByEfExtras(categories, productName);

            // Assert
            expected.ShouldEqual(actual);
        }

    }
}