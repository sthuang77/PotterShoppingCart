using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using PotterShoppingCart;

namespace PotterShoppingCart.Tests
{

    [TestClass]
    public class PotterShoppingCart
    {
        public PotterShoppingCart()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Buy_PotterBookI_1EA_price_100()  //第一集買了一本，其他都沒買，價格應為100*1=100元
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},            
            };
            var target = new ShoppingCart();
            var expected = 150;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
