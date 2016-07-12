using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ShoppingCart
    {
        private double discount;
        private double total;

        //計算總金額       
        public double Get_Price(List<Book> books)
        {
            while (books.Any())
            {
                var bookTypeCount = books.Select(x => x.Episode).Distinct().Count();
                switch (bookTypeCount)
                {
                    case 2:
                        discount = 0.95;
                        break;
                    case 3:
                        discount = 0.9;
                        break;
                    case 4:
                        discount = 0.8;
                        break;
                    case 5:
                        discount = 0.75;
                        break;
                    default:
                        discount = 1;
                        break;
                }            

                List<Book> preferentialBooks = new List<Book>();
                foreach (var Episode in books.Select(x => x.Episode).Distinct().ToList())
                {
                    preferentialBooks.Add(books.Find(x => x.Episode == Episode));
                }

                foreach (var book in preferentialBooks)
                {
                    total += (book.Price * discount);
                    books.Remove(book);
                }              
            }
            return total;
        }
    } 
}

