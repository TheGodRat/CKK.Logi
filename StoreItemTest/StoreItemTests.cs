using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;
using System.Threading.Tasks;
using Xunit;

namespace StoreItemTest
{
    public class Tests
    {
        ShoppingCartItem product1;
        ShoppingCartItem product2;
        ShoppingCartItem product3;

        Product item1 = new Product();
        Product item2 = new Product();
        Product item3 = new Product();
        
        [Fact]
        public void GetTotalTest()
        {
            item1.SetPrice(1m);
            item2.SetPrice(2m);
            item3.SetPrice(3m);

            product1 = new ShoppingCartItem(item1, 1);
            product2 = new ShoppingCartItem(item2, 1);
            product3 = new ShoppingCartItem(item3, 1);

            decimal expected = 6;
            decimal actual = product1.GetTotal() + product2.GetTotal() + product3.GetTotal();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddProductTest()
        {
            Customer Toby = new Customer();
            ShoppingCart cart = new ShoppingCart(Toby);

            cart.AddProduct(item1, 2);
            cart.AddProduct(item1);

            decimal expected = 3m;
            decimal actual = cart.GetProduct(1).GetQuantity();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveProductTest()
        {
            Customer Toby = new Customer();
            ShoppingCart cart = new ShoppingCart(Toby);

            cart.AddProduct(item1, 2);
            cart.RemoveProduct(item1, 1);

            decimal expected = 1m;
            decimal actual = cart.GetProduct(1).GetQuantity();

            Assert.Equal(expected, actual);
        }
    }
}
