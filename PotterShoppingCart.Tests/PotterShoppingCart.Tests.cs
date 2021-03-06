﻿using System;
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
            var expected = 100;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_Buy_PotterBookI_1EA_price_100_and_PotterBookII_1EA_price_100()  //第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
            };
            var target = new ShoppingCart();
            var expected = 190;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_PotterBookI_BookII_BookIII_1EA_price_100()  //一二三集各買了一本，價格應為100*3*0.9=270
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},
            };
            var target = new ShoppingCart();
            var expected = 270;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_PotterBookI_BookII_BookIII_BookIV_1EA_price_100() //一二三四集各買了一本，價格應為100*4*0.8=320
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},
                new Book {BookName = "哈利波特", Episode = 4, Price = 100},
            };
            var target = new ShoppingCart();
            var expected = 320;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_Buy_PotterBookI_BookII_BookIII_BookIV_BookV_1EA_price_100() //一次買了整套，一二三四五集各買了一本，價格應為100*5*0.75=375
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},
                new Book {BookName = "哈利波特", Episode = 4, Price = 100},
                new Book {BookName = "哈利波特", Episode = 5, Price = 100},
            };
            var target = new ShoppingCart();
            var expected = 375;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test_Buy_PotterBookI_BookII_1EA_BookIII_2EA_price_100() //一二集各買了一本，第三集買了兩本，價格應為100*3*0.9 + 100 = 370
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},

            };
            var target = new ShoppingCart();
            var expected = 370;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_PotterBookI_1EA_BookII_2EA_BookIII_2EA_price_100() //第一集買了一本，第二三集各買了兩本，價格應為100*3*0.9 + 100*2*0.95 = 460
        {
            //arrange
            var books = new List<Book>
            {
                new Book {BookName = "哈利波特", Episode = 1, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 2, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},
                new Book {BookName = "哈利波特", Episode = 3, Price = 100},

            };
            var target = new ShoppingCart();
            var expected = 460;
            //act
            var actual = target.Get_Price(books);
            //assert
            Assert.AreEqual(expected, actual);
        }

         
    }
}
